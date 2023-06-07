using BE_;
using BL_;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WebPolleria
{
    public partial class GOrdenDelivery_Daniel_ : System.Web.UI.Page
    {
        BL_GenerarOrdenPedidoDelivery blGOPD=null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!Page.IsPostBack) { 
            ListaPedidosPreparados();
            ListaRepartidores();
            }
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

        protected void ListaRepartidores()
        {
            blGOPD = new BL_GenerarOrdenPedidoDelivery();
            gvRepEnable.DataSource = blGOPD.ListaRepartidores();
            gvRepEnable.DataBind();
        }
        //ADICIONES DENTRO DEL DOCUMENTO
        public void GenerarAcordeon(string num)
        {
            blGOPD = new BL_GenerarOrdenPedidoDelivery();
            var accordionContainer = new PlaceHolder();
                    //var button = new LiteralControl("<h4 class=\"accordion\">✅ Ticket Nro." + dato.idTicket + "&nbsp&nbsp&nbsp&nbspPrecio:s/" + dato.totalTicket + "&nbsp&nbsp&nbsp&nbspArticulos:" + dato.cantidadXTicket + "</h4>");
                    var panel = ContAcordeon(blGOPD.ListaTickets(num));

                    //accordionContainer.Controls.Add(button);
                      accordionContainer.Controls.Add(panel);

                Modal.Controls.Add(accordionContainer);
        }
        public Panel ContAcordeon(List<TicketDetalle> listTicketDetalle)
        {
            Panel panel = new Panel();
            PlaceHolder placeholder = new PlaceHolder();
            StringBuilder htmlBuilder = new StringBuilder();
            panel.CssClass = "panel";
            foreach (var dato in listTicketDetalle)
            {
                var panel2 = new LiteralControl("<div class=\"panel2\"><h5>✔️&nbspProducto:&nbsp" + dato.desProductoTicket + "&nbsp&nbsp&nbsp&nbsp&nbspCantidad:&nbsp" + dato.cantidadProductoTicket + "&nbsp&nbsp&nbsp&nbsp&nbspPrecioXUnidad:&nbsps/" + dato.precio + "&nbsp&nbsp&nbsp&nbsp&nbspTotal:&nbsp" + dato.totalProductoTicket + "</h5>" + "</div>");
                panel.Controls.Add(panel2);
            }

            return panel;
        }
        protected int checkboxCount = 0;
        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in gvListaPedidos.Rows)
            {
                CheckBox checkBox = (CheckBox)row.FindControl("CheckBox1");

                if (checkBox.Checked)
                {
                    checkboxCount++;
                    
                }
            }
            txtSeleccionados.Text = checkboxCount.ToString();
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            List<string> valoresPrimeraColumna = new List<string>();

            blGOPD = new BL_GenerarOrdenPedidoDelivery();
            foreach (GridViewRow row in gvListaPedidos.Rows)
            {
                CheckBox checkBox = (CheckBox)row.FindControl("CheckBox1");

                if (checkBox.Checked)
                {
                    string valorPrimeraColumna = row.Cells[0].Text; // Obtener el valor de la primera columna
                    valoresPrimeraColumna.Add(valorPrimeraColumna);
                }
            }
            string cad = "";
            if (int.Parse(txtSeleccionados.Text) == 0) {Message("Seleccione un pedido para asignar");
                return;    
            }
            if (gvRepEnable.SelectedIndex < 0)
            {
                Message("Seleccione un repartidor al cual asignar");
                return;
            }
            //GENERAMOS DOCUMENTO PRINCIPAL
            GridViewRow selectedRow = gvRepEnable.SelectedRow;
            string repartidor = selectedRow.Cells[0].Text;
            if (blGOPD.RegistrarGOPD(int.Parse(repartidor)))
            {
                for (int i = 0; i < valoresPrimeraColumna.Count; i++)
                {
                    if (blGOPD.RegistrarDetalleGOPD(valoresPrimeraColumna[i]))
                    {

                    }
                    else
                    {
                        Message("Error al insertar Detalle");
                    }
                }
                Message("Se asigno con exito!");
                gvRepEnable.SelectedIndex = -1;
                ListaPedidosPreparados();
                ListaRepartidores();
                txtSeleccionados.Text = "0";
            }
            else
            {
                Message("Error al insertar GOPD");
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

        protected void gvRepEnable_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void gvListaPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = gvListaPedidos.SelectedRow;
            string codigo = selectedRow.Cells[0].Text;
            GenerarAcordeon(codigo);
        }
    }
}