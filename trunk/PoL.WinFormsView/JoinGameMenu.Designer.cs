namespace PoL.WinFormsView
{
  partial class JoinGameMenu
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
      this.btnSavedGame = new RibbonStyle.RibbonMenuButton();
      this.btnNewGame = new RibbonStyle.RibbonMenuButton();
      this.btnTitle = new RibbonStyle.RibbonMenuButton();
      this.btnQuit = new RibbonStyle.RibbonMenuButton();
      this.SuspendLayout();
      // 
      // btnSavedGame
      // 
      this.btnSavedGame.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnSavedGame.BackColor = System.Drawing.Color.Transparent;
      this.btnSavedGame.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnSavedGame.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnSavedGame.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnSavedGame.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnSavedGame.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnSavedGame.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnSavedGame.FadingSpeed = 20;
      this.btnSavedGame.FlatAppearance.BorderSize = 0;
      this.btnSavedGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSavedGame.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnSavedGame.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnSavedGame.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Center;
      this.btnSavedGame.Image = global::PoL.WinFormsView.Properties.Resources.document_save1;
      this.btnSavedGame.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnSavedGame.ImageOffset = 10;
      this.btnSavedGame.IsPressed = false;
      this.btnSavedGame.KeepPress = false;
      this.btnSavedGame.Location = new System.Drawing.Point(7, 125);
      this.btnSavedGame.MaxImageSize = new System.Drawing.Point(0, 32);
      this.btnSavedGame.MenuPos = new System.Drawing.Point(0, 0);
      this.btnSavedGame.Name = "btnSavedGame";
      this.btnSavedGame.Radius = 50;
      this.btnSavedGame.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnSavedGame.Size = new System.Drawing.Size(296, 58);
      this.btnSavedGame.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnSavedGame.SplitDistance = 30;
      this.btnSavedGame.TabIndex = 110;
      this.btnSavedGame.Text = "Join a saved game. You must enter \r\ncorresponding password to be accepted.";
      this.btnSavedGame.Title = "Join to a saved game";
      this.btnSavedGame.UseVisualStyleBackColor = true;
      // 
      // btnNewGame
      // 
      this.btnNewGame.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnNewGame.BackColor = System.Drawing.Color.Transparent;
      this.btnNewGame.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnNewGame.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnNewGame.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnNewGame.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnNewGame.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnNewGame.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnNewGame.FadingSpeed = 20;
      this.btnNewGame.FlatAppearance.BorderSize = 0;
      this.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnNewGame.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnNewGame.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnNewGame.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Top;
      this.btnNewGame.Image = global::PoL.WinFormsView.Properties.Resources.stock_new_window;
      this.btnNewGame.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnNewGame.ImageOffset = 10;
      this.btnNewGame.IsPressed = false;
      this.btnNewGame.KeepPress = false;
      this.btnNewGame.Location = new System.Drawing.Point(7, 61);
      this.btnNewGame.MaxImageSize = new System.Drawing.Point(0, 32);
      this.btnNewGame.MenuPos = new System.Drawing.Point(0, 0);
      this.btnNewGame.Name = "btnNewGame";
      this.btnNewGame.Radius = 50;
      this.btnNewGame.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnNewGame.Size = new System.Drawing.Size(296, 58);
      this.btnNewGame.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnNewGame.SplitDistance = 30;
      this.btnNewGame.TabIndex = 109;
      this.btnNewGame.Text = "Join a new game. You can be asked \r\nto enter a password to use saving feature.";
      this.btnNewGame.Title = "Join to a new game";
      this.btnNewGame.UseVisualStyleBackColor = true;
      // 
      // btnTitle
      // 
      this.btnTitle.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnTitle.BackColor = System.Drawing.Color.Transparent;
      this.btnTitle.ColorBase = System.Drawing.Color.Peru;
      this.btnTitle.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(76)))), ((int)(((byte)(49)))), ((int)(((byte)(23)))));
      this.btnTitle.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnTitle.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnTitle.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnTitle.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnTitle.Enabled = false;
      this.btnTitle.FadingSpeed = 20;
      this.btnTitle.FlatAppearance.BorderSize = 0;
      this.btnTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnTitle.ForeColor = System.Drawing.Color.Black;
      this.btnTitle.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
      this.btnTitle.Image = global::PoL.WinFormsView.Properties.Resources.emblem_new;
      this.btnTitle.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnTitle.ImageOffset = 10;
      this.btnTitle.IsPressed = false;
      this.btnTitle.KeepPress = false;
      this.btnTitle.Location = new System.Drawing.Point(45, 5);
      this.btnTitle.MaxImageSize = new System.Drawing.Point(0, 32);
      this.btnTitle.MenuPos = new System.Drawing.Point(0, 0);
      this.btnTitle.Name = "btnTitle";
      this.btnTitle.Radius = 50;
      this.btnTitle.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnTitle.Size = new System.Drawing.Size(218, 51);
      this.btnTitle.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnTitle.SplitDistance = 30;
      this.btnTitle.TabIndex = 111;
      this.btnTitle.Text = "Join to an  existing game";
      this.btnTitle.Title = "Join game";
      this.btnTitle.UseVisualStyleBackColor = true;
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
      this.btnQuit.Location = new System.Drawing.Point(6, 189);
      this.btnQuit.MaxImageSize = new System.Drawing.Point(0, 32);
      this.btnQuit.MenuPos = new System.Drawing.Point(0, 0);
      this.btnQuit.Name = "btnQuit";
      this.btnQuit.Radius = 50;
      this.btnQuit.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnQuit.Size = new System.Drawing.Size(296, 57);
      this.btnQuit.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnQuit.SplitDistance = 30;
      this.btnQuit.TabIndex = 112;
      this.btnQuit.Text = "Return to main menu.";
      this.btnQuit.Title = "Quit";
      this.btnQuit.UseVisualStyleBackColor = true;
      // 
      // JoinGameMenu
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnQuit;
      this.ClientSize = new System.Drawing.Size(308, 252);
      this.Controls.Add(this.btnQuit);
      this.Controls.Add(this.btnTitle);
      this.Controls.Add(this.btnSavedGame);
      this.Controls.Add(this.btnNewGame);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "JoinGameMenu";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "JoinGameMenu";
      this.ResumeLayout(false);

    }

    #endregion

    private RibbonStyle.RibbonMenuButton btnSavedGame;
    private RibbonStyle.RibbonMenuButton btnNewGame;
    private RibbonStyle.RibbonMenuButton btnTitle;
    private RibbonStyle.RibbonMenuButton btnQuit;


  }
}