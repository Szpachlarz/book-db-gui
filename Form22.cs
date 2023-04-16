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
    public partial class Form22 : Form
    {
        internal string Kludiunia;
        int n = 0;
        Form14 powrot;

        public Form22()
        {
            InitializeComponent();
        }

        private void Form22_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form14 wyjdz = new Form14();
            wyjdz.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            powrot = new Form14();
            powrot.FormClosing += new FormClosingEventHandler(this.Form22_FormClosing);
            this.Hide();
            powrot.ShowDialog();
        }

        private void Form22_Load(object sender, EventArgs e)
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

            string Kaludia = String.Format("SELECT tytul, wydawnictwo, seria, rok_wydania, rok_1wydania, strony, jezyk, jezyk_oryginalny, tlumaczenie, tytul_oryginalny, kategoria, ISBN, w.nazwa AS kaludyna, ka.nazwa AS kornel FROM ksiazki AS k INNER JOIN wydawnictwa AS w ON k.wydawnictwo=w.id INNER JOIN kategorie AS ka ON ka.id = k.kategoria WHERE ISBN={0}"
                , Kludiunia);
            string Arkadiusz = String.Format("SELECT ISBN, autor, au.imiona, au.nazwisko, au.id AS caludia, SUM((SELECT COUNT(*) FROM autorstwo WHERE ISBN={0})) AS claudia FROM autorstwo as a RIGHT JOIN autorzy AS au ON au.id=a.autor WHERE ISBN={0} GROUP BY caludia"
                , Kludiunia);
            string Rafalala = String.Format("SELECT imiona, nazwisko, id FROM autorzy"
                , Kludiunia);
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 1; i < 8; i++)
            {
                comboBox4.Items.Add(i);
            }

            var database = new Database();
            if (database.connect_db())
            {
                MySqlCommand mySqlCommand = new MySqlCommand(Kaludia);
                mySqlCommand.Connection = database.mySqlConnection;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dt;

                database.close_db();

                textBox1.Text = dt.Rows[0]["tytul"].ToString();
                comboBox2.SelectedIndex = comboBox2.FindString(dt.Rows[0]["kaludyna"].ToString());
                textBox4.Text = dt.Rows[0]["seria"].ToString();
                textBox5.Text = dt.Rows[0]["rok_wydania"].ToString();
                textBox6.Text = dt.Rows[0]["rok_1wydania"].ToString();
                textBox9.Text = dt.Rows[0]["strony"].ToString();
                textBox8.Text = dt.Rows[0]["jezyk"].ToString();
                textBox7.Text = dt.Rows[0]["jezyk_oryginalny"].ToString();
                textBox10.Text = dt.Rows[0]["tlumaczenie"].ToString();
                textBox2.Text = dt.Rows[0]["tytul_oryginalny"].ToString();
                comboBox3.SelectedIndex = comboBox3.FindString(dt.Rows[0]["kornel"].ToString());

                MySqlCommand mySqlCommand2 = new MySqlCommand(Arkadiusz);
                mySqlCommand2.Connection = database.mySqlConnection;
                MySqlDataAdapter adapter2 = new MySqlDataAdapter();
                adapter2.SelectCommand = mySqlCommand2;
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);
                BindingSource bindingSource2 = new BindingSource();
                bindingSource2.DataSource = dt2;

                MySqlCommand mySqlCommand3 = new MySqlCommand(Rafalala);
                mySqlCommand3.Connection = database.mySqlConnection;
                MySqlDataAdapter adapter3 = new MySqlDataAdapter();
                adapter3.SelectCommand = mySqlCommand3;
                DataTable dt3 = new DataTable();
                adapter3.Fill(dt3);
                BindingSource bindingSource3 = new BindingSource();
                bindingSource3.DataSource = dt3;

                List<ComboBox> comboBoxList = new List<ComboBox>();
                for (int i = 4; i < Convert.ToInt32(dt2.Rows[0]["claudia"]) + 4; i++)
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
                }
                groupBox1.Controls.Clear();
                int arkadia = 0;
                foreach (ComboBox comboBox in comboBoxList)
                {
                    groupBox1.Controls.Add(comboBox);
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

        public class Authors
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        public class Publishers
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        public class Categories
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var database = new Database();
            if (database.connect_db())
            {

                            string Klaudia = String.Format("DELETE FROM ksiazki WHERE ISBN={0}", Kludiunia);

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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex != -1)
            {
                n = Convert.ToInt32(comboBox4.SelectedItem.ToString());
                CreateComboBoxes(n);
            }
        }

        private void CreateComboBoxes(int n)
        {

            DataTable dataTable = Database.GetDataTable("SELECT * FROM autorzy");

            List<ComboBox> comboBoxList = new List<ComboBox>();
            for (int i = 4; i < n + 4; i++)
            {
                var dataSource = new List<Authors>();
                foreach (var item in dataTable.AsEnumerable())
                {
                    dataSource.Add(new Authors() { Name = item[1].ToString() + " " + item[2].ToString(), Value = item[0].ToString() });
                }
                ComboBox comboBox = new ComboBox();
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.Location = new System.Drawing.Point(5, 10 + ((i - 4) * 25));
                comboBox.Name = "comboBox" + i;
                comboBox.Enabled = false;
                comboBox.Size = new System.Drawing.Size(121, 21);
                comboBoxList.Add(comboBox);
                comboBoxList[i - 4].DataSource = dataSource;
                comboBoxList[i - 4].DisplayMember = "Name";
                comboBoxList[i - 4].ValueMember = "Value";
                
            }
            groupBox1.Controls.Clear();
            foreach (ComboBox comboBox in comboBoxList)
            {
                groupBox1.Controls.Add(comboBox);
            }
        }
    }
}
