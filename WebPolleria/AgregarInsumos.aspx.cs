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
    public partial class AgregarInsumos : System.Web.UI.Page
    {
        BL_Trabajador TR;
        protected void Page_Load(object sender, EventArgs e)
        {
            TR = new BL_Trabajador();
            TxtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            TxtEAlmacen.Text = TR.BuscarNombreTrabajador(Session["usuario"].ToString());
            TxtEAlmacen.Enabled = false;
            BtnModificar.Visible = false;
        }
        protected void Llenar_Categorias()
        {
            List<BE_Insumo> Categorias = new List<BE_Insumo>();
            BL_Insumo m = new BL_Insumo();
            Categorias = m.ListaCategorias();
            DpCategoria.DataSource = Categorias;
            DpCategoria.DataTextField = "Categoria";
            DpCategoria.DataBind();
            DpCategoria.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Seleccione una Categortia]", "0"));
        }
        protected void Llenar_Unidades()
        {
            List<BE_Insumo> Categorias = new List<BE_Insumo>();
            BL_Insumo m = new BL_Insumo();
            Categorias = m.ListaUnidades();
            DpUnidad.DataSource = Categorias;
            DpUnidad.DataTextField = "Unidad";
            DpUnidad.DataValueField = "Unidad";
            DpUnidad.DataBind();
            DpUnidad.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Seleccione una Unidad]", "0"));
        }
        protected void Limpiar()
        {
            TxtCod.Text = "";
            TxtDes.Text = "";
            TxtSActual.Text = "";
            TxtSMax.Text = "";
            TxtSMin.Text = "";
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
        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            BL_Insumo IN = new BL_Insumo();
            string NumInsumo = TxtCod.Text;
            int Categ = int.Parse(DpCategoria.SelectedValue);
            string Unidad = DpUnidad.SelectedValue;
            int Cantidad = int.Parse(TxtSActual.Text);
            int Min = int.Parse(TxtSMin.Text);
            int Max = int.Parse(TxtSMax.Text);
            if (IN.ModificarInsumo(NumInsumo, Categ, Unidad, Cantidad, Min, Max))
            {
                Message("Se modifico el insumo correctamente");
                Limpiar();
            }
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            BL_Insumo IN = new BL_Insumo();
            string Des = TxtDes.Text;
            int Categ = int.Parse(DpCategoria.SelectedValue);
            string Unidad = DpUnidad.SelectedValue;
            int Cantidad = int.Parse(TxtSActual.Text);
            int Min = int.Parse(TxtSMin.Text);
            int Max = int.Parse(TxtSMax.Text);
            if (IN.RegistrarInsumo(Des, Categ, Unidad, Cantidad, Min, Max))
            {
                Message("Se registro el insumo correctamente");
                Limpiar();
            }

        }

        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx", true);
        }
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            BL_Insumo IN = new BL_Insumo();
            List<BE_Insumo> Lista = new List<BE_Insumo>();
            string a = TxtCod.Text;
            Lista = IN.BuscarInsumo(a);
            if (Lista.Count != 0)
            {
                Message("Insumo encontrado");
                BtnRegistrar.Visible = false;
                BtnModificar.Visible = true;
                foreach (var lis in Lista)
                {
                    TxtCod.Text = lis.NumInsumo;
                    TxtDes.Text = lis.DesIns;
                    DpCategoria.Text = lis.Categoria;
                    DpUnidad.Text = lis.Unidad;
                    TxtSActual.Text = lis.Cantidad.ToString();
                    TxtSMin.Text = lis.StockMin.ToString();
                    TxtSMax.Text = lis.StockMax.ToString();
                }
            }
            else
            {
                Message("Insumo no encontrado");
                Limpiar();
            }
        }

        protected void DpCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            BL_Insumo IN = new BL_Insumo();
            int Categ = int.Parse(DpCategoria.SelectedValue);
            TxtCod.Text = IN.NuevoNumeroInsumoCateg(Categ);
        }
    }
}