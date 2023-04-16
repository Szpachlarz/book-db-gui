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
using System.Text.RegularExpressions;

namespace projekt
{
    public partial class Form20 : Form
    {
        Form12 powrot;
        internal string Klaudeczka;

        public Form20()
        {
            InitializeComponent();
        }

        private void Form20_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form12 wyjdz = new Form12();
            wyjdz.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            powrot = new Form12();
            powrot.FormClosing += new FormClosingEventHandler(this.Form20_FormClosing);
            this.Hide();
            powrot.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var database = new Database();
            if (database.connect_db())
            {
                if (textBox1.Text.Length > 30 || textBox1.Text.Length == 0 || textBox2.Text.Length > 30 || textBox3.Text.Length > 30 || textBox4.Text.Length > 30) MessageBox.Show("Wprowadzone dane mają nieprawidłowy rozmiar!");
                else
                {
                    Regex stringaCheck = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ0-9\s.-]+$");
                    Match matchAdres = stringaCheck.Match(textBox2.Text);
                    Regex stringbCheck = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s.-]+$");
                    Match matchMiasto = stringbCheck.Match(textBox3.Text);
                    Regex stringcCheck = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s]+$");
                    Match matchKraj = stringcCheck.Match(textBox4.Text);
                    if (!matchAdres.Success || !matchMiasto.Success || !matchKraj.Success) MessageBox.Show("Wprowadzone dane mają nieprawidłowy format!");
                    else
                    {
                        string Klaudia = String.Format("UPDATE wydawnictwa SET nazwa=@nazwa, adres=@adres, miasto=@miasto, kraj=@kraj WHERE id={0}"
                            , Klaudeczka);

                        MySqlCommand mySqlCommand2 = new MySqlCommand(Klaudia);
                        mySqlCommand2.Parameters.AddWithValue("@nazwa", textBox1.Text);
                        mySqlCommand2.Parameters.AddWithValue("@adres", textBox2.Text);
                        mySqlCommand2.Parameters.AddWithValue("@miasto", textBox3.Text);
                        mySqlCommand2.Parameters.AddWithValue("@kraj", textBox4.Text);
                        mySqlCommand2.Connection = database.mySqlConnection;
                        MySqlCommand regQr = new MySqlCommand(Klaudia, database.mySqlConnection);
                        foreach (MySqlParameter p in mySqlCommand2.Parameters)
                        {
                            regQr.Parameters.AddWithValue(p.ParameterName, p.Value);
                        }
                        regQr.ExecuteNonQuery();
                    }
                }
                database.close_db();
            }
            else
            {
                MessageBox.Show("Database error!");
            }
        }

        private void Form20_Load(object sender, EventArgs e)
        {
            string Kaludia = String.Format("SELECT nazwa, adres, miasto, kraj FROM wydawnictwa WHERE id={0}"
                , Klaudeczka);

            var database = new Database();
            if (database.connect_db())
            {
                MySqlCommand mySqlCommand = new MySqlCommand(Kaludia);
                mySqlCommand.Connection = database.mySqlConnection;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dt;

                database.close_db();

                textBox1.Text = dt.Rows[0]["nazwa"].ToString();
                textBox2.Text = dt.Rows[0]["adres"].ToString();
                textBox3.Text = dt.Rows[0]["miasto"].ToString();
                textBox4.Text = dt.Rows[0]["kraj"].ToString();
            }
            else
            {
                MessageBox.Show("Database error!");
            }
        }
    }
}
