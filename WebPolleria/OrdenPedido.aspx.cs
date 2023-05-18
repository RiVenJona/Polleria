using BE_;
using BL_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public class Datos
    {
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public int cantidad { get; set; }
    }
    public partial class OrdenPedido : System.Web.UI.Page
    {
        BL_CatalogoProductos IN;
        List<BE_CatalogoProductos> listaFilas = new List<BE_CatalogoProductos>();
        BL_Trabajador TR;
        string a = "";
        protected void Page_Load(object sender, EventArgs e)
        {

                // Lista de datos
                var listaDatos = new List<Datos>
                {
                    new Datos { Titulo = "Dato 1", Contenido = "Contenido del dato 1",cantidad=2 },
                    new Datos { Titulo = "Dato 2", Contenido = "Contenido del dato 2",cantidad=3 },
                    new Datos { Titulo = "Producto 3", Contenido = "Contenido del dato 3",cantidad=5 }
                };

                GenerarAcordeon(listaDatos);
            if (!Page.IsPostBack)
            {
                CargarTabla(a);
                if (ViewState["listaFilas"] == null)
                {
                    ViewState["listaFilas"] = new List<BE_CatalogoProductos>();
                }
                gvPedido.DataSource = (List<BE_CatalogoProductos>)ViewState["listaFilas"];
                gvPedido.DataBind();
                txtTotal.Value = "" + 0;
                TR = new BL_Trabajador();
                nombreMozo.Value = TR.BuscarNombreTrabajador(Session["usuario"].ToString());
                MesasOcupadas();
            }
            
            
        }

        public void GenerarAcordeon(List<Datos> listaDatos)
        {
            foreach (var dato in listaDatos)
            {
                var button = new Button
                {
                    CssClass = "accordion",
                    Text = dato.Titulo
                };

                var panel = new Panel
                {
                    CssClass = "panel"
                };
                panel.Controls.Add(new LiteralControl("<p>" + dato.Contenido + "</p>"));
                panel.Controls.Add(new LiteralControl("<p>" + dato.cantidad + "</p>"));

                phAcordeon.Controls.Add(button);
                phAcordeon.Controls.Add(panel);
            }
        }

        protected void MesasOcupadas()
        {
            BL_CatalogoProductos caPro = new BL_CatalogoProductos();
            DropDownList1.DataSource = caPro.listaMesas();
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
            txtTotal.Value = total.ToString();
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
            if (int.Parse(DropDownList1.SelectedItem.Text) == 4)
            {
                nombreCliente.Value = "Juan Gonzales Vargas";
            }
            else if (int.Parse(DropDownList1.SelectedItem.Text) == 5)
            {
                nombreCliente.Value = "Santiago Dulce Marton";
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
        protected void Button3_Click(object sender, EventArgs e)
        {
            Message("Se genero correctamente");
        }
    }
}