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
    public partial class GeneOrdenCompra1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarSolis();
            }
        }
        protected void CargarSolis()
        {
            BL_OrdenCompra OC = new BL_OrdenCompra();
            GvSolicitudes.DataSource = OC.ListaSolicitudes();
            GvSolicitudes.DataBind();
            GvSolicitudes.Width = Unit.Percentage(75);
        }
        protected void GvSolicitudes_SelectedIndexChanged(object sender, EventArgs e)
        {
            BL_OrdenInsumo OI = new BL_OrdenInsumo();
            GridViewRow row = GvSolicitudes.SelectedRow;
            string a = row.Cells[0].Text;
            GvInsumo.DataSource = OI.ListaInsumoOC(a);
            GvInsumo.DataBind();
            GvInsumo.Width = Unit.Percentage(60);
            Insumos.Style["overflow-x"] = "auto";
        }
        protected string ObtenerUsuario()
        {
            string LogedUser = Session["usuario"].ToString();
            return LogedUser;
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

        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx", true);
        }

        protected void BtnGenerar_Click(object sender, EventArgs e)
        {

        }
    }
}