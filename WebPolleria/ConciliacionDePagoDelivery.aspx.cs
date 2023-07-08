    using BL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public partial class ConciliacionDePagoDelivery : System.Web.UI.Page
    {
        BL_Conciliacion bl_Conciliacion = null;
        BL_Trabajador bl_Trabajador = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            LlenarTabla1();
            bl_Trabajador=new BL_Trabajador();
            Nombre.Value= bl_Trabajador.BuscarNombreTrabajador(Session["usuario"].ToString());
        }

        protected void LlenarTabla1()
        {
            bl_Conciliacion = new BL_Conciliacion();
            gvRepatidores.DataSource = bl_Conciliacion.OrdenesXRepartidores();
            gvRepatidores.DataBind();
        }
        protected void LlenarTabla2(string a)
        {
            bl_Conciliacion = new BL_Conciliacion();
            gvDetalle.DataSource = bl_Conciliacion.DetallesXOrdendes(a);
            gvDetalle.DataBind();
        }
        protected void gvRepatidores_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedRow = gvRepatidores.SelectedRow;
            string codigo = selectedRow.Cells[0].Text;
            LlenarTabla2(codigo);
            monto.Value= ""+RecaudacionTotal();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            bl_Conciliacion = new BL_Conciliacion();
            GridViewRow selectedRow = gvRepatidores.SelectedRow;
            string codigo = selectedRow.Cells[0].Text;
            if (bl_Conciliacion.LiquidarOrden(codigo))
            {
                Message("Consolidacion Realizada al pedido seleccionado");
                LlenarTabla1();
                gvDetalle.DataSource = null;
                gvDetalle.DataBind();
                gvRepatidores.SelectedIndex = -1;
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
        protected double RecaudacionTotal()
        {
            double totRecaudacion = 0;
            for (int i = 0; i < gvDetalle.Rows.Count; i++)
            {
                GridViewRow row = gvDetalle.Rows[i];
                totRecaudacion = totRecaudacion + double.Parse(row.Cells[3].Text);
            }
            return totRecaudacion;
        }
    }
}