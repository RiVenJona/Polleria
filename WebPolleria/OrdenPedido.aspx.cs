using BE_;
using BL_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public partial class OrdenPedido : System.Web.UI.Page
    {
        BL_Insumo IN;
        List<BE_CatalogoProductos> listaPedidos = new List<BE_CatalogoProductos>();
        string a = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarTabla();
            }
            
        }
        protected void CargarTabla()
        {
            BL_CatalogoProductos caPro = new BL_CatalogoProductos();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Producto");
            dt.Columns.Add("Precio");

            gvPedido.DataSource = dt;
            gvPedido.DataBind();
            gvCatalogo.DataSource = caPro.ListaProductos(a);
            gvCatalogo.DataBind();
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
                    cantidadMaxima = int.Parse(GvrDatos.Cells[4].Text);
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
        }

        protected void GvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvCatalogo.SelectedRow;
            BE_CatalogoProductos NI = new BE_CatalogoProductos();
            NI.idProducto = int.Parse(row.Cells[0].Text);
            NI.desProducto = row.Cells[1].Text;
            NI.PrecioProducto = int.Parse(row.Cells[2].Text);

            List<BE_CatalogoProductos> listaFilas = (List<BE_CatalogoProductos>)ViewState["listaPedidos"];

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
            }
        }
    }
}