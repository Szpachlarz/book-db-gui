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
    public partial class edycjaautora : usuwanieedycja
    {
        public override string query
        {
            get { return "SELECT id, imiona, nazwisko FROM autorzy"; }
        }
        public override void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string idautora = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                edycjaautora2 form19 = new edycjaautora2();
                form19.idautora2 = idautora;
                form19.ShowDialog();
            }
        }
    }
}
