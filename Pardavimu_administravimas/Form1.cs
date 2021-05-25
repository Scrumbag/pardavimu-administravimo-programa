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
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;

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
                             "• Lentelę galima surikiuoti pagal kiekvieną iš lentelės stulpelių ant jo paspaudus.\n• Naudojant paieškos lauką galima surasti informaciją apie keliones pagal nurodytą data.\n• Lentelę taip pat galima filtruoti pagal klientą, agentą ir kryptį naudojant pasirinkimus lentelės kairėje.\n• Norint išvalyti filtravimą spauskite 'Kelionių duomenys' mygtuką.\n• Norint suformuoti ataskaitą spauskite 'Suformuoti ataskaitą' mygtuką ir iššokusioje formoje pasirinkite kokią ataskaitą formuoti norite.\n• Norint pridėti darbuotoją ar kelionių kryptį, spauskite meniu punktą pridėti ir pasirinkite. Pridėjus duomenį spausti mygtuką 'Kelionių duomenys' tam, kad atsinaujintų duomenų atvaizdavimas.\n• Daugiau apie programą galite sužinoti paspaudę 'Aprašymas' meniu punktą.\n• Daugiau apie programos autorius galite sužinoti paspaudę 'Kontaktai' meniu punktą.";
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
                                  "KELIONE.data AS 'Kelionės data'," +
                                  "KELIONE.uzsakymo_data AS 'Užsakymo data'," +
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
                                  "KELIONE.kaina_keleiviui AS 'Bilieto kaina'," +
                                  "KELIONE.keleiviu_kiekis AS 'Keleivių kiekis'," +
                                  "KELIONE.data AS 'Kelionės data'," +
                                  "KELIONE.uzsakymo_data AS 'Užsakymo data'," +
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
                                  "KELIONE.kaina_keleiviui AS 'Bilieto kaina'," +
                                  "KELIONE.keleiviu_kiekis AS 'Keleivių kiekis'," +
                                  "KELIONE.data AS 'Kelionės data'," +
                                  "KELIONE.uzsakymo_data AS 'Užsakymo data'," +
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
                                  "KELIONE.kaina_keleiviui AS 'Bilieto kaina'," +
                                  "KELIONE.keleiviu_kiekis AS 'Keleivių kiekis'," +
                                  "KELIONE.data AS 'Kelionės data'," +
                                  "KELIONE.uzsakymo_data AS 'Užsakymo data'," +
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
            pasirinkiteKlienta.Items.Clear();
            pasirinkiteAgenta.Items.Clear();
            pasirinkiteKrypti.Items.Clear();
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

        public void atnaujintiAgentus()
        {
            pasirinkiteAgenta.Items.Clear();
            MySqlConnection con = new MySqlConnection(@"server=46.17.175.136;database=u682536470_keliones;userid=u682536470_agentura;password=B#u^4E|l2;");
            con.Open();

            MySqlCommand fillAgentas = new MySqlCommand("SELECT * FROM DARBUOTOJAS", con);
            MySqlDataReader cmbAgentas = fillAgentas.ExecuteReader();
            while (cmbAgentas.Read())
            {
                pasirinkiteAgenta.Items.Add(cmbAgentas["pavarde"].ToString());
            }
            cmbAgentas.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 ataskFormavimas = new Form5();
            ataskFormavimas.ShowDialog();
        }

        public void klientuAtaskaita()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataSet ds = new DataSet();
                string query = null;
                int i = 0;
                int yPoint = 0;
                string vardas = null;
                string pavarde = null;
                string kelioniu_sk = null;
                MySqlConnection con = new MySqlConnection(@"server=46.17.175.136;database=u682536470_keliones;userid=u682536470_agentura;password=B#u^4E|l2;");
                con.Open();
                MySqlCommand cmd;
                //cmd = con.CreateCommand();
                query = "   SELECT KLIENTAS.vardas AS Vardas," +
                                  "KLIENTAS.pavarde AS Pavardė," +
                                  "COUNT(KELIONE.id_KELIONE) AS 'Kelionių skaičius' " +
                           "FROM KLIENTAS INNER JOIN KELIONE ON KLIENTAS.id_KLIENTAS = KELIONE.fk_KLIENTASid_KLIENTAS " +
                           "GROUP BY KLIENTAS.id_KLIENTAS ORDER BY `Kelionių skaičius` DESC";
                cmd = new MySqlCommand(query, con);
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                //cmd.CommandText = query;
                con.Close();

                PdfDocument pdf = new PdfDocument();
                pdf.Info.Title = "Klientų ataskaita";
                PdfPage pdfPage = pdf.AddPage();
                XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                XFont font = new XFont("Verdana", 15, XFontStyle.Regular);
                XFont heading = new XFont("Verdana", 25, XFontStyle.BoldItalic);
                XFont subHeading = new XFont("Verdana", 20, XFontStyle.Bold);
                XFont date = new XFont("Verdana", 10, XFontStyle.Regular);

                graph.DrawString("Klientų ataskaita", heading, XBrushes.Black, new XRect(285, 20, pdfPage.Width.Centimeter, pdfPage.Height.Centimeter), XStringFormats.Center);
                graph.DrawString("Vardas", subHeading, XBrushes.Black, new XRect(40, 80, pdfPage.Width.Centimeter, pdfPage.Height.Centimeter), XStringFormats.TopLeft);
                graph.DrawString("Pavardė", subHeading, XBrushes.Black, new XRect(240, 80, pdfPage.Width.Centimeter, pdfPage.Height.Centimeter), XStringFormats.TopLeft);
                graph.DrawString("Kelionių skaičius", subHeading, XBrushes.Black, new XRect(380, 80, pdfPage.Width.Centimeter, pdfPage.Height.Centimeter), XStringFormats.TopLeft);
                yPoint = yPoint + 120;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    vardas = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    pavarde = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    kelioniu_sk = ds.Tables[0].Rows[i].ItemArray[2].ToString();

                    graph.DrawString(vardas, font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(pavarde, font, XBrushes.Black, new XRect(240, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(kelioniu_sk, font, XBrushes.Black, new XRect(470, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    yPoint = yPoint + 40;
                }

                string todaysDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
                graph.DrawString("Data: " + todaysDate, date, XBrushes.Black, new XRect(550, yPoint, pdfPage.Width.Centimeter, pdfPage.Height.Centimeter), XStringFormats.BottomRight);

                string pdfFilename = "klientuAtaskaita.pdf";
                pdf.Save(pdfFilename);
                Process.Start(pdfFilename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void darbuotojuAtaskaita(string dateFrom, string dateTo)
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataSet ds = new DataSet();
                string query = null;
                int i = 0;
                int yPoint = 0;
                string vardas = null;
                string pavarde = null;
                string pelnas = null;
                string pardavimu_sk = null;
                MySqlConnection con = new MySqlConnection(@"server=46.17.175.136;database=u682536470_keliones;userid=u682536470_agentura;password=B#u^4E|l2;");
                con.Open();
                MySqlCommand cmd;
                //cmd = con.CreateCommand();
                query = "   SELECT DARBUOTOJAS.vardas," +
                                  "DARBUOTOJAS.pavarde," +
                                  "SUM(KELIONE.kaina_keleiviui * KELIONE.keleiviu_kiekis) AS 'Pelnas'," +
                                  "COUNT(KELIONE.id_KELIONE) AS 'Pardavimų skaičius' " +
                           "FROM DARBUOTOJAS INNER JOIN KELIONE ON DARBUOTOJAS.id_DARBUOTOJAS = KELIONE.fk_DARBUOTOJASid_DARBUOTOJAS " +
                           "WHERE KELIONE.uzsakymo_data>='" + dateFrom + "'" + " AND KELIONE.uzsakymo_data<'" + dateTo + "' " +
                           "GROUP BY DARBUOTOJAS.id_DARBUOTOJAS ORDER BY `Pelnas` DESC";
                cmd = new MySqlCommand(query, con);
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                //cmd.CommandText = query;
                con.Close();

                PdfDocument pdf = new PdfDocument();
                pdf.Info.Title = "Darbuotojų ataskaita";
                PdfPage pdfPage = pdf.AddPage();
                XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                XFont font = new XFont("Verdana", 15, XFontStyle.Regular);
                XFont heading = new XFont("Verdana", 25, XFontStyle.BoldItalic);
                XFont subHeading = new XFont("Verdana", 20, XFontStyle.Bold);
                XFont date = new XFont("Verdana", 10, XFontStyle.Regular);
                graph.DrawString("Darbuotojų ataskaita", heading, XBrushes.Black, new XRect(285, 20, pdfPage.Width.Centimeter, pdfPage.Height.Centimeter), XStringFormats.Center);
                graph.DrawString("Darbuotojas", subHeading, XBrushes.Black, new XRect(30, 80, pdfPage.Width.Centimeter, pdfPage.Height.Centimeter), XStringFormats.TopLeft);
                graph.DrawString("Pelnas", subHeading, XBrushes.Black, new XRect(240, 80, pdfPage.Width.Centimeter, pdfPage.Height.Centimeter), XStringFormats.TopLeft);
                graph.DrawString("Pardavimų skaičius", subHeading, XBrushes.Black, new XRect(360, 80, pdfPage.Width.Centimeter, pdfPage.Height.Centimeter), XStringFormats.TopLeft);
                yPoint = yPoint + 120;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    vardas = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    pavarde = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    pelnas = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    pardavimu_sk = ds.Tables[0].Rows[i].ItemArray[3].ToString();

                    graph.DrawString(vardas + " " + pavarde, font, XBrushes.Black, new XRect(30, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(pelnas + " €", font, XBrushes.Black, new XRect(240, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(pardavimu_sk, font, XBrushes.Black, new XRect(470, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    yPoint = yPoint + 40;
                }

                string todaysDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
                graph.DrawString("Data: " + todaysDate, date, XBrushes.Black, new XRect(550, yPoint, pdfPage.Width.Centimeter, pdfPage.Height.Centimeter), XStringFormats.BottomRight);

                string pdfFilename = "darbuotojuAtaskaita.pdf";
                pdf.Save(pdfFilename);
                Process.Start(pdfFilename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void krypciuAtaskaita()
        {
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataSet ds = new DataSet();
                string query = null;
                int i = 0;
                int yPoint = 0;
                string salis = null;
                string nupirkta = null;
                MySqlConnection con = new MySqlConnection(@"server=46.17.175.136;database=u682536470_keliones;userid=u682536470_agentura;password=B#u^4E|l2;");
                con.Open();
                MySqlCommand cmd;
                //cmd = con.CreateCommand();
                query = "   SELECT KELIONES_KRYPTIS.salis," +
                                  "COUNT(KELIONE.id_KELIONE) AS 'Nupirkta kelionių' " +
                           "FROM KELIONES_KRYPTIS INNER JOIN KELIONE ON KELIONES_KRYPTIS.id_KELIONES_KRYPTIS = KELIONE.fk_KELIONES_KRYPTISid_KELIONES_KRYPTIS " +
                           "GROUP BY KELIONES_KRYPTIS.id_KELIONES_KRYPTIS ORDER BY `Nupirkta kelionių` DESC";
                cmd = new MySqlCommand(query, con);
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                //cmd.CommandText = query;
                con.Close();

                PdfDocument pdf = new PdfDocument();
                pdf.Info.Title = "Kelionių krypčių ataskaita";
                PdfPage pdfPage = pdf.AddPage();
                XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                XFont font = new XFont("Verdana", 15, XFontStyle.Regular);
                XFont heading = new XFont("Verdana", 25, XFontStyle.BoldItalic);
                XFont subHeading = new XFont("Verdana", 20, XFontStyle.Bold);
                XFont date = new XFont("Verdana", 10, XFontStyle.Regular);

                graph.DrawString("Kelionių krypčių ataskaita", heading, XBrushes.Black, new XRect(285, 20, pdfPage.Width.Centimeter, pdfPage.Height.Centimeter), XStringFormats.Center);
                graph.DrawString("Šalis", subHeading, XBrushes.Black, new XRect(80, 80, pdfPage.Width.Centimeter, pdfPage.Height.Centimeter), XStringFormats.TopLeft);
                graph.DrawString("Nupirkta kelionių", subHeading, XBrushes.Black, new XRect(280, 80, pdfPage.Width.Centimeter, pdfPage.Height.Centimeter), XStringFormats.TopLeft);
                yPoint = yPoint + 120;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    salis = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    nupirkta = ds.Tables[0].Rows[i].ItemArray[1].ToString();

                    graph.DrawString(salis, font, XBrushes.Black, new XRect(80, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(nupirkta, font, XBrushes.Black, new XRect(380, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                    yPoint = yPoint + 40;
                }

                string todaysDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
                graph.DrawString("Data: " + todaysDate, date, XBrushes.Black, new XRect(550, yPoint, pdfPage.Width.Centimeter, pdfPage.Height.Centimeter), XStringFormats.BottomRight);

                string pdfFilename = "krypciuAtaskaita.pdf";
                pdf.Save(pdfFilename);
                Process.Start(pdfFilename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(@"server=46.17.175.136;database=u682536470_keliones;userid=u682536470_agentura;password=B#u^4E|l2;");
            con.Open();
            string query = "    SELECT KELIONE.id_KELIONE AS Numeris," +
                                      "KELIONES_KRYPTIS.salis AS Šalis," +
                                      "KELIONE.miestas AS Miestas," +
                                      "KELIONE.kaina_keleiviui AS 'Bilieto kaina'," +
                                      "KELIONE.keleiviu_kiekis AS 'Keleivių kiekis'," +
                                      "KELIONE.data AS 'Kelionės data'," +
                                      "KELIONE.uzsakymo_data AS 'Užsakymo data'," +
                                      "CONCAT(DARBUOTOJAS.vardas, ' ', DARBUOTOJAS.pavarde) AS Agentas," +
                                      "CONCAT(KLIENTAS.vardas, ' ', KLIENTAS.pavarde) AS Klientas " +
                               "FROM KELIONE INNER JOIN KELIONES_KRYPTIS ON KELIONE.fk_KELIONES_KRYPTISid_KELIONES_KRYPTIS = KELIONES_KRYPTIS.id_KELIONES_KRYPTIS " +
                                            "INNER JOIN DARBUOTOJAS ON KELIONE.fk_DARBUOTOJASid_DARBUOTOJAS = DARBUOTOJAS.id_DARBUOTOJAS " +
                                            "INNER JOIN KLIENTAS ON KELIONE.fk_KLIENTASid_KLIENTAS = KLIENTAS.id_KLIENTAS " +
                               "WHERE Data like '" + textBox1.Text+"%' " +
                               "ORDER BY KELIONE.id_KELIONE ASC";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}