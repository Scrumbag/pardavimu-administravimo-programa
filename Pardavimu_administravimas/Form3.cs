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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void pridetiAgentaB_Click(object sender, EventArgs e)
        {
            string klaidos = "";
            bool buvoKlaidu = false;

            if (Vardas.Text.Trim() == "")
            {
                klaidos+="Vardas nebuvo įrašytas \n";
                buvoKlaidu = true;
            }
            if (Pavarde.Text.Trim() == "")
            {
                klaidos += "Pavardė nebuvo įrašytas \n";
                buvoKlaidu = true;
            }
            if (elPastas.Text.Trim() == "")
            {
                klaidos += "El.Paštas nebuvo įrašytas \n";
                buvoKlaidu = true;
            }
            if (Telefonas.Text.Trim() == "")
            {
                klaidos += "Telefonas nebuvo įrašytas \n";
                buvoKlaidu = true;
            }
            if (pardavimuKiekis.Text.Trim() == "")
            {
                klaidos += "Pardavimų kiekis nebuvo įrašytas \n";
                buvoKlaidu = true;
            }
            if (Pelnas.Text.Trim() == "")
            {
                klaidos += "Pelnas nebuvo įrašytas \n";
                buvoKlaidu = true;
            }

            if (buvoKlaidu == false)
            {
                MySqlConnection con = new MySqlConnection(@"server=46.17.175.136;database=u682536470_keliones;userid=u682536470_agentura;password=B#u^4E|l2;");
                con.Open();
                MySqlCommand cmd;
                cmd = con.CreateCommand();
                string query = "INSERT INTO DARBUOTOJAS (el_pastas, vardas, pavarde, telefonas, pardavimu_kiekis, pelnas, fk_AGENTURAid_AGENTURA) VALUES ('" + elPastas.Text + "', '" + Vardas.Text + "', '" + Pavarde.Text + "', '" + Telefonas.Text + "', '" + pardavimuKiekis.Text + "', '" + Pelnas.Text + "', '1')";
                cmd.CommandText = query;
                MySqlDataReader sdr = cmd.ExecuteReader();
                Form1 f1 = new Form1();
                f1.atnaujintiAgentus();
                MessageBox.Show("Darbuotojas pridėtas sėkmingai!", "");
            }
            else {
                MessageBox.Show(klaidos, "Klaida!");
            }
        }
    }
}
