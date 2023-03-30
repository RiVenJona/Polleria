using BL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public partial class CambiarPass : System.Web.UI.Page
    {
        BL_Usuario bluser;
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["RolUser"] != null)
            //{
            //    Response.Redirect("login.aspx", true);
            //}

        }

        protected void btnCambiarPass_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["MisDatos"];
            string user = cookie["usuario"];
            string nuevapass = Request.Form["txtNuevapass"];
            bool contieneMayusculas = Regex.IsMatch(nuevapass, "[A-Z]");
            bool contieneNumeros = Regex.IsMatch(nuevapass, @"\d");
            bool contieneSimbolos = Regex.IsMatch(nuevapass, @"[^\w\s]");
            if (contieneMayusculas&&contieneNumeros&&contieneSimbolos)
            {
                if(bluser.CamPass(user, nuevapass))
                {
                    Response.Redirect("MainMenu.aspx", true);
                }
                else
                {
                    Message("Hubo un error al cambiar la contraseña");
                }
            }
            else
            {
                Message("Contraseña insegura, siga hasta que la barra este completamente verde");
            }
        }
        public void Message(string str)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<script type = 'text/javascript'>");
            stringBuilder.Append("window.onload=function(){");
            stringBuilder.Append("alert('");
            stringBuilder.Append(str);
            stringBuilder.Append("')};");
            stringBuilder.Append("</script>");
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Alerta", stringBuilder.ToString());
        }
    }
}