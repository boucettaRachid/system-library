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

namespace LibrarySystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 10;

            if (panel1.Width >= 420)
            {
                timer1.Stop();
                login l = new login();
                l.Show();
                Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }
    }
}
