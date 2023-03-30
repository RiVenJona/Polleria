using BL_;
using BE_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;

namespace WebPolleria
{
    public partial class AnularReserva : System.Web.UI.Page
    {
        BL_OrdenReserva or;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            or = new BL_OrdenReserva();
            string a = this.TxtNro.Text;
            CargarDatos(a);
            List<BE_OrdenReserva> Lista = new List<BE_OrdenReserva>();
            Lista = or.BL_Reserva(a);
            if (Lista != null)
            {
                foreach (var lis in Lista)
                {
                    this.TxtEstado.Text = lis.EstadoOrden;
                }
                this.TxtNro.Enabled = false;
            }
            else
            {
                Message("Registro no encontrado");
            }
        }
        protected void CargarDatos(string a)
        {
            or = new BL_OrdenReserva();
            this.GrdReserva.DataSource = or.BL_Reserva(a);
            this.GrdReserva.DataBind();
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

        protected void BtnAnular_Click(object sender, EventArgs e)
        {
            or = new BL_OrdenReserva();
            string b = this.TxtNro.Text;
            if (TxtNro.Text != String.Empty)
            {
                if (or.BL_AnulaReserva(b))
                {
                    Message("Se anulo correctamente");
                    this.TxtNro.Enabled = true;
                    this.TxtEstado.Text = "Anulado";
                }
                else
                {
                    Message("Error al anular");
                }
            }
            else
            {
                Message("Ingrese Nro de Orden");
            }
        }

        protected void TxtEstado_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GrdReserva_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}