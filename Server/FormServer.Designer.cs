
namespace Server
{
    partial class FormServer
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
            this.btnListen = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbMessage = new System.Windows.Forms.TextBox();
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
            this.labelPort.Location = new System.Drawing.Point(27, 83);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(34, 17);
            this.labelPort.TabIndex = 0;
            this.labelPort.Text = "Port";
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(41, 132);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(20, 17);
            this.labelIP.TabIndex = 1;
            this.labelIP.Text = "IP";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(131, 78);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 22);
            this.tbPort.TabIndex = 2;
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(131, 127);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(100, 22);
            this.tbIP.TabIndex = 3;
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(130, 184);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(101, 23);
            this.btnListen.TabIndex = 4;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(16, 33);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(45, 17);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(131, 28);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 22);
            this.tbName.TabIndex = 6;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(303, 600);
            this.tbMessage.MaxLength = 50;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(911, 22);
            this.tbMessage.TabIndex = 7;
            this.tbMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMessage_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.labelPort);
            this.panel1.Controls.Add(this.btnListen);
            this.panel1.Controls.Add(this.tbPort);
            this.panel1.Controls.Add(this.labelIP);
            this.panel1.Controls.Add(this.tbIP);
            this.panel1.Location = new System.Drawing.Point(12, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 236);
            this.panel1.TabIndex = 9;
            // 
            // lvChat
            // 
            this.lvChat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clCorresp,
            this.clYou});
            this.lvChat.HideSelection = false;
            this.lvChat.Location = new System.Drawing.Point(303, 28);
            this.lvChat.Name = "lvChat";
            this.lvChat.Size = new System.Drawing.Size(911, 548);
            this.lvChat.TabIndex = 10;
            this.lvChat.UseCompatibleStateImageBehavior = false;
            this.lvChat.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvChat_ColumnWidthChanging);
            // 
            // clCorresp
            // 
            this.clCorresp.Text = "Correspondent";
            this.clCorresp.Width = 343;
            // 
            // clYou
            // 
            this.clYou.Text = "You";
            this.clYou.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clYou.Width = 343;
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(1019, 580);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(195, 17);
            this.lbInfo.TabIndex = 11;
            this.lbInfo.Text = "*maximum size: 50 characters";
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1235, 643);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.lvChat);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbMessage);
            this.MaximizeBox = false;
            this.Name = "FormServer";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormServer_FormClosing);
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
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvChat;
        private System.Windows.Forms.ColumnHeader clCorresp;
        private System.Windows.Forms.ColumnHeader clYou;
        private System.Windows.Forms.Label lbInfo;
    }
}

