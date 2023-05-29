using BE_;
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
    public partial class WebForm3 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTabla();
            if (!Page.IsPostBack)
            {
                
            }
        }

        protected void GvEsperando_SelectedIndexChanged(object sender, EventArgs e)
        {
            BL_OrdenPedido OP = new BL_OrdenPedido();
            GridViewRow row = GvEsperando.SelectedRow;
            int idorden = int.Parse(row.Cells[0].Text);
            if (ddlTipo.SelectedIndex == 0)
            {
                GvDetalle.DataSource = OP.DetalleXTicketPreparar(idorden);
            }
            else if (ddlTipo.SelectedIndex == 1)
            {
                GvDetalle.DataSource = OP.DetalleXODPPreparar(idorden);
            }
            GvDetalle.DataBind();
            GvDetalle.Width = Unit.Percentage(100);
            Panel2.Style["overflow-x"] = "auto";
        }
        protected void CargarTabla()
        {
            BL_OrdenPedido OP = new BL_OrdenPedido();
            if (ddlTipo.SelectedIndex == 0)
            {
                GvEsperando.DataSource = OP.ListaTickets();
            } else if (ddlTipo.SelectedIndex == 1)
            {
                GvEsperando.DataSource = OP.ListaPedidosDeliveryPreparar();
            }
            GvEsperando.DataBind();
            GvEsperando.Width = Unit.Percentage(100);
            Panel7.Style["overflow-x"] = "auto";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }
        protected void btnPreparado_Click(object sender, EventArgs e)
        {

            BL_OrdenPedido OP = new BL_OrdenPedido();
            GridViewRow row = GvEsperando.SelectedRow;
            int idorden = int.Parse(row.Cells[0].Text);
            if (ddlTipo.SelectedIndex == 0)
            {
                if (OP.OPPreparado(idorden))
                {
                    Message("TICKET/ORDEN PREPARADO");

                }
            }
            else if (ddlTipo.SelectedIndex == 1)
            {
                if (OP.OPDPreparado(idorden))
                {
                    Message("ORDEN PEDIDO DELIVERY PREPARADO");

                }
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