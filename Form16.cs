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
    public partial class Form16 : Form
    {
        paneladmina powrot;
        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_FormClosing(object sender, FormClosingEventArgs e)
        {
            paneladmina wyjdz = new paneladmina();
            wyjdz.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            powrot = new paneladmina();
            powrot.FormClosing += new FormClosingEventHandler(this.Form16_FormClosing);
            this.Hide();
            powrot.ShowDialog();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            var database = new Database();
            if (database.connect_db())
            {
                string query = "SELECT id, nazwa, adres, miasto, kraj FROM wydawnictwa";
                MySqlCommand mySqlCommand = new MySqlCommand(query);
                mySqlCommand.Connection = database.mySqlConnection;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dt;

                dataGridView1.DataSource = bindingSource;

                database.close_db();
            }
            else
            {
                MessageBox.Show("Database error!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string Klaudiusza = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                Form24 form24 = new Form24();
                form24.Klaudeczka = Klaudiusza;
                form24.ShowDialog();
            }
        }
    }
}
