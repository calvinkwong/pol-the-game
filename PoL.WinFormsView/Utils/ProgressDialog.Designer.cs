namespace PoL.WinFormsView.Utils
{
  partial class ProgressDialog
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.lblMessage = new System.Windows.Forms.Label();
      this.progBar = new System.Windows.Forms.ProgressBar();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.background;
      this.panel1.Controls.Add(this.lblMessage);
      this.panel1.Controls.Add(this.progBar);
      this.panel1.Location = new System.Drawing.Point(12, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(419, 123);
      this.panel1.TabIndex = 2;
      // 
      // lblMessage
      // 
      this.lblMessage.BackColor = System.Drawing.Color.Transparent;
      this.lblMessage.Location = new System.Drawing.Point(54, 22);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new System.Drawing.Size(311, 23);
      this.lblMessage.TabIndex = 3;
      this.lblMessage.Text = "MESSAGE";
      this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // progBar
      // 
      this.progBar.Location = new System.Drawing.Point(20, 62);
      this.progBar.Name = "progBar";
      this.progBar.Size = new System.Drawing.Size(378, 31);
      this.progBar.TabIndex = 2;
      // 
      // ProgressDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.darkbackground;
      this.ClientSize = new System.Drawing.Size(443, 147);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "ProgressDialog";
      this.ShowInTaskbar = false;
      this.Text = "ProgressDialog";
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label lblMessage;
    private System.Windows.Forms.ProgressBar progBar;

  }
}