using BE_;
using BL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public DateTime date = DateTime.Today;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtFecha.Text = date.ToString("yyyy-MM-dd");
                GvDetalle.DataBind();

                LlenarListas();

            }
            if (RblMetodoPago.SelectedIndex != 0) 
            {
                pMetodoPago.Visible = false;
            }

        }

        protected void LlenarListas()
        {
            LlenarListaCDP();
            LlenarListaMetodoPago();
            LlenarListaMesFC();
            LlenarListaAnoFC();
        }

        protected void LlenarListaMesFC()
        {
            int mes = date.Month;
            for (int i = mes; i <= 12; i++)
            {
                int conteo = 1;
                string paddedNumber = i.ToString("00");
                ddlMes.Items.Add(new ListItem(paddedNumber, conteo.ToString()));
            }
        }
        protected void LlenarListaAnoFC()
        {
            int ano = date.Year;
            for (int i = ano; i <= ano + 5; i++)
            {
                int conteo = 1;
                ddlAno.Items.Add(new ListItem(i.ToString(), conteo.ToString()));
            }

        }
        protected void LlenarListaCDP()
        {
            List<BE_CDP> cdp = new List<BE_CDP>();
            BL_CDP c = new BL_CDP();
            cdp = c.BL_ListaCDP();
            RblCDP.DataSource = cdp;
            RblCDP.DataTextField = "Descripcion";
            RblCDP.DataValueField = "Valor";
            RblCDP.DataBind();
            RblCDP.RepeatDirection = RepeatDirection.Horizontal;
            RblCDP.SelectedIndex = 0;
        }
        protected void LlenarListaMetodoPago()
        {
            List<BE_MetodoPago> metodoPago = new List<BE_MetodoPago>();
            BL_MetodoPago c = new BL_MetodoPago();
            metodoPago = c.BL_ListaMetodoPago();
            RblMetodoPago.DataSource = metodoPago;
            RblMetodoPago.DataTextField = "Descripcion";
            RblMetodoPago.DataValueField = "Valor";
            RblMetodoPago.DataBind();
            RblMetodoPago.RepeatDirection = RepeatDirection.Horizontal;
            RblMetodoPago.SelectedIndex = 0;
        }
        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        protected void RblMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RblMetodoPago.SelectedIndex == 0)
            {
                pMetodoPago.Visible = true;
            }
            else
            {
                pMetodoPago.Visible = false;
            }

            if (RblMetodoPago.SelectedIndex == 1)
            {
                pEfectivo.Visible = true;
            }
            else
            {
                pEfectivo.Visible = false;
            }
        }


        protected void cvNumero_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int valorMaximo = 999; // Valor máximo permitido
            int valorIngresado;

            if (int.TryParse(txtNroTarjeta.Text, out valorIngresado))
            {
                if (valorIngresado > valorMaximo)
                {
                    args.IsValid = false; // Establecer el resultado de validación en falso
                }
                else
                {
                    args.IsValid = true; // Establecer el resultado de validación en verdadero
                }
            }
            else
            {
                args.IsValid = false; // Establecer el resultado de validación en falso si el valor no es un número
            }
        }
    }
}