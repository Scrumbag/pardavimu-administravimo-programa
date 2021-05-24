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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void sudarytiButton_Click(object sender, EventArgs e)
        {
            Form1 darbuotojuAt = new Form1();
            string dateFrom = dateTimePicker1.Value.Date.ToString();
            string dateTo = dateTimePicker2.Value.Date.ToString();
            darbuotojuAt.darbuotojuAtaskaita(dateFrom, dateTo);
        }
    }
}
