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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projekt
{
    public partial class edycjaautora2 : formularzautor
    {
        edycjaautora powrot;
        internal string idautora2;
        /*public override string query
        {
            get { return "UPDATE autorzy SET imiona=@imiona, nazwisko=@nazwisko, data_urodzenia=@data_urodzenia, data_smierci=@data_smierci, narodowosc=@narodowosc WHERE id={0}", idautora2; }
        }*/

        public override void Form7_Load(object sender, EventArgs e)
        {
            string query2 = String.Format("SELECT imiona, nazwisko, data_urodzenia, data_smierci, narodowosc FROM autorzy WHERE id={0}"
                , idautora2);

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

                textImiona.Text = dt.Rows[0]["imiona"].ToString();
                textNazwisko.Text = dt.Rows[0]["nazwisko"].ToString();
                textData_ur.Text = dt.Rows[0]["data_urodzenia"].ToString();
                textData_sm.Text = dt.Rows[0]["data_smierci"].ToString();
                textNarodowosc.Text = dt.Rows[0]["narodowosc"].ToString();
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
                string query = String.Format("UPDATE autorzy SET imiona=@imiona, nazwisko=@nazwisko, data_urodzenia=@data_urodzenia, data_smierci=@data_smierci, narodowosc=@narodowosc WHERE id={0}"
                , idautora2);

                MySqlCommand mySqlCommand2 = new MySqlCommand(query);
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
                MessageBox.Show("Database error!");
            }
        }
    }
}
