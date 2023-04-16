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
    public partial class Form24 : Form
    {
        internal string Klaudeczka;
        Form16 powrot;

        public Form24()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var database = new Database();
            if (database.connect_db())
            {                
                string Klaudia = String.Format("DELETE FROM wydawnictwa WHERE id={0}"
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

        private void Form24_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form16 wyjdz = new Form16();
            wyjdz.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            powrot = new Form16();
            powrot.FormClosing += new FormClosingEventHandler(this.Form24_FormClosing);
            this.Hide();
            powrot.ShowDialog();
        }

        private void Form24_Load(object sender, EventArgs e)
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
