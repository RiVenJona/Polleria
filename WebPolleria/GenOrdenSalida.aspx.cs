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
            BL_Insumo I = new BL_Insumo();
            txtNroSol.Text = OI.SolicitudActual();
            GvInsumo.DataSource = I.ListaSolicitudHoy();
            GvInsumo.DataBind();
            GvInsumo.Width = Unit.Percentage(100);
            Panel1.Style["overflow-x"] = "auto";
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
            
            if (GvInsumo.Rows.Count == 0)
            {
                Message("NO HAY SOLICITUD PENDIENTE");
            } else
            {
                OI.RegistrarOrdenSalida(IdTrabajador);

                for (int i = 0; i < GvInsumo.Rows.Count; i++)
                {
                    GridViewRow rowSalida = GvInsumo.Rows[i];

                    OI.RegistrarOrdenSalidaDet(int.Parse(rowSalida.Cells[0].Text), int.Parse(rowSalida.Cells[3].Text));
                    
                }
                Message("SE GENERÓ LA ORDEN DE SALIDA CON ÉXITO");

            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx");
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
    }
    

}