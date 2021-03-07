
namespace Pardavimu_administravimas
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pasirinkimasAgentura = new System.Windows.Forms.ComboBox();
            this.uzrasasAgentura = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.failasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.išeitiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pasirinkimasAgentura
            // 
            this.pasirinkimasAgentura.FormattingEnabled = true;
            this.pasirinkimasAgentura.Location = new System.Drawing.Point(12, 82);
            this.pasirinkimasAgentura.Name = "pasirinkimasAgentura";
            this.pasirinkimasAgentura.Size = new System.Drawing.Size(139, 21);
            this.pasirinkimasAgentura.TabIndex = 0;
            // 
            // uzrasasAgentura
            // 
            this.uzrasasAgentura.AutoSize = true;
            this.uzrasasAgentura.Location = new System.Drawing.Point(12, 66);
            this.uzrasasAgentura.Name = "uzrasasAgentura";
            this.uzrasasAgentura.Size = new System.Drawing.Size(139, 13);
            this.uzrasasAgentura.TabIndex = 1;
            this.uzrasasAgentura.Text = "Pasirinkite kelionių agentūrą";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // failasToolStripMenuItem
            // 
            this.failasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.išeitiToolStripMenuItem});
            this.failasToolStripMenuItem.Name = "failasToolStripMenuItem";
            this.failasToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.failasToolStripMenuItem.Text = "Failas";
            // 
            // išeitiToolStripMenuItem
            // 
            this.išeitiToolStripMenuItem.Name = "išeitiToolStripMenuItem";
            this.išeitiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.išeitiToolStripMenuItem.Text = "Išeiti";
            this.išeitiToolStripMenuItem.Click += new System.EventHandler(this.išeitiToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uzrasasAgentura);
            this.Controls.Add(this.pasirinkimasAgentura);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox pasirinkimasAgentura;
        private System.Windows.Forms.Label uzrasasAgentura;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem išeitiToolStripMenuItem;
    }
}

