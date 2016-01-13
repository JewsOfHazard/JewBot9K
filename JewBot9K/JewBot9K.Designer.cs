namespace JewBot9K
{
    partial class JewBot9K
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JewBot9K));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.ChatWindow = new System.Windows.Forms.TextBox();
            this.ChatBox = new System.Windows.Forms.TextBox();
            this.VersionNumber = new System.Windows.Forms.Label();
            this.ViewersList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.AuthButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TitleUpdateBox = new System.Windows.Forms.TextBox();
            this.GameUpdateBox = new System.Windows.Forms.TextBox();
            this.TitleGameUpdateButton = new System.Windows.Forms.Button();
            this.DashboardTitleLabel = new System.Windows.Forms.Label();
            this.DashboardGameUpdateLabel = new System.Windows.Forms.Label();
            this.DashboardLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-1, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(691, 377);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DisconnectButton);
            this.tabPage1.Controls.Add(this.ChatWindow);
            this.tabPage1.Controls.Add(this.ChatBox);
            this.tabPage1.Controls.Add(this.VersionNumber);
            this.tabPage1.Controls.Add(this.ViewersList);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.ConnectButton);
            this.tabPage1.Controls.Add(this.AuthButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(683, 351);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chat";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Enabled = false;
            this.DisconnectButton.Location = new System.Drawing.Point(10, 74);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(90, 30);
            this.DisconnectButton.TabIndex = 9;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // ChatWindow
            // 
            this.ChatWindow.Location = new System.Drawing.Point(106, 3);
            this.ChatWindow.Multiline = true;
            this.ChatWindow.Name = "ChatWindow";
            this.ChatWindow.ReadOnly = true;
            this.ChatWindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatWindow.Size = new System.Drawing.Size(456, 308);
            this.ChatWindow.TabIndex = 8;
            // 
            // ChatBox
            // 
            this.ChatBox.AcceptsReturn = true;
            this.ChatBox.Location = new System.Drawing.Point(106, 317);
            this.ChatBox.Multiline = true;
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(571, 24);
            this.ChatBox.TabIndex = 7;
            this.ChatBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChatBox_KeyDown);
            // 
            // VersionNumber
            // 
            this.VersionNumber.AutoSize = true;
            this.VersionNumber.Location = new System.Drawing.Point(14, 323);
            this.VersionNumber.Name = "VersionNumber";
            this.VersionNumber.Size = new System.Drawing.Size(78, 13);
            this.VersionNumber.TabIndex = 6;
            this.VersionNumber.Text = "Version 0.0.0.0";
            this.VersionNumber.Click += new System.EventHandler(this.VersionLabel_Click);
            // 
            // ViewersList
            // 
            this.ViewersList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewersList.FormattingEnabled = true;
            this.ViewersList.ItemHeight = 16;
            this.ViewersList.Location = new System.Drawing.Point(568, 3);
            this.ViewersList.Name = "ViewersList";
            this.ViewersList.Size = new System.Drawing.Size(109, 308);
            this.ViewersList.TabIndex = 5;
            this.ViewersList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ViewersList_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Disconnected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Status:";
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(10, 40);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(90, 30);
            this.ConnectButton.TabIndex = 1;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // AuthButton
            // 
            this.AuthButton.Location = new System.Drawing.Point(10, 7);
            this.AuthButton.Name = "AuthButton";
            this.AuthButton.Size = new System.Drawing.Size(90, 30);
            this.AuthButton.TabIndex = 0;
            this.AuthButton.Text = "Authorize";
            this.AuthButton.UseVisualStyleBackColor = true;
            this.AuthButton.Click += new System.EventHandler(this.AuthButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DashboardLabel);
            this.tabPage2.Controls.Add(this.DashboardGameUpdateLabel);
            this.tabPage2.Controls.Add(this.DashboardTitleLabel);
            this.tabPage2.Controls.Add(this.TitleGameUpdateButton);
            this.tabPage2.Controls.Add(this.GameUpdateBox);
            this.tabPage2.Controls.Add(this.TitleUpdateBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(683, 351);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dashboard";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 15000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TitleUpdateBox
            // 
            this.TitleUpdateBox.Location = new System.Drawing.Point(154, 10);
            this.TitleUpdateBox.Name = "TitleUpdateBox";
            this.TitleUpdateBox.Size = new System.Drawing.Size(190, 20);
            this.TitleUpdateBox.TabIndex = 0;
            // 
            // GameUpdateBox
            // 
            this.GameUpdateBox.Location = new System.Drawing.Point(406, 9);
            this.GameUpdateBox.Name = "GameUpdateBox";
            this.GameUpdateBox.Size = new System.Drawing.Size(190, 20);
            this.GameUpdateBox.TabIndex = 1;
            // 
            // TitleGameUpdateButton
            // 
            this.TitleGameUpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleGameUpdateButton.Location = new System.Drawing.Point(602, 8);
            this.TitleGameUpdateButton.Name = "TitleGameUpdateButton";
            this.TitleGameUpdateButton.Size = new System.Drawing.Size(75, 23);
            this.TitleGameUpdateButton.TabIndex = 2;
            this.TitleGameUpdateButton.Text = "Update";
            this.TitleGameUpdateButton.UseVisualStyleBackColor = true;
            this.TitleGameUpdateButton.Click += new System.EventHandler(this.TitleGameUpdateButton_Click);
            // 
            // DashboardTitleLabel
            // 
            this.DashboardTitleLabel.AutoSize = true;
            this.DashboardTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashboardTitleLabel.Location = new System.Drawing.Point(112, 11);
            this.DashboardTitleLabel.Name = "DashboardTitleLabel";
            this.DashboardTitleLabel.Size = new System.Drawing.Size(39, 18);
            this.DashboardTitleLabel.TabIndex = 3;
            this.DashboardTitleLabel.Text = "Title:";
            // 
            // DashboardGameUpdateLabel
            // 
            this.DashboardGameUpdateLabel.AutoSize = true;
            this.DashboardGameUpdateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashboardGameUpdateLabel.Location = new System.Drawing.Point(350, 9);
            this.DashboardGameUpdateLabel.Name = "DashboardGameUpdateLabel";
            this.DashboardGameUpdateLabel.Size = new System.Drawing.Size(53, 18);
            this.DashboardGameUpdateLabel.TabIndex = 4;
            this.DashboardGameUpdateLabel.Text = "Game:";
            // 
            // DashboardLabel
            // 
            this.DashboardLabel.AutoSize = true;
            this.DashboardLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashboardLabel.Location = new System.Drawing.Point(6, 6);
            this.DashboardLabel.Name = "DashboardLabel";
            this.DashboardLabel.Size = new System.Drawing.Size(106, 26);
            this.DashboardLabel.TabIndex = 5;
            this.DashboardLabel.Text = "Dasboard";
            // 
            // JewBot9K
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 375);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "JewBot9K";
            this.Text = "Hazard Bot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JewBot9K_FormClosed);
            this.Load += new System.EventHandler(this.JewBot9K_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button AuthButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ChatBox;
        private System.Windows.Forms.Label VersionNumber;
        private System.Windows.Forms.ListBox ViewersList;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox ChatWindow;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.Label DashboardGameUpdateLabel;
        private System.Windows.Forms.Label DashboardTitleLabel;
        private System.Windows.Forms.Button TitleGameUpdateButton;
        private System.Windows.Forms.TextBox GameUpdateBox;
        private System.Windows.Forms.TextBox TitleUpdateBox;
        private System.Windows.Forms.Label DashboardLabel;
    }
}

