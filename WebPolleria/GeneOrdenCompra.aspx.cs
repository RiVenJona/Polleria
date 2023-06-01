using BE_;
using BL_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace WebPolleria
{
    public partial class GeneOrdenCompra : System.Web.UI.Page
    {
        BL_Insumo IN;
        BL_Trabajador TR;
        List<BE_Insumo> listaFilas = new List<BE_Insumo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Llenar_Insumos();
            if (!Page.IsPostBack)
            {
                TR = new BL_Trabajador();
                TxtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                TxtEAlmacen.Text = TR.BuscarNombreTrabajador(Session["usuario"].ToString());
                TxtEAlmacen.Enabled = false;

                if (ViewState["listaFilas"] == null)
                {
                    ViewState["listaFilas"] = new List<BE_Insumo>();
                }
                GvOrden.DataSource = (List<BE_Insumo>)ViewState["listaFilas"];
                GvOrden.DataBind();
            }
            else
            {
                listaFilas = (List<BE_Insumo>)ViewState["listaFilas"];
            }

        }
        protected void Llenar_Insumos()
        {
            List<BE_Insumo> Insumos = new List<BE_Insumo>();
            BL_OrdenCompra m = new BL_OrdenCompra();
            Insumos = m.ListaInsumos();
            DpInsumos.DataSource = Insumos;
            DpInsumos.DataTextField = "DesIns";
            DpInsumos.DataValueField = "DesIns";
            DpInsumos.DataBind();
            DpInsumos.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Seleccione un Insumo]", "0"));
        }
        protected void Llenar_Insumos_NoMin()
        {
            List<BE_Insumo> Insumos = new List<BE_Insumo>();
            BL_OrdenCompra m = new BL_OrdenCompra();
            Insumos = m.ListaInsumosNoMin();
            DpInsumos.DataSource = Insumos;
            DpInsumos.DataTextField = "DesIns";
            DpInsumos.DataValueField = "DesIns";
            DpInsumos.DataBind();
            DpInsumos.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Seleccione un Insumo]", "0"));
        }
        protected void CargarTabla()
        {
            IN = new BL_Insumo();
            GvOrden.DataSource = IN.InsumosCatMin();
            GvOrden.DataBind();
        }
        protected void btnIncrementar_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow GvrOrden = (GridViewRow)button.Parent.Parent;
            TextBox textBox = (TextBox)GvrOrden.FindControl("txtCantGv");
            string numInsumo = GvrOrden.Cells[0].Text;
            int value = 0;
            if (int.TryParse(textBox.Text, out value))
            {
                value++;
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

        protected void BtnPlanificacion_Click(object sender, EventArgs e)
        {
            CargarTabla();
            Llenar_Insumos_NoMin();
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx", true);
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = int.Parse((sender as Button).CommandArgument);
            listaFilas.RemoveAt(index);
            GvOrden.DataSource = listaFilas;
            GvOrden.DataBind();
        }
        protected string ObtenerUsuario()
        {
            string LogedUser = Session["usuario"].ToString();
            return LogedUser;
        }
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            BL_OrdenCompra OC = new BL_OrdenCompra();
            BL_Trabajador TR = new BL_Trabajador();
            BL_Insumo IN = new BL_Insumo();
            int Trabajador = TR.BuscarIdTrabajador(ObtenerUsuario()); ;
            if (OC.OrdenCompra(Trabajador))
            {

            }

            for (int i = 0; i < GvOrden.Rows.Count; i++)
            {
                GridViewRow row = GvOrden.Rows[i];
                int idProducto = IN.BuscarIdInsumoxNumInsumo(row.Cells[0].Text);
                TextBox tbC = (TextBox)GvOrden.Rows[i].FindControl("txtCantGv");
                int Cantidad = int.Parse(tbC.Text);
                if (OC.DetalleOrdenCompra(idProducto, Cantidad))
                {
                }
            }
            Message("Se genero la orden de compra correctamente");
        }

        protected void BtnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                BL_OrdenCompra OC = new BL_OrdenCompra();
                string descripcionInsumo = DpInsumos.Text;
                DataTable data = OC.AñadirInsumo(descripcionInsumo);
                GvOrden.DataSource = data;
                GvOrden.DataBind();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones - muestra o registra el mensaje de error
                Console.WriteLine("Error al cargar los datos en el GridView: " + ex.Message);
            }

        }
    }
}