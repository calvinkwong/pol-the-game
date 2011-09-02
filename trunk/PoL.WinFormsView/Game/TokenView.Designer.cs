namespace PoL.WinFormsView.Game
{
  partial class TokenView
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
      this.lblAmount = new System.Windows.Forms.Label();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.SuspendLayout();
      // 
      // lblAmount
      // 
      this.lblAmount.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblAmount.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblAmount.ForeColor = System.Drawing.SystemColors.ControlText;
      this.lblAmount.Location = new System.Drawing.Point(0, 0);
      this.lblAmount.Name = "lblAmount";
      this.lblAmount.Size = new System.Drawing.Size(22, 16);
      this.lblAmount.TabIndex = 0;
      this.lblAmount.Text = "999";
      this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // toolTip
      // 
      this.toolTip.IsBalloon = true;
      // 
      // TokenView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Transparent;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.Controls.Add(this.lblAmount);
      this.Margin = new System.Windows.Forms.Padding(0);
      this.Name = "TokenView";
      this.Size = new System.Drawing.Size(22, 16);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblAmount;
    private System.Windows.Forms.ToolTip toolTip;
  }
}
