using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;
using System_Abdalli_multisport;

namespace LibrarySystem.AllForms
{
    public partial class FIN_Produects : UserControl
    {
        public FIN_Produects()
        {
            InitializeComponent();
        }

        TheQuery t = new TheQuery();
        Access a = new Access();
        email mail = new email();

        private void FIN_Produects_Load(object sender, EventArgs e)
        {
            t.AllProduct(dataGridView1, "where Quntity <= 0");

            ///////////////////
            if (a.ACC.ToString() == "user")
            {
                button2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a.id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            FRM_Show_Product FSP = new FRM_Show_Product();
            FSP.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (groupBox3.Visible == true)
            {
                groupBox3.Visible = false;
            }
            else if (groupBox3.Visible == false)
            {
                groupBox3.Visible = true;
                groupBox3.BringToFront();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            t.AllProduct(dataGridView1, "where (Name like N'%" + textBox4.Text + "%' or date_add like '%" + textBox4.Text + "%') and Quntity = 0");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
                
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            t.AllProduct(dataGridView1, "where ( Money between 0 and " + trackBar1.Value.ToString() + ") and Quntity = 0");
            label10.Text = trackBar1.Value.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            t.AllProduct(dataGridView1, "where Quntity <= 0");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this Product ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {

                try
                {
                    a.connection();
                    a.cmd.Connection = a.con;
                    a.cmd.CommandText = "delete from Product where ID='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                    a.cmd.ExecuteNonQuery();
                    a.Deconnection();
                    MessageBox.Show("Deleted successfully");

                    if (a.ACC.ToString() == "user")
                    {
                        mail.mailAdmin("supprime un produit en date : " + DateTime.Now.Date.ToString());
                    }

                }
                catch (Exception r)
                {
                    MessageBox.Show(r.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Tous les produits Ne existe pas en stock";
                printer.SubTitle = String.Format("Date : " + DateTime.Now.Date);
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "LIBRAIRIE AMITEE";
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dataGridView1);

                if (a.ACC.ToString() == "user")
                {
                    mail.mailAdmin("imprime las produit pas en stock a la date : " + DateTime.Now.Date.ToString());
                }

            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
    }
}
