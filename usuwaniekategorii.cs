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
    public partial class usuwaniekategorii : usuwanieedycja
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

                usuwaniekategorii2 form25 = new usuwaniekategorii2();
                form25.idkategorii2 = idkategorii;
                form25.ShowDialog();
            }
        }

    }
}
