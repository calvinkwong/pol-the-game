namespace PoL.WinFormsView.GameStarters
{
  partial class ServerConnectionView
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
      this.lblServerIP = new System.Windows.Forms.Label();
      this.lblServerPort = new System.Windows.Forms.Label();
      this.txtClientIP = new System.Windows.Forms.TextBox();
      this.pnlMain = new System.Windows.Forms.FlowLayoutPanel();
      this.pnlServerParameters = new System.Windows.Forms.Panel();
      this.btnOk = new RibbonStyle.RibbonMenuButton();
      this.btnCancel = new RibbonStyle.RibbonMenuButton();
      ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
      this.pnlMain.SuspendLayout();
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
      this.pnlMain.Controls.Add(this.pnlServerParameters);
      this.pnlMain.Location = new System.Drawing.Point(12, 12);
      this.pnlMain.Name = "pnlMain";
      this.pnlMain.Size = new System.Drawing.Size(274, 99);
      this.pnlMain.TabIndex = 113;
      // 
      // pnlServerParameters
      // 
      this.pnlServerParameters.BackColor = System.Drawing.Color.Transparent;
      this.pnlServerParameters.Controls.Add(this.numPort);
      this.pnlServerParameters.Controls.Add(this.txtClientIP);
      this.pnlServerParameters.Controls.Add(this.lblServerPort);
      this.pnlServerParameters.Controls.Add(this.lblServerIP);
      this.pnlServerParameters.Location = new System.Drawing.Point(3, 3);
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
      this.btnOk.Location = new System.Drawing.Point(12, 117);
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
      this.btnCancel.Location = new System.Drawing.Point(152, 117);
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
      // ServerConnectionView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(296, 167);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.pnlMain);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "ServerConnectionView";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "ServerConnectionView";
      ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
      this.pnlMain.ResumeLayout(false);
      this.pnlServerParameters.ResumeLayout(false);
      this.pnlServerParameters.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.NumericUpDown numPort;
    private System.Windows.Forms.Label lblServerIP;
    private System.Windows.Forms.Label lblServerPort;
    private System.Windows.Forms.TextBox txtClientIP;
    private System.Windows.Forms.FlowLayoutPanel pnlMain;
    private System.Windows.Forms.Panel pnlServerParameters;
    private RibbonStyle.RibbonMenuButton btnOk;
    private RibbonStyle.RibbonMenuButton btnCancel;
  }
}