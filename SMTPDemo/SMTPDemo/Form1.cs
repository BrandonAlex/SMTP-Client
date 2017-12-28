using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

//you need 2 classes for this System.Net and System.Net.Mail

namespace SMTPDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var mail = new MailMessage();
                var client = new SmtpClient("mail.smtp2go.com", 2525) //your port may be different 
                {
                    Credentials = new NetworkCredential("username", "password"),
                    EnableSsl = true
                };

                MailMessage objMsg = new MailMessage();
                objMsg.Body = textBox3.Text;
                objMsg.Subject = textBox2.Text;
                objMsg.From = new MailAddress(textBox1.Text.ToString());
                objMsg.To.Add(new MailAddress("to email"));
                client.Send(objMsg);

                MessageBox.Show("Your email was sent!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Your message didnt send, check your email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
