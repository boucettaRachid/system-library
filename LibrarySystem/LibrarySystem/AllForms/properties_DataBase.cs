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
    public partial class properties_DataBase : Form
    {
        public properties_DataBase()
        {
            InitializeComponent();
        }

        private void properties_DataBase_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.Data_Source.ToString();
            textBox2.Text = Properties.Settings.Default.Initial_Catalog.ToString();
            textBox3.Text = Properties.Settings.Default.Integrated_Security.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Data_Source = textBox1.Text;
            Properties.Settings.Default.Initial_Catalog = textBox2.Text;
            Properties.Settings.Default.Integrated_Security = textBox3.Text;
            Properties.Settings.Default.Save();
        }
    }
}
