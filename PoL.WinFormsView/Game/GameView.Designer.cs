namespace PoL.WinFormsView.Game
{
  partial class GameView
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameView));
      this.pnlLog = new System.Windows.Forms.Panel();
      this.consoleView = new PoL.WinFormsView.Game.ConsoleView();
      this.panel1 = new System.Windows.Forms.Panel();
      this.playerStatusContainer = new System.Windows.Forms.SplitContainer();
      this.btnSave = new RibbonStyle.RibbonMenuButton();
      this.btnOptions = new RibbonStyle.RibbonMenuButton();
      this.btnDice = new RibbonStyle.RibbonMenuButton();
      this.menuDice = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.menuDice4 = new System.Windows.Forms.ToolStripMenuItem();
      this.menuDice6 = new System.Windows.Forms.ToolStripMenuItem();
      this.menuDice8 = new System.Windows.Forms.ToolStripMenuItem();
      this.menuDice10 = new System.Windows.Forms.ToolStripMenuItem();
      this.menuDice12 = new System.Windows.Forms.ToolStripMenuItem();
      this.menuDice20 = new System.Windows.Forms.ToolStripMenuItem();
      this.btnCoin = new RibbonStyle.RibbonMenuButton();
      this.btnRedo = new RibbonStyle.RibbonMenuButton();
      this.btnUndo = new RibbonStyle.RibbonMenuButton();
      this.cardPreview = new System.Windows.Forms.PictureBox();
      this.pnlGameFields = new System.Windows.Forms.SplitContainer();
      this.tabControl = new System.Windows.Forms.TabControl();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.btnRestart = new RibbonStyle.RibbonMenuButton();
      this.pnlLog.SuspendLayout();
      this.panel1.SuspendLayout();
      this.playerStatusContainer.SuspendLayout();
      this.menuDice.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cardPreview)).BeginInit();
      this.pnlGameFields.Panel1.SuspendLayout();
      this.pnlGameFields.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlLog
      // 
      this.pnlLog.BackColor = System.Drawing.Color.White;
      this.pnlLog.Controls.Add(this.consoleView);
      this.pnlLog.Controls.Add(this.panel1);
      this.pnlLog.Controls.Add(this.cardPreview);
      this.pnlLog.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnlLog.Location = new System.Drawing.Point(0, 0);
      this.pnlLog.Name = "pnlLog";
      this.pnlLog.Size = new System.Drawing.Size(250, 730);
      this.pnlLog.TabIndex = 7;
      // 
      // consoleView
      // 
      this.consoleView.BackColor = System.Drawing.Color.Transparent;
      this.consoleView.CurrentText = "";
      this.consoleView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.consoleView.Location = new System.Drawing.Point(0, 527);
      this.consoleView.Name = "consoleView";
      this.consoleView.Size = new System.Drawing.Size(250, 203);
      this.consoleView.TabIndex = 0;
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.SystemColors.Control;
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panel1.Controls.Add(this.btnRestart);
      this.panel1.Controls.Add(this.playerStatusContainer);
      this.panel1.Controls.Add(this.btnSave);
      this.panel1.Controls.Add(this.btnOptions);
      this.panel1.Controls.Add(this.btnDice);
      this.panel1.Controls.Add(this.btnCoin);
      this.panel1.Controls.Add(this.btnRedo);
      this.panel1.Controls.Add(this.btnUndo);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 334);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(250, 193);
      this.panel1.TabIndex = 1;
      // 
      // playerStatusContainer
      // 
      this.playerStatusContainer.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.darkbackground;
      this.playerStatusContainer.IsSplitterFixed = true;
      this.playerStatusContainer.Location = new System.Drawing.Point(0, 34);
      this.playerStatusContainer.Name = "playerStatusContainer";
      // 
      // playerStatusContainer.Panel1
      // 
      this.playerStatusContainer.Panel1.BackColor = System.Drawing.Color.Transparent;
      this.playerStatusContainer.Panel1.Padding = new System.Windows.Forms.Padding(2);
      // 
      // playerStatusContainer.Panel2
      // 
      this.playerStatusContainer.Panel2.BackColor = System.Drawing.Color.Transparent;
      this.playerStatusContainer.Panel2.Padding = new System.Windows.Forms.Padding(2);
      this.playerStatusContainer.Size = new System.Drawing.Size(246, 155);
      this.playerStatusContainer.SplitterDistance = 123;
      this.playerStatusContainer.SplitterWidth = 1;
      this.playerStatusContainer.TabIndex = 125;
      // 
      // btnSave
      // 
      this.btnSave.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnSave.BackColor = System.Drawing.Color.Transparent;
      this.btnSave.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnSave.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnSave.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnSave.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnSave.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnSave.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnSave.FadingSpeed = 20;
      this.btnSave.FlatAppearance.BorderSize = 0;
      this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnSave.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnSave.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Right;
      this.btnSave.Image = global::PoL.WinFormsView.Properties.Resources.document_save;
      this.btnSave.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnSave.ImageOffset = 8;
      this.btnSave.IsPressed = false;
      this.btnSave.KeepPress = false;
      this.btnSave.Location = new System.Drawing.Point(210, 1);
      this.btnSave.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnSave.MenuPos = new System.Drawing.Point(0, 0);
      this.btnSave.Name = "btnSave";
      this.btnSave.Radius = 30;
      this.btnSave.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnSave.Size = new System.Drawing.Size(34, 33);
      this.btnSave.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnSave.SplitDistance = 30;
      this.btnSave.TabIndex = 85;
      this.btnSave.Title = "";
      this.btnSave.UseVisualStyleBackColor = true;
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
      this.btnOptions.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Left;
      this.btnOptions.Image = global::PoL.WinFormsView.Properties.Resources.preferences_system;
      this.btnOptions.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnOptions.ImageOffset = 8;
      this.btnOptions.IsPressed = false;
      this.btnOptions.KeepPress = false;
      this.btnOptions.Location = new System.Drawing.Point(2, 1);
      this.btnOptions.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnOptions.MenuPos = new System.Drawing.Point(0, 0);
      this.btnOptions.Name = "btnOptions";
      this.btnOptions.Radius = 30;
      this.btnOptions.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnOptions.Size = new System.Drawing.Size(31, 33);
      this.btnOptions.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnOptions.SplitDistance = 30;
      this.btnOptions.TabIndex = 84;
      this.btnOptions.Title = "";
      this.btnOptions.UseVisualStyleBackColor = true;
      // 
      // btnDice
      // 
      this.btnDice.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.ToRight;
      this.btnDice.BackColor = System.Drawing.Color.Transparent;
      this.btnDice.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnDice.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnDice.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnDice.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnDice.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnDice.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnDice.ContextMenuStrip = this.menuDice;
      this.btnDice.FadingSpeed = 20;
      this.btnDice.FlatAppearance.BorderSize = 0;
      this.btnDice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnDice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnDice.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnDice.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Center;
      this.btnDice.Image = global::PoL.WinFormsView.Properties.Resources.dice;
      this.btnDice.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnDice.ImageOffset = 8;
      this.btnDice.IsPressed = false;
      this.btnDice.KeepPress = false;
      this.btnDice.Location = new System.Drawing.Point(92, 1);
      this.btnDice.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnDice.MenuPos = new System.Drawing.Point(0, 0);
      this.btnDice.Name = "btnDice";
      this.btnDice.Radius = 30;
      this.btnDice.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnDice.Size = new System.Drawing.Size(39, 33);
      this.btnDice.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnDice.SplitDistance = 30;
      this.btnDice.TabIndex = 82;
      this.btnDice.Title = "";
      this.btnDice.UseVisualStyleBackColor = true;
      // 
      // menuDice
      // 
      this.menuDice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDice4,
            this.menuDice6,
            this.menuDice8,
            this.menuDice10,
            this.menuDice12,
            this.menuDice20});
      this.menuDice.Name = "menuDice";
      this.menuDice.Size = new System.Drawing.Size(117, 136);
      // 
      // menuDice4
      // 
      this.menuDice4.Name = "menuDice4";
      this.menuDice4.Size = new System.Drawing.Size(116, 22);
      this.menuDice4.Text = "DICE_4";
      // 
      // menuDice6
      // 
      this.menuDice6.Name = "menuDice6";
      this.menuDice6.Size = new System.Drawing.Size(116, 22);
      this.menuDice6.Text = "DICE_6";
      // 
      // menuDice8
      // 
      this.menuDice8.Name = "menuDice8";
      this.menuDice8.Size = new System.Drawing.Size(116, 22);
      this.menuDice8.Text = "DICE_8";
      // 
      // menuDice10
      // 
      this.menuDice10.Name = "menuDice10";
      this.menuDice10.Size = new System.Drawing.Size(116, 22);
      this.menuDice10.Text = "DICE_10";
      // 
      // menuDice12
      // 
      this.menuDice12.Name = "menuDice12";
      this.menuDice12.Size = new System.Drawing.Size(116, 22);
      this.menuDice12.Text = "DICE_12";
      // 
      // menuDice20
      // 
      this.menuDice20.Name = "menuDice20";
      this.menuDice20.Size = new System.Drawing.Size(116, 22);
      this.menuDice20.Text = "DICE_20";
      // 
      // btnCoin
      // 
      this.btnCoin.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnCoin.BackColor = System.Drawing.Color.Transparent;
      this.btnCoin.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnCoin.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnCoin.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnCoin.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnCoin.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnCoin.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnCoin.FadingSpeed = 20;
      this.btnCoin.FlatAppearance.BorderSize = 0;
      this.btnCoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCoin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnCoin.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnCoin.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Center;
      this.btnCoin.Image = global::PoL.WinFormsView.Properties.Resources.stock_smiley_1___copy;
      this.btnCoin.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnCoin.ImageOffset = 8;
      this.btnCoin.IsPressed = false;
      this.btnCoin.KeepPress = false;
      this.btnCoin.Location = new System.Drawing.Point(133, 1);
      this.btnCoin.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnCoin.MenuPos = new System.Drawing.Point(0, 0);
      this.btnCoin.Name = "btnCoin";
      this.btnCoin.Radius = 30;
      this.btnCoin.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnCoin.Size = new System.Drawing.Size(36, 33);
      this.btnCoin.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnCoin.SplitDistance = 30;
      this.btnCoin.TabIndex = 81;
      this.btnCoin.Title = "";
      this.btnCoin.UseVisualStyleBackColor = true;
      // 
      // btnRedo
      // 
      this.btnRedo.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnRedo.BackColor = System.Drawing.Color.Transparent;
      this.btnRedo.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnRedo.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnRedo.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnRedo.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnRedo.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnRedo.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnRedo.FadingSpeed = 20;
      this.btnRedo.FlatAppearance.BorderSize = 0;
      this.btnRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnRedo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnRedo.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnRedo.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Center;
      this.btnRedo.Image = global::PoL.WinFormsView.Properties.Resources.edit_redo;
      this.btnRedo.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnRedo.ImageOffset = 8;
      this.btnRedo.IsPressed = false;
      this.btnRedo.KeepPress = false;
      this.btnRedo.Location = new System.Drawing.Point(63, 1);
      this.btnRedo.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnRedo.MenuPos = new System.Drawing.Point(0, 0);
      this.btnRedo.Name = "btnRedo";
      this.btnRedo.Radius = 30;
      this.btnRedo.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnRedo.Size = new System.Drawing.Size(27, 33);
      this.btnRedo.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnRedo.SplitDistance = 30;
      this.btnRedo.TabIndex = 80;
      this.btnRedo.Title = "";
      this.btnRedo.UseVisualStyleBackColor = true;
      // 
      // btnUndo
      // 
      this.btnUndo.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnUndo.BackColor = System.Drawing.Color.Transparent;
      this.btnUndo.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnUndo.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnUndo.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnUndo.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnUndo.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnUndo.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnUndo.FadingSpeed = 20;
      this.btnUndo.FlatAppearance.BorderSize = 0;
      this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnUndo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnUndo.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnUndo.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Center;
      this.btnUndo.Image = global::PoL.WinFormsView.Properties.Resources.edit_undo;
      this.btnUndo.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnUndo.ImageOffset = 8;
      this.btnUndo.IsPressed = false;
      this.btnUndo.KeepPress = false;
      this.btnUndo.Location = new System.Drawing.Point(34, 1);
      this.btnUndo.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnUndo.MenuPos = new System.Drawing.Point(0, 0);
      this.btnUndo.Name = "btnUndo";
      this.btnUndo.Radius = 30;
      this.btnUndo.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnUndo.Size = new System.Drawing.Size(27, 33);
      this.btnUndo.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnUndo.SplitDistance = 30;
      this.btnUndo.TabIndex = 79;
      this.btnUndo.Title = "";
      this.btnUndo.UseVisualStyleBackColor = true;
      // 
      // cardPreview
      // 
      this.cardPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.cardPreview.Dock = System.Windows.Forms.DockStyle.Top;
      this.cardPreview.Location = new System.Drawing.Point(0, 0);
      this.cardPreview.Name = "cardPreview";
      this.cardPreview.Size = new System.Drawing.Size(250, 334);
      this.cardPreview.TabIndex = 0;
      this.cardPreview.TabStop = false;
      // 
      // pnlGameFields
      // 
      this.pnlGameFields.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlGameFields.IsSplitterFixed = true;
      this.pnlGameFields.Location = new System.Drawing.Point(250, 0);
      this.pnlGameFields.Name = "pnlGameFields";
      this.pnlGameFields.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // pnlGameFields.Panel1
      // 
      this.pnlGameFields.Panel1.Controls.Add(this.tabControl);
      this.pnlGameFields.Size = new System.Drawing.Size(758, 730);
      this.pnlGameFields.SplitterDistance = 248;
      this.pnlGameFields.SplitterWidth = 1;
      this.pnlGameFields.TabIndex = 8;
      // 
      // tabControl
      // 
      this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl.Location = new System.Drawing.Point(0, 0);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(758, 248);
      this.tabControl.TabIndex = 0;
      // 
      // toolTip
      // 
      this.toolTip.ShowAlways = true;
      // 
      // btnRestart
      // 
      this.btnRestart.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnRestart.BackColor = System.Drawing.Color.Transparent;
      this.btnRestart.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnRestart.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnRestart.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnRestart.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnRestart.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnRestart.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnRestart.FadingSpeed = 20;
      this.btnRestart.FlatAppearance.BorderSize = 0;
      this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnRestart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnRestart.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnRestart.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Center;
      this.btnRestart.Image = global::PoL.WinFormsView.Properties.Resources.emblem_new;
      this.btnRestart.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnRestart.ImageOffset = 8;
      this.btnRestart.IsPressed = false;
      this.btnRestart.KeepPress = false;
      this.btnRestart.Location = new System.Drawing.Point(171, 1);
      this.btnRestart.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnRestart.MenuPos = new System.Drawing.Point(0, 0);
      this.btnRestart.Name = "btnRestart";
      this.btnRestart.Radius = 30;
      this.btnRestart.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnRestart.Size = new System.Drawing.Size(36, 33);
      this.btnRestart.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnRestart.SplitDistance = 30;
      this.btnRestart.TabIndex = 126;
      this.btnRestart.Title = "";
      this.btnRestart.UseVisualStyleBackColor = true;
      // 
      // GameView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1008, 730);
      this.Controls.Add(this.pnlGameFields);
      this.Controls.Add(this.pnlLog);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.MinimumSize = new System.Drawing.Size(800, 600);
      this.Name = "GameView";
      this.Text = "GameView";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.pnlLog.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.playerStatusContainer.ResumeLayout(false);
      this.menuDice.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.cardPreview)).EndInit();
      this.pnlGameFields.Panel1.ResumeLayout(false);
      this.pnlGameFields.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlLog;
    private System.Windows.Forms.SplitContainer pnlGameFields;
    private ConsoleView consoleView;
    private System.Windows.Forms.PictureBox cardPreview;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TabControl tabControl;
    private RibbonStyle.RibbonMenuButton btnUndo;
    private RibbonStyle.RibbonMenuButton btnRedo;
    private System.Windows.Forms.ToolTip toolTip;
    private RibbonStyle.RibbonMenuButton btnCoin;
    private RibbonStyle.RibbonMenuButton btnDice;
    private System.Windows.Forms.ContextMenuStrip menuDice;
    private System.Windows.Forms.ToolStripMenuItem menuDice4;
    private System.Windows.Forms.ToolStripMenuItem menuDice6;
    private System.Windows.Forms.ToolStripMenuItem menuDice8;
    private System.Windows.Forms.ToolStripMenuItem menuDice10;
    private System.Windows.Forms.ToolStripMenuItem menuDice12;
    private System.Windows.Forms.ToolStripMenuItem menuDice20;
    private RibbonStyle.RibbonMenuButton btnOptions;
    private RibbonStyle.RibbonMenuButton btnSave;
    private System.Windows.Forms.SplitContainer playerStatusContainer;
    private RibbonStyle.RibbonMenuButton btnRestart;

  }
}