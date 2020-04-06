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
    public partial class FRM_Add_ADMIN : Form
    {
        public FRM_Add_ADMIN()
        {
            InitializeComponent();
        }

        Access a = new Access();

        private void FRM_Add_ADMIN_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FRM_Add_ADMIN.ActiveForm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                try
                {
                    a.connection();
                    a.cmd.Connection = a.con;
                    a.cmd.CommandText = "insert into Admin values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "')";
                    a.cmd.ExecuteNonQuery();
                    a.Deconnection();
                    textBox3.BackColor = Color.White;
                    MessageBox.Show("Add User Successflly");

                }
                catch (Exception r)
                {
                    MessageBox.Show(r.Message);
                }
            }
            else
            {
                textBox3.BackColor = Color.Red;
            }
        }
    }
}
