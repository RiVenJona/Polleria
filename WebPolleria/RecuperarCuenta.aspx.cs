using BL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public partial class RecuperarCuenta : System.Web.UI.Page
    {
        BL_Usuario blUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Preguntas.Visible = false;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string valor = Request.Form["txtUsuario"];
            blUser = new BL_Usuario();
            string user = Request.Form["txtUsuario"];
            if (blUser.ExisteUsuario(user))
            {
                Preguntas.Visible = true;
                Message("Conteste las preguntas de seguridad correctamente para formatear su contraseña.");
            }
            else
            {
                Message("Usuario no encontrado, ingrese nuevamente");
            }

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            blUser = new BL_Usuario();
            string p1 = Request.Form["txtPregunta1"];
            string p2 = Request.Form["txtPregunta2"];
            string p3 = Request.Form["txtPregunta3"];
            string p4 = Request.Form["txtPregunta4"];
            string p5 = Request.Form["txtPregunta5"];
            string user = blUser.ValidarUsuario(p1, p2, p3, p4, p5);
            if (user != string.Empty)
            {
                Session["User"] = user;
            }
            else
            {
                Message("No se pudo validar sus preguntas, reingrese las respuestas");
                Limpiar();
            }
        }

        protected void Limpiar()
        {
            txtPregunta1.Value = "";
            txtPregunta2.Value = "";
            txtPregunta3.Value = "";
            txtPregunta4.Value = "";
            txtPregunta5.Value = "";
        }


    }
}