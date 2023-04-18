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
    public partial class usuwaniekategorii2 : formularzkategoria
    {
        internal string idkategorii2;
        public override void formularzkategoria_Load(object sender, EventArgs e)
        {
            string query = String.Format("SELECT nazwa FROM kategorie WHERE id={0}"
                , idkategorii2);

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

                textKategoria.Text = dt.Rows[0]["nazwa"].ToString();
                textKategoria.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Błąd bazy!");
            }
        }
        public override void button2_Click(object sender, EventArgs e)
        {
            var database = new Database();
            if (database.connect_db())
            {
                string query2 = String.Format("DELETE FROM kategorie WHERE id={0}"
                    , idkategorii2);

                MySqlCommand mySqlCommand2 = new MySqlCommand(query2);
                MySqlCommand regQr = new MySqlCommand(query2, database.mySqlConnection);
                try
                {
                    regQr.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nie można usunąć kategorii, jest przypisana do książki");
                    return;
                }
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
