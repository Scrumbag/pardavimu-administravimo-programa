using MySql.Data.MySqlClient;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string klaidos = "";
            bool buvoKlaidu = false;

            if (textBox1.Text.Trim() == "")
            {
                klaidos += "Kelionės kryptis nebuvo įrašytas \n";
                buvoKlaidu = true;
            }

            if (buvoKlaidu == false)
            {
                MySqlConnection con = new MySqlConnection(@"server=46.17.175.136;database=u682536470_keliones;userid=u682536470_agentura;password=B#u^4E|l2;");
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                string query = "INSERT INTO KELIONES_KRYPTIS (salis, fk_AGENTURAid_AGENTURA) VALUES ('" + textBox1.Text + "', '1')";
                cmd.CommandText = query;
                MySqlDataReader sdr = cmd.ExecuteReader();
                MessageBox.Show("Kelionės kryptis pridėta sėkmingai!", "");
            }
            else
            {
                MessageBox.Show(klaidos, "Klaida!");
            }
        }
    }
}
