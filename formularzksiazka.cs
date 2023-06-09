﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt
{
    public partial class formularzksiazka : Form
    {
        public virtual string query
        {
            get { return ""; }
        }

        public virtual string query2
        {
            get { return ""; }
        }

        paneladmina powrot;
        int n = 0;
        public formularzksiazka()
        {
            InitializeComponent();
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

        public void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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
        }

        public void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            var dataSource = new List<Categories>();
            DataTable dataTable = Database.GetDataTable("SELECT * FROM kategorie");
            foreach (var item in dataTable.AsEnumerable())
            {
                dataSource.Add(new Categories() { Name = item[1].ToString(), Value = item[0].ToString() });
            }
            comboBox3.DataSource = dataSource;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Value";
        }

        public virtual void button2_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                var database = new Database();
                if (database.connect_db())
                {
                    string insertksiazka = String.Format(query);
                    string insertautorstwo = String.Format(query2);

                    MySqlCommand mySqlCommand2 = new MySqlCommand(insertksiazka);
                    mySqlCommand2.Parameters.AddWithValue("@tytul", textTytul.Text);
                    mySqlCommand2.Parameters.AddWithValue("@wydawnictwo", comboBox2.SelectedValue);
                    mySqlCommand2.Parameters.AddWithValue("@seria", textSeria.Text);
                    mySqlCommand2.Parameters.AddWithValue("@rok_wydania", textRok_w.Text);
                    mySqlCommand2.Parameters.AddWithValue("@rok_1wydania", textRok_pw.Text);
                    mySqlCommand2.Parameters.AddWithValue("@strony", textStrony.Text);
                    mySqlCommand2.Parameters.AddWithValue("@jezyk", textJezyk.Text);
                    mySqlCommand2.Parameters.AddWithValue("@jezyk_oryginalny", textJezyk_o.Text);
                    mySqlCommand2.Parameters.AddWithValue("@tlumaczenie", textTlumaczenie.Text);
                    mySqlCommand2.Parameters.AddWithValue("@tytul_oryginalny", textTytul_o.Text);
                    mySqlCommand2.Parameters.AddWithValue("@kategoria", comboBox3.SelectedValue);
                    mySqlCommand2.Parameters.AddWithValue("@isbn", textISBN.Text);
                    mySqlCommand2.Connection = database.mySqlConnection;
                    MySqlCommand regQr = new MySqlCommand(insertksiazka, database.mySqlConnection);
                    foreach (MySqlParameter p in mySqlCommand2.Parameters)
                    {
                        regQr.Parameters.AddWithValue(p.ParameterName, p.Value);
                    }
                    regQr.ExecuteNonQuery();
                    n = Convert.ToInt32(comboBox4.SelectedItem.ToString());
                    var set = new HashSet<int>();
                    foreach (ComboBox comboBox in panel1.Controls.OfType<ComboBox>())
                    {
                        set.Add(Convert.ToInt32(comboBox.SelectedValue));
                    }
                    string id_ksiazki = String.Format("SELECT id_ksiazki FROM ksiazki WHERE ISBN='{0}'", textISBN.Text);
                    MySqlCommand mySqlCommand4 = new MySqlCommand(id_ksiazki);
                    mySqlCommand4.Connection = database.mySqlConnection;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(id_ksiazki, mySqlCommand4.Connection);
                    DataTable myDataSet = new DataTable();
                    adapter.Fill(myDataSet);
                    string id_ksiazki2 = myDataSet.Rows[0][0].ToString();
                    Console.WriteLine(id_ksiazki2);
                    foreach (int comboBox in set)
                    {
                        MySqlCommand mySqlCommand3 = new MySqlCommand(insertautorstwo);
                        mySqlCommand3.Parameters.AddWithValue("@autor", comboBox);
                        mySqlCommand3.Parameters.AddWithValue("@id_ksiazki", id_ksiazki2);
                        mySqlCommand3.Connection = database.mySqlConnection;
                        MySqlCommand regQr2 = new MySqlCommand(insertautorstwo, database.mySqlConnection);
                        foreach (MySqlParameter p in mySqlCommand3.Parameters)
                        {
                            regQr2.Parameters.AddWithValue(p.ParameterName, p.Value);
                        }
                        regQr2.ExecuteNonQuery();

                    }
                    database.close_db();
                    ClearTextBoxes();
                    MessageBox.Show("Dodano!");
                }
                else
                {
                    MessageBox.Show("Błąd połączenia z bazą!");
                }
            }
        }
        public virtual void Form6_Load(object sender, EventArgs e)
        {
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 1; i < 8; i++)
            {
                comboBox4.Items.Add(i);
            }
        }
        public void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        public void button1_Click(object sender, EventArgs e)
        {
            powrot = new paneladmina();
            powrot.FormClosing += new FormClosingEventHandler(this.Form6_FormClosing);
            this.Hide();
            powrot.ShowDialog();
        }
        public void CreateComboBoxes(int n)
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
                comboBox.Location = new Point(5, 10 + ((i - 4) * 25));
                comboBox.Name = "comboBox" + i;
                comboBox.Size = new Size(121, 21);
                comboBoxList.Add(comboBox);
                comboBoxList[i - 4].DataSource = dataSource;
                comboBoxList[i - 4].DisplayMember = "Name";
                comboBoxList[i - 4].ValueMember = "Value";
            }
            panel1.Controls.Clear();
            foreach (ComboBox comboBox in comboBoxList)
            {
                panel1.Controls.Add(comboBox);
            }
        }
        public void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex != -1)
            {
                n = Convert.ToInt32(comboBox4.SelectedItem.ToString());
                CreateComboBoxes(n);
            }
        }
        public void textTytul_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textTytul.Text))
            {
                e.Cancel = true;
                textTytul.Focus();
                errorProvider1.SetError(textTytul, "Błędne dane!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textTytul, "");
            }
        }
        public void textSeria_Validating(object sender, CancelEventArgs e)
        {
            Regex check = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ .\-]*$");
            Match matchSeria = check.Match(textSeria.Text);
            if (!matchSeria.Success)
            {
                e.Cancel = true;
                textSeria.Focus();
                errorProvider2.SetError(textSeria, "Błędne dane!");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(textSeria, "");
            }
        }
        public void textRok_w_Validating(object sender, CancelEventArgs e)
        {
            Regex intCheck = new Regex(@"^\d+$");
            Match matchRok = intCheck.Match(textRok_w.Text);
            if (string.IsNullOrWhiteSpace(textRok_w.Text) || !matchRok.Success || Int32.Parse(textRok_w.Text) > DateTime.Now.Year || Int32.Parse(textRok_w.Text) < 1)
            {
                e.Cancel = true;
                textRok_w.Focus();
                errorProvider3.SetError(textRok_w, "Błędne dane!");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(textRok_w, "");
            }
        }
        public void textRok_pw_Validating(object sender, CancelEventArgs e)
        {
            Regex intCheck = new Regex(@"^\d*$");
            Match matchRok = intCheck.Match(textRok_pw.Text);
            if (!string.IsNullOrEmpty(textRok_pw.Text))
            {
                if (!matchRok.Success || Int32.Parse(textRok_pw.Text) > DateTime.Now.Year || Int32.Parse(textRok_pw.Text) > Int32.Parse(textRok_w.Text) || Int32.Parse(textRok_pw.Text) < 1)
                {
                    e.Cancel = true;
                    textRok_pw.Focus();
                    errorProvider4.SetError(textRok_pw, "Błędne dane!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider4.SetError(textRok_pw, "");
                }
            }
        }
        public void textStrony_Validating(object sender, CancelEventArgs e)
        {
            Regex intCheck = new Regex(@"^\d+$");
            Match matchStrony = intCheck.Match(textStrony.Text);
            if (string.IsNullOrWhiteSpace(textStrony.Text) || !matchStrony.Success)
            {
                e.Cancel = true;
                textStrony.Focus();
                errorProvider5.SetError(textStrony, "Błędne dane!");
            }
            else
            {
                e.Cancel = false;
                errorProvider5.SetError(textStrony, "");
            }
        }
        public void textJezyk_Validating(object sender, CancelEventArgs e)
        {
            Regex stringCheck = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ \-]+$");
            Match matchJezyk = stringCheck.Match(textJezyk.Text);
            if (string.IsNullOrWhiteSpace(textJezyk.Text) || !matchJezyk.Success)
            {
                e.Cancel = true;
                textJezyk.Focus();
                errorProvider6.SetError(textJezyk, "Błędne dane!");
            }
            else
            {
                e.Cancel = false;
                errorProvider6.SetError(textJezyk, "");
            }
        }
        public void textJezyk_o_Validating(object sender, CancelEventArgs e)
        {
            Regex stringCheck = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ \-]*$");
            Match matchJezyk = stringCheck.Match(textJezyk_o.Text);
            if (!matchJezyk.Success)
            {
                e.Cancel = true;
                textJezyk_o.Focus();
                errorProvider7.SetError(textJezyk_o, "Błędne dane!");
            }
            else
            {
                e.Cancel = false;
                errorProvider7.SetError(textJezyk_o, "");
            }
        }
        public virtual void textISBN_Validating(object sender, CancelEventArgs e)
        {
            Regex intCheck = new Regex(@"^\d+$");
            Match matchISBN = intCheck.Match(textISBN.Text);
            if (string.IsNullOrWhiteSpace(textISBN.Text) || !matchISBN.Success)
            {
                e.Cancel = true;
                textISBN.Focus();
                errorProvider8.SetError(textISBN, "Błędne dane!");
            }
            else
            {
                e.Cancel = false;
                errorProvider8.SetError(textISBN, "");
            }
            var database = new Database();
            if (database.connect_db())
            {
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT ISBN FROM ksiazki WHERE ISBN=@isbn");
                mySqlCommand.Parameters.AddWithValue("@isbn", textISBN.Text);
                mySqlCommand.Connection = database.mySqlConnection;
                MySqlDataAdapter checkISBNy = new MySqlDataAdapter(mySqlCommand);
                DataTable checkISBNs = new DataTable();
                checkISBNy.Fill(checkISBNs);
                //jeśli w bazie znajdują się rekordy zawierające podany numer ISBN, zostanie wyświetlony komunikat
                if (checkISBNs.Rows.Count > 0)
                {
                    e.Cancel = true;
                    textISBN.Focus();
                    errorProvider8.SetError(textISBN, "Podany numer ISBN już istnieje!");
                }
                database.close_db();
            }
            else
            {
                MessageBox.Show("Błąd połączenia z bazą!");
            }
        }

        public void textTlumaczenie_Validating(object sender, CancelEventArgs e)
        {
            Regex check = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ .\-]*$");
            Match matchTlumaczenie = check.Match(textTlumaczenie.Text);
            if (!matchTlumaczenie.Success)
            {
                e.Cancel = true;
                textTlumaczenie.Focus();
                errorProvider9.SetError(textTlumaczenie, "Błędne dane!");
            }
            else
            {
                e.Cancel = false;
                errorProvider9.SetError(textTlumaczenie, "");
            }
        }
        public void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

    }
}

