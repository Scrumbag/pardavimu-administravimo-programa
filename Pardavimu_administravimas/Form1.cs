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

        private void aprašymasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string aprasymas = "Programa kaupia duomenis apie klientus (fiziniai/juridiniai asmenys), parduodamus produktus, bei įvykdytus užsakymus.\nGali suformuoti ataskaitą, kuri parodo kiek produkcijos klientas yra pirkęs, kiek produkcijos darbuotojas yra pardavęs ir uždirbęs bei kiek kelionių tam tikra kryptimi buvo parduota.\n\nProgramą kūrė: *šią informaciją galite sužinoti nuėję į kontaktų skiltį*";
            MessageBox.Show(aprasymas, "Programos aprašymas");
        }

        private void kontaktaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string kontaktai = "Dmitrij Zubko IFIN-9/2 dmizub@ktu.lt\nGediminas Mažeika IFIN-9/2 gedmaz4@ktu.lt\nEvaldas Liutkus IFIN-9/2 evaliu@ktu.lt\nRokas Eitavičius IFIN-9/2 rokeit@ktu.lt\nRokas Beniušis IFIN-9/2 rokben1@ktu.lt";
            MessageBox.Show(kontaktai, "Kontaktai");
        }

        private void pagalbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pagalba = "Programos naudojimas:\n\n" +
                             "• Lentelę galima surikiuoti pagal kiekvieną iš lentelės stulpelių ant jo paspaudus.\n• Naudojant paieškos lauką galima susirasti reikiamą duomenį.\n• Lentelę taip pat galima filtruoti pagal klientą, agentą ir kryptį naudojant pasirinkimus lentelės kairėje.\n• Norint išvalyti filtravimą spauskite 'Kelionių duomenys' mygtuką.\n• Norint suformuoti ataskaitą spauskite 'Suformuoti ataskaitą' mygtuką ir iššokusioje formoje pasirinkite kokią ataskaitą formuoti norite.\n• Daugiau apie programą galite sužinoti paspaudę 'Aprašymas' meniu punktą.\n• Daugiau apie programos autorius galite sužinoti paspaudę 'Kontaktai' meniu punktą.";
            MessageBox.Show(pagalba, "Pagalba");
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
                                  "KELIONE.data AS Data," +
                                  "CONCAT(DARBUOTOJAS.vardas, ' ', DARBUOTOJAS.pavarde) AS Agentas," +
                                  "CONCAT(KLIENTAS.vardas, ' ', KLIENTAS.pavarde) AS Klientas " +
                           "FROM KELIONE INNER JOIN KELIONES_KRYPTIS ON KELIONE.fk_KELIONES_KRYPTISid_KELIONES_KRYPTIS = KELIONES_KRYPTIS.id_KELIONES_KRYPTIS " +
                                        "INNER JOIN DARBUOTOJAS ON KELIONE.fk_DARBUOTOJASid_DARBUOTOJAS = DARBUOTOJAS.id_DARBUOTOJAS " +
                                        "INNER JOIN KLIENTAS ON KELIONE.fk_KLIENTASid_KLIENTAS = KLIENTAS.id_KLIENTAS " +
                           "ORDER BY KELIONE.id_KELIONE asc";
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
            con.Close();

            return dt;
        }

        private void pasirinkiteAgenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(@"server=46.17.175.136;database=u682536470_keliones;userid=u682536470_agentura;password=B#u^4E|l2;");
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            pasirinkiteKlienta.ResetText();
            pasirinkiteKrypti.ResetText();
            string pavarde = pasirinkiteAgenta.GetItemText(this.pasirinkiteAgenta.SelectedItem);
            string query = "SELECT KELIONE.id_KELIONE AS Numeris," +
                                  "KELIONE.miestas AS Miestas," +
                                  "KELIONE.kaina_keleiviui AS 'Kaina keleiviui'," +
                                  "KELIONE.keleiviu_kiekis AS 'Keleivių kiekis'," +
                                  "KELIONE.data AS Data," +
                                  "CONCAT(DARBUOTOJAS.vardas, ' ', DARBUOTOJAS.pavarde) AS Agentas," +
                                  "CONCAT(KLIENTAS.vardas, ' ', KLIENTAS.pavarde) AS Klientas," +
                                  "KELIONES_KRYPTIS.salis AS Šalis " +
                           "FROM KELIONE INNER JOIN KELIONES_KRYPTIS ON KELIONE.fk_KELIONES_KRYPTISid_KELIONES_KRYPTIS = KELIONES_KRYPTIS.id_KELIONES_KRYPTIS " +
                                        "INNER JOIN DARBUOTOJAS ON KELIONE.fk_DARBUOTOJASid_DARBUOTOJAS = DARBUOTOJAS.id_DARBUOTOJAS " +
                                        "INNER JOIN KLIENTAS ON KELIONE.fk_KLIENTASid_KLIENTAS = KLIENTAS.id_KLIENTAS " +
                           "WHERE DARBUOTOJAS.pavarde = " + "'" + pavarde + "' " +
                           "ORDER BY KELIONE.id_KELIONE asc";
            cmd.CommandText = query;
            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void pasirinkiteKlienta_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(@"server=46.17.175.136;database=u682536470_keliones;userid=u682536470_agentura;password=B#u^4E|l2;");
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            pasirinkiteAgenta.ResetText();
            pasirinkiteKrypti.ResetText();
            string pavarde = pasirinkiteKlienta.GetItemText(this.pasirinkiteKlienta.SelectedItem);
            string query = "SELECT KELIONE.id_KELIONE AS Numeris," +
                                  "KELIONE.miestas AS Miestas," +
                                  "KELIONE.kaina_keleiviui AS 'Kaina keleiviui'," +
                                  "KELIONE.keleiviu_kiekis AS 'Keleivių kiekis'," +
                                  "KELIONE.data AS Data," +
                                  "CONCAT(DARBUOTOJAS.vardas, ' ', DARBUOTOJAS.pavarde) AS Agentas," +
                                  "CONCAT(KLIENTAS.vardas, ' ', KLIENTAS.pavarde) AS Klientas," +
                                  "KELIONES_KRYPTIS.salis AS Šalis " +
                           "FROM KELIONE INNER JOIN KELIONES_KRYPTIS ON KELIONE.fk_KELIONES_KRYPTISid_KELIONES_KRYPTIS = KELIONES_KRYPTIS.id_KELIONES_KRYPTIS " +
                                        "INNER JOIN DARBUOTOJAS ON KELIONE.fk_DARBUOTOJASid_DARBUOTOJAS = DARBUOTOJAS.id_DARBUOTOJAS " +
                                        "INNER JOIN KLIENTAS ON KELIONE.fk_KLIENTASid_KLIENTAS = KLIENTAS.id_KLIENTAS " +
                           "WHERE KLIENTAS.pavarde = " + "'" + pavarde + "' " +
                           "ORDER BY KELIONE.id_KELIONE asc";
            cmd.CommandText = query;
            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void pasirinkiteKrypti_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(@"server=46.17.175.136;database=u682536470_keliones;userid=u682536470_agentura;password=B#u^4E|l2;");
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            pasirinkiteKlienta.ResetText();
            pasirinkiteAgenta.ResetText();
            string salis = pasirinkiteKrypti.GetItemText(this.pasirinkiteKrypti.SelectedItem);
            string query = "SELECT KELIONE.id_KELIONE AS Numeris," +
                                  "KELIONE.miestas AS Miestas," +
                                  "KELIONE.kaina_keleiviui AS 'Kaina keleiviui'," +
                                  "KELIONE.keleiviu_kiekis AS 'Keleivių kiekis'," +
                                  "KELIONE.data AS Data," +
                                  "CONCAT(DARBUOTOJAS.vardas, ' ', DARBUOTOJAS.pavarde) AS Agentas," +
                                  "CONCAT(KLIENTAS.vardas, ' ', KLIENTAS.pavarde) AS Klientas," +
                                  "KELIONES_KRYPTIS.salis AS Šalis " +
                           "FROM KELIONE INNER JOIN KELIONES_KRYPTIS ON KELIONE.fk_KELIONES_KRYPTISid_KELIONES_KRYPTIS = KELIONES_KRYPTIS.id_KELIONES_KRYPTIS " +
                                        "INNER JOIN DARBUOTOJAS ON KELIONE.fk_DARBUOTOJASid_DARBUOTOJAS = DARBUOTOJAS.id_DARBUOTOJAS " +
                                        "INNER JOIN KLIENTAS ON KELIONE.fk_KLIENTASid_KLIENTAS = KLIENTAS.id_KLIENTAS " +
                           "WHERE KELIONES_KRYPTIS.salis = " + "'" + salis + "' " +
                           "ORDER BY KELIONE.id_KELIONE asc";
            cmd.CommandText = query;
            MySqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pasirinkiteKlienta.ResetText();
            pasirinkiteAgenta.ResetText();
            pasirinkiteKrypti.ResetText();
            dataGridView1.DataSource = GetList();
        }

        private void pridėtiDarbuotojąToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 darbPridejimas = new Form3();
            darbPridejimas.ShowDialog();
        }

        private void pridėtiKelioniųKryptįToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 kryptiesPridejimas = new Form2();
            kryptiesPridejimas.ShowDialog();
        }
    }
}
