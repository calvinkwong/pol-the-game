namespace PoL.WinFormsView.DeckRoom
{
  partial class DeckImportStatisticsView
  {
    /// <summary>
    /// Variabile di progettazione necessaria.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Liberare le risorse in uso.
    /// </summary>
    /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
    protected override void Dispose(bool disposing)
    {
      if(disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Codice generato da Progettazione Windows Form

    /// <summary>
    /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
    /// il contenuto del metodo con l'editor di codice.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeckImportStatisticsView));
      this.listResults = new System.Windows.Forms.ListView();
      this.colStatus = new System.Windows.Forms.ColumnHeader();
      this.colFileName = new System.Windows.Forms.ColumnHeader();
      this.imageList = new System.Windows.Forms.ImageList(this.components);
      this.btnOk = new System.Windows.Forms.Button();
      this.listDiscardedLines = new System.Windows.Forms.ListView();
      this.colLine = new System.Windows.Forms.ColumnHeader();
      this.colError = new System.Windows.Forms.ColumnHeader();
      this.SuspendLayout();
      // 
      // listResults
      // 
      this.listResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)));
      this.listResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colStatus,
            this.colFileName});
      this.listResults.FullRowSelect = true;
      this.listResults.Location = new System.Drawing.Point(0, 0);
      this.listResults.MultiSelect = false;
      this.listResults.Name = "listResults";
      this.listResults.Size = new System.Drawing.Size(270, 190);
      this.listResults.SmallImageList = this.imageList;
      this.listResults.TabIndex = 0;
      this.listResults.UseCompatibleStateImageBehavior = false;
      this.listResults.View = System.Windows.Forms.View.Details;
      // 
      // colStatus
      // 
      this.colStatus.Text = "STATUS";
      // 
      // colFileName
      // 
      this.colFileName.Text = "FILENAME";
      this.colFileName.Width = 200;
      // 
      // imageList
      // 
      this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
      this.imageList.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList.Images.SetKeyName(0, "OK");
      this.imageList.Images.SetKeyName(1, "KO");
      // 
      // btnOk
      // 
      this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnOk.Location = new System.Drawing.Point(305, 197);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 23);
      this.btnOk.TabIndex = 1;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = true;
      // 
      // listDiscardedLines
      // 
      this.listDiscardedLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.listDiscardedLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLine,
            this.colError});
      this.listDiscardedLines.Location = new System.Drawing.Point(276, 0);
      this.listDiscardedLines.Name = "listDiscardedLines";
      this.listDiscardedLines.Size = new System.Drawing.Size(408, 190);
      this.listDiscardedLines.SmallImageList = this.imageList;
      this.listDiscardedLines.TabIndex = 2;
      this.listDiscardedLines.UseCompatibleStateImageBehavior = false;
      this.listDiscardedLines.View = System.Windows.Forms.View.Details;
      // 
      // colLine
      // 
      this.colLine.Text = "LINE";
      this.colLine.Width = 126;
      // 
      // colError
      // 
      this.colError.Text = "ERROR";
      this.colError.Width = 351;
      // 
      // DeckImportStatisticsView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(685, 225);
      this.Controls.Add(this.listDiscardedLines);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.listResults);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
      this.Name = "DeckImportStatisticsView";
      this.ShowInTaskbar = false;
      this.Text = "ImportStatisticsView";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView listResults;
    private System.Windows.Forms.ColumnHeader colFileName;
    private System.Windows.Forms.ColumnHeader colStatus;
    private System.Windows.Forms.ImageList imageList;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.ListView listDiscardedLines;
    private System.Windows.Forms.ColumnHeader colLine;
    private System.Windows.Forms.ColumnHeader colError;

  }
}