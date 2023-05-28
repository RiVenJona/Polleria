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
    public partial class GeneOrdenDelivery : System.Web.UI.Page
    {
        BL_CatalogoProductos IN;
        List<BE_CatalogoProductos> listaFilas = new List<BE_CatalogoProductos>();
        BL_Trabajador TR;
        string a = "";
        string Cli = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!Page.IsPostBack)
            {
                CargarTabla(a);
                if (ViewState["listaFilas"] == null)
                {
                    ViewState["listaFilas"] = new List<BE_CatalogoProductos>();
                }
                gvPedido.DataSource = (List<BE_CatalogoProductos>)ViewState["listaFilas"];
                gvPedido.DataBind();
                txtTotal.Text = 0.ToString();
                TR = new BL_Trabajador();
            }
        }
        protected string ObtenerUsuario()
        {
            BL_Trabajador Cl = new BL_Trabajador();
            string LogedUser = Session["usuario"].ToString();
            string ID = (Cl.BuscarIdCliente(LogedUser)).ToString();
            return ID;
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
        protected void ObtenerTotal()
        {
            int Cantidad;
            double total = 0;
            for (int i = 0; i < gvPedido.Rows.Count; i++)
            {
                GridViewRow row = gvPedido.Rows[i];
                TextBox tbC = (TextBox)gvPedido.Rows[i].FindControl("txtCantGv");
                Cantidad = int.Parse(tbC.Text);
                double xd = double.Parse(row.Cells[3].Text);
                total += xd * Cantidad;

            }
            txtTotal.Text = total.ToString();
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
        protected void gvCatalogo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCatalogo.PageIndex = e.NewPageIndex;
            CargarTabla(a);
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
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = int.Parse((sender as Button).CommandArgument);
            listaFilas.RemoveAt(index);
            gvPedido.DataSource = listaFilas;
            gvPedido.DataBind();
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            BL_OrdenPedido OD = new BL_OrdenPedido();
            int CLi = int.Parse(ObtenerUsuario());
            double Total = double.Parse(txtTotal.Text);
            if (OD.PedidoDelivery(CLi, Total))
            {
                
            }

            for (int i = 0; i < gvPedido.Rows.Count; i++)
            {
                GridViewRow row = gvPedido.Rows[i];
                int idProducto = int.Parse(row.Cells[0].Text);
                TextBox tbC = (TextBox)gvPedido.Rows[i].FindControl("txtCantGv");
                int Cantidad = int.Parse(tbC.Text);
                if (OD.DetallePedidoDelivery(idProducto, Cantidad))
                {
                }
            }
            Message("Se registro el pedido correctamente");
        }
    }
}