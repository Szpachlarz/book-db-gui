using MySql.Data.MySqlClient;
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
    public partial class formularzwydawnictwo : Form
    {
        paneladmina powrot;
        public virtual string query
        {
            get { return ""; }
        }
        public formularzwydawnictwo()
        {
            InitializeComponent();
        }

        public void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            paneladmina wyjdz = new paneladmina();
            wyjdz.Show();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            powrot = new paneladmina();
            powrot.FormClosing += new FormClosingEventHandler(this.Form8_FormClosing);
            this.Hide();
            powrot.ShowDialog();
        }

        public virtual void button2_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                var database = new Database();
                if (database.connect_db())
                {
                    string insertWydawnictwo = String.Format("INSERT INTO wydawnictwa(nazwa, adres, miasto, kraj) VALUES(@nazwa, @adres, @miasto, @kraj)");
                    MySqlCommand mySqlCommand2 = new MySqlCommand(insertWydawnictwo);
                    mySqlCommand2.Parameters.AddWithValue("@nazwa", textNazwa.Text);
                    mySqlCommand2.Parameters.AddWithValue("@adres", textAdres.Text);
                    mySqlCommand2.Parameters.AddWithValue("@miasto", textMiasto.Text);
                    mySqlCommand2.Parameters.AddWithValue("@kraj", textKraj.Text);
                    mySqlCommand2.Connection = database.mySqlConnection;
                    MySqlCommand regQr = new MySqlCommand(insertWydawnictwo, database.mySqlConnection);
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
        public virtual void textNazwa_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNazwa.Text) || textNazwa.Text.Length > 30)
            {
                e.Cancel = true;
                textNazwa.Focus();
                errorProvider1.SetError(textNazwa, "Błędne dane!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textNazwa, "");
            }
            var database = new Database();
            if (database.connect_db())
            {
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT nazwa FROM wydawnictwa WHERE nazwa=@nazwa");
                mySqlCommand.Parameters.AddWithValue("@nazwa", textNazwa.Text);
                mySqlCommand.Connection = database.mySqlConnection;
                MySqlDataAdapter checkNazwa = new MySqlDataAdapter(mySqlCommand);
                DataTable checkNazwa2 = new DataTable();
                checkNazwa.Fill(checkNazwa2);
                if (checkNazwa2.Rows.Count > 0)
                {
                    e.Cancel = true;
                    textNazwa.Focus();
                    errorProvider1.SetError(textNazwa, "Podane wydawnictwo już istnieje!");
                }
                database.close_db();
            }
            else
            {
                MessageBox.Show("Błąd połączenia z bazą!");
            }
        }

        public void textAdres_Validating(object sender, CancelEventArgs e)
        {
            Regex stringaCheck = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ0-9\s.-]+$");
            Match matchAdres = stringaCheck.Match(textAdres.Text);
            if (string.IsNullOrWhiteSpace(textAdres.Text) || textAdres.Text.Length > 30 || !matchAdres.Success)
            {
                e.Cancel = true;
                textAdres.Focus();
                errorProvider2.SetError(textAdres, "Błędne dane!");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(textAdres, "");
            }
        }
        public void textMiasto_Validating(object sender, CancelEventArgs e)
        {
            Regex stringbCheck = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s.-]+$");
            Match matchMiasto = stringbCheck.Match(textMiasto.Text);
            if (string.IsNullOrWhiteSpace(textMiasto.Text) || textMiasto.Text.Length > 30 || !matchMiasto.Success)
            {
                e.Cancel = true;
                textMiasto.Focus();
                errorProvider3.SetError(textMiasto, "Błędne dane!");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(textMiasto, "");
            }
        }

        public void textKraj_Validating(object sender, CancelEventArgs e)
        {
            Regex stringcCheck = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ\s]+$");
            Match matchKraj = stringcCheck.Match(textKraj.Text);
            if (string.IsNullOrWhiteSpace(textKraj.Text) || textKraj.Text.Length > 30 || !matchKraj.Success)
            {
                e.Cancel = true;
                textKraj.Focus();
                errorProvider4.SetError(textKraj, "Błędne dane!");
            }
            else
            {
                e.Cancel = false;
                errorProvider4.SetError(textKraj, "");
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
        public virtual void formularzwydawnictwo_Load(object sender, EventArgs e)
        {

        }
    }
}
