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
    public partial class Form19 : Form
    {
        Form11 powrot;
        internal string Klaudeczka;

        public Form19()
        {
            InitializeComponent();
        }

        private void Form19_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form11 wyjdz = new Form11();
            wyjdz.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            powrot = new Form11();
            powrot.FormClosing += new FormClosingEventHandler(this.Form19_FormClosing);
            this.Hide();
            powrot.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var database = new Database();
            if (database.connect_db())
            {
                if (textBox1.Text.Length > 50 || textBox1.Text.Length == 0 || textBox2.Text.Length > 30 || textBox2.Text.Length == 0 || textBox3.Text.Length > 24 || textBox3.Text.Length == 0) MessageBox.Show("Wprowadzone dane mają nieprawidłowy rozmiar!");
                else
                {
                    Regex strnCheck = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ .\-']+$");
                    Match matchImie = strnCheck.Match(textBox1.Text);
                    Match matchNazwisko = strnCheck.Match(textBox2.Text);
                    Regex stringCheck = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ .\-]+$");
                    Match matchNarodowosc = stringCheck.Match(textBox3.Text);
                    Regex intCheck = new Regex(@"^\d+$");
                    Match matchRok = intCheck.Match(textBox4.Text);
                    Match matchRokS = intCheck.Match(textBox5.Text);
                    if (!matchImie.Success || !matchNazwisko.Success || !matchNarodowosc.Success || !matchRok.Success || !matchRokS.Success) MessageBox.Show("Wprowadzone dane mają nieprawidłowy format!");
                    else
                    {

                        if (Int32.Parse(textBox4.Text) > 2023 || Int32.Parse(textBox5.Text) > 2023 || Int32.Parse(textBox4.Text) > Int32.Parse(textBox5.Text) || Int32.Parse(textBox4.Text) < 1 || Int32.Parse(textBox5.Text) < 1) MessageBox.Show("Błąd przy wprowadzaniu daty!");
                        else
                        {
                        string Klaudia = String.Format("UPDATE autorzy SET imiona=@imiona, nazwisko=@nazwisko, data_urodzenia=@data_urodzenia, data_smierci=@data_smierci, narodowosc=@narodowosc WHERE id={0}"
                            , Klaudeczka);

                        MySqlCommand mySqlCommand2 = new MySqlCommand(Klaudia);
                        mySqlCommand2.Parameters.AddWithValue("@imiona", textBox1.Text);
                        mySqlCommand2.Parameters.AddWithValue("@nazwisko", textBox2.Text);
                        mySqlCommand2.Parameters.AddWithValue("@data_urodzenia", textBox4.Text);
                        if (textBox5.Enabled == true)
                        {
                            mySqlCommand2.Parameters.AddWithValue("@data_smierci", textBox5.Text);
                        }
                        else
                        {
                            mySqlCommand2.Parameters.AddWithValue("@data_smierci", null);
                        }
                        mySqlCommand2.Parameters.AddWithValue("@narodowosc", textBox3.Text);
                        mySqlCommand2.Connection = database.mySqlConnection;
                        MySqlCommand regQr = new MySqlCommand(Klaudia, database.mySqlConnection);
                        foreach (MySqlParameter p in mySqlCommand2.Parameters)
                        {
                            regQr.Parameters.AddWithValue(p.ParameterName, p.Value);
                        }
                        regQr.ExecuteNonQuery();
                        }
                    }
                }
                database.close_db();
            }
            else
            {
                MessageBox.Show("Database error!");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox5.Enabled = false;
            }
            else
            {
                textBox5.Enabled = true;
            }
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            string Kaludia = String.Format("SELECT imiona, nazwisko, data_urodzenia, data_smierci, narodowosc FROM autorzy WHERE id={0}"
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

                textBox1.Text = dt.Rows[0]["imiona"].ToString();
                textBox2.Text = dt.Rows[0]["nazwisko"].ToString();
                textBox4.Text = dt.Rows[0]["data_urodzenia"].ToString();
                textBox5.Text = dt.Rows[0]["data_smierci"].ToString();
                textBox3.Text = dt.Rows[0]["narodowosc"].ToString();
            }
            else
            {
                MessageBox.Show("Database error!");
            }
        }
    }
}
