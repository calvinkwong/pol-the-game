namespace PoL.WinFormsView.GameStarters
{
  partial class LobbyView
  {
    /// <summary>
    /// Variabile di progettazione necessaria.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Liberare le risorse in uso.
    /// </summary>
    /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
    protected override void Dispose(bool disposing)
    {
      if(disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Codice generato da Progettazione Windows Form

    /// <summary>
    /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
    /// il contenuto del metodo con l'editor di codice.
    /// </summary>
    private void InitializeComponent()
    {
      this.btnReady = new RibbonStyle.RibbonMenuButton();
      this.btnSideboarding = new RibbonStyle.RibbonMenuButton();
      this.btnStart = new RibbonStyle.RibbonMenuButton();
      this.btnCancel = new RibbonStyle.RibbonMenuButton();
      this.pnlPlayers = new System.Windows.Forms.Panel();
      this.listPlayers = new System.Windows.Forms.FlowLayoutPanel();
      this.pnlPlayersTitle = new System.Windows.Forms.Panel();
      this.lblPlayers = new RibbonStyle.RibbonMenuButton();
      this.pnlPlayers.SuspendLayout();
      this.pnlPlayersTitle.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnReady
      // 
      this.btnReady.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnReady.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnReady.BackColor = System.Drawing.Color.Transparent;
      this.btnReady.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnReady.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnReady.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnReady.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnReady.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnReady.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnReady.FadingSpeed = 20;
      this.btnReady.FlatAppearance.BorderSize = 0;
      this.btnReady.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnReady.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnReady.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnReady.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
      this.btnReady.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnReady.ImageOffset = 8;
      this.btnReady.IsPressed = false;
      this.btnReady.KeepPress = false;
      this.btnReady.Location = new System.Drawing.Point(190, 318);
      this.btnReady.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnReady.MenuPos = new System.Drawing.Point(0, 0);
      this.btnReady.Name = "btnReady";
      this.btnReady.Radius = 15;
      this.btnReady.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnReady.Size = new System.Drawing.Size(117, 41);
      this.btnReady.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnReady.SplitDistance = 30;
      this.btnReady.TabIndex = 118;
      this.btnReady.Text = "Ready";
      this.btnReady.Title = "";
      this.btnReady.UseVisualStyleBackColor = true;
      // 
      // btnSideboarding
      // 
      this.btnSideboarding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSideboarding.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnSideboarding.BackColor = System.Drawing.Color.Transparent;
      this.btnSideboarding.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnSideboarding.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnSideboarding.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnSideboarding.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnSideboarding.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnSideboarding.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnSideboarding.FadingSpeed = 20;
      this.btnSideboarding.FlatAppearance.BorderSize = 0;
      this.btnSideboarding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSideboarding.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnSideboarding.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnSideboarding.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
      this.btnSideboarding.Image = global::PoL.WinFormsView.Properties.Resources.applications_accessories;
      this.btnSideboarding.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnSideboarding.ImageOffset = 8;
      this.btnSideboarding.IsPressed = false;
      this.btnSideboarding.KeepPress = false;
      this.btnSideboarding.Location = new System.Drawing.Point(313, 318);
      this.btnSideboarding.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnSideboarding.MenuPos = new System.Drawing.Point(0, 0);
      this.btnSideboarding.Name = "btnSideboarding";
      this.btnSideboarding.Radius = 15;
      this.btnSideboarding.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnSideboarding.Size = new System.Drawing.Size(117, 41);
      this.btnSideboarding.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnSideboarding.SplitDistance = 30;
      this.btnSideboarding.TabIndex = 117;
      this.btnSideboarding.Text = "Sideboarding";
      this.btnSideboarding.Title = "";
      this.btnSideboarding.UseVisualStyleBackColor = true;
      // 
      // btnStart
      // 
      this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnStart.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnStart.BackColor = System.Drawing.Color.Transparent;
      this.btnStart.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnStart.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnStart.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnStart.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnStart.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnStart.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnStart.FadingSpeed = 20;
      this.btnStart.FlatAppearance.BorderSize = 0;
      this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnStart.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnStart.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
      this.btnStart.Image = global::PoL.WinFormsView.Properties.Resources.emblem_default;
      this.btnStart.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnStart.ImageOffset = 8;
      this.btnStart.IsPressed = false;
      this.btnStart.KeepPress = false;
      this.btnStart.Location = new System.Drawing.Point(67, 318);
      this.btnStart.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnStart.MenuPos = new System.Drawing.Point(0, 0);
      this.btnStart.Name = "btnStart";
      this.btnStart.Radius = 15;
      this.btnStart.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnStart.Size = new System.Drawing.Size(117, 41);
      this.btnStart.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnStart.SplitDistance = 30;
      this.btnStart.TabIndex = 116;
      this.btnStart.Text = "Start";
      this.btnStart.Title = "";
      this.btnStart.UseVisualStyleBackColor = true;
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
      this.btnCancel.Location = new System.Drawing.Point(436, 318);
      this.btnCancel.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnCancel.MenuPos = new System.Drawing.Point(0, 0);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Radius = 15;
      this.btnCancel.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnCancel.Size = new System.Drawing.Size(117, 41);
      this.btnCancel.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnCancel.SplitDistance = 30;
      this.btnCancel.TabIndex = 114;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.Title = "";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // pnlPlayers
      // 
      this.pnlPlayers.Controls.Add(this.listPlayers);
      this.pnlPlayers.Controls.Add(this.pnlPlayersTitle);
      this.pnlPlayers.Location = new System.Drawing.Point(12, 12);
      this.pnlPlayers.Name = "pnlPlayers";
      this.pnlPlayers.Size = new System.Drawing.Size(300, 290);
      this.pnlPlayers.TabIndex = 113;
      // 
      // listPlayers
      // 
      this.listPlayers.AutoScroll = true;
      this.listPlayers.BackColor = System.Drawing.Color.White;
      this.listPlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.listPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listPlayers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.listPlayers.Location = new System.Drawing.Point(0, 45);
      this.listPlayers.Name = "listPlayers";
      this.listPlayers.Size = new System.Drawing.Size(300, 245);
      this.listPlayers.TabIndex = 112;
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
      this.lblPlayers.Radius = 15;
      this.lblPlayers.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.lblPlayers.Size = new System.Drawing.Size(300, 45);
      this.lblPlayers.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.lblPlayers.SplitDistance = 0;
      this.lblPlayers.TabIndex = 48;
      this.lblPlayers.Text = "Room list";
      this.lblPlayers.Title = "Rooms";
      this.lblPlayers.UseVisualStyleBackColor = true;
      // 
      // LobbyView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(630, 371);
      this.Controls.Add(this.btnReady);
      this.Controls.Add(this.btnSideboarding);
      this.Controls.Add(this.btnStart);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.pnlPlayers);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "LobbyView";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "LobbyView";
      this.pnlPlayers.ResumeLayout(false);
      this.pnlPlayersTitle.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private RibbonStyle.RibbonMenuButton btnReady;
    private RibbonStyle.RibbonMenuButton btnSideboarding;
    private RibbonStyle.RibbonMenuButton btnStart;
    private RibbonStyle.RibbonMenuButton btnCancel;
    private System.Windows.Forms.Panel pnlPlayers;
    private System.Windows.Forms.FlowLayoutPanel listPlayers;
    private System.Windows.Forms.Panel pnlPlayersTitle;
    private RibbonStyle.RibbonMenuButton lblPlayers;

  }
}