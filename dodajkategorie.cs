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
    public partial class dodajkategorie : formularzkategoria
    {
        public override string query
        {
            get { return "INSERT INTO kategorie(nazwa) VALUES(@nazwa)"; }
        }
        public dodajkategorie()
        {
            InitializeComponent();
            Text = "Dodawanie kategorii";
        }
        
    }
}
