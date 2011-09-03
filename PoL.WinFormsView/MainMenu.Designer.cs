namespace PoL.WinFormsView
{
  partial class MainMenu
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
      this.btnQuit = new RibbonStyle.RibbonMenuButton();
      this.btnOptions = new RibbonStyle.RibbonMenuButton();
      this.btnDeckEditor = new RibbonStyle.RibbonMenuButton();
      this.btnConnectGame = new RibbonStyle.RibbonMenuButton();
      this.btnHostGame = new RibbonStyle.RibbonMenuButton();
      this.btnStartSolitaire = new RibbonStyle.RibbonMenuButton();
      this.lblCurrentGame = new RibbonStyle.RibbonMenuButton();
      this.btnChat = new RibbonStyle.RibbonMenuButton();
      this.SuspendLayout();
      // 
      // btnQuit
      // 
      this.btnQuit.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnQuit.BackColor = System.Drawing.Color.Transparent;
      this.btnQuit.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnQuit.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnQuit.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnQuit.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnQuit.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnQuit.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnQuit.FadingSpeed = 20;
      this.btnQuit.FlatAppearance.BorderSize = 0;
      this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnQuit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnQuit.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnQuit.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Bottom;
      this.btnQuit.Image = global::PoL.WinFormsView.Properties.Resources.emblem_symbolic_link;
      this.btnQuit.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnQuit.ImageOffset = 10;
      this.btnQuit.IsPressed = false;
      this.btnQuit.KeepPress = false;
      this.btnQuit.Location = new System.Drawing.Point(7, 441);
      this.btnQuit.MaxImageSize = new System.Drawing.Point(0, 32);
      this.btnQuit.MenuPos = new System.Drawing.Point(0, 0);
      this.btnQuit.Name = "btnQuit";
      this.btnQuit.Radius = 50;
      this.btnQuit.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnQuit.Size = new System.Drawing.Size(296, 57);
      this.btnQuit.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnQuit.SplitDistance = 30;
      this.btnQuit.TabIndex = 74;
      this.btnQuit.Text = "Description";
      this.btnQuit.Title = "Quit";
      this.btnQuit.UseVisualStyleBackColor = true;
      // 
      // btnOptions
      // 
      this.btnOptions.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnOptions.BackColor = System.Drawing.Color.Transparent;
      this.btnOptions.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnOptions.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnOptions.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnOptions.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnOptions.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnOptions.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnOptions.FadingSpeed = 20;
      this.btnOptions.FlatAppearance.BorderSize = 0;
      this.btnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnOptions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOptions.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnOptions.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Center;
      this.btnOptions.Image = global::PoL.WinFormsView.Properties.Resources.applications_other;
      this.btnOptions.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnOptions.ImageOffset = 10;
      this.btnOptions.IsPressed = false;
      this.btnOptions.KeepPress = false;
      this.btnOptions.Location = new System.Drawing.Point(7, 378);
      this.btnOptions.MaxImageSize = new System.Drawing.Point(0, 32);
      this.btnOptions.MenuPos = new System.Drawing.Point(0, 0);
      this.btnOptions.Name = "btnOptions";
      this.btnOptions.Radius = 0;
      this.btnOptions.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnOptions.Size = new System.Drawing.Size(296, 57);
      this.btnOptions.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnOptions.SplitDistance = 30;
      this.btnOptions.TabIndex = 73;
      this.btnOptions.Text = "Description";
      this.btnOptions.Title = "Options";
      this.btnOptions.UseVisualStyleBackColor = true;
      // 
      // btnDeckEditor
      // 
      this.btnDeckEditor.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnDeckEditor.BackColor = System.Drawing.Color.Transparent;
      this.btnDeckEditor.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnDeckEditor.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnDeckEditor.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnDeckEditor.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnDeckEditor.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnDeckEditor.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnDeckEditor.FadingSpeed = 20;
      this.btnDeckEditor.FlatAppearance.BorderSize = 0;
      this.btnDeckEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnDeckEditor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnDeckEditor.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnDeckEditor.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Center;
      this.btnDeckEditor.Image = global::PoL.WinFormsView.Properties.Resources.applications_accessories;
      this.btnDeckEditor.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnDeckEditor.ImageOffset = 10;
      this.btnDeckEditor.IsPressed = false;
      this.btnDeckEditor.KeepPress = false;
      this.btnDeckEditor.Location = new System.Drawing.Point(7, 315);
      this.btnDeckEditor.MaxImageSize = new System.Drawing.Point(0, 32);
      this.btnDeckEditor.MenuPos = new System.Drawing.Point(0, 0);
      this.btnDeckEditor.Name = "btnDeckEditor";
      this.btnDeckEditor.Radius = 0;
      this.btnDeckEditor.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnDeckEditor.Size = new System.Drawing.Size(296, 57);
      this.btnDeckEditor.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnDeckEditor.SplitDistance = 30;
      this.btnDeckEditor.TabIndex = 72;
      this.btnDeckEditor.Text = "Description";
      this.btnDeckEditor.Title = "Deck editor";
      this.btnDeckEditor.UseVisualStyleBackColor = true;
      // 
      // btnConnectGame
      // 
      this.btnConnectGame.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnConnectGame.BackColor = System.Drawing.Color.Transparent;
      this.btnConnectGame.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnConnectGame.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnConnectGame.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnConnectGame.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnConnectGame.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnConnectGame.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnConnectGame.FadingSpeed = 20;
      this.btnConnectGame.FlatAppearance.BorderSize = 0;
      this.btnConnectGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnConnectGame.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnConnectGame.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnConnectGame.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Center;
      this.btnConnectGame.Image = global::PoL.WinFormsView.Properties.Resources.gtk_leave_fullscreen;
      this.btnConnectGame.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnConnectGame.ImageOffset = 10;
      this.btnConnectGame.IsPressed = false;
      this.btnConnectGame.KeepPress = false;
      this.btnConnectGame.Location = new System.Drawing.Point(7, 189);
      this.btnConnectGame.MaxImageSize = new System.Drawing.Point(0, 32);
      this.btnConnectGame.MenuPos = new System.Drawing.Point(0, 0);
      this.btnConnectGame.Name = "btnConnectGame";
      this.btnConnectGame.Radius = 0;
      this.btnConnectGame.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnConnectGame.Size = new System.Drawing.Size(296, 57);
      this.btnConnectGame.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnConnectGame.SplitDistance = 30;
      this.btnConnectGame.TabIndex = 71;
      this.btnConnectGame.Text = "Description";
      this.btnConnectGame.Title = "Join game";
      this.btnConnectGame.UseVisualStyleBackColor = true;
      // 
      // btnHostGame
      // 
      this.btnHostGame.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnHostGame.BackColor = System.Drawing.Color.Transparent;
      this.btnHostGame.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnHostGame.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnHostGame.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnHostGame.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnHostGame.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnHostGame.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnHostGame.FadingSpeed = 20;
      this.btnHostGame.FlatAppearance.BorderSize = 0;
      this.btnHostGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnHostGame.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnHostGame.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnHostGame.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Center;
      this.btnHostGame.Image = global::PoL.WinFormsView.Properties.Resources.stock_new_window;
      this.btnHostGame.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnHostGame.ImageOffset = 10;
      this.btnHostGame.IsPressed = false;
      this.btnHostGame.KeepPress = false;
      this.btnHostGame.Location = new System.Drawing.Point(7, 126);
      this.btnHostGame.MaxImageSize = new System.Drawing.Point(0, 32);
      this.btnHostGame.MenuPos = new System.Drawing.Point(0, 0);
      this.btnHostGame.Name = "btnHostGame";
      this.btnHostGame.Radius = 0;
      this.btnHostGame.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnHostGame.Size = new System.Drawing.Size(296, 57);
      this.btnHostGame.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnHostGame.SplitDistance = 30;
      this.btnHostGame.TabIndex = 70;
      this.btnHostGame.Text = "Description";
      this.btnHostGame.Title = "Create game";
      this.btnHostGame.UseVisualStyleBackColor = true;
      // 
      // btnStartSolitaire
      // 
      this.btnStartSolitaire.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnStartSolitaire.BackColor = System.Drawing.Color.Transparent;
      this.btnStartSolitaire.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnStartSolitaire.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnStartSolitaire.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnStartSolitaire.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnStartSolitaire.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnStartSolitaire.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnStartSolitaire.FadingSpeed = 20;
      this.btnStartSolitaire.FlatAppearance.BorderSize = 0;
      this.btnStartSolitaire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnStartSolitaire.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnStartSolitaire.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnStartSolitaire.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Top;
      this.btnStartSolitaire.Image = global::PoL.WinFormsView.Properties.Resources.stock_person;
      this.btnStartSolitaire.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnStartSolitaire.ImageOffset = 10;
      this.btnStartSolitaire.IsPressed = false;
      this.btnStartSolitaire.KeepPress = false;
      this.btnStartSolitaire.Location = new System.Drawing.Point(7, 62);
      this.btnStartSolitaire.MaxImageSize = new System.Drawing.Point(0, 32);
      this.btnStartSolitaire.MenuPos = new System.Drawing.Point(0, 0);
      this.btnStartSolitaire.Name = "btnStartSolitaire";
      this.btnStartSolitaire.Radius = 50;
      this.btnStartSolitaire.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnStartSolitaire.Size = new System.Drawing.Size(296, 58);
      this.btnStartSolitaire.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnStartSolitaire.SplitDistance = 30;
      this.btnStartSolitaire.TabIndex = 69;
      this.btnStartSolitaire.Text = "Descripition";
      this.btnStartSolitaire.Title = "Start solitaire";
      this.btnStartSolitaire.UseVisualStyleBackColor = true;
      // 
      // lblCurrentGame
      // 
      this.lblCurrentGame.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.lblCurrentGame.BackColor = System.Drawing.Color.Transparent;
      this.lblCurrentGame.ColorBase = System.Drawing.Color.Peru;
      this.lblCurrentGame.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(49)))), ((int)(((byte)(23)))));
      this.lblCurrentGame.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.lblCurrentGame.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.lblCurrentGame.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.lblCurrentGame.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.lblCurrentGame.Enabled = false;
      this.lblCurrentGame.FadingSpeed = 20;
      this.lblCurrentGame.FlatAppearance.BorderSize = 0;
      this.lblCurrentGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.lblCurrentGame.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblCurrentGame.ForeColor = System.Drawing.Color.Black;
      this.lblCurrentGame.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
      this.lblCurrentGame.Image = global::PoL.WinFormsView.Properties.Resources.emblem_new;
      this.lblCurrentGame.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.lblCurrentGame.ImageOffset = 10;
      this.lblCurrentGame.IsPressed = false;
      this.lblCurrentGame.KeepPress = false;
      this.lblCurrentGame.Location = new System.Drawing.Point(45, 5);
      this.lblCurrentGame.MaxImageSize = new System.Drawing.Point(0, 32);
      this.lblCurrentGame.MenuPos = new System.Drawing.Point(0, 0);
      this.lblCurrentGame.Name = "lblCurrentGame";
      this.lblCurrentGame.Radius = 50;
      this.lblCurrentGame.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.lblCurrentGame.Size = new System.Drawing.Size(218, 51);
      this.lblCurrentGame.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.lblCurrentGame.SplitDistance = 30;
      this.lblCurrentGame.TabIndex = 75;
      this.lblCurrentGame.Text = "Game name";
      this.lblCurrentGame.Title = "Current game";
      this.lblCurrentGame.UseVisualStyleBackColor = true;
      // 
      // btnChat
      // 
      this.btnChat.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnChat.BackColor = System.Drawing.Color.Transparent;
      this.btnChat.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnChat.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnChat.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnChat.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnChat.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnChat.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnChat.FadingSpeed = 20;
      this.btnChat.FlatAppearance.BorderSize = 0;
      this.btnChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnChat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnChat.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnChat.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Center;
      this.btnChat.Image = global::PoL.WinFormsView.Properties.Resources.help_faq;
      this.btnChat.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnChat.ImageOffset = 10;
      this.btnChat.IsPressed = false;
      this.btnChat.KeepPress = false;
      this.btnChat.Location = new System.Drawing.Point(7, 252);
      this.btnChat.MaxImageSize = new System.Drawing.Point(0, 32);
      this.btnChat.MenuPos = new System.Drawing.Point(0, 0);
      this.btnChat.Name = "btnChat";
      this.btnChat.Radius = 0;
      this.btnChat.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnChat.Size = new System.Drawing.Size(296, 57);
      this.btnChat.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnChat.SplitDistance = 30;
      this.btnChat.TabIndex = 76;
      this.btnChat.Text = "Description";
      this.btnChat.Title = "Chat";
      this.btnChat.UseVisualStyleBackColor = true;
      // 
      // MainMenu
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.CancelButton = this.btnQuit;
      this.ClientSize = new System.Drawing.Size(308, 504);
      this.Controls.Add(this.btnChat);
      this.Controls.Add(this.lblCurrentGame);
      this.Controls.Add(this.btnQuit);
      this.Controls.Add(this.btnOptions);
      this.Controls.Add(this.btnDeckEditor);
      this.Controls.Add(this.btnConnectGame);
      this.Controls.Add(this.btnHostGame);
      this.Controls.Add(this.btnStartSolitaire);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = "MainMenu";
      this.Padding = new System.Windows.Forms.Padding(2);
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.ResumeLayout(false);

    }

    #endregion

    private RibbonStyle.RibbonMenuButton btnQuit;
    private RibbonStyle.RibbonMenuButton btnOptions;
    private RibbonStyle.RibbonMenuButton btnDeckEditor;
    private RibbonStyle.RibbonMenuButton btnConnectGame;
    private RibbonStyle.RibbonMenuButton btnHostGame;
    private RibbonStyle.RibbonMenuButton btnStartSolitaire;
    private RibbonStyle.RibbonMenuButton lblCurrentGame;
    private RibbonStyle.RibbonMenuButton btnChat;

  }
}