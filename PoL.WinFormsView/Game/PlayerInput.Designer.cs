namespace PoL.WinFormsView.Game
{
  partial class PlayerInput
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
      this.btnCancel = new System.Windows.Forms.Button();
      this.pnlPlayerList = new System.Windows.Forms.FlowLayoutPanel();
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
      this.mPanelMain.Size = new System.Drawing.Size(168, 294);
      this.mPanelMain.TabIndex = 7;
      // 
      // panelRightTop
      // 
      this.panelRightTop.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.background;
      this.panelRightTop.Controls.Add(this.pnlPlayerList);
      this.panelRightTop.Controls.Add(this.btnCancel);
      this.panelRightTop.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelRightTop.Location = new System.Drawing.Point(0, 0);
      this.panelRightTop.Name = "panelRightTop";
      this.panelRightTop.Size = new System.Drawing.Size(168, 294);
      this.panelRightTop.TabIndex = 7;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnCancel.BackColor = System.Drawing.Color.Transparent;
      this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCancel.Image = global::PoL.WinFormsView.Properties.Resources.stop;
      this.btnCancel.Location = new System.Drawing.Point(41, 237);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(86, 50);
      this.btnCancel.TabIndex = 7;
      this.btnCancel.Text = "CANCEL";
      this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnCancel.UseVisualStyleBackColor = false;
      // 
      // pnlPlayerList
      // 
      this.pnlPlayerList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
      this.pnlPlayerList.AutoScroll = true;
      this.pnlPlayerList.BackColor = System.Drawing.Color.Transparent;
      this.pnlPlayerList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.pnlPlayerList.Location = new System.Drawing.Point(30, 9);
      this.pnlPlayerList.Name = "pnlPlayerList";
      this.pnlPlayerList.Size = new System.Drawing.Size(108, 210);
      this.pnlPlayerList.TabIndex = 8;
      this.pnlPlayerList.WrapContents = false;
      // 
      // PlayerInput
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.darkbackground;
      this.ClientSize = new System.Drawing.Size(172, 298);
      this.Controls.Add(this.mPanelMain);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "PlayerInput";
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
    private System.Windows.Forms.FlowLayoutPanel pnlPlayerList;
  }
}