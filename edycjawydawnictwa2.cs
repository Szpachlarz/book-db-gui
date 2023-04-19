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
    public partial class edycjawydawnictwa2 : formularzwydawnictwo
    {
        edycjawydawnictwa powrot;
        internal string idwydawnictwa2;
        public edycjawydawnictwa2()
        {
            button2.Text = "Edytuj";
            Text = "Edycja wydawnictwa";
        }
        public override void button2_Click(object sender, EventArgs e)
        {
            var database = new Database();
            if (database.connect_db())
            {                
                string query = String.Format("UPDATE wydawnictwa SET nazwa=@nazwa, adres=@adres, miasto=@miasto, kraj=@kraj WHERE id={0}"
                    , idwydawnictwa2);

                MySqlCommand mySqlCommand2 = new MySqlCommand(query);
                mySqlCommand2.Parameters.AddWithValue("@nazwa", textNazwa.Text);
                mySqlCommand2.Parameters.AddWithValue("@adres", textAdres.Text);
                mySqlCommand2.Parameters.AddWithValue("@miasto", textMiasto.Text);
                mySqlCommand2.Parameters.AddWithValue("@kraj", textKraj.Text);
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
        public override void formularzwydawnictwo_Load(object sender, EventArgs e)
        {
            string query2 = String.Format("SELECT nazwa, adres, miasto, kraj FROM wydawnictwa WHERE id={0}"
                , idwydawnictwa2);

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

                textNazwa.Text = dt.Rows[0]["nazwa"].ToString();
                textAdres.Text = dt.Rows[0]["adres"].ToString();
                textMiasto.Text = dt.Rows[0]["miasto"].ToString();
                textKraj.Text = dt.Rows[0]["kraj"].ToString();
            }
            else
            {
                MessageBox.Show("Błąd bazy!");
            }
        }

        public override void textNazwa_Validating(object sender, CancelEventArgs e)
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
        }
    }
}
