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
    public partial class edycjakategorii : usuwanieedycja
    {
        public override string query
        {
            get { return "SELECT id, nazwa FROM kategorie"; }
        }

        public override void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string idkategorii = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                edycjakategorii2 form21 = new edycjakategorii2();
                form21.idkategorii2 = idkategorii;
                form21.ShowDialog();
            }
        }
    }
}
