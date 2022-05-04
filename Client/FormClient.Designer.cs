
namespace Client
{
    partial class FormClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelPort = new System.Windows.Forms.Label();
            this.labelIP = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvChat = new System.Windows.Forms.ListView();
            this.clCorresp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clYou = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbInfo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(27, 79);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(34, 17);
            this.labelPort.TabIndex = 0;
            this.labelPort.Text = "Port";
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(41, 139);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(20, 17);
            this.labelIP.TabIndex = 1;
            this.labelIP.Text = "IP";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(113, 74);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 22);
            this.tbPort.TabIndex = 2;
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(113, 134);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(100, 22);
            this.tbIP.TabIndex = 3;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(113, 206);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(110, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(285, 604);
            this.tbMessage.MaxLength = 50;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(922, 22);
            this.tbMessage.TabIndex = 5;
            this.tbMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMessage_KeyPress);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(113, 20);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 22);
            this.tbName.TabIndex = 7;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(16, 25);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(45, 17);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "Name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.labelPort);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.tbPort);
            this.panel1.Controls.Add(this.tbIP);
            this.panel1.Controls.Add(this.labelIP);
            this.panel1.Location = new System.Drawing.Point(12, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 252);
            this.panel1.TabIndex = 9;
            // 
            // lvChat
            // 
            this.lvChat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clCorresp,
            this.clYou});
            this.lvChat.HideSelection = false;
            this.lvChat.Location = new System.Drawing.Point(285, 23);
            this.lvChat.Name = "lvChat";
            this.lvChat.Size = new System.Drawing.Size(922, 547);
            this.lvChat.TabIndex = 10;
            this.lvChat.UseCompatibleStateImageBehavior = false;
            this.lvChat.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvChat_ColumnWidthChanging);
            // 
            // clCorresp
            // 
            this.clCorresp.Text = "Correspondent";
            this.clCorresp.Width = 347;
            // 
            // clYou
            // 
            this.clYou.Text = "You";
            this.clYou.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clYou.Width = 347;
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(1012, 584);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(195, 17);
            this.lbInfo.TabIndex = 11;
            this.lbInfo.Text = "*maximum size: 50 characters";
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1244, 670);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.lvChat);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbMessage);
            this.MaximizeBox = false;
            this.Name = "FormClient";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClient_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvChat;
        private System.Windows.Forms.ColumnHeader clCorresp;
        private System.Windows.Forms.ColumnHeader clYou;
        private System.Windows.Forms.Label lbInfo;
    }
}

