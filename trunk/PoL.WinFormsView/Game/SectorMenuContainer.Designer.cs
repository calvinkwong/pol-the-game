namespace PoL.WinFormsView.Game
{
  partial class SectorMenuContainer
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

    #region Codice generato da Progettazione componenti

    /// <summary> 
    /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
    /// il contenuto del metodo con l'editor di codice.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.menuStraightAllCards = new System.Windows.Forms.ToolStripMenuItem();
      this.menuChangeAllCardsCharacteristics = new System.Windows.Forms.ToolStripMenuItem();
      this.menuCreatePawn = new System.Windows.Forms.ToolStripMenuItem();
      this.menuShuffle = new System.Windows.Forms.ToolStripMenuItem();
      this.sepShuffle = new System.Windows.Forms.ToolStripSeparator();
      this.menuMoveTopToDefaultSector = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMoveXTopToDefaultSector = new System.Windows.Forms.ToolStripMenuItem();
      this.sepDefault = new System.Windows.Forms.ToolStripSeparator();
      this.menuShowXRandomToPlayer = new System.Windows.Forms.ToolStripMenuItem();
      this.menuShowXTopToPlayer = new System.Windows.Forms.ToolStripMenuItem();
      this.menuShowAllToPlayer = new System.Windows.Forms.ToolStripMenuItem();
      this.menuWatchXTop = new System.Windows.Forms.ToolStripMenuItem();
      this.menuWatchAll = new System.Windows.Forms.ToolStripMenuItem();
      this.menuKeepUncoveredXTop = new System.Windows.Forms.ToolStripMenuItem();
      this.sepShow = new System.Windows.Forms.ToolStripSeparator();
      this.menuMoveXRandomToSector = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMoveXTopToSector = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMoveAllToTopSector = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMoveAllToBottomSector = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMulligan = new System.Windows.Forms.ToolStripMenuItem();
      this.menu.SuspendLayout();
      this.SuspendLayout();
      // 
      // menu
      // 
      this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStraightAllCards,
            this.menuChangeAllCardsCharacteristics,
            this.menuCreatePawn,
            this.menuShuffle,
            this.menuMulligan,
            this.sepShuffle,
            this.menuMoveTopToDefaultSector,
            this.menuMoveXTopToDefaultSector,
            this.sepDefault,
            this.menuShowXRandomToPlayer,
            this.menuShowXTopToPlayer,
            this.menuShowAllToPlayer,
            this.menuWatchXTop,
            this.menuWatchAll,
            this.menuKeepUncoveredXTop,
            this.sepShow,
            this.menuMoveXRandomToSector,
            this.menuMoveXTopToSector,
            this.menuMoveAllToTopSector,
            this.menuMoveAllToBottomSector});
      this.menu.Name = "menu";
      this.menu.Size = new System.Drawing.Size(218, 418);
      // 
      // menuStraightAllCards
      // 
      this.menuStraightAllCards.Image = global::PoL.WinFormsView.Properties.Resources.rotate;
      this.menuStraightAllCards.Name = "menuStraightAllCards";
      this.menuStraightAllCards.Size = new System.Drawing.Size(217, 22);
      this.menuStraightAllCards.Text = "StraightAllCards";
      // 
      // menuChangeAllCardsCharacteristics
      // 
      this.menuChangeAllCardsCharacteristics.Name = "menuChangeAllCardsCharacteristics";
      this.menuChangeAllCardsCharacteristics.Size = new System.Drawing.Size(217, 22);
      this.menuChangeAllCardsCharacteristics.Text = "ChangeAllCharacteristics";
      // 
      // menuCreatePawn
      // 
      this.menuCreatePawn.Name = "menuCreatePawn";
      this.menuCreatePawn.Size = new System.Drawing.Size(217, 22);
      this.menuCreatePawn.Text = "CreatePawn";
      // 
      // menuShuffle
      // 
      this.menuShuffle.Image = global::PoL.WinFormsView.Properties.Resources.stock_flip_horizontally;
      this.menuShuffle.Name = "menuShuffle";
      this.menuShuffle.Size = new System.Drawing.Size(217, 22);
      this.menuShuffle.Text = "Shuffle";
      // 
      // sepShuffle
      // 
      this.sepShuffle.Name = "sepShuffle";
      this.sepShuffle.Size = new System.Drawing.Size(214, 6);
      // 
      // menuMoveTopToDefaultSector
      // 
      this.menuMoveTopToDefaultSector.Image = global::PoL.WinFormsView.Properties.Resources.stock_alignment_right;
      this.menuMoveTopToDefaultSector.Name = "menuMoveTopToDefaultSector";
      this.menuMoveTopToDefaultSector.Size = new System.Drawing.Size(217, 22);
      this.menuMoveTopToDefaultSector.Text = "MoveTopToDefaultSector";
      // 
      // menuMoveXTopToDefaultSector
      // 
      this.menuMoveXTopToDefaultSector.Name = "menuMoveXTopToDefaultSector";
      this.menuMoveXTopToDefaultSector.Size = new System.Drawing.Size(217, 22);
      this.menuMoveXTopToDefaultSector.Text = "MoveXTopToDefaultSector";
      // 
      // sepDefault
      // 
      this.sepDefault.Name = "sepDefault";
      this.sepDefault.Size = new System.Drawing.Size(214, 6);
      // 
      // menuShowXRandomToPlayer
      // 
      this.menuShowXRandomToPlayer.Name = "menuShowXRandomToPlayer";
      this.menuShowXRandomToPlayer.Size = new System.Drawing.Size(217, 22);
      this.menuShowXRandomToPlayer.Text = "ShowXRandomToPlayer";
      // 
      // menuShowXTopToPlayer
      // 
      this.menuShowXTopToPlayer.Name = "menuShowXTopToPlayer";
      this.menuShowXTopToPlayer.Size = new System.Drawing.Size(217, 22);
      this.menuShowXTopToPlayer.Text = "ShowXTopToPlayer";
      // 
      // menuShowAllToPlayer
      // 
      this.menuShowAllToPlayer.Name = "menuShowAllToPlayer";
      this.menuShowAllToPlayer.Size = new System.Drawing.Size(217, 22);
      this.menuShowAllToPlayer.Text = "ShowAllToPlayer";
      // 
      // menuWatchXTop
      // 
      this.menuWatchXTop.Image = global::PoL.WinFormsView.Properties.Resources.stock_show_all;
      this.menuWatchXTop.Name = "menuWatchXTop";
      this.menuWatchXTop.Size = new System.Drawing.Size(217, 22);
      this.menuWatchXTop.Text = "WatchXTop";
      // 
      // menuWatchAll
      // 
      this.menuWatchAll.Name = "menuWatchAll";
      this.menuWatchAll.Size = new System.Drawing.Size(217, 22);
      this.menuWatchAll.Text = "WatchAll";
      // 
      // menuKeepUncoveredXTop
      // 
      this.menuKeepUncoveredXTop.Name = "menuKeepUncoveredXTop";
      this.menuKeepUncoveredXTop.Size = new System.Drawing.Size(217, 22);
      this.menuKeepUncoveredXTop.Text = "KeepUncoveredXTop";
      // 
      // sepShow
      // 
      this.sepShow.Name = "sepShow";
      this.sepShow.Size = new System.Drawing.Size(214, 6);
      // 
      // menuMoveXRandomToSector
      // 
      this.menuMoveXRandomToSector.Name = "menuMoveXRandomToSector";
      this.menuMoveXRandomToSector.Size = new System.Drawing.Size(217, 22);
      this.menuMoveXRandomToSector.Text = "MoveXRandomToSector";
      // 
      // menuMoveXTopToSector
      // 
      this.menuMoveXTopToSector.Name = "menuMoveXTopToSector";
      this.menuMoveXTopToSector.Size = new System.Drawing.Size(217, 22);
      this.menuMoveXTopToSector.Text = "MoveXTopToSector";
      // 
      // menuMoveAllToTopSector
      // 
      this.menuMoveAllToTopSector.Name = "menuMoveAllToTopSector";
      this.menuMoveAllToTopSector.Size = new System.Drawing.Size(217, 22);
      this.menuMoveAllToTopSector.Text = "MoveAllToTopSector";
      // 
      // menuMoveAllToBottomSector
      // 
      this.menuMoveAllToBottomSector.Name = "menuMoveAllToBottomSector";
      this.menuMoveAllToBottomSector.Size = new System.Drawing.Size(217, 22);
      this.menuMoveAllToBottomSector.Text = "MoveAllToBottomSector";
      // 
      // menuMulligan
      // 
      this.menuMulligan.Name = "menuMulligan";
      this.menuMulligan.Size = new System.Drawing.Size(217, 22);
      this.menuMulligan.Text = "Mulligan";
      // 
      // SectorMenuContainer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Name = "SectorMenuContainer";
      this.menu.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip menu;
    private System.Windows.Forms.ToolStripMenuItem menuStraightAllCards;
    private System.Windows.Forms.ToolStripMenuItem menuCreatePawn;
    private System.Windows.Forms.ToolStripMenuItem menuShowXRandomToPlayer;
    private System.Windows.Forms.ToolStripMenuItem menuMoveXRandomToSector;
    private System.Windows.Forms.ToolStripMenuItem menuMoveAllToTopSector;
    private System.Windows.Forms.ToolStripMenuItem menuMoveAllToBottomSector;
    private System.Windows.Forms.ToolStripMenuItem menuShuffle;
    private System.Windows.Forms.ToolStripMenuItem menuMoveTopToDefaultSector;
    private System.Windows.Forms.ToolStripMenuItem menuMoveXTopToDefaultSector;
    private System.Windows.Forms.ToolStripMenuItem menuWatchXTop;
    private System.Windows.Forms.ToolStripMenuItem menuShowXTopToPlayer;
    private System.Windows.Forms.ToolStripMenuItem menuWatchAll;
    private System.Windows.Forms.ToolStripMenuItem menuShowAllToPlayer;
    private System.Windows.Forms.ToolStripMenuItem menuKeepUncoveredXTop;
    private System.Windows.Forms.ToolStripMenuItem menuMoveXTopToSector;
    private System.Windows.Forms.ToolStripSeparator sepShuffle;
    private System.Windows.Forms.ToolStripSeparator sepDefault;
    private System.Windows.Forms.ToolStripSeparator sepShow;
    private System.Windows.Forms.ToolStripMenuItem menuChangeAllCardsCharacteristics;
    private System.Windows.Forms.ToolStripMenuItem menuMulligan;
  }
}
