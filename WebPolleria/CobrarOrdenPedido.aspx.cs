using BE_;
using BL_;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace WebPolleria
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        
        public DateTime date = DateTime.Today;
        private Boolean permitir = false;
        BL_CatalogoProductos CP;
        BL_OrdenPedido OP;
        BL_CDP CDP;
        BL_Trabajador TR;
        
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
                txtPago.Enabled = true;
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
            txtPago.Enabled = false;
            GvDetalle.DataBind();
            GvDetalleDelivery.DataBind();
            txtNroOrden.Text = "";
            txtMonto.Text = "";
            txtDNI.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
        }

        protected void CalculoEfectivo()
        {
            double pago = double.Parse(txtPago.Text);
            double monto = double.Parse(txtMonto.Text);
            if (pago < monto)
            {
                Message("El pago es menor al monto a pagar");
            }
            else
            {
                permitir = true;
                double opGrav;
                double igv;
                double vuelto;

                igv = monto * 0.18;
                opGrav = monto - igv;
                txtOpGrav.Text = opGrav.ToString("00.00");
                txtIGV.Text = igv.ToString("00.00");
                txtImporte.Text = monto.ToString("00.00");
                vuelto = pago - monto;
                txtVuelto.Text = vuelto.ToString("00.00");
            }
        }
        protected void btnVer_Click(object sender, EventArgs e)
        {
            CalculoEfectivo();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void btnEmitir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDNI.Text) || string.IsNullOrEmpty(txtPago.Text))
            {
                Message("Debes completar el formulario para poder emitir el comprobante");
            }
            else 
            {
                CalculoEfectivo();
                if (permitir == true)
                {
                    TR = new BL_Trabajador();
                    string trabajador = TR.BuscarNombreTrabajador(Session["usuario"].ToString());

                    //OP = new BL_OrdenPedido();
                    //OP.OPPagado(txtBuscar.Text);
                    //Message("COMPROBANTE DE PAGO EMITIDO");
                    //CargarTabla();


                    // Crea un nuevo documento PDF
                    PdfDocument document = new PdfDocument();
                    // Crea una nueva página
                    PdfPage page = document.AddPage();
                    page.Width = 302;
                    // Obtiene un objeto XGraphics que representa la página actual
                    XGraphics graphics = XGraphics.FromPdfPage(page);
                    // Agrega contenido al documento, como texto, imágenes, etc.
                    XFont font = new XFont("Consolas", 12, XFontStyle.Regular);
                    XStringFormat format = new XStringFormat();
                    format.Alignment = XStringAlignment.Center;
                    string logo = Server.MapPath("~/Imagenes/Logo.jpg");

                    // Crea un objeto XImage con la imagen
                    XImage image = XImage.FromFile(logo);
                    graphics.DrawImage(image, 101, 10, 100, 100);
                    graphics.DrawString("Pollería El Buen Sabor", font, XBrushes.Black, new XRect(0, 100, page.Width, page.Height), format);
                    graphics.DrawString("Jr. Lima 536", font, XBrushes.Black, new XRect(0, 115, page.Width, page.Height), format);
                    graphics.DrawString("Tarma-Tarma-Junín", font, XBrushes.Black, new XRect(0, 130, page.Width, page.Height), format);
                    graphics.DrawString(RblCDP.SelectedItem.Text + " de venta", font, XBrushes.Black, new XRect(0, 145, page.Width, page.Height), format);
                    graphics.DrawString("No. " + txtNroCDP.Text, font, XBrushes.Black, new XRect(0, 160, page.Width, page.Height), format);
                    DateTime fechahora = DateTime.Now;
                    graphics.DrawString("Fecha emisión: " + (fechahora).ToString("yyyy-MM-dd HH:mm:ss"), font, XBrushes.Black, new XRect(20, 190, page.Width, page.Height), XStringFormats.TopLeft);
                    graphics.DrawString("----------------------------------------", font, XBrushes.Black, new XRect(20, 205, page.Width, page.Height), XStringFormats.TopLeft);
                    graphics.DrawString("DESCRIPCION        CANT   P.UNIT  SUBTOTAL", font, XBrushes.Black, new XRect(20, 220, page.Width, page.Height), XStringFormats.TopLeft);
                    graphics.DrawString("----------------------------------------", font, XBrushes.Black, new XRect(20, 235, page.Width, page.Height), XStringFormats.TopLeft);
                    int altura = 235;
                    for (int i = 0; i < GvDetalle.Rows.Count; i++)
                    {
                        GridViewRow row = GvDetalle.Rows[i];
                        string descripcion = row.Cells[0].Text;
                        string cantidad = row.Cells[1].Text;
                        string precio = row.Cells[2].Text;
                        string total = row.Cells[3].Text;
                        graphics.DrawString(descripcion, font, XBrushes.Black, new XRect(20, altura += 15, page.Width, page.Height), XStringFormats.TopLeft);
                        graphics.DrawString("                    " + cantidad + "     " + precio + "      " + total, font, XBrushes.Black, new XRect(20, altura += 15, page.Width, page.Height), XStringFormats.TopLeft);

                    }
                    graphics.DrawString("----------------------------------------", font, XBrushes.Black, new XRect(20, altura += 15, page.Width, page.Height), XStringFormats.TopLeft);
                    graphics.DrawString("Pago        : S/   " + (int.Parse((txtPago.Text))).ToString("00.00"), font, XBrushes.Black, new XRect(20, altura += 20, page.Width, page.Height), XStringFormats.TopLeft);
                    graphics.DrawString("Op. Gravada : S/   " + txtOpGrav.Text, font, XBrushes.Black, new XRect(20, altura += 20, page.Width, page.Height), XStringFormats.TopLeft);
                    graphics.DrawString("IGV         : S/   " + txtIGV.Text, font, XBrushes.Black, new XRect(20, altura += 20, page.Width, page.Height), XStringFormats.TopLeft);
                    graphics.DrawString("Importe     : S/   " + txtImporte.Text, font, XBrushes.Black, new XRect(20, altura += 20, page.Width, page.Height), XStringFormats.TopLeft);
                    graphics.DrawString("Vuelto      : S/   " + txtVuelto.Text, font, XBrushes.Black, new XRect(20, altura += 20, page.Width, page.Height), XStringFormats.TopLeft);
                    graphics.DrawString("Tipo pago: " + RblMetodoPago.SelectedItem.Text, font, XBrushes.Black, new XRect(20, altura += 40, page.Width, page.Height), XStringFormats.TopLeft);
                    graphics.DrawString("Cliente  : " + txtNombres.Text + " " + txtApellidos.Text, font, XBrushes.Black, new XRect(20, altura += 20, page.Width, page.Height), XStringFormats.TopLeft);
                    graphics.DrawString("DNI/RUC  : " + txtDNI.Text, font, XBrushes.Black, new XRect(20, altura += 20, page.Width, page.Height), XStringFormats.TopLeft);
                    graphics.DrawString("Cajero   : " + trabajador, font, XBrushes.Black, new XRect(20, altura += 20, page.Width, page.Height), XStringFormats.TopLeft);
                    graphics.DrawString("¡GRACIAS POR LA COMPRA!", font, XBrushes.Black, new XRect(0, altura += 40, page.Width, page.Height), format);


                    // Guarda el documento en un archivo
                    string nombreArchivo = "CdP_" + (fechahora).ToString("yyyyMMdd_HHmmss") + ".pdf";
                    string filePath = Server.MapPath("~/Reportes/" + nombreArchivo + ".pdf");
                    document.Save(filePath);
                    // Descarga el archivo PDF generado
                    Response.ContentType = "application/pdf";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + nombreArchivo);
                    Response.TransmitFile(filePath);
                    Response.End();
                }
                else
                {
                    Message("El pago es menor al monto a pagar");
                }
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