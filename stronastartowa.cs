using MySql.Data;
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
    public partial class stronastartowa : Form
    {
        logowanie loguj;
        Form2 konto;
        bool zalogowany;
        public stronastartowa()
        {
            InitializeComponent();
            this.Load += Form5_Load;
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*private void Form5_Loaded(object sender, EventArgs e)
        {
            bool zalogowany = false; // zmienna reprezentująca stan zalogowania klienta

            // ukrycie przycisku "Moje konto"
            button2.Visible = false;

            if (zalogowany)
            {
                // jeśli klient jest zalogowany, ukrycie przycisku "Zaloguj" i pokazanie przycisku "Moje konto"
                button1.Visible = false;
                button2.Visible = true;
            }
        }*/

        public void Form5_Load(object sender, EventArgs e)
        {
            string query = "SELECT k.tytul, a.imiona, a.nazwisko, k.ISBN, w.nazwa, k.seria, k.rok_wydania, k.rok_1wydania, k.strony, k.jezyk, k.jezyk_oryginalny, k.tlumaczenie, k.tytul_oryginalny, kat.nazwa" +
                    " FROM ksiazki k LEFT OUTER JOIN autorstwo aut ON k.id_ksiazki=aut.id_ksiazki LEFT OUTER JOIN autorzy a ON aut.autor=a.id " +
                    "LEFT OUTER JOIN kategorie kat ON k.kategoria=kat.id LEFT OUTER JOIN wydawnictwa w ON k.wydawnictwo=w.id ORDER BY k.tytul";
            loadData(query);
            if (zalogowany == false)
            {
                button1.Visible = true;
                button2.Visible = false;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = true;
            }

            var database = new Database();
            if (database.connect_db())
            {
                string querykat = "SELECT * FROM kategorie";
                MySqlCommand mySqlCommand = new MySqlCommand(querykat);
                mySqlCommand.Connection = database.mySqlConnection;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                mySqlCommand.ExecuteNonQuery();
                database.close_db();
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.DisplayMember = "nazwa";
                comboBox1.ValueMember = "id";
                comboBox1.SelectedItem = null;

            }
            else
            {
                MessageBox.Show("Database error!");
            }
        }

        public void loadData(string query)
        {
            var database = new Database();
            if (database.connect_db())
            {                
                MySqlCommand mySqlCommand = new MySqlCommand(query);
                mySqlCommand.Connection = database.mySqlConnection;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataView dv = new DataView(ds.Tables[0]);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = dv;
                database.close_db();
            }
            else
            {
                MessageBox.Show("Database error!");
            }
        }

        private void zaloguj(object sender, EventArgs e)
        {
            loguj = new logowanie();
            loguj.FormClosing += new FormClosingEventHandler(this.Form5_FormClosing);
            this.Hide();
            loguj.ShowDialog();
        }

        private void mojeKonto(object sender, EventArgs e)
        {
            konto = new Form2();
            konto.FormClosing += new FormClosingEventHandler(this.Form5_FormClosing);
            this.Hide();
            loguj.ShowDialog();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                DataRowView item = (DataRowView)comboBox1.SelectedItem;
                string query = String.Format("SELECT k.tytul, a.imiona, a.nazwisko, k.ISBN, w.nazwa, k.seria, k.rok_wydania, k.rok_1wydania, k.strony, k.jezyk, k.jezyk_oryginalny, k.tlumaczenie, k.tytul_oryginalny, kat.nazwa" +
                    " FROM ksiazki k LEFT OUTER JOIN autorstwo aut ON k.id_ksiazki=aut.id_ksiazki LEFT OUTER JOIN autorzy a ON aut.autor=a.id " +
                    "LEFT OUTER JOIN kategorie kat ON k.kategoria=kat.id LEFT OUTER JOIN wydawnictwa w ON k.wydawnictwo=w.id WHERE kat.nazwa = '{0}' ORDER BY k.tytul", comboBox1.GetItemText(item[0]));
                loadData(query);
            }
            else
            {
                string query = "SELECT k.tytul, a.imiona, a.nazwisko, k.ISBN, w.nazwa, k.seria, k.rok_wydania, k.rok_1wydania, k.strony, k.jezyk, k.jezyk_oryginalny, k.tlumaczenie, k.tytul_oryginalny, kat.nazwa" +
                    " FROM ksiazki k LEFT OUTER JOIN autorstwo aut ON k.id_ksiazki=aut.id_ksiazki LEFT OUTER JOIN autorzy a ON aut.autor=a.id " +
                    "LEFT OUTER JOIN kategorie kat ON k.kategoria=kat.id LEFT OUTER JOIN wydawnictwa w ON k.wydawnictwo=w.id ORDER BY k.tytul";
                loadData(query);
            }
        }
    }
}
