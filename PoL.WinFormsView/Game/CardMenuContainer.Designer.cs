namespace PoL.WinFormsView.Game
{
  partial class CardMenuContainer
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
      this.menuRotate = new System.Windows.Forms.ToolStripMenuItem();
      this.menuLock = new System.Windows.Forms.ToolStripMenuItem();
      this.sepRotation = new System.Windows.Forms.ToolStripSeparator();
      this.menuReverse = new System.Windows.Forms.ToolStripMenuItem();
      this.sepVisibility = new System.Windows.Forms.ToolStripSeparator();
      this.menuAddToken = new System.Windows.Forms.ToolStripMenuItem();
      this.menuChangeCharacteristics = new System.Windows.Forms.ToolStripMenuItem();
      this.menuDuplicate = new System.Windows.Forms.ToolStripMenuItem();
      this.sepCard = new System.Windows.Forms.ToolStripSeparator();
      this.menuMoveToDefault = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMoveToDefault_VisibilityOwnerOnly = new System.Windows.Forms.ToolStripMenuItem();
      this.sepMoveDefault = new System.Windows.Forms.ToolStripSeparator();
      this.menuMoveToTopSector = new System.Windows.Forms.ToolStripMenuItem();
      this.menuMoveToBottomSector = new System.Windows.Forms.ToolStripMenuItem();
      this.sepMove = new System.Windows.Forms.ToolStripSeparator();
      this.menuShowToPlayer = new System.Windows.Forms.ToolStripMenuItem();
      this.menuVisible = new System.Windows.Forms.ToolStripMenuItem();
      this.menuOwnerOnly = new System.Windows.Forms.ToolStripMenuItem();
      this.menuHidden = new System.Windows.Forms.ToolStripMenuItem();
      this.menu.SuspendLayout();
      this.SuspendLayout();
      // 
      // menu
      // 
      this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRotate,
            this.menuLock,
            this.sepRotation,
            this.menuReverse,
            this.menuVisible,
            this.menuOwnerOnly,
            this.menuHidden,
            this.sepVisibility,
            this.menuAddToken,
            this.menuChangeCharacteristics,
            this.menuDuplicate,
            this.sepCard,
            this.menuMoveToDefault,
            this.menuMoveToDefault_VisibilityOwnerOnly,
            this.sepMoveDefault,
            this.menuMoveToTopSector,
            this.menuMoveToBottomSector,
            this.sepMove,
            this.menuShowToPlayer});
      this.menu.Name = "contextMenuStrip1";
      this.menu.Size = new System.Drawing.Size(266, 364);
      // 
      // menuRotate
      // 
      this.menuRotate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.menuRotate.Image = global::PoL.WinFormsView.Properties.Resources.stock_rotate;
      this.menuRotate.Name = "menuRotate";
      this.menuRotate.Size = new System.Drawing.Size(265, 22);
      this.menuRotate.Text = "Rotate90";
      // 
      // menuLock
      // 
      this.menuLock.Name = "menuLock";
      this.menuLock.Size = new System.Drawing.Size(265, 22);
      this.menuLock.Text = "Lock";
      // 
      // sepRotation
      // 
      this.sepRotation.Name = "sepRotation";
      this.sepRotation.Size = new System.Drawing.Size(262, 6);
      // 
      // menuReverse
      // 
      this.menuReverse.Name = "menuReverse";
      this.menuReverse.Size = new System.Drawing.Size(265, 22);
      this.menuReverse.Text = "Reverse";
      // 
      // sepVisibility
      // 
      this.sepVisibility.Name = "sepVisibility";
      this.sepVisibility.Size = new System.Drawing.Size(262, 6);
      // 
      // menuAddToken
      // 
      this.menuAddToken.Image = global::PoL.WinFormsView.Properties.Resources.button_red_small;
      this.menuAddToken.Name = "menuAddToken";
      this.menuAddToken.Size = new System.Drawing.Size(265, 22);
      this.menuAddToken.Text = "AddToken";
      // 
      // menuChangeCharacteristics
      // 
      this.menuChangeCharacteristics.Name = "menuChangeCharacteristics";
      this.menuChangeCharacteristics.Size = new System.Drawing.Size(265, 22);
      this.menuChangeCharacteristics.Text = "ChangeCharacteristics";
      // 
      // menuDuplicate
      // 
      this.menuDuplicate.Name = "menuDuplicate";
      this.menuDuplicate.Size = new System.Drawing.Size(265, 22);
      this.menuDuplicate.Text = "Duplicate";
      // 
      // sepCard
      // 
      this.sepCard.Name = "sepCard";
      this.sepCard.Size = new System.Drawing.Size(262, 6);
      // 
      // menuMoveToDefault
      // 
      this.menuMoveToDefault.Image = global::PoL.WinFormsView.Properties.Resources.stock_alignment_right;
      this.menuMoveToDefault.Name = "menuMoveToDefault";
      this.menuMoveToDefault.Size = new System.Drawing.Size(265, 22);
      this.menuMoveToDefault.Text = "MoveToDefault";
      // 
      // menuMoveToDefault_VisibilityOwnerOnly
      // 
      this.menuMoveToDefault_VisibilityOwnerOnly.Name = "menuMoveToDefault_VisibilityOwnerOnly";
      this.menuMoveToDefault_VisibilityOwnerOnly.Size = new System.Drawing.Size(265, 22);
      this.menuMoveToDefault_VisibilityOwnerOnly.Text = "MoveToDefault_VisibilityOwnerOnly";
      // 
      // sepMoveDefault
      // 
      this.sepMoveDefault.Name = "sepMoveDefault";
      this.sepMoveDefault.Size = new System.Drawing.Size(262, 6);
      // 
      // menuMoveToTopSector
      // 
      this.menuMoveToTopSector.Name = "menuMoveToTopSector";
      this.menuMoveToTopSector.Size = new System.Drawing.Size(265, 22);
      this.menuMoveToTopSector.Text = "MoveToTopSector";
      // 
      // menuMoveToBottomSector
      // 
      this.menuMoveToBottomSector.Name = "menuMoveToBottomSector";
      this.menuMoveToBottomSector.Size = new System.Drawing.Size(265, 22);
      this.menuMoveToBottomSector.Text = "MoveToBottomSector";
      // 
      // sepMove
      // 
      this.sepMove.Name = "sepMove";
      this.sepMove.Size = new System.Drawing.Size(262, 6);
      // 
      // menuShowToPlayer
      // 
      this.menuShowToPlayer.Name = "menuShowToPlayer";
      this.menuShowToPlayer.Size = new System.Drawing.Size(265, 22);
      this.menuShowToPlayer.Text = "ShowToPlayer";
      // 
      // menuVisible
      // 
      this.menuVisible.Name = "menuVisible";
      this.menuVisible.Size = new System.Drawing.Size(265, 22);
      this.menuVisible.Text = "Visible";
      // 
      // menuOwnerOnly
      // 
      this.menuOwnerOnly.Name = "menuOwnerOnly";
      this.menuOwnerOnly.Size = new System.Drawing.Size(265, 22);
      this.menuOwnerOnly.Text = "OwnerOnly";
      // 
      // menuHidden
      // 
      this.menuHidden.Name = "menuHidden";
      this.menuHidden.Size = new System.Drawing.Size(265, 22);
      this.menuHidden.Text = "Hidden";
      // 
      // CardMenuContainer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Name = "CardMenuContainer";
      this.menu.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip menu;
    private System.Windows.Forms.ToolStripMenuItem menuRotate;
    private System.Windows.Forms.ToolStripMenuItem menuReverse;
    private System.Windows.Forms.ToolStripMenuItem menuAddToken;
    private System.Windows.Forms.ToolStripMenuItem menuChangeCharacteristics;
    private System.Windows.Forms.ToolStripMenuItem menuLock;
    private System.Windows.Forms.ToolStripMenuItem menuMoveToTopSector;
    private System.Windows.Forms.ToolStripMenuItem menuMoveToBottomSector;
    private System.Windows.Forms.ToolStripMenuItem menuMoveToDefault;
    private System.Windows.Forms.ToolStripMenuItem menuMoveToDefault_VisibilityOwnerOnly;
    private System.Windows.Forms.ToolStripMenuItem menuShowToPlayer;
    private System.Windows.Forms.ToolStripSeparator sepRotation;
    private System.Windows.Forms.ToolStripSeparator sepVisibility;
    private System.Windows.Forms.ToolStripSeparator sepCard;
    private System.Windows.Forms.ToolStripSeparator sepMoveDefault;
    private System.Windows.Forms.ToolStripSeparator sepMove;
    private System.Windows.Forms.ToolStripMenuItem menuDuplicate;
    private System.Windows.Forms.ToolStripMenuItem menuVisible;
    private System.Windows.Forms.ToolStripMenuItem menuOwnerOnly;
    private System.Windows.Forms.ToolStripMenuItem menuHidden;
  }
}
