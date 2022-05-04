using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Processor;

namespace Client
{
    public partial class FormClient : Form
    {
        TcpClient client;
        string serverName;
        string clientName;
        int port;
        string localAddress;
        NetworkStream stream;
        bool hasName = false;
        System.Timers.Timer timerHeartbeat;
        System.Timers.Timer timerConnect;
        Object locker = new Object();
        public FormClient()
        {
            InitializeComponent();
            string valueIP = System.Configuration.ConfigurationManager.AppSettings["ServerIpAddress"];
            string valuePort = System.Configuration.ConfigurationManager.AppSettings["ServerPort"];
            tbIP.Text = valueIP;
            tbPort.Text = valuePort;
            btnConnect.Enabled = false;
            lvChat.View = View.List;
            lvChat.View = View.Details;
            tbMessage.Enabled = false;
            timerConnect = new System.Timers.Timer(10000);
            timerConnect.AutoReset = true;
            timerConnect.Elapsed += OnTimedEvent;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            port = int.Parse(tbPort.Text);
            localAddress = tbIP.Text;
            connect();
        }

        private void connect()
        {
            try
            {
                client = new TcpClient(localAddress, port);
                btnConnect.Enabled = false;
                Byte[] data = Encoding.ASCII.GetBytes(tbName.Text);
                stream = client.GetStream();
                Byte[] size = new Byte[2];
                size[0] = (Byte)(data.Length / 256);
                size[1] = (Byte)(data.Length % 256);
                stream.Write(size, 0, 2);
                stream.Write(data, 0, data.Length);
                Task task = Task.Factory.StartNew(() => receiveFromServer());
                timerHeartbeat = new System.Timers.Timer(2000);
                timerHeartbeat.Elapsed += heartbeat;
                timerHeartbeat.AutoReset = true;
                timerHeartbeat.Enabled = true;
                timerConnect.Enabled = false;
                this.Invoke(new Action(() =>
                {
                    tbMessage.Enabled = true;
                }));
            }
            catch(Exception e)
            {
                timerConnect.Enabled = true;
            }
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            invoke("Trying to reconnect...", "System"); 
            connect();
        }

        private void heartbeat(object sender, ElapsedEventArgs e)
        {
            Byte[] size = new Byte[2];
            size[0] = (Byte)(0);
            size[1] = (Byte)(0);
            try
            {
                stream.Write(size, 0, 2);
            }
            catch
            {
                closeConnection();
            }
        }

        private void tbMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13 && tbMessage.Text != "")
            {
                Byte[] data = Encoding.ASCII.GetBytes(tbMessage.Text);
                Byte[] size = new Byte[2];
                size[0] = (Byte)(data.Length / 256);
                size[1] = (Byte)(data.Length % 256);
                stream.Write(size, 0, 2);
                stream.Write(data, 0, data.Length);
                string message = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);
                invoke(message, "You");
                tbMessage.Clear();
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if(tbName.Text!="")
            {
                btnConnect.Enabled = true;
            }
            else
            {
                btnConnect.Enabled = false;
            }
        }

        private void receiveFromServer()
        {
            Byte[] bytes = new Byte[256];
            while (true)
            {
                try
                {
                    int i;
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        MessageProcessor.process(bytes, i, addMessage);
                    }
                }
                catch (IOException ioe)
                {
                    closeConnection();
                    return;
                }
            }
        }

        private void closeConnection()
        {
            lock (locker)
            {
                if (client != null)
                {
                    timerHeartbeat.Enabled = false;
                    this.Invoke(new Action(() =>
                    {
                        tbMessage.Enabled = false;
                    }));
                    stream.Close();
                    client.Close();
                    client = null;
                    hasName = false;
                    invoke("The server disconnected!", "System");
                    timerConnect.Enabled = true;
                }
            }
        }

        private void addMessage(string data)
        {
            if(hasName == false)
            {
                serverName = data;
                clientName = tbName.Text;
                hasName = true;
            }
            else
                invoke(data, serverName);
        }

        private void invoke(string data, string name)
        {
            this.Invoke(new Action(() =>
            {
                string message = "";
                message += name;
                message += ": ";
                message += data;
                if (name == "You")
                {
                    ListViewItem item = new ListViewItem(" ");
                    item.SubItems.Add(message);
                    lvChat.Items.Add(item);
                }
                else
                {
                    ListViewItem item = new ListViewItem(message);
                    item.SubItems.Add(" ");
                    lvChat.Items.Add(item);
                }
            }));
        }

        private void lvChat_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvChat.Columns[e.ColumnIndex].Width;
        }

        private void FormClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            stream.Close();
            client.Close();
        }
    }
}
