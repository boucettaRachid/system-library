using LibrarySystem.AllForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.Accueil
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        Access a = new Access();

        private void login_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            pictureBox1.Location = new Point(280, 165);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                pictureBox1.Location = new Point(280, 41);
                panel1.Visible = true;
            }
            else
            {
                pictureBox1.Location = new Point(280, 165);
                panel1.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                a.connection();
                a.cmd.Connection = a.con;
                a.cmd.CommandText = "select * from admins where username='"+ textBox1.Text +"' and password='"+ textBox2.Text +"'";
                a.dr = a.cmd.ExecuteReader();
                if (a.dr.Read())
                {
                    a.ACC = a.dr[3].ToString();
                    textBox1.BackColor = Color.White;
                    textBox2.BackColor = Color.White;
                    FRM_GENE G = new FRM_GENE();
                    G.Show();
                    Hide();
                }
                else
                {
                    textBox1.BackColor = Color.Red;
                    textBox2.BackColor = Color.Red;
                }
                a.dr.Close();
                a.Deconnection();
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (panel1.Visible == false)
                {
                    pictureBox1.Location = new Point(280, 41);
                    panel1.Visible = true;
                    textBox1.Focus();
                }
                else
                {
                    pictureBox1.Location = new Point(280, 165);
                    panel1.Visible = false;
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    a.connection();
                    a.cmd.Connection = a.con;
                    a.cmd.CommandText = "select * from admins where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                    a.dr = a.cmd.ExecuteReader();
                    if (a.dr.Read())
                    {
                        a.ACC = a.dr[3].ToString();
                        textBox1.BackColor = Color.White;
                        textBox2.BackColor = Color.White;
                        FRM_GENE G = new FRM_GENE();
                        G.Show();
                        Hide();
                    }
                    else
                    {
                        textBox1.BackColor = Color.Red;
                        textBox2.BackColor = Color.Red;
                    }
                    a.dr.Close();
                    a.Deconnection();
                }
                catch (Exception p)
                {
                    MessageBox.Show(p.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            properties_DataBase p = new properties_DataBase();
            p.Show();
        }
    }
}
