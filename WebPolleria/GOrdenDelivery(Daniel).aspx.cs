using BE_;
using BL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public partial class GOrdenDelivery_Daniel_ : System.Web.UI.Page
    {
        BL_GenerarOrdenPedidoDelivery blGOPD=null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaPedidosPreparados();
            ListaRepartidores();
        }

        protected void ListaPedidosPreparados()
        {
            blGOPD=new BL_GenerarOrdenPedidoDelivery(); 
            gvListaPedidos.DataSource = blGOPD.ListaPedidosGOPD();
            gvListaPedidos.DataBind();

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            ListaPedidosPreparados();
        }

        protected void SelectButton_Click(object sender, EventArgs e)
        {
            // Lógica para manejar el evento de clic del botón "Seleccionar"
        }
        protected void ListaRepartidores()
        {
            blGOPD = new BL_GenerarOrdenPedidoDelivery();
            gvRepEnable.DataSource = blGOPD.ListaRepartidores();
            gvRepEnable.DataBind();
        }
    }
}