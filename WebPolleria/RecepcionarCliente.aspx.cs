using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_;
using BE_;
using System.Text;

namespace WebPolleria
{
	public partial class RecepcionarCliente : System.Web.UI.Page
	{
        BL_OrdenReserva OR;
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!Page.IsPostBack)
            {
                TxtHoraRes.Enabled = false;
                TxtMesa.Enabled = false;
                LlenarListaMesas();
                LlenarListaHorarios();
            }
		}
        protected void Habilitar()
        {
            TxtNombre.Enabled = true;
            TxtApellido.Enabled = true;
            TxtDNI.Enabled = true;
            TxtTel.Enabled = true;
            TxtCorreoRes.Enabled = true;
        }
        protected void Deshabilitar()
        {
            TxtNombre.Enabled = false;
            TxtApellido.Enabled = false;
            TxtDNI.Enabled = false;
            TxtTel.Enabled = false;
            TxtCorreoRes.Enabled = false;
            DropDownListMesas.Enabled = false;
            DropDownListHorarios.Enabled = false;
        }
        protected void LlenarListaMesas()
        {      
                List<BE_Mesa> mesas = new List<BE_Mesa>();
                BL_Mesa m = new BL_Mesa();
                mesas = m.BL_ListaMesas();
                DropDownListMesas.DataSource = mesas;
                DropDownListMesas.DataTextField = "IdMesa";
                DropDownListMesas.DataValueField = "IdMesa";
                DropDownListMesas.DataBind();
                DropDownListMesas.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Seleccione una Mesa]", "0"));
                
        }
        protected void LlenarListaHorarios()
        {
            List<BE_Horario> horarios= new List<BE_Horario>();
            BL_Horario h = new BL_Horario();
            horarios = h.BL_ListaHorarios();
            DropDownListHorarios.DataSource = horarios;
            DropDownListHorarios.DataTextField = "DescHorario";
            DropDownListHorarios.DataValueField = "IdHorario";
            DropDownListHorarios.DataBind();
            DropDownListHorarios.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Seleccione un horario]", "0"));

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

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = DropDownListHorarios.SelectedValue;
            TxtMesa.Text = a;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = DropDownListMesas.SelectedValue;
            TxtMesa.Text = a;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void BtnBuscarRes_Click(object sender, EventArgs e)
        {
            OR = new BL_OrdenReserva();
            string a = this.TxtNro.Text;
            List<BE_OrdenReserva> Lista = new List<BE_OrdenReserva>();
            Lista = OR.BL_Reserva(a);
            if (Lista != null)
            {
                foreach (var lis in Lista)
                {
                    TxtNombre.Text = lis.Nombre;
                    TxtApellido.Text = lis.Apellidos;
                    TxtDNI.Text = lis.DNI.ToString();
                    TxtHoraRes.Text = lis.DescHorario; 
                    TxtTel.Text = lis.Telefono.ToString();
                    TxtCorreoRes.Text = lis.Correo;
                    TxtMesa.Text = lis.IdMesa.ToString();
                }
            Deshabilitar();
            }
        else
           {
           Message("persona no encontrada, puede proceder a registrarla");
           Habilitar();
           }
        }
    }
}