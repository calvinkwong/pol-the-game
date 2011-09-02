namespace PoL.WinFormsView.Game
{
  partial class NumberInput
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
      this.mPanelMain = new System.Windows.Forms.Panel();
      this.panelRightTop = new System.Windows.Forms.Panel();
      this.pnlNegativeNumbers = new System.Windows.Forms.TableLayoutPanel();
      this.btn1n = new System.Windows.Forms.Button();
      this.btn2n = new System.Windows.Forms.Button();
      this.btn3n = new System.Windows.Forms.Button();
      this.btn4n = new System.Windows.Forms.Button();
      this.btn10n = new System.Windows.Forms.Button();
      this.btn5n = new System.Windows.Forms.Button();
      this.btn9n = new System.Windows.Forms.Button();
      this.btn6n = new System.Windows.Forms.Button();
      this.btn8n = new System.Windows.Forms.Button();
      this.btn7n = new System.Windows.Forms.Button();
      this.pnlPositiveNumbers = new System.Windows.Forms.TableLayoutPanel();
      this.btn1 = new System.Windows.Forms.Button();
      this.btn2 = new System.Windows.Forms.Button();
      this.btn3 = new System.Windows.Forms.Button();
      this.btn4 = new System.Windows.Forms.Button();
      this.btn10 = new System.Windows.Forms.Button();
      this.btn5 = new System.Windows.Forms.Button();
      this.btn9 = new System.Windows.Forms.Button();
      this.btn6 = new System.Windows.Forms.Button();
      this.btn8 = new System.Windows.Forms.Button();
      this.btn7 = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.numValue = new System.Windows.Forms.NumericUpDown();
      this.lblValue = new System.Windows.Forms.Label();
      this.btnOk = new System.Windows.Forms.Button();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.mPanelMain.SuspendLayout();
      this.panelRightTop.SuspendLayout();
      this.pnlNegativeNumbers.SuspendLayout();
      this.pnlPositiveNumbers.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numValue)).BeginInit();
      this.tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // mPanelMain
      // 
      this.mPanelMain.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.darkbackground;
      this.mPanelMain.Controls.Add(this.panelRightTop);
      this.mPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mPanelMain.Location = new System.Drawing.Point(2, 2);
      this.mPanelMain.Name = "mPanelMain";
      this.mPanelMain.Size = new System.Drawing.Size(242, 291);
      this.mPanelMain.TabIndex = 7;
      // 
      // panelRightTop
      // 
      this.panelRightTop.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.background;
      this.panelRightTop.Controls.Add(this.pnlNegativeNumbers);
      this.panelRightTop.Controls.Add(this.pnlPositiveNumbers);
      this.panelRightTop.Controls.Add(this.btnCancel);
      this.panelRightTop.Controls.Add(this.numValue);
      this.panelRightTop.Controls.Add(this.lblValue);
      this.panelRightTop.Controls.Add(this.btnOk);
      this.panelRightTop.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelRightTop.Location = new System.Drawing.Point(0, 0);
      this.panelRightTop.Name = "panelRightTop";
      this.panelRightTop.Size = new System.Drawing.Size(242, 291);
      this.panelRightTop.TabIndex = 7;
      // 
      // pnlNegativeNumbers
      // 
      this.pnlNegativeNumbers.BackColor = System.Drawing.Color.Transparent;
      this.pnlNegativeNumbers.ColumnCount = 5;
      this.pnlNegativeNumbers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.pnlNegativeNumbers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.pnlNegativeNumbers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.pnlNegativeNumbers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.pnlNegativeNumbers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.pnlNegativeNumbers.Controls.Add(this.btn1n, 0, 0);
      this.pnlNegativeNumbers.Controls.Add(this.btn2n, 1, 0);
      this.pnlNegativeNumbers.Controls.Add(this.btn3n, 2, 0);
      this.pnlNegativeNumbers.Controls.Add(this.btn4n, 3, 0);
      this.pnlNegativeNumbers.Controls.Add(this.btn10n, 4, 1);
      this.pnlNegativeNumbers.Controls.Add(this.btn5n, 4, 0);
      this.pnlNegativeNumbers.Controls.Add(this.btn9n, 3, 1);
      this.pnlNegativeNumbers.Controls.Add(this.btn6n, 0, 1);
      this.pnlNegativeNumbers.Controls.Add(this.btn8n, 2, 1);
      this.pnlNegativeNumbers.Controls.Add(this.btn7n, 1, 1);
      this.pnlNegativeNumbers.Location = new System.Drawing.Point(18, 142);
      this.pnlNegativeNumbers.Name = "pnlNegativeNumbers";
      this.pnlNegativeNumbers.RowCount = 2;
      this.pnlNegativeNumbers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.pnlNegativeNumbers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.pnlNegativeNumbers.Size = new System.Drawing.Size(206, 70);
      this.pnlNegativeNumbers.TabIndex = 40;
      // 
      // btn1n
      // 
      this.btn1n.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn1n.BackColor = System.Drawing.Color.Transparent;
      this.btn1n.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn1n.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn1n.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn1n.Location = new System.Drawing.Point(3, 3);
      this.btn1n.Name = "btn1n";
      this.btn1n.Size = new System.Drawing.Size(35, 29);
      this.btn1n.TabIndex = 25;
      this.btn1n.Text = "-1";
      this.btn1n.UseVisualStyleBackColor = false;
      // 
      // btn2n
      // 
      this.btn2n.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn2n.BackColor = System.Drawing.Color.Transparent;
      this.btn2n.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn2n.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn2n.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn2n.Location = new System.Drawing.Point(44, 3);
      this.btn2n.Name = "btn2n";
      this.btn2n.Size = new System.Drawing.Size(35, 29);
      this.btn2n.TabIndex = 23;
      this.btn2n.Text = "-2";
      this.btn2n.UseVisualStyleBackColor = false;
      // 
      // btn3n
      // 
      this.btn3n.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn3n.BackColor = System.Drawing.Color.Transparent;
      this.btn3n.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn3n.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn3n.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn3n.Location = new System.Drawing.Point(85, 3);
      this.btn3n.Name = "btn3n";
      this.btn3n.Size = new System.Drawing.Size(35, 29);
      this.btn3n.TabIndex = 16;
      this.btn3n.Text = "-3";
      this.btn3n.UseVisualStyleBackColor = false;
      // 
      // btn4n
      // 
      this.btn4n.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn4n.BackColor = System.Drawing.Color.Transparent;
      this.btn4n.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn4n.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn4n.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn4n.Location = new System.Drawing.Point(126, 3);
      this.btn4n.Name = "btn4n";
      this.btn4n.Size = new System.Drawing.Size(35, 29);
      this.btn4n.TabIndex = 17;
      this.btn4n.Text = "-4";
      this.btn4n.UseVisualStyleBackColor = false;
      // 
      // btn10n
      // 
      this.btn10n.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn10n.BackColor = System.Drawing.Color.Transparent;
      this.btn10n.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn10n.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn10n.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn10n.Location = new System.Drawing.Point(167, 38);
      this.btn10n.Name = "btn10n";
      this.btn10n.Size = new System.Drawing.Size(36, 29);
      this.btn10n.TabIndex = 24;
      this.btn10n.Text = "-10";
      this.btn10n.UseVisualStyleBackColor = false;
      // 
      // btn5n
      // 
      this.btn5n.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn5n.BackColor = System.Drawing.Color.Transparent;
      this.btn5n.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn5n.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn5n.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn5n.Location = new System.Drawing.Point(167, 3);
      this.btn5n.Name = "btn5n";
      this.btn5n.Size = new System.Drawing.Size(36, 29);
      this.btn5n.TabIndex = 18;
      this.btn5n.Text = "-5";
      this.btn5n.UseVisualStyleBackColor = false;
      // 
      // btn9n
      // 
      this.btn9n.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn9n.BackColor = System.Drawing.Color.Transparent;
      this.btn9n.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn9n.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn9n.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn9n.Location = new System.Drawing.Point(126, 38);
      this.btn9n.Name = "btn9n";
      this.btn9n.Size = new System.Drawing.Size(35, 29);
      this.btn9n.TabIndex = 22;
      this.btn9n.Text = "-9";
      this.btn9n.UseVisualStyleBackColor = false;
      // 
      // btn6n
      // 
      this.btn6n.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn6n.BackColor = System.Drawing.Color.Transparent;
      this.btn6n.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn6n.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn6n.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn6n.Location = new System.Drawing.Point(3, 38);
      this.btn6n.Name = "btn6n";
      this.btn6n.Size = new System.Drawing.Size(35, 29);
      this.btn6n.TabIndex = 19;
      this.btn6n.Text = "-6";
      this.btn6n.UseVisualStyleBackColor = false;
      // 
      // btn8n
      // 
      this.btn8n.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn8n.BackColor = System.Drawing.Color.Transparent;
      this.btn8n.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn8n.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn8n.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn8n.Location = new System.Drawing.Point(85, 38);
      this.btn8n.Name = "btn8n";
      this.btn8n.Size = new System.Drawing.Size(35, 29);
      this.btn8n.TabIndex = 21;
      this.btn8n.Text = "-8";
      this.btn8n.UseVisualStyleBackColor = false;
      // 
      // btn7n
      // 
      this.btn7n.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn7n.BackColor = System.Drawing.Color.Transparent;
      this.btn7n.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn7n.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn7n.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn7n.Location = new System.Drawing.Point(44, 38);
      this.btn7n.Name = "btn7n";
      this.btn7n.Size = new System.Drawing.Size(35, 29);
      this.btn7n.TabIndex = 20;
      this.btn7n.Text = "-7";
      this.btn7n.UseVisualStyleBackColor = false;
      // 
      // pnlPositiveNumbers
      // 
      this.pnlPositiveNumbers.BackColor = System.Drawing.Color.Transparent;
      this.pnlPositiveNumbers.ColumnCount = 5;
      this.pnlPositiveNumbers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.pnlPositiveNumbers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.pnlPositiveNumbers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.pnlPositiveNumbers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.pnlPositiveNumbers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.pnlPositiveNumbers.Controls.Add(this.btn1, 0, 0);
      this.pnlPositiveNumbers.Controls.Add(this.btn2, 1, 0);
      this.pnlPositiveNumbers.Controls.Add(this.btn3, 2, 0);
      this.pnlPositiveNumbers.Controls.Add(this.btn4, 3, 0);
      this.pnlPositiveNumbers.Controls.Add(this.btn10, 4, 1);
      this.pnlPositiveNumbers.Controls.Add(this.btn5, 4, 0);
      this.pnlPositiveNumbers.Controls.Add(this.btn9, 3, 1);
      this.pnlPositiveNumbers.Controls.Add(this.btn6, 0, 1);
      this.pnlPositiveNumbers.Controls.Add(this.btn8, 2, 1);
      this.pnlPositiveNumbers.Controls.Add(this.btn7, 1, 1);
      this.pnlPositiveNumbers.Location = new System.Drawing.Point(18, 14);
      this.pnlPositiveNumbers.Name = "pnlPositiveNumbers";
      this.pnlPositiveNumbers.RowCount = 2;
      this.pnlPositiveNumbers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.pnlPositiveNumbers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.pnlPositiveNumbers.Size = new System.Drawing.Size(206, 70);
      this.pnlPositiveNumbers.TabIndex = 39;
      // 
      // btn1
      // 
      this.btn1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn1.BackColor = System.Drawing.Color.Transparent;
      this.btn1.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn1.Location = new System.Drawing.Point(3, 3);
      this.btn1.Name = "btn1";
      this.btn1.Size = new System.Drawing.Size(35, 29);
      this.btn1.TabIndex = 25;
      this.btn1.Text = "1";
      this.btn1.UseVisualStyleBackColor = false;
      // 
      // btn2
      // 
      this.btn2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn2.BackColor = System.Drawing.Color.Transparent;
      this.btn2.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn2.Location = new System.Drawing.Point(44, 3);
      this.btn2.Name = "btn2";
      this.btn2.Size = new System.Drawing.Size(35, 29);
      this.btn2.TabIndex = 23;
      this.btn2.Text = "2";
      this.btn2.UseVisualStyleBackColor = false;
      // 
      // btn3
      // 
      this.btn3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn3.BackColor = System.Drawing.Color.Transparent;
      this.btn3.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn3.Location = new System.Drawing.Point(85, 3);
      this.btn3.Name = "btn3";
      this.btn3.Size = new System.Drawing.Size(35, 29);
      this.btn3.TabIndex = 16;
      this.btn3.Text = "3";
      this.btn3.UseVisualStyleBackColor = false;
      // 
      // btn4
      // 
      this.btn4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn4.BackColor = System.Drawing.Color.Transparent;
      this.btn4.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn4.Location = new System.Drawing.Point(126, 3);
      this.btn4.Name = "btn4";
      this.btn4.Size = new System.Drawing.Size(35, 29);
      this.btn4.TabIndex = 17;
      this.btn4.Text = "4";
      this.btn4.UseVisualStyleBackColor = false;
      // 
      // btn10
      // 
      this.btn10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn10.BackColor = System.Drawing.Color.Transparent;
      this.btn10.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn10.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn10.Location = new System.Drawing.Point(167, 38);
      this.btn10.Name = "btn10";
      this.btn10.Size = new System.Drawing.Size(36, 29);
      this.btn10.TabIndex = 24;
      this.btn10.Text = "10";
      this.btn10.UseVisualStyleBackColor = false;
      // 
      // btn5
      // 
      this.btn5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn5.BackColor = System.Drawing.Color.Transparent;
      this.btn5.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn5.Location = new System.Drawing.Point(167, 3);
      this.btn5.Name = "btn5";
      this.btn5.Size = new System.Drawing.Size(36, 29);
      this.btn5.TabIndex = 18;
      this.btn5.Text = "5";
      this.btn5.UseVisualStyleBackColor = false;
      // 
      // btn9
      // 
      this.btn9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn9.BackColor = System.Drawing.Color.Transparent;
      this.btn9.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn9.Location = new System.Drawing.Point(126, 38);
      this.btn9.Name = "btn9";
      this.btn9.Size = new System.Drawing.Size(35, 29);
      this.btn9.TabIndex = 22;
      this.btn9.Text = "9";
      this.btn9.UseVisualStyleBackColor = false;
      // 
      // btn6
      // 
      this.btn6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn6.BackColor = System.Drawing.Color.Transparent;
      this.btn6.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn6.Location = new System.Drawing.Point(3, 38);
      this.btn6.Name = "btn6";
      this.btn6.Size = new System.Drawing.Size(35, 29);
      this.btn6.TabIndex = 19;
      this.btn6.Text = "6";
      this.btn6.UseVisualStyleBackColor = false;
      // 
      // btn8
      // 
      this.btn8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn8.BackColor = System.Drawing.Color.Transparent;
      this.btn8.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn8.Location = new System.Drawing.Point(85, 38);
      this.btn8.Name = "btn8";
      this.btn8.Size = new System.Drawing.Size(35, 29);
      this.btn8.TabIndex = 21;
      this.btn8.Text = "8";
      this.btn8.UseVisualStyleBackColor = false;
      // 
      // btn7
      // 
      this.btn7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.btn7.BackColor = System.Drawing.Color.Transparent;
      this.btn7.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btn7.Location = new System.Drawing.Point(44, 38);
      this.btn7.Name = "btn7";
      this.btn7.Size = new System.Drawing.Size(35, 29);
      this.btn7.TabIndex = 20;
      this.btn7.Text = "7";
      this.btn7.UseVisualStyleBackColor = false;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.btnCancel.BackColor = System.Drawing.Color.Transparent;
      this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCancel.Image = global::PoL.WinFormsView.Properties.Resources.stop;
      this.btnCancel.Location = new System.Drawing.Point(78, 231);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(86, 50);
      this.btnCancel.TabIndex = 38;
      this.btnCancel.Text = "CANCEL";
      this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
      this.btnCancel.UseVisualStyleBackColor = false;
      // 
      // numValue
      // 
      this.numValue.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.numValue.Location = new System.Drawing.Point(104, 101);
      this.numValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
      this.numValue.Name = "numValue";
      this.numValue.Size = new System.Drawing.Size(57, 23);
      this.numValue.TabIndex = 37;
      this.numValue.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
      // 
      // lblValue
      // 
      this.lblValue.BackColor = System.Drawing.Color.Transparent;
      this.lblValue.Location = new System.Drawing.Point(18, 106);
      this.lblValue.Name = "lblValue";
      this.lblValue.Size = new System.Drawing.Size(79, 13);
      this.lblValue.TabIndex = 36;
      this.lblValue.Text = "VALUE";
      this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // btnOk
      // 
      this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.btnOk.BackColor = System.Drawing.Color.Transparent;
      this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnOk.Location = new System.Drawing.Point(167, 101);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(44, 23);
      this.btnOk.TabIndex = 5;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = false;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
      this.tableLayoutPanel2.ColumnCount = 5;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
      this.tableLayoutPanel2.Controls.Add(this.button1, 0, 0);
      this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
      this.tableLayoutPanel2.TabIndex = 0;
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.button1.BackColor = System.Drawing.Color.Transparent;
      this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
      this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button1.Location = new System.Drawing.Point(3, 3);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(34, 94);
      this.button1.TabIndex = 25;
      this.button1.Text = "1";
      this.button1.UseVisualStyleBackColor = false;
      // 
      // button2
      // 
      this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.button2.BackColor = System.Drawing.Color.Transparent;
      this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
      this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button2.Location = new System.Drawing.Point(44, 3);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(35, 29);
      this.button2.TabIndex = 23;
      this.button2.Text = "2";
      this.button2.UseVisualStyleBackColor = false;
      // 
      // NumberInput
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackgroundImage = global::PoL.WinFormsView.Properties.Resources.darkbackground;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(246, 295);
      this.Controls.Add(this.mPanelMain);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "NumberInput";
      this.Padding = new System.Windows.Forms.Padding(2);
      this.ShowInTaskbar = false;
      this.mPanelMain.ResumeLayout(false);
      this.panelRightTop.ResumeLayout(false);
      this.pnlNegativeNumbers.ResumeLayout(false);
      this.pnlPositiveNumbers.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.numValue)).EndInit();
      this.tableLayoutPanel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel mPanelMain;
    private System.Windows.Forms.Panel panelRightTop;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btn1;
    private System.Windows.Forms.Button btn10;
    private System.Windows.Forms.Button btn2;
    private System.Windows.Forms.Button btn9;
    private System.Windows.Forms.Button btn8;
    private System.Windows.Forms.Button btn7;
    private System.Windows.Forms.Button btn6;
    private System.Windows.Forms.Button btn5;
    private System.Windows.Forms.Button btn4;
    private System.Windows.Forms.Button btn3;
    private System.Windows.Forms.NumericUpDown numValue;
    private System.Windows.Forms.Label lblValue;
    private System.Windows.Forms.TableLayoutPanel pnlPositiveNumbers;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.TableLayoutPanel pnlNegativeNumbers;
    private System.Windows.Forms.Button btn1n;
    private System.Windows.Forms.Button btn2n;
    private System.Windows.Forms.Button btn3n;
    private System.Windows.Forms.Button btn4n;
    private System.Windows.Forms.Button btn10n;
    private System.Windows.Forms.Button btn5n;
    private System.Windows.Forms.Button btn9n;
    private System.Windows.Forms.Button btn6n;
    private System.Windows.Forms.Button btn8n;
    private System.Windows.Forms.Button btn7n;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
  }
}