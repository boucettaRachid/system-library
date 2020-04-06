using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem
{
    class Access
    {
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();
        public static string ID;
        public static string Acc;

        public void connection()
        {
            if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            {
                con.ConnectionString = @"Data Source=" + Properties.Settings.Default.Data_Source.ToString() + ";Initial Catalog=" + Properties.Settings.Default.Initial_Catalog.ToString() + ";Integrated Security=" + Properties.Settings.Default.Integrated_Security.ToString();
                con.Open();
            }
        }

        public void Deconnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public string id
        {
            get { return ID; }
            set { ID = value; }
        }

        public string ACC
        {
            get { return Acc; }
            set { Acc = value; }
        }


    }
}
