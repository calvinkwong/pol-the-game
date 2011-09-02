namespace PoL.Test
{
  partial class TestView
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
      this.btnStartOnLine = new System.Windows.Forms.Button();
      this.btnStartSolitaire = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnStartOnLine
      // 
      this.btnStartOnLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnStartOnLine.Location = new System.Drawing.Point(29, 143);
      this.btnStartOnLine.Name = "btnStartOnLine";
      this.btnStartOnLine.Size = new System.Drawing.Size(204, 125);
      this.btnStartOnLine.TabIndex = 1;
      this.btnStartOnLine.Text = "Start on line";
      this.btnStartOnLine.UseVisualStyleBackColor = true;
      this.btnStartOnLine.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // btnStartSolitaire
      // 
      this.btnStartSolitaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnStartSolitaire.Location = new System.Drawing.Point(29, 12);
      this.btnStartSolitaire.Name = "btnStartSolitaire";
      this.btnStartSolitaire.Size = new System.Drawing.Size(204, 125);
      this.btnStartSolitaire.TabIndex = 2;
      this.btnStartSolitaire.Text = "Start Solitaire";
      this.btnStartSolitaire.UseVisualStyleBackColor = true;
      this.btnStartSolitaire.Click += new System.EventHandler(this.btnStartSolitaire_Click);
      // 
      // TestView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 276);
      this.Controls.Add(this.btnStartSolitaire);
      this.Controls.Add(this.btnStartOnLine);
      this.Name = "TestView";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnStartOnLine;
    private System.Windows.Forms.Button btnStartSolitaire;

  }
}

