using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["RolUser"].ToString() != string.Empty)
            //{
            //    this.txtRol.Value = Session["RolUser"].ToString();
            //    if (Session["RolUser"].ToString() == "Recepcionista")
            //    {
            //        aGenOrden.Style.Add("display", "none");
            //    }
            //    if (Session["RolUser"].ToString() == "Jefe de Cocina")
            //    {
            //        aRegistrar.Style.Add("display", "none");
            //        aAnular.Style.Add("display", "none");
            //    }
            //}

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["RolUser"] = String.Empty; // Borra la variable de sesión "rol"
            Response.Redirect("~/Login.aspx", true);
        }
    }
}