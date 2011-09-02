namespace PoL.Services
{
  partial class PartialCardLayoutPawn
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
          this.mType = new System.Windows.Forms.Panel();
          this.mText = new System.Windows.Forms.Panel();
          this.SuspendLayout();
          // 
          // mName
          // 
          this.mName.Location = new System.Drawing.Point(4, 0);
          this.mName.Name = "mName";
          this.mName.Size = new System.Drawing.Size(77, 12);
          this.mName.TabIndex = 1;
          // 
          // mImage
          // 
          this.mImage.Location = new System.Drawing.Point(4, 15);
          this.mImage.Name = "mImage";
          this.mImage.Size = new System.Drawing.Size(76, 52);
          this.mImage.TabIndex = 2;
          // 
          // mCharacteristics
          // 
          this.mCharacteristics.Location = new System.Drawing.Point(42, 96);
          this.mCharacteristics.Name = "mCharacteristics";
          this.mCharacteristics.Size = new System.Drawing.Size(41, 21);
          this.mCharacteristics.TabIndex = 3;
          // 
          // mType
          // 
          this.mType.Location = new System.Drawing.Point(3, 68);
          this.mType.Name = "mType";
          this.mType.Size = new System.Drawing.Size(79, 9);
          this.mType.TabIndex = 4;
          // 
          // mText
          // 
          this.mText.Location = new System.Drawing.Point(4, 76);
          this.mText.Name = "mText";
          this.mText.Size = new System.Drawing.Size(76, 41);
          this.mText.TabIndex = 6;
          // 
          // PartialCardLayoutPawn
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.mType);
          this.Controls.Add(this.mCharacteristics);
          this.Controls.Add(this.mImage);
          this.Controls.Add(this.mName);
          this.Controls.Add(this.mText);
          this.Name = "PartialCardLayoutPawn";
          this.Size = new System.Drawing.Size(84, 120);
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mName;
		private System.Windows.Forms.Panel mImage;
		private System.Windows.Forms.Panel mCharacteristics;
    private System.Windows.Forms.Panel mType;
    private System.Windows.Forms.Panel mText;
    }
}
