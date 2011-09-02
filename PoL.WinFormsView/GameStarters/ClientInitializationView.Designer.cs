namespace PoL.WinFormsView.GameStarters
{
  partial class ClientInitializationView
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
      this.numPort = new System.Windows.Forms.NumericUpDown();
      this.lblPassword = new System.Windows.Forms.Label();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.lblServerIP = new System.Windows.Forms.Label();
      this.lblServerPort = new System.Windows.Forms.Label();
      this.txtClientIP = new System.Windows.Forms.TextBox();
      this.pnlMain = new System.Windows.Forms.FlowLayoutPanel();
      this.pnlDeck = new System.Windows.Forms.Panel();
      this.txtDeckName = new System.Windows.Forms.TextBox();
      this.btnBrowseDecks = new RibbonStyle.RibbonMenuButton();
      this.lblDeck = new System.Windows.Forms.Label();
      this.pnlPassword = new System.Windows.Forms.Panel();
      this.pnlServerParameters = new System.Windows.Forms.Panel();
      this.btnOk = new RibbonStyle.RibbonMenuButton();
      this.btnCancel = new RibbonStyle.RibbonMenuButton();
      ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
      this.pnlMain.SuspendLayout();
      this.pnlDeck.SuspendLayout();
      this.pnlPassword.SuspendLayout();
      this.pnlServerParameters.SuspendLayout();
      this.SuspendLayout();
      // 
      // numPort
      // 
      this.numPort.Location = new System.Drawing.Point(6, 60);
      this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.numPort.Name = "numPort";
      this.numPort.Size = new System.Drawing.Size(120, 20);
      this.numPort.TabIndex = 112;
      // 
      // lblPassword
      // 
      this.lblPassword.AutoSize = true;
      this.lblPassword.Location = new System.Drawing.Point(4, 8);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(56, 13);
      this.lblPassword.TabIndex = 111;
      this.lblPassword.Text = "Password:";
      this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtPassword
      // 
      this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
      this.txtPassword.ForeColor = System.Drawing.SystemColors.ControlText;
      this.txtPassword.Location = new System.Drawing.Point(7, 24);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new System.Drawing.Size(195, 23);
      this.txtPassword.TabIndex = 110;
      this.txtPassword.UseSystemPasswordChar = true;
      // 
      // lblServerIP
      // 
      this.lblServerIP.AutoSize = true;
      this.lblServerIP.BackColor = System.Drawing.Color.Transparent;
      this.lblServerIP.Location = new System.Drawing.Point(3, 4);
      this.lblServerIP.Name = "lblServerIP";
      this.lblServerIP.Size = new System.Drawing.Size(54, 13);
      this.lblServerIP.TabIndex = 109;
      this.lblServerIP.Text = "Server IP:";
      this.lblServerIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblServerPort
      // 
      this.lblServerPort.AutoSize = true;
      this.lblServerPort.BackColor = System.Drawing.Color.Transparent;
      this.lblServerPort.Location = new System.Drawing.Point(4, 43);
      this.lblServerPort.Name = "lblServerPort";
      this.lblServerPort.Size = new System.Drawing.Size(62, 13);
      this.lblServerPort.TabIndex = 108;
      this.lblServerPort.Text = "Server port:";
      this.lblServerPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtClientIP
      // 
      this.txtClientIP.Location = new System.Drawing.Point(6, 20);
      this.txtClientIP.Name = "txtClientIP";
      this.txtClientIP.Size = new System.Drawing.Size(116, 20);
      this.txtClientIP.TabIndex = 107;
      this.txtClientIP.Text = "127.0.0.1";
      // 
      // pnlMain
      // 
      this.pnlMain.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.sfondoblu;
      this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pnlMain.Controls.Add(this.pnlDeck);
      this.pnlMain.Controls.Add(this.pnlPassword);
      this.pnlMain.Controls.Add(this.pnlServerParameters);
      this.pnlMain.Location = new System.Drawing.Point(12, 12);
      this.pnlMain.Name = "pnlMain";
      this.pnlMain.Size = new System.Drawing.Size(274, 227);
      this.pnlMain.TabIndex = 113;
      // 
      // pnlDeck
      // 
      this.pnlDeck.BackColor = System.Drawing.Color.Transparent;
      this.pnlDeck.Controls.Add(this.txtDeckName);
      this.pnlDeck.Controls.Add(this.btnBrowseDecks);
      this.pnlDeck.Controls.Add(this.lblDeck);
      this.pnlDeck.Location = new System.Drawing.Point(3, 3);
      this.pnlDeck.Name = "pnlDeck";
      this.pnlDeck.Size = new System.Drawing.Size(259, 60);
      this.pnlDeck.TabIndex = 115;
      // 
      // txtDeckName
      // 
      this.txtDeckName.Location = new System.Drawing.Point(7, 29);
      this.txtDeckName.Name = "txtDeckName";
      this.txtDeckName.ReadOnly = true;
      this.txtDeckName.Size = new System.Drawing.Size(194, 20);
      this.txtDeckName.TabIndex = 107;
      // 
      // btnBrowseDecks
      // 
      this.btnBrowseDecks.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnBrowseDecks.BackColor = System.Drawing.Color.Transparent;
      this.btnBrowseDecks.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnBrowseDecks.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnBrowseDecks.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnBrowseDecks.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnBrowseDecks.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnBrowseDecks.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnBrowseDecks.FadingSpeed = 20;
      this.btnBrowseDecks.FlatAppearance.BorderSize = 0;
      this.btnBrowseDecks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnBrowseDecks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnBrowseDecks.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnBrowseDecks.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
      this.btnBrowseDecks.Image = global::PoL.WinFormsView.Properties.Resources.stock_book_open;
      this.btnBrowseDecks.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnBrowseDecks.ImageOffset = 8;
      this.btnBrowseDecks.IsPressed = false;
      this.btnBrowseDecks.KeepPress = false;
      this.btnBrowseDecks.Location = new System.Drawing.Point(207, 20);
      this.btnBrowseDecks.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnBrowseDecks.MenuPos = new System.Drawing.Point(0, 0);
      this.btnBrowseDecks.Name = "btnBrowseDecks";
      this.btnBrowseDecks.Radius = 15;
      this.btnBrowseDecks.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnBrowseDecks.Size = new System.Drawing.Size(33, 29);
      this.btnBrowseDecks.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnBrowseDecks.SplitDistance = 30;
      this.btnBrowseDecks.TabIndex = 106;
      this.btnBrowseDecks.Title = "";
      this.btnBrowseDecks.UseVisualStyleBackColor = true;
      // 
      // lblDeck
      // 
      this.lblDeck.AutoSize = true;
      this.lblDeck.Location = new System.Drawing.Point(4, 10);
      this.lblDeck.Name = "lblDeck";
      this.lblDeck.Size = new System.Drawing.Size(71, 13);
      this.lblDeck.TabIndex = 105;
      this.lblDeck.Text = "Current deck:";
      this.lblDeck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // pnlPassword
      // 
      this.pnlPassword.BackColor = System.Drawing.Color.Transparent;
      this.pnlPassword.Controls.Add(this.txtPassword);
      this.pnlPassword.Controls.Add(this.lblPassword);
      this.pnlPassword.Location = new System.Drawing.Point(3, 69);
      this.pnlPassword.Name = "pnlPassword";
      this.pnlPassword.Size = new System.Drawing.Size(259, 52);
      this.pnlPassword.TabIndex = 114;
      // 
      // pnlServerParameters
      // 
      this.pnlServerParameters.BackColor = System.Drawing.Color.Transparent;
      this.pnlServerParameters.Controls.Add(this.numPort);
      this.pnlServerParameters.Controls.Add(this.txtClientIP);
      this.pnlServerParameters.Controls.Add(this.lblServerPort);
      this.pnlServerParameters.Controls.Add(this.lblServerIP);
      this.pnlServerParameters.Location = new System.Drawing.Point(3, 127);
      this.pnlServerParameters.Name = "pnlServerParameters";
      this.pnlServerParameters.Size = new System.Drawing.Size(259, 90);
      this.pnlServerParameters.TabIndex = 114;
      // 
      // btnOk
      // 
      this.btnOk.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnOk.BackColor = System.Drawing.Color.Transparent;
      this.btnOk.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnOk.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnOk.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnOk.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnOk.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnOk.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnOk.FadingSpeed = 20;
      this.btnOk.FlatAppearance.BorderSize = 0;
      this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnOk.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOk.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnOk.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Left;
      this.btnOk.Image = global::PoL.WinFormsView.Properties.Resources.emblem_default;
      this.btnOk.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnOk.ImageOffset = 8;
      this.btnOk.IsPressed = false;
      this.btnOk.KeepPress = false;
      this.btnOk.Location = new System.Drawing.Point(12, 245);
      this.btnOk.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnOk.MenuPos = new System.Drawing.Point(0, 0);
      this.btnOk.Name = "btnOk";
      this.btnOk.Radius = 15;
      this.btnOk.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnOk.Size = new System.Drawing.Size(134, 41);
      this.btnOk.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnOk.SplitDistance = 30;
      this.btnOk.TabIndex = 114;
      this.btnOk.Text = "Ok";
      this.btnOk.Title = "";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
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
      this.btnCancel.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Right;
      this.btnCancel.Image = global::PoL.WinFormsView.Properties.Resources.stop;
      this.btnCancel.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnCancel.ImageOffset = 8;
      this.btnCancel.IsPressed = false;
      this.btnCancel.KeepPress = false;
      this.btnCancel.Location = new System.Drawing.Point(152, 245);
      this.btnCancel.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnCancel.MenuPos = new System.Drawing.Point(0, 0);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Radius = 15;
      this.btnCancel.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnCancel.Size = new System.Drawing.Size(134, 41);
      this.btnCancel.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnCancel.SplitDistance = 30;
      this.btnCancel.TabIndex = 115;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.Title = "";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // ClientInitializationView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(296, 298);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.pnlMain);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "ClientInitializationView";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "ClientInitializationView";
      ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
      this.pnlMain.ResumeLayout(false);
      this.pnlDeck.ResumeLayout(false);
      this.pnlDeck.PerformLayout();
      this.pnlPassword.ResumeLayout(false);
      this.pnlPassword.PerformLayout();
      this.pnlServerParameters.ResumeLayout(false);
      this.pnlServerParameters.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.NumericUpDown numPort;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Label lblServerIP;
    private System.Windows.Forms.Label lblServerPort;
    private System.Windows.Forms.TextBox txtClientIP;
    private System.Windows.Forms.FlowLayoutPanel pnlMain;
    private System.Windows.Forms.Panel pnlDeck;
    private RibbonStyle.RibbonMenuButton btnBrowseDecks;
    private System.Windows.Forms.Label lblDeck;
    private System.Windows.Forms.Panel pnlPassword;
    private System.Windows.Forms.Panel pnlServerParameters;
    private RibbonStyle.RibbonMenuButton btnOk;
    private RibbonStyle.RibbonMenuButton btnCancel;
    private System.Windows.Forms.TextBox txtDeckName;
  }
}