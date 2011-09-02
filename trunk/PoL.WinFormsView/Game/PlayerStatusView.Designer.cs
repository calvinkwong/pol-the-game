namespace PoL.WinFormsView.Game
{
  partial class PlayerStatusView
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

    #region Codice generato da Progettazione componenti

    /// <summary> 
    /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
    /// il contenuto del metodo con l'editor di codice.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.simpleSectorsContainer = new System.Windows.Forms.FlowLayoutPanel();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.panel1 = new System.Windows.Forms.Panel();
      this.numCountersContainer = new System.Windows.Forms.FlowLayoutPanel();
      this.picAvatar = new System.Windows.Forms.PictureBox();
      this.lblPlayerName = new System.Windows.Forms.Label();
      this.pnlPoints = new System.Windows.Forms.Panel();
      this.lblPoints = new System.Windows.Forms.Label();
      this.picSetLifePoints = new System.Windows.Forms.PictureBox();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
      this.pnlPoints.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picSetLifePoints)).BeginInit();
      this.SuspendLayout();
      // 
      // simpleSectorsContainer
      // 
      this.simpleSectorsContainer.AutoScroll = true;
      this.simpleSectorsContainer.BackColor = System.Drawing.Color.Transparent;
      this.simpleSectorsContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.simpleSectorsContainer.Location = new System.Drawing.Point(52, 45);
      this.simpleSectorsContainer.Name = "simpleSectorsContainer";
      this.simpleSectorsContainer.Size = new System.Drawing.Size(61, 104);
      this.simpleSectorsContainer.TabIndex = 12;
      this.simpleSectorsContainer.WrapContents = false;
      // 
      // toolTip
      // 
      this.toolTip.IsBalloon = true;
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.Transparent;
      this.panel1.Controls.Add(this.numCountersContainer);
      this.panel1.Controls.Add(this.picAvatar);
      this.panel1.Location = new System.Drawing.Point(3, 14);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(47, 135);
      this.panel1.TabIndex = 14;
      // 
      // numCountersContainer
      // 
      this.numCountersContainer.AutoScroll = true;
      this.numCountersContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.numCountersContainer.Location = new System.Drawing.Point(2, 38);
      this.numCountersContainer.Name = "numCountersContainer";
      this.numCountersContainer.Size = new System.Drawing.Size(42, 96);
      this.numCountersContainer.TabIndex = 14;
      this.numCountersContainer.WrapContents = false;
      // 
      // picAvatar
      // 
      this.picAvatar.BackColor = System.Drawing.Color.Transparent;
      this.picAvatar.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.pol;
      this.picAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.picAvatar.Location = new System.Drawing.Point(3, 1);
      this.picAvatar.Name = "picAvatar";
      this.picAvatar.Size = new System.Drawing.Size(36, 36);
      this.picAvatar.TabIndex = 12;
      this.picAvatar.TabStop = false;
      // 
      // lblPlayerName
      // 
      this.lblPlayerName.AutoEllipsis = true;
      this.lblPlayerName.BackColor = System.Drawing.Color.Transparent;
      this.lblPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblPlayerName.ForeColor = System.Drawing.Color.White;
      this.lblPlayerName.Location = new System.Drawing.Point(0, 0);
      this.lblPlayerName.Name = "lblPlayerName";
      this.lblPlayerName.Size = new System.Drawing.Size(112, 14);
      this.lblPlayerName.TabIndex = 15;
      this.lblPlayerName.Text = "label1";
      this.lblPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pnlPoints
      // 
      this.pnlPoints.BackColor = System.Drawing.Color.Transparent;
      this.pnlPoints.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.redbanner;
      this.pnlPoints.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pnlPoints.Controls.Add(this.picSetLifePoints);
      this.pnlPoints.Controls.Add(this.lblPoints);
      this.pnlPoints.Location = new System.Drawing.Point(50, 19);
      this.pnlPoints.Name = "pnlPoints";
      this.pnlPoints.Size = new System.Drawing.Size(61, 24);
      this.pnlPoints.TabIndex = 16;
      // 
      // lblPoints
      // 
      this.lblPoints.BackColor = System.Drawing.Color.Transparent;
      this.lblPoints.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblPoints.ForeColor = System.Drawing.Color.White;
      this.lblPoints.Location = new System.Drawing.Point(0, 0);
      this.lblPoints.Name = "lblPoints";
      this.lblPoints.Size = new System.Drawing.Size(61, 24);
      this.lblPoints.TabIndex = 4;
      this.lblPoints.Text = "999";
      this.lblPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // picSetLifePoints
      // 
      this.picSetLifePoints.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.stock_smiley_1___copy;
      this.picSetLifePoints.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.picSetLifePoints.Location = new System.Drawing.Point(47, 11);
      this.picSetLifePoints.Name = "picSetLifePoints";
      this.picSetLifePoints.Size = new System.Drawing.Size(12, 12);
      this.picSetLifePoints.TabIndex = 5;
      this.picSetLifePoints.TabStop = false;
      // 
      // PlayerStatusView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.background2;
      this.Controls.Add(this.pnlPoints);
      this.Controls.Add(this.lblPlayerName);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.simpleSectorsContainer);
      this.Name = "PlayerStatusView";
      this.Size = new System.Drawing.Size(115, 150);
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
      this.pnlPoints.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.picSetLifePoints)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.FlowLayoutPanel simpleSectorsContainer;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.PictureBox picAvatar;
    private System.Windows.Forms.Label lblPlayerName;
    private System.Windows.Forms.FlowLayoutPanel numCountersContainer;
    private System.Windows.Forms.Panel pnlPoints;
    private System.Windows.Forms.Label lblPoints;
    private System.Windows.Forms.PictureBox picSetLifePoints;
  }
}
