using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net.Mail;
using System.Text;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public partial class VerCorreo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            btnenviar.ServerClick += new EventHandler(btnEnviar_Click);

        }
        protected void EnviarCod()
        {
            string codigover = "ZzKbron";
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("mo05061213@gmail.com");
            msg.To.Add(new MailAddress("2019100308@ucss.pe"));
            msg.Subject = "Codigo de Verificacion - Polleria El buen Sabor";
            msg.Body = "Su codigo de verificacion es:" + codigover;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Credentials = new System.Net.NetworkCredential("mo05061213@gmail.com", "mayaporsiempre");
            smtp.EnableSsl = true;
            smtp.Send(msg);
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            EnviarCod();
        }
    }
}