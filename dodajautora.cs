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
    public partial class dodajautora : Form
    {
        paneladmina powrot;
        public dodajautora()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                var database = new Database();
                if (database.connect_db())
                {
                    string insertAutor = String.Format("INSERT INTO autorzy(imiona, nazwisko, data_urodzenia, data_smierci, narodowosc) VALUES(@imiona, @nazwisko, @data_urodzenia, @data_smierci, @narodowosc)");

                    MySqlCommand mySqlCommand2 = new MySqlCommand(insertAutor);
                    mySqlCommand2.Parameters.AddWithValue("@imiona", textImiona.Text);
                    mySqlCommand2.Parameters.AddWithValue("@nazwisko", textNazwisko.Text);
                    mySqlCommand2.Parameters.AddWithValue("@data_urodzenia", textData_ur.Text);
                    if (textData_sm.Enabled == true)
                    {
                        mySqlCommand2.Parameters.AddWithValue("@data_smierci", textData_sm.Text);
                    }
                    else
                    {
                        mySqlCommand2.Parameters.AddWithValue("@data_smierci", null);
                    }
                    mySqlCommand2.Parameters.AddWithValue("@narodowosc", textNarodowosc.Text);
                    mySqlCommand2.Connection = database.mySqlConnection;
                    MySqlCommand regQr = new MySqlCommand(insertAutor, database.mySqlConnection);
                    foreach (MySqlParameter p in mySqlCommand2.Parameters)
                    {
                        regQr.Parameters.AddWithValue(p.ParameterName, p.Value);
                    }
                    regQr.ExecuteNonQuery();
                    database.close_db();
                    ClearTextBoxes();
                    MessageBox.Show("Dodano!");
                }
                else
                {
                    MessageBox.Show("Błąd!");
                }
            }
        }
        
        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            paneladmina wyjdz = new paneladmina();
            wyjdz.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            powrot = new paneladmina();
            powrot.FormClosing += new FormClosingEventHandler(this.Form7_FormClosing);
            this.Hide();
            powrot.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textData_sm.Enabled = false;
            }
            else
            {
                textData_sm.Enabled = true;
            }
        }

        private void textImiona_Validating(object sender, CancelEventArgs e)
        {
            Regex strnCheck = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ .\-']+$");
            Match matchImie = strnCheck.Match(textImiona.Text);
            if (string.IsNullOrWhiteSpace(textImiona.Text) || !matchImie.Success)
            {
                e.Cancel = true;
                textImiona.Focus();
                errorProvider1.SetError(textImiona, "Błędne dane!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textImiona, "");
            }
        }
        private void textNazwisko_Validating(object sender, CancelEventArgs e)
        {
            Regex strnCheck = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ .\-']+$");
            Match matchNazwisko = strnCheck.Match(textNazwisko.Text);
            if (string.IsNullOrWhiteSpace(textNazwisko.Text) || !matchNazwisko.Success)
            {
                e.Cancel = true;
                textNazwisko.Focus();
                errorProvider2.SetError(textNazwisko, "Błędne dane!");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(textNazwisko, "");
            }
        }
        private void textData_ur_Validating(object sender, CancelEventArgs e)
        {
            Regex intCheck = new Regex(@"^\d+$");
            Match matchRok = intCheck.Match(textData_ur.Text);
            if (string.IsNullOrWhiteSpace(textData_ur.Text) || !matchRok.Success || Int32.Parse(textData_ur.Text) > DateTime.Now.Year || Int32.Parse(textData_sm.Text) < 1)
            {
                e.Cancel = true;
                textData_ur.Focus();
                errorProvider3.SetError(textData_ur, "Błędne dane!");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(textData_ur, "");
            }
        }
        private void textData_sm_Validating(object sender, CancelEventArgs e)
        {
            if (textData_sm.Enabled == true)
            {
                Regex intCheck = new Regex(@"^\d+$");
                Match matchRok = intCheck.Match(textData_sm.Text);
                if (string.IsNullOrWhiteSpace(textData_sm.Text) || !matchRok.Success || Int32.Parse(textData_sm.Text) > DateTime.Now.Year || Int32.Parse(textData_ur.Text) > Int32.Parse(textData_sm.Text) || Int32.Parse(textData_sm.Text) < 1)
                {
                    e.Cancel = true;
                    textData_sm.Focus();
                    errorProvider4.SetError(textData_sm, "Błędne dane!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider4.SetError(textData_sm, "");
                }
            }
        }
        private void textNarodowosc_Validating(object sender, CancelEventArgs e)
        {
            Regex stringCheck = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ .\-]+$");
            Match matchNarodowosc = stringCheck.Match(textNarodowosc.Text);
            if (string.IsNullOrWhiteSpace(textNarodowosc.Text) || !matchNarodowosc.Success)
            {
                e.Cancel = true;
                textNarodowosc.Focus();
                errorProvider5.SetError(textNarodowosc, "Błędne dane!");
            }
            else
            {
                e.Cancel = false;
                errorProvider5.SetError(textNarodowosc, "");
            }
        }
        private void ClearTextBoxes()
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
