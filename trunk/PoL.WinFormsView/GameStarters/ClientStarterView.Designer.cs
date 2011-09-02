namespace PoL.WinFormsView.GameStarters
{
  partial class ClientStarterView
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientStarterView));
          this.pnlPlayers = new System.Windows.Forms.Panel();
          this.listPlayers = new System.Windows.Forms.FlowLayoutPanel();
          this.pnlPlayersTitle = new System.Windows.Forms.Panel();
          this.lblPlayers = new RibbonStyle.RibbonMenuButton();
          this.pnlConsole = new System.Windows.Forms.Panel();
          this.consoleView = new PoL.WinFormsView.Game.ConsoleView();
          this.pnlConsoleTitle = new System.Windows.Forms.Panel();
          this.lblConsoleTitle = new RibbonStyle.RibbonMenuButton();
          this.btnCancel = new RibbonStyle.RibbonMenuButton();
          this.pnlPlayers.SuspendLayout();
          this.pnlPlayersTitle.SuspendLayout();
          this.pnlConsole.SuspendLayout();
          this.pnlConsoleTitle.SuspendLayout();
          this.SuspendLayout();
          // 
          // pnlPlayers
          // 
          this.pnlPlayers.Controls.Add(this.listPlayers);
          this.pnlPlayers.Controls.Add(this.pnlPlayersTitle);
          this.pnlPlayers.Location = new System.Drawing.Point(12, 12);
          this.pnlPlayers.Name = "pnlPlayers";
          this.pnlPlayers.Size = new System.Drawing.Size(300, 290);
          this.pnlPlayers.TabIndex = 105;
          // 
          // listPlayers
          // 
          this.listPlayers.AutoScroll = true;
          this.listPlayers.BackColor = System.Drawing.Color.White;
          this.listPlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.listPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
          this.listPlayers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
          this.listPlayers.Font = new System.Drawing.Font("Segoe UI", 9F);
          this.listPlayers.Location = new System.Drawing.Point(0, 45);
          this.listPlayers.Name = "listPlayers";
          this.listPlayers.Size = new System.Drawing.Size(300, 245);
          this.listPlayers.TabIndex = 113;
          this.listPlayers.WrapContents = false;
          // 
          // pnlPlayersTitle
          // 
          this.pnlPlayersTitle.Controls.Add(this.lblPlayers);
          this.pnlPlayersTitle.Dock = System.Windows.Forms.DockStyle.Top;
          this.pnlPlayersTitle.Location = new System.Drawing.Point(0, 0);
          this.pnlPlayersTitle.Name = "pnlPlayersTitle";
          this.pnlPlayersTitle.Size = new System.Drawing.Size(300, 45);
          this.pnlPlayersTitle.TabIndex = 107;
          // 
          // lblPlayers
          // 
          this.lblPlayers.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
          this.lblPlayers.BackColor = System.Drawing.Color.Transparent;
          this.lblPlayers.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
          this.lblPlayers.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
          this.lblPlayers.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
          this.lblPlayers.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
          this.lblPlayers.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
          this.lblPlayers.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
          this.lblPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblPlayers.Enabled = false;
          this.lblPlayers.FadingSpeed = 0;
          this.lblPlayers.FlatAppearance.BorderSize = 0;
          this.lblPlayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.lblPlayers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblPlayers.ForeColor = System.Drawing.Color.DarkBlue;
          this.lblPlayers.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Top;
          this.lblPlayers.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
          this.lblPlayers.ImageOffset = 5;
          this.lblPlayers.IsPressed = false;
          this.lblPlayers.KeepPress = false;
          this.lblPlayers.Location = new System.Drawing.Point(0, 0);
          this.lblPlayers.MaxImageSize = new System.Drawing.Point(38, 0);
          this.lblPlayers.MenuPos = new System.Drawing.Point(0, 0);
          this.lblPlayers.Name = "lblPlayers";
          this.lblPlayers.Radius = 10;
          this.lblPlayers.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
          this.lblPlayers.Size = new System.Drawing.Size(300, 45);
          this.lblPlayers.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
          this.lblPlayers.SplitDistance = 0;
          this.lblPlayers.TabIndex = 48;
          this.lblPlayers.Text = "Player list";
          this.lblPlayers.Title = "Players";
          this.lblPlayers.UseVisualStyleBackColor = true;
          // 
          // pnlConsole
          // 
          this.pnlConsole.Controls.Add(this.consoleView);
          this.pnlConsole.Controls.Add(this.pnlConsoleTitle);
          this.pnlConsole.Font = new System.Drawing.Font("Segoe UI", 9F);
          this.pnlConsole.Location = new System.Drawing.Point(318, 12);
          this.pnlConsole.Name = "pnlConsole";
          this.pnlConsole.Size = new System.Drawing.Size(300, 290);
          this.pnlConsole.TabIndex = 106;
          // 
          // consoleView
          // 
          this.consoleView.CurrentText = "";
          this.consoleView.DefaultMessagesVisible = false;
          this.consoleView.Dock = System.Windows.Forms.DockStyle.Fill;
          this.consoleView.Location = new System.Drawing.Point(0, 45);
          this.consoleView.Name = "consoleView";
          this.consoleView.Size = new System.Drawing.Size(300, 245);
          this.consoleView.TabIndex = 104;
          // 
          // pnlConsoleTitle
          // 
          this.pnlConsoleTitle.Controls.Add(this.lblConsoleTitle);
          this.pnlConsoleTitle.Dock = System.Windows.Forms.DockStyle.Top;
          this.pnlConsoleTitle.Location = new System.Drawing.Point(0, 0);
          this.pnlConsoleTitle.Name = "pnlConsoleTitle";
          this.pnlConsoleTitle.Size = new System.Drawing.Size(300, 45);
          this.pnlConsoleTitle.TabIndex = 0;
          // 
          // lblConsoleTitle
          // 
          this.lblConsoleTitle.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
          this.lblConsoleTitle.BackColor = System.Drawing.Color.Transparent;
          this.lblConsoleTitle.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
          this.lblConsoleTitle.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
          this.lblConsoleTitle.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
          this.lblConsoleTitle.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
          this.lblConsoleTitle.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
          this.lblConsoleTitle.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
          this.lblConsoleTitle.Dock = System.Windows.Forms.DockStyle.Fill;
          this.lblConsoleTitle.Enabled = false;
          this.lblConsoleTitle.FadingSpeed = 0;
          this.lblConsoleTitle.FlatAppearance.BorderSize = 0;
          this.lblConsoleTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.lblConsoleTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblConsoleTitle.ForeColor = System.Drawing.Color.DarkBlue;
          this.lblConsoleTitle.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Top;
          this.lblConsoleTitle.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
          this.lblConsoleTitle.ImageOffset = 5;
          this.lblConsoleTitle.IsPressed = false;
          this.lblConsoleTitle.KeepPress = false;
          this.lblConsoleTitle.Location = new System.Drawing.Point(0, 0);
          this.lblConsoleTitle.MaxImageSize = new System.Drawing.Point(38, 0);
          this.lblConsoleTitle.MenuPos = new System.Drawing.Point(0, 0);
          this.lblConsoleTitle.Name = "lblConsoleTitle";
          this.lblConsoleTitle.Radius = 10;
          this.lblConsoleTitle.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
          this.lblConsoleTitle.Size = new System.Drawing.Size(300, 45);
          this.lblConsoleTitle.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
          this.lblConsoleTitle.SplitDistance = 0;
          this.lblConsoleTitle.TabIndex = 49;
          this.lblConsoleTitle.Text = "Chat";
          this.lblConsoleTitle.Title = "Chat";
          this.lblConsoleTitle.UseVisualStyleBackColor = true;
          // 
          // btnCancel
          // 
          this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
          this.btnCancel.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
          this.btnCancel.BackColor = System.Drawing.Color.Transparent;
          this.btnCancel.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
          this.btnCancel.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
          this.btnCancel.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
          this.btnCancel.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
          this.btnCancel.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
          this.btnCancel.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
          this.btnCancel.FadingSpeed = 20;
          this.btnCancel.FlatAppearance.BorderSize = 0;
          this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnCancel.ForeColor = System.Drawing.Color.DarkBlue;
          this.btnCancel.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
          this.btnCancel.Image = global::PoL.WinFormsView.Properties.Resources.emblem_symbolic_link;
          this.btnCancel.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
          this.btnCancel.ImageOffset = 8;
          this.btnCancel.IsPressed = false;
          this.btnCancel.KeepPress = false;
          this.btnCancel.Location = new System.Drawing.Point(257, 315);
          this.btnCancel.MaxImageSize = new System.Drawing.Point(24, 24);
          this.btnCancel.MenuPos = new System.Drawing.Point(0, 0);
          this.btnCancel.Name = "btnCancel";
          this.btnCancel.Radius = 10;
          this.btnCancel.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
          this.btnCancel.Size = new System.Drawing.Size(117, 41);
          this.btnCancel.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
          this.btnCancel.SplitDistance = 30;
          this.btnCancel.TabIndex = 105;
          this.btnCancel.Text = "Cancel";
          this.btnCancel.Title = "";
          this.btnCancel.UseVisualStyleBackColor = true;
          // 
          // ClientStarterView
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.SystemColors.Control;
          this.ClientSize = new System.Drawing.Size(630, 368);
          this.Controls.Add(this.btnCancel);
          this.Controls.Add(this.pnlConsole);
          this.Controls.Add(this.pnlPlayers);
          this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "ClientStarterView";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Join to multiplayer game";
          this.pnlPlayers.ResumeLayout(false);
          this.pnlPlayersTitle.ResumeLayout(false);
          this.pnlConsole.ResumeLayout(false);
          this.pnlConsoleTitle.ResumeLayout(false);
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPlayers;
        private System.Windows.Forms.Panel pnlPlayersTitle;
        private RibbonStyle.RibbonMenuButton lblPlayers;
        private System.Windows.Forms.Panel pnlConsole;
        private System.Windows.Forms.Panel pnlConsoleTitle;
        private PoL.WinFormsView.Game.ConsoleView consoleView;
        private RibbonStyle.RibbonMenuButton lblConsoleTitle;
        private RibbonStyle.RibbonMenuButton btnCancel;
        private System.Windows.Forms.FlowLayoutPanel listPlayers;





    }
}

