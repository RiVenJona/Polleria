using BL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public partial class WebForm4 : System.Web.UI.Page
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
            BL_OrdenPedidoDelivery OPD = new BL_OrdenPedidoDelivery();
            GvOrdenes.DataSource = OPD.ListaOrdenesPedidoXDeliveryID();
            GvOrdenes.DataBind();
            GvOrdenes.Width = Unit.Percentage(100);
            Panel3.Style["overflow-x"] = "auto";


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
    }
}