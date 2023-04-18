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
    public partial class edycjakategorii2 : formularzkategoria
    {
        internal string idkategorii2;
        public override void button2_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                var database = new Database();
                if (database.connect_db())
                {
                    string query = String.Format("UPDATE kategorie SET nazwa=@nazwa WHERE id={0}"
                        , idkategorii2);

                    MySqlCommand mySqlCommand2 = new MySqlCommand(query);
                    mySqlCommand2.Parameters.AddWithValue("@nazwa", textKategoria.Text);
                    mySqlCommand2.Connection = database.mySqlConnection;
                    MySqlCommand regQr = new MySqlCommand(query, database.mySqlConnection);
                    foreach (MySqlParameter p in mySqlCommand2.Parameters)
                    {
                        regQr.Parameters.AddWithValue(p.ParameterName, p.Value);
                    }
                    regQr.ExecuteNonQuery();
                    database.close_db();
                    MessageBox.Show("Zapisano!");
                }
                else
                {
                    MessageBox.Show("Błąd bazy!");
                }
            }
        }
        public override void formularzkategoria_Load(object sender, EventArgs e)
        {
            string query2 = String.Format("SELECT nazwa FROM kategorie WHERE id={0}"
                , idkategorii2);

            var database = new Database();
            if (database.connect_db())
            {
                MySqlCommand mySqlCommand = new MySqlCommand(query2);
                mySqlCommand.Connection = database.mySqlConnection;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dt;

                database.close_db();

                textKategoria.Text = dt.Rows[0]["nazwa"].ToString();
            }
            else
            {
                MessageBox.Show("Błąd bazy!");
            }
        }
        public override void textKategoria_Validating(object sender, CancelEventArgs e)
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
        }
    }
}
