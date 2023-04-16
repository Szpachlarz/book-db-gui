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

namespace projekt
{   //panel edycji danych użytkownika
    public partial class Form3 : Form
    {
        const string slash = "\\";
        SqlConnection cn = new SqlConnection("Data Source=(localdb)" + slash + "PoSrv;Initial Catalog=ProjectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //flagi sprawdzające czy  wypełniono wszystkie pola,
        //czy zaktualizowano same dane i czy zaktualizowano dane z hasłem
        bool isComplete;
        bool dataUpdated;
        bool passwdUpdated;
        public Form3()
        {
            InitializeComponent();
            //przekazanie do pól ekstowych aktualnych danych
            //NameUp.Text = UserData.Name;
        }

        //przycisk anulowania
        //wychodzi z formularza bez zmiany danych
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //przycisk aktualizujący dane
        //żeby zaktualizować dane należy potwierdzić swoje hasło 
        private void updateBtn_Click(object sender, EventArgs e)
        {   //ustawienie wartości flag
            isComplete=true;
            dataUpdated=false;
            passwdUpdated=false;
            //jeśli pole z nowym hasłem jest puste
            //nie zostanie zaktualizowane
            if (textBox1.Text == "")
            {
                //sprawdzenie czy wszystkie pola poza nowym hasłem
                //są wypełnione
                foreach(Control c in updatepanel.Controls)
                {
                    if((c is TextBox || c is ComboBox) && c.Text == "")
                    {
                        //jeśli nie, zostanie wyświetlony komunikat
                        //i flaga isComplete zostanie ustawiona na false
                        isComplete=false;
                        MessageBox.Show("należy wypełnić wszystkie pola");
                        break;
                    }
                }

                //jeśli pola wypełniono
                if (isComplete)
                {
                    //jeśli podane hasło jest zgodne z hasłem użytkownika
                    /*if (Passwd.Text == UserData.Passwd)
                    {
                        //zapytanie do bazy danych aktualizujące dane użytkownika
                        string updateProfile = string.Format("UPDATE UsersTab SET Name='{0}', Surname='{1}', Country='{2}' WHERE ID='{3}' ",
                            NameUp.Text, UserData.Id);
                        try
                        {
                            //wysłanie zapytania do bazy
                            cn.Open();
                            using (SqlCommand updateUser = new SqlCommand(updateProfile, cn))
                            {
                                updateUser.ExecuteNonQuery();
                            }
                            //wyświetlenie komunikatu o zaktualizowaniu danych
                            MessageBox.Show("Pomyślnie zaktualizowano");
                            //ustawienie flagi na true
                            dataUpdated = true;
                            cn.Close();
                            //wyjście z panelu edycji danych
                            this.Close();


                        }
                        catch (SystemException ex)
                        {
                            MessageBox.Show(String.Format("Wystąpił błąd \n {0}", ex.Message));
                        }
                    }
                    else
                    {   //komunikat gdy podano błędne hasło
                        MessageBox.Show("Podano błędne hasło");
                    }*/
                }

            }
            //w przypadku aktualizacji hasła
            else
            {
                //sprawdzenie, czy wszystkie pola są wypełnione
                foreach (Control c in updatepanel.Controls)
                {
                    if ((c is TextBox || c is ComboBox) && c.Text == "")
                    {
                        isComplete = false;
                        MessageBox.Show("należy wypełnić wszystkie pola");
                        break;
                    }
                }
                //jeśli wypełniono wszystkie pola
                if (isComplete)
                {
                    //jeśli podano takie samo hasło w obu polach
                    if (textBox1.Text == textBox2.Text)
                    {
                        //jeśli podane hasło jest zgodne z hasłem użytkownika
                        /*if (Passwd.Text == UserData.Passwd)
                        {
                            //zapytanie do bazy sql aktualizujące hasło i dane użytkownika
                            string updateProfile = string.Format("UPDATE UsersTab SET Name='{0}', Surname='{1}', Country='{2}', Passwd='{3}' WHERE ID='{4}' ",
                                NameUp.Text, textBox1.Text, UserData.Id);
                            try
                            {
                                cn.Open();
                                //wykonanie zapytania
                                using (SqlCommand updateUser = new SqlCommand(updateProfile, cn))
                                {
                                    updateUser.ExecuteNonQuery();
                                }
                                MessageBox.Show("Pomyślnie zaktualizowano");
                                passwdUpdated = true;
                                cn.Close();
                                this.Close();


                            }
                            catch (SystemException ex)
                            {
                                MessageBox.Show(String.Format("Wystąpił błąd \n {0}", ex.Message));
                            }
                        }
                        else
                        {
                            MessageBox.Show("Podano błędne hasło");
                        }*/
                    }
                    else
                    {
                        //komunikat gdy podano różne hasła
                        MessageBox.Show("Podano różne hasła");
                    }
                }

            }
            
        }

        //przekazanie do klasy statycznej z danymi użytkownika zauktalizowanych danych
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            //gdy aktualizowane dane bez hasła
            if (dataUpdated)
            {
                //UserData.Name = NameUp.Text;
            }
            //gdy aktualizowano dane z hasłem
            if (passwdUpdated)
            {
                //UserData.Name = NameUp.Text;
                //UserData.Passwd = textBox1.Text;
                
            }

        }
    }
}
