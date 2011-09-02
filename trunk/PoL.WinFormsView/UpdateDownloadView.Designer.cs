namespace PoL.WinFormsView
{
  partial class UpdateDownloadView
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
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.lblStatus = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.lblProgress = new System.Windows.Forms.Label();
      this.btnCancelClose = new System.Windows.Forms.Button();
      this.lblProgressValue = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // progressBar
      // 
      this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.progressBar.Location = new System.Drawing.Point(12, 74);
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(351, 16);
      this.progressBar.TabIndex = 86;
      // 
      // lblStatus
      // 
      this.lblStatus.AutoEllipsis = true;
      this.lblStatus.Location = new System.Drawing.Point(66, 12);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new System.Drawing.Size(297, 45);
      this.lblStatus.TabIndex = 87;
      this.lblStatus.Text = "Status";
      this.lblStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.apacheconf;
      this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.pictureBox1.Location = new System.Drawing.Point(12, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(48, 48);
      this.pictureBox1.TabIndex = 88;
      this.pictureBox1.TabStop = false;
      // 
      // lblProgress
      // 
      this.lblProgress.AutoEllipsis = true;
      this.lblProgress.Location = new System.Drawing.Point(12, 95);
      this.lblProgress.Name = "lblProgress";
      this.lblProgress.Size = new System.Drawing.Size(90, 13);
      this.lblProgress.TabIndex = 89;
      this.lblProgress.Text = "Downloaded:";
      // 
      // btnCancelClose
      // 
      this.btnCancelClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnCancelClose.Location = new System.Drawing.Point(150, 131);
      this.btnCancelClose.Name = "btnCancelClose";
      this.btnCancelClose.Size = new System.Drawing.Size(75, 23);
      this.btnCancelClose.TabIndex = 90;
      this.btnCancelClose.Text = "Cancel";
      this.btnCancelClose.UseVisualStyleBackColor = true;
      // 
      // lblProgressValue
      // 
      this.lblProgressValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblProgressValue.AutoEllipsis = true;
      this.lblProgressValue.Location = new System.Drawing.Point(108, 95);
      this.lblProgressValue.Name = "lblProgressValue";
      this.lblProgressValue.Size = new System.Drawing.Size(255, 13);
      this.lblProgressValue.TabIndex = 91;
      this.lblProgressValue.Text = "...";
      // 
      // UpdateDownloadView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(375, 166);
      this.Controls.Add(this.lblProgressValue);
      this.Controls.Add(this.btnCancelClose);
      this.Controls.Add(this.lblProgress);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.lblStatus);
      this.Controls.Add(this.progressBar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "UpdateDownloadView";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "UpdateDownloadView";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label lblProgress;
    private System.Windows.Forms.Button btnCancelClose;
    private System.Windows.Forms.Label lblProgressValue;
  }
}