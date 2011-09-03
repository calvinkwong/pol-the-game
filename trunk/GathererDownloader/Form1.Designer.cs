namespace ScaricaSpoilers
{
	partial class Form1
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
      this.mList = new System.Windows.Forms.ListView();
      this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
      this.mBtnDownloadList = new System.Windows.Forms.Button();
      this.mBtnDownLoadSpoiler = new System.Windows.Forms.Button();
      this.mProgress = new System.Windows.Forms.ProgressBar();
      this.btnImportIta = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // mList
      // 
      this.mList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.mList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
      this.mList.Location = new System.Drawing.Point(12, 12);
      this.mList.Name = "mList";
      this.mList.Size = new System.Drawing.Size(272, 306);
      this.mList.TabIndex = 0;
      this.mList.UseCompatibleStateImageBehavior = false;
      this.mList.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "SET";
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "TEXT";
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "OTHER";
      // 
      // mBtnDownloadList
      // 
      this.mBtnDownloadList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.mBtnDownloadList.Location = new System.Drawing.Point(290, 12);
      this.mBtnDownloadList.Name = "mBtnDownloadList";
      this.mBtnDownloadList.Size = new System.Drawing.Size(86, 41);
      this.mBtnDownloadList.TabIndex = 2;
      this.mBtnDownloadList.Text = "DOWNLOAD LIST";
      this.mBtnDownloadList.UseVisualStyleBackColor = true;
      this.mBtnDownloadList.Click += new System.EventHandler(this.mBtnDownloadList_Click);
      // 
      // mBtnDownLoadSpoiler
      // 
      this.mBtnDownLoadSpoiler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.mBtnDownLoadSpoiler.Location = new System.Drawing.Point(290, 69);
      this.mBtnDownLoadSpoiler.Name = "mBtnDownLoadSpoiler";
      this.mBtnDownLoadSpoiler.Size = new System.Drawing.Size(86, 41);
      this.mBtnDownLoadSpoiler.TabIndex = 4;
      this.mBtnDownLoadSpoiler.Text = "CREATE SPOILER";
      this.mBtnDownLoadSpoiler.UseVisualStyleBackColor = true;
      this.mBtnDownLoadSpoiler.Click += new System.EventHandler(this.mBtnDownLoadSpoiler_Click);
      // 
      // mProgress
      // 
      this.mProgress.Location = new System.Drawing.Point(12, 338);
      this.mProgress.Name = "mProgress";
      this.mProgress.Size = new System.Drawing.Size(364, 23);
      this.mProgress.TabIndex = 5;
      // 
      // btnImportIta
      // 
      this.btnImportIta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnImportIta.Location = new System.Drawing.Point(290, 131);
      this.btnImportIta.Name = "btnImportIta";
      this.btnImportIta.Size = new System.Drawing.Size(86, 41);
      this.btnImportIta.TabIndex = 6;
      this.btnImportIta.Text = "IMPORT ITA";
      this.btnImportIta.UseVisualStyleBackColor = true;
      this.btnImportIta.Click += new System.EventHandler(this.btnImportIta_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(388, 373);
      this.Controls.Add(this.btnImportIta);
      this.Controls.Add(this.mProgress);
      this.Controls.Add(this.mBtnDownLoadSpoiler);
      this.Controls.Add(this.mBtnDownloadList);
      this.Controls.Add(this.mList);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView mList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.Button mBtnDownloadList;
		private System.Windows.Forms.Button mBtnDownLoadSpoiler;
    private System.Windows.Forms.ProgressBar mProgress;
    private System.Windows.Forms.Button btnImportIta;
	}
}

