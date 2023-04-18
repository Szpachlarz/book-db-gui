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
    public partial class usuwaniewydawnictwa2 : formularzwydawnictwo
    {
        internal string idwydawnictwa;        
        public override void formularzwydawnictwo_Load(object sender, EventArgs e)
        {
            string query = String.Format("SELECT nazwa, adres, miasto, kraj FROM wydawnictwa WHERE id={0}"
                , idwydawnictwa);

            var database = new Database();
            if (database.connect_db())
            {
                MySqlCommand mySqlCommand = new MySqlCommand(query);
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

                textNazwa.ReadOnly= true;
                textAdres.ReadOnly = true;
                textMiasto.ReadOnly = true;
                textKraj.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Database error!");
            }
        }
        public override void button2_Click(object sender, EventArgs e)
        {
            var database = new Database();
            if (database.connect_db())
            {
                string query2 = String.Format("DELETE FROM wydawnictwa WHERE id={0}"
                    , idwydawnictwa);

                MySqlCommand mySqlCommand2 = new MySqlCommand(query2);
                MySqlCommand regQr = new MySqlCommand(query2, database.mySqlConnection);
                regQr.ExecuteNonQuery();

                database.close_db();
                MessageBox.Show("Usunięto!");
            }
            else
            {
                MessageBox.Show("Błąd bazy!");
            }
        }
    }
}
