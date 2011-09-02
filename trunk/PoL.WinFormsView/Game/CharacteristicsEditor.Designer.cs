namespace PoL.WinFormsView.Game
{
  partial class CharacteristicsEditor
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacteristicsEditor));
      this.mPanelMain = new System.Windows.Forms.Panel();
      this.panelRightTop = new System.Windows.Forms.Panel();
      this.chkApplyNumericalIncrement = new System.Windows.Forms.CheckBox();
      this.txtText = new System.Windows.Forms.TextBox();
      this.lblText = new System.Windows.Forms.Label();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.lblTitle = new System.Windows.Forms.Label();
      this.imageList = new System.Windows.Forms.ImageList(this.components);
      this.mPanelMain.SuspendLayout();
      this.panelRightTop.SuspendLayout();
      this.SuspendLayout();
      // 
      // mPanelMain
      // 
      this.mPanelMain.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.darkbackground;
      this.mPanelMain.Controls.Add(this.panelRightTop);
      this.mPanelMain.Controls.Add(this.lblTitle);
      this.mPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mPanelMain.Location = new System.Drawing.Point(2, 2);
      this.mPanelMain.Name = "mPanelMain";
      this.mPanelMain.Size = new System.Drawing.Size(220, 130);
      this.mPanelMain.TabIndex = 7;
      // 
      // panelRightTop
      // 
      this.panelRightTop.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.background;
      this.panelRightTop.Controls.Add(this.chkApplyNumericalIncrement);
      this.panelRightTop.Controls.Add(this.txtText);
      this.panelRightTop.Controls.Add(this.lblText);
      this.panelRightTop.Controls.Add(this.btnOk);
      this.panelRightTop.Controls.Add(this.btnCancel);
      this.panelRightTop.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelRightTop.Location = new System.Drawing.Point(0, 22);
      this.panelRightTop.Name = "panelRightTop";
      this.panelRightTop.Size = new System.Drawing.Size(220, 108);
      this.panelRightTop.TabIndex = 7;
      // 
      // chkApplyNumericalIncrement
      // 
      this.chkApplyNumericalIncrement.AutoSize = true;
      this.chkApplyNumericalIncrement.BackColor = System.Drawing.Color.Transparent;
      this.chkApplyNumericalIncrement.Location = new System.Drawing.Point(21, 44);
      this.chkApplyNumericalIncrement.Name = "chkApplyNumericalIncrement";
      this.chkApplyNumericalIncrement.Size = new System.Drawing.Size(73, 17);
      this.chkApplyNumericalIncrement.TabIndex = 16;
      this.chkApplyNumericalIncrement.Text = "Increment";
      this.chkApplyNumericalIncrement.UseVisualStyleBackColor = false;
      // 
      // txtText
      // 
      this.txtText.Location = new System.Drawing.Point(77, 18);
      this.txtText.Name = "txtText";
      this.txtText.Size = new System.Drawing.Size(123, 20);
      this.txtText.TabIndex = 15;
      // 
      // lblText
      // 
      this.lblText.BackColor = System.Drawing.Color.Transparent;
      this.lblText.Location = new System.Drawing.Point(17, 21);
      this.lblText.Name = "lblText";
      this.lblText.Size = new System.Drawing.Size(54, 13);
      this.lblText.TabIndex = 14;
      this.lblText.Text = "TEXT";
      this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btnOk
      // 
      this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnOk.BackColor = System.Drawing.Color.Transparent;
      this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnOk.Location = new System.Drawing.Point(21, 73);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(86, 23);
      this.btnOk.TabIndex = 5;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = false;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnCancel.BackColor = System.Drawing.Color.Transparent;
      this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCancel.Location = new System.Drawing.Point(114, 73);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(86, 23);
      this.btnCancel.TabIndex = 6;
      this.btnCancel.Text = "CANCEL";
      this.btnCancel.UseVisualStyleBackColor = false;
      // 
      // lblTitle
      // 
      this.lblTitle.BackColor = System.Drawing.Color.Transparent;
      this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblTitle.Font = new System.Drawing.Font("Lucida Sans", 10F, System.Drawing.FontStyle.Bold);
      this.lblTitle.ForeColor = System.Drawing.Color.Ivory;
      this.lblTitle.Location = new System.Drawing.Point(0, 0);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(220, 22);
      this.lblTitle.TabIndex = 8;
      this.lblTitle.Text = "TITLE";
      this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // imageList
      // 
      this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
      this.imageList.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList.Images.SetKeyName(0, "button-blue_small.png");
      this.imageList.Images.SetKeyName(1, "button-green_small.png");
      this.imageList.Images.SetKeyName(2, "button-purple_small.png");
      this.imageList.Images.SetKeyName(3, "button-red_small.png");
      this.imageList.Images.SetKeyName(4, "button-seagreen_small.png");
      this.imageList.Images.SetKeyName(5, "button-yellow_small.png");
      // 
      // CharacteristicsEditor
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.darkbackground;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(224, 134);
      this.Controls.Add(this.mPanelMain);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "CharacteristicsEditor";
      this.Padding = new System.Windows.Forms.Padding(2);
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.mPanelMain.ResumeLayout(false);
      this.panelRightTop.ResumeLayout(false);
      this.panelRightTop.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel mPanelMain;
    private System.Windows.Forms.Panel panelRightTop;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblText;
    private System.Windows.Forms.TextBox txtText;
    private System.Windows.Forms.ImageList imageList;
    private System.Windows.Forms.CheckBox chkApplyNumericalIncrement;
  }
}