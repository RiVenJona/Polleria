using BL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public partial class GenOrdenSalida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Cargar();
            }
        }
        protected void Cargar()
        {
            BL_OrdenInsumo OI = new BL_OrdenInsumo();
            GvInsumo.DataSource = OI.ListaOrdenesInsumo();
            GvInsumo.DataBind();
            GvInsumo.Width = Unit.Percentage(100);
            Panel1.Style["overflow-x"] = "auto";
        }
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
        }
        protected void btnSolicitar_Click(object sender, EventArgs e)
        {
        }
    }
    

}