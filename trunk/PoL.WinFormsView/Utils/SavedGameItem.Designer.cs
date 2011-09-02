namespace PoL.WinFormsView.Utils
{
  partial class SavedGameItem
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
      this.pnlSaveData = new System.Windows.Forms.Panel();
      this.lblPlayersData = new System.Windows.Forms.Label();
      this.lblPlayers = new System.Windows.Forms.Label();
      this.picSave = new System.Windows.Forms.PictureBox();
      this.lblDateValue = new System.Windows.Forms.Label();
      this.lblDate = new System.Windows.Forms.Label();
      this.pnlPassword = new System.Windows.Forms.Panel();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.lblPassword = new System.Windows.Forms.Label();
      this.picDelete = new System.Windows.Forms.PictureBox();
      this.pnlSaveData.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picSave)).BeginInit();
      this.pnlPassword.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
      this.SuspendLayout();
      // 
      // pnlSaveData
      // 
      this.pnlSaveData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlSaveData.BackColor = System.Drawing.Color.Transparent;
      this.pnlSaveData.Controls.Add(this.picDelete);
      this.pnlSaveData.Controls.Add(this.lblPlayersData);
      this.pnlSaveData.Controls.Add(this.lblPlayers);
      this.pnlSaveData.Controls.Add(this.picSave);
      this.pnlSaveData.Controls.Add(this.lblDateValue);
      this.pnlSaveData.Controls.Add(this.lblDate);
      this.pnlSaveData.Location = new System.Drawing.Point(0, 0);
      this.pnlSaveData.Name = "pnlSaveData";
      this.pnlSaveData.Size = new System.Drawing.Size(374, 50);
      this.pnlSaveData.TabIndex = 5;
      // 
      // lblPlayersData
      // 
      this.lblPlayersData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPlayersData.AutoEllipsis = true;
      this.lblPlayersData.BackColor = System.Drawing.Color.Transparent;
      this.lblPlayersData.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.lblPlayersData.Location = new System.Drawing.Point(105, 25);
      this.lblPlayersData.Name = "lblPlayersData";
      this.lblPlayersData.Size = new System.Drawing.Size(223, 15);
      this.lblPlayersData.TabIndex = 9;
      this.lblPlayersData.Text = "Players";
      this.lblPlayersData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblPlayers
      // 
      this.lblPlayers.BackColor = System.Drawing.Color.Transparent;
      this.lblPlayers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.lblPlayers.Location = new System.Drawing.Point(43, 25);
      this.lblPlayers.Name = "lblPlayers";
      this.lblPlayers.Size = new System.Drawing.Size(64, 15);
      this.lblPlayers.TabIndex = 8;
      this.lblPlayers.Text = "Players:";
      // 
      // picSave
      // 
      this.picSave.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.document_save1;
      this.picSave.Location = new System.Drawing.Point(7, 8);
      this.picSave.Name = "picSave";
      this.picSave.Size = new System.Drawing.Size(32, 32);
      this.picSave.TabIndex = 7;
      this.picSave.TabStop = false;
      // 
      // lblDateValue
      // 
      this.lblDateValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblDateValue.BackColor = System.Drawing.Color.Transparent;
      this.lblDateValue.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.lblDateValue.Location = new System.Drawing.Point(105, 8);
      this.lblDateValue.Name = "lblDateValue";
      this.lblDateValue.Size = new System.Drawing.Size(223, 15);
      this.lblDateValue.TabIndex = 6;
      this.lblDateValue.Text = "Date";
      this.lblDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblDate
      // 
      this.lblDate.BackColor = System.Drawing.Color.Transparent;
      this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.lblDate.Location = new System.Drawing.Point(43, 8);
      this.lblDate.Name = "lblDate";
      this.lblDate.Size = new System.Drawing.Size(64, 15);
      this.lblDate.TabIndex = 5;
      this.lblDate.Text = "Date:";
      // 
      // pnlPassword
      // 
      this.pnlPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlPassword.BackColor = System.Drawing.Color.Transparent;
      this.pnlPassword.Controls.Add(this.txtPassword);
      this.pnlPassword.Controls.Add(this.lblPassword);
      this.pnlPassword.Location = new System.Drawing.Point(0, 50);
      this.pnlPassword.Name = "pnlPassword";
      this.pnlPassword.Size = new System.Drawing.Size(374, 30);
      this.pnlPassword.TabIndex = 6;
      // 
      // txtPassword
      // 
      this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
      this.txtPassword.ForeColor = System.Drawing.SystemColors.ControlText;
      this.txtPassword.Location = new System.Drawing.Point(125, 3);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new System.Drawing.Size(152, 23);
      this.txtPassword.TabIndex = 111;
      this.txtPassword.UseSystemPasswordChar = true;
      // 
      // lblPassword
      // 
      this.lblPassword.BackColor = System.Drawing.Color.Transparent;
      this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.lblPassword.Location = new System.Drawing.Point(43, 8);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(76, 15);
      this.lblPassword.TabIndex = 6;
      this.lblPassword.Text = "Password:";
      // 
      // picDelete
      // 
      this.picDelete.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.stock_calc_cancel1;
      this.picDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.picDelete.Location = new System.Drawing.Point(334, 9);
      this.picDelete.Name = "picDelete";
      this.picDelete.Size = new System.Drawing.Size(32, 32);
      this.picDelete.TabIndex = 10;
      this.picDelete.TabStop = false;
      // 
      // SavedGameItem
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.Controls.Add(this.pnlSaveData);
      this.Controls.Add(this.pnlPassword);
      this.DoubleBuffered = true;
      this.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.ForeColor = System.Drawing.Color.DarkBlue;
      this.Name = "SavedGameItem";
      this.Size = new System.Drawing.Size(374, 80);
      this.pnlSaveData.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.picSave)).EndInit();
      this.pnlPassword.ResumeLayout(false);
      this.pnlPassword.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlSaveData;
    private System.Windows.Forms.PictureBox picSave;
    private System.Windows.Forms.Label lblDateValue;
    private System.Windows.Forms.Label lblDate;
    private System.Windows.Forms.Panel pnlPassword;
    private System.Windows.Forms.Label lblPassword;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Label lblPlayers;
    private System.Windows.Forms.Label lblPlayersData;
    private System.Windows.Forms.PictureBox picDelete;

  }
}
