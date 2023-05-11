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
        BL_Trabajador TR;
        BL_Mesa ME;
        protected void Page_Load(object sender, EventArgs e)
        {
            HR = new BL_Horario();
            if (!Page.IsPostBack)
            {
                ReservaActivas.Visible = false;
                TxtMozoId.Visible = false;
                BtnAsignar1.Visible = false;
                TxtApellido1.Visible = false;
                TxtNombre1.Visible = false;
                BtnBuscarRes1.Visible = false;
                RdDNI.Checked = true;
                TR = new BL_Trabajador();
                TxtRecepcionista.Text = TR.BuscarNombreTrabajador(Session["usuario"].ToString());
                TxtRecepcionista.Enabled = false;
                BtnRep.Style.Value = "background: #41403F";
                LlenarListaMesas();
                Mozo1();

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

        protected void Limpiar()
        {
            TxtNombre.Text = string.Empty;
            TxtApellidos.Text = string.Empty;
            TxtDni.Text = string.Empty;
        }

        protected void Limpiar1()
        {
            RdDNI.Enabled = false;
            RdNombre.Enabled = false;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            BL_Mesa m = new BL_Mesa();
            DropDownListMesas.DataSource = m.MesasDisponiblesPre();
            DropDownListMesas.DataBind();
        }
        protected void Mozo1()
        {
            try
            {
                ME = new BL_Mesa();
                DataTable dt = ME.BL_Mozo();

                String valor1 = "";
                String valor2 = "";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    valor1 = dt.Rows[i]["TraId"].ToString();
                    valor2 = dt.Rows[i]["Nombre"].ToString();
                }

                TxtMozo.Text = valor2;
                TxtMozoId.Text = valor1;
                TxtMozo.Enabled = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error" + ex.ToString());
            }
        }

        protected void BtnBuscarRes_Click(object sender, EventArgs e)
        {
            try
            {
                OR = new BL_OrdenReserva();
                int a = int.Parse(this.TxtNro.Text);
                List<BE_OrdenReserva> Lista = new List<BE_OrdenReserva>();
                Lista = OR.BL_ReservaActiva(a);
                if (Lista.Count != 0)
                {
                    Message("Reserva encontrada");
                    BtnRep.Visible = false;
                    Busqueda.Visible = true;
                    BtnBuscarRes.Enabled = false;
                    TxtNro.Enabled = false;
                    Recepcion.Visible = false;
                    BtnDisponibilidad.Visible = false;
                    Limpiar1();
                    foreach (var lis in Lista)
                    {
                        LbCalendario.Text = lis.FechaProgra.ToString();
                        LbHorario.Text = lis.DescHorario;
                        LbMesa.Text = lis.IdMesa.ToString();
                        LbIdentificacion.Text = lis.DNI.ToString();
                    }
                }
                else
                {
                    Message("Reserva no encontrada");
                    this.Reserva.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Message("Falta ingresar DNI");
            }
        }
        protected void BtnSalir_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            BtnRep.Style.Value = "background: #41403F";
            BtnReser.Style.Value = "background: #F0F0F0";
            BtnAsignar.Visible = true;
            BtnAsignar1.Visible = false;
            Recepcion.Visible = true;
            RecepcionCliente.Visible = true;
            ReservaActivas.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            BtnReser.Style.Value = "background: #41403F";
            BtnRep.Style.Value = "background: #F0F0F0";
            BtnAsignar.Visible = false;
            BtnAsignar1.Visible = true;
            ReservaActivas.Visible = true;
            RecepcionCliente.Visible = false;
        }

        protected void BtnAsignar_Click(object sender, EventArgs e)
        {
            BL_Mesa ME = new BL_Mesa();
            int Mesa = int.Parse(DropDownListMesas.SelectedValue);
            int Mozo = int.Parse(TxtMozoId.Text);
            if (ME.BL_AsignarMesa(Mesa, Mozo))
            {
                Message("Se asigno la mesa correctamente");
                DropDownListMesas.Items.Clear();
                Mozo1();
                Limpiar();
            }
        }

        protected void BtnAsignar1_Click(object sender, EventArgs e)
        {
            BL_Mesa ME = new BL_Mesa();
            int Mesa = int.Parse(LbMesa.Text);
            if (ME.BL_AsignarMesa1(Mesa))
            {
                Message("Se asigno la mesa correctamente");
            }
        }

        protected void RdDNI_CheckedChanged(object sender, EventArgs e)
        {
            BtnBuscarRes.Visible = true;
            BtnBuscarRes1.Visible = false;
            RdNombre.Checked = false;
            TxtNro.Visible = true;
            TxtNombre1.Visible = false;
            TxtApellido1.Visible = false;
        }

        protected void RdNombre_CheckedChanged(object sender, EventArgs e)
        {
            BtnBuscarRes.Visible = false;
            BtnBuscarRes1.Visible = true;
            RdDNI.Checked = false;
            TxtNro.Visible = false;
            TxtNombre1.Visible = true;
            TxtApellido1.Visible = true;
        }


        protected void BtnBuscarRes12_Click(object sender, EventArgs e)
        {
            OR = new BL_OrdenReserva();
            string b = TxtNombre1.Text;
            string c = TxtApellido1.Text;
            List<BE_OrdenReserva> Lista1 = new List<BE_OrdenReserva>();
            Lista1 = OR.BL_ReservaActiva1(b, c);
            if (Lista1.Count != 0)
            {
                Message("Reserva encontrada");
                BtnRep.Visible = false;
                Busqueda.Visible = true;
                BtnBuscarRes1.Enabled = false;
                TxtNro.Enabled = false;
                Recepcion.Visible = false;
                BtnDisponibilidad.Visible = false;
                Limpiar1();
                foreach (var lis in Lista1)
                {
                    LbCalendario.Text = lis.FechaProgra.ToString();
                    LbHorario.Text = lis.DescHorario;
                    LbMesa.Text = lis.IdMesa.ToString();
                    LbIdentificacion.Text = lis.DNI.ToString();
                }
            }
            else
            {
                Message("Reserva no encontrada");
                this.Reserva.Visible = false;
            }
        }
    }
}
