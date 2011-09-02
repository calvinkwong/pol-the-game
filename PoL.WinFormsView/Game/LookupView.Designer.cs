namespace PoL.WinFormsView.Game
{
  partial class LookupView
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
      this.pnlMain = new System.Windows.Forms.Panel();
      this.pnlList = new System.Windows.Forms.Panel();
      this.cardList = new PoL.WinFormsView.Utils.CardListView();
      this.sortedCardList = new PoL.WinFormsView.Utils.CardListView();
      this.txtQuickSearch = new System.Windows.Forms.TextBox();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.lblSearch = new System.Windows.Forms.ToolStripLabel();
      this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.btnUp = new System.Windows.Forms.ToolStripButton();
      this.btnDown = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.btnSort = new System.Windows.Forms.ToolStripButton();
      this.btnBottom = new System.Windows.Forms.ToolStripButton();
      this.pnlMain.SuspendLayout();
      this.pnlList.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlMain
      // 
      this.pnlMain.Controls.Add(this.pnlList);
      this.pnlMain.Controls.Add(this.txtQuickSearch);
      this.pnlMain.Controls.Add(this.toolStrip1);
      this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlMain.Location = new System.Drawing.Point(0, 0);
      this.pnlMain.Name = "pnlMain";
      this.pnlMain.Size = new System.Drawing.Size(368, 389);
      this.pnlMain.TabIndex = 1;
      // 
      // pnlList
      // 
      this.pnlList.Controls.Add(this.cardList);
      this.pnlList.Controls.Add(this.sortedCardList);
      this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlList.Location = new System.Drawing.Point(0, 25);
      this.pnlList.Name = "pnlList";
      this.pnlList.Size = new System.Drawing.Size(368, 364);
      this.pnlList.TabIndex = 3;
      // 
      // cardList
      // 
      this.cardList.AllowDrop = true;
      this.cardList.Behavior = PoL.WinFormsView.Utils.CardListBehavior.Game;
      this.cardList.DataSource = null;
      this.cardList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cardList.GridLines = true;
      this.cardList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.cardList.HideSelection = false;
      this.cardList.Location = new System.Drawing.Point(0, 0);
      this.cardList.Name = "cardList";
      this.cardList.OwnerDraw = true;
      this.cardList.ShowItemToolTips = true;
      this.cardList.Size = new System.Drawing.Size(368, 364);
      this.cardList.TabIndex = 0;
      this.cardList.UseCompatibleStateImageBehavior = false;
      this.cardList.View = System.Windows.Forms.View.Details;
      // 
      // sortedCardList
      // 
      this.sortedCardList.AllowDrop = true;
      this.sortedCardList.Behavior = PoL.WinFormsView.Utils.CardListBehavior.GameSorted;
      this.sortedCardList.DataSource = null;
      this.sortedCardList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sortedCardList.GridLines = true;
      this.sortedCardList.HideSelection = false;
      this.sortedCardList.Location = new System.Drawing.Point(0, 0);
      this.sortedCardList.Name = "sortedCardList";
      this.sortedCardList.OwnerDraw = true;
      this.sortedCardList.ShowItemToolTips = true;
      this.sortedCardList.Size = new System.Drawing.Size(368, 364);
      this.sortedCardList.TabIndex = 1;
      this.sortedCardList.UseCompatibleStateImageBehavior = false;
      this.sortedCardList.View = System.Windows.Forms.View.Details;
      this.sortedCardList.Visible = false;
      // 
      // txtQuickSearch
      // 
      this.txtQuickSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtQuickSearch.Location = new System.Drawing.Point(54, 2);
      this.txtQuickSearch.Name = "txtQuickSearch";
      this.txtQuickSearch.Size = new System.Drawing.Size(100, 20);
      this.txtQuickSearch.TabIndex = 2;
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSearch,
            this.toolStripLabel2,
            this.toolStripSeparator1,
            this.btnUp,
            this.btnDown,
            this.btnBottom,
            this.toolStripSeparator2,
            this.btnSort});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(368, 25);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // lblSearch
      // 
      this.lblSearch.Name = "lblSearch";
      this.lblSearch.Size = new System.Drawing.Size(45, 22);
      this.lblSearch.Text = "Search:";
      // 
      // toolStripLabel2
      // 
      this.toolStripLabel2.AutoSize = false;
      this.toolStripLabel2.Name = "toolStripLabel2";
      this.toolStripLabel2.Size = new System.Drawing.Size(100, 22);
      this.toolStripLabel2.Text = "toolStripLabel2";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // btnUp
      // 
      this.btnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnUp.Image = global::PoL.WinFormsView.Properties.Resources.go_up1;
      this.btnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnUp.Name = "btnUp";
      this.btnUp.Size = new System.Drawing.Size(23, 22);
      // 
      // btnDown
      // 
      this.btnDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnDown.Image = global::PoL.WinFormsView.Properties.Resources.down1;
      this.btnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnDown.Name = "btnDown";
      this.btnDown.Size = new System.Drawing.Size(23, 22);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // btnSort
      // 
      this.btnSort.CheckOnClick = true;
      this.btnSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnSort.Image = global::PoL.WinFormsView.Properties.Resources.stock_sort_ascending;
      this.btnSort.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnSort.Name = "btnSort";
      this.btnSort.Size = new System.Drawing.Size(23, 22);
      // 
      // btnBottom
      // 
      this.btnBottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnBottom.Image = global::PoL.WinFormsView.Properties.Resources.bottom;
      this.btnBottom.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnBottom.Name = "btnBottom";
      this.btnBottom.Size = new System.Drawing.Size(23, 22);
      // 
      // LookupView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(368, 389);
      this.Controls.Add(this.pnlMain);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
      this.Name = "LookupView";
      this.ShowInTaskbar = false;
      this.Text = "LookupView";
      this.pnlMain.ResumeLayout(false);
      this.pnlMain.PerformLayout();
      this.pnlList.ResumeLayout(false);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private PoL.WinFormsView.Utils.CardListView cardList;
    private System.Windows.Forms.Panel pnlMain;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripLabel lblSearch;
    private System.Windows.Forms.TextBox txtQuickSearch;
    private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton btnUp;
    private System.Windows.Forms.ToolStripButton btnDown;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton btnSort;
    private System.Windows.Forms.Panel pnlList;
    private Utils.CardListView sortedCardList;
    private System.Windows.Forms.ToolStripButton btnBottom;
  }
}