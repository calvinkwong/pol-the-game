namespace PoL.WinFormsView.DeckRoom
{
  partial class ExportParametersView
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
      this.pnlSearchParameters = new System.Windows.Forms.Panel();
      this.btnOk = new RibbonStyle.RibbonMenuButton();
      this.btnCancel = new RibbonStyle.RibbonMenuButton();
      this.panel1 = new System.Windows.Forms.Panel();
      this.chkNoTag = new System.Windows.Forms.CheckBox();
      this.btnLanguage = new RibbonStyle.RibbonMenuButton();
      this.menuCardsLanguage = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.lblLanguage = new System.Windows.Forms.Label();
      this.boxDestination = new System.Windows.Forms.GroupBox();
      this.rbClipboard = new System.Windows.Forms.RadioButton();
      this.rbFile = new System.Windows.Forms.RadioButton();
      this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.pnlSearchParameters.SuspendLayout();
      this.panel1.SuspendLayout();
      this.boxDestination.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlSearchParameters
      // 
      this.pnlSearchParameters.BackColor = System.Drawing.Color.White;
      this.pnlSearchParameters.Controls.Add(this.btnOk);
      this.pnlSearchParameters.Controls.Add(this.btnCancel);
      this.pnlSearchParameters.Controls.Add(this.panel1);
      this.pnlSearchParameters.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlSearchParameters.Location = new System.Drawing.Point(0, 0);
      this.pnlSearchParameters.Name = "pnlSearchParameters";
      this.pnlSearchParameters.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
      this.pnlSearchParameters.Size = new System.Drawing.Size(259, 254);
      this.pnlSearchParameters.TabIndex = 35;
      // 
      // btnOk
      // 
      this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
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
      this.btnOk.Location = new System.Drawing.Point(6, 206);
      this.btnOk.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnOk.MenuPos = new System.Drawing.Point(0, 0);
      this.btnOk.Name = "btnOk";
      this.btnOk.Radius = 10;
      this.btnOk.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnOk.Size = new System.Drawing.Size(120, 41);
      this.btnOk.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnOk.SplitDistance = 30;
      this.btnOk.TabIndex = 86;
      this.btnOk.Text = "Ok";
      this.btnOk.Title = "";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnCancel.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
      this.btnCancel.BackColor = System.Drawing.Color.Transparent;
      this.btnCancel.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnCancel.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))), ((int)(((byte)(76)))));
      this.btnCancel.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnCancel.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnCancel.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnCancel.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
      this.btnCancel.Location = new System.Drawing.Point(132, 206);
      this.btnCancel.MaxImageSize = new System.Drawing.Point(24, 24);
      this.btnCancel.MenuPos = new System.Drawing.Point(0, 0);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Radius = 10;
      this.btnCancel.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnCancel.Size = new System.Drawing.Size(120, 41);
      this.btnCancel.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnCancel.SplitDistance = 30;
      this.btnCancel.TabIndex = 87;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.Title = "";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.sfondoblu;
      this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.panel1.Controls.Add(this.chkNoTag);
      this.panel1.Controls.Add(this.btnLanguage);
      this.panel1.Controls.Add(this.lblLanguage);
      this.panel1.Controls.Add(this.boxDestination);
      this.panel1.Location = new System.Drawing.Point(6, 8);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(246, 192);
      this.panel1.TabIndex = 85;
      // 
      // chkNoTag
      // 
      this.chkNoTag.AutoSize = true;
      this.chkNoTag.BackColor = System.Drawing.Color.Transparent;
      this.chkNoTag.Location = new System.Drawing.Point(21, 149);
      this.chkNoTag.Name = "chkNoTag";
      this.chkNoTag.Size = new System.Drawing.Size(98, 17);
      this.chkNoTag.TabIndex = 116;
      this.chkNoTag.Text = "Not include tag";
      this.chkNoTag.UseVisualStyleBackColor = false;
      // 
      // btnLanguage
      // 
      this.btnLanguage.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.ToDown;
      this.btnLanguage.BackColor = System.Drawing.Color.Transparent;
      this.btnLanguage.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
      this.btnLanguage.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
      this.btnLanguage.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
      this.btnLanguage.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
      this.btnLanguage.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
      this.btnLanguage.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.btnLanguage.ContextMenuStrip = this.menuCardsLanguage;
      this.btnLanguage.FadingSpeed = 20;
      this.btnLanguage.FlatAppearance.BorderSize = 0;
      this.btnLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnLanguage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnLanguage.ForeColor = System.Drawing.Color.DarkBlue;
      this.btnLanguage.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
      this.btnLanguage.Image = global::PoL.WinFormsView.Properties.Resources.emblem_web;
      this.btnLanguage.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Left;
      this.btnLanguage.ImageOffset = 2;
      this.btnLanguage.IsPressed = false;
      this.btnLanguage.KeepPress = false;
      this.btnLanguage.Location = new System.Drawing.Point(21, 33);
      this.btnLanguage.MaxImageSize = new System.Drawing.Point(0, 0);
      this.btnLanguage.MenuPos = new System.Drawing.Point(0, 10);
      this.btnLanguage.Name = "btnLanguage";
      this.btnLanguage.Radius = 4;
      this.btnLanguage.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
      this.btnLanguage.Size = new System.Drawing.Size(139, 24);
      this.btnLanguage.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
      this.btnLanguage.SplitDistance = 14;
      this.btnLanguage.TabIndex = 114;
      this.btnLanguage.Title = "";
      this.btnLanguage.UseVisualStyleBackColor = true;
      // 
      // menuCardsLanguage
      // 
      this.menuCardsLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
      this.menuCardsLanguage.DropShadowEnabled = false;
      this.menuCardsLanguage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.menuCardsLanguage.Name = "Paste";
      this.menuCardsLanguage.Size = new System.Drawing.Size(61, 4);
      // 
      // lblLanguage
      // 
      this.lblLanguage.AutoSize = true;
      this.lblLanguage.BackColor = System.Drawing.Color.Transparent;
      this.lblLanguage.Location = new System.Drawing.Point(18, 17);
      this.lblLanguage.Name = "lblLanguage";
      this.lblLanguage.Size = new System.Drawing.Size(81, 13);
      this.lblLanguage.TabIndex = 115;
      this.lblLanguage.Text = "Cards language";
      // 
      // boxDestination
      // 
      this.boxDestination.BackColor = System.Drawing.Color.Transparent;
      this.boxDestination.Controls.Add(this.rbClipboard);
      this.boxDestination.Controls.Add(this.rbFile);
      this.boxDestination.Location = new System.Drawing.Point(17, 63);
      this.boxDestination.Name = "boxDestination";
      this.boxDestination.Size = new System.Drawing.Size(143, 79);
      this.boxDestination.TabIndex = 113;
      this.boxDestination.TabStop = false;
      this.boxDestination.Text = "Destination";
      // 
      // rbClipboard
      // 
      this.rbClipboard.AutoSize = true;
      this.rbClipboard.BackColor = System.Drawing.Color.Transparent;
      this.rbClipboard.Location = new System.Drawing.Point(11, 45);
      this.rbClipboard.Name = "rbClipboard";
      this.rbClipboard.Size = new System.Drawing.Size(69, 17);
      this.rbClipboard.TabIndex = 111;
      this.rbClipboard.Text = "Clipboard";
      this.rbClipboard.UseVisualStyleBackColor = false;
      // 
      // rbFile
      // 
      this.rbFile.AutoSize = true;
      this.rbFile.BackColor = System.Drawing.Color.Transparent;
      this.rbFile.Checked = true;
      this.rbFile.Location = new System.Drawing.Point(11, 27);
      this.rbFile.Name = "rbFile";
      this.rbFile.Size = new System.Drawing.Size(41, 17);
      this.rbFile.TabIndex = 112;
      this.rbFile.TabStop = true;
      this.rbFile.Text = "File";
      this.rbFile.UseVisualStyleBackColor = false;
      // 
      // ExportParametersView
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(259, 254);
      this.Controls.Add(this.pnlSearchParameters);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "ExportParametersView";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Export deck";
      this.pnlSearchParameters.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.boxDestination.ResumeLayout(false);
      this.boxDestination.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlSearchParameters;
    private System.Windows.Forms.Panel panel1;
    private RibbonStyle.RibbonMenuButton btnOk;
    private RibbonStyle.RibbonMenuButton btnCancel;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
    private RibbonStyle.RibbonMenuButton btnLanguage;
    private System.Windows.Forms.Label lblLanguage;
    private System.Windows.Forms.ContextMenuStrip menuCardsLanguage;
    private System.Windows.Forms.GroupBox boxDestination;
    private System.Windows.Forms.RadioButton rbClipboard;
    private System.Windows.Forms.RadioButton rbFile;
    private System.Windows.Forms.CheckBox chkNoTag;
  }
}