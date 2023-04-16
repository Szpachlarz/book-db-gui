using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace projekt
{
    public partial class Form2 : Form
    {
        //panel użytkownika i rozliczeń
        //zainicjowanie połączenia z bazą danych
        public static Form2 Instance;
        //zmienne dla nowych formularzy
        Form3 editForm;
        stronastartowa wroc;

        public void LogButton_Click(object sender, EventArgs e)
        {
            var database = new Database();
            if (database.connect_db())
            {
                string login = String.Format("SELECT * FROM recenzje AS r LEFT JOIN uzytkownicy AS u ON  WHERE '"
                ); //pobranie z bazy danych użytkownika z Emailem i hasłem wpisanych w polach panelu
                MySqlCommand mySqlCommand = new MySqlCommand(login);
                mySqlCommand.Connection = database.mySqlConnection;
                MySqlDataAdapter checkLog = new MySqlDataAdapter(login, mySqlCommand.Connection);
                DataTable checkLogTable = new DataTable();

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = checkLogTable;
                dataGridView1.DataSource = bindingSource;
            }
            else
            {
                MessageBox.Show("Database error!");
            }
        }

        public Form2(int id)
        {
            var database = new Database();
            string query = "SELECT k.tytul, a.imiona, a.nazwisko FROM ksiazki AS k INNER JOIN autorzy AS a ON k.autor = a.id";
            MySqlCommand mySqlCommand = new MySqlCommand(query);
            mySqlCommand.Connection = database.mySqlConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = mySqlCommand;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dt;

            dataGridView1 = new DataGridView();
            dataGridView1.DataSource = bindingSource;

            database.close_db();

             InitializeComponent();
             /*//pobranie danych zalogowanego użytkownika z bazy danych
             string getData = string.Format("SELECT * FROM UsersTab WHERE ID='{0}'", id);
             SqlDataAdapter checkLog = new SqlDataAdapter(getData, cn);
             DataTable checkLogTable = new DataTable();
             checkLog.Fill(checkLogTable);
             //wpisanie do klasy statycznej UserData danych zawierającej dane użytkownika
             //danych z bazy
             UserData.Name = checkLogTable.Rows[0]["Name"].ToString();
             UserData.Surname = checkLogTable.Rows[0]["Surname"].ToString();
             UserData.Email = checkLogTable.Rows[0]["Email"].ToString();
             UserData.Country = checkLogTable.Rows[0]["Country"].ToString();
             UserData.Passwd = checkLogTable.Rows[0]["Passwd"].ToString();
             UserData.Id = Int32.Parse(checkLogTable.Rows[0]["ID"].ToString());
             Instance = this;
             //wpisanie do panelu użytkownika jego danych
             label1.Text = UserData.Name;
             label2.Text = UserData.Surname;
             label3.Text = UserData.Country;
             label4.Text = UserData.Email;
             //wyświetlenie panelu użytkownika przy otwarciu formularza
             //i schowanie panelu z rozliczeniami
             userProfile.Visible = true;
             PITforms.Visible = false; */

        }

        public Form2()
        {
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {   
            //otwarcie panelu logowania
            //po zamknięciu aktualnego panelu
            logowanie logForm=new logowanie();
            logForm.Show();
        }


        //podświetlenie przycisku po najechaniu
        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = SystemColors.HighlightText;
        }

        //powrót do poprzedniego koloru
        //jeśli nie jest otwarty panel użytkownika
        private void label5_MouseLeave(object sender, EventArgs e)
        {
            if (userProfile.Visible == false)
            {
                label5.ForeColor = SystemColors.MenuHighlight;
            }
        }

        //otwarcie okna edycji profilu użytkownika
        //dodanie obsługi zdarzenia
        //która pozwala na aktualizacje danych w panelu użytkownika
        //po zamknięciu okna
        private void editButton_Click(object sender, EventArgs e)
        {
            editForm = new Form3();
            editForm.FormClosing += new FormClosingEventHandler(this.Form3_FormClosing);
            editForm.ShowDialog();
        }

        //przypisanie do etykiet
        //danych użytkownika po zamknięciu okna edycji
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
           // label1.Text = UserData.Name;
           // label2.Text = UserData.Surname;
           // label3.Text = UserData.Country;
        }

        //otwarcie formularza rozliczania podatku
        private void UpBtn_Click(object sender, EventArgs e)
        {
            wroc = new stronastartowa();
            wroc.FormClosing += new FormClosingEventHandler(this.Form2_FormClosing);
            this.Hide();
            wroc.ShowDialog();
        }

        private void userProfile_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
