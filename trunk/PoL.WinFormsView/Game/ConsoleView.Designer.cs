namespace PoL.WinFormsView.Game
{
    partial class ConsoleView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          this.pnlMain = new System.Windows.Forms.SplitContainer();
          this.messageList = new RichTextBoxLinks.RichTextBoxEx();
          this.txtChat = new System.Windows.Forms.TextBox();
          this.btnMessage2 = new System.Windows.Forms.Button();
          this.btnMessage1 = new System.Windows.Forms.Button();
          this.pnlMain.Panel1.SuspendLayout();
          this.pnlMain.Panel2.SuspendLayout();
          this.pnlMain.SuspendLayout();
          this.SuspendLayout();
          // 
          // pnlMain
          // 
          this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
          this.pnlMain.IsSplitterFixed = true;
          this.pnlMain.Location = new System.Drawing.Point(0, 0);
          this.pnlMain.Name = "pnlMain";
          this.pnlMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
          // 
          // pnlMain.Panel1
          // 
          this.pnlMain.Panel1.Controls.Add(this.messageList);
          this.pnlMain.Panel1.Controls.Add(this.txtChat);
          this.pnlMain.Panel1MinSize = 20;
          // 
          // pnlMain.Panel2
          // 
          this.pnlMain.Panel2.Controls.Add(this.btnMessage2);
          this.pnlMain.Panel2.Controls.Add(this.btnMessage1);
          this.pnlMain.Panel2MinSize = 20;
          this.pnlMain.Size = new System.Drawing.Size(230, 167);
          this.pnlMain.SplitterDistance = 140;
          this.pnlMain.SplitterWidth = 1;
          this.pnlMain.TabIndex = 8;
          // 
          // messageList
          // 
          this.messageList.Dock = System.Windows.Forms.DockStyle.Fill;
          this.messageList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.messageList.HiglightColor = RichTextBoxLinks.RtfColor.White;
          this.messageList.Location = new System.Drawing.Point(0, 0);
          this.messageList.Name = "messageList";
          this.messageList.ReadOnly = true;
          this.messageList.Size = new System.Drawing.Size(230, 120);
          this.messageList.TabIndex = 8;
          this.messageList.Text = "";
          this.messageList.TextColor = RichTextBoxLinks.RtfColor.Black;
          // 
          // txtChat
          // 
          this.txtChat.Dock = System.Windows.Forms.DockStyle.Bottom;
          this.txtChat.Location = new System.Drawing.Point(0, 120);
          this.txtChat.Name = "txtChat";
          this.txtChat.Size = new System.Drawing.Size(230, 20);
          this.txtChat.TabIndex = 9;
          // 
          // btnMessage2
          // 
          this.btnMessage2.Anchor = System.Windows.Forms.AnchorStyles.Top;
          this.btnMessage2.AutoEllipsis = true;
          this.btnMessage2.Location = new System.Drawing.Point(118, 1);
          this.btnMessage2.Name = "btnMessage2";
          this.btnMessage2.Size = new System.Drawing.Size(75, 23);
          this.btnMessage2.TabIndex = 8;
          this.btnMessage2.Text = "button2";
          this.btnMessage2.UseVisualStyleBackColor = true;
          // 
          // btnMessage1
          // 
          this.btnMessage1.Anchor = System.Windows.Forms.AnchorStyles.Top;
          this.btnMessage1.Location = new System.Drawing.Point(37, 1);
          this.btnMessage1.Name = "btnMessage1";
          this.btnMessage1.Size = new System.Drawing.Size(75, 23);
          this.btnMessage1.TabIndex = 7;
          this.btnMessage1.Text = "button1";
          this.btnMessage1.UseVisualStyleBackColor = true;
          // 
          // ConsoleView
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.pnlMain);
          this.Name = "ConsoleView";
          this.Size = new System.Drawing.Size(230, 167);
          this.pnlMain.Panel1.ResumeLayout(false);
          this.pnlMain.Panel1.PerformLayout();
          this.pnlMain.Panel2.ResumeLayout(false);
          this.pnlMain.ResumeLayout(false);
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer pnlMain;
        private System.Windows.Forms.Button btnMessage2;
        private System.Windows.Forms.Button btnMessage1;
        private RichTextBoxLinks.RichTextBoxEx messageList;
        private System.Windows.Forms.TextBox txtChat;

    }
}
