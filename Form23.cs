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
    public partial class Form23 : Form
    {
        internal string Klaudeczka;
        Form15 powrot;

        public Form23()
        {
            InitializeComponent();
        }

        private void Form23_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form11 wyjdz = new Form11();
            wyjdz.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            powrot = new Form15();
            powrot.FormClosing += new FormClosingEventHandler(this.Form23_FormClosing);
            this.Hide();
            powrot.ShowDialog();
        }

        private void Form23_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            var database = new Database();
            if (database.connect_db())
            {
                
                string Klaudia = String.Format("DELETE FROM autorzy WHERE id={0}"
                    , Klaudeczka);

                MySqlCommand mySqlCommand2 = new MySqlCommand(Klaudia);
                MySqlCommand regQr = new MySqlCommand(Klaudia, database.mySqlConnection);
                regQr.ExecuteNonQuery();

                database.close_db();
            }
            else
            {
                MessageBox.Show("Database error!");
            }
        }
    }
}
