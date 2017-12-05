namespace FormForTanks
{
    partial class FormForTanks
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.PBForTanks = new System.Windows.Forms.PictureBox();
            this.MSForTanks = new System.Windows.Forms.MenuStrip();
            this.beginGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PBForTanks)).BeginInit();
            this.MSForTanks.SuspendLayout();
            this.SuspendLayout();
            // 
            // PBForTanks
            // 
            this.PBForTanks.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PBForTanks.Location = new System.Drawing.Point(12, 27);
            this.PBForTanks.Name = "PBForTanks";
            this.PBForTanks.Size = new System.Drawing.Size(500, 500);
            this.PBForTanks.TabIndex = 0;
            this.PBForTanks.TabStop = false;
            // 
            // MSForTanks
            // 
            this.MSForTanks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beginGameToolStripMenuItem,
            this.saveGameToolStripMenuItem,
            this.loadGameToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.pauseToolStripMenuItem});
            this.MSForTanks.Location = new System.Drawing.Point(0, 0);
            this.MSForTanks.Name = "MSForTanks";
            this.MSForTanks.Size = new System.Drawing.Size(521, 24);
            this.MSForTanks.TabIndex = 1;
            this.MSForTanks.Text = "menuStrip1";
            // 
            // beginGameToolStripMenuItem
            // 
            this.beginGameToolStripMenuItem.Name = "beginGameToolStripMenuItem";
            this.beginGameToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.beginGameToolStripMenuItem.Text = "Begin Game";
            this.beginGameToolStripMenuItem.Click += new System.EventHandler(this.beginGameToolStripMenuItem_Click);
            // 
            // saveGameToolStripMenuItem
            // 
            this.saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            this.saveGameToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.saveGameToolStripMenuItem.Text = "Save Game";
            // 
            // loadGameToolStripMenuItem
            // 
            this.loadGameToolStripMenuItem.Name = "loadGameToolStripMenuItem";
            this.loadGameToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.loadGameToolStripMenuItem.Text = "Load Game";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.pauseToolStripMenuItem.Text = "Pause";
            // 
            // FormForTanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 537);
            this.Controls.Add(this.PBForTanks);
            this.Controls.Add(this.MSForTanks);
            this.MainMenuStrip = this.MSForTanks;
            this.Name = "FormForTanks";
            this.Text = "Танчики";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormForTanks_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PBForTanks)).EndInit();
            this.MSForTanks.ResumeLayout(false);
            this.MSForTanks.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PBForTanks;
        private System.Windows.Forms.MenuStrip MSForTanks;
        private System.Windows.Forms.ToolStripMenuItem beginGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
    }
}

