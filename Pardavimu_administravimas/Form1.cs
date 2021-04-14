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
                richTextBox1.LoadFile(fv, RichTextBoxStreamType.PlainText);
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
                richTextBox1.LoadFile(fv, RichTextBoxStreamType.PlainText);
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
                richTextBox1.LoadFile(fv, RichTextBoxStreamType.PlainText);
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
                richTextBox1.LoadFile(fv, RichTextBoxStreamType.PlainText);
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
                richTextBox1.LoadFile(fv, RichTextBoxStreamType.PlainText);
                AgencyT = ReadTestAgency(fv);
            }
        }

        
    }
}
