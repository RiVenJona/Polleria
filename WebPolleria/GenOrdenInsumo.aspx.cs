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
    public partial class GenOrdenInsumo : System.Web.UI.Page
    {
        BL_Insumo IN;
        List<BE_Insumo> listaFilas = new List<BE_Insumo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IN = new BL_Insumo();
                TxtNroIns.Text = IN.NumActualOrdenInsumo();
                TxtJefe.Enabled = false;
                CargarTabla();

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
        protected void CargarTabla()
        {
            IN = new BL_Insumo();
            GvDatos.DataSource = IN.ListaInsumos();
            GvDatos.DataBind();

            DataTable dt = new DataTable();
            dt.Columns.Add("NumInsumo");
            dt.Columns.Add("DesIns");
            dt.Columns.Add("Categoria");
            dt.Columns.Add("Unidad");
            dt.Columns.Add("Cantidad");

            GvOrden.DataSource = dt;
            GvOrden.DataBind();
        }
        protected void CargarxNombre(string a)
        {
            IN = new BL_Insumo();
            GvDatos.DataSource = IN.ListaInsumosxNombre(a);
            GvDatos.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            IN = new BL_Insumo();
            string a = this.TxtInsumoDesc.Text;
            CargarxNombre(a);
            List<BE_Insumo> Lista = new List<BE_Insumo>();
            Lista = IN.ListaInsumosxNombre(a);
            if (Lista.Count != 0)
            {

            }
            else
            {
                CargarTabla();
                Message("Registro no encontrado.");
            }
        }

        protected void txtCantGv_TextChanged(object sender, EventArgs e)
        {

        }
        protected void btnIncrementar_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            GridViewRow GvrOrden = (GridViewRow)button.Parent.Parent;
            TextBox textBox = (TextBox)GvrOrden.FindControl("txtCantGv");
            string numInsumo = GvrOrden.Cells[0].Text;
            int value = 0;
            int cantidadMaxima = 0;
            foreach (GridViewRow GvrDatos in GvDatos.Rows)
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = int.Parse((sender as Button).CommandArgument);
            listaFilas.RemoveAt(index);
            GvOrden.DataSource = listaFilas;
            GvOrden.DataBind();
        }
        protected void GvOrden_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GvDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GvDatos.SelectedRow;
            BE_Insumo NI = new BE_Insumo();
            NI.NumInsumo = row.Cells[0].Text;
            NI.DesIns = row.Cells[1].Text;
            NI.Categoria = row.Cells[2].Text;
            NI.Unidad = row.Cells[3].Text;
            NI.Cantidad = int.Parse(row.Cells[4].Text);

            List<BE_Insumo> listaFilas = (List<BE_Insumo>)ViewState["listaFilas"];

            bool filaRepetida = false;
            foreach (BE_Insumo fila in listaFilas)
            {
                if (fila.NumInsumo == NI.NumInsumo)
                {
                    filaRepetida = true;
                    break;
                }
            }
            if (!filaRepetida)
            {
                listaFilas.Add(NI);
                ViewState["listaFilas"] = listaFilas;

                GvOrden.DataSource = listaFilas;
                GvOrden.DataBind();
            }
        }

    }
}