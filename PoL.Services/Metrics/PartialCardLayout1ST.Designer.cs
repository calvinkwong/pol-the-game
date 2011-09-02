namespace PoL.Services
{
  partial class PartialCardLayout1ST
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
            if (disposing && (components != null))
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
          this.mName = new System.Windows.Forms.Panel();
          this.mImage = new System.Windows.Forms.Panel();
          this.mCharacteristics = new System.Windows.Forms.Panel();
          this.mText = new System.Windows.Forms.Panel();
          this.mType = new System.Windows.Forms.Panel();
          this.SuspendLayout();
          // 
          // mName
          // 
          this.mName.Location = new System.Drawing.Point(2, 1);
          this.mName.Name = "mName";
          this.mName.Size = new System.Drawing.Size(80, 12);
          this.mName.TabIndex = 1;
          // 
          // mImage
          // 
          this.mImage.Location = new System.Drawing.Point(7, 34);
          this.mImage.Name = "mImage";
          this.mImage.Size = new System.Drawing.Size(71, 52);
          this.mImage.TabIndex = 2;
          // 
          // mCharacteristics
          // 
          this.mCharacteristics.Location = new System.Drawing.Point(54, 37);
          this.mCharacteristics.Name = "mCharacteristics";
          this.mCharacteristics.Size = new System.Drawing.Size(29, 12);
          this.mCharacteristics.TabIndex = 3;
          // 
          // mText
          // 
          this.mText.Location = new System.Drawing.Point(7, 91);
          this.mText.Name = "mText";
          this.mText.Size = new System.Drawing.Size(71, 26);
          this.mText.TabIndex = 5;
          // 
          // mType
          // 
          this.mType.Location = new System.Drawing.Point(0, 16);
          this.mType.Name = "mType";
          this.mType.Size = new System.Drawing.Size(84, 12);
          this.mType.TabIndex = 6;
          // 
          // PartialCardLayout1ST
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.mType);
          this.Controls.Add(this.mCharacteristics);
          this.Controls.Add(this.mText);
          this.Controls.Add(this.mImage);
          this.Controls.Add(this.mName);
          this.Name = "PartialCardLayout1ST";
          this.Size = new System.Drawing.Size(84, 120);
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mName;
		private System.Windows.Forms.Panel mImage;
    private System.Windows.Forms.Panel mCharacteristics;
    private System.Windows.Forms.Panel mText;
    private System.Windows.Forms.Panel mType;
    }
}
