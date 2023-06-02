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
            GvSalida.Width = Unit.Percentage(100);
            Panel1.Style["overflow-x"] = "auto";

            

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
            OI.RegistrarOrdenSalida(IdTrabajador);

            for (int i = 0; i < GvSalida.Rows.Count; i++)
            {
                GridViewRow rowSalida = GvSalida.Rows[i];
                int IdInsumo = IN.BuscarIdInsumoxNumInsumo(rowSalida.Cells[0].Text);

                if (OI.RegistrarOrdenSalidaDet(IdInsumo, int.Parse(rowSalida.Cells[3].Text)))
                {

                    Message("SE GENERÓ LA ORDEN DE SALIDA");
                }
            }
        }
        protected void btnSolicitar_Click(object sender, EventArgs e)
        {
        }
    }
    

}