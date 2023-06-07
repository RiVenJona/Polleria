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
        protected void Llenar_Productos()
        {
            List<BE_CatalogoProductos> productos = new List<BE_CatalogoProductos>();
            BL_Insumo m = new BL_Insumo();
            productos = m.ListaProdCata();
            DpInsumos.DataSource = productos;
            DpInsumos.DataTextField = "desProducto";
            DpInsumos.DataValueField = "idProducto";
            DpInsumos.DataBind();
            DpInsumos.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Seleccione un Insumo]", "0"));
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
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx", true);
        }
        protected void EliminarFila(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse((sender as Button).CommandArgument);
            GvOrden.DeleteRow(index);
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
            if (OC.SolicitudInsumo(Trabajador))
            {

            }

            for (int i = 0; i < GvOrden.Rows.Count; i++)
            {
                GridViewRow row = GvOrden.Rows[i];
                int idProducto = IN.BuscarIdInsumoxNumInsumo(row.Cells[0].Text);
                int Cantidad = int.Parse(row.Cells[4].Text) - int.Parse(row.Cells[3].Text);

                if (OC.DetalleSolicitudInsumo(idProducto, Cantidad))
                {
                }
            }
            Message("Se genero la solicitud de insumos correctamente");
        }

        protected void BtnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                BL_OrdenCompra OC = new BL_OrdenCompra();
                int IdProducto = int.Parse(DpInsumos.SelectedValue);
                if (IdProducto == 0)
                {
                    Message("No se selecciono producto");
                }
                else
                {
                    GvOrden.DataSource = OC.AñadirInsumo(IdProducto);
                    GvOrden.DataBind();
                }
            }
            catch (Exception ex)
            {
                Message("Error al cargar los datos en el GridView: " + ex);
            }

        }

        protected void GvOrden_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}