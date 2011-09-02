namespace PoL.WinFormsView.DeckEditor
{
  partial class SearchParametersView
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchParametersView));
      this.pnlSearchParameters = new System.Windows.Forms.Panel();
      this.boxSearch = new System.Windows.Forms.GroupBox();
      this.btnSelectNoneTypes = new System.Windows.Forms.Button();
      this.btnSelectAllTypes = new System.Windows.Forms.Button();
      this.btnSelectNoneRarities = new System.Windows.Forms.Button();
      this.btnSelectAllRarities = new System.Windows.Forms.Button();
      this.btnSelectNoneColors = new System.Windows.Forms.Button();
      this.btnSelectAllColors = new System.Windows.Forms.Button();
      this.btnSelectNoneSets = new System.Windows.Forms.Button();
      this.btnSelectAllSets = new System.Windows.Forms.Button();
      this.btnSelectAll = new RibbonStyle.RibbonMenuButton();
      this.txtCharacteristics = new System.Windows.Forms.TextBox();
      this.lblCharacteristics = new System.Windows.Forms.Label();
      this.lblRarity = new System.Windows.Forms.Label();
      this.listRarity = new System.Windows.Forms.CheckedListBox();
      this.btnClose = new RibbonStyle.RibbonMenuButton();
      this.btnClearFields = new RibbonStyle.RibbonMenuButton();
      this.btnSearch = new RibbonStyle.RibbonMenuButton();
      this.cbCost = new System.Windows.Forms.ComboBox();
      this.listSet = new System.Windows.Forms.CheckedListBox();
      this.lblSet = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.listType = new System.Windows.Forms.CheckedListBox();
      this.lblSearchName = new System.Windows.Forms.Label();
      this.lblType = new System.Windows.Forms.Label();
      this.lblColor = new System.Windows.Forms.Label();
      this.numCost = new System.Windows.Forms.NumericUpDown();
      this.listColor = new System.Windows.Forms.CheckedListBox();
      this.txtText = new System.Windows.Forms.TextBox();
      this.lblSearchText = new System.Windows.Forms.Label();
      this.lblSearchCost = new System.Windows.Forms.Label();
      this.lblSearchParameters = new RibbonStyle.RibbonMenuButton();
      this.pnlSearchParameters.SuspendLayout();
      this.boxSearch.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numCost)).BeginInit();
      this.SuspendLayout();
      // 
      // pnlSearchParameters
      // 
      this.pnlSearchParameters.BackColor = System.Drawing.Color.White;
      this.pnlSearchParameters.Controls.Add(this.boxSearch);
      this.pnlSearchParameters.Controls.Add(this.lblSearchParameters);
      this.pnlSearchParameters.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlSearchParameters.Location = new System.Drawing.Point(0, 0);
      this.pnlSearchParameters.Name = "pnlSearchParameters";
      this.pnlSearchParameters.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
      this.pnlSearchParameters.Size = new System.Drawing.Size(744, 421);
      this.pnlSearchParameters.TabIndex = 35;
      // 
      // boxSearch
      // 
      this.boxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.boxSearch.Controls.Add(this.btnSelectNoneTypes);
      this.boxSearch.Controls.Add(this.btnSelectAllTypes);
      this.boxSearch.Controls.Add(this.btnSelectNoneRarities);
      this.boxSearch.Controls.Add(this.btnSelectAllRarities);
      this.boxSearch.Controls.Add(this.btnSelectNoneColors);
      this.boxSearch.Controls.Add(this.btnSelectAllColors);
      this.boxSearch.Controls.Add(this.btnSelectNoneSets);
      this.boxSearch.Controls.Add(this.btnSelectAllSets);
      this.boxSearch.Controls.Add(this.btnSelectAll);
      this.boxSearch.Controls.Add(this.txtCharacteristics);
      this.boxSearch.Controls.Add(this.lblCharacteristics);
      this.boxSearch.Controls.Add(this.lblRarity);
      this.boxSearch.Controls.Add(this.listRarity);
      this.boxSearch.Controls.Add(this.btnClose);
      this.boxSearch.Controls.Add(this.btnClearFields);
      this.boxSearch.Controls.Add(this.btnSearch);
      this.boxSearch.Controls.Add(this.cbCost);
      this.boxSearch.Controls.Add(this.listSet);
      this.boxSearch.Controls.Add(this.lblSet);
      this.boxSearch.Controls.Add(this.txtName);
      this.boxSearch.Controls.Add(this.listType);
      this.boxSearch.Controls.Add(this.lblSearchName);
      this.boxSearch.Controls.Add(this.lblType);
      this.boxSearch.Controls.Add(this.lblColor);
      this.boxSearch.Controls.Add(this.numCost);
      this.boxSearch.Controls.Add(this.listColor);
      this.boxSearch.Controls.Add(this.txtText);
      this.boxSearch.Controls.Add(this.lblSearchText);
      this.boxSearch.Controls.Add(this.lblSearchCost);
      this.boxSearch.Location = new System.Drawing.Point(6, 43);
      this.boxSearch.Name = "boxSearch";
      this.boxSearch.Size = new System.Drawing.Size(731, 373);
      this.boxSearch.TabIndex = 84;
      this.boxSearch.TabStop = false;
      // 
      // btnSelectNoneTypes
      // 
      this.btnSelectNoneTypes.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.stock_calc_cancel;
      this.btnSelectNoneTypes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnSelectNoneTypes.Location = new System.Drawing.Point(501, 7);
      this.btnSelectNoneTypes.Name = "btnSelectNoneTypes";
      this.btnSelectNoneTypes.Size = new System.Drawing.Size(20, 20);
      this.btnSelectNoneTypes.TabIndex = 111;
      this.btnSelectNoneTypes.UseVisualStyleBackColor = true;
      // 
      // btnSelectAllTypes
      // 
      this.btnSelectAllTypes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelectAllTypes.BackgroundImage")));
      this.btnSelectAllTypes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnSelectAllTypes.Location = new System.Drawing.Point(482, 7);
      this.btnSelectAllTypes.Name = "btnSelectAllTypes";
      this.btnSelectAllTypes.Size = new System.Drawing.Size(20, 20);
      this.btnSelectAllTypes.TabIndex = 110;
      this.btnSelectAllTypes.UseVisualStyleBackColor = true;
      // 
      // btnSelectNoneRarities
      // 
      this.btnSelectNoneRarities.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.stock_calc_cancel;
      this.btnSelectNoneRarities.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnSelectNoneRarities.Location = new System.Drawing.Point(331, 187);
      this.btnSelectNoneRarities.Name = "btnSelectNoneRarities";
      this.btnSelectNoneRarities.Size = new System.Drawing.Size(20, 20);
      this.btnSelectNoneRarities.TabIndex = 109;
      this.btnSelectNoneRarities.UseVisualStyleBackColor = true;
      // 
      // btnSelectAllRarities
      // 
      this.btnSelectAllRarities.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelectAllRarities.BackgroundImage")));
      this.btnSelectAllRarities.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnSelectAllRarities.Location = new System.Drawing.Point(312, 187);
      this.btnSelectAllRarities.Name = "btnSelectAllRarities";
      this.btnSelectAllRarities.Size = new System.Drawing.Size(20, 20);
      this.btnSelectAllRarities.TabIndex = 108;
      this.btnSelectAllRarities.UseVisualStyleBackColor = true;
      // 
      // btnSelectNoneColors
      // 
      this.btnSelectNoneColors.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.stock_calc_cancel;
      this.btnSelectNoneColors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnSelectNoneColors.Location = new System.Drawing.Point(331, 7);
      this.btnSelectNoneColors.Name = "btnSelectNoneColors";
      this.btnSelectNoneColors.Size = new System.Drawing.Size(20, 20);
      this.btnSelectNoneColors.TabIndex = 107;
      this.btnSelectNoneColors.UseVisualStyleBackColor = true;
      // 
      // btnSelectAllColors
      // 
      this.btnSelectAllColors.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelectAllColors.BackgroundImage")));
      this.btnSelectAllColors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnSelectAllColors.Location = new System.Drawing.Point(312, 7);
      this.btnSelectAllColors.Name = "btnSelectAllColors";
      this.btnSelectAllColors.Size = new System.Drawing.Size(20, 20);
      this.btnSelectAllColors.TabIndex = 106;
      this.btnSelectAllColors.UseVisualStyleBackColor = true;
      // 
      // btnSelectNoneSets
      // 
      this.btnSelectNoneSets.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.stock_calc_cancel;
      this.btnSelectNoneSets.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnSelectNoneSets.Location = new System.Drawing.Point(163, 7);
      this.btnSelectNoneSets.Name = "btnSelectNoneSets";
      this.btnSelectNoneSets.Size = new System.Drawing.Size(20, 20);
      this.btnSelectNoneSets.TabIndex = 105;
      this.btnSelectNoneSets.UseVisualStyleBackColor = true;
      // 
      // btnSelectAllSets
      // 
      this.btnSelectAllSets.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelectAllSets.BackgroundImage")));
      this.btnSelectAllSets.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnSelectAllSets.Location = new System.Drawing.Point(144, 7);
      this.btnSelectAllSets.Name = "btnSelectAllSets";
      this.btnSelectAllSets.Size = new System.Drawing.Size(20, 20);
      this.btnSelectAllSets.TabIndex = 104;
      this.btnSelectAllSets.UseVisualStyleBackColor = true;
      // 
      // btnSelectAll
      // 
      this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSelectAll.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnSelectAll.BackColor = System.Drawing.Color.Transparent;
      this.btnSelectAll.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnSelectAll.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnSelectAll.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnSelectAll.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnSelectAll.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnSelectAll.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnSelectAll.FadingSpeed = 20;
      this.btnSelectAll.FlatAppearance.BorderSize = 0;
      this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSelectAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnSelectAll.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnSelectAll.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Center;
      this.btnSelectAll.Image = global::PoL.WinFormsView.Properties.Resources.stock_calc_accept1;
      this.btnSelectAll.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnSelectAll.ImageOffset = 8;
      this.btnSelectAll.IsPressed = false;
      this.btnSelectAll.KeepPress = false;
      this.btnSelectAll.Location = new System.Drawing.Point(576, 248);
      this.btnSelectAll.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnSelectAll.MenuPos = new System.Drawing.Point(0, 0);
      this.btnSelectAll.Name = "btnSelectAll";
      this.btnSelectAll.Radius = 10;
      this.btnSelectAll.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnSelectAll.Size = new System.Drawing.Size(143, 33);
      this.btnSelectAll.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnSelectAll.SplitDistance = 30;
      this.btnSelectAll.TabIndex = 103;
      this.btnSelectAll.Text = "Select all";
      this.btnSelectAll.Title = "";
      this.btnSelectAll.UseVisualStyleBackColor = true;
      // 
      // txtCharacteristics
      // 
      this.txtCharacteristics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtCharacteristics.Location = new System.Drawing.Point(532, 109);
      this.txtCharacteristics.Name = "txtCharacteristics";
      this.txtCharacteristics.Size = new System.Drawing.Size(187, 20);
      this.txtCharacteristics.TabIndex = 101;
      // 
      // lblCharacteristics
      // 
      this.lblCharacteristics.AutoSize = true;
      this.lblCharacteristics.BackColor = System.Drawing.Color.Transparent;
      this.lblCharacteristics.Location = new System.Drawing.Point(530, 93);
      this.lblCharacteristics.Name = "lblCharacteristics";
      this.lblCharacteristics.Size = new System.Drawing.Size(107, 13);
      this.lblCharacteristics.TabIndex = 102;
      this.lblCharacteristics.Text = "CHARACTERISTICS";
      // 
      // lblRarity
      // 
      this.lblRarity.AutoSize = true;
      this.lblRarity.BackColor = System.Drawing.Color.Transparent;
      this.lblRarity.Location = new System.Drawing.Point(190, 193);
      this.lblRarity.Name = "lblRarity";
      this.lblRarity.Size = new System.Drawing.Size(47, 13);
      this.lblRarity.TabIndex = 99;
      this.lblRarity.Text = "RARITY";
      // 
      // listRarity
      // 
      this.listRarity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.listRarity.CheckOnClick = true;
      this.listRarity.FormattingEnabled = true;
      this.listRarity.Location = new System.Drawing.Point(189, 207);
      this.listRarity.Name = "listRarity";
      this.listRarity.Size = new System.Drawing.Size(163, 152);
      this.listRarity.TabIndex = 100;
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnClose.BackColor = System.Drawing.Color.Transparent;
      this.btnClose.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnClose.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnClose.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnClose.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnClose.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnClose.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnClose.FadingSpeed = 20;
      this.btnClose.FlatAppearance.BorderSize = 0;
      this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnClose.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnClose.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Bottom;
      this.btnClose.Image = global::PoL.WinFormsView.Properties.Resources.stop;
      this.btnClose.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnClose.ImageOffset = 8;
      this.btnClose.IsPressed = false;
      this.btnClose.KeepPress = false;
      this.btnClose.Location = new System.Drawing.Point(576, 326);
      this.btnClose.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
      this.btnClose.Name = "btnClose";
      this.btnClose.Radius = 10;
      this.btnClose.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnClose.Size = new System.Drawing.Size(143, 33);
      this.btnClose.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnClose.SplitDistance = 30;
      this.btnClose.TabIndex = 98;
      this.btnClose.Text = "Close";
      this.btnClose.Title = "";
      this.btnClose.UseVisualStyleBackColor = true;
      // 
      // btnClearFields
      // 
      this.btnClearFields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClearFields.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnClearFields.BackColor = System.Drawing.Color.Transparent;
      this.btnClearFields.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnClearFields.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnClearFields.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnClearFields.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnClearFields.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnClearFields.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnClearFields.FadingSpeed = 20;
      this.btnClearFields.FlatAppearance.BorderSize = 0;
      this.btnClearFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnClearFields.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnClearFields.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnClearFields.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Center;
      this.btnClearFields.Image = global::PoL.WinFormsView.Properties.Resources.stock_calc_cancel;
      this.btnClearFields.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnClearFields.ImageOffset = 8;
      this.btnClearFields.IsPressed = false;
      this.btnClearFields.KeepPress = false;
      this.btnClearFields.Location = new System.Drawing.Point(576, 287);
      this.btnClearFields.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnClearFields.MenuPos = new System.Drawing.Point(0, 0);
      this.btnClearFields.Name = "btnClearFields";
      this.btnClearFields.Radius = 10;
      this.btnClearFields.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnClearFields.Size = new System.Drawing.Size(143, 33);
      this.btnClearFields.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnClearFields.SplitDistance = 30;
      this.btnClearFields.TabIndex = 97;
      this.btnClearFields.Text = "Clear fields";
      this.btnClearFields.Title = "";
      this.btnClearFields.UseVisualStyleBackColor = true;
      // 
      // btnSearch
      // 
      this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSearch.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnSearch.BackColor = System.Drawing.Color.Transparent;
      this.btnSearch.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnSearch.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnSearch.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnSearch.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnSearch.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnSearch.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnSearch.FadingSpeed = 20;
      this.btnSearch.FlatAppearance.BorderSize = 0;
      this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnSearch.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnSearch.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Top;
      this.btnSearch.Image = global::PoL.WinFormsView.Properties.Resources.gtk_zoom_fit;
      this.btnSearch.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnSearch.ImageOffset = 8;
      this.btnSearch.IsPressed = false;
      this.btnSearch.KeepPress = false;
      this.btnSearch.Location = new System.Drawing.Point(576, 207);
      this.btnSearch.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnSearch.MenuPos = new System.Drawing.Point(0, 0);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Radius = 10;
      this.btnSearch.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnSearch.Size = new System.Drawing.Size(143, 33);
      this.btnSearch.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnSearch.SplitDistance = 30;
      this.btnSearch.TabIndex = 96;
      this.btnSearch.Text = "Search";
      this.btnSearch.Title = "";
      this.btnSearch.UseVisualStyleBackColor = true;
      // 
      // cbCost
      // 
      this.cbCost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbCost.FormattingEnabled = true;
      this.cbCost.Items.AddRange(new object[] {
            "",
            "<",
            "=",
            ">"});
      this.cbCost.Location = new System.Drawing.Point(532, 158);
      this.cbCost.Name = "cbCost";
      this.cbCost.Size = new System.Drawing.Size(66, 21);
      this.cbCost.TabIndex = 95;
      // 
      // listSet
      // 
      this.listSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.listSet.CheckOnClick = true;
      this.listSet.FormattingEnabled = true;
      this.listSet.Location = new System.Drawing.Point(6, 27);
      this.listSet.Name = "listSet";
      this.listSet.Size = new System.Drawing.Size(177, 332);
      this.listSet.TabIndex = 86;
      // 
      // lblSet
      // 
      this.lblSet.AutoSize = true;
      this.lblSet.BackColor = System.Drawing.Color.Transparent;
      this.lblSet.Location = new System.Drawing.Point(6, 13);
      this.lblSet.Name = "lblSet";
      this.lblSet.Size = new System.Drawing.Size(28, 13);
      this.lblSet.TabIndex = 83;
      this.lblSet.Text = "SET";
      // 
      // txtName
      // 
      this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtName.Location = new System.Drawing.Point(533, 27);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(187, 20);
      this.txtName.TabIndex = 84;
      // 
      // listType
      // 
      this.listType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.listType.CheckOnClick = true;
      this.listType.FormattingEnabled = true;
      this.listType.Location = new System.Drawing.Point(358, 27);
      this.listType.Name = "listType";
      this.listType.Size = new System.Drawing.Size(163, 332);
      this.listType.TabIndex = 94;
      // 
      // lblSearchName
      // 
      this.lblSearchName.AutoSize = true;
      this.lblSearchName.BackColor = System.Drawing.Color.Transparent;
      this.lblSearchName.Location = new System.Drawing.Point(530, 13);
      this.lblSearchName.Name = "lblSearchName";
      this.lblSearchName.Size = new System.Drawing.Size(38, 13);
      this.lblSearchName.TabIndex = 85;
      this.lblSearchName.Text = "NAME";
      // 
      // lblType
      // 
      this.lblType.AutoSize = true;
      this.lblType.BackColor = System.Drawing.Color.Transparent;
      this.lblType.Location = new System.Drawing.Point(359, 13);
      this.lblType.Name = "lblType";
      this.lblType.Size = new System.Drawing.Size(35, 13);
      this.lblType.TabIndex = 93;
      this.lblType.Text = "TYPE";
      // 
      // lblColor
      // 
      this.lblColor.AutoSize = true;
      this.lblColor.BackColor = System.Drawing.Color.Transparent;
      this.lblColor.Location = new System.Drawing.Point(190, 13);
      this.lblColor.Name = "lblColor";
      this.lblColor.Size = new System.Drawing.Size(44, 13);
      this.lblColor.TabIndex = 87;
      this.lblColor.Text = "COLOR";
      // 
      // numCost
      // 
      this.numCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.numCost.Location = new System.Drawing.Point(604, 159);
      this.numCost.Name = "numCost";
      this.numCost.Size = new System.Drawing.Size(54, 20);
      this.numCost.TabIndex = 92;
      // 
      // listColor
      // 
      this.listColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.listColor.CheckOnClick = true;
      this.listColor.FormattingEnabled = true;
      this.listColor.Location = new System.Drawing.Point(189, 27);
      this.listColor.Name = "listColor";
      this.listColor.Size = new System.Drawing.Size(163, 152);
      this.listColor.TabIndex = 88;
      // 
      // txtText
      // 
      this.txtText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtText.Location = new System.Drawing.Point(533, 66);
      this.txtText.Name = "txtText";
      this.txtText.Size = new System.Drawing.Size(187, 20);
      this.txtText.TabIndex = 89;
      // 
      // lblSearchText
      // 
      this.lblSearchText.AutoSize = true;
      this.lblSearchText.BackColor = System.Drawing.Color.Transparent;
      this.lblSearchText.Location = new System.Drawing.Point(529, 50);
      this.lblSearchText.Name = "lblSearchText";
      this.lblSearchText.Size = new System.Drawing.Size(35, 13);
      this.lblSearchText.TabIndex = 90;
      this.lblSearchText.Text = "TEXT";
      // 
      // lblSearchCost
      // 
      this.lblSearchCost.AutoSize = true;
      this.lblSearchCost.BackColor = System.Drawing.Color.Transparent;
      this.lblSearchCost.Location = new System.Drawing.Point(531, 142);
      this.lblSearchCost.Name = "lblSearchCost";
      this.lblSearchCost.Size = new System.Drawing.Size(36, 13);
      this.lblSearchCost.TabIndex = 91;
      this.lblSearchCost.Text = "COST";
      // 
      // lblSearchParameters
      // 
      this.lblSearchParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblSearchParameters.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.lblSearchParameters.BackColor = System.Drawing.Color.Transparent;
      this.lblSearchParameters.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.lblSearchParameters.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
      this.lblSearchParameters.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.lblSearchParameters.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.lblSearchParameters.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.lblSearchParameters.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.lblSearchParameters.Enabled = false;
      this.lblSearchParameters.FadingSpeed = 0;
      this.lblSearchParameters.FlatAppearance.BorderSize = 0;
      this.lblSearchParameters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.lblSearchParameters.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblSearchParameters.ForeColor = System.Drawing.Color.DarkBlue;
      this.lblSearchParameters.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
      this.lblSearchParameters.Image = global::PoL.WinFormsView.Properties.Resources.gtk_zoom_fit;
      this.lblSearchParameters.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.lblSearchParameters.ImageOffset = 5;
      this.lblSearchParameters.IsPressed = false;
      this.lblSearchParameters.KeepPress = false;
      this.lblSearchParameters.Location = new System.Drawing.Point(6, 5);
      this.lblSearchParameters.MaxImageSize = new System.Drawing.Point(38, 0);
      this.lblSearchParameters.MenuPos = new System.Drawing.Point(0, 0);
      this.lblSearchParameters.Name = "lblSearchParameters";
      this.lblSearchParameters.Radius = 10;
      this.lblSearchParameters.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.lblSearchParameters.Size = new System.Drawing.Size(731, 38);
      this.lblSearchParameters.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.lblSearchParameters.SplitDistance = 0;
      this.lblSearchParameters.TabIndex = 54;
      this.lblSearchParameters.Text = "Insert search parameters";
      this.lblSearchParameters.Title = "Search Parameters";
      this.lblSearchParameters.UseVisualStyleBackColor = true;
      // 
      // SearchParametersView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(744, 421);
      this.Controls.Add(this.pnlSearchParameters);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "SearchParametersView";
      this.pnlSearchParameters.ResumeLayout(false);
      this.boxSearch.ResumeLayout(false);
      this.boxSearch.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numCost)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlSearchParameters;
    private System.Windows.Forms.GroupBox boxSearch;
    private RibbonStyle.RibbonMenuButton btnClearFields;
    private RibbonStyle.RibbonMenuButton btnSearch;
    private System.Windows.Forms.ComboBox cbCost;
    private System.Windows.Forms.CheckedListBox listSet;
    private System.Windows.Forms.Label lblSet;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.CheckedListBox listType;
    private System.Windows.Forms.Label lblSearchName;
    private System.Windows.Forms.Label lblType;
    private System.Windows.Forms.Label lblColor;
    private System.Windows.Forms.NumericUpDown numCost;
    private System.Windows.Forms.CheckedListBox listColor;
    private System.Windows.Forms.TextBox txtText;
    private System.Windows.Forms.Label lblSearchText;
    private System.Windows.Forms.Label lblSearchCost;
    private RibbonStyle.RibbonMenuButton lblSearchParameters;
    private RibbonStyle.RibbonMenuButton btnClose;
    private System.Windows.Forms.Label lblRarity;
    private System.Windows.Forms.CheckedListBox listRarity;
    private System.Windows.Forms.TextBox txtCharacteristics;
    private System.Windows.Forms.Label lblCharacteristics;
    private RibbonStyle.RibbonMenuButton btnSelectAll;
    private System.Windows.Forms.Button btnSelectAllSets;
    private System.Windows.Forms.Button btnSelectNoneSets;
    private System.Windows.Forms.Button btnSelectNoneTypes;
    private System.Windows.Forms.Button btnSelectAllTypes;
    private System.Windows.Forms.Button btnSelectNoneRarities;
    private System.Windows.Forms.Button btnSelectAllRarities;
    private System.Windows.Forms.Button btnSelectNoneColors;
    private System.Windows.Forms.Button btnSelectAllColors;
  }
}