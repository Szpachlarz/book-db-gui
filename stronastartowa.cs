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
            Form_Load();
        }
                
        private void Form_Load()
        {
            string query = "SELECT k.tytul, CONCAT(a.imiona,' ', a.nazwisko) as autor, k.ISBN, w.nazwa, k.seria, k.rok_wydania as 'rok wydania', k.rok_1wydania as 'rok pierwszego wydania', k.strony, k.jezyk as język, k.jezyk_oryginalny as 'język oryginalny', k.tlumaczenie as tłumaczenie, k.tytul_oryginalny as 'tytuł oryginalny', kat.nazwa as kategoria" +
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
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.DisplayMember = "nazwa";
                comboBox1.ValueMember = "id";
                comboBox1.SelectedItem = null;

                string queryaut = "SELECT id, CONCAT(imiona, ' ', nazwisko) as autor FROM autorzy";
                MySqlCommand mySqlCommand2 = new MySqlCommand(queryaut);
                mySqlCommand2.Connection = database.mySqlConnection;
                MySqlDataAdapter adapter2 = new MySqlDataAdapter();
                adapter2.SelectCommand = mySqlCommand2;

                DataSet ds2 = new DataSet();
                adapter2.Fill(ds2);
                comboBox2.DataSource = ds2.Tables[0];
                comboBox2.DisplayMember = "autor";
                comboBox2.ValueMember = "id";
                comboBox2.SelectedItem = null;

                string querywyd = "SELECT id, nazwa FROM wydawnictwa";
                MySqlCommand mySqlCommand3 = new MySqlCommand(querywyd);
                mySqlCommand3.Connection = database.mySqlConnection;
                MySqlDataAdapter adapter3 = new MySqlDataAdapter();
                adapter3.SelectCommand = mySqlCommand3;

                DataSet ds3 = new DataSet();
                adapter3.Fill(ds3);
                comboBox3.DataSource = ds3.Tables[0];
                comboBox3.DisplayMember = "nazwa";
                comboBox3.ValueMember = "id";
                comboBox3.SelectedItem = null;

                mySqlCommand.ExecuteNonQuery();
                database.close_db();

            }
            else
            {
                MessageBox.Show("Błąd bazy!");
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
                MessageBox.Show("Błąd bazy!");
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
                string query1 = String.Format("SELECT k.tytul as tytuł, CONCAT(a.imiona,' ', a.nazwisko) as autor, k.ISBN, w.nazwa as wydawnictwo, k.seria, k.rok_wydania as 'rok wydania', k.rok_1wydania as 'rok pierwszego wydania', k.strony, k.jezyk as język, k.jezyk_oryginalny as 'język oryginalny', k.tlumaczenie as tłumaczenie, k.tytul_oryginalny as 'tytuł oryginalny', kat.nazwa as kategoria" +
                    " FROM ksiazki k LEFT OUTER JOIN autorstwo aut ON k.id_ksiazki=aut.id_ksiazki LEFT OUTER JOIN autorzy a ON aut.autor=a.id " +
                    "LEFT OUTER JOIN kategorie kat ON k.kategoria=kat.id LEFT OUTER JOIN wydawnictwa w ON k.wydawnictwo=w.id WHERE kategoria = '{0}' ORDER BY k.tytul", comboBox1.GetItemText(item[0]));
                loadData(query1);
            }
            else
            {
                string query4 = "SELECT k.tytul as tytuł, CONCAT(a.imiona,' ', a.nazwisko) as autor, k.ISBN, w.nazwa as wydawnictwo, k.seria, k.rok_wydania as 'rok wydania', k.rok_1wydania as 'rok pierwszego wydania', k.strony, k.jezyk as język, k.jezyk_oryginalny as 'język oryginalny', k.tlumaczenie as tłumaczenie, k.tytul_oryginalny as 'tytuł oryginalny', kat.nazwa as kategoria" +
                    " FROM ksiazki k LEFT OUTER JOIN autorstwo aut ON k.id_ksiazki=aut.id_ksiazki LEFT OUTER JOIN autorzy a ON aut.autor=a.id " +
                    "LEFT OUTER JOIN kategorie kat ON k.kategoria=kat.id LEFT OUTER JOIN wydawnictwa w ON k.wydawnictwo=w.id ORDER BY k.tytul";
                loadData(query4);
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox2.Text))
            {
                DataRowView item = (DataRowView)comboBox2.SelectedItem;
                string query2 = String.Format("SELECT k.tytul as tytuł, CONCAT(a.imiona,' ', a.nazwisko) as autor, k.ISBN, w.nazwa as wydawnictwo, k.seria, k.rok_wydania as 'rok wydania', k.rok_1wydania as 'rok pierwszego wydania', k.strony, k.jezyk as język, k.jezyk_oryginalny as 'język oryginalny', k.tlumaczenie as tłumaczenie, k.tytul_oryginalny as 'tytuł oryginalny', kat.nazwa as kategoria" +
                    " FROM ksiazki k LEFT OUTER JOIN autorstwo aut ON k.id_ksiazki=aut.id_ksiazki LEFT OUTER JOIN autorzy a ON aut.autor=a.id " +
                    "LEFT OUTER JOIN kategorie kat ON k.kategoria=kat.id LEFT OUTER JOIN wydawnictwa w ON k.wydawnictwo=w.id WHERE autor = '{0}' ORDER BY k.tytul", comboBox2.GetItemText(item[0]));
                loadData(query2);
            }
            else
            {
                string query4 = "SELECT k.tytul as tytuł, CONCAT(a.imiona,' ', a.nazwisko) as autor, k.ISBN, w.nazwa as wydawnictwo, k.seria, k.rok_wydania as 'rok wydania', k.rok_1wydania as 'rok pierwszego wydania', k.strony, k.jezyk as język, k.jezyk_oryginalny as 'język oryginalny', k.tlumaczenie as tłumaczenie, k.tytul_oryginalny as 'tytuł oryginalny', kat.nazwa as kategoria" +
                    " FROM ksiazki k LEFT OUTER JOIN autorstwo aut ON k.id_ksiazki=aut.id_ksiazki LEFT OUTER JOIN autorzy a ON aut.autor=a.id " +
                    "LEFT OUTER JOIN kategorie kat ON k.kategoria=kat.id LEFT OUTER JOIN wydawnictwa w ON k.wydawnictwo=w.id ORDER BY k.tytul";
                loadData(query4);
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox3.Text))
            {
                DataRowView item = (DataRowView)comboBox3.SelectedItem;
                string query3 = String.Format("SELECT k.tytul as tytuł, CONCAT(a.imiona,' ', a.nazwisko) as autor, k.ISBN, w.nazwa as wydawnictwo, k.seria, k.rok_wydania as 'rok wydania', k.rok_1wydania as 'rok pierwszego wydania', k.strony, k.jezyk as język, k.jezyk_oryginalny as 'język oryginalny', k.tlumaczenie as tłumaczenie, k.tytul_oryginalny as 'tytuł oryginalny', kat.nazwa as kategoria" +
                    " FROM ksiazki k LEFT OUTER JOIN autorstwo aut ON k.id_ksiazki=aut.id_ksiazki LEFT OUTER JOIN autorzy a ON aut.autor=a.id " +
                    "LEFT OUTER JOIN kategorie kat ON k.kategoria=kat.id LEFT OUTER JOIN wydawnictwa w ON k.wydawnictwo=w.id WHERE wydawnictwo = '{0}' ORDER BY k.tytul", comboBox3.GetItemText(item[0]));
                loadData(query3);
            }
            else
            {
                string query4 = "SELECT k.tytul as tytuł, CONCAT(a.imiona,' ', a.nazwisko) as autor, k.ISBN, w.nazwa as wydawnictwo, k.seria, k.rok_wydania as 'rok wydania', k.rok_1wydania as 'rok pierwszego wydania', k.strony, k.jezyk as język, k.jezyk_oryginalny as 'język oryginalny', k.tlumaczenie as tłumaczenie, k.tytul_oryginalny as 'tytuł oryginalny', kat.nazwa as kategoria" +
                    " FROM ksiazki k LEFT OUTER JOIN autorstwo aut ON k.id_ksiazki=aut.id_ksiazki LEFT OUTER JOIN autorzy a ON aut.autor=a.id " +
                    "LEFT OUTER JOIN kategorie kat ON k.kategoria=kat.id LEFT OUTER JOIN wydawnictwa w ON k.wydawnictwo=w.id ORDER BY k.tytul";
                loadData(query4);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_Load();
        }
    }
}
