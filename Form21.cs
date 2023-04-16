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
    public partial class Form21 : Form
    {
        Form13 powrot;
        internal string Klaudeczka;

        public Form21()
        {
            InitializeComponent();
        }

        private void Form21_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form13 wyjdz = new Form13();
            wyjdz.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            powrot = new Form13();
            powrot.FormClosing += new FormClosingEventHandler(this.Form21_FormClosing);
            this.Hide();
            powrot.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var database = new Database();
            if (database.connect_db())
            {
                if (textBox1.Text.Length > 30) MessageBox.Show("Wprowadzone dane mają nieprawidłowy rozmiar!");
                else
                {
                    Regex stringCheck = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ .\-]+$");
                    Match matchKategoria = stringCheck.Match(textBox1.Text);

                    if (!matchKategoria.Success) MessageBox.Show("Wprowadzone dane mają nieprawidłowy format!");
                    else
                    {
                        string Klaudia = String.Format("UPDATE kategorie SET nazwa=@nazwa WHERE id={0}"
                            , Klaudeczka);

                        MySqlCommand mySqlCommand2 = new MySqlCommand(Klaudia);
                        mySqlCommand2.Parameters.AddWithValue("@nazwa", textBox1.Text);
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

        private void Form21_Load(object sender, EventArgs e)
        {
            string Kaludia = String.Format("SELECT nazwa FROM kategorie WHERE id={0}"
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
            }
            else
            {
                MessageBox.Show("Database error!");
            }
        }
    }
}
