using BL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public partial class GenOrdenSalida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Cargar();
            }
        }
        protected void Cargar()
        {
            BL_OrdenInsumo OI = new BL_OrdenInsumo();
            GvInsumo.DataSource = OI.ListaOrdenesInsumo();
            GvInsumo.DataBind();
            GvInsumo.Width = Unit.Percentage(100);
            Panel1.Style["overflow-x"] = "auto";
        }

        protected void GvInsumos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            BL_OrdenInsumo OI = new BL_OrdenInsumo();
            GridViewRow row = GvInsumo.SelectedRow;
            txtNroSol.Text = row.Cells[0].Text;
            GvSalida.DataSource = OI.ListaInsumoDisponible(txtNroSol.Text);
            GvSalida.DataBind();
            GvCompra.DataSource = OI.ListaInsumoNoDisponible(txtNroSol.Text);
            GvCompra.DataBind();
            GvSalida.Width = Unit.Percentage(100);
            Panel1.Style["overflow-x"] = "auto";
            GvCompra.Width = Unit.Percentage(100);
            Panel3.Style["overflow-x"] = "auto";
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
        protected string ObtenerUsuario()
        {
            string LogedUser = Session["usuario"].ToString();
            return LogedUser;
        }
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            BL_OrdenInsumo OI = new BL_OrdenInsumo();
            BL_Insumo IN = new BL_Insumo();
            BL_Trabajador TR = new BL_Trabajador();
            int IdTrabajador = TR.BuscarIdTrabajador(ObtenerUsuario());

            if (GvCompra.Rows.Count == 0)
            {
                OI.RegistrarOrdenSalida(IdTrabajador);

                for (int i = 0; i < GvSalida.Rows.Count; i++)
                {
                    GridViewRow rowSalida = GvSalida.Rows[i];
                    int IdInsumo = IN.BuscarIdInsumoxNumInsumo(rowSalida.Cells[0].Text);

                    if (OI.RegistrarOrdenSalidaDet(IdInsumo, int.Parse(rowSalida.Cells[3].Text)))
                    {
                        OI.CerrarSolicitudInsumo(txtNroSol.Text);
                        Message("SE GENERÓ LA ORDEN DE SALIDA");
                    }
                }
            } else
            {
                Message("FALTAN INSUMOS PARA CUMPLIR LA SOLICITUD");
            }
        }
        protected void btnSolicitar_Click(object sender, EventArgs e)
        {
            BL_SolicitudCompra SC = new BL_SolicitudCompra();
            //SC.RegistrarSolicitudCompra();
            for (int i = 0; i < GvCompra.Rows.Count; i++)
            {
                GridViewRow rowCompra = GvCompra.Rows[i];
                string contenido = Regex.Replace(rowCompra.Cells[0].Text, @"[A-Za-z]+0*", "");
                if (SC.RegistrarSolicitudCompraDet(int.Parse(contenido), int.Parse(rowCompra.Cells[3].Text)))
                {
                    Message(contenido+"SE GENERÓ LA SOLICITUD DE COMPRA");
                }
            }
        }
    }
    

}