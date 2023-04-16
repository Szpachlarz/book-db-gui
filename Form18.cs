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
    public partial class Form18 : Form
    {
        Form10 powrot;
        int n = 0;
        internal string ISBNa;

        public Form18()
        {
            InitializeComponent();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            var dataSource = new List<Publishers>();
            DataTable dataTable = Database.GetDataTable("SELECT * FROM wydawnictwa");
            foreach (var item in dataTable.AsEnumerable())
            {
                dataSource.Add(new Publishers() { Name = item[1].ToString(), Value = item[0].ToString() });
            }
            comboBox2.DataSource = dataSource;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Value";

            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            var dataSource2 = new List<Categories>();
            DataTable dataTable2 = Database.GetDataTable("SELECT * FROM kategorie");
            foreach (var item in dataTable2.AsEnumerable())
            {
                dataSource2.Add(new Categories() { Name = item[1].ToString(), Value = item[0].ToString() });
            }
            comboBox3.DataSource = dataSource2;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Value";

            if (comboBox4.SelectedIndex != -1)
            {
                n = Convert.ToInt32(comboBox4.SelectedItem.ToString());
                CreateComboBoxes(n);
            }

            string Kaludia = String.Format("SELECT tytul, wydawnictwo, seria, rok_wydania, rok_1wydania, strony, jezyk, jezyk_oryginalny, tlumaczenie, tytul_oryginalny, kategoria, ISBN, w.nazwa AS kaludyna, ka.nazwa AS kornel FROM ksiazki AS k INNER JOIN wydawnictwa AS w ON k.wydawnictwo=w.id INNER JOIN kategorie AS ka ON ka.id = k.kategoria WHERE ISBN={0}"
                , ISBNa);
            string Arkadiusz = String.Format("SELECT ISBN, autor, au.imiona, au.nazwisko, au.id AS caludia, SUM((SELECT COUNT(*) FROM autorstwo WHERE ISBN={0})) AS claudia FROM autorstwo as a RIGHT JOIN autorzy AS au ON au.id=a.autor WHERE ISBN={0} GROUP BY caludia"
                , ISBNa);
            string Rafalala = String.Format("SELECT imiona, nazwisko, id FROM autorzy"
                , ISBNa);
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 1; i < 8; i++)
            {
                comboBox4.Items.Add(i);
            }

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

                textBox1.Text = dt.Rows[0]["tytul"].ToString();
                comboBox2.SelectedIndex = comboBox2.FindString(dt.Rows[0]["kaludyna"].ToString());
                textBox4.Text = dt.Rows[0]["seria"].ToString();
                textBox5.Text = dt.Rows[0]["rok_wydania"].ToString();
                textBox6.Text = dt.Rows[0]["rok_1wydania"].ToString();
                textBox9.Text = dt.Rows[0]["strony"].ToString();
                textBox8.Text = dt.Rows[0]["jezyk"].ToString();
                textBox7.Text = dt.Rows[0]["jezyk_oryginalny"].ToString();
                textBox10.Text = dt.Rows[0]["tlumaczenie"].ToString();
                textBox2.Text = dt.Rows[0]["tytul_oryginalny"].ToString();
                comboBox3.SelectedIndex = comboBox3.FindString(dt.Rows[0]["kornel"].ToString());

                MySqlCommand mySqlCommand2 = new MySqlCommand(Arkadiusz);
                mySqlCommand2.Connection = database.mySqlConnection;
                MySqlDataAdapter adapter2 = new MySqlDataAdapter();
                adapter2.SelectCommand = mySqlCommand2;
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);
                BindingSource bindingSource2 = new BindingSource();
                bindingSource2.DataSource = dt2;

                MySqlCommand mySqlCommand3 = new MySqlCommand(Rafalala);
                mySqlCommand3.Connection = database.mySqlConnection;
                MySqlDataAdapter adapter3 = new MySqlDataAdapter();
                adapter3.SelectCommand = mySqlCommand3;
                DataTable dt3 = new DataTable();
                adapter3.Fill(dt3);
                BindingSource bindingSource3 = new BindingSource();
                bindingSource3.DataSource = dt3;

                List<ComboBox> comboBoxList = new List<ComboBox>();
                for (int i = 4; i < Convert.ToInt32(dt2.Rows[0]["claudia"]) + 4; i++)
                {
                    var dataSource36 = new List<Authors>();
                    foreach (var item in dt3.AsEnumerable())
                    {
                        dataSource36.Add(new Authors() { Name = item["imiona"].ToString() + " " + item["nazwisko"].ToString(), Value = item["id"].ToString() });
                    }
                    ComboBox comboBox = new ComboBox();
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox.Location = new System.Drawing.Point(5, 10 + ((i - 4) * 25));
                    comboBox.Name = "comboBox" + i;
                    comboBox.Size = new System.Drawing.Size(121, 21);
                    comboBoxList.Add(comboBox);
                    comboBoxList[i - 4].DataSource = dataSource36;
                    comboBoxList[i - 4].DisplayMember = "Name";
                    comboBoxList[i - 4].ValueMember = "Value";
                }
                groupBox1.Controls.Clear();
                int arkadia = 0;
                foreach (ComboBox comboBox in comboBoxList)
                {
                    groupBox1.Controls.Add(comboBox);
                    comboBox.SelectedIndex = comboBox.FindString(dt2.Rows[arkadia]["imiona"].ToString() + " " + dt2.Rows[arkadia]["nazwisko"].ToString());
                    arkadia++;
                }

                database.close_db();
            }
            else
            {
                MessageBox.Show("Database error!");
            }
        }

        public class Authors
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        public class Publishers
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        public class Categories
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            var database = new Database();
            if (database.connect_db())
            {
                if (textBox1.Text.Length > 50 || textBox1.Text.Length == 0 || textBox4.Text.Length > 11 || textBox5.Text.Length > 4 || textBox6.Text.Length > 4 || textBox9.Text.Length > 6 || textBox8.Text.Length > 24 || textBox7.Text.Length > 24 || textBox10.Text.Length > 30 || textBox2.Text.Length > 50 || comboBox4.Text == "" || comboBox2.Text == "" || comboBox3.Text == "") MessageBox.Show("Wprowadzone dane mają nieprawidłowy rozmiar!");
                else
                {
                    Regex intCheck = new Regex(@"^\d+$");
                    Match matchRok = intCheck.Match(textBox5.Text);
                    Match matchRok1 = intCheck.Match(textBox6.Text);
                    Match matchStrony = intCheck.Match(textBox9.Text);

                    Regex stringCheck = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ \-]+$");
                    Match matchJezyk = stringCheck.Match(textBox8.Text);
                    Match matchJezykOrginalny = stringCheck.Match(textBox7.Text);

                    Regex check = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ .\-]+$");
                    Match matchTlumaczenie = check.Match(textBox10.Text);

                    if (!matchRok.Success || !matchRok1.Success || !matchStrony.Success || !matchJezyk.Success || !matchJezykOrginalny.Success && textBox7.Text != "" || !matchTlumaczenie.Success && textBox10.Text != "") MessageBox.Show("Wprowadzone dane mają nieprawidłowy format!");
                    else
                    {

                        if (Int32.Parse(textBox5.Text) > 2023 || Int32.Parse(textBox6.Text) > 2023 || Int32.Parse(textBox6.Text) > Int32.Parse(textBox5.Text) || Int32.Parse(textBox5.Text) < 1 || Int32.Parse(textBox6.Text) < 1) MessageBox.Show("Błąd przy wprowadzaniu daty!");
                        else
                        {
                            string Klaudia = String.Format("UPDATE ksiazki SET tytul=@tytul, wydawnictwo=@wydawnictwo, seria=@seria, rok_wydania=@rok_wydania, rok_1wydania=@rok_1wydania, strony=@strony, jezyk=@jezyk, jezyk_oryginalny=@jezyk_oryginalny, tlumaczenie=@tlumaczenie, tytul_oryginalny=@tytul_oryginalny, kategoria=@kategoria WHERE ISBN={0}"
                                , ISBNa);
                            string Arek = String.Format("DELETE FROM autorstwo WHERE ISBN={0}", ISBNa);
                            string Rafaello = String.Format("INSERT INTO autorstwo(ISBN, autor) VALUES(@isbn, @autor)");
                                                       
                            MySqlCommand mySqlCommand2 = new MySqlCommand(Klaudia);
                            mySqlCommand2.Parameters.AddWithValue("@tytul", textBox1.Text);
                            mySqlCommand2.Parameters.AddWithValue("@wydawnictwo", comboBox2.SelectedValue);
                            mySqlCommand2.Parameters.AddWithValue("@seria", textBox4.Text);
                            mySqlCommand2.Parameters.AddWithValue("@rok_wydania", textBox5.Text);
                            mySqlCommand2.Parameters.AddWithValue("@rok_1wydania", textBox6.Text);
                            mySqlCommand2.Parameters.AddWithValue("@strony", textBox9.Text);
                            mySqlCommand2.Parameters.AddWithValue("@jezyk", textBox8.Text);
                            mySqlCommand2.Parameters.AddWithValue("@jezyk_oryginalny", textBox7.Text);
                            mySqlCommand2.Parameters.AddWithValue("@tlumaczenie", textBox10.Text);
                            mySqlCommand2.Parameters.AddWithValue("@tytul_oryginalny", textBox2.Text);
                            mySqlCommand2.Parameters.AddWithValue("@kategoria", comboBox3.SelectedValue);
                            mySqlCommand2.Connection = database.mySqlConnection;
                            MySqlCommand regQr = new MySqlCommand(Klaudia, database.mySqlConnection);
                            foreach (MySqlParameter p in mySqlCommand2.Parameters)
                            {
                                regQr.Parameters.AddWithValue(p.ParameterName, p.Value);
                            }
                            regQr.ExecuteNonQuery();
                            MySqlCommand mySqlCommand4 = new MySqlCommand(Arek);
                            MySqlCommand regQr3 = new MySqlCommand(Arek, database.mySqlConnection);
                            regQr3.ExecuteNonQuery();
                            n = Convert.ToInt32(comboBox4.SelectedItem.ToString());
                            var set = new HashSet<int>();
                            foreach (ComboBox comboBox in groupBox1.Controls.OfType<ComboBox>())
                            {
                                set.Add(Convert.ToInt32(comboBox.SelectedValue));
                            }
                            foreach (int comboBox in set)
                            {
                                MySqlCommand mySqlCommand3 = new MySqlCommand(Rafaello);
                                mySqlCommand3.Parameters.AddWithValue("@isbn", ISBNa);
                                mySqlCommand3.Parameters.AddWithValue("@autor", comboBox);
                                mySqlCommand3.Connection = database.mySqlConnection;
                                MySqlCommand regQr2 = new MySqlCommand(Rafaello, database.mySqlConnection);
                                foreach (MySqlParameter p in mySqlCommand3.Parameters)
                                {
                                    regQr2.Parameters.AddWithValue(p.ParameterName, p.Value);
                                }
                                regQr2.ExecuteNonQuery();
                            }
                            
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

        private void Form18_FormClosing(object sender, FormClosingEventArgs e)
        {
            paneladmina wyjdz = new paneladmina();
            wyjdz.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            powrot = new Form10();
            powrot.FormClosing += new FormClosingEventHandler(this.Form18_FormClosing);
            this.Hide();
            powrot.ShowDialog();
        }

        private void comboBox4_Click(object sender, EventArgs e)
        {

        }
        private void CreateComboBoxes(int n)
        {

            DataTable dataTable = Database.GetDataTable("SELECT * FROM autorzy");

            List<ComboBox> comboBoxList = new List<ComboBox>();
            for (int i = 4; i < n + 4; i++)
            {
                var dataSource = new List<Authors>();
                foreach (var item in dataTable.AsEnumerable())
                {
                    dataSource.Add(new Authors() { Name = item[1].ToString() + " " + item[2].ToString(), Value = item[0].ToString() });
                }
                ComboBox comboBox = new ComboBox();
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.Location = new System.Drawing.Point(5, 10 + ((i - 4) * 25));
                comboBox.Name = "comboBox" + i;
                comboBox.Size = new System.Drawing.Size(121, 21);
                comboBoxList.Add(comboBox);
                comboBoxList[i - 4].DataSource = dataSource;
                comboBoxList[i - 4].DisplayMember = "Name";
                comboBoxList[i - 4].ValueMember = "Value";
            }
            groupBox1.Controls.Clear();
            foreach (ComboBox comboBox in comboBoxList)
            {
                groupBox1.Controls.Add(comboBox);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex != -1)
            {
                n = Convert.ToInt32(comboBox4.SelectedItem.ToString());
                CreateComboBoxes(n);
            }
        }
    }
}