using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System_Abdalli_multisport;

namespace LibrarySystem.AllForms
{
    public partial class FRM_Show_Orders : Form
    {
        public FRM_Show_Orders()
        {
            InitializeComponent();
        }
        Access a = new Access();
        TheQuery t = new TheQuery();
        email mail = new email();

        private void FRM_Show_Orders_Load(object sender, EventArgs e)
        {
            try
            {
                a.connection();
                a.cmd.CommandText = "select * from Orders where ID_cmd ='" + a.id.ToString() + "'";
                a.cmd.Connection = a.con;
                a.dr = a.cmd.ExecuteReader();

                 while (a.dr.Read())
                 {
                     label21.Text = a.dr[1].ToString();
                     label14.Text = a.dr[5].ToString();
                     t.Orders(dataGridView2FAC, label21);
                 }
                 
                 a.dr.Close();
                 a.Deconnection();
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message);
            }


            double c = 0;
            for (int i = 0; i < dataGridView2FAC.Rows.Count; i++)
            {
                c += Convert.ToDouble(dataGridView2FAC.Rows[i].Cells[3].Value);
                label15.Text = c.ToString();
            }
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            int SPACE = 145;
            //string title = Application.StartupPath + "\\CBT_Title.png";
            //string barcode = Application.StartupPath + "\\code128bar.jpg";
            Graphics g = e.Graphics;

            string Titlehead =  "*************************";
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


            g.DrawString("Name        QNT      Price", fBody, sb, 10, SPACE + 150 );

            int i = 0;
            for (i = 0; i < dataGridView2FAC.Rows.Count; i++)
            {
                g.DrawString(dataGridView2FAC.Rows[i].Cells[1].Value.ToString(), fBody1, sb, 10, SPACE + 180 + i * 30);
                g.DrawString(dataGridView2FAC.Rows[i].Cells[2].Value.ToString() + "        " + dataGridView2FAC.Rows[i].Cells[3].Value.ToString(), fBody1, sb, 180, SPACE + 180 + i * 30);
            }


            g.DrawString("-------------------------------", fBody1, sb, 10, SPACE + 180 + i * 30);
            g.DrawString("TOTAL. "+label15.Text+"DH", rs, sb, 10, SPACE + 200 + i * 30);
            //g.DrawString(TType, fTType, sb, 240, 100);

            //g.DrawImage(Image.FromFile(barcode), 10, SPACE+240);
            g.DrawString("Address.: 24 village Pilote dar bouazza", Footer, sb, 10, 440 + i * 30);
            g.DrawString("phone.: +212 604082998", Footer, sb, 10, 465 + i * 30);



            g.DrawRectangle(Pens.Black, 5, 5, 420, 500 + i * 30);

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height, panel1.CreateGraphics());
            panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));
            RectangleF bounds = e.PageSettings.PrintableArea;
            float factor = ((float)bmp.Height / (float)bmp.Width);
            e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
        
        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
            doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            doc.Print();

            if (a.ACC.ToString() == "user")
            {
                mail.mailAdmin("imprime un demande en date : " + DateTime.Now.Date.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                mail.mailAdmin("ticke un demande en date : " + DateTime.Now.Date.ToString());
            }
        }
    }
}
