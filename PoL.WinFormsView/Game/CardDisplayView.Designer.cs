namespace PoL.WinFormsView.Game
{
  partial class CardDisplayView
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if(disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.pnlCards = new System.Windows.Forms.FlowLayoutPanel();
      this.SuspendLayout();
      // 
      // pnlCards
      // 
      this.pnlCards.BackColor = System.Drawing.Color.White;
      this.pnlCards.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlCards.Location = new System.Drawing.Point(0, 0);
      this.pnlCards.Name = "pnlCards";
      this.pnlCards.Size = new System.Drawing.Size(368, 233);
      this.pnlCards.TabIndex = 1;
      // 
      // CardDisplayView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(368, 233);
      this.Controls.Add(this.pnlCards);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
      this.Name = "CardDisplayView";
      this.ShowInTaskbar = false;
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.FlowLayoutPanel pnlCards;

  }
}