namespace PoL.Services
{
  partial class FullCardLayout2ST
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
          this.mType = new System.Windows.Forms.Panel();
          this.mText = new System.Windows.Forms.Panel();
          this.mArtist = new System.Windows.Forms.Panel();
          this.mSymbol = new System.Windows.Forms.Panel();
          this.mImage = new System.Windows.Forms.Panel();
          this.mCharacteristics = new System.Windows.Forms.Panel();
          this.SuspendLayout();
          // 
          // mName
          // 
          this.mName.Location = new System.Drawing.Point(9, 8);
          this.mName.Name = "mName";
          this.mName.Size = new System.Drawing.Size(230, 16);
          this.mName.TabIndex = 1;
          // 
          // mType
          // 
          this.mType.Location = new System.Drawing.Point(9, 30);
          this.mType.Name = "mType";
          this.mType.Size = new System.Drawing.Size(154, 16);
          this.mType.TabIndex = 3;
          // 
          // mText
          // 
          this.mText.Location = new System.Drawing.Point(10, 253);
          this.mText.Name = "mText";
          this.mText.Size = new System.Drawing.Size(228, 64);
          this.mText.TabIndex = 4;
          // 
          // mArtist
          // 
          this.mArtist.Location = new System.Drawing.Point(7, 318);
          this.mArtist.Name = "mArtist";
          this.mArtist.Size = new System.Drawing.Size(234, 16);
          this.mArtist.TabIndex = 5;
          // 
          // mSymbol
          // 
          this.mSymbol.Location = new System.Drawing.Point(221, 31);
          this.mSymbol.Name = "mSymbol";
          this.mSymbol.Size = new System.Drawing.Size(13, 13);
          this.mSymbol.TabIndex = 6;
          // 
          // mImage
          // 
          this.mImage.Location = new System.Drawing.Point(9, 52);
          this.mImage.Name = "mImage";
          this.mImage.Size = new System.Drawing.Size(232, 195);
          this.mImage.TabIndex = 7;
          // 
          // mCharacteristics
          // 
          this.mCharacteristics.Location = new System.Drawing.Point(170, 25);
          this.mCharacteristics.Name = "mCharacteristics";
          this.mCharacteristics.Size = new System.Drawing.Size(47, 24);
          this.mCharacteristics.TabIndex = 9;
          // 
          // FullCardLayout2ST
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.mCharacteristics);
          this.Controls.Add(this.mImage);
          this.Controls.Add(this.mSymbol);
          this.Controls.Add(this.mText);
          this.Controls.Add(this.mArtist);
          this.Controls.Add(this.mType);
          this.Controls.Add(this.mName);
          this.Name = "FullCardLayout2ST";
          this.Size = new System.Drawing.Size(250, 335);
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mName;
			private System.Windows.Forms.Panel mType;
			private System.Windows.Forms.Panel mText;
			private System.Windows.Forms.Panel mArtist;
      private System.Windows.Forms.Panel mSymbol;
      private System.Windows.Forms.Panel mImage;
      private System.Windows.Forms.Panel mCharacteristics;
    }
}
