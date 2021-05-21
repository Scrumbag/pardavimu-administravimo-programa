using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pardavimu_administravimas
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void klientubutton_Click(object sender, EventArgs e)
        {
            Form1 klientuAt = new Form1();
            klientuAt.klientuAtaskaita();
        }

        private void darbuotojubutton_Click(object sender, EventArgs e)
        {
            Form1 darbuotojuAt = new Form1();
            darbuotojuAt.darbuotojuAtaskaita();
        }

        private void kryptisbutton_Click(object sender, EventArgs e)
        {
            Form1 krypciuAt = new Form1();
            krypciuAt.krypciuAtaskaita();
        }
    }
}
