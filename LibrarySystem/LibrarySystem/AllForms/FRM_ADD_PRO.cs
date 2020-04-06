using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.AllForms
{
    public partial class FRM_ADD_PRO : Form
    {
        public FRM_ADD_PRO()
        {
            InitializeComponent();
        }
        Access a = new Access();

        private void FRM_ADD_PRO_Load(object sender, EventArgs e)
        {
            textBox5.Focus();
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRO.ActiveForm.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "")
                {
                    byte[] imge = null;
                    FileStream FS = new FileStream(img, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(FS);
                    imge = br.ReadBytes((int)FS.Length);

                    if (imge != null)
                    {
                        a.connection();
                        a.cmd.Connection = a.con;
                        a.cmd.CommandText = "insert into Product values('"+textBox5.Text+"',N'" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + DateTime.Now.ToString() + "','" + textBox4.Text + "', @img)";
                        a.cmd.Parameters.Add(new SqlParameter("@img", imge));
                        a.cmd.ExecuteNonQuery();
                        a.cmd.Parameters.Clear();
                        a.Deconnection();

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        comboBox1.Text = "";
                        pictureBox1.ImageLocation = "";
                       
                    }
                    else
                    {
                        MessageBox.Show("Please Entre Some Pictuer for Your Product");
                    }
                }
                else
                {
                    MessageBox.Show("Please Entre All Information for Your Product");
                }
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message);
            }
        }
    }
}
