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
    public partial class Additions : UserControl
    {
        public Additions()
        {
            InitializeComponent();
        }
        Access a = new Access();

        private void button3_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRO DP = new FRM_ADD_PRO();
            DP.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_Add_ADMIN FAD = new FRM_Add_ADMIN();
            FAD.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FRM_Add_Type FAT = new FRM_Add_Type();
            FAT.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void Additions_Load(object sender, EventArgs e)
        {

        }
    }
}
