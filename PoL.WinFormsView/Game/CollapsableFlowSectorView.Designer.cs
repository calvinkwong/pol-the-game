namespace PoL.WinFormsView.Game
{
  partial class CollapsableFlowSectorView
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
      this.pnl = new System.Windows.Forms.FlowLayoutPanel();
      this.SuspendLayout();
      // 
      // pnl
      // 
      this.pnl.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.panelbg;
      this.pnl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnl.Location = new System.Drawing.Point(0, 0);
      this.pnl.Name = "pnl";
      this.pnl.Size = new System.Drawing.Size(452, 90);
      this.pnl.TabIndex = 0;
      // 
      // CollapsableFlowSectorView
      // 
      this.AllowDrop = true;
      this.AnimationDirection = PoL.WinFormsView.Utils.AnimationDirection.Vertical;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.pnl);
      this.Name = "CollapsableFlowSectorView";
      this.Size = new System.Drawing.Size(452, 90);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.FlowLayoutPanel pnl;
  }
}
