using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibrarySystem.RDLC;
using DGVPrinterHelper;
using System_Abdalli_multisport;

namespace LibrarySystem.AllForms
{
    public partial class All_Products : UserControl
    {
        public All_Products()
        {
            InitializeComponent();
        }

        TheQuery T = new TheQuery();
        Access a = new Access();
        email mail = new email();

        private void All_Products_Load(object sender, EventArgs e)
        {
            T.AllProduct(dataGridView1, "where Quntity > 0");
            ////////////
            if (a.ACC.ToString() == "user")
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
            }
            /////////////

            dataGridView1.RowTemplate.Height = 80;
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[7];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRO FA = new FRM_ADD_PRO();
            FA.Show();
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
                        mail.mailAdmin("Ajoute un produit en date : " + DateTime.Now.Date.ToString());
                    }

                }
                catch (Exception r)
                {
                    MessageBox.Show(r.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a.id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            FRM_Show_Product FSP = new FRM_Show_Product();
            FSP.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            a.id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            FRM_UpdateProducts FUP = new FRM_UpdateProducts();
            FUP.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            T.AllProduct(dataGridView1, "where (ID like '%" + textBox1.Text + "%' or Name like N'%" + textBox1.Text + "%' or Quntity like '%" + textBox1.Text + "%' or Types like '%" + textBox1.Text + "%' or date_add like '%" + textBox1.Text + "%' or Money like '%" + textBox1.Text + "%') and Quntity > 0");
        }

        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
            T.AllProduct(dataGridView1, "where Quntity > 0");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            T.AllProduct(dataGridView1, "where Quntity > 0");

            dataGridView1.RowTemplate.Height = 80;
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[7];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Tout les Produites";
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
                    mail.mailAdmin("imprime las produites en date : " + DateTime.Now.Date.ToString());
                }

            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
