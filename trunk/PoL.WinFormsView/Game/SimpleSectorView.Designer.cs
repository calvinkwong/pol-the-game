namespace PoL.WinFormsView.Game
{
  partial class SimpleSectorView
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.pnlCounter = new System.Windows.Forms.Panel();
      this.lblCounter = new System.Windows.Forms.Label();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.picSector = new System.Windows.Forms.PictureBox();
      this.pnlCounter.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picSector)).BeginInit();
      this.SuspendLayout();
      // 
      // pnlCounter
      // 
      this.pnlCounter.BackColor = System.Drawing.Color.Transparent;
      this.pnlCounter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pnlCounter.Controls.Add(this.lblCounter);
      this.pnlCounter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlCounter.Location = new System.Drawing.Point(24, 0);
      this.pnlCounter.Name = "pnlCounter";
      this.pnlCounter.Size = new System.Drawing.Size(34, 24);
      this.pnlCounter.TabIndex = 2;
      // 
      // lblCounter
      // 
      this.lblCounter.BackColor = System.Drawing.Color.Transparent;
      this.lblCounter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
      this.lblCounter.ForeColor = System.Drawing.Color.White;
      this.lblCounter.Location = new System.Drawing.Point(0, 0);
      this.lblCounter.Name = "lblCounter";
      this.lblCounter.Size = new System.Drawing.Size(34, 24);
      this.lblCounter.TabIndex = 2;
      this.lblCounter.Text = "999";
      this.lblCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // picSector
      // 
      this.picSector.Dock = System.Windows.Forms.DockStyle.Left;
      this.picSector.Location = new System.Drawing.Point(0, 0);
      this.picSector.Name = "picSector";
      this.picSector.Size = new System.Drawing.Size(24, 24);
      this.picSector.TabIndex = 4;
      this.picSector.TabStop = false;
      // 
      // SimpleSectorView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Transparent;
      this.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.darkbackground;
      this.Controls.Add(this.pnlCounter);
      this.Controls.Add(this.picSector);
      this.DoubleBuffered = true;
      this.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
      this.Name = "SimpleSectorView";
      this.Size = new System.Drawing.Size(58, 24);
      this.pnlCounter.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.picSector)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlCounter;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.Label lblCounter;
    private System.Windows.Forms.PictureBox picSector;
  }
}
