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
{    public partial class usuwanieksiazki2 : formularzksiazka
    {
        internal string idksiazki2;
        int n = 0;
        public usuwanieksiazki2()
        {
            button2.Text = "Usuń";
            Text = "Usuwanie książki";
        }
        public override void Form6_Load(object sender, EventArgs e)
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

            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            var dataSource2 = new List<Categories>();
            DataTable dataTable2 = Database.GetDataTable("SELECT * FROM kategorie");
            foreach (var item in dataTable2.AsEnumerable())
            {
                dataSource2.Add(new Categories() { Name = item[1].ToString(), Value = item[0].ToString() });
            }
            comboBox3.DataSource = dataSource2;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Value";

            if (comboBox4.SelectedIndex != -1)
            {
                n = Convert.ToInt32(comboBox4.SelectedItem.ToString());
                CreateComboBoxes(n);
            }

            string query1 = String.Format("SELECT k.tytul, k.seria, k.rok_wydania, k.rok_1wydania, k.strony, k.jezyk, k.jezyk_oryginalny, k.tlumaczenie, k.tytul_oryginalny, k.ISBN, w.nazwa AS wydawnictwo, ka.nazwa AS kategoria FROM ksiazki AS k INNER JOIN wydawnictwa AS w ON k.wydawnictwo=w.id INNER JOIN kategorie AS ka ON ka.id = k.kategoria WHERE id_ksiazki={0}"
                , idksiazki2);
            string query2 = String.Format("SELECT id_ksiazki, autor, au.imiona, au.nazwisko, au.id AS idautora, SUM((SELECT COUNT(*) FROM autorstwo WHERE id_ksiazki={0})) AS suma FROM autorstwo as a RIGHT JOIN autorzy AS au ON au.id=a.autor WHERE id_ksiazki={0} GROUP BY idautora"
                , idksiazki2);
            string query3 = String.Format("SELECT imiona, nazwisko, id FROM autorzy"
                , idksiazki2);
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 1; i < 8; i++)
            {
                comboBox4.Items.Add(i);
            }

            var database = new Database();
            if (database.connect_db())
            {
                MySqlCommand mySqlCommand = new MySqlCommand(query1);
                mySqlCommand.Connection = database.mySqlConnection;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dt;

                database.close_db();

                textTytul.Text = dt.Rows[0]["tytul"].ToString();
                comboBox2.SelectedIndex = comboBox2.FindString(dt.Rows[0]["wydawnictwo"].ToString());
                textSeria.Text = dt.Rows[0]["seria"].ToString();
                textRok_w.Text = dt.Rows[0]["rok_wydania"].ToString();
                textRok_pw.Text = dt.Rows[0]["rok_1wydania"].ToString();
                textStrony.Text = dt.Rows[0]["strony"].ToString();
                textJezyk.Text = dt.Rows[0]["jezyk"].ToString();
                textJezyk_o.Text = dt.Rows[0]["jezyk_oryginalny"].ToString();
                textTlumaczenie.Text = dt.Rows[0]["tlumaczenie"].ToString();
                textTytul_o.Text = dt.Rows[0]["tytul_oryginalny"].ToString();
                textISBN.Text = dt.Rows[0]["ISBN"].ToString();
                comboBox3.SelectedIndex = comboBox3.FindString(dt.Rows[0]["kategoria"].ToString());

                textTytul.ReadOnly = true;
                comboBox2.Enabled = false;
                textSeria.ReadOnly = true;
                textRok_w.ReadOnly = true;
                textRok_pw.ReadOnly = true;
                textStrony.ReadOnly = true;
                textJezyk.ReadOnly = true;
                textJezyk_o.ReadOnly = true;
                textTlumaczenie.ReadOnly = true;
                textTytul_o.ReadOnly = true;
                textISBN.ReadOnly = true;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;

                MySqlCommand mySqlCommand2 = new MySqlCommand(query2);
                mySqlCommand2.Connection = database.mySqlConnection;
                MySqlDataAdapter adapter2 = new MySqlDataAdapter();
                adapter2.SelectCommand = mySqlCommand2;
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);
                BindingSource bindingSource2 = new BindingSource();
                bindingSource2.DataSource = dt2;

                MySqlCommand mySqlCommand3 = new MySqlCommand(query3);
                mySqlCommand3.Connection = database.mySqlConnection;
                MySqlDataAdapter adapter3 = new MySqlDataAdapter();
                adapter3.SelectCommand = mySqlCommand3;
                DataTable dt3 = new DataTable();
                adapter3.Fill(dt3);
                BindingSource bindingSource3 = new BindingSource();
                bindingSource3.DataSource = dt3;

                List<ComboBox> comboBoxList = new List<ComboBox>();
                for (int i = 4; i < Convert.ToInt32(dt2.Rows[0]["suma"]) + 4; i++)
                {
                    var dataSource36 = new List<Authors>();
                    foreach (var item in dt3.AsEnumerable())
                    {
                        dataSource36.Add(new Authors() { Name = item["imiona"].ToString() + " " + item["nazwisko"].ToString(), Value = item["id"].ToString() });
                    }
                    ComboBox comboBox = new ComboBox();
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox.Location = new System.Drawing.Point(5, 10 + ((i - 4) * 25));
                    comboBox.Name = "comboBox" + i;
                    comboBox.Size = new System.Drawing.Size(121, 21);
                    comboBoxList.Add(comboBox);
                    comboBoxList[i - 4].DataSource = dataSource36;
                    comboBoxList[i - 4].DisplayMember = "Name";
                    comboBoxList[i - 4].ValueMember = "Value";
                    comboBoxList[i - 4].Enabled = false;
                }
                panel1.Controls.Clear();
                int arkadia = 0;
                foreach (ComboBox comboBox in comboBoxList)
                {
                    panel1.Controls.Add(comboBox);
                    comboBox.SelectedIndex = comboBox.FindString(dt2.Rows[arkadia]["imiona"].ToString() + " " + dt2.Rows[arkadia]["nazwisko"].ToString());
                    arkadia++;
                }

                database.close_db();
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
                string Klaudia = String.Format("DELETE FROM ksiazki WHERE id_ksiazki={0}", idksiazki2);

                MySqlCommand mySqlCommand2 = new MySqlCommand(Klaudia);
                MySqlCommand regQr = new MySqlCommand(Klaudia, database.mySqlConnection);
                regQr.ExecuteNonQuery();
                           
                database.close_db();
            }
            else
            {
                MessageBox.Show("Database error!");
            }
        }

    }
}
