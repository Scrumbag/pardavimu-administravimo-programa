using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Pardavimu_administravimas
{
    public partial class LoginApp : Form
    {
        public LoginApp()
        {
            InitializeComponent();
            passwordBox.PasswordChar = '•';
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            String str = @"server=46.17.175.136;database=u682536470_keliones;userid=u682536470_agentura;password=B#u^4E|l2;";
            MySqlConnection con = null;
            MySqlDataReader reader = null;

            try
            {
                int m = 0;
                con = new MySqlConnection(str);
                con.Open();
                //MessageBox.Show("Connection Open ! ");
                String cmdText = "SELECT * FROM PRISIJUNGIMAI";
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    m++;
                    if (reader.GetString(0) == usernameBox.Text && reader.GetString(1) == passwordBox.Text)
                    {
                        //LoginApp current = new LoginApp();
                        //current.MdiParent = this.MdiParent;
                        this.Hide();
                        Form1 ss = new Form1();
                        ss.ShowDialog();
                        this.Close();
                        break;
                    }
                    else
                    {
                        klaida.Text = "Neteisingi duomenys";
                    }
                }
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            Console.Read();
        }
    }
}
