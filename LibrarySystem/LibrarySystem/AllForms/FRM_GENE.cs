using LibrarySystem.Accueil;
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
    public partial class FRM_GENE : Form
    {
        public FRM_GENE()
        {
            InitializeComponent();
        }

        TheQuery t = new TheQuery();
        Access a = new Access();

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel6.Height = button2.Height;
            panel6.Top = button2.Top;
            stock1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel6.Height = button3.Height;
            panel6.Top = button3.Top;
            all_Orders1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel6.Height = button1.Height;
            panel6.Top = button1.Top;
            all_Products1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel6.Height = button4.Height;
            panel6.Top = button4.Top;
            fiN_Produects1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel6.Height = button5.Height;
            panel6.Top = button5.Top;
            settinges1.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel6.Height = button7.Height;
            panel6.Top = button7.Top;
            calendar1.BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel6.Height = button8.Height;
            panel6.Top = button8.Top;
            additions1.BringToFront();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to Exit ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
             if (confirmResult == DialogResult.Yes)
             {
                 Application.Exit();
             }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel6.Height = button9.Height;
            panel6.Top = button9.Top;
            home1.BringToFront();
        }

        private void stock1_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel6.Height = button10.Height;
            panel6.Top = button10.Top;
            management1.BringToFront();
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void home1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FRM_GENE_Load(object sender, EventArgs e)
        {
            if ( a.ACC.ToString() == "user")
            {
                button8.Enabled = false;
                button5.Enabled = false;
                button10.Enabled = false;
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            help1.BringToFront();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.Show();
            Hide();
        }
    }
}
