namespace PoL.WinFormsView.Game
{
  partial class NumCounterView
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
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.picNumCounter = new System.Windows.Forms.PictureBox();
      this.lblValue = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.picNumCounter)).BeginInit();
      this.SuspendLayout();
      // 
      // picNumCounter
      // 
      this.picNumCounter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.picNumCounter.Dock = System.Windows.Forms.DockStyle.Left;
      this.picNumCounter.Location = new System.Drawing.Point(0, 0);
      this.picNumCounter.Name = "picNumCounter";
      this.picNumCounter.Size = new System.Drawing.Size(16, 16);
      this.picNumCounter.TabIndex = 6;
      this.picNumCounter.TabStop = false;
      // 
      // lblValue
      // 
      this.lblValue.BackColor = System.Drawing.Color.Transparent;
      this.lblValue.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
      this.lblValue.ForeColor = System.Drawing.Color.White;
      this.lblValue.Location = new System.Drawing.Point(16, 0);
      this.lblValue.Name = "lblValue";
      this.lblValue.Size = new System.Drawing.Size(24, 16);
      this.lblValue.TabIndex = 5;
      this.lblValue.Text = "99";
      this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // NumCounterView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Transparent;
      this.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.darkbackground;
      this.Controls.Add(this.lblValue);
      this.Controls.Add(this.picNumCounter);
      this.Margin = new System.Windows.Forms.Padding(0);
      this.Name = "NumCounterView";
      this.Size = new System.Drawing.Size(40, 16);
      ((System.ComponentModel.ISupportInitialize)(this.picNumCounter)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.PictureBox picNumCounter;
    private System.Windows.Forms.Label lblValue;

  }
}
