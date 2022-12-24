namespace PlatformerGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslblFrame = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblElapsed = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblFps = new System.Windows.Forms.ToolStripStatusLabel();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblFrame,
            this.tslblElapsed,
            this.tslblFps});
            this.statusStrip1.Location = new System.Drawing.Point(0, 634);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1756, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslblFrame
            // 
            this.tslblFrame.Name = "tslblFrame";
            this.tslblFrame.Size = new System.Drawing.Size(62, 17);
            this.tslblFrame.Text = "tslblFrame";
            this.tslblFrame.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // tslblElapsed
            // 
            this.tslblElapsed.Name = "tslblElapsed";
            this.tslblElapsed.Size = new System.Drawing.Size(69, 17);
            this.tslblElapsed.Text = "tslblElapsed";
            // 
            // tslblFps
            // 
            this.tslblFps.Name = "tslblFps";
            this.tslblFps.Size = new System.Drawing.Size(118, 17);
            this.tslblFps.Text = "toolStripStatusLabel1";
            // 
            // rtbLog
            // 
            this.rtbLog.Enabled = false;
            this.rtbLog.Location = new System.Drawing.Point(1351, 12);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(393, 606);
            this.rtbLog.TabIndex = 1;
            this.rtbLog.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1756, 656);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tslblFrame;
        private ToolStripStatusLabel tslblElapsed;
        private ToolStripStatusLabel tslblFps;
        private RichTextBox rtbLog;
    }
}