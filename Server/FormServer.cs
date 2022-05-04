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
using System.Windows.Forms;
using System.Windows.Threading;
using Processor;

namespace Server
{
    public partial class FormServer : Form
    {
        TcpListener server;
        TcpClient client;
        string clientName;
        string serverName;
        NetworkStream stream;
        bool hasName = false;
        Dispatcher disp;
        public FormServer()
        {
            InitializeComponent();
            string valueIP = System.Configuration.ConfigurationManager.AppSettings["ServerIpAddress"];
            string valuePort = System.Configuration.ConfigurationManager.AppSettings["ServerPort"];
            tbIP.Text = valueIP;
            tbPort.Text = valuePort;
            btnListen.Enabled = false;
            lvChat.View = View.List;
            lvChat.View = View.Details;
            tbMessage.Enabled = false;
            disp = Dispatcher.CurrentDispatcher;
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            int port = int.Parse(tbPort.Text);
            IPAddress localAddress = IPAddress.Parse(tbIP.Text);
            server = new TcpListener(localAddress, port);
            server.Start();
            Task task = Task.Factory.StartNew( () => listenForClient());
            btnListen.Enabled = false;
            tbName.Enabled = false;
            //this.Controls.Add(btnListen);
        }

        private void listenForClient()
        {
            Byte[] bytes = new Byte[256];
            client = server.AcceptTcpClient();
            this.Invoke(new Action(() =>
            {
                tbMessage.Enabled = true;
            }));
            stream = client.GetStream();
            Byte[] data = Encoding.ASCII.GetBytes(tbName.Text);
            Byte[] size = new Byte[2];
            size[0] = (Byte)(data.Length / 256);
            size[1] = (Byte)(data.Length % 256);
            stream.Write(size, 0, 2);
            stream.Write(data, 0, data.Length);
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
                catch(IOException ioe)
                {
                    stream.Close();
                    client.Close();
                    client = null;
                    hasName = false;
                    this.Invoke(new Action(() =>
                    {
                        tbMessage.Enabled = false;
                    }));
                    invoke("The client disconnected!", "System");
                    Task task = Task.Factory.StartNew(() => listenForClient());
                    return;
                }
            }
        }

        private void addMessage(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                if (hasName == false)
                {
                    clientName = data;
                    serverName = tbName.Text;
                    hasName = true;
                }
                else
                    invoke(data, clientName);
            }
        }

        private void invoke(string data, string name)
        {
            this.Invoke(new Action(() =>
            {
                string message = "";
                message += name;
                message += ": ";
                message += data;
                if(name == "You")
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

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (tbName.Text != "" && hasName == false)
            {
                btnListen.Enabled = true;
            }
        }

        private void tbMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && tbMessage.Text != "")
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

        private void lvChat_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvChat.Columns[e.ColumnIndex].Width;
        }

        private void FormServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            stream.Close();
            client.Close();
        }
    }
}
