namespace PoL.WinFormsView.Utils
{
  partial class PlayerListItem
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
      this.lblNickname = new System.Windows.Forms.Label();
      this.lblMessage = new System.Windows.Forms.Label();
      this.picAvatar = new System.Windows.Forms.PictureBox();
      this.picReadyState = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.picReadyState)).BeginInit();
      this.SuspendLayout();
      // 
      // lblNickname
      // 
      this.lblNickname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblNickname.BackColor = System.Drawing.Color.Transparent;
      this.lblNickname.Location = new System.Drawing.Point(60, 13);
      this.lblNickname.Name = "lblNickname";
      this.lblNickname.Size = new System.Drawing.Size(165, 13);
      this.lblNickname.TabIndex = 1;
      this.lblNickname.Text = "label1";
      // 
      // lblMessage
      // 
      this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblMessage.AutoEllipsis = true;
      this.lblMessage.BackColor = System.Drawing.Color.Transparent;
      this.lblMessage.Location = new System.Drawing.Point(60, 30);
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new System.Drawing.Size(165, 15);
      this.lblMessage.TabIndex = 2;
      this.lblMessage.Text = "label1";
      // 
      // picAvatar
      // 
      this.picAvatar.BackColor = System.Drawing.Color.Transparent;
      this.picAvatar.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.pol;
      this.picAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.picAvatar.Location = new System.Drawing.Point(4, 4);
      this.picAvatar.Name = "picAvatar";
      this.picAvatar.Size = new System.Drawing.Size(50, 50);
      this.picAvatar.TabIndex = 0;
      this.picAvatar.TabStop = false;
      // 
      // picReadyState
      // 
      this.picReadyState.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.picReadyState.Location = new System.Drawing.Point(209, 4);
      this.picReadyState.Name = "picReadyState";
      this.picReadyState.Size = new System.Drawing.Size(16, 16);
      this.picReadyState.TabIndex = 3;
      this.picReadyState.TabStop = false;
      // 
      // PlayerListItem
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Transparent;
      this.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.sfondoblu_tondo;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.Controls.Add(this.picReadyState);
      this.Controls.Add(this.lblMessage);
      this.Controls.Add(this.lblNickname);
      this.Controls.Add(this.picAvatar);
      this.DoubleBuffered = true;
      this.Name = "PlayerListItem";
      this.Size = new System.Drawing.Size(228, 60);
      ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.picReadyState)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox picAvatar;
    private System.Windows.Forms.Label lblNickname;
    private System.Windows.Forms.Label lblMessage;
    private System.Windows.Forms.PictureBox picReadyState;
  }
}
