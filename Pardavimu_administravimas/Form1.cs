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
        private List<TestEmployee> EmployeeT;
        private List<TestTrips> TripsT;
        private List<TestTripsDestination> TripsDestinationT;
        private List<TestClient> ClientT;
        private List<TestAgency> AgencyT;
        public Form1()
        {
            InitializeComponent();
        }
        private void išeitiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        static List<TestEmployee> ReadTestEmployee(string fv)
        {
            List<TestEmployee> EmployT = new List<TestEmployee>();
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string email = parts[0];
                    string name = parts[1];
                    string surname = parts[2];
                    string phoneNumber = parts[4];
                    string birthD = parts[5];
                    int sellC = int.Parse(parts[6]);
                    double moneyM = double.Parse(parts[7]);
                    TestEmployee Emp = new TestEmployee(email, name, surname, phoneNumber,
                        birthD, sellC, moneyM);
                    EmployT.Add(Emp);
                }
            }
            return EmployT;
        }
        static List<TestTrips> ReadTripsT(string fv)
        {
            List<TestTrips> TT = new List<TestTrips>();
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string City = parts[0];
                    string date = parts[1];
                    double price = double.Parse(parts[2]);
                    TestTrips TestT = new TestTrips(City, date, price);
                    TT.Add(TestT);
                }
            }
            return TT;
        }
        static List<TestTripsDestination> ReadTTD(string fv)
        {
            List<TestTripsDestination> TTD = new List<TestTripsDestination>();
            {
                using(StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
                {
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        string Country = parts[0];
                        TestTripsDestination TestTTD = new TestTripsDestination(Country);
                        TTD.Add(TestTTD);
                    }
                }
                return TTD;
            }

        }
        static List<TestClient> ReadTestClient(string fv)
        {
            List<TestClient> TestC = new List<TestClient>();
            {
                using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        string email = parts[0];
                        string name = parts[1];
                        string surname = parts[2];
                        string phoneN = parts[3];
                        string birthDay = parts[4];
                        TestClient TestCl = new TestClient(email, name, surname,
                            phoneN, birthDay);
                        TestC.Add(TestCl);
                    }
                }
                return TestC;
            }
        }
        static List<TestAgency> ReadTestAgency(string fv)
        {
            List<TestAgency> TestA = new List<TestAgency>();
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string line; 
                while((line =reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string AgencyN = parts[0];
                    int AgencyC = int.Parse(parts[1]);
                    string phoneNr = parts[2];
                    string adress = parts[3];
                    string country = parts[4];
                    TestAgency TestAg = new TestAgency(AgencyN, AgencyC, phoneNr,
                        adress, country);
                    TestA.Add(TestAg);
                }
            }
            return TestA;
        }

        private void testEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter =
                "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult result1 = openFileDialog1.ShowDialog();
            if (result1 == DialogResult.OK)
            {
                string fv = openFileDialog1.FileName;
                //richTextBox1.LoadFile(fv, RichTextBoxStreamType.PlainText);
                EmployeeT = ReadTestEmployee(fv);
            }
        }

        private void testTripsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter =
                "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog2.Title = "Pasirinkite duomenų failą";
            DialogResult result2 = openFileDialog2.ShowDialog();
            if (result2 == DialogResult.OK)
            {
                string fv = openFileDialog2.FileName;
                //richTextBox1.LoadFile(fv, RichTextBoxStreamType.PlainText);
                TripsT = ReadTripsT(fv);
            }
        }

        private void testTripsDestinationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter =
                "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog2.Title = "Pasirinkite duomenų failą";
            DialogResult result2 = openFileDialog2.ShowDialog();
            if (result2 == DialogResult.OK)
            {
                string fv = openFileDialog2.FileName;
                //richTextBox1.LoadFile(fv, RichTextBoxStreamType.PlainText);
                TripsDestinationT = ReadTTD(fv);
            }
        }
        private void testClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter =
                "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog2.Title = "Pasirinkite duomenų failą";
            DialogResult result2 = openFileDialog2.ShowDialog();
            if (result2 == DialogResult.OK)
            {
                string fv = openFileDialog2.FileName;
                //richTextBox1.LoadFile(fv, RichTextBoxStreamType.PlainText);
                ClientT = ReadTestClient(fv);
            }
        }
        private void testAgencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter =
                "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog2.Title = "Pasirinkite duomenų failą";
            DialogResult result2 = openFileDialog2.ShowDialog();
            if (result2 == DialogResult.OK)
            {
                string fv = openFileDialog2.FileName;
                //richTextBox1.LoadFile(fv, RichTextBoxStreamType.PlainText);
                AgencyT = ReadTestAgency(fv);
            }
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
            dataGridView1.Columns[6].Width = 150;
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
            return dt;
        }
    }
}
