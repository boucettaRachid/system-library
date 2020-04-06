using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System_Abdalli_multisport;
using System.IO;

namespace LibrarySystem.AllForms
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }
        TheQuery T = new TheQuery();
        Access a = new Access();
        email mail = new email();

        private void Home_Load(object sender, EventArgs e)
        {
            //T.tryThemes(this);

            chart1.Series["Stock"].Points.AddXY("Produits disponibles", T.SumProducts());
            chart1.Series["Stock"].Points.AddXY("Produits non disponibles", T.SumFinProducts());

            chart2.Series["Series1"].Points.AddXY("Capital social", T.SumCapital());
            chart2.Series["Series1"].Points.AddXY("Gains généraux", T.SumMoney());

            label1.Text = T.SumProducts().ToString();
            label2.Text = T.SumOrders().ToString();
            label3.Text = T.SumFinProducts().ToString();
            label4.Text = T.SumMoney().ToString();

            

            try
            {
                a.dt.Clear();
                a.connection();
                a.cmd.CommandText = "select ID,Name,Money,Pictuer from Product where Quntity > 0";
                a.cmd.Connection = a.con;
                a.dr = a.cmd.ExecuteReader();
                a.dt.Load(a.dr);
                dataGridView1.DataSource = a.dt;
                a.dr.Close();
                a.Deconnection();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

            dataGridView1.RowTemplate.Height = 80;
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[3];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;

            ///////

            timer1.Start();
            timer1.Interval = 1000;

            //////////

            T.Orders(dataGridView2FAC, label21);

        }

        private void Home_MouseHover(object sender, EventArgs e)
        {

            label1.Text = T.SumProducts().ToString();
            label2.Text = T.SumOrders().ToString();
            label3.Text = T.SumFinProducts().ToString();
            label4.Text = T.SumMoney().ToString();

            try
            {

                a.dt.Clear();
                a.connection();
                a.cmd.CommandText = "select ID,Name,Money,Pictuer from Product where Quntity > 0";
                a.cmd.Connection = a.con;
                a.dr = a.cmd.ExecuteReader();
                a.dt.Load(a.dr);
                dataGridView1.DataSource = a.dt;
                a.dr.Close();
                a.Deconnection();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }

            dataGridView1.RowTemplate.Height = 80;
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image = (DataGridViewImageColumn)dataGridView1.Columns[3];
            image.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                a.dt.Clear();
                a.connection();
                a.cmd.CommandText = "select ID,Name,Money,Pictuer from Product where (Name like N'%" + textBox1.Text + "%' or ID like '"+textBox1.Text+"') and Quntity > 0";
                a.cmd.Connection = a.con;
                a.dr = a.cmd.ExecuteReader();
                a.dt.Load(a.dr);
                dataGridView1.DataSource = a.dt;
                a.dr.Close();
                a.Deconnection();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
             Bitmap bmp = new Bitmap(panel1.Width, panel1.Height, panel1.CreateGraphics());
             panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));
            RectangleF bounds = e.PageSettings.PrintableArea;
            float factor = ((float)bmp.Height / (float)bmp.Width);
            e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
            doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            doc.Print();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox2.Text);
            textBox2.Text = (a + 1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox2.Text);

            if (a != 0)
            {
                textBox2.Text = (a - 1).ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
             int a = Convert.ToInt32(textBox3.Text);
            textBox3.Text = (a + 5).ToString();

            if (dataGridView1.Rows.Count != 0)
            {
                c = 0;
                for (int i = 0; i < dataGridView2FAC.Rows.Count; i++)
                {
                    c += Convert.ToDouble(dataGridView2FAC.Rows[i].Cells[3].Value);
                    label15.Text = c.ToString();
                }

                p = Convert.ToInt32(textBox3.Text);
                double h = (c * p / 100);
                sum = c - h;
                label15.Text = sum.ToString();
                label23.Text = p.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
             int a = Convert.ToInt32(textBox3.Text);
            if (a != 0)
            {
                textBox3.Text = (a - 5).ToString();
            }

             if (dataGridView1.Rows.Count != 0)
            {
                c = 0;
                for (int i = 0; i < dataGridView2FAC.Rows.Count; i++)
                {
                    c += Convert.ToDouble(dataGridView2FAC.Rows[i].Cells[3].Value);
                    label15.Text = c.ToString();
                }

                p = Convert.ToInt32(textBox3.Text);
                double h = (c * p / 100);
                sum = c - h;

                label15.Text = sum.ToString();
                label23.Text = p.ToString();
            }
        }

        double c = 0;
        double p = 0;
        double sum;

        private void button5_Click(object sender, EventArgs e)
        {
            ////////Number Commonde///////////

            Random random = new Random();
            int id_cmd;
            if (label21.Text == "0000")
            {
                 id_cmd = random.Next();
                 label21.Text = id_cmd.ToString();
            }
            else
            {
                id_cmd = Convert.ToInt32(label21.Text);
            }

            var data = (Byte[])(dataGridView1.CurrentRow.Cells[3].Value);
            var stream = new MemoryStream(data);
            pictureBox7.Image = Image.FromStream(stream);
            //////////Add Order//////////////
            try
            {
                a.connection();
                a.cmd.CommandText = "insert into Orders values('" + id_cmd + "','" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "','" + textBox2.Text + "','" + (Convert.ToDouble(dataGridView1.CurrentRow.Cells[2].Value.ToString())*Convert.ToDouble(textBox2.Text)).ToString() + "',getdate())";
                a.cmd.Connection = a.con;
                a.cmd.ExecuteNonQuery();
                a.Deconnection();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }


            //////////select Order///////
            T.Orders(dataGridView2FAC, label21);

            /////////SUM Prix////////
            c = 0;
            for (int i = 0; i < dataGridView2FAC.Rows.Count; i++)
            {
                c += Convert.ToDouble(dataGridView2FAC.Rows[i].Cells[3].Value);
                label15.Text = c.ToString();
            }

            ////////Porsontage %%///////////
            
            p = Convert.ToDouble(textBox3.Text);
            double h = (c * p / 100);
            sum = c - h;

            label15.Text = sum.ToString();
            label23.Text = p.ToString();


            if (a.ACC.ToString() == "user")
            {
                mail.mailAdmin("scan produit " + dataGridView1.CurrentRow.Cells[0].Value.ToString() + " sur un commande " + id_cmd + " en date : " + DateTime.Now.Date.ToString());
            }
        }

        public string Qun;

        private void button8_Click(object sender, EventArgs e)
        {
            //Add Order
            for (int i = 0; i < dataGridView2FAC.RowCount; i++)
            {

                try
                {
                    a.connection();
                    a.cmd.Connection = a.con;
                    a.cmd.CommandText = "select Quntity from Product where name ='" + dataGridView2FAC.Rows[i].Cells[1].Value.ToString() + "'";
                    Qun = a.cmd.ExecuteScalar().ToString();
                    a.Deconnection();
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }

                Qun = (Convert.ToInt32(Qun)-Convert.ToInt32(dataGridView2FAC.Rows[i].Cells[2].Value.ToString())).ToString();

                try
                {
                    a.connection();
                    a.cmd.CommandText = "update Product set Quntity='" + Qun + "' where name ='" + dataGridView2FAC.Rows[i].Cells[1].Value.ToString() + "'";
                    a.cmd.Connection = a.con;
                    a.cmd.ExecuteNonQuery();
                    a.Deconnection();

                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }

            //For Print Factuer
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

            //send email to admin
            if (a.ACC.ToString() == "user")
            {
                mail.mailAdmin("inscrire une nouvall commande N°: " + label21.Text + " en date : " + DateTime.Now.Date.ToString());
            }

            //New Order
            label21.Text = "0000";
            label15.Text = "0";
            label23.Text = "0";
            dataGridView2FAC.DataSource = null;



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label14.Text = DateTime.Now.ToString();
        }


        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            int SPACE = 145;
            //string title = Application.StartupPath + "\\CBT_Title.png";
            //string barcode = Application.StartupPath + "\\code128bar.jpg";
            Graphics g = e.Graphics;

            string Titlehead = "*************************";
            string Titlehead1 = "******* LIBRAIRIE  ****";
            string Titlehead2 = "******** AMITIEE  *****";
            string Titlehead3 = "*************************";

            //string TType = "S";

            //if (rbReturn.Checked)
            //{
            //    TType = "R";
            //}



            //g.DrawImage(Image.FromFile(title), 50, 7);
            Font fBody = new Font("Lucida Console", 15, FontStyle.Bold);
            Font fBody1 = new Font("Lucida Console", 15, FontStyle.Regular);
            Font Footer = new Font("Lucida Console", 10, FontStyle.Bold);
            Font rs = new Font("Stencil", 25, FontStyle.Bold);
            Font fTType = new Font("", 20, FontStyle.Bold);
            SolidBrush sb = new SolidBrush(Color.Black);

            g.DrawString(Titlehead, fTType, sb, 50, 30);
            g.DrawString(Titlehead1, fTType, sb, 50, 50);
            g.DrawString(Titlehead2, fTType, sb, 50, 80);
            g.DrawString(Titlehead3, fTType, sb, 50, 110);

            g.DrawString("-------------------------------", fBody1, sb, 10, 120);

            g.DrawString("Date :", fBody, sb, 10, SPACE);
            g.DrawString(DateTime.Now.ToShortDateString(), fBody1, sb, 90, SPACE);

            g.DrawString("Time :", fBody, sb, 10, SPACE + 30);
            g.DrawString(DateTime.Now.ToShortTimeString(), fBody1, sb, 90, SPACE + 30);

            g.DrawString("TicketNo.:", fBody, sb, 10, SPACE + 60);
            g.DrawString(label21.Text, fBody1, sb, 140, SPACE + 60);

            g.DrawString("BusNo.:", fBody, sb, 10, SPACE + 90);
            g.DrawString(label21.Text, fBody1, sb, 100, SPACE + 90);

            //g.DrawString("DriverName:", fBody, sb, 10, SPACE+120);
            //g.DrawString(txtDriveName.Text, fBody1, sb, 153, SPACE + 120);

            g.DrawString("Route:", fBody, sb, 10, SPACE + 120);
            //g.DrawString(cbRoute.SelectedItem.ToString(), fBody1, sb, 100, SPACE + 120);


            g.DrawString("Name        QNT      Price", fBody, sb, 10, SPACE + 150);

            int i = 0;
            for (i = 0; i < dataGridView2FAC.Rows.Count; i++)
            {
                g.DrawString(dataGridView2FAC.Rows[i].Cells[1].Value.ToString(), fBody1, sb, 10, SPACE + 180 + i * 30);
                g.DrawString(dataGridView2FAC.Rows[i].Cells[2].Value.ToString() + "        " + dataGridView2FAC.Rows[i].Cells[3].Value.ToString(), fBody1, sb, 180, SPACE + 180 + i * 30);
            }


            g.DrawString("-------------------------------", fBody1, sb, 10, SPACE + 180 + i * 30);
            g.DrawString("REMISE. " + label23.Text + "%", rs, sb, 10, SPACE + 200 + i * 30);
            g.DrawString("TOTAL. " + label15.Text + "DH", rs, sb, 10, SPACE + 230 + i * 30);
            //g.DrawString(TType, fTType, sb, 240, 100);

            //g.DrawImage(Image.FromFile(barcode), 10, SPACE+240);
            g.DrawString("Address.: 24 village Pilote dar bouazza", Footer, sb, 10, 440 + i * 30);
            g.DrawString("phone.: +212 604082998", Footer, sb, 10, 465 + i * 30);
            g.DrawString("Merci d'avoir acheté chez nous !", Footer, sb, 80, 520 + i * 30);


            g.DrawRectangle(Pens.Black, 5, 5, 420, 550 + i * 30);

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //Quntity
            for (int i = 0; i < dataGridView2FAC.RowCount; i++)
            {

                try
                {
                    a.connection();
                    a.cmd.Connection = a.con;
                    a.cmd.CommandText = "select Quntity from Product where name ='" + dataGridView2FAC.Rows[i].Cells[1].Value.ToString() + "'";
                    Qun = a.cmd.ExecuteScalar().ToString();
                    a.Deconnection();
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }

                Qun = (Convert.ToInt32(Qun) - Convert.ToInt32(dataGridView2FAC.Rows[i].Cells[2].Value.ToString())).ToString();

                try
                {
                    a.connection();
                    a.cmd.CommandText = "update Product set Quntity='" + Qun + "' where name ='" + dataGridView2FAC.Rows[i].Cells[1].Value.ToString() + "'";
                    a.cmd.Connection = a.con;
                    a.cmd.ExecuteNonQuery();
                    a.Deconnection();

                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }


            PrintDocument pd = new PrintDocument();
            PaperSize ps = new PaperSize("", 475, 550);

            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            pd.PrintController = new StandardPrintController();
            pd.DefaultPageSettings.Margins.Left = 0;
            pd.DefaultPageSettings.Margins.Right = 0;
            pd.DefaultPageSettings.Margins.Top = 0;
            pd.DefaultPageSettings.Margins.Bottom = 0;

            pd.DefaultPageSettings.PaperSize = ps;
            pd.Print();

            if (a.ACC.ToString() == "user")
            {
                mail.mailAdmin("inscrire une nouvall commande N°: " + label21.Text + " en date : " + DateTime.Now.Date.ToString());
            }

            ////////////
            label21.Text = "0000";
            label15.Text = "0";
            label23.Text = "0";
            dataGridView2FAC.DataSource = null;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete product in this order ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    a.connection();
                    a.cmd.Connection = a.con;
                    a.cmd.CommandText = "delete from orders where id='" + dataGridView2FAC.CurrentRow.Cells[0].Value.ToString() + "'";
                    a.cmd.ExecuteNonQuery();

                    MessageBox.Show("Demande de suppression réussie");
                    T.Orders(dataGridView2FAC, label21);

                    if (a.ACC.ToString() == "user")
                    {
                        mail.mailAdmin("supprime une produit en commande N°: " + label21.Text + " en date : " + DateTime.Now.Date.ToString());
                    }

                    a.Deconnection();

                }
                catch (Exception l)
                {
                    MessageBox.Show(l.Message);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Are you sure to cancel this Orders ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {

                label21.Text = "0000";
                label15.Text = "0";
                label23.Text = "0";

                if (dataGridView2FAC.DataSource != null)
                {
                    for (int i = 0; i < dataGridView2FAC.Rows.Count; i++)
                    {
                        try
                        {
                            a.connection();
                            a.cmd.Connection = a.con;
                            a.cmd.CommandText = "delete from orders where id='" + dataGridView2FAC.Rows[i].Cells[0].Value.ToString() + "'";
                            a.cmd.ExecuteNonQuery();
                            a.Deconnection();
                        }
                        catch (Exception l)
                        {
                            MessageBox.Show(l.Message);
                        }
                    }

                    if (a.ACC.ToString() == "user")
                    {
                        mail.mailAdmin("Annuller un commande en date : " + DateTime.Now.Date.ToString());
                    }

                    dataGridView2FAC.DataSource = null;
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox4.Focus();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            a.connection();
            a.cmd.Connection = a.con;
            a.cmd.CommandText = "select ID from Product where ID = '" + textBox4.Text + "' and Quntity > 0";
            a.dr = a.cmd.ExecuteReader();

            if (a.dr.Read())
            {
                a.dr.Close();
                ////////Number Commonde///////////
                Random random = new Random();
                int id_cmd;

                if (label21.Text == "0000")
                {
                    id_cmd = random.Next();
                    label21.Text = id_cmd.ToString();
                }
                else
                {
                    id_cmd = Convert.ToInt32(label21.Text);
                }

                var Qu = "";
                // select Product by scanner
               try
                {
                    

                    a.connection();
                    a.cmd.Connection = a.con;
                    a.cmd.CommandText = "select * from Product where ID = '" + textBox4.Text + "' and Quntity > 0";
                    a.dr = a.cmd.ExecuteReader();

                    while (a.dr.Read())
                    {
                        Byte[] data = new Byte[0];
                        data = (Byte[])(a.dr[7]);
                        MemoryStream mem = new MemoryStream(data);
                        pictureBox7.Image = Image.FromStream(mem);

                        Qu = "insert into Orders values('" + id_cmd + "','" + a.dr[0].ToString() +"','" + textBox2.Text + "','" + (Convert.ToDouble(a.dr[4].ToString()) * Convert.ToDouble(textBox2.Text)).ToString() + "',getdate())";
                    }

                    a.dr.Close();
                    a.Deconnection();



                        
                        //////////Add Order//////////////
                        try
                        {
                            a.connection();
                            a.cmd.CommandText = Qu;
                            a.cmd.Connection = a.con;
                            a.cmd.ExecuteNonQuery();
                            a.Deconnection();

                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(x.Message);
                        }


                        //////////select Order///////
                        T.Orders(dataGridView2FAC, label21);

                        /////////SUM Prix////////
                        c = 0;
                        for (int i = 0; i < dataGridView2FAC.Rows.Count; i++)
                        {
                            c += Convert.ToDouble(dataGridView2FAC.Rows[i].Cells[3].Value);
                            label15.Text = c.ToString();
                        }

                        ////////Porsontage %%///////////

                        p = Convert.ToDouble(textBox3.Text);
                        double h = (c * p / 100);
                        sum = c - h;

                        label15.Text = sum.ToString();
                        label23.Text = p.ToString();


                   

                }
                catch (Exception r)
               {
                    a.dr.Close();
                    MessageBox.Show(r.Message);
                }

               if (a.ACC.ToString() == "user")
               {
                   mail.mailAdmin("scan produit " + textBox4.Text + " sur un commande " + id_cmd + " en date : " + DateTime.Now.Date.ToString());
               }

                ///////////
                textBox4.Clear();
                textBox4.Focus();
            }

            a.Deconnection();
        
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //Quntity
            for (int i = 0; i < dataGridView2FAC.RowCount; i++)
            {

                try
                {
                    a.connection();
                    a.cmd.Connection = a.con;
                    a.cmd.CommandText = "select Quntity from Product where name ='" + dataGridView2FAC.Rows[i].Cells[1].Value.ToString() + "'";
                    Qun = a.cmd.ExecuteScalar().ToString();
                    a.Deconnection();
                }
                catch (Exception b)
                {
                    MessageBox.Show(b.Message);
                }

                Qun = (Convert.ToInt32(Qun) - Convert.ToInt32(dataGridView2FAC.Rows[i].Cells[2].Value.ToString())).ToString();

                try
                {
                    a.connection();
                    a.cmd.CommandText = "update Product set Quntity='" + Qun + "' where name ='" + dataGridView2FAC.Rows[i].Cells[1].Value.ToString() + "'";
                    a.cmd.Connection = a.con;
                    a.cmd.ExecuteNonQuery();
                    a.Deconnection();

                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }

            label21.Text = "0000";
            label15.Text = "0";
            label23.Text = "0";
            dataGridView2FAC.DataSource = null;
            pictureBox7.ImageLocation = null;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                c = 0;
                for (int i = 0; i < dataGridView2FAC.Rows.Count; i++)
                {
                    c += Convert.ToDouble(dataGridView2FAC.Rows[i].Cells[3].Value);
                    label15.Text = c.ToString();
                }

                p = Convert.ToInt32(textBox3.Text);
                double h = (c * p / 100);
                sum = c - h;
                label15.Text = sum.ToString();
                label23.Text = p.ToString();
            }
        }

    }
}
