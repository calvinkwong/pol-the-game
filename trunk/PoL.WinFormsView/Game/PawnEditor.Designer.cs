namespace PoL.WinFormsView.Game
{
  partial class PawnEditor
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
      this.mPanelMain = new System.Windows.Forms.Panel();
      this.mPanelRightTop = new System.Windows.Forms.Panel();
      this.txtCharacteristics = new System.Windows.Forms.TextBox();
      this.lblCharacteristics = new System.Windows.Forms.Label();
      this.txtText = new System.Windows.Forms.TextBox();
      this.lblText = new System.Windows.Forms.Label();
      this.txtType = new System.Windows.Forms.TextBox();
      this.lblType = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.lblName = new System.Windows.Forms.Label();
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.lblTitle = new System.Windows.Forms.Label();
      this.mPanelMain.SuspendLayout();
      this.mPanelRightTop.SuspendLayout();
      this.SuspendLayout();
      // 
      // mPanelMain
      // 
      this.mPanelMain.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.darkbackground;
      this.mPanelMain.Controls.Add(this.mPanelRightTop);
      this.mPanelMain.Controls.Add(this.lblTitle);
      this.mPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mPanelMain.Location = new System.Drawing.Point(2, 2);
      this.mPanelMain.Name = "mPanelMain";
      this.mPanelMain.Size = new System.Drawing.Size(305, 218);
      this.mPanelMain.TabIndex = 7;
      // 
      // mPanelRightTop
      // 
      this.mPanelRightTop.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.background;
      this.mPanelRightTop.Controls.Add(this.txtCharacteristics);
      this.mPanelRightTop.Controls.Add(this.lblCharacteristics);
      this.mPanelRightTop.Controls.Add(this.txtText);
      this.mPanelRightTop.Controls.Add(this.lblText);
      this.mPanelRightTop.Controls.Add(this.txtType);
      this.mPanelRightTop.Controls.Add(this.lblType);
      this.mPanelRightTop.Controls.Add(this.txtName);
      this.mPanelRightTop.Controls.Add(this.lblName);
      this.mPanelRightTop.Controls.Add(this.btnOk);
      this.mPanelRightTop.Controls.Add(this.btnCancel);
      this.mPanelRightTop.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mPanelRightTop.Location = new System.Drawing.Point(0, 22);
      this.mPanelRightTop.Name = "mPanelRightTop";
      this.mPanelRightTop.Size = new System.Drawing.Size(305, 196);
      this.mPanelRightTop.TabIndex = 7;
      // 
      // txtCharacteristics
      // 
      this.txtCharacteristics.Location = new System.Drawing.Point(20, 123);
      this.txtCharacteristics.Name = "txtCharacteristics";
      this.txtCharacteristics.Size = new System.Drawing.Size(123, 20);
      this.txtCharacteristics.TabIndex = 6;
      // 
      // lblCharacteristics
      // 
      this.lblCharacteristics.BackColor = System.Drawing.Color.Transparent;
      this.lblCharacteristics.Location = new System.Drawing.Point(16, 107);
      this.lblCharacteristics.Name = "lblCharacteristics";
      this.lblCharacteristics.Size = new System.Drawing.Size(127, 13);
      this.lblCharacteristics.TabIndex = 20;
      this.lblCharacteristics.Text = "CHARACTERISTICS";
      this.lblCharacteristics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtText
      // 
      this.txtText.Location = new System.Drawing.Point(155, 28);
      this.txtText.Multiline = true;
      this.txtText.Name = "txtText";
      this.txtText.Size = new System.Drawing.Size(132, 115);
      this.txtText.TabIndex = 7;
      // 
      // lblText
      // 
      this.lblText.BackColor = System.Drawing.Color.Transparent;
      this.lblText.Location = new System.Drawing.Point(152, 12);
      this.lblText.Name = "lblText";
      this.lblText.Size = new System.Drawing.Size(54, 13);
      this.lblText.TabIndex = 18;
      this.lblText.Text = "TEXT";
      this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtType
      // 
      this.txtType.Location = new System.Drawing.Point(20, 74);
      this.txtType.Name = "txtType";
      this.txtType.Size = new System.Drawing.Size(123, 20);
      this.txtType.TabIndex = 5;
      // 
      // lblType
      // 
      this.lblType.BackColor = System.Drawing.Color.Transparent;
      this.lblType.Location = new System.Drawing.Point(17, 58);
      this.lblType.Name = "lblType";
      this.lblType.Size = new System.Drawing.Size(54, 13);
      this.lblType.TabIndex = 16;
      this.lblType.Text = "TYPE";
      this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(20, 28);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(123, 20);
      this.txtName.TabIndex = 4;
      // 
      // lblName
      // 
      this.lblName.BackColor = System.Drawing.Color.Transparent;
      this.lblName.Location = new System.Drawing.Point(17, 12);
      this.lblName.Name = "lblName";
      this.lblName.Size = new System.Drawing.Size(54, 13);
      this.lblName.TabIndex = 14;
      this.lblName.Text = "NAME";
      this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btnOk
      // 
      this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnOk.BackColor = System.Drawing.Color.Transparent;
      this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnOk.Location = new System.Drawing.Point(63, 160);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(86, 23);
      this.btnOk.TabIndex = 20;
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
      this.btnCancel.Location = new System.Drawing.Point(155, 160);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(86, 23);
      this.btnCancel.TabIndex = 21;
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
      this.lblTitle.Size = new System.Drawing.Size(305, 22);
      this.lblTitle.TabIndex = 8;
      this.lblTitle.Text = "TITLE";
      this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // PawnEditor
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.darkbackground;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(309, 222);
      this.Controls.Add(this.mPanelMain);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "PawnEditor";
      this.Padding = new System.Windows.Forms.Padding(2);
      this.ShowInTaskbar = false;
      this.mPanelMain.ResumeLayout(false);
      this.mPanelRightTop.ResumeLayout(false);
      this.mPanelRightTop.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel mPanelMain;
    private System.Windows.Forms.Panel mPanelRightTop;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label lblText;
    private System.Windows.Forms.TextBox txtType;
    private System.Windows.Forms.Label lblType;
    private System.Windows.Forms.TextBox txtText;
    private System.Windows.Forms.TextBox txtCharacteristics;
    private System.Windows.Forms.Label lblCharacteristics;
  }
}