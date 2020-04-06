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
    public partial class All_Orders : UserControl
    {
        public All_Orders()
        {
            InitializeComponent();
        }
        Access a = new Access();
        TheQuery t = new TheQuery();
        email mail = new email();

        private void All_Orders_Load(object sender, EventArgs e)
        {
            t.Allorders(dataGridView1, "");
            if (a.ACC.ToString() == "user")
            {
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this Order ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {

                try
                {
                    a.connection();
                    a.cmd.Connection = a.con;
                    a.cmd.CommandText = "delete from Orders where ID='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                    a.cmd.ExecuteNonQuery();
                    a.Deconnection();
                    MessageBox.Show("Deleted successfully");
                    t.Allorders(dataGridView1, "");

                    if (a.ACC.ToString() == "user")
                    {
                        mail.mailAdmin("Supprimer la demande en date : " + DateTime.Now.Date.ToString());
                    }

                }
                catch (Exception r)
                {
                    MessageBox.Show(r.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            t.Allorders(dataGridView1, "where ID_cmd like '%"+textBox1.Text+"%'");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a.id = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            FRM_Show_Orders FRO = new FRM_Show_Orders();
            FRO.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            t.Allorders(dataGridView1, "where date_order like '%" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "%'");
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t.Allorders(dataGridView1, "");
            dateTimePicker1.Value = DateTime.Now;
            button1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Tout les commendes";
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
                    mail.mailAdmin("imprime las demandes en date : " + DateTime.Now.Date.ToString());
                }
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }
    }
}
