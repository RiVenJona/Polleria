using BL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public partial class PreSeguridad : System.Web.UI.Page
    {
        BL_Usuario bL_Usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["RolUser"] != null)
            //{
            //    Response.Redirect("Login.aspx", true);
            //}
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            bL_Usuario = new BL_Usuario();
            HttpCookie cookie = Request.Cookies["MisDatos"];
            string valor1 = cookie["usuario"];
            string p1 = Request.Form["txtPregunta1"];
            string p2 = Request.Form["txtPregunta2"];
            string p3 = Request.Form["txtPregunta3"];
            string p4 = Request.Form["txtPregunta4"];
            string p5 = Request.Form["txtPregunta5"];
            if (bL_Usuario.RegPreguntas(valor1, p1, p2, p3, p4, p5))
            {
                Response.Redirect("CambiarPass.aspx", true);
            }
        }
    }
}