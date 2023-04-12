using System;
using BL_;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BCrypt.Net;
using System.Text;
using System.Web.SessionState;
using bc = BCrypt.Net.BCrypt;

namespace WebPolleria
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        BL_Usuario us;
        protected void Page_Load(object sender, EventArgs e)
        {
            //quiero que se note este cambio en el archivo
            //si se borra es porque jonathan es un marica
            //jonathan puto
        }
        protected void CargarPag(string a, string b) 
        {

            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            us = new BL_Usuario();
            string usuario = this.txtUser.Text;
            //string password = bc.HashPassword(txtPass.Text,12);
            string password = bc.HashPassword(us.BL_Validacion(usuario),12);
            var verificacion = bc.Verify(txtPass.Text,password);
            if (verificacion)
            {
                if (us.ValUsuario(usuario,txtPass.Text)!=0) {
                    Session["RolUser"] = us.GetRol(usuario, txtPass.Text);
                    Session["usuario"] = txtUser.Text;
                    Response.Redirect("MainMenu.aspx", true);
                    
                }
                else
                {
                    Session["usuario"] = txtUser.Text;
                    
                    Session["RolUser"] = us.GetRol(usuario, txtPass.Text);
                    //Response.Redirect("MainMenu.aspx", true);
                    Response.Redirect("PreSeguridad.aspx", true);
                }
            }
            else
            {
                txtPass.Text = string.Empty;
                txtUser.Text = string.Empty;
                txtUser.Focus();
                Message("Credenciales Incorrectas, intentelo de nuevo");
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