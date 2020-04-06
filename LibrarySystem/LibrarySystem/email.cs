using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net.Mime;
using System.Windows.Forms;
using LibrarySystem;

namespace System_Abdalli_multisport
{
    class email
    {
        Access a = new Access();
        private static string EmailSendr;
        private static string EmailAdmin;
        private static string password;
        private static string Port;
        private static string SMTP;
        private static string Subject;
        private static string Message;


        public void infomail()
        {
            a.connection();
            a.cmd.CommandText = "select * from email";
            a.cmd.Connection = a.con;
            a.dr = a.cmd.ExecuteReader();
            while (a.dr.Read())
            {
                EmailSendr = a.dr[0].ToString();
                EmailAdmin = a.dr[1].ToString();
                password = a.dr[2].ToString();
                Port = a.dr[3].ToString();
                SMTP = a.dr[4].ToString();
                Subject = a.dr[5].ToString();
                Message = a.dr[6].ToString();
            }
            a.dr.Close();
            a.Deconnection();
        }
        



        public void mailAdmin(string messsage)
        {
            try
            {
                infomail();
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(EmailAdmin.ToString());
                    mail.To.Add(EmailSendr);
                    mail.Subject = Subject.ToString();

                    //style message
                    mail.Body = messsage;

                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient(SMTP, Convert.ToInt32(Port.ToString())))
                    {
                        smtp.Credentials = new NetworkCredential(EmailAdmin.ToString(), password.ToString());
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        MessageBox.Show("Email Send Successfuly");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      

    }
}
