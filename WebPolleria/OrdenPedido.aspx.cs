using BE_;
using BL_;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public partial class OrdenPedido : System.Web.UI.Page
    {
        BL_CatalogoProductos IN;
        List<BE_CatalogoProductos> listaFilas = new List<BE_CatalogoProductos>();
        BL_Trabajador TR;
        BL_OrdenPedido blOrdenPedido;
        string a = "";
        string user = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            user = Session["usuario"].ToString();
            if (!Page.IsPostBack)
            {
                CargarTabla(a);
                if (ViewState["listaFilas"] == null)
                {
                    ViewState["listaFilas"] = new List<BE_CatalogoProductos>();
                }
                gvPedido.DataSource = (List<BE_CatalogoProductos>)ViewState["listaFilas"];
                gvPedido.DataBind();
                txtTotal.Value = "s/" + 0;
                TR = new BL_Trabajador();
                nombreMozo.Value = TR.BuscarNombreTrabajador(Session["usuario"].ToString());
                
            }
            if (user != null)
            {
                TR = new BL_Trabajador();
                MesasOcupadas(TR.BuscarIdTrabajador(user));
            }
            MesasOcupadas(TR.BuscarIdTrabajador(user));
            
            

        }
        public double TotalOP(int id)
        {
            blOrdenPedido = new BL_OrdenPedido();
            return blOrdenPedido.TotalOP(id);
        }
        public void GenerarAcordeon(List<TicketDetalle> listTicket)
        {
            blOrdenPedido=new BL_OrdenPedido();
            var accordionContainer = new PlaceHolder();
            if (listTicket.Count!=0) { 
            foreach (var dato in listTicket)
            {
                var button = new LiteralControl("<h4 class=\"accordion\">✅ Ticket Nro."+dato.idTicket+ "&nbsp&nbsp&nbsp&nbspPrecio:s/" + dato.totalTicket+ "&nbsp&nbsp&nbsp&nbspArticulos:" + dato.cantidadXTicket+"</h4>");
                    var panel = ContAcordeon(blOrdenPedido.DetallexTicket(dato.idTicket));

                accordionContainer.Controls.Add(button);
                accordionContainer.Controls.Add(panel);
            }

            TicketsUsuario.Controls.Add(accordionContainer);
            }
            else
            {
                var panel = new LiteralControl("<div class=\"panel\"><p>NO SE ENCONTRARON TICKETS PREVIOS</p></div>");
                accordionContainer.Controls.Add(panel);
                TicketsUsuario.Controls.Add(accordionContainer);
            }
        }
        public Panel ContAcordeon(List<TicketDetalle> listTicketDetalle)
        {
            Panel panel=new Panel();
            PlaceHolder placeholder = new PlaceHolder();
            StringBuilder htmlBuilder = new StringBuilder();
            panel.CssClass = "panel";
            foreach (var dato in listTicketDetalle)
                {
                    var panel2 = new LiteralControl("<div class=\"panel2\"><h5>✔️&nbspProducto:&nbsp" + dato.desProductoTicket + "&nbsp&nbsp&nbsp&nbsp&nbspCantidad:&nbsp" + dato.cantidadProductoTicket + "&nbsp&nbsp&nbsp&nbsp&nbspPrecioXUnidad:&nbsps/" + dato.precio + "&nbsp&nbsp&nbsp&nbsp&nbspTotal:&nbsp" + dato.totalProductoTicket + "</h5>"+ "</div>");
                panel.Controls.Add(panel2);
            }
            
            return panel;
        }

        protected void MesasOcupadas(int user)
        {
            BL_CatalogoProductos caPro = new BL_CatalogoProductos();
            DropDownList1.DataSource = caPro.listaMesas(user);
            DropDownList1.DataBind();
        }
        protected void CargarTabla(string b)
        {
            BL_CatalogoProductos caPro = new BL_CatalogoProductos();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Producto");
            dt.Columns.Add("Precio");

            gvPedido.DataSource = dt;
            gvPedido.DataBind();
            gvCatalogo.DataSource = caPro.ListaProductos(b);
            gvCatalogo.DataBind();
        }
        protected void CargarTabla2(string b)
        {
            BL_CatalogoProductos caPro = new BL_CatalogoProductos();
            gvCatalogo.DataSource = caPro.ListaProductos(b);
            gvCatalogo.DataBind();
            ObtenerTotal();
        }
        protected void btnIncrementar_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow GvrOrden = (GridViewRow)button.Parent.Parent;
            TextBox textBox = (TextBox)GvrOrden.FindControl("txtCantGv");
            string numInsumo = GvrOrden.Cells[0].Text;
            int value = 0;
            int cantidadMaxima = 0;
            foreach (GridViewRow GvrDatos in gvPedido.Rows)
            {
                if (GvrDatos.Cells[0].Text == numInsumo)
                {
                    cantidadMaxima = 5;
                    break;
                }
            }
            if (int.TryParse(textBox.Text, out value))
            {
                if (value >= cantidadMaxima)
                {

                }
                else
                {
                    value++;
                }
                textBox.Text = value.ToString();
            }
            ObtenerTotal();
        }

        protected void btnDisminuir_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow gridViewRow = (GridViewRow)button.Parent.Parent;
            TextBox textBox = (TextBox)gridViewRow.FindControl("txtCantGv");
            int value;
            if (int.TryParse(textBox.Text, out value))
            {
                value--;
                if (value < 1)
                {
                    value = 1;
                }
                textBox.Text = value.ToString();
            }
            ObtenerTotal();
        }

        protected void ObtenerTotal()
        {
            int Cantidad;
            double total=0;
            for (int i = 0; i < gvPedido.Rows.Count; i++)
            {
                GridViewRow row = gvPedido.Rows[i];
                TextBox tbC = (TextBox)gvPedido.Rows[i].FindControl("txtCantGv");
                Cantidad = int.Parse(tbC.Text);
                double xd = double.Parse(row.Cells[3].Text);
                total += xd * Cantidad;
                
            }
            txtTotal.Value = "s/"+total.ToString();
        }
        protected void GvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvCatalogo.SelectedRow;
            BE_CatalogoProductos NI = new BE_CatalogoProductos();
            NI.idProducto = int.Parse(row.Cells[0].Text);
            NI.desProducto = row.Cells[1].Text;
            NI.PrecioProducto = double.Parse(row.Cells[2].Text);
            NI.cantidadProducto = 1;

            List<BE_CatalogoProductos> listaFilas = (List<BE_CatalogoProductos>)ViewState["listaFilas"];

            bool filaRepetida = false;
            foreach (BE_CatalogoProductos fila in listaFilas)
            {
                if (fila.idProducto == NI.idProducto)
                {
                    filaRepetida = true;
                    break;
                }
            }
            if (!filaRepetida)
            {
                listaFilas.Add(NI);
                ViewState["listaFilas"] = listaFilas;

                gvPedido.DataSource = listaFilas;
                gvPedido.DataBind();
                ObtenerTotal();
            }
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
                int index = int.Parse((sender as Button).CommandArgument);
            listaFilas.RemoveAt(index);
            gvPedido.DataSource = listaFilas;
            gvPedido.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            a = Request.Form["txtBuscarProducto"];
            CargarTabla2(a);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            blOrdenPedido = new BL_OrdenPedido();
            nombreCliente.Value = blOrdenPedido.NombreCliente(int.Parse(DropDownList1.SelectedValue));
            List<TicketDetalle> Lista = new List<TicketDetalle>();
            TR = new BL_Trabajador();
            int id = TR.BuscarIdTrabajador(user);
            Lista = blOrdenPedido.ListaTicketsXOP(blOrdenPedido.GetOrdenPedidoId(id, int.Parse(DropDownList1.SelectedValue)));
            GenerarAcordeon(Lista);
            txtTotalOP.Value = "s/" + TotalOP(blOrdenPedido.GetOrdenPedidoId(id, int.Parse(DropDownList1.SelectedValue)));
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
        protected void Button3_Click(object sender, EventArgs e)
        {
            Message("Se genero correctamente");
        }

        protected void gvCatalogo_PageIndexChanged(object sender, GridViewPageEventArgs e)
        {
            
        }

        protected void gvCatalogo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCatalogo.PageIndex = e.NewPageIndex;
            CargarTabla(a);
        }
    }
}