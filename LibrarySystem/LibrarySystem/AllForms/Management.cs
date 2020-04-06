using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.AllForms
{
    public partial class Management : UserControl
    {
        public Management()
        {
            InitializeComponent();
        }

        Access a = new Access();
        TheQuery t = new TheQuery();

        private void Management_Load(object sender, EventArgs e)
        {
            try
            {
                a.connection();
                a.cmd.Connection = a.con;
                a.cmd.CommandText = "select count(id) as NUMBER, date_order from Orders Group by date_order";
                a.dr = a.cmd.ExecuteReader();
                while (a.dr.Read())
                {
                    chart1.Series["number orders"].Points.AddXY(a.dr[1].ToString(), a.dr[0].ToString());
                }
                a.dr.Close();
                a.Deconnection();

            }catch(Exception tt)
            {
                MessageBox.Show(tt.Message);
            }



            try
            {
                a.connection();
                a.cmd.Connection = a.con;
                a.cmd.CommandText = "select date_order,Sum(price) as TRotal from Orders Group by date_order";
                a.dr = a.cmd.ExecuteReader();
                while (a.dr.Read())
                {
                    chart2.Series["Monthly profit"].Points.AddXY(a.dr[0].ToString(), a.dr[1].ToString());
                }
                a.dr.Close();
                a.Deconnection();
            }
            catch (Exception tt)
            {
                MessageBox.Show(tt.Message);
            }


            ///////////////
            label1.Text = t.SumCapital().ToString();
            label2.Text = t.SumMoney().ToString();
            label3.Text = (t.SumMoney() - t.SumCapital()).ToString();
            label21.Text = (t.SumMoney() - t.SumCapital()).ToString();

            label18.Text = (Convert.ToDouble(label3.Text) - Convert.ToDouble(label20.Text)).ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label20.Text = (Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text) + Convert.ToDouble(textBox3.Text) + Convert.ToDouble(textBox4.Text) + Convert.ToDouble(textBox5.Text) + Convert.ToDouble(textBox6.Text)).ToString();
            label18.Text = (Convert.ToDouble(label3.Text) - Convert.ToDouble(label20.Text)).ToString();
        }
    }
}
