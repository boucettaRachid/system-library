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
using System_Abdalli_multisport;

namespace LibrarySystem.AllForms
{
    public partial class FRM_UpdateProducts : Form
    {
        public FRM_UpdateProducts()
        {
            InitializeComponent();
        }

        Access a = new Access();
        email mail = new email();

        private void button3_Click(object sender, EventArgs e)
        {
            FRM_UpdateProducts.ActiveForm.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                a.connection();
                a.cmd.Connection = a.con;
                a.cmd.CommandText = "update Product set Name=N'" + textBox1.Text + "',Quntity='" + textBox2.Text + "',Types='" + comboBox1.Text + "',date_add='" + dateTimePicker1.Value.ToString() + "',Money='" + textBox3.Text + "',capital='" + textBox4.Text + "' where ID = '" + label7.Text + "'";
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

        private void FRM_UpdateProducts_Load(object sender, EventArgs e)
        {
            try
            {
                a.connection();
                a.cmd.CommandText = "select * from Product where ID='" + a.id.ToString() +"'";
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
                    textBox4.Text = a.dr[6].ToString();
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


            try
            {
                a.connection();
                a.cmd.Connection = a.con;
                a.cmd.CommandText = "select * from typee";
                a.dr = a.cmd.ExecuteReader();

                while (a.dr.Read())
                {
                    comboBox1.Items.Add(a.dr[1].ToString());
                }
                a.dr.Close();
                a.Deconnection();
            }
            catch (Exception l)
            {
                MessageBox.Show(l.Message);
            }

        }

        string img = "";

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                img = dialog.FileName;
                pictureBox1.ImageLocation = img;

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
