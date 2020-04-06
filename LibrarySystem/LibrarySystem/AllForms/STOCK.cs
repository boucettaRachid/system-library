using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DGVPrinterHelper;
using System_Abdalli_multisport;

namespace LibrarySystem.AllForms
{
    public partial class STOCK : UserControl
    {
        public STOCK()
        {
            InitializeComponent();
        }

        TheQuery t = new TheQuery();
        Access a = new Access();
        email mail = new email();

        private void STOCK_Load(object sender, EventArgs e)
        {
            t.AllProduct(dataGridView1, "");
            //////////////
            if (a.ACC.ToString() == "user")
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            button6.Visible = true;
            button5.Visible = true;
            groupBox1.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            button6.Visible = false;
            button5.Visible = false;
            groupBox1.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string Qu = "update Product set Name=N'"+textBox1.Text+"',Quntity='"+textBox2.Text+"',Types='"+comboBox1.Text+"',date_add='"+dateTimePicker1.Value.ToString()+"',Money='"+textBox3.Text+"',capital='"+textBox5.Text+"' where ID = '"+label7.Text+"'";
                a.connection();
                a.cmd.Connection = a.con;
                a.cmd.CommandText = Qu;
                a.cmd.ExecuteNonQuery();
                a.Deconnection();
                MessageBox.Show("Update successfully");

                if (a.ACC.ToString() == "user")
                {
                    mail.mailAdmin("modifie un produit " + textBox1.Text + " en date : " + DateTime.Now.Date.ToString());
                }

            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (groupBox3.Visible == true)
            {
                groupBox3.Visible = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                a.connection();
                a.cmd.CommandText = "select * from Product where ID='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                a.cmd.Connection = a.con;
                a.dr = a.cmd.ExecuteReader();
                while (a.dr.Read())
                {
                    label7.Text = a.dr[0].ToString();
                    textBox1.Text = a.dr[1].ToString();
                    textBox2.Text = a.dr[2].ToString();
                    comboBox1.Text = a.dr[3].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(a.dr[5].ToString());
                    textBox3.Text = a.dr[4].ToString();
                    textBox5.Text = a.dr[6].ToString();
                    ///////////
                    Byte[] data = new Byte[0];
                    data = (Byte[])(a.dr[7]);
                    MemoryStream mem = new MemoryStream(data);
                    pictureBox1.Image = Image.FromStream(mem);
                }
                a.dr.Close();
                a.Deconnection();
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
                        mail.mailAdmin("supprime un produit  en date : " + DateTime.Now.Date.ToString());
                    }
                }
                catch (Exception r)
                {
                    MessageBox.Show(r.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Stock";
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
                    mail.mailAdmin("imprime les produites en date : " + DateTime.Now.Date.ToString());
                }

            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            t.AllProduct(dataGridView1, "where id like '%" + textBox4.Text + "%' or Name like N'%" + textBox4.Text + "%' or date_add like '%" + textBox4.Text + "%'");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            t.AllProduct(dataGridView1, "where Money between 0 and "+trackBar1.Value.ToString());
            label10.Text = trackBar1.Value.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Qu = "";

            if (comboBox2.Text == "Yas")
            {
                Qu = "where Quntity != 0";
            }
            else if (comboBox2.Text == "No")
            {
                Qu = "where Quntity = 0";
            }
            else
            {
                Qu = "";
            }

            t.AllProduct(dataGridView1, Qu );
        }
    }
}
