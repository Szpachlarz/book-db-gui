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
    public partial class Form25 : Form
    {
        internal string Klaudeczka;
        Form17 powrot;

        public Form25()
        {
            InitializeComponent();
        }

        private void Form25_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            var database = new Database();
            if (database.connect_db())
            {
                string Klaudia = String.Format("DELETE FROM kategorie WHERE id={0}"
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
