using BE_;
using BL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        
        public DateTime date = DateTime.Today;
        BL_CatalogoProductos CP;
        BL_OrdenPedido OP;
        BL_CDP CDP;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiViewTabs.ActiveViewIndex = 0;
            if (!Page.IsPostBack)
            {
                CDP = new BL_CDP();
                BtnTab1.CssClass = MultiViewTabs.ActiveViewIndex == 0 ? "tab-button active" : "tab-button";
                BtnTab2.CssClass = MultiViewTabs.ActiveViewIndex == 1 ? "tab-button active" : "tab-button";
                CargarTabla();
                txtFecha.Text = date.ToString("yyyy-MM-dd");
                Limpiar();
                GvEstadoPedido.DataBind();
                h3delivery.Visible = false;
                LlenarListas();
                txtNroCDP.Text = CDP.SiguienteIdOrdenPedido();
                
            }
            if (RblMetodoPago.SelectedIndex != 0) 
            {
                pMetodoPago.Visible = false;
            }
            if (RblTipoServ.SelectedIndex == 1)
            {
                h3delivery.Visible = true;
                h3pedido.Visible = false;
                txtTipoServ.Text = "DELIVERY";
                txtDireccion.Visible = true;
                Label21.Visible = true;
                GvDetalleDelivery.Visible = true;
                GvDetalle.Visible = false;
            } else
            {
                h3delivery.Visible = false;
                h3pedido.Visible = true;
                txtTipoServ.Text = "PRESENCIAL";
                txtDireccion.Visible = false;
                Label21.Visible = false;
                GvDetalleDelivery.Visible = false;
                GvDetalle.Visible = true;
            }

        }

        protected void CargarTabla()
        {
            OP = new BL_OrdenPedido();
            GvEstadoPedido.DataSource = OP.ListaOrdenesPedido();
            GvEstadoPedido.DataBind();
            GvEstadoPedido.Width = Unit.Percentage(100);
            Panel7.Style["overflow-x"] = "auto";
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
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CP = new BL_CatalogoProductos();
            OP = new BL_OrdenPedido();
            CDP = new BL_CDP();
            GvDetalle.DataSource = CP.DetalleOrdenPedido(txtBuscar.Text);
            GvDetalle.DataBind();
            GvDetalle.Width = Unit.Percentage(100);
            Panel5.Style["overflow-x"] = "auto";
            bool tieneFilas = GvDetalle.Rows.Count > 0;
            if (tieneFilas)
            {
                string contenido = txtBuscar.Text;
                txtNroOrden.Text = contenido;
                string texto = txtBuscar.Text;
                texto = texto.Replace("OP", "").TrimStart('0');
                txtMonto.Text = (OP.TotalOP(int.Parse(texto))).ToString();

                BE_Persona p = CDP.ClienteCDP(txtBuscar.Text);

                txtDNI.Text = (p.DNI).ToString();
                txtNombres.Text = p.Nombre;
                txtApellidos.Text = p.Apellidos;
            }
            else
            {
                Limpiar();
            }


        }

        protected void Limpiar()
        {
            GvDetalle.DataBind();
            GvDetalleDelivery.DataBind();
            txtNroOrden.Text = "";
            txtMonto.Text = "";
            txtDNI.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
        }
        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            OP = new BL_OrdenPedido();
            OP.OPPagado(txtBuscar.Text);
            Message("COMPROBANTE DE PAGO EMITIDO");
            CargarTabla();
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

        protected void BtnTab_Click(object sender, EventArgs e)
        {
            // Obtener el botón de pestaña que se hizo clic
            LinkButton clickedButton = (LinkButton)sender;

            // Desactivar todos los botones de pestaña
            BtnTab1.CssClass = "tab-button";
            BtnTab2.CssClass = "tab-button";

            // Activar el botón de pestaña clicado
            clickedButton.CssClass = "tab-button active";

            // Obtener el índice de la vista asociada al botón de pestaña clicado
            int viewIndex = int.Parse(clickedButton.CommandArgument);

            // Mostrar la vista correspondiente en el MultiView
            MultiViewTabs.ActiveViewIndex = viewIndex;
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


        protected void RblTipoServ_SelectedIndexChanged(object sender, EventArgs e)
        {
            Limpiar();
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