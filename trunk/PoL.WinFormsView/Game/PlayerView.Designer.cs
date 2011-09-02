namespace PoL.WinFormsView.Game
{
  partial class PlayerView
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
      this.pnlRight = new System.Windows.Forms.Panel();
      this.handView = new PoL.WinFormsView.Game.CollapsableFlowSectorView();
      this.playView = new PoL.WinFormsView.Game.StaticFreeSectorView();
      this.pnlRight.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlRight
      // 
      this.pnlRight.Controls.Add(this.handView);
      this.pnlRight.Controls.Add(this.playView);
      this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlRight.Location = new System.Drawing.Point(0, 0);
      this.pnlRight.Name = "pnlRight";
      this.pnlRight.Size = new System.Drawing.Size(532, 420);
      this.pnlRight.TabIndex = 3;
      // 
      // handView
      // 
      this.handView.AllowDrop = true;
      this.handView.Animate = false;
      this.handView.AnimationDirection = PoL.WinFormsView.Utils.AnimationDirection.Vertical;
      this.handView.BackColor = System.Drawing.SystemColors.Control;
      this.handView.CollapsedSize = 60;
      this.handView.CollapsedState = PoL.WinFormsView.Utils.CollapsedState.Collapsed;
      this.handView.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.handView.FullExpandedSize = 131;
      this.handView.Location = new System.Drawing.Point(0, 360);
      this.handView.Name = "handView";
      this.handView.Size = new System.Drawing.Size(532, 60);
      this.handView.TabIndex = 4;
      // 
      // playView
      // 
      this.playView.AllowDrop = true;
      this.playView.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.background;
      this.playView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.playView.Location = new System.Drawing.Point(0, 0);
      this.playView.Name = "playView";
      this.playView.Size = new System.Drawing.Size(532, 420);
      this.playView.TabIndex = 3;
      // 
      // PlayerView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.pnlRight);
      this.Name = "PlayerView";
      this.Size = new System.Drawing.Size(532, 420);
      this.pnlRight.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlRight;
    private StaticFreeSectorView playView;
    private CollapsableFlowSectorView handView;
  }
}
