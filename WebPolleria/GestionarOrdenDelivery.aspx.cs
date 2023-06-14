using BL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar();
            if (!Page.IsPostBack)
            {
                
            }
        }
        protected int ObtenerUsuario()
        {
            BL_Trabajador TR = new BL_Trabajador();
            int idtra = TR.BuscarIdUsuario(Session["usuario"].ToString());
            return idtra;
        }
        protected void Cargar()
        {
            BL_OrdenPedidoDelivery OPD = new BL_OrdenPedidoDelivery();
            BL_GenerarOrdenPedidoDelivery GOPD = new BL_GenerarOrdenPedidoDelivery();
            int user = ObtenerUsuario();
            
            string ultimo = GOPD.UltimoDelivery(user).ToString(); 
            if (ultimo == "0")
            {
                txtOD.Text = "Sin asignar";

            } else
            {
                txtOD.Text = ultimo;
            }
            GvOrdenes.DataSource = OPD.ListaOrdenesPedidoXDeliveryID(int.Parse(ultimo));
            GvOrdenesDel.DataSource = OPD.ListaOrdenesPedido2XDeliveryID(int.Parse(ultimo));
            GvOrdenes.DataBind();
            GvOrdenesDel.DataBind();
            GvOrdenes.Width = Unit.Percentage(100);
            Panel3.Style["overflow-x"] = "auto";
            GvOrdenesDel.Width = Unit.Percentage(100);
            Panel5.Style["overflow-x"] = "auto";


            //recaudacion
            txtRecaudacion.Text = RecaudacionTotal().ToString();

        }

        protected double RecaudacionTotal()
        {
            double totRecaudacion = 0;
            for (int i = 0; i < GvOrdenes.Rows.Count; i++)
            {
                GridViewRow row = GvOrdenes.Rows[i];
                totRecaudacion = totRecaudacion + double.Parse(row.Cells[3].Text);
            }
            return totRecaudacion;
        }

        protected void RblEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            BL_OrdenPedidoDelivery OPD = new BL_OrdenPedidoDelivery();
            if (OPD.CambiarEstadoDelivery(int.Parse(ddlEstado.SelectedValue), txtNroOP.Text))
            {
                Message("ESTADO DE DELIVERY CAMBIADO");
            }
            Response.Redirect("GestionarOrdenDelivery.aspx");
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
        }
        protected void GvOrdenesDel_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GvOrdenesDel.SelectedRow;
            txtNroOP.Text = row.Cells[0].Text;

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