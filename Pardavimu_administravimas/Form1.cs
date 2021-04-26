using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Pardavimu_administravimas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void išeitiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aprašymasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            popupForm aprasymasForm = new popupForm();
            aprasymasForm.Text = "Aprašymas";
            aprasymasForm.LabelText = "Programa kaupia duomenis apie klientus (fiziniai/juridiniai asmenys), parduodamus produktus, bei įvykdytus užsakymus. Gali suformuoti ataskaitą, kuri parodo kiek produkcijos kuris klientas yra pirkęs ir kiek kuris darbuotojas yra pardavęs.";
            aprasymasForm.ShowDialog();
        }

        private void kontaktaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            popupForm kontaktaiForm = new popupForm();
            kontaktaiForm.Text = "Kontaktai";
            kontaktaiForm.LabelText = "Dmitrij Zubko IFIN-9/2 dmizub@ktu.lt\nGediminas Mažeika IFIN-9/2 gedmaz@ktu.lt\nEvaldas Liutkus IFIN-9/2 evaliu@ktu.lt\nRokas Eitavičius IFIN-9/2 rokeit@ktu.lt\nRokas Beniušis IFIN-9/2 rokben@ktu.lt";
            kontaktaiForm.ShowDialog();
        }

        private void pagalbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            popupForm pagalbaForm = new popupForm();
            pagalbaForm.Text = "Pagalba";
            pagalbaForm.LabelText = "Norėdami sužinoti ką daro programa spauskite 'Aprašymas'.";
            pagalbaForm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetList();
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[6].Width = 130;
        }
        private DataTable GetList()
        {
            MySqlConnection con = new MySqlConnection(@"server=46.17.175.136;database=u682536470_keliones;userid=u682536470_agentura;password=B#u^4E|l2;");
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            string query = "SELECT KELIONE.id_KELIONE AS Numeris," +
                                  "KELIONES_KRYPTIS.salis AS Šalis," +
                                  "KELIONE.miestas AS Miestas," +
                                  "KELIONE.kaina_keleiviui AS 'Bilieto kaina'," +
                                  "KELIONE.keleiviu_kiekis AS 'Keleivių kiekis'," +
                                  "CONCAT(DARBUOTOJAS.vardas, ' ', DARBUOTOJAS.pavarde) AS Agentas," +
                                  "CONCAT(KLIENTAS.vardas, ' ', KLIENTAS.pavarde) AS Klientas " +
                           "FROM KELIONE INNER JOIN KELIONES_KRYPTIS ON KELIONE.fk_KELIONES_KRYPTISid_KELIONES_KRYPTIS = KELIONES_KRYPTIS.id_KELIONES_KRYPTIS " +
                                        "INNER JOIN DARBUOTOJAS ON KELIONE.fk_DARBUOTOJASid_DARBUOTOJAS = DARBUOTOJAS.id_DARBUOTOJAS " +
                                        "INNER JOIN KLIENTAS ON KELIONE.fk_KLIENTASid_KLIENTAS = KLIENTAS.id_KLIENTAS";
            cmd.CommandText = query;
            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);

            MySqlCommand fillAgentas = new MySqlCommand("SELECT * FROM DARBUOTOJAS", con);
            MySqlDataReader cmbAgentas = fillAgentas.ExecuteReader();
            while (cmbAgentas.Read())
                pasirinkiteAgenta.Items.Add(cmbAgentas["pavarde"].ToString());
            cmbAgentas.Close();

            MySqlCommand fillKlientas = new MySqlCommand("SELECT * FROM KLIENTAS", con);
            MySqlDataReader cmbKlientas = fillKlientas.ExecuteReader();
            while (cmbKlientas.Read())
                pasirinkiteKlienta.Items.Add(cmbKlientas["pavarde"].ToString());
            cmbKlientas.Close();

            MySqlCommand fillKryptis = new MySqlCommand("SELECT * FROM KELIONES_KRYPTIS", con);
            MySqlDataReader cmbKryptis = fillKryptis.ExecuteReader();
            while (cmbKryptis.Read())
                pasirinkiteKrypti.Items.Add(cmbKryptis["salis"].ToString());
            cmbKlientas.Close();


            return dt;
        }

        private void pasirinkiteAgenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
