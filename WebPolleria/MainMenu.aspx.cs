using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public partial class MainMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rolBi.InnerHtml = Session["RolUser"].ToString().ToUpper();
        //    if (Session["RolUser"] != null) { 
        //    Response.Redirect("Login.aspx", true);
        //} 
        }
    }
}