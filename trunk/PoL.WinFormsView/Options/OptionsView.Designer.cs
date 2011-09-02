namespace PoL.WinFormsView.Options
{
  partial class OptionsView
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsView));
      this.menuImportPictures = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.menuImportInternalPictures = new System.Windows.Forms.ToolStripMenuItem();
      this.menuImportMwsPictures = new System.Windows.Forms.ToolStripMenuItem();
      this.menuCardsLanguage = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.menuGameLanguage = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.menuClientLanguage = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.openAvatarFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.btnCancel = new RibbonStyle.RibbonMenuButton();
      this.btnOk = new RibbonStyle.RibbonMenuButton();
      this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.mainTab = new System.Windows.Forms.TabControl();
      this.pagePlayer = new System.Windows.Forms.TabPage();
      this.lblMessage = new System.Windows.Forms.Label();
      this.lblPicture = new System.Windows.Forms.Label();
      this.lblNickName = new System.Windows.Forms.Label();
      this.btnRemovePicture = new RibbonStyle.RibbonMenuButton();
      this.btnChangePicture = new RibbonStyle.RibbonMenuButton();
      this.txtMessage = new System.Windows.Forms.TextBox();
      this.picAvatar = new System.Windows.Forms.PictureBox();
      this.txtNickname = new System.Windows.Forms.TextBox();
      this.pagePictures = new System.Windows.Forms.TabPage();
      this.chkSetMapping = new System.Windows.Forms.CheckBox();
      this.btnBrowsePicturesPath = new RibbonStyle.RibbonMenuButton();
      this.lblPicturesPath = new System.Windows.Forms.Label();
      this.txtCardPicturesPath = new System.Windows.Forms.TextBox();
      this.rbCrop = new System.Windows.Forms.RadioButton();
      this.rbFull = new System.Windows.Forms.RadioButton();
      this.pageLanguages = new System.Windows.Forms.TabPage();
      this.lblGameLanguage = new System.Windows.Forms.Label();
      this.lblClientLanguage = new System.Windows.Forms.Label();
      this.btnGameLanguage = new RibbonStyle.RibbonMenuButton();
      this.btnClientLanguage = new RibbonStyle.RibbonMenuButton();
      this.pageSystem = new System.Windows.Forms.TabPage();
      this.chkAnimateHand = new System.Windows.Forms.CheckBox();
      this.boxNetwork = new System.Windows.Forms.GroupBox();
      this.numPort = new System.Windows.Forms.NumericUpDown();
      this.lblListenPort = new System.Windows.Forms.Label();
      this.chkKeepGameLog = new System.Windows.Forms.CheckBox();
      this.menuImportPictures.SuspendLayout();
      this.mainTab.SuspendLayout();
      this.pagePlayer.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
      this.pagePictures.SuspendLayout();
      this.pageLanguages.SuspendLayout();
      this.pageSystem.SuspendLayout();
      this.boxNetwork.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
      this.SuspendLayout();
      // 
      // menuImportPictures
      // 
      this.menuImportPictures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
      this.menuImportPictures.DropShadowEnabled = false;
      this.menuImportPictures.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.menuImportPictures.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuImportInternalPictures,
            this.menuImportMwsPictures});
      this.menuImportPictures.Name = "Paste";
      this.menuImportPictures.Size = new System.Drawing.Size(187, 48);
      // 
      // menuImportInternalPictures
      // 
      this.menuImportInternalPictures.Name = "menuImportInternalPictures";
      this.menuImportInternalPictures.Size = new System.Drawing.Size(186, 22);
      this.menuImportInternalPictures.Text = "INTERNAL_PICTURES";
      // 
      // menuImportMwsPictures
      // 
      this.menuImportMwsPictures.Name = "menuImportMwsPictures";
      this.menuImportMwsPictures.Size = new System.Drawing.Size(186, 22);
      this.menuImportMwsPictures.Text = "MWS_PICTURES";
      // 
      // menuCardsLanguage
      // 
      this.menuCardsLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
      this.menuCardsLanguage.DropShadowEnabled = false;
      this.menuCardsLanguage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.menuCardsLanguage.Name = "Paste";
      this.menuCardsLanguage.Size = new System.Drawing.Size(61, 4);
      // 
      // menuGameLanguage
      // 
      this.menuGameLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
      this.menuGameLanguage.DropShadowEnabled = false;
      this.menuGameLanguage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.menuGameLanguage.Name = "Paste";
      this.menuGameLanguage.Size = new System.Drawing.Size(61, 4);
      // 
      // menuClientLanguage
      // 
      this.menuClientLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
      this.menuClientLanguage.DropShadowEnabled = false;
      this.menuClientLanguage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.menuClientLanguage.Name = "Paste";
      this.menuClientLanguage.Size = new System.Drawing.Size(61, 4);
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
      this.btnCancel.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.Right;
      this.btnCancel.Image = global::PoL.WinFormsView.Properties.Resources.stop;
      this.btnCancel.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnCancel.ImageOffset = 8;
      this.btnCancel.IsPressed = false;
      this.btnCancel.KeepPress = false;
      this.btnCancel.Location = new System.Drawing.Point(174, 350);
      this.btnCancel.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnCancel.MenuPos = new System.Drawing.Point(0, 0);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Radius = 10;
      this.btnCancel.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnCancel.Size = new System.Drawing.Size(146, 41);
      this.btnCancel.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnCancel.SplitDistance = 30;
      this.btnCancel.TabIndex = 78;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.Title = "";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
      this.btnOk.Location = new System.Drawing.Point(12, 350);
      this.btnOk.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnOk.MenuPos = new System.Drawing.Point(0, 0);
      this.btnOk.Name = "btnOk";
      this.btnOk.Radius = 10;
      this.btnOk.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnOk.Size = new System.Drawing.Size(146, 41);
      this.btnOk.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnOk.SplitDistance = 30;
      this.btnOk.TabIndex = 77;
      this.btnOk.Text = "Ok";
      this.btnOk.Title = "";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // mainTab
      // 
      this.mainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.mainTab.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
      this.mainTab.Controls.Add(this.pagePlayer);
      this.mainTab.Controls.Add(this.pagePictures);
      this.mainTab.Controls.Add(this.pageLanguages);
      this.mainTab.Controls.Add(this.pageSystem);
      this.mainTab.Location = new System.Drawing.Point(6, 12);
      this.mainTab.Name = "mainTab";
      this.mainTab.SelectedIndex = 0;
      this.mainTab.Size = new System.Drawing.Size(322, 336);
      this.mainTab.TabIndex = 89;
      // 
      // pagePlayer
      // 
      this.pagePlayer.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.sfondoblu;
      this.pagePlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pagePlayer.Controls.Add(this.lblMessage);
      this.pagePlayer.Controls.Add(this.lblPicture);
      this.pagePlayer.Controls.Add(this.lblNickName);
      this.pagePlayer.Controls.Add(this.btnRemovePicture);
      this.pagePlayer.Controls.Add(this.btnChangePicture);
      this.pagePlayer.Controls.Add(this.txtMessage);
      this.pagePlayer.Controls.Add(this.picAvatar);
      this.pagePlayer.Controls.Add(this.txtNickname);
      this.pagePlayer.Location = new System.Drawing.Point(4, 27);
      this.pagePlayer.Name = "pagePlayer";
      this.pagePlayer.Padding = new System.Windows.Forms.Padding(3);
      this.pagePlayer.Size = new System.Drawing.Size(314, 305);
      this.pagePlayer.TabIndex = 1;
      this.pagePlayer.Text = "Player";
      this.pagePlayer.UseVisualStyleBackColor = true;
      // 
      // lblMessage
      // 
      this.lblMessage.AutoSize = true;
      this.lblMessage.BackColor = System.Drawing.Color.Transparent;
      this.lblMessage.Location = new System.Drawing.Point(14, 185);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new System.Drawing.Size(53, 15);
      this.lblMessage.TabIndex = 101;
      this.lblMessage.Text = "Message";
      // 
      // lblPicture
      // 
      this.lblPicture.AutoSize = true;
      this.lblPicture.BackColor = System.Drawing.Color.Transparent;
      this.lblPicture.Location = new System.Drawing.Point(14, 76);
      this.lblPicture.Name = "lblPicture";
      this.lblPicture.Size = new System.Drawing.Size(44, 15);
      this.lblPicture.TabIndex = 100;
      this.lblPicture.Text = "Picture";
      // 
      // lblNickName
      // 
      this.lblNickName.AutoSize = true;
      this.lblNickName.BackColor = System.Drawing.Color.Transparent;
      this.lblNickName.Location = new System.Drawing.Point(14, 24);
      this.lblNickName.Name = "lblNickName";
      this.lblNickName.Size = new System.Drawing.Size(61, 15);
      this.lblNickName.TabIndex = 99;
      this.lblNickName.Text = "Nickname";
      // 
      // btnRemovePicture
      // 
      this.btnRemovePicture.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnRemovePicture.BackColor = System.Drawing.Color.Transparent;
      this.btnRemovePicture.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnRemovePicture.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnRemovePicture.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnRemovePicture.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnRemovePicture.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnRemovePicture.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnRemovePicture.FadingSpeed = 20;
      this.btnRemovePicture.FlatAppearance.BorderSize = 0;
      this.btnRemovePicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnRemovePicture.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnRemovePicture.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnRemovePicture.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
      this.btnRemovePicture.Image = global::PoL.WinFormsView.Properties.Resources.editdelete;
      this.btnRemovePicture.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnRemovePicture.ImageOffset = 8;
      this.btnRemovePicture.IsPressed = false;
      this.btnRemovePicture.KeepPress = false;
      this.btnRemovePicture.Location = new System.Drawing.Point(103, 86);
      this.btnRemovePicture.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnRemovePicture.MenuPos = new System.Drawing.Point(0, 0);
      this.btnRemovePicture.Name = "btnRemovePicture";
      this.btnRemovePicture.Radius = 2;
      this.btnRemovePicture.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnRemovePicture.Size = new System.Drawing.Size(148, 41);
      this.btnRemovePicture.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnRemovePicture.SplitDistance = 30;
      this.btnRemovePicture.TabIndex = 98;
      this.btnRemovePicture.Text = "Remove picture";
      this.btnRemovePicture.Title = "";
      this.btnRemovePicture.UseVisualStyleBackColor = true;
      // 
      // btnChangePicture
      // 
      this.btnChangePicture.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnChangePicture.BackColor = System.Drawing.Color.Transparent;
      this.btnChangePicture.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnChangePicture.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnChangePicture.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnChangePicture.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnChangePicture.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnChangePicture.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnChangePicture.FadingSpeed = 20;
      this.btnChangePicture.FlatAppearance.BorderSize = 0;
      this.btnChangePicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnChangePicture.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnChangePicture.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnChangePicture.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
      this.btnChangePicture.Image = global::PoL.WinFormsView.Properties.Resources.application_x_gnome_saved_search;
      this.btnChangePicture.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnChangePicture.ImageOffset = 8;
      this.btnChangePicture.IsPressed = false;
      this.btnChangePicture.KeepPress = false;
      this.btnChangePicture.Location = new System.Drawing.Point(103, 133);
      this.btnChangePicture.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnChangePicture.MenuPos = new System.Drawing.Point(0, 0);
      this.btnChangePicture.Name = "btnChangePicture";
      this.btnChangePicture.Radius = 2;
      this.btnChangePicture.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnChangePicture.Size = new System.Drawing.Size(148, 41);
      this.btnChangePicture.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnChangePicture.SplitDistance = 30;
      this.btnChangePicture.TabIndex = 97;
      this.btnChangePicture.Text = "Change picture...";
      this.btnChangePicture.Title = "";
      this.btnChangePicture.UseVisualStyleBackColor = true;
      // 
      // txtMessage
      // 
      this.txtMessage.Location = new System.Drawing.Point(17, 203);
      this.txtMessage.Name = "txtMessage";
      this.txtMessage.Size = new System.Drawing.Size(224, 23);
      this.txtMessage.TabIndex = 93;
      // 
      // picAvatar
      // 
      this.picAvatar.BackColor = System.Drawing.Color.White;
      this.picAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.picAvatar.Location = new System.Drawing.Point(17, 94);
      this.picAvatar.Name = "picAvatar";
      this.picAvatar.Size = new System.Drawing.Size(80, 80);
      this.picAvatar.TabIndex = 92;
      this.picAvatar.TabStop = false;
      // 
      // txtNickname
      // 
      this.txtNickname.Location = new System.Drawing.Point(17, 42);
      this.txtNickname.Name = "txtNickname";
      this.txtNickname.Size = new System.Drawing.Size(130, 23);
      this.txtNickname.TabIndex = 91;
      // 
      // pagePictures
      // 
      this.pagePictures.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.sfondoblu;
      this.pagePictures.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pagePictures.Controls.Add(this.chkSetMapping);
      this.pagePictures.Controls.Add(this.btnBrowsePicturesPath);
      this.pagePictures.Controls.Add(this.lblPicturesPath);
      this.pagePictures.Controls.Add(this.txtCardPicturesPath);
      this.pagePictures.Controls.Add(this.rbCrop);
      this.pagePictures.Controls.Add(this.rbFull);
      this.pagePictures.Location = new System.Drawing.Point(4, 25);
      this.pagePictures.Name = "pagePictures";
      this.pagePictures.Padding = new System.Windows.Forms.Padding(3);
      this.pagePictures.Size = new System.Drawing.Size(314, 307);
      this.pagePictures.TabIndex = 3;
      this.pagePictures.Text = "Pictures";
      this.pagePictures.UseVisualStyleBackColor = true;
      // 
      // chkSetMapping
      // 
      this.chkSetMapping.AutoSize = true;
      this.chkSetMapping.BackColor = System.Drawing.Color.Transparent;
      this.chkSetMapping.Location = new System.Drawing.Point(17, 124);
      this.chkSetMapping.Name = "chkSetMapping";
      this.chkSetMapping.Size = new System.Drawing.Size(119, 17);
      this.chkSetMapping.TabIndex = 111;
      this.chkSetMapping.Text = "Enable set mapping";
      this.chkSetMapping.UseVisualStyleBackColor = false;
      // 
      // btnBrowsePicturesPath
      // 
      this.btnBrowsePicturesPath.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnBrowsePicturesPath.BackColor = System.Drawing.Color.Transparent;
      this.btnBrowsePicturesPath.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnBrowsePicturesPath.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnBrowsePicturesPath.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnBrowsePicturesPath.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnBrowsePicturesPath.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnBrowsePicturesPath.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnBrowsePicturesPath.FadingSpeed = 20;
      this.btnBrowsePicturesPath.FlatAppearance.BorderSize = 0;
      this.btnBrowsePicturesPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnBrowsePicturesPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnBrowsePicturesPath.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnBrowsePicturesPath.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
      this.btnBrowsePicturesPath.Image = global::PoL.WinFormsView.Properties.Resources.application_x_gnome_saved_search1;
      this.btnBrowsePicturesPath.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnBrowsePicturesPath.ImageOffset = 8;
      this.btnBrowsePicturesPath.IsPressed = false;
      this.btnBrowsePicturesPath.KeepPress = false;
      this.btnBrowsePicturesPath.Location = new System.Drawing.Point(266, 33);
      this.btnBrowsePicturesPath.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnBrowsePicturesPath.MenuPos = new System.Drawing.Point(0, 0);
      this.btnBrowsePicturesPath.Name = "btnBrowsePicturesPath";
      this.btnBrowsePicturesPath.Radius = 2;
      this.btnBrowsePicturesPath.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnBrowsePicturesPath.Size = new System.Drawing.Size(32, 32);
      this.btnBrowsePicturesPath.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnBrowsePicturesPath.SplitDistance = 30;
      this.btnBrowsePicturesPath.TabIndex = 100;
      this.btnBrowsePicturesPath.Title = "";
      this.btnBrowsePicturesPath.UseVisualStyleBackColor = true;
      // 
      // lblPicturesPath
      // 
      this.lblPicturesPath.AutoSize = true;
      this.lblPicturesPath.BackColor = System.Drawing.Color.Transparent;
      this.lblPicturesPath.Location = new System.Drawing.Point(17, 24);
      this.lblPicturesPath.Name = "lblPicturesPath";
      this.lblPicturesPath.Size = new System.Drawing.Size(76, 15);
      this.lblPicturesPath.TabIndex = 99;
      this.lblPicturesPath.Text = "Pictures path";
      // 
      // txtCardPicturesPath
      // 
      this.txtCardPicturesPath.Location = new System.Drawing.Point(17, 42);
      this.txtCardPicturesPath.Name = "txtCardPicturesPath";
      this.txtCardPicturesPath.Size = new System.Drawing.Size(244, 23);
      this.txtCardPicturesPath.TabIndex = 98;
      // 
      // rbCrop
      // 
      this.rbCrop.AutoSize = true;
      this.rbCrop.BackColor = System.Drawing.Color.Transparent;
      this.rbCrop.Checked = true;
      this.rbCrop.Location = new System.Drawing.Point(17, 89);
      this.rbCrop.Name = "rbCrop";
      this.rbCrop.Size = new System.Drawing.Size(47, 17);
      this.rbCrop.TabIndex = 96;
      this.rbCrop.TabStop = true;
      this.rbCrop.Text = "Crop";
      this.rbCrop.UseVisualStyleBackColor = false;
      // 
      // rbFull
      // 
      this.rbFull.AutoSize = true;
      this.rbFull.BackColor = System.Drawing.Color.Transparent;
      this.rbFull.Location = new System.Drawing.Point(17, 71);
      this.rbFull.Name = "rbFull";
      this.rbFull.Size = new System.Drawing.Size(41, 17);
      this.rbFull.TabIndex = 97;
      this.rbFull.Text = "Full";
      this.rbFull.UseVisualStyleBackColor = false;
      // 
      // pageLanguages
      // 
      this.pageLanguages.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.sfondoblu;
      this.pageLanguages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pageLanguages.Controls.Add(this.lblGameLanguage);
      this.pageLanguages.Controls.Add(this.lblClientLanguage);
      this.pageLanguages.Controls.Add(this.btnGameLanguage);
      this.pageLanguages.Controls.Add(this.btnClientLanguage);
      this.pageLanguages.Location = new System.Drawing.Point(4, 25);
      this.pageLanguages.Name = "pageLanguages";
      this.pageLanguages.Padding = new System.Windows.Forms.Padding(3);
      this.pageLanguages.Size = new System.Drawing.Size(314, 307);
      this.pageLanguages.TabIndex = 4;
      this.pageLanguages.Text = "Languages";
      this.pageLanguages.UseVisualStyleBackColor = true;
      // 
      // lblGameLanguage
      // 
      this.lblGameLanguage.AutoSize = true;
      this.lblGameLanguage.BackColor = System.Drawing.Color.Transparent;
      this.lblGameLanguage.Location = new System.Drawing.Point(16, 84);
      this.lblGameLanguage.Name = "lblGameLanguage";
      this.lblGameLanguage.Size = new System.Drawing.Size(90, 15);
      this.lblGameLanguage.TabIndex = 107;
      this.lblGameLanguage.Text = "Game language";
      // 
      // lblClientLanguage
      // 
      this.lblClientLanguage.AutoSize = true;
      this.lblClientLanguage.BackColor = System.Drawing.Color.Transparent;
      this.lblClientLanguage.Location = new System.Drawing.Point(16, 25);
      this.lblClientLanguage.Name = "lblClientLanguage";
      this.lblClientLanguage.Size = new System.Drawing.Size(90, 15);
      this.lblClientLanguage.TabIndex = 106;
      this.lblClientLanguage.Text = "Client language";
      // 
      // btnGameLanguage
      // 
      this.btnGameLanguage.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.ToDown;
      this.btnGameLanguage.BackColor = System.Drawing.Color.Transparent;
      this.btnGameLanguage.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnGameLanguage.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
      this.btnGameLanguage.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnGameLanguage.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnGameLanguage.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnGameLanguage.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnGameLanguage.ContextMenuStrip = this.menuGameLanguage;
      this.btnGameLanguage.FadingSpeed = 20;
      this.btnGameLanguage.FlatAppearance.BorderSize = 0;
      this.btnGameLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnGameLanguage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnGameLanguage.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnGameLanguage.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
      this.btnGameLanguage.Image = global::PoL.WinFormsView.Properties.Resources.emblem_web;
      this.btnGameLanguage.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnGameLanguage.ImageOffset = 2;
      this.btnGameLanguage.IsPressed = false;
      this.btnGameLanguage.KeepPress = false;
      this.btnGameLanguage.Location = new System.Drawing.Point(19, 102);
      this.btnGameLanguage.MaxImageSize = new System.Drawing.Point(0, 0);
      this.btnGameLanguage.MenuPos = new System.Drawing.Point(0, 10);
      this.btnGameLanguage.Name = "btnGameLanguage";
      this.btnGameLanguage.Radius = 4;
      this.btnGameLanguage.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnGameLanguage.Size = new System.Drawing.Size(139, 24);
      this.btnGameLanguage.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnGameLanguage.SplitDistance = 14;
      this.btnGameLanguage.TabIndex = 101;
      this.btnGameLanguage.Title = "";
      this.btnGameLanguage.UseVisualStyleBackColor = true;
      // 
      // btnClientLanguage
      // 
      this.btnClientLanguage.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.ToDown;
      this.btnClientLanguage.BackColor = System.Drawing.Color.Transparent;
      this.btnClientLanguage.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnClientLanguage.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
      this.btnClientLanguage.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnClientLanguage.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnClientLanguage.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnClientLanguage.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnClientLanguage.ContextMenuStrip = this.menuClientLanguage;
      this.btnClientLanguage.FadingSpeed = 20;
      this.btnClientLanguage.FlatAppearance.BorderSize = 0;
      this.btnClientLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnClientLanguage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnClientLanguage.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnClientLanguage.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
      this.btnClientLanguage.Image = global::PoL.WinFormsView.Properties.Resources.emblem_web;
      this.btnClientLanguage.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnClientLanguage.ImageOffset = 2;
      this.btnClientLanguage.IsPressed = false;
      this.btnClientLanguage.KeepPress = false;
      this.btnClientLanguage.Location = new System.Drawing.Point(19, 43);
      this.btnClientLanguage.MaxImageSize = new System.Drawing.Point(0, 0);
      this.btnClientLanguage.MenuPos = new System.Drawing.Point(0, 10);
      this.btnClientLanguage.Name = "btnClientLanguage";
      this.btnClientLanguage.Radius = 4;
      this.btnClientLanguage.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnClientLanguage.Size = new System.Drawing.Size(139, 24);
      this.btnClientLanguage.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnClientLanguage.SplitDistance = 14;
      this.btnClientLanguage.TabIndex = 100;
      this.btnClientLanguage.Title = "";
      this.btnClientLanguage.UseVisualStyleBackColor = true;
      // 
      // pageSystem
      // 
      this.pageSystem.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.sfondoblu;
      this.pageSystem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pageSystem.Controls.Add(this.chkKeepGameLog);
      this.pageSystem.Controls.Add(this.chkAnimateHand);
      this.pageSystem.Controls.Add(this.boxNetwork);
      this.pageSystem.Location = new System.Drawing.Point(4, 27);
      this.pageSystem.Name = "pageSystem";
      this.pageSystem.Padding = new System.Windows.Forms.Padding(3);
      this.pageSystem.Size = new System.Drawing.Size(314, 305);
      this.pageSystem.TabIndex = 2;
      this.pageSystem.Text = "System";
      this.pageSystem.UseVisualStyleBackColor = true;
      // 
      // chkAnimateHand
      // 
      this.chkAnimateHand.AutoSize = true;
      this.chkAnimateHand.BackColor = System.Drawing.Color.Transparent;
      this.chkAnimateHand.Location = new System.Drawing.Point(17, 31);
      this.chkAnimateHand.Name = "chkAnimateHand";
      this.chkAnimateHand.Size = new System.Drawing.Size(101, 19);
      this.chkAnimateHand.TabIndex = 109;
      this.chkAnimateHand.Text = "Animate hand";
      this.chkAnimateHand.UseVisualStyleBackColor = false;
      // 
      // boxNetwork
      // 
      this.boxNetwork.BackColor = System.Drawing.Color.Transparent;
      this.boxNetwork.Controls.Add(this.numPort);
      this.boxNetwork.Controls.Add(this.lblListenPort);
      this.boxNetwork.Location = new System.Drawing.Point(17, 96);
      this.boxNetwork.Name = "boxNetwork";
      this.boxNetwork.Size = new System.Drawing.Size(268, 85);
      this.boxNetwork.TabIndex = 98;
      this.boxNetwork.TabStop = false;
      this.boxNetwork.Text = "Network";
      // 
      // numPort
      // 
      this.numPort.Location = new System.Drawing.Point(9, 43);
      this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
      this.numPort.Name = "numPort";
      this.numPort.Size = new System.Drawing.Size(120, 23);
      this.numPort.TabIndex = 96;
      // 
      // lblListenPort
      // 
      this.lblListenPort.AutoSize = true;
      this.lblListenPort.BackColor = System.Drawing.Color.Transparent;
      this.lblListenPort.Location = new System.Drawing.Point(9, 24);
      this.lblListenPort.Name = "lblListenPort";
      this.lblListenPort.Size = new System.Drawing.Size(63, 15);
      this.lblListenPort.TabIndex = 97;
      this.lblListenPort.Text = "Listen port";
      // 
      // chkKeepGameLog
      // 
      this.chkKeepGameLog.AutoSize = true;
      this.chkKeepGameLog.BackColor = System.Drawing.Color.Transparent;
      this.chkKeepGameLog.Location = new System.Drawing.Point(17, 56);
      this.chkKeepGameLog.Name = "chkKeepGameLog";
      this.chkKeepGameLog.Size = new System.Drawing.Size(105, 19);
      this.chkKeepGameLog.TabIndex = 110;
      this.chkKeepGameLog.Text = "Keep game log";
      this.chkKeepGameLog.UseVisualStyleBackColor = false;
      // 
      // OptionsView
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(332, 398);
      this.Controls.Add(this.mainTab);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.btnCancel);
      this.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "OptionsView";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "OptionsView";
      this.menuImportPictures.ResumeLayout(false);
      this.mainTab.ResumeLayout(false);
      this.pagePlayer.ResumeLayout(false);
      this.pagePlayer.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
      this.pagePictures.ResumeLayout(false);
      this.pagePictures.PerformLayout();
      this.pageLanguages.ResumeLayout(false);
      this.pageLanguages.PerformLayout();
      this.pageSystem.ResumeLayout(false);
      this.pageSystem.PerformLayout();
      this.boxNetwork.ResumeLayout(false);
      this.boxNetwork.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.OpenFileDialog openAvatarFileDialog;
    private RibbonStyle.RibbonMenuButton btnCancel;
    private RibbonStyle.RibbonMenuButton btnOk;
    private System.Windows.Forms.ContextMenuStrip menuClientLanguage;
    private System.Windows.Forms.ContextMenuStrip menuCardsLanguage;
    private System.Windows.Forms.ContextMenuStrip menuGameLanguage;
    private System.Windows.Forms.ContextMenuStrip menuImportPictures;
    private System.Windows.Forms.ToolStripMenuItem menuImportInternalPictures;
    private System.Windows.Forms.ToolStripMenuItem menuImportMwsPictures;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    private System.Windows.Forms.TabControl mainTab;
    private System.Windows.Forms.TabPage pagePlayer;
    private RibbonStyle.RibbonMenuButton btnRemovePicture;
    private RibbonStyle.RibbonMenuButton btnChangePicture;
    private System.Windows.Forms.TextBox txtMessage;
    private System.Windows.Forms.PictureBox picAvatar;
    private System.Windows.Forms.TextBox txtNickname;
    private System.Windows.Forms.TabPage pageSystem;
    private System.Windows.Forms.TabPage pagePictures;
    private RibbonStyle.RibbonMenuButton btnBrowsePicturesPath;
    private System.Windows.Forms.Label lblPicturesPath;
    private System.Windows.Forms.TextBox txtCardPicturesPath;
    private System.Windows.Forms.RadioButton rbCrop;
    private System.Windows.Forms.RadioButton rbFull;
    private System.Windows.Forms.TabPage pageLanguages;
    private RibbonStyle.RibbonMenuButton btnGameLanguage;
    private RibbonStyle.RibbonMenuButton btnClientLanguage;
    private System.Windows.Forms.Label lblNickName;
    private System.Windows.Forms.Label lblMessage;
    private System.Windows.Forms.Label lblPicture;
    private System.Windows.Forms.Label lblGameLanguage;
    private System.Windows.Forms.Label lblClientLanguage;
    private System.Windows.Forms.GroupBox boxNetwork;
    private System.Windows.Forms.NumericUpDown numPort;
    private System.Windows.Forms.Label lblListenPort;
    private System.Windows.Forms.CheckBox chkAnimateHand;
    private System.Windows.Forms.CheckBox chkSetMapping;
    private System.Windows.Forms.CheckBox chkKeepGameLog;
  }
}