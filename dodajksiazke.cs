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
    public partial class dodajksiazke : formularzksiazka
    {
        public override string query
        {
            get { return "INSERT INTO ksiazki(tytul, wydawnictwo, seria, rok_wydania, rok_1wydania, strony, jezyk, jezyk_oryginalny, tlumaczenie, tytul_oryginalny, kategoria, ISBN) VALUES(@tytul, @wydawnictwo, @seria, @rok_wydania, @rok_1wydania, @strony, @jezyk, @jezyk_oryginalny, @tlumaczenie, @tytul_oryginalny, @kategoria, @isbn)"; }
        }

        public override string query2
        {
            get { return "INSERT INTO autorstwo(autor, id_ksiazki) VALUES(@autor, @id_ksiazki)"; }
        }
        public dodajksiazke()
        {
            Text = "Dodawanie książki";
        }
    }
}
