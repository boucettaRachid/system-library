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
    public partial class Settinges : UserControl
    {
        public Settinges()
        {
            InitializeComponent();
        }

        TheQuery t = new TheQuery();
        Access a = new Access();

        private void Settinges_Load(object sender, EventArgs e)
        {

            t.Admins(dataGridView1);

            try
            {
                a.dt.Clear();
                a.connection();
                a.cmd.CommandText = "select * from Typee ";
                a.cmd.Connection = a.con;
                a.dr = a.cmd.ExecuteReader();
                a.dt.Load(a.dr);
                dataGridView2.DataSource = a.dt;
                a.dr.Close();
                a.Deconnection();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }


            a.connection();
            a.cmd.CommandText = "select * from email";
            a.cmd.Connection = a.con;
            a.dr = a.cmd.ExecuteReader();
            while (a.dr.Read())
            {
                EmailSendr.Text = a.dr[0].ToString();
                EmailAdmin.Text = a.dr[1].ToString();
                password.Text = a.dr[2].ToString();
                Port.Text = a.dr[3].ToString();
                SMTP.Text = a.dr[4].ToString();
                Subject.Text = a.dr[5].ToString();
                Messsage.Text = a.dr[6].ToString();
            }
            a.dr.Close();
            a.Deconnection();
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //t.UpdateThemes(comboBox1.Text);
            //MessageBox.Show("Update Themes sccessfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t.Admins(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                a.dt.Clear();
                a.connection();
                a.cmd.CommandText = "select * from Typee ";
                a.cmd.Connection = a.con;
                a.dr = a.cmd.ExecuteReader();
                a.dt.Load(a.dr);
                dataGridView2.DataSource = a.dt;
                a.dr.Close();
                a.Deconnection();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
             var confirmResult = MessageBox.Show("Are you sure to delete this Admin ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
             if (confirmResult == DialogResult.Yes)
             {

                 try
                 {
                     a.connection();
                     a.cmd.Connection = a.con;
                     a.cmd.CommandText = "delete from admins where ID=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
                     a.cmd.ExecuteNonQuery();
                     a.Deconnection();
                     MessageBox.Show("Update Successfully");
                 }
                 catch (Exception p)
                 {
                     MessageBox.Show(p.Message);
                 }
             }
        }

        private void button6_Click(object sender, EventArgs e)
        {
             var confirmResult = MessageBox.Show("Are you sure to delete this type ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
             if (confirmResult == DialogResult.Yes)
             {

                 try
                 {
                     a.connection();
                     a.cmd.Connection = a.con;
                     a.cmd.CommandText = "delete from typee where ID=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
                     a.cmd.ExecuteNonQuery();
                     a.Deconnection();
                     MessageBox.Show("Update Successfully");
                 }
                 catch (Exception p)
                 {
                     MessageBox.Show(p.Message);
                 }
             }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                a.connection();
                a.cmd.CommandText = "update email set Email_S='" + EmailSendr.Text + "',Email_A='" + EmailAdmin.Text + "',Passwordmail_A='" + password.Text + "',Port='" + Port.Text + "',Smtp='" + SMTP.Text + "',subjecte='" + Subject.Text + "',messag='" + Messsage.Text + "'";
                a.cmd.Connection = a.con;
                a.cmd.ExecuteNonQuery();
                a.Deconnection();
                MessageBox.Show("Update Successfuly");
            }
            catch (Exception l)
            {
                MessageBox.Show(l.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                a.connection();
                a.cmd.Connection = a.con;
                a.cmd.CommandText = "update admins set username='" + textBox1.Text + "', password='" + textBox2.Text + "', Access='" + comboBox3.Text + "' where ID ='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                a.cmd.ExecuteNonQuery();
                a.Deconnection();
                MessageBox.Show("Update Successfully");

                groupBox2.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
        }
    }
}
                                                 