namespace PoL.WinFormsView.DeckEditor
{
  partial class DeckEditorView
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeckEditorView));
      this.pnlRight = new System.Windows.Forms.Panel();
      this.pnlOtherInfo = new System.Windows.Forms.Panel();
      this.lblOtherInfo = new RibbonStyle.RibbonMenuButton();
      this.pnlButtons = new System.Windows.Forms.Panel();
      this.btnOrientation = new RibbonStyle.RibbonMenuButton();
      this.mCbDeckCategory = new System.Windows.Forms.ComboBox();
      this.txtDeckName = new System.Windows.Forms.TextBox();
      this.btnExit = new RibbonStyle.RibbonMenuButton();
      this.lblCategory = new System.Windows.Forms.Label();
      this.btnSaveExit = new RibbonStyle.RibbonMenuButton();
      this.lblName = new System.Windows.Forms.Label();
      this.btnSave = new RibbonStyle.RibbonMenuButton();
      this.pnlPreview = new System.Windows.Forms.Panel();
      this.cardPreview = new System.Windows.Forms.PictureBox();
      this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
      this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
      this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
      this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
      this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
      this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
      this.pnlArchive = new System.Windows.Forms.Panel();
      this.txtArchiveQuickSearch = new System.Windows.Forms.TextBox();
      this.listArchive = new PoL.WinFormsView.Utils.CardListView();
      this.toolStrip3 = new System.Windows.Forms.ToolStrip();
      this.lblArchiveQuickSearch = new System.Windows.Forms.ToolStripLabel();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      this.btnSearchParameters = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.btnSearchToMain = new System.Windows.Forms.ToolStripButton();
      this.btnSearchToSide = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.lblArchiveCount = new System.Windows.Forms.ToolStripLabel();
      this.pnlArchiveHeader = new System.Windows.Forms.Panel();
      this.lblArchive = new System.Windows.Forms.Label();
      this.deckSplitContainer = new System.Windows.Forms.SplitContainer();
      this.panel1 = new System.Windows.Forms.Panel();
      this.txtMainQuickSearch = new System.Windows.Forms.TextBox();
      this.listMain = new PoL.WinFormsView.Utils.CardListView();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.lblMainQuickSearch = new System.Windows.Forms.ToolStripLabel();
      this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
      this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
      this.btnDuplicateMain = new System.Windows.Forms.ToolStripButton();
      this.btnRemoveMain = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.btnMainToSide = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.btnClearMain = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
      this.lblMainCount = new System.Windows.Forms.ToolStripLabel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.lblMain = new System.Windows.Forms.Label();
      this.panel3 = new System.Windows.Forms.Panel();
      this.txtSideQuickSearch = new System.Windows.Forms.TextBox();
      this.listSideboard = new PoL.WinFormsView.Utils.CardListView();
      this.toolStrip2 = new System.Windows.Forms.ToolStrip();
      this.lblSideQuickSearch = new System.Windows.Forms.ToolStripLabel();
      this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
      this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
      this.btnDuplicateSide = new System.Windows.Forms.ToolStripButton();
      this.btnRemoveSide = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.btnSideToMain = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.btnClearSide = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
      this.lblSideCount = new System.Windows.Forms.ToolStripLabel();
      this.panel4 = new System.Windows.Forms.Panel();
      this.lblSide = new System.Windows.Forms.Label();
      this.pnlRight.SuspendLayout();
      this.pnlOtherInfo.SuspendLayout();
      this.pnlButtons.SuspendLayout();
      this.pnlPreview.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cardPreview)).BeginInit();
      this.mainSplitContainer.Panel1.SuspendLayout();
      this.mainSplitContainer.Panel2.SuspendLayout();
      this.mainSplitContainer.SuspendLayout();
      this.pnlArchive.SuspendLayout();
      this.toolStrip3.SuspendLayout();
      this.pnlArchiveHeader.SuspendLayout();
      this.deckSplitContainer.Panel1.SuspendLayout();
      this.deckSplitContainer.Panel2.SuspendLayout();
      this.deckSplitContainer.SuspendLayout();
      this.panel1.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.toolStrip2.SuspendLayout();
      this.panel4.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlRight
      // 
      this.pnlRight.Controls.Add(this.pnlOtherInfo);
      this.pnlRight.Controls.Add(this.pnlPreview);
      this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
      this.pnlRight.Location = new System.Drawing.Point(748, 0);
      this.pnlRight.Name = "pnlRight";
      this.pnlRight.Size = new System.Drawing.Size(260, 730);
      this.pnlRight.TabIndex = 32;
      // 
      // pnlOtherInfo
      // 
      this.pnlOtherInfo.Controls.Add(this.lblOtherInfo);
      this.pnlOtherInfo.Controls.Add(this.pnlButtons);
      this.pnlOtherInfo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlOtherInfo.Location = new System.Drawing.Point(0, 344);
      this.pnlOtherInfo.Name = "pnlOtherInfo";
      this.pnlOtherInfo.Padding = new System.Windows.Forms.Padding(5);
      this.pnlOtherInfo.Size = new System.Drawing.Size(260, 386);
      this.pnlOtherInfo.TabIndex = 50;
      // 
      // lblOtherInfo
      // 
      this.lblOtherInfo.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.lblOtherInfo.BackColor = System.Drawing.Color.Transparent;
      this.lblOtherInfo.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.lblOtherInfo.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
      this.lblOtherInfo.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.lblOtherInfo.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.lblOtherInfo.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.lblOtherInfo.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.lblOtherInfo.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblOtherInfo.Enabled = false;
      this.lblOtherInfo.FadingSpeed = 0;
      this.lblOtherInfo.FlatAppearance.BorderSize = 0;
      this.lblOtherInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.lblOtherInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblOtherInfo.ForeColor = System.Drawing.Color.DarkBlue;
      this.lblOtherInfo.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Top;
      this.lblOtherInfo.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.lblOtherInfo.ImageOffset = 5;
      this.lblOtherInfo.IsPressed = false;
      this.lblOtherInfo.KeepPress = false;
      this.lblOtherInfo.Location = new System.Drawing.Point(5, 5);
      this.lblOtherInfo.MaxImageSize = new System.Drawing.Point(38, 0);
      this.lblOtherInfo.MenuPos = new System.Drawing.Point(0, 0);
      this.lblOtherInfo.Name = "lblOtherInfo";
      this.lblOtherInfo.Radius = 10;
      this.lblOtherInfo.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.lblOtherInfo.Size = new System.Drawing.Size(250, 43);
      this.lblOtherInfo.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.lblOtherInfo.SplitDistance = 0;
      this.lblOtherInfo.TabIndex = 86;
      this.lblOtherInfo.Text = "Other Info";
      this.lblOtherInfo.Title = "Other info";
      this.lblOtherInfo.UseVisualStyleBackColor = true;
      // 
      // pnlButtons
      // 
      this.pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlButtons.Controls.Add(this.btnOrientation);
      this.pnlButtons.Controls.Add(this.mCbDeckCategory);
      this.pnlButtons.Controls.Add(this.txtDeckName);
      this.pnlButtons.Controls.Add(this.btnExit);
      this.pnlButtons.Controls.Add(this.lblCategory);
      this.pnlButtons.Controls.Add(this.btnSaveExit);
      this.pnlButtons.Controls.Add(this.lblName);
      this.pnlButtons.Controls.Add(this.btnSave);
      this.pnlButtons.Location = new System.Drawing.Point(5, 48);
      this.pnlButtons.Name = "pnlButtons";
      this.pnlButtons.Size = new System.Drawing.Size(250, 335);
      this.pnlButtons.TabIndex = 85;
      // 
      // btnOrientation
      // 
      this.btnOrientation.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnOrientation.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnOrientation.BackColor = System.Drawing.Color.Transparent;
      this.btnOrientation.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnOrientation.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnOrientation.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnOrientation.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnOrientation.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnOrientation.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnOrientation.FadingSpeed = 20;
      this.btnOrientation.FlatAppearance.BorderSize = 0;
      this.btnOrientation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnOrientation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOrientation.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnOrientation.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
      this.btnOrientation.Image = global::PoL.WinFormsView.Properties.Resources.emblem_symbolic_link;
      this.btnOrientation.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnOrientation.ImageOffset = 8;
      this.btnOrientation.IsPressed = false;
      this.btnOrientation.KeepPress = false;
      this.btnOrientation.Location = new System.Drawing.Point(59, 155);
      this.btnOrientation.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnOrientation.MenuPos = new System.Drawing.Point(0, 0);
      this.btnOrientation.Name = "btnOrientation";
      this.btnOrientation.Radius = 10;
      this.btnOrientation.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnOrientation.Size = new System.Drawing.Size(132, 41);
      this.btnOrientation.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnOrientation.SplitDistance = 30;
      this.btnOrientation.TabIndex = 85;
      this.btnOrientation.TabStop = false;
      this.btnOrientation.Text = "Orientation";
      this.btnOrientation.Title = "";
      this.btnOrientation.UseVisualStyleBackColor = true;
      // 
      // mCbDeckCategory
      // 
      this.mCbDeckCategory.FormattingEnabled = true;
      this.mCbDeckCategory.Location = new System.Drawing.Point(13, 70);
      this.mCbDeckCategory.MaxLength = 50;
      this.mCbDeckCategory.Name = "mCbDeckCategory";
      this.mCbDeckCategory.Size = new System.Drawing.Size(216, 22);
      this.mCbDeckCategory.TabIndex = 8;
      // 
      // txtDeckName
      // 
      this.txtDeckName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtDeckName.Location = new System.Drawing.Point(13, 30);
      this.txtDeckName.MaxLength = 50;
      this.txtDeckName.Name = "txtDeckName";
      this.txtDeckName.Size = new System.Drawing.Size(216, 20);
      this.txtDeckName.TabIndex = 7;
      // 
      // btnExit
      // 
      this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnExit.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnExit.BackColor = System.Drawing.Color.Transparent;
      this.btnExit.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnExit.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnExit.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnExit.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnExit.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnExit.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnExit.FadingSpeed = 20;
      this.btnExit.FlatAppearance.BorderSize = 0;
      this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnExit.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnExit.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Bottom;
      this.btnExit.Image = global::PoL.WinFormsView.Properties.Resources.stop;
      this.btnExit.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnExit.ImageOffset = 8;
      this.btnExit.IsPressed = false;
      this.btnExit.KeepPress = false;
      this.btnExit.Location = new System.Drawing.Point(3, 288);
      this.btnExit.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnExit.MenuPos = new System.Drawing.Point(0, 0);
      this.btnExit.Name = "btnExit";
      this.btnExit.Radius = 10;
      this.btnExit.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnExit.Size = new System.Drawing.Size(239, 41);
      this.btnExit.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnExit.SplitDistance = 30;
      this.btnExit.TabIndex = 84;
      this.btnExit.TabStop = false;
      this.btnExit.Text = "Exit";
      this.btnExit.Title = "";
      this.btnExit.UseVisualStyleBackColor = true;
      // 
      // lblCategory
      // 
      this.lblCategory.AutoSize = true;
      this.lblCategory.BackColor = System.Drawing.Color.Transparent;
      this.lblCategory.Location = new System.Drawing.Point(10, 53);
      this.lblCategory.Name = "lblCategory";
      this.lblCategory.Size = new System.Drawing.Size(66, 14);
      this.lblCategory.TabIndex = 54;
      this.lblCategory.Text = "CATEGORY";
      // 
      // btnSaveExit
      // 
      this.btnSaveExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSaveExit.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnSaveExit.BackColor = System.Drawing.Color.Transparent;
      this.btnSaveExit.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnSaveExit.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnSaveExit.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnSaveExit.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnSaveExit.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnSaveExit.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnSaveExit.FadingSpeed = 20;
      this.btnSaveExit.FlatAppearance.BorderSize = 0;
      this.btnSaveExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSaveExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnSaveExit.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnSaveExit.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Center;
      this.btnSaveExit.Image = global::PoL.WinFormsView.Properties.Resources.exit;
      this.btnSaveExit.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnSaveExit.ImageOffset = 8;
      this.btnSaveExit.IsPressed = false;
      this.btnSaveExit.KeepPress = false;
      this.btnSaveExit.Location = new System.Drawing.Point(3, 245);
      this.btnSaveExit.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnSaveExit.MenuPos = new System.Drawing.Point(0, 0);
      this.btnSaveExit.Name = "btnSaveExit";
      this.btnSaveExit.Radius = 10;
      this.btnSaveExit.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnSaveExit.Size = new System.Drawing.Size(239, 41);
      this.btnSaveExit.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnSaveExit.SplitDistance = 30;
      this.btnSaveExit.TabIndex = 83;
      this.btnSaveExit.TabStop = false;
      this.btnSaveExit.Text = "Save and exit";
      this.btnSaveExit.Title = "";
      this.btnSaveExit.UseVisualStyleBackColor = true;
      // 
      // lblName
      // 
      this.lblName.AutoSize = true;
      this.lblName.BackColor = System.Drawing.Color.Transparent;
      this.lblName.Location = new System.Drawing.Point(10, 13);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(37, 14);
      this.lblName.TabIndex = 53;
      this.lblName.Text = "NAME";
      // 
      // btnSave
      // 
      this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
      this.btnSave.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Top;
      this.btnSave.Image = global::PoL.WinFormsView.Properties.Resources.document_save;
      this.btnSave.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnSave.ImageOffset = 8;
      this.btnSave.IsPressed = false;
      this.btnSave.KeepPress = false;
      this.btnSave.Location = new System.Drawing.Point(3, 202);
      this.btnSave.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnSave.MenuPos = new System.Drawing.Point(0, 0);
      this.btnSave.Name = "btnSave";
      this.btnSave.Radius = 10;
      this.btnSave.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnSave.Size = new System.Drawing.Size(239, 41);
      this.btnSave.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnSave.SplitDistance = 30;
      this.btnSave.TabIndex = 82;
      this.btnSave.TabStop = false;
      this.btnSave.Text = "Save";
      this.btnSave.Title = "";
      this.btnSave.UseVisualStyleBackColor = true;
      // 
      // pnlPreview
      // 
      this.pnlPreview.Controls.Add(this.cardPreview);
      this.pnlPreview.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlPreview.Location = new System.Drawing.Point(0, 0);
      this.pnlPreview.Name = "pnlPreview";
      this.pnlPreview.Size = new System.Drawing.Size(260, 344);
      this.pnlPreview.TabIndex = 52;
      // 
      // cardPreview
      // 
      this.cardPreview.Location = new System.Drawing.Point(5, 5);
      this.cardPreview.Name = "cardPreview";
      this.cardPreview.Size = new System.Drawing.Size(250, 334);
      this.cardPreview.TabIndex = 52;
      this.cardPreview.TabStop = false;
      // 
      // BottomToolStripPanel
      // 
      this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
      this.BottomToolStripPanel.Name = "BottomToolStripPanel";
      this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
      this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
      // 
      // TopToolStripPanel
      // 
      this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
      this.TopToolStripPanel.Name = "TopToolStripPanel";
      this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
      this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
      // 
      // RightToolStripPanel
      // 
      this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
      this.RightToolStripPanel.Name = "RightToolStripPanel";
      this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
      this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
      // 
      // LeftToolStripPanel
      // 
      this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
      this.LeftToolStripPanel.Name = "LeftToolStripPanel";
      this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
      this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
      // 
      // ContentPanel
      // 
      this.ContentPanel.Size = new System.Drawing.Size(150, 150);
      // 
      // mainSplitContainer
      // 
      this.mainSplitContainer.BackColor = System.Drawing.SystemColors.Control;
      this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
      this.mainSplitContainer.Name = "mainSplitContainer";
      this.mainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // mainSplitContainer.Panel1
      // 
      this.mainSplitContainer.Panel1.BackColor = System.Drawing.Color.White;
      this.mainSplitContainer.Panel1.Controls.Add(this.pnlArchive);
      // 
      // mainSplitContainer.Panel2
      // 
      this.mainSplitContainer.Panel2.Controls.Add(this.deckSplitContainer);
      this.mainSplitContainer.Size = new System.Drawing.Size(748, 730);
      this.mainSplitContainer.SplitterDistance = 244;
      this.mainSplitContainer.TabIndex = 35;
      this.mainSplitContainer.TabStop = false;
      // 
      // pnlArchive
      // 
      this.pnlArchive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlArchive.Controls.Add(this.txtArchiveQuickSearch);
      this.pnlArchive.Controls.Add(this.listArchive);
      this.pnlArchive.Controls.Add(this.toolStrip3);
      this.pnlArchive.Controls.Add(this.pnlArchiveHeader);
      this.pnlArchive.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlArchive.Location = new System.Drawing.Point(0, 0);
      this.pnlArchive.Name = "pnlArchive";
      this.pnlArchive.Size = new System.Drawing.Size(748, 244);
      this.pnlArchive.TabIndex = 0;
      // 
      // txtArchiveQuickSearch
      // 
      this.txtArchiveQuickSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtArchiveQuickSearch.Location = new System.Drawing.Point(52, 25);
      this.txtArchiveQuickSearch.Name = "txtArchiveQuickSearch";
      this.txtArchiveQuickSearch.Size = new System.Drawing.Size(100, 20);
      this.txtArchiveQuickSearch.TabIndex = 1;
      // 
      // listArchive
      // 
      this.listArchive.AllowDrop = true;
      this.listArchive.Behavior = PoL.WinFormsView.Utils.CardListBehavior.EditorArchive;
      this.listArchive.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.listArchive.DataSource = null;
      this.listArchive.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listArchive.GridLines = true;
      this.listArchive.HideSelection = false;
      this.listArchive.Location = new System.Drawing.Point(0, 48);
      this.listArchive.Name = "listArchive";
      this.listArchive.OwnerDraw = true;
      this.listArchive.ShowItemToolTips = true;
      this.listArchive.Size = new System.Drawing.Size(746, 194);
      this.listArchive.TabIndex = 2;
      this.listArchive.UseCompatibleStateImageBehavior = false;
      this.listArchive.View = System.Windows.Forms.View.Details;
      this.listArchive.VirtualMode = true;
      // 
      // toolStrip3
      // 
      this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblArchiveQuickSearch,
            this.toolStripLabel1,
            this.toolStripSeparator7,
            this.btnSearchParameters,
            this.toolStripSeparator6,
            this.btnSearchToMain,
            this.btnSearchToSide,
            this.toolStripSeparator3,
            this.lblArchiveCount});
      this.toolStrip3.Location = new System.Drawing.Point(0, 23);
      this.toolStrip3.Name = "toolStrip3";
      this.toolStrip3.Size = new System.Drawing.Size(746, 25);
      this.toolStrip3.TabIndex = 1;
      this.toolStrip3.Text = "toolStrip3";
      // 
      // lblArchiveQuickSearch
      // 
      this.lblArchiveQuickSearch.AutoSize = false;
      this.lblArchiveQuickSearch.Name = "lblArchiveQuickSearch";
      this.lblArchiveQuickSearch.Size = new System.Drawing.Size(45, 22);
      this.lblArchiveQuickSearch.Text = "Search:";
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.AutoSize = false;
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(100, 22);
      this.toolStripLabel1.Text = "toolStripLabel1";
      // 
      // toolStripSeparator7
      // 
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
      // 
      // btnSearchParameters
      // 
      this.btnSearchParameters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnSearchParameters.Image = global::PoL.WinFormsView.Properties.Resources.zoom_best_fit;
      this.btnSearchParameters.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnSearchParameters.Name = "btnSearchParameters";
      this.btnSearchParameters.Size = new System.Drawing.Size(23, 22);
      this.btnSearchParameters.Text = "toolStripButton1";
      // 
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
      // 
      // btnSearchToMain
      // 
      this.btnSearchToMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnSearchToMain.Image = global::PoL.WinFormsView.Properties.Resources.forward1;
      this.btnSearchToMain.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnSearchToMain.Name = "btnSearchToMain";
      this.btnSearchToMain.Size = new System.Drawing.Size(23, 22);
      this.btnSearchToMain.Text = "To main";
      // 
      // btnSearchToSide
      // 
      this.btnSearchToSide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnSearchToSide.Image = global::PoL.WinFormsView.Properties.Resources.finish1;
      this.btnSearchToSide.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnSearchToSide.Name = "btnSearchToSide";
      this.btnSearchToSide.Size = new System.Drawing.Size(23, 22);
      this.btnSearchToSide.Text = "To sideboard";
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
      // 
      // lblArchiveCount
      // 
      this.lblArchiveCount.Name = "lblArchiveCount";
      this.lblArchiveCount.Size = new System.Drawing.Size(86, 22);
      this.lblArchiveCount.Text = "toolStripLabel1";
      // 
      // pnlArchiveHeader
      // 
      this.pnlArchiveHeader.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.sfondoblu;
      this.pnlArchiveHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pnlArchiveHeader.Controls.Add(this.lblArchive);
      this.pnlArchiveHeader.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlArchiveHeader.Location = new System.Drawing.Point(0, 0);
      this.pnlArchiveHeader.Name = "pnlArchiveHeader";
      this.pnlArchiveHeader.Size = new System.Drawing.Size(746, 23);
      this.pnlArchiveHeader.TabIndex = 57;
      // 
      // lblArchive
      // 
      this.lblArchive.BackColor = System.Drawing.Color.Transparent;
      this.lblArchive.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblArchive.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.lblArchive.ForeColor = System.Drawing.Color.DarkBlue;
      this.lblArchive.Location = new System.Drawing.Point(0, 0);
      this.lblArchive.Name = "lblArchive";
      this.lblArchive.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.lblArchive.Size = new System.Drawing.Size(746, 23);
      this.lblArchive.TabIndex = 53;
      this.lblArchive.Text = "Archive";
      this.lblArchive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // deckSplitContainer
      // 
      this.deckSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.deckSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.deckSplitContainer.Location = new System.Drawing.Point(0, 0);
      this.deckSplitContainer.Name = "deckSplitContainer";
      // 
      // deckSplitContainer.Panel1
      // 
      this.deckSplitContainer.Panel1.BackColor = System.Drawing.Color.White;
      this.deckSplitContainer.Panel1.Controls.Add(this.panel1);
      // 
      // deckSplitContainer.Panel2
      // 
      this.deckSplitContainer.Panel2.BackColor = System.Drawing.Color.White;
      this.deckSplitContainer.Panel2.Controls.Add(this.panel3);
      this.deckSplitContainer.Size = new System.Drawing.Size(748, 482);
      this.deckSplitContainer.SplitterDistance = 417;
      this.deckSplitContainer.TabIndex = 36;
      this.deckSplitContainer.TabStop = false;
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.SystemColors.Control;
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.txtMainQuickSearch);
      this.panel1.Controls.Add(this.listMain);
      this.panel1.Controls.Add(this.toolStrip1);
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(417, 482);
      this.panel1.TabIndex = 0;
      // 
      // txtMainQuickSearch
      // 
      this.txtMainQuickSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtMainQuickSearch.Location = new System.Drawing.Point(52, 28);
      this.txtMainQuickSearch.Name = "txtMainQuickSearch";
      this.txtMainQuickSearch.Size = new System.Drawing.Size(100, 20);
      this.txtMainQuickSearch.TabIndex = 3;
      // 
      // listMain
      // 
      this.listMain.AllowDrop = true;
      this.listMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.listMain.DataSource = null;
      this.listMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listMain.GridLines = true;
      this.listMain.HideSelection = false;
      this.listMain.Location = new System.Drawing.Point(0, 51);
      this.listMain.Name = "listMain";
      this.listMain.OwnerDraw = true;
      this.listMain.ShowItemToolTips = true;
      this.listMain.Size = new System.Drawing.Size(415, 429);
      this.listMain.TabIndex = 4;
      this.listMain.UseCompatibleStateImageBehavior = false;
      this.listMain.View = System.Windows.Forms.View.Details;
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMainQuickSearch,
            this.toolStripLabel2,
            this.toolStripSeparator8,
            this.btnDuplicateMain,
            this.btnRemoveMain,
            this.toolStripSeparator4,
            this.btnMainToSide,
            this.toolStripSeparator1,
            this.btnClearMain,
            this.toolStripSeparator10,
            this.lblMainCount});
      this.toolStrip1.Location = new System.Drawing.Point(0, 26);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(415, 25);
      this.toolStrip1.TabIndex = 3;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // lblMainQuickSearch
      // 
      this.lblMainQuickSearch.AutoSize = false;
      this.lblMainQuickSearch.Name = "lblMainQuickSearch";
      this.lblMainQuickSearch.Size = new System.Drawing.Size(45, 22);
      this.lblMainQuickSearch.Text = "Search:";
      // 
      // toolStripLabel2
      // 
      this.toolStripLabel2.AutoSize = false;
      this.toolStripLabel2.Name = "toolStripLabel2";
      this.toolStripLabel2.Size = new System.Drawing.Size(100, 22);
      this.toolStripLabel2.Text = "toolStripLabel2";
      // 
      // toolStripSeparator8
      // 
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
      // 
      // btnDuplicateMain
      // 
      this.btnDuplicateMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnDuplicateMain.Image = global::PoL.WinFormsView.Properties.Resources.list_add;
      this.btnDuplicateMain.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnDuplicateMain.Name = "btnDuplicateMain";
      this.btnDuplicateMain.Size = new System.Drawing.Size(23, 22);
      this.btnDuplicateMain.Text = "toolStripButton3";
      this.btnDuplicateMain.ToolTipText = "Duplicate";
      // 
      // btnRemoveMain
      // 
      this.btnRemoveMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnRemoveMain.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveMain.Image")));
      this.btnRemoveMain.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnRemoveMain.Name = "btnRemoveMain";
      this.btnRemoveMain.Size = new System.Drawing.Size(23, 22);
      this.btnRemoveMain.Text = "toolStripButton2";
      this.btnRemoveMain.ToolTipText = "Remove";
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
      // 
      // btnMainToSide
      // 
      this.btnMainToSide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnMainToSide.Image = global::PoL.WinFormsView.Properties.Resources.down1;
      this.btnMainToSide.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnMainToSide.Name = "btnMainToSide";
      this.btnMainToSide.Size = new System.Drawing.Size(23, 22);
      this.btnMainToSide.Text = "toolStripButton1";
      this.btnMainToSide.ToolTipText = "To side";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // btnClearMain
      // 
      this.btnClearMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnClearMain.Image = global::PoL.WinFormsView.Properties.Resources.gtk_delete1;
      this.btnClearMain.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnClearMain.Name = "btnClearMain";
      this.btnClearMain.Size = new System.Drawing.Size(23, 22);
      this.btnClearMain.Text = "toolStripButton1";
      this.btnClearMain.ToolTipText = "Clear";
      // 
      // toolStripSeparator10
      // 
      this.toolStripSeparator10.Name = "toolStripSeparator10";
      this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
      // 
      // lblMainCount
      // 
      this.lblMainCount.Name = "lblMainCount";
      this.lblMainCount.Size = new System.Drawing.Size(86, 22);
      this.lblMainCount.Text = "toolStripLabel1";
      // 
      // panel2
      // 
      this.panel2.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.sfondoblu;
      this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.panel2.Controls.Add(this.lblMain);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(415, 26);
      this.panel2.TabIndex = 54;
      // 
      // lblMain
      // 
      this.lblMain.BackColor = System.Drawing.Color.Transparent;
      this.lblMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.lblMain.ForeColor = System.Drawing.Color.DarkBlue;
      this.lblMain.Location = new System.Drawing.Point(0, 0);
      this.lblMain.Name = "lblMain";
      this.lblMain.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.lblMain.Size = new System.Drawing.Size(415, 26);
      this.lblMain.TabIndex = 53;
      this.lblMain.Text = "Main";
      this.lblMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // panel3
      // 
      this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel3.Controls.Add(this.txtSideQuickSearch);
      this.panel3.Controls.Add(this.listSideboard);
      this.panel3.Controls.Add(this.toolStrip2);
      this.panel3.Controls.Add(this.panel4);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(327, 482);
      this.panel3.TabIndex = 0;
      // 
      // txtSideQuickSearch
      // 
      this.txtSideQuickSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtSideQuickSearch.Location = new System.Drawing.Point(52, 29);
      this.txtSideQuickSearch.Name = "txtSideQuickSearch";
      this.txtSideQuickSearch.Size = new System.Drawing.Size(100, 20);
      this.txtSideQuickSearch.TabIndex = 5;
      // 
      // listSideboard
      // 
      this.listSideboard.AllowDrop = true;
      this.listSideboard.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.listSideboard.DataSource = null;
      this.listSideboard.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listSideboard.GridLines = true;
      this.listSideboard.HideSelection = false;
      this.listSideboard.Location = new System.Drawing.Point(0, 52);
      this.listSideboard.Name = "listSideboard";
      this.listSideboard.OwnerDraw = true;
      this.listSideboard.ShowItemToolTips = true;
      this.listSideboard.Size = new System.Drawing.Size(325, 428);
      this.listSideboard.TabIndex = 6;
      this.listSideboard.UseCompatibleStateImageBehavior = false;
      this.listSideboard.View = System.Windows.Forms.View.Details;
      // 
      // toolStrip2
      // 
      this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSideQuickSearch,
            this.toolStripLabel3,
            this.toolStripSeparator9,
            this.btnDuplicateSide,
            this.btnRemoveSide,
            this.toolStripSeparator5,
            this.btnSideToMain,
            this.toolStripSeparator2,
            this.btnClearSide,
            this.toolStripSeparator11,
            this.lblSideCount});
      this.toolStrip2.Location = new System.Drawing.Point(0, 27);
      this.toolStrip2.Name = "toolStrip2";
      this.toolStrip2.Size = new System.Drawing.Size(325, 25);
      this.toolStrip2.TabIndex = 59;
      this.toolStrip2.Text = "toolStrip2";
      // 
      // lblSideQuickSearch
      // 
      this.lblSideQuickSearch.AutoSize = false;
      this.lblSideQuickSearch.Name = "lblSideQuickSearch";
      this.lblSideQuickSearch.Size = new System.Drawing.Size(45, 22);
      this.lblSideQuickSearch.Text = "Search:";
      // 
      // toolStripLabel3
      // 
      this.toolStripLabel3.AutoSize = false;
      this.toolStripLabel3.Name = "toolStripLabel3";
      this.toolStripLabel3.Size = new System.Drawing.Size(100, 15);
      this.toolStripLabel3.Text = "toolStripLabel3";
      // 
      // toolStripSeparator9
      // 
      this.toolStripSeparator9.Name = "toolStripSeparator9";
      this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
      // 
      // btnDuplicateSide
      // 
      this.btnDuplicateSide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnDuplicateSide.Image = global::PoL.WinFormsView.Properties.Resources.list_add;
      this.btnDuplicateSide.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnDuplicateSide.Name = "btnDuplicateSide";
      this.btnDuplicateSide.Size = new System.Drawing.Size(23, 22);
      this.btnDuplicateSide.Text = "toolStripButton3";
      this.btnDuplicateSide.ToolTipText = "Increment";
      // 
      // btnRemoveSide
      // 
      this.btnRemoveSide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnRemoveSide.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveSide.Image")));
      this.btnRemoveSide.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnRemoveSide.Name = "btnRemoveSide";
      this.btnRemoveSide.Size = new System.Drawing.Size(23, 22);
      this.btnRemoveSide.Text = "toolStripButton2";
      this.btnRemoveSide.ToolTipText = "Remove";
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
      // 
      // btnSideToMain
      // 
      this.btnSideToMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnSideToMain.Image = global::PoL.WinFormsView.Properties.Resources.go_up1;
      this.btnSideToMain.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnSideToMain.Name = "btnSideToMain";
      this.btnSideToMain.Size = new System.Drawing.Size(23, 22);
      this.btnSideToMain.Text = "toolStripButton1";
      this.btnSideToMain.ToolTipText = "To main";
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // btnClearSide
      // 
      this.btnClearSide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnClearSide.Image = global::PoL.WinFormsView.Properties.Resources.gtk_delete1;
      this.btnClearSide.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnClearSide.Name = "btnClearSide";
      this.btnClearSide.Size = new System.Drawing.Size(23, 22);
      this.btnClearSide.Text = "toolStripButton1";
      this.btnClearSide.ToolTipText = "Clear";
      // 
      // toolStripSeparator11
      // 
      this.toolStripSeparator11.Name = "toolStripSeparator11";
      this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
      // 
      // lblSideCount
      // 
      this.lblSideCount.Name = "lblSideCount";
      this.lblSideCount.Size = new System.Drawing.Size(86, 15);
      this.lblSideCount.Text = "toolStripLabel1";
      // 
      // panel4
      // 
      this.panel4.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.sfondoblu;
      this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.panel4.Controls.Add(this.lblSide);
      this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel4.Location = new System.Drawing.Point(0, 0);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(325, 27);
      this.panel4.TabIndex = 57;
      // 
      // lblSide
      // 
      this.lblSide.BackColor = System.Drawing.Color.Transparent;
      this.lblSide.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblSide.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.lblSide.ForeColor = System.Drawing.Color.DarkBlue;
      this.lblSide.Location = new System.Drawing.Point(0, 0);
      this.lblSide.Name = "lblSide";
      this.lblSide.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.lblSide.Size = new System.Drawing.Size(325, 27);
      this.lblSide.TabIndex = 54;
      this.lblSide.Text = "Side";
      this.lblSide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // DeckEditorView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnExit;
      this.ClientSize = new System.Drawing.Size(1008, 730);
      this.Controls.Add(this.mainSplitContainer);
      this.Controls.Add(this.pnlRight);
      this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.Name = "DeckEditorView";
      this.Text = "DeckEditorForm";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.pnlRight.ResumeLayout(false);
      this.pnlOtherInfo.ResumeLayout(false);
      this.pnlButtons.ResumeLayout(false);
      this.pnlButtons.PerformLayout();
      this.pnlPreview.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.cardPreview)).EndInit();
      this.mainSplitContainer.Panel1.ResumeLayout(false);
      this.mainSplitContainer.Panel2.ResumeLayout(false);
      this.mainSplitContainer.ResumeLayout(false);
      this.pnlArchive.ResumeLayout(false);
      this.pnlArchive.PerformLayout();
      this.toolStrip3.ResumeLayout(false);
      this.toolStrip3.PerformLayout();
      this.pnlArchiveHeader.ResumeLayout(false);
      this.deckSplitContainer.Panel1.ResumeLayout(false);
      this.deckSplitContainer.Panel2.ResumeLayout(false);
      this.deckSplitContainer.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.toolStrip2.ResumeLayout(false);
      this.toolStrip2.PerformLayout();
      this.panel4.ResumeLayout(false);
      this.ResumeLayout(false);

		}

		#endregion

    private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlOtherInfo;
        private RibbonStyle.RibbonMenuButton btnSaveExit;
        private RibbonStyle.RibbonMenuButton btnSave;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.PictureBox cardPreview;
        private RibbonStyle.RibbonMenuButton btnExit;
        private RibbonStyle.RibbonMenuButton lblOtherInfo;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.ComboBox mCbDeckCategory;
        private System.Windows.Forms.TextBox txtDeckName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.SplitContainer deckSplitContainer;
        private System.Windows.Forms.Panel pnlArchive;
        private PoL.WinFormsView.Utils.CardListView listArchive;
        private System.Windows.Forms.Panel pnlArchiveHeader;
        private System.Windows.Forms.Label lblArchive;
        private System.Windows.Forms.Panel panel1;
        private PoL.WinFormsView.Utils.CardListView listMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel lblArchiveQuickSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnSearchParameters;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnSearchToMain;
        private System.Windows.Forms.ToolStripButton btnSearchToSide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel lblArchiveCount;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblMainQuickSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnDuplicateMain;
        private System.Windows.Forms.ToolStripButton btnRemoveMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnMainToSide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClearMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripLabel lblMainCount;
        private System.Windows.Forms.Panel panel3;
        private PoL.WinFormsView.Utils.CardListView listSideboard;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel lblSideQuickSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnDuplicateSide;
        private System.Windows.Forms.ToolStripButton btnRemoveSide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnSideToMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClearSide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripLabel lblSideCount;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblSide;
        private RibbonStyle.RibbonMenuButton btnOrientation;
        private System.Windows.Forms.TextBox txtArchiveQuickSearch;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TextBox txtMainQuickSearch;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.TextBox txtSideQuickSearch;
	}
}