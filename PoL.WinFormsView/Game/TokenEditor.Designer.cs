namespace PoL.WinFormsView.Game
{
  partial class TokenEditor
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TokenEditor));
      this.mPanelMain = new System.Windows.Forms.Panel();
      this.panelRightTop = new System.Windows.Forms.Panel();
      this.lblColor = new System.Windows.Forms.Label();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.picRed = new System.Windows.Forms.PictureBox();
      this.pictureBox4 = new System.Windows.Forms.PictureBox();
      this.rbAzure = new System.Windows.Forms.RadioButton();
      this.pictureBox6 = new System.Windows.Forms.PictureBox();
      this.pictureBox5 = new System.Windows.Forms.PictureBox();
      this.rbYellow = new System.Windows.Forms.RadioButton();
      this.rbRed = new System.Windows.Forms.RadioButton();
      this.rbPurple = new System.Windows.Forms.RadioButton();
      this.rbBlue = new System.Windows.Forms.RadioButton();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.rbGreen = new System.Windows.Forms.RadioButton();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.numAmount = new System.Windows.Forms.NumericUpDown();
      this.lblAmount = new System.Windows.Forms.Label();
      this.txtText = new System.Windows.Forms.TextBox();
      this.lblText = new System.Windows.Forms.Label();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.lblTitle = new System.Windows.Forms.Label();
      this.imageList = new System.Windows.Forms.ImageList(this.components);
      this.mPanelMain.SuspendLayout();
      this.panelRightTop.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picRed)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
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
      this.mPanelMain.Size = new System.Drawing.Size(220, 186);
      this.mPanelMain.TabIndex = 7;
      // 
      // panelRightTop
      // 
      this.panelRightTop.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.background;
      this.panelRightTop.Controls.Add(this.lblColor);
      this.panelRightTop.Controls.Add(this.tableLayoutPanel1);
      this.panelRightTop.Controls.Add(this.numAmount);
      this.panelRightTop.Controls.Add(this.lblAmount);
      this.panelRightTop.Controls.Add(this.txtText);
      this.panelRightTop.Controls.Add(this.lblText);
      this.panelRightTop.Controls.Add(this.btnOk);
      this.panelRightTop.Controls.Add(this.btnCancel);
      this.panelRightTop.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelRightTop.Location = new System.Drawing.Point(0, 22);
      this.panelRightTop.Name = "panelRightTop";
      this.panelRightTop.Size = new System.Drawing.Size(220, 164);
      this.panelRightTop.TabIndex = 7;
      // 
      // lblColor
      // 
      this.lblColor.BackColor = System.Drawing.Color.Transparent;
      this.lblColor.Location = new System.Drawing.Point(18, 62);
      this.lblColor.Name = "lblColor";
      this.lblColor.Size = new System.Drawing.Size(54, 13);
      this.lblColor.TabIndex = 32;
      this.lblColor.Text = "COLOR";
      this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
      this.tableLayoutPanel1.ColumnCount = 6;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel1.Controls.Add(this.picRed, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.pictureBox4, 5, 1);
      this.tableLayoutPanel1.Controls.Add(this.rbAzure, 4, 1);
      this.tableLayoutPanel1.Controls.Add(this.pictureBox6, 3, 1);
      this.tableLayoutPanel1.Controls.Add(this.pictureBox5, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.rbYellow, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.rbRed, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.rbPurple, 2, 1);
      this.tableLayoutPanel1.Controls.Add(this.rbBlue, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 3, 0);
      this.tableLayoutPanel1.Controls.Add(this.rbGreen, 4, 0);
      this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 5, 0);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(21, 78);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(179, 44);
      this.tableLayoutPanel1.TabIndex = 31;
      // 
      // picRed
      // 
      this.picRed.BackColor = System.Drawing.Color.Transparent;
      this.picRed.Image = global::PoL.WinFormsView.Properties.Resources.button_red_small;
      this.picRed.Location = new System.Drawing.Point(26, 3);
      this.picRed.Name = "picRed";
      this.picRed.Size = new System.Drawing.Size(16, 16);
      this.picRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.picRed.TabIndex = 18;
      this.picRed.TabStop = false;
      // 
      // pictureBox4
      // 
      this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox4.Image = global::PoL.WinFormsView.Properties.Resources.button_seagreen_small;
      this.pictureBox4.Location = new System.Drawing.Point(142, 25);
      this.pictureBox4.Name = "pictureBox4";
      this.pictureBox4.Size = new System.Drawing.Size(16, 16);
      this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox4.TabIndex = 26;
      this.pictureBox4.TabStop = false;
      // 
      // rbAzure
      // 
      this.rbAzure.AutoSize = true;
      this.rbAzure.BackColor = System.Drawing.Color.Transparent;
      this.rbAzure.Location = new System.Drawing.Point(119, 25);
      this.rbAzure.Name = "rbAzure";
      this.rbAzure.Size = new System.Drawing.Size(14, 13);
      this.rbAzure.TabIndex = 27;
      this.rbAzure.TabStop = true;
      this.rbAzure.UseVisualStyleBackColor = false;
      // 
      // pictureBox6
      // 
      this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox6.Image = global::PoL.WinFormsView.Properties.Resources.button_purple_small;
      this.pictureBox6.Location = new System.Drawing.Point(84, 25);
      this.pictureBox6.Name = "pictureBox6";
      this.pictureBox6.Size = new System.Drawing.Size(16, 16);
      this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox6.TabIndex = 28;
      this.pictureBox6.TabStop = false;
      // 
      // pictureBox5
      // 
      this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox5.Image = global::PoL.WinFormsView.Properties.Resources.button_yellow_small;
      this.pictureBox5.Location = new System.Drawing.Point(26, 25);
      this.pictureBox5.Name = "pictureBox5";
      this.pictureBox5.Size = new System.Drawing.Size(16, 16);
      this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox5.TabIndex = 29;
      this.pictureBox5.TabStop = false;
      // 
      // rbYellow
      // 
      this.rbYellow.AutoSize = true;
      this.rbYellow.BackColor = System.Drawing.Color.Transparent;
      this.rbYellow.Location = new System.Drawing.Point(3, 25);
      this.rbYellow.Name = "rbYellow";
      this.rbYellow.Size = new System.Drawing.Size(14, 13);
      this.rbYellow.TabIndex = 30;
      this.rbYellow.TabStop = true;
      this.rbYellow.UseVisualStyleBackColor = false;
      // 
      // rbRed
      // 
      this.rbRed.AutoSize = true;
      this.rbRed.BackColor = System.Drawing.Color.Transparent;
      this.rbRed.Location = new System.Drawing.Point(3, 3);
      this.rbRed.Name = "rbRed";
      this.rbRed.Size = new System.Drawing.Size(14, 13);
      this.rbRed.TabIndex = 19;
      this.rbRed.TabStop = true;
      this.rbRed.UseVisualStyleBackColor = false;
      // 
      // rbPurple
      // 
      this.rbPurple.AutoSize = true;
      this.rbPurple.BackColor = System.Drawing.Color.Transparent;
      this.rbPurple.Location = new System.Drawing.Point(61, 25);
      this.rbPurple.Name = "rbPurple";
      this.rbPurple.Size = new System.Drawing.Size(14, 13);
      this.rbPurple.TabIndex = 25;
      this.rbPurple.TabStop = true;
      this.rbPurple.UseVisualStyleBackColor = false;
      // 
      // rbBlue
      // 
      this.rbBlue.AutoSize = true;
      this.rbBlue.BackColor = System.Drawing.Color.Transparent;
      this.rbBlue.Location = new System.Drawing.Point(61, 3);
      this.rbBlue.Name = "rbBlue";
      this.rbBlue.Size = new System.Drawing.Size(14, 13);
      this.rbBlue.TabIndex = 21;
      this.rbBlue.TabStop = true;
      this.rbBlue.UseVisualStyleBackColor = false;
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox1.Image = global::PoL.WinFormsView.Properties.Resources.button_blue_small;
      this.pictureBox1.Location = new System.Drawing.Point(84, 3);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(16, 16);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 20;
      this.pictureBox1.TabStop = false;
      // 
      // rbGreen
      // 
      this.rbGreen.AutoSize = true;
      this.rbGreen.BackColor = System.Drawing.Color.Transparent;
      this.rbGreen.Location = new System.Drawing.Point(119, 3);
      this.rbGreen.Name = "rbGreen";
      this.rbGreen.Size = new System.Drawing.Size(14, 13);
      this.rbGreen.TabIndex = 23;
      this.rbGreen.TabStop = true;
      this.rbGreen.UseVisualStyleBackColor = false;
      // 
      // pictureBox2
      // 
      this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox2.Image = global::PoL.WinFormsView.Properties.Resources.button_green_small;
      this.pictureBox2.Location = new System.Drawing.Point(142, 3);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(16, 16);
      this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox2.TabIndex = 22;
      this.pictureBox2.TabStop = false;
      // 
      // numAmount
      // 
      this.numAmount.Location = new System.Drawing.Point(77, 7);
      this.numAmount.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
      this.numAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numAmount.Name = "numAmount";
      this.numAmount.Size = new System.Drawing.Size(44, 20);
      this.numAmount.TabIndex = 17;
      this.numAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // lblAmount
      // 
      this.lblAmount.BackColor = System.Drawing.Color.Transparent;
      this.lblAmount.Location = new System.Drawing.Point(17, 9);
      this.lblAmount.Name = "lblAmount";
      this.lblAmount.Size = new System.Drawing.Size(54, 13);
      this.lblAmount.TabIndex = 16;
      this.lblAmount.Text = "AMOUNT";
      this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtText
      // 
      this.txtText.Location = new System.Drawing.Point(77, 33);
      this.txtText.Name = "txtText";
      this.txtText.Size = new System.Drawing.Size(123, 20);
      this.txtText.TabIndex = 15;
      // 
      // lblText
      // 
      this.lblText.BackColor = System.Drawing.Color.Transparent;
      this.lblText.Location = new System.Drawing.Point(17, 36);
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
      this.btnOk.Location = new System.Drawing.Point(21, 133);
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
      this.btnCancel.Location = new System.Drawing.Point(113, 133);
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
      // TokenEditor
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.darkbackground;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(224, 190);
      this.Controls.Add(this.mPanelMain);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "TokenEditor";
      this.Padding = new System.Windows.Forms.Padding(2);
      this.ShowInTaskbar = false;
      this.mPanelMain.ResumeLayout(false);
      this.panelRightTop.ResumeLayout(false);
      this.panelRightTop.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picRed)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
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
    private System.Windows.Forms.Label lblAmount;
    private System.Windows.Forms.NumericUpDown numAmount;
    private System.Windows.Forms.PictureBox picRed;
    private System.Windows.Forms.ImageList imageList;
    private System.Windows.Forms.RadioButton rbRed;
    private System.Windows.Forms.RadioButton rbYellow;
    private System.Windows.Forms.PictureBox pictureBox5;
    private System.Windows.Forms.PictureBox pictureBox6;
    private System.Windows.Forms.RadioButton rbAzure;
    private System.Windows.Forms.PictureBox pictureBox4;
    private System.Windows.Forms.RadioButton rbPurple;
    private System.Windows.Forms.RadioButton rbGreen;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.RadioButton rbBlue;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label lblColor;
  }
}