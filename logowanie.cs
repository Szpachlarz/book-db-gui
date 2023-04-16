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
using System.Security.Cryptography;

namespace projekt
{
    public partial class logowanie : Form
    {
        stronastartowa wroc;
        //panel logowania i rejestracji
        //const string slash = "\\";
        //zainicjowanie połączenia z bazą danych
        //SqlConnection cn = new SqlConnection("Data Source=(localdb)" + slash + "PoSrv;Initial Catalog=ProjectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        Form2 UserPanel;
        paneladmina AdminPanel;

        //funkcja chowająca wszystkie panele
        void HidePannels()
        {
            foreach (Control p in this.Controls)
            {
                if (p is Panel) p.Visible = false;
            }
        }
        public logowanie()
        {
            InitializeComponent();
            //schowanie wszystkich paneli i wyświetlenie formularza logowania przy starcie
            HidePannels();
            LogPan.Visible = true;

        }

        private void RegistryPan_Paint(object sender, PaintEventArgs e)
        {

        }

        //przejście do panelu rejestracji
        private void GoToReg_Click(object sender, EventArgs e)
        {
            HidePannels();
            this.Text = "Utwórz konto";
            RegistryPan.Visible = true;
        }

        //wrócenie z panelu rejestracji do panelu logowania
        private void BackToLogPan_Click(object sender, EventArgs e)
        {
            HidePannels();
            this.Text = "Zaloguj się";
            LogPan.Visible = true;
        }

        //funkcja odpowiadająca za przycisk logowania

        public void LogButton_Click(object sender, EventArgs e)
        {
            var database = new Database();
            if (database.connect_db())
            {
                string login = String.Format("SELECT * FROM uzytkownicy WHERE email='{0}' AND haslo='{1}'"
                , MailLog.Text, PassLog.Text); //pobranie z bazy danych użytkownika z Emailem i hasłem wpisanych w polach panelu
                MySqlCommand mySqlCommand = new MySqlCommand(login);
                mySqlCommand.Connection = database.mySqlConnection;
                MySqlDataAdapter checkLog = new MySqlDataAdapter(login, mySqlCommand.Connection);
                DataTable checkLogTable = new DataTable();
                //wypełnienie tymczasowej tabeli danymi
                checkLog.Fill(checkLogTable);
                //sprawdzenie czy tabela ma 1 wiersz
                //jeśli tak, podany użytkownik istnieje
                if (checkLogTable.Rows.Count == 1)
                {
                    //zmienna zawierająca flagę administratora
                    bool IsAdmin = Convert.ToBoolean(checkLogTable.Rows[0]["uprawnienia"]);
                    //jeśli flaga administratora ma wartość true następuje przejście do panelu administratora
                    this.Hide();
                    if (IsAdmin)
                    {
                        AdminPanel = new paneladmina();
                        AdminPanel.Show();
                    }
                    else
                    {
                        //jeśli flaga administratora ma wartość false, następuje przejście do panelu użytkownika
                        //zmienna zawierając id użytkonika
                        int testd = Convert.ToInt32(checkLogTable.Rows[0]["id"]);
                        //utworzenie nowego panelu, do którego zostaje przekazana flaga użytkownika
                        UserPanel = new Form2(testd);
                        UserPanel.Show();
                    }

                    
                }
                //ukrycie formularza z panelem logowania                
                database.close_db();

            }
            else
            {
                MessageBox.Show("Database error!");
            }
        }

        //funkcja odpowiedzialna za rejestrację nowego użytkownika
        private void button2_Click(object sender, EventArgs e)
        {   //flaga sprawdzająca czy wszystkie pola wypełniono
            bool isComplete = true;

            var database = new Database();
            if (database.connect_db())
            {
                //pętla sprawdzająca czy wszystkie pola wypełniono poprawnie
                foreach (Control c in RegistryPan.Controls)
                {
                    //jeśli któreś z pól jest puste
                    if ((c is TextBox || c is ComboBox) && c.Text == "")
                    {   //wyświetlenie komunikatu i ustawienie flagi na false
                        MessageBox.Show("należy wypełnić wszystkie pola");
                        isComplete = false;
                        break;
                    }
                }
                //jeśli wszystkie pola wypełniono
                if (isComplete == true)
                {
                    //sprawdzenie czy podano takie same hasła
                    if (PasswdReg.Text != ConfPassButton.Text) MessageBox.Show("Wprowadzono różne hasła");
                    else
                    {
                        //sprawdzenie czy adres email podano w poprawnym formacie
                        Regex mailCheck = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                        Match match = mailCheck.Match(EmailReg.Text);
                        //jeśli email jest poprawny
                        if (match.Success)
                        {
                            //pobranie z bazy danych pól zawierających adres email podany w formularzu
                            //w celu sprawdzenia, czy na podany adres utworzono już konto
                            string checkMailComm = String.Format("SELECT email FROM uzytkownicy WHERE Email='{0}'"
                            , EmailReg.Text) ;
                            //zmienna zawierająca zapytanie do bazy sql dodające nowego użytkownika
                            string regComm = String.Format("INSERT INTO uzytkownicy (nazwa, email, haslo, uprawnienia) VALUES ('{0}','{1}','{2}','{3}')"
                            , NameReg.Text, EmailReg.Text, PasswdReg.Text, 0);
                            MySqlCommand mySqlCommand = new MySqlCommand(checkMailComm);
                            mySqlCommand.Connection = database.mySqlConnection;
                            MySqlDataAdapter checkMail = new MySqlDataAdapter(checkMailComm, mySqlCommand.Connection);
                            DataTable checkMailTable = new DataTable();
                            checkMail.Fill(checkMailTable);
                            //jeśli w bazie znajdują się rekordy zawierające podanego maila
                            //zostanie wyświetlony komunikat
                            if (checkMailTable.Rows.Count > 0) MessageBox.Show("Na podanym adresie E-mail utworzono już konto");
                            else
                            {
                                //dodanie użytkownika do bazy
                                //i wyświetlenie komunikatu
                                MySqlCommand regQr = new MySqlCommand(regComm, mySqlCommand.Connection);
                                regQr.ExecuteNonQuery();
                                MessageBox.Show("Pomyślnie zarejestrowano nowego użytkownika");
                                //MessageBox.Show(regComm);
                                //wyczyszczenie pól po dodaniu użytkownika
                                foreach (Control c in RegistryPan.Controls)
                                {
                                    if (c is TextBox)
                                    {
                                        c.Text = "";
                                    }
                                }
                                //przejście do panelu rejestracji po zarejestrowaniu
                                HidePannels();
                                LogPan.Visible = true;
                            }
                        }
                        else
                        {
                            //jeśli email jest niepoprwany
                            //wyświetlenie komunikatu
                            MessageBox.Show("Adres email podano w niepoprawnym formacie");
                        }
                    }
                }
                //zamknięcie połączenia z bazą danych
                database.close_db();
            }
            else
            {
                MessageBox.Show("Database error!");
            }

        }
        //wyjście z aplikacji przy zamknięciu formularza
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
        private void returnToMain(object sender, EventArgs e)
        {
            wroc = new stronastartowa();
            wroc.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            Hide();
            wroc.ShowDialog();
        }
    }

    public class Hash
    {
        private const int SaltSize = 128 / 8;
        private const int KeySize = 256 / 8;
        private const int Iterations = 10000;
        private static readonly HashAlgorithmName hashAlgorithmName = HashAlgorithmName.SHA256;

        /*public string Hash2(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password);
        }*/

        public bool Verify(string passwordHash, string inputPassword)
        {
            throw new NotImplementedException();
        }
    }
}