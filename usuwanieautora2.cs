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
    public partial class usuwanieautora2 : formularzautor
    {
        internal string idautora2;
        public override void Form7_Load(object sender, EventArgs e)
        {
            string query = String.Format("SELECT imiona, nazwisko, data_urodzenia, data_smierci, narodowosc FROM autorzy WHERE id={0}"
                , idautora2);

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

                textImiona.Text = dt.Rows[0]["imiona"].ToString();
                textNazwisko.Text = dt.Rows[0]["nazwisko"].ToString();
                textData_ur.Text = dt.Rows[0]["data_urodzenia"].ToString();
                textData_sm.Text = dt.Rows[0]["data_smierci"].ToString();
                textNarodowosc.Text = dt.Rows[0]["narodowosc"].ToString();

                textImiona.ReadOnly = true;
                textNazwisko.ReadOnly = true;
                textData_ur.ReadOnly = true;
                textData_sm.ReadOnly = true;
                textNarodowosc.ReadOnly = true;
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
                string query2 = String.Format("DELETE FROM autorzy WHERE id={0}"
                    , idautora2);

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
