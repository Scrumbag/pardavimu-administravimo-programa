
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
            this.testMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testTripsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testTripsDestinationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testAgencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.uzrasasAgentas = new System.Windows.Forms.Label();
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
            this.failasToolStripMenuItem,
            this.testMenuToolStripMenuItem});
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
            this.išeitiToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.išeitiToolStripMenuItem.Text = "Išeiti";
            this.išeitiToolStripMenuItem.Click += new System.EventHandler(this.išeitiToolStripMenuItem_Click);
            // 
            // testMenuToolStripMenuItem
            // 
            this.testMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testEmployeeToolStripMenuItem,
            this.testTripsToolStripMenuItem,
            this.testTripsDestinationToolStripMenuItem,
            this.testClientToolStripMenuItem,
            this.testAgencyToolStripMenuItem});
            this.testMenuToolStripMenuItem.Name = "testMenuToolStripMenuItem";
            this.testMenuToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.testMenuToolStripMenuItem.Text = "TestMenu";
            // 
            // testEmployeeToolStripMenuItem
            // 
            this.testEmployeeToolStripMenuItem.Name = "testEmployeeToolStripMenuItem";
            this.testEmployeeToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.testEmployeeToolStripMenuItem.Text = "TestEmployee";
            this.testEmployeeToolStripMenuItem.Click += new System.EventHandler(this.testEmployeeToolStripMenuItem_Click);
            // 
            // testTripsToolStripMenuItem
            // 
            this.testTripsToolStripMenuItem.Name = "testTripsToolStripMenuItem";
            this.testTripsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.testTripsToolStripMenuItem.Text = "TestTrips";
            this.testTripsToolStripMenuItem.Click += new System.EventHandler(this.testTripsToolStripMenuItem_Click);
            // 
            // testTripsDestinationToolStripMenuItem
            // 
            this.testTripsDestinationToolStripMenuItem.Name = "testTripsDestinationToolStripMenuItem";
            this.testTripsDestinationToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.testTripsDestinationToolStripMenuItem.Text = "TestTripsDestination";
            this.testTripsDestinationToolStripMenuItem.Click += new System.EventHandler(this.testTripsDestinationToolStripMenuItem_Click);
            // 
            // testClientToolStripMenuItem
            // 
            this.testClientToolStripMenuItem.Name = "testClientToolStripMenuItem";
            this.testClientToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.testClientToolStripMenuItem.Text = "TestClient";
            this.testClientToolStripMenuItem.Click += new System.EventHandler(this.testClientToolStripMenuItem_Click);
            // 
            // testAgencyToolStripMenuItem
            // 
            this.testAgencyToolStripMenuItem.Name = "testAgencyToolStripMenuItem";
            this.testAgencyToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.testAgencyToolStripMenuItem.Text = "TestAgency";
            this.testAgencyToolStripMenuItem.Click += new System.EventHandler(this.testAgencyToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(176, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(596, 411);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 134);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(139, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // uzrasasAgentas
            // 
            this.uzrasasAgentas.AutoSize = true;
            this.uzrasasAgentas.Location = new System.Drawing.Point(12, 118);
            this.uzrasasAgentas.Name = "uzrasasAgentas";
            this.uzrasasAgentas.Size = new System.Drawing.Size(91, 13);
            this.uzrasasAgentas.TabIndex = 5;
            this.uzrasasAgentas.Text = "Pasirinkite agentą";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uzrasasAgentas);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.richTextBox1);
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
        private System.Windows.Forms.ToolStripMenuItem testMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testEmployeeToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem testTripsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testTripsDestinationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testAgencyToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label uzrasasAgentas;
    }
}

