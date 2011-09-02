namespace PoL.WinFormsView.GameStarters
{
  partial class ServerStartNewGameView
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
      if(disposing && (components != null))
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
      this.btnOk = new RibbonStyle.RibbonMenuButton();
      this.btnCancel = new RibbonStyle.RibbonMenuButton();
      this.pnlMain = new System.Windows.Forms.FlowLayoutPanel();
      this.pnlDeck = new System.Windows.Forms.Panel();
      this.txtDeckName = new System.Windows.Forms.TextBox();
      this.lblDeck = new System.Windows.Forms.Label();
      this.btnBrowseDecks = new RibbonStyle.RibbonMenuButton();
      this.pnlPassword = new System.Windows.Forms.Panel();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.lblPassword = new System.Windows.Forms.Label();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.pnlMain.SuspendLayout();
      this.pnlDeck.SuspendLayout();
      this.pnlPassword.SuspendLayout();
      this.SuspendLayout();
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
      this.btnOk.Location = new System.Drawing.Point(12, 222);
      this.btnOk.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnOk.MenuPos = new System.Drawing.Point(0, 0);
      this.btnOk.Name = "btnOk";
      this.btnOk.Radius = 15;
      this.btnOk.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnOk.Size = new System.Drawing.Size(134, 41);
      this.btnOk.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnOk.SplitDistance = 30;
      this.btnOk.TabIndex = 117;
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
      this.btnCancel.Location = new System.Drawing.Point(152, 222);
      this.btnCancel.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnCancel.MenuPos = new System.Drawing.Point(0, 0);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Radius = 15;
      this.btnCancel.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnCancel.Size = new System.Drawing.Size(134, 41);
      this.btnCancel.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnCancel.SplitDistance = 30;
      this.btnCancel.TabIndex = 118;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.Title = "";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // pnlMain
      // 
      this.pnlMain.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.sfondoblu;
      this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pnlMain.Controls.Add(this.pnlDeck);
      this.pnlMain.Controls.Add(this.pnlPassword);
      this.pnlMain.Location = new System.Drawing.Point(12, 12);
      this.pnlMain.Name = "pnlMain";
      this.pnlMain.Size = new System.Drawing.Size(274, 204);
      this.pnlMain.TabIndex = 116;
      // 
      // pnlDeck
      // 
      this.pnlDeck.BackColor = System.Drawing.Color.Transparent;
      this.pnlDeck.Controls.Add(this.txtDeckName);
      this.pnlDeck.Controls.Add(this.lblDeck);
      this.pnlDeck.Controls.Add(this.btnBrowseDecks);
      this.pnlDeck.Location = new System.Drawing.Point(3, 3);
      this.pnlDeck.Name = "pnlDeck";
      this.pnlDeck.Size = new System.Drawing.Size(259, 52);
      this.pnlDeck.TabIndex = 115;
      // 
      // txtDeckName
      // 
      this.txtDeckName.Location = new System.Drawing.Point(10, 24);
      this.txtDeckName.Name = "txtDeckName";
      this.txtDeckName.ReadOnly = true;
      this.txtDeckName.Size = new System.Drawing.Size(192, 20);
      this.txtDeckName.TabIndex = 108;
      // 
      // lblDeck
      // 
      this.lblDeck.AutoSize = true;
      this.lblDeck.Location = new System.Drawing.Point(7, 7);
      this.lblDeck.Name = "lblDeck";
      this.lblDeck.Size = new System.Drawing.Size(71, 13);
      this.lblDeck.TabIndex = 107;
      this.lblDeck.Text = "Current deck:";
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
      this.btnBrowseDecks.Location = new System.Drawing.Point(208, 17);
      this.btnBrowseDecks.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnBrowseDecks.MenuPos = new System.Drawing.Point(0, 0);
      this.btnBrowseDecks.Name = "btnBrowseDecks";
      this.btnBrowseDecks.Radius = 15;
      this.btnBrowseDecks.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnBrowseDecks.Size = new System.Drawing.Size(33, 27);
      this.btnBrowseDecks.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnBrowseDecks.SplitDistance = 30;
      this.btnBrowseDecks.TabIndex = 106;
      this.btnBrowseDecks.Title = "";
      this.btnBrowseDecks.UseVisualStyleBackColor = true;
      // 
      // pnlPassword
      // 
      this.pnlPassword.BackColor = System.Drawing.Color.Transparent;
      this.pnlPassword.Controls.Add(this.txtPassword);
      this.pnlPassword.Controls.Add(this.lblPassword);
      this.pnlPassword.Location = new System.Drawing.Point(3, 61);
      this.pnlPassword.Name = "pnlPassword";
      this.pnlPassword.Size = new System.Drawing.Size(259, 52);
      this.pnlPassword.TabIndex = 114;
      // 
      // txtPassword
      // 
      this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
      this.txtPassword.ForeColor = System.Drawing.SystemColors.ControlText;
      this.txtPassword.Location = new System.Drawing.Point(10, 24);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new System.Drawing.Size(192, 23);
      this.txtPassword.TabIndex = 110;
      this.txtPassword.UseSystemPasswordChar = true;
      // 
      // lblPassword
      // 
      this.lblPassword.AutoSize = true;
      this.lblPassword.Location = new System.Drawing.Point(7, 8);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(56, 13);
      this.lblPassword.TabIndex = 111;
      this.lblPassword.Text = "Password:";
      // 
      // ServerStartNewGameView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(296, 270);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.pnlMain);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "ServerStartNewGameView";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "ServerInitializationView";
      this.pnlMain.ResumeLayout(false);
      this.pnlDeck.ResumeLayout(false);
      this.pnlDeck.PerformLayout();
      this.pnlPassword.ResumeLayout(false);
      this.pnlPassword.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private RibbonStyle.RibbonMenuButton btnOk;
    private RibbonStyle.RibbonMenuButton btnCancel;
    private System.Windows.Forms.FlowLayoutPanel pnlMain;
    private System.Windows.Forms.Panel pnlDeck;
    private RibbonStyle.RibbonMenuButton btnBrowseDecks;
    private System.Windows.Forms.Panel pnlPassword;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.Label lblDeck;
    private System.Windows.Forms.TextBox txtDeckName;


  }
}