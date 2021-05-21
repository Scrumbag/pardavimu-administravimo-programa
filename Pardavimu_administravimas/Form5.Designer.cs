
namespace Pardavimu_administravimas
{
    partial class Form5
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
            this.title = new System.Windows.Forms.Label();
            this.klientubutton = new System.Windows.Forms.Button();
            this.darbuotojubutton = new System.Windows.Forms.Button();
            this.kryptisbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(11, 24);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(272, 29);
            this.title.TabIndex = 0;
            this.title.Text = "Ataskaitos formavimas";
            // 
            // klientubutton
            // 
            this.klientubutton.Location = new System.Drawing.Point(21, 65);
            this.klientubutton.Name = "klientubutton";
            this.klientubutton.Size = new System.Drawing.Size(72, 64);
            this.klientubutton.TabIndex = 1;
            this.klientubutton.Text = "Klientų ataskaita";
            this.klientubutton.UseVisualStyleBackColor = true;
            this.klientubutton.Click += new System.EventHandler(this.klientubutton_Click);
            // 
            // darbuotojubutton
            // 
            this.darbuotojubutton.Location = new System.Drawing.Point(110, 65);
            this.darbuotojubutton.Name = "darbuotojubutton";
            this.darbuotojubutton.Size = new System.Drawing.Size(72, 64);
            this.darbuotojubutton.TabIndex = 2;
            this.darbuotojubutton.Text = "Darbuotojų ataskaita";
            this.darbuotojubutton.UseVisualStyleBackColor = true;
            this.darbuotojubutton.Click += new System.EventHandler(this.darbuotojubutton_Click);
            // 
            // kryptisbutton
            // 
            this.kryptisbutton.Location = new System.Drawing.Point(199, 65);
            this.kryptisbutton.Name = "kryptisbutton";
            this.kryptisbutton.Size = new System.Drawing.Size(72, 64);
            this.kryptisbutton.TabIndex = 3;
            this.kryptisbutton.Text = "Krypčių ataskaita";
            this.kryptisbutton.UseVisualStyleBackColor = true;
            this.kryptisbutton.Click += new System.EventHandler(this.kryptisbutton_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 165);
            this.Controls.Add(this.kryptisbutton);
            this.Controls.Add(this.darbuotojubutton);
            this.Controls.Add(this.klientubutton);
            this.Controls.Add(this.title);
            this.Name = "Form5";
            this.Text = "Form5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button klientubutton;
        private System.Windows.Forms.Button darbuotojubutton;
        private System.Windows.Forms.Button kryptisbutton;
    }
}