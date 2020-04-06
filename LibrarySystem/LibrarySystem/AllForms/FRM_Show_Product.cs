using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.AllForms
{
    public partial class FRM_Show_Product : Form
    {
        public FRM_Show_Product()
        {
            InitializeComponent();
        }
        Access a = new Access();
        TheQuery T = new TheQuery();

        private void FRM_Show_Product_Load(object sender, EventArgs e)
        {
            try
            {
                a.connection();
                a.cmd.CommandText = "select * from Product where ID='"+a.id.ToString()+"'";
                a.cmd.Connection = a.con;
                a.dr = a.cmd.ExecuteReader();
                while (a.dr.Read())
                {
                    label8.Text  = a.dr[0].ToString();
                    label11.Text = a.dr[1].ToString();
                    label10.Text = a.dr[2].ToString();
                    label9.Text  = a.dr[3].ToString();
                    label14.Text = a.dr[5].ToString();
                    label13.Text = a.dr[4].ToString();
                    label16.Text = a.dr[6].ToString();
                    ///////////
                    Byte[] data = new Byte[0];
                    data = (Byte[])(a.dr[7]);
                    MemoryStream mem = new MemoryStream(data);
                    pictureBox1.Image = Image.FromStream(mem);

                    //////////
                    string ID = label8.Text;

                    chart1.Series["Series1"].Points.AddXY("Stock", Convert.ToInt16(T.Stock(ID)));
                    chart1.Series["Series1"].Points.AddXY("order", Convert.ToInt16(T.CountOrder(ID)));
                }
                a.dr.Close();
                a.Deconnection();
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            FRM_Show_Product.ActiveForm.Close();
        }
    }
}
