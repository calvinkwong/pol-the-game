namespace PoL.WinFormsView.DeckRoom
{
	partial class DeckRoomView
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeckRoomView));
      this.pnlCenterTop = new System.Windows.Forms.Panel();
      this.listCard = new PoL.WinFormsView.Utils.CardListView();
      this.lblYourDeck = new RibbonStyle.RibbonMenuButton();
      this.pnlCenterBottom = new System.Windows.Forms.Panel();
      this.listSideboard = new PoL.WinFormsView.Utils.CardListView();
      this.lblYourSideboard = new RibbonStyle.RibbonMenuButton();
      this.pnlLeft = new System.Windows.Forms.Panel();
      this.listDeck = new System.Windows.Forms.ListView();
      this.colDeckListName = new System.Windows.Forms.ColumnHeader();
      this.lblDeckList = new RibbonStyle.RibbonMenuButton();
      this.btnOK = new RibbonStyle.RibbonMenuButton();
      this.btnQuit = new RibbonStyle.RibbonMenuButton();
      this.btnEdit = new RibbonStyle.RibbonMenuButton();
      this.btnDelete = new RibbonStyle.RibbonMenuButton();
      this.btnNew = new RibbonStyle.RibbonMenuButton();
      this.cardPreview = new System.Windows.Forms.PictureBox();
      this.btnExport = new RibbonStyle.RibbonMenuButton();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.btnImport = new RibbonStyle.RibbonMenuButton();
      this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.pnlCenterTop.SuspendLayout();
      this.pnlCenterBottom.SuspendLayout();
      this.pnlLeft.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cardPreview)).BeginInit();
      this.SuspendLayout();
      // 
      // pnlCenterTop
      // 
      this.pnlCenterTop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlCenterTop.Controls.Add(this.listCard);
      this.pnlCenterTop.Controls.Add(this.lblYourDeck);
      this.pnlCenterTop.Location = new System.Drawing.Point(234, 14);
      this.pnlCenterTop.Name = "pnlCenterTop";
      this.pnlCenterTop.Size = new System.Drawing.Size(379, 270);
      this.pnlCenterTop.TabIndex = 19;
      // 
      // listCard
      // 
      this.listCard.Behavior = PoL.WinFormsView.Utils.CardListBehavior.DeckRoom;
      this.listCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.listCard.DataSource = null;
      this.listCard.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listCard.FullRowSelect = true;
      this.listCard.GridLines = true;
      this.listCard.HideSelection = false;
      this.listCard.Location = new System.Drawing.Point(0, 45);
      this.listCard.Name = "listCard";
      this.listCard.OwnerDraw = true;
      this.listCard.ShowItemToolTips = true;
      this.listCard.Size = new System.Drawing.Size(379, 225);
      this.listCard.TabIndex = 15;
      this.listCard.UseCompatibleStateImageBehavior = false;
      this.listCard.View = System.Windows.Forms.View.Details;
      // 
      // lblYourDeck
      // 
      this.lblYourDeck.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.lblYourDeck.BackColor = System.Drawing.Color.Transparent;
      this.lblYourDeck.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.lblYourDeck.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
      this.lblYourDeck.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.lblYourDeck.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.lblYourDeck.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.lblYourDeck.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.lblYourDeck.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblYourDeck.Enabled = false;
      this.lblYourDeck.FadingSpeed = 0;
      this.lblYourDeck.FlatAppearance.BorderSize = 0;
      this.lblYourDeck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.lblYourDeck.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblYourDeck.ForeColor = System.Drawing.Color.DarkBlue;
      this.lblYourDeck.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Top;
      this.lblYourDeck.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.lblYourDeck.ImageOffset = 5;
      this.lblYourDeck.IsPressed = false;
      this.lblYourDeck.KeepPress = false;
      this.lblYourDeck.Location = new System.Drawing.Point(0, 0);
      this.lblYourDeck.MaxImageSize = new System.Drawing.Point(38, 0);
      this.lblYourDeck.MenuPos = new System.Drawing.Point(0, 0);
      this.lblYourDeck.Name = "lblYourDeck";
      this.lblYourDeck.Radius = 15;
      this.lblYourDeck.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.lblYourDeck.Size = new System.Drawing.Size(379, 45);
      this.lblYourDeck.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.lblYourDeck.SplitDistance = 0;
      this.lblYourDeck.TabIndex = 49;
      this.lblYourDeck.Text = "These are the cards contained into deck";
      this.lblYourDeck.Title = "Cards";
      this.lblYourDeck.UseVisualStyleBackColor = true;
      // 
      // pnlCenterBottom
      // 
      this.pnlCenterBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlCenterBottom.Controls.Add(this.listSideboard);
      this.pnlCenterBottom.Controls.Add(this.lblYourSideboard);
      this.pnlCenterBottom.Location = new System.Drawing.Point(234, 284);
      this.pnlCenterBottom.Name = "pnlCenterBottom";
      this.pnlCenterBottom.Size = new System.Drawing.Size(379, 219);
      this.pnlCenterBottom.TabIndex = 20;
      // 
      // listSideboard
      // 
      this.listSideboard.Behavior = PoL.WinFormsView.Utils.CardListBehavior.DeckRoom;
      this.listSideboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.listSideboard.DataSource = null;
      this.listSideboard.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listSideboard.FullRowSelect = true;
      this.listSideboard.GridLines = true;
      this.listSideboard.HideSelection = false;
      this.listSideboard.Location = new System.Drawing.Point(0, 45);
      this.listSideboard.Name = "listSideboard";
      this.listSideboard.OwnerDraw = true;
      this.listSideboard.ShowItemToolTips = true;
      this.listSideboard.Size = new System.Drawing.Size(379, 174);
      this.listSideboard.TabIndex = 16;
      this.listSideboard.UseCompatibleStateImageBehavior = false;
      this.listSideboard.View = System.Windows.Forms.View.Details;
      // 
      // lblYourSideboard
      // 
      this.lblYourSideboard.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.lblYourSideboard.BackColor = System.Drawing.Color.Transparent;
      this.lblYourSideboard.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.lblYourSideboard.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
      this.lblYourSideboard.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.lblYourSideboard.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.lblYourSideboard.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.lblYourSideboard.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.lblYourSideboard.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblYourSideboard.Enabled = false;
      this.lblYourSideboard.FadingSpeed = 0;
      this.lblYourSideboard.FlatAppearance.BorderSize = 0;
      this.lblYourSideboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.lblYourSideboard.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblYourSideboard.ForeColor = System.Drawing.Color.DarkBlue;
      this.lblYourSideboard.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Center;
      this.lblYourSideboard.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.lblYourSideboard.ImageOffset = 5;
      this.lblYourSideboard.IsPressed = false;
      this.lblYourSideboard.KeepPress = false;
      this.lblYourSideboard.Location = new System.Drawing.Point(0, 0);
      this.lblYourSideboard.MaxImageSize = new System.Drawing.Point(38, 0);
      this.lblYourSideboard.MenuPos = new System.Drawing.Point(0, 0);
      this.lblYourSideboard.Name = "lblYourSideboard";
      this.lblYourSideboard.Radius = 30;
      this.lblYourSideboard.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.lblYourSideboard.Size = new System.Drawing.Size(379, 45);
      this.lblYourSideboard.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.lblYourSideboard.SplitDistance = 0;
      this.lblYourSideboard.TabIndex = 48;
      this.lblYourSideboard.Text = "These are the cards contained into sideboard";
      this.lblYourSideboard.Title = "Sideboard";
      this.lblYourSideboard.UseVisualStyleBackColor = true;
      // 
      // pnlLeft
      // 
      this.pnlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)));
      this.pnlLeft.Controls.Add(this.listDeck);
      this.pnlLeft.Controls.Add(this.lblDeckList);
      this.pnlLeft.Location = new System.Drawing.Point(12, 13);
      this.pnlLeft.Name = "pnlLeft";
      this.pnlLeft.Size = new System.Drawing.Size(216, 298);
      this.pnlLeft.TabIndex = 17;
      // 
      // listDeck
      // 
      this.listDeck.BackgroundImageTiled = true;
      this.listDeck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.listDeck.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDeckListName});
      this.listDeck.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listDeck.FullRowSelect = true;
      this.listDeck.GridLines = true;
      this.listDeck.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.listDeck.HideSelection = false;
      this.listDeck.Location = new System.Drawing.Point(0, 43);
      this.listDeck.MultiSelect = false;
      this.listDeck.Name = "listDeck";
      this.listDeck.Size = new System.Drawing.Size(216, 255);
      this.listDeck.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.listDeck.TabIndex = 1;
      this.listDeck.UseCompatibleStateImageBehavior = false;
      this.listDeck.View = System.Windows.Forms.View.Details;
      // 
      // colDeckListName
      // 
      this.colDeckListName.Text = "NAME";
      this.colDeckListName.Width = 170;
      // 
      // lblDeckList
      // 
      this.lblDeckList.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.lblDeckList.BackColor = System.Drawing.Color.Transparent;
      this.lblDeckList.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.lblDeckList.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
      this.lblDeckList.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.lblDeckList.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.lblDeckList.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.lblDeckList.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.lblDeckList.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblDeckList.Enabled = false;
      this.lblDeckList.FadingSpeed = 0;
      this.lblDeckList.FlatAppearance.BorderSize = 0;
      this.lblDeckList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.lblDeckList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDeckList.ForeColor = System.Drawing.Color.DarkBlue;
      this.lblDeckList.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Top;
      this.lblDeckList.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.lblDeckList.ImageOffset = 5;
      this.lblDeckList.IsPressed = false;
      this.lblDeckList.KeepPress = false;
      this.lblDeckList.Location = new System.Drawing.Point(0, 0);
      this.lblDeckList.MaxImageSize = new System.Drawing.Point(38, 0);
      this.lblDeckList.MenuPos = new System.Drawing.Point(0, 0);
      this.lblDeckList.Name = "lblDeckList";
      this.lblDeckList.Radius = 15;
      this.lblDeckList.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.lblDeckList.Size = new System.Drawing.Size(216, 43);
      this.lblDeckList.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.lblDeckList.SplitDistance = 0;
      this.lblDeckList.TabIndex = 47;
      this.lblDeckList.Text = "Choose a deck from list";
      this.lblDeckList.Title = "Deck List";
      this.lblDeckList.UseVisualStyleBackColor = true;
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnOK.BackColor = System.Drawing.Color.Transparent;
      this.btnOK.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnOK.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnOK.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnOK.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnOK.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnOK.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnOK.FadingSpeed = 20;
      this.btnOK.FlatAppearance.BorderSize = 0;
      this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnOK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOK.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnOK.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Left;
      this.btnOK.Image = global::PoL.WinFormsView.Properties.Resources.emblem_default;
      this.btnOK.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnOK.ImageOffset = 8;
      this.btnOK.IsPressed = false;
      this.btnOK.KeepPress = false;
      this.btnOK.Location = new System.Drawing.Point(625, 462);
      this.btnOK.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnOK.MenuPos = new System.Drawing.Point(0, 0);
      this.btnOK.Name = "btnOK";
      this.btnOK.Radius = 15;
      this.btnOK.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnOK.Size = new System.Drawing.Size(124, 41);
      this.btnOK.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnOK.SplitDistance = 30;
      this.btnOK.TabIndex = 78;
      this.btnOK.Text = "Ok";
      this.btnOK.Title = "";
      this.btnOK.UseVisualStyleBackColor = true;
      // 
      // btnQuit
      // 
      this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnQuit.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnQuit.BackColor = System.Drawing.Color.Transparent;
      this.btnQuit.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnQuit.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnQuit.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnQuit.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnQuit.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnQuit.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnQuit.FadingSpeed = 20;
      this.btnQuit.FlatAppearance.BorderSize = 0;
      this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnQuit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnQuit.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnQuit.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Right;
      this.btnQuit.Image = global::PoL.WinFormsView.Properties.Resources.stop;
      this.btnQuit.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnQuit.ImageOffset = 8;
      this.btnQuit.IsPressed = false;
      this.btnQuit.KeepPress = false;
      this.btnQuit.Location = new System.Drawing.Point(758, 462);
      this.btnQuit.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnQuit.MenuPos = new System.Drawing.Point(0, 0);
      this.btnQuit.Name = "btnQuit";
      this.btnQuit.Radius = 15;
      this.btnQuit.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnQuit.Size = new System.Drawing.Size(117, 41);
      this.btnQuit.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnQuit.SplitDistance = 30;
      this.btnQuit.TabIndex = 79;
      this.btnQuit.Text = "Quit";
      this.btnQuit.Title = "";
      this.btnQuit.UseVisualStyleBackColor = true;
      // 
      // btnEdit
      // 
      this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnEdit.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnEdit.BackColor = System.Drawing.Color.Transparent;
      this.btnEdit.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnEdit.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnEdit.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnEdit.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnEdit.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnEdit.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnEdit.FadingSpeed = 20;
      this.btnEdit.FlatAppearance.BorderSize = 0;
      this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnEdit.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnEdit.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Center;
      this.btnEdit.Image = global::PoL.WinFormsView.Properties.Resources.gtk_edit;
      this.btnEdit.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnEdit.ImageOffset = 8;
      this.btnEdit.IsPressed = false;
      this.btnEdit.KeepPress = false;
      this.btnEdit.Location = new System.Drawing.Point(12, 366);
      this.btnEdit.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnEdit.MenuPos = new System.Drawing.Point(0, 0);
      this.btnEdit.Name = "btnEdit";
      this.btnEdit.Radius = 15;
      this.btnEdit.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnEdit.Size = new System.Drawing.Size(216, 41);
      this.btnEdit.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnEdit.SplitDistance = 30;
      this.btnEdit.TabIndex = 80;
      this.btnEdit.Text = "Edit";
      this.btnEdit.Title = "";
      this.btnEdit.UseVisualStyleBackColor = true;
      // 
      // btnDelete
      // 
      this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnDelete.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnDelete.BackColor = System.Drawing.Color.Transparent;
      this.btnDelete.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnDelete.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnDelete.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnDelete.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnDelete.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnDelete.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnDelete.FadingSpeed = 20;
      this.btnDelete.FlatAppearance.BorderSize = 0;
      this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnDelete.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnDelete.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Bottom;
      this.btnDelete.Image = global::PoL.WinFormsView.Properties.Resources.gtk_delete;
      this.btnDelete.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnDelete.ImageOffset = 8;
      this.btnDelete.IsPressed = false;
      this.btnDelete.KeepPress = false;
      this.btnDelete.Location = new System.Drawing.Point(12, 462);
      this.btnDelete.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnDelete.MenuPos = new System.Drawing.Point(0, 0);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Radius = 15;
      this.btnDelete.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnDelete.Size = new System.Drawing.Size(216, 41);
      this.btnDelete.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnDelete.SplitDistance = 30;
      this.btnDelete.TabIndex = 81;
      this.btnDelete.Text = "Delete";
      this.btnDelete.Title = "";
      this.btnDelete.UseVisualStyleBackColor = true;
      // 
      // btnNew
      // 
      this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnNew.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnNew.BackColor = System.Drawing.Color.Transparent;
      this.btnNew.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnNew.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnNew.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnNew.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnNew.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnNew.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnNew.FadingSpeed = 20;
      this.btnNew.FlatAppearance.BorderSize = 0;
      this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnNew.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnNew.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Top;
      this.btnNew.Image = global::PoL.WinFormsView.Properties.Resources.filenew;
      this.btnNew.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnNew.ImageOffset = 8;
      this.btnNew.IsPressed = false;
      this.btnNew.KeepPress = false;
      this.btnNew.Location = new System.Drawing.Point(12, 319);
      this.btnNew.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnNew.MenuPos = new System.Drawing.Point(0, 0);
      this.btnNew.Name = "btnNew";
      this.btnNew.Radius = 15;
      this.btnNew.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnNew.Size = new System.Drawing.Size(216, 41);
      this.btnNew.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnNew.SplitDistance = 30;
      this.btnNew.TabIndex = 82;
      this.btnNew.Text = "New";
      this.btnNew.Title = "";
      this.btnNew.UseVisualStyleBackColor = true;
      // 
      // cardPreview
      // 
      this.cardPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cardPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.cardPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.cardPreview.Location = new System.Drawing.Point(625, 14);
      this.cardPreview.Name = "cardPreview";
      this.cardPreview.Size = new System.Drawing.Size(250, 334);
      this.cardPreview.TabIndex = 83;
      this.cardPreview.TabStop = false;
      // 
      // btnExport
      // 
      this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnExport.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnExport.BackColor = System.Drawing.Color.Transparent;
      this.btnExport.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnExport.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnExport.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnExport.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnExport.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnExport.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnExport.FadingSpeed = 20;
      this.btnExport.FlatAppearance.BorderSize = 0;
      this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnExport.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnExport.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Center;
      this.btnExport.Image = global::PoL.WinFormsView.Properties.Resources.stock_outbox;
      this.btnExport.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnExport.ImageOffset = 8;
      this.btnExport.IsPressed = false;
      this.btnExport.KeepPress = false;
      this.btnExport.Location = new System.Drawing.Point(125, 415);
      this.btnExport.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnExport.MenuPos = new System.Drawing.Point(0, 0);
      this.btnExport.Name = "btnExport";
      this.btnExport.Radius = 15;
      this.btnExport.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnExport.Size = new System.Drawing.Size(103, 41);
      this.btnExport.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnExport.SplitDistance = 30;
      this.btnExport.TabIndex = 84;
      this.btnExport.Text = "Export";
      this.btnExport.Title = "";
      this.btnExport.UseVisualStyleBackColor = true;
      // 
      // openFileDialog
      // 
      this.openFileDialog.Multiselect = true;
      // 
      // btnImport
      // 
      this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnImport.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnImport.BackColor = System.Drawing.Color.Transparent;
      this.btnImport.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnImport.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnImport.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnImport.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnImport.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnImport.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnImport.FadingSpeed = 20;
      this.btnImport.FlatAppearance.BorderSize = 0;
      this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnImport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnImport.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnImport.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Center;
      this.btnImport.Image = global::PoL.WinFormsView.Properties.Resources.stock_inbox;
      this.btnImport.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnImport.ImageOffset = 8;
      this.btnImport.IsPressed = false;
      this.btnImport.KeepPress = false;
      this.btnImport.Location = new System.Drawing.Point(12, 415);
      this.btnImport.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnImport.MenuPos = new System.Drawing.Point(0, 0);
      this.btnImport.Name = "btnImport";
      this.btnImport.Radius = 15;
      this.btnImport.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnImport.Size = new System.Drawing.Size(103, 41);
      this.btnImport.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnImport.SplitDistance = 30;
      this.btnImport.TabIndex = 85;
      this.btnImport.Text = "Import";
      this.btnImport.Title = "";
      this.btnImport.UseVisualStyleBackColor = true;
      // 
      // DeckRoomView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(896, 516);
      this.Controls.Add(this.btnImport);
      this.Controls.Add(this.btnExport);
      this.Controls.Add(this.cardPreview);
      this.Controls.Add(this.btnNew);
      this.Controls.Add(this.btnDelete);
      this.Controls.Add(this.btnEdit);
      this.Controls.Add(this.btnQuit);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.pnlCenterBottom);
      this.Controls.Add(this.pnlCenterTop);
      this.Controls.Add(this.pnlLeft);
      this.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "DeckRoomView";
      this.Text = "DeckRoomForm";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.pnlCenterTop.ResumeLayout(false);
      this.pnlCenterBottom.ResumeLayout(false);
      this.pnlLeft.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.cardPreview)).EndInit();
      this.ResumeLayout(false);

		}

		#endregion

    private System.Windows.Forms.Panel pnlCenterTop;
        private PoL.WinFormsView.Utils.CardListView listCard;
        private System.Windows.Forms.Panel pnlCenterBottom;
        private PoL.WinFormsView.Utils.CardListView listSideboard;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.ListView listDeck;
        private System.Windows.Forms.ColumnHeader colDeckListName;
        private RibbonStyle.RibbonMenuButton lblDeckList;
        private RibbonStyle.RibbonMenuButton lblYourSideboard;
        private RibbonStyle.RibbonMenuButton lblYourDeck;
        private RibbonStyle.RibbonMenuButton btnOK;
        private RibbonStyle.RibbonMenuButton btnQuit;
        private RibbonStyle.RibbonMenuButton btnEdit;
        private RibbonStyle.RibbonMenuButton btnDelete;
        private RibbonStyle.RibbonMenuButton btnNew;
        private System.Windows.Forms.PictureBox cardPreview;
        private RibbonStyle.RibbonMenuButton btnExport;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private RibbonStyle.RibbonMenuButton btnImport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
	}
}