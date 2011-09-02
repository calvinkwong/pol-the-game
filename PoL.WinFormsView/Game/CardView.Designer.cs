namespace PoL.WinFormsView.Game
{
  partial class CardView
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
      this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.menuChangeText = new System.Windows.Forms.ToolStripMenuItem();
      this.menuRemove = new System.Windows.Forms.ToolStripMenuItem();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.menu.SuspendLayout();
      this.SuspendLayout();
      // 
      // menu
      // 
      this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuChangeText,
            this.menuRemove});
      this.menu.Name = "contextMenuStrip1";
      this.menu.Size = new System.Drawing.Size(155, 48);
      // 
      // menuChangeText
      // 
      this.menuChangeText.Image = global::PoL.WinFormsView.Properties.Resources.stock_form_text_box;
      this.menuChangeText.Name = "menuChangeText";
      this.menuChangeText.Size = new System.Drawing.Size(154, 22);
      this.menuChangeText.Text = "CHANGE_TEXT";
      // 
      // menuRemove
      // 
      this.menuRemove.Image = global::PoL.WinFormsView.Properties.Resources.stock_calc_cancel;
      this.menuRemove.Name = "menuRemove";
      this.menuRemove.Size = new System.Drawing.Size(154, 22);
      this.menuRemove.Text = "REMOVE";
      // 
      // CardView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.DoubleBuffered = true;
      this.Name = "CardView";
      this.Size = new System.Drawing.Size(84, 109);
      this.menu.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip menu;
    private System.Windows.Forms.ToolStripMenuItem menuChangeText;
    private System.Windows.Forms.ToolStripMenuItem menuRemove;
    private System.Windows.Forms.ToolTip toolTip;
  }
}
