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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                
                Cargar();
            }
        }

        protected void Cargar()
        {
            BL_OrdenPedidoDelivery OPD = new BL_OrdenPedidoDelivery();
            GvPedidos.DataSource = OPD.ListaOrdenesDevueltos();
            GvPedidos.DataBind();
            GvPedidos.Width = Unit.Percentage(100);
            Panel1.Style["overflow-x"] = "auto";
            GvPedidos.SelectedIndex = -1;
            GvDetalle.DataBind();
            
        }
        protected void Limpiar()
        {
            txtOPD.Text = "";
        }
        protected void GvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            BL_CatalogoProductos CP = new BL_CatalogoProductos();
            txtOPD.Text = GvPedidos.SelectedRow.Cells[0].Text;
            GvDetalle.DataSource = CP.ListaDevoluciones(txtOPD.Text);
            GvDetalle.DataBind();
            GvDetalle.Width = Unit.Percentage(100);
            Panel1.Style["overflow-x"] = "auto";
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
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }

        protected void btnLiberar_Click(object sender, EventArgs e)
        {
            BL_PlatosDevueltos PD = new BL_PlatosDevueltos();
            if (string.IsNullOrEmpty(txtOPD.Text))
            {
                Message("Debe seleccionar un pedido delivery devuelto.");
            }
            else
            {
                PD.RegistrarPlatosDevueltos(txtOPD.Text);
                PD.CerrarOrdenPedidoDelivery(txtOPD.Text);
                Message("Pedido delivery liberado con éxito.");
                Limpiar();
            }
            Cargar();
        }
    }
}