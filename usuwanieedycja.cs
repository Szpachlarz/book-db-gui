using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt
{
    public partial class usuwanieedycja : Form
    {
        paneladmina powrot;

        public virtual string query
        {
            get { return ""; }
        }
        public usuwanieedycja()
        { 
            InitializeComponent();
        }

        public void usuwanieedycja_FormClosing(object sender, FormClosingEventArgs e)
        {
            paneladmina wyjdz = new paneladmina();
            wyjdz.Show();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            powrot = new paneladmina();
            powrot.FormClosing += new FormClosingEventHandler(this.usuwanieedycja_FormClosing);
            this.Hide();
            powrot.ShowDialog();
        }

        public void usuwanieedycja_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            var database = new Database();
            if (database.connect_db())
            {
                //string query = "SELECT tytul, id_ksiazki FROM ksiazki";
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
                MessageBox.Show("Błąd połączenia z bazą!");
            }
    }

        public virtual void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

