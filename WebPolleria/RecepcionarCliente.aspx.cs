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
        BL_Horario HR;
        protected void Page_Load(object sender, EventArgs e)
        {
            HR = new BL_Horario();
            TxtHorario.Text = HR.BL_HoraReal();
            Busqueda.Visible = false;
            DetRecepcion.Visible = false;
            if (!Page.IsPostBack)
            {
                TxtHoraRes.Enabled = false;
                TxtMesa.Enabled = false;
                DetalleReserva.Visible = false;
                LlenarListaMesas();
            }
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
            int a = int.Parse(this.TxtNro.Text);
            List<BE_OrdenReserva> Lista = new List<BE_OrdenReserva>();
            Lista = OR.BL_ReservaActiva(a);
            if (Lista.Count != 0)
            {
                Message("Reserva encontrada");
                this.DetalleReserva.Visible = true;
                Button1.Visible = false;
                Busqueda.Visible = true;
                BtnBuscarRes.Enabled = false;
                TxtCalendario.Enabled = false;
                TxtDni.Enabled = false;
                TxtDni.Visible = true;
                TxtNro.Enabled = false;
                Recepcion.Visible = false;
                BtnDisponibilidad.Visible = false;
                foreach (var lis in Lista)
                {
                    TxtCalendario.Text = lis.FechaProgra.ToString();
                    TxtHoraRes.Text = lis.DescHorario;
                    TxtMesa.Text = "Mesa " + lis.IdMesa.ToString();
                    TxtDni.Text = lis.DNI.ToString();
                }
            }
            else
            {
                Message("Reserva no encontrada");
                this.Reserva.Visible = false;
                TxtHorario.Enabled = false;
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Reserva.Style.Value = "background: #B6F3F3";
            Recepcion.Style.Value = "background: #FFFFFF";
            Busqueda.Visible = true;
            DetRecepcion.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Recepcion.Style.Value = "background: #B6F3F3";
            Reserva.Style.Value = "background: #FFFFFF";
            DetRecepcion.Visible = true;
            Busqueda.Visible = false;
        }

        protected void BtnSalir_Click(object sender, EventArgs e)
        {

        }
    }
}