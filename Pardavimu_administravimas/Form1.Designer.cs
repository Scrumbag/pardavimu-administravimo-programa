﻿
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
            this.pasirinkiteKlienta = new System.Windows.Forms.ComboBox();
            this.uzrasasAgentura = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.failasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.išeitiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aprašymasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kontaktaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagalbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasirinkiteAgenta = new System.Windows.Forms.ComboBox();
            this.uzrasasAgentas = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pasirinkiteKrypti = new System.Windows.Forms.ComboBox();
            this.Country = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pasirinkiteKlienta
            // 
            this.pasirinkiteKlienta.FormattingEnabled = true;
            this.pasirinkiteKlienta.Location = new System.Drawing.Point(12, 82);
            this.pasirinkiteKlienta.Name = "pasirinkiteKlienta";
            this.pasirinkiteKlienta.Size = new System.Drawing.Size(139, 21);
            this.pasirinkiteKlienta.TabIndex = 0;
            // 
            // uzrasasAgentura
            // 
            this.uzrasasAgentura.AutoSize = true;
            this.uzrasasAgentura.Location = new System.Drawing.Point(12, 66);
            this.uzrasasAgentura.Name = "uzrasasAgentura";
            this.uzrasasAgentura.Size = new System.Drawing.Size(89, 13);
            this.uzrasasAgentura.TabIndex = 1;
            this.uzrasasAgentura.Text = "Pasirinkite klientą";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failasToolStripMenuItem,
            this.aprašymasToolStripMenuItem,
            this.kontaktaiToolStripMenuItem,
            this.pagalbaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(922, 24);
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
            // aprašymasToolStripMenuItem
            // 
            this.aprašymasToolStripMenuItem.Name = "aprašymasToolStripMenuItem";
            this.aprašymasToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.aprašymasToolStripMenuItem.Text = "Aprašymas";
            this.aprašymasToolStripMenuItem.Click += new System.EventHandler(this.aprašymasToolStripMenuItem_Click);
            // 
            // kontaktaiToolStripMenuItem
            // 
            this.kontaktaiToolStripMenuItem.Name = "kontaktaiToolStripMenuItem";
            this.kontaktaiToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.kontaktaiToolStripMenuItem.Text = "Kontaktai";
            this.kontaktaiToolStripMenuItem.Click += new System.EventHandler(this.kontaktaiToolStripMenuItem_Click);
            // 
            // pagalbaToolStripMenuItem
            // 
            this.pagalbaToolStripMenuItem.Name = "pagalbaToolStripMenuItem";
            this.pagalbaToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.pagalbaToolStripMenuItem.Text = "Pagalba";
            this.pagalbaToolStripMenuItem.Click += new System.EventHandler(this.pagalbaToolStripMenuItem_Click);
            // 
            // pasirinkiteAgenta
            // 
            this.pasirinkiteAgenta.FormattingEnabled = true;
            this.pasirinkiteAgenta.Location = new System.Drawing.Point(12, 134);
            this.pasirinkiteAgenta.Name = "pasirinkiteAgenta";
            this.pasirinkiteAgenta.Size = new System.Drawing.Size(139, 21);
            this.pasirinkiteAgenta.TabIndex = 4;
            this.pasirinkiteAgenta.SelectedIndexChanged += new System.EventHandler(this.pasirinkiteAgenta_SelectedIndexChanged);
            // 
            // uzrasasAgentas
            // 
            this.uzrasasAgentas.AutoSize = true;
            this.uzrasasAgentas.Location = new System.Drawing.Point(9, 118);
            this.uzrasasAgentas.Name = "uzrasasAgentas";
            this.uzrasasAgentas.Size = new System.Drawing.Size(91, 13);
            this.uzrasasAgentas.TabIndex = 5;
            this.uzrasasAgentas.Text = "Pasirinkite agentą";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(70, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Ieškoti...";
            // 
            // pasirinkiteKrypti
            // 
            this.pasirinkiteKrypti.FormattingEnabled = true;
            this.pasirinkiteKrypti.Location = new System.Drawing.Point(12, 193);
            this.pasirinkiteKrypti.Name = "pasirinkiteKrypti";
            this.pasirinkiteKrypti.Size = new System.Drawing.Size(139, 21);
            this.pasirinkiteKrypti.TabIndex = 7;
            // 
            // Country
            // 
            this.Country.AutoSize = true;
            this.Country.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Country.Location = new System.Drawing.Point(12, 174);
            this.Country.Name = "Country";
            this.Country.Size = new System.Drawing.Size(83, 13);
            this.Country.TabIndex = 8;
            this.Country.Text = "Pasirinkite kryptį";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Pardavimu_administravimas.Properties.Resources.planeIconv2;
            this.pictureBox1.Location = new System.Drawing.Point(15, 418);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "0.0.1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 41);
            this.button1.TabIndex = 11;
            this.button1.Text = "Suformuoti ataskaitą";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(176, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(734, 388);
            this.dataGridView1.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Country);
            this.Controls.Add(this.pasirinkiteKrypti);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.uzrasasAgentas);
            this.Controls.Add(this.pasirinkiteAgenta);
            this.Controls.Add(this.uzrasasAgentura);
            this.Controls.Add(this.pasirinkiteKlienta);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Pardavimų administravimas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox pasirinkiteKlienta;
        private System.Windows.Forms.Label uzrasasAgentura;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem išeitiToolStripMenuItem;
        private System.Windows.Forms.ComboBox pasirinkiteAgenta;
        private System.Windows.Forms.Label uzrasasAgentas;
        private System.Windows.Forms.ToolStripMenuItem aprašymasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kontaktaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagalbaToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox pasirinkiteKrypti;
        private System.Windows.Forms.Label Country;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

