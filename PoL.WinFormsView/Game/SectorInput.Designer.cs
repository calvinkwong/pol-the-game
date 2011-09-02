namespace PoL.WinFormsView.Game
{
  partial class SectorInput
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
      this.panelRightTop = new System.Windows.Forms.Panel();
      this.pnlSectorList = new System.Windows.Forms.FlowLayoutPanel();
      this.btnCancel = new System.Windows.Forms.Button();
      this.mPanelMain.SuspendLayout();
      this.panelRightTop.SuspendLayout();
      this.SuspendLayout();
      // 
      // mPanelMain
      // 
      this.mPanelMain.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.darkbackground;
      this.mPanelMain.Controls.Add(this.panelRightTop);
      this.mPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mPanelMain.Location = new System.Drawing.Point(2, 2);
      this.mPanelMain.Name = "mPanelMain";
      this.mPanelMain.Size = new System.Drawing.Size(168, 407);
      this.mPanelMain.TabIndex = 7;
      // 
      // panelRightTop
      // 
      this.panelRightTop.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.background;
      this.panelRightTop.Controls.Add(this.pnlSectorList);
      this.panelRightTop.Controls.Add(this.btnCancel);
      this.panelRightTop.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelRightTop.Location = new System.Drawing.Point(0, 0);
      this.panelRightTop.Name = "panelRightTop";
      this.panelRightTop.Size = new System.Drawing.Size(168, 407);
      this.panelRightTop.TabIndex = 7;
      // 
      // pnlSectorList
      // 
      this.pnlSectorList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
      this.pnlSectorList.AutoScroll = true;
      this.pnlSectorList.BackColor = System.Drawing.Color.Transparent;
      this.pnlSectorList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.pnlSectorList.Location = new System.Drawing.Point(31, 9);
      this.pnlSectorList.Name = "pnlSectorList";
      this.pnlSectorList.Size = new System.Drawing.Size(106, 317);
      this.pnlSectorList.TabIndex = 7;
      this.pnlSectorList.WrapContents = false;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnCancel.BackColor = System.Drawing.Color.Transparent;
      this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCancel.Image = global::PoL.WinFormsView.Properties.Resources.stop;
      this.btnCancel.Location = new System.Drawing.Point(41, 350);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(86, 50);
      this.btnCancel.TabIndex = 6;
      this.btnCancel.Text = "CANCEL";
      this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnCancel.UseVisualStyleBackColor = false;
      // 
      // SectorInput
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.darkbackground;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(172, 411);
      this.Controls.Add(this.mPanelMain);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "SectorInput";
      this.Padding = new System.Windows.Forms.Padding(2);
      this.ShowInTaskbar = false;
      this.mPanelMain.ResumeLayout(false);
      this.panelRightTop.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel mPanelMain;
    private System.Windows.Forms.Panel panelRightTop;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.FlowLayoutPanel pnlSectorList;
  }
}