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
    public partial class formularzkategoria : Form
    {
        public virtual string query
        {
            get { return ""; }
        }
        paneladmina powrot;
        public formularzkategoria()
        {
            InitializeComponent();
        }
        public virtual void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            powrot = new paneladmina();
            powrot.FormClosing += new FormClosingEventHandler(this.Form9_FormClosing);
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
                    string insertKategoria = String.Format("INSERT INTO kategorie(nazwa) VALUES(@nazwa)");

                    MySqlCommand mySqlCommand2 = new MySqlCommand(insertKategoria);
                    mySqlCommand2.Parameters.AddWithValue("@nazwa", textKategoria.Text);
                    mySqlCommand2.Connection = database.mySqlConnection;
                    MySqlCommand regQr = new MySqlCommand(insertKategoria, database.mySqlConnection);
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
                    MessageBox.Show("Database error!");
                }
            }
        }
        public virtual void textKategoria_Validating(object sender, CancelEventArgs e)
        {
            Regex stringCheck = new Regex(@"^[a-zA-ZąćęłńóśźżĄĆĘŁŃÓŚŹŻ .\-]+$");
            Match matchKategoria = stringCheck.Match(textKategoria.Text);
            if (string.IsNullOrWhiteSpace(textKategoria.Text) || textKategoria.Text.Length > 30 || !matchKategoria.Success)
            {
                e.Cancel = true;
                textKategoria.Focus();
                errorProvider1.SetError(textKategoria, "Błędne dane!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textKategoria, "");
            }
            var database = new Database();
            if (database.connect_db())
            {
                MySqlCommand mySqlCommand = new MySqlCommand("SELECT nazwa FROM kategorie WHERE nazwa=@nazwa");
                mySqlCommand.Parameters.AddWithValue("@nazwa", textKategoria.Text);
                mySqlCommand.Connection = database.mySqlConnection;
                MySqlDataAdapter checkNazwa = new MySqlDataAdapter(mySqlCommand);
                DataTable checkNazwa2 = new DataTable();
                checkNazwa.Fill(checkNazwa2);
                if (checkNazwa2.Rows.Count > 0)
                {
                    e.Cancel = true;
                    textKategoria.Focus();
                    errorProvider1.SetError(textKategoria, "Podana kategoria już istnieje!");
                }
                database.close_db();
            }
            else
            {
                MessageBox.Show("Błąd połączenia z bazą!");
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

        public virtual void formularzkategoria_Load(object sender, EventArgs e)
        {

        }
    }
}
