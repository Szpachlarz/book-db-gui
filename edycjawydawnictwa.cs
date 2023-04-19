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
    public partial class edycjawydawnictwa : usuwanieedycja
    {
        public override string query
        {
            get { return "SELECT id, nazwa FROM wydawnictwa"; }
        }
        public edycjawydawnictwa()
        {
            Text = "Wybierz wydawnictwo";
        }
        public override void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string idwydawnictwa = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                edycjawydawnictwa2 form20 = new edycjawydawnictwa2();
                form20.idwydawnictwa2 = idwydawnictwa;
                form20.ShowDialog();
            }
        }
    }
}
