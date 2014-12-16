using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinearOptimizationGame.Pages
{
    public partial class consulting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }      
        //protected void btnSendEmail_Click1(object sender, EventArgs e)
        //{
        //    SmtpClient smtp = new SmtpClient();

        //    smtp.Host = "smtp.gmail.com";
        //    smtp.Port = 587;
        //    smtp.EnableSsl = true;
        //    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        //    smtp.Credentials = new NetworkCredential("uweschmidt.it@googlemail.com", "Venezi97!");
        //    smtp.Timeout = 20000;

        //    smtp.Send("uwe42@gmx.de", "uwe42@gmx.de", "hallo from website", "hallo uwe dies ist ein feedback");

        //    /*
        //    MailMessage message = new MailMessage();
        //    message.From = new MailAddress(inputEmail.Value);

        //    message.To.Add(new MailAddress("uwe42@gmx.de"));

        //    message.Subject = "This is my subject";

        //    message.Body = ta1.InnerText;
        //    SmtpMail.SmtpServer = "";
        //    SmtpClient client = new SmtpClient();
        //    client.Send(message);
        //     * */
        //}
    }
}