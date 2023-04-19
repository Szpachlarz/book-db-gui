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
    public partial class edycjaksiazki : usuwanieedycja
    {
        public override string query
        {
            get { return "SELECT id_ksiazki, tytul FROM ksiazki"; }
        }
        public edycjaksiazki()
        {
            Text = "Wybierz książkę";
        }
        public override void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string idksiazki = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                edycjaksiazki2 form18 = new edycjaksiazki2();
                form18.idksiazki2 = idksiazki;
                form18.ShowDialog();
            }
        }
    }
}
