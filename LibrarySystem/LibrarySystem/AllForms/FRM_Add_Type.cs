using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.AllForms
{
    public partial class FRM_Add_Type : Form
    {
        public FRM_Add_Type()
        {
            InitializeComponent();
        }
        Access a = new Access();

        private void FRM_Add_Type_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FRM_Add_Type.ActiveForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                a.connection();
                a.cmd.Connection = a.con;
                a.cmd.CommandText = "insert into Typee values('"+textBox1.Text+"')";
                a.cmd.ExecuteNonQuery();
                a.Deconnection();
                MessageBox.Show("Add Type Successflly");

            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message);
            }
        }
    }
}
