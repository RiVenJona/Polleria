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
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Runtime.Remoting.Contexts;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace WebPolleria
{
    public partial class RecepcionarCliente : System.Web.UI.Page
    {
        BL_OrdenReserva OR;
        BL_Trabajador TR;
        BL_Mesa ME;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ReservaActivas.Visible = false;
                TxtMozoId.Visible = false;
                BtnAsignar1.Visible = false;
                TxtApellido1.Visible = false;
                TxtNombre1.Visible = false;
                BtnBuscarRes1.Visible = false;
                RdDNI.Checked = true;
                LbNombre.Visible = false;
                LbApellidos.Visible = false;
                LbMozoId.Visible = false;
                TR = new BL_Trabajador();
                TxtRecepcionista.Text = TR.BuscarNombreTrabajador(Session["usuario"].ToString());
                TxtRecepcionista.Enabled = false;
                BtnRep.Style.Value = "background: #41403F";
                Mozo1();
                Mesa1();
            }
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
                LbMozo.Text = valor2;
                LbMozoId.Text = valor1;
                TxtMozo.Enabled = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error" + ex.ToString());
            }
        }

        protected void Mesa1()
        {
            try
            {
                ME = new BL_Mesa();
                DataTable dt = ME.BL_MesaDispoPre();
                String valor1 = "";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    valor1 = dt.Rows[i]["IdMesa"].ToString();
                }
                TxtMesa.Text = "Mesa " + valor1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error" + ex.ToString());
            }
        }

        protected void TicketAten()
        {
            // Crea un nuevo documento PDF
            PdfDocument document = new PdfDocument();
            // Crea una nueva página
            PdfPage page = document.AddPage();
            page.Width = 300;
            page.Height = 280;
            // Obtiene un objeto XGraphics que representa la página actual
            XGraphics graphics = XGraphics.FromPdfPage(page);
            // Agrega contenido al documento, como texto, imágenes, etc.
            XFont font = new XFont("Consolas", 12, XFontStyle.Regular);
            XStringFormat format = new XStringFormat();
            format.Alignment = XStringAlignment.Center;
            // Crea un objeto XImage con la imagen
            graphics.DrawString("Pollería El Buen Sabor", font, XBrushes.Black, new XRect(0, 50, page.Width, page.Height), format);
            graphics.DrawString("Ticket de Atencion", font, XBrushes.Black, new XRect(0, 100, page.Width, page.Height), format);
            DateTime fechahora = DateTime.Now;
            graphics.DrawString("Fecha emisión: " + (fechahora).ToString("yyyy-MM-dd HH:mm:ss"), font, XBrushes.Black, new XRect(20, 120, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString("----------------------------------------", font, XBrushes.Black, new XRect(20, 140, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString("Mesa: " + TxtMesa.Text, font, XBrushes.Black, new XRect(20, 160, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString("Nombre: " + TxtNombre.Text, font, XBrushes.Black, new XRect(20, 180, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString("Apellidos: " + TxtApellidos.Text, font, XBrushes.Black, new XRect(20, 200, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString("Documento de identidad: " + TxtDni.Text, font, XBrushes.Black, new XRect(20, 220, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString("Mozo: " + TxtMozo.Text, font, XBrushes.Black, new XRect(20, 240, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString("----------------------------------------", font, XBrushes.Black, new XRect(20, 260, page.Width, page.Height), XStringFormats.TopLeft);
            // Guarda el documento en un archivo
            string nombreArchivo = "Ticket_Atencion" + (fechahora).ToString("yyyyMMdd_HHmmss") + ".pdf";
            string filePath = Server.MapPath("~/Reportes/" + nombreArchivo + ".pdf");
            document.Save(filePath);
            // Descarga el archivo PDF generado
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + nombreArchivo);
            Response.TransmitFile(filePath);
            Response.End();
        }

        protected void TicketAten1()
        {
            // Crea un nuevo documento PDF
            PdfDocument document = new PdfDocument();
            // Crea una nueva página
            PdfPage page = document.AddPage();
            page.Width = 300;
            page.Height = 280;
            // Obtiene un objeto XGraphics que representa la página actual
            XGraphics graphics = XGraphics.FromPdfPage(page);
            // Agrega contenido al documento, como texto, imágenes, etc.
            XFont font = new XFont("Consolas", 12, XFontStyle.Regular);
            XStringFormat format = new XStringFormat();
            format.Alignment = XStringAlignment.Center;
            // Crea un objeto XImage con la imagen
            graphics.DrawString("Pollería El Buen Sabor", font, XBrushes.Black, new XRect(0, 50, page.Width, page.Height), format);
            graphics.DrawString("Ticket de Atencion", font, XBrushes.Black, new XRect(0, 100, page.Width, page.Height), format);
            DateTime fechahora = DateTime.Now;
            graphics.DrawString("Fecha emisión: " + (fechahora).ToString("yyyy-MM-dd HH:mm:ss"), font, XBrushes.Black, new XRect(20, 120, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString("----------------------------------------", font, XBrushes.Black, new XRect(20, 140, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString("Mesa: " + LbMesa.Text, font, XBrushes.Black, new XRect(20, 160, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString("Nombre: " + LbNombre.Text, font, XBrushes.Black, new XRect(20, 180, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString("Apellidos: " + LbApellidos.Text, font, XBrushes.Black, new XRect(20, 200, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString("Documento de identidad: " + LbIdentificacion.Text, font, XBrushes.Black, new XRect(20, 220, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString("Mozo: " + LbMozo.Text, font, XBrushes.Black, new XRect(20, 240, page.Width, page.Height), XStringFormats.TopLeft);
            graphics.DrawString("----------------------------------------", font, XBrushes.Black, new XRect(20, 260, page.Width, page.Height), XStringFormats.TopLeft);
            // Guarda el documento en un archivo
            string nombreArchivo = "Ticket_Atencion" + (fechahora).ToString("yyyyMMdd_HHmmss") + ".pdf";
            string filePath = Server.MapPath("~/Reportes/" + nombreArchivo + ".pdf");
            document.Save(filePath);
            // Descarga el archivo PDF generado
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + nombreArchivo);
            Response.TransmitFile(filePath);
            Response.End();
        }
        protected void BtnBuscarRes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtNro.Text))
            {
                Message("Ingresar el DNI del reservista");
            }
            else
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
                    Limpiar1();
                    foreach (var lis in Lista)
                    {
                        LbNombre.Text = lis.Nombre.ToString();
                        LbApellidos.Text = lis.Apellidos.ToString();
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
        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainMenu.aspx", true);
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
            if (!Regex.IsMatch(TxtDni.Text, "^[0-9]+$"))
            {
                Message("El campo DNI debe tener solo numeros");
            }
            else if (!Regex.IsMatch(TxtNombre.Text, "^[a-zA-Z]+$"))
            {
                Message("El campo Nombre debe tener carateres alfabeticos");
            }
            else
            {
                BL_Mesa ME = new BL_Mesa();
                ME = new BL_Mesa();
                DataTable dt = ME.BL_MesaDispoPre();
                int valor1 = 0;

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        valor1 = int.Parse(dt.Rows[i]["IdMesa"].ToString());
                    }

                    int Mozo = int.Parse(TxtMozoId.Text);
                    string Nombre = TxtNombre.Text;
                    string Apellidos = TxtApellidos.Text;
                    int Dni = int.Parse(TxtDni.Text);
                    if (ME.BL_AsignarMesa(valor1, Mozo, Nombre, Apellidos, Dni))
                    {
                        Message("Se asigno la mesa correctamente");
                        /* TicketAten();*/
                    }
                    Mozo1();
                    Mesa1();
                    Limpiar();
                }
                else
                {
                    Message("No hay mesa disponible");
                    Response.Redirect("MainMenu.aspx", true);
                }

            }
        }

        protected void BtnAsignar1_Click(object sender, EventArgs e)
        {

            BL_Mesa ME = new BL_Mesa();
            int Mesa = int.Parse(LbMesa.Text);
            string Nombre = LbNombre.Text;
            string Apellidos = LbApellidos.Text;
            int Mozo = int.Parse(LbMozoId.Text);
            int Dni = int.Parse(LbIdentificacion.Text);
            if (ME.BL_AsignarMesa(Mesa, Mozo, Nombre, Apellidos, Dni))
            {
                Message("Se asigno la mesa correctamente");
                /*TicketAten1();*/
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
            if (string.IsNullOrEmpty(TxtNombre1.Text) || string.IsNullOrEmpty(TxtApellido1.Text))
            {
                Message("LLenar los datos de la persona que realizo la reserva");
            }
            else if (!Regex.IsMatch(TxtNombre1.Text, "^[a-zA-Z]+$"))
            {
                Message("El campo Nombre debe tener carateres alfabeticos");
            }
            else
            {
                if (Lista1.Count != 0)
                {
                    Message("Reserva encontrada");
                    BtnRep.Visible = false;
                    Busqueda.Visible = true;
                    BtnBuscarRes1.Enabled = false;
                    TxtNro.Enabled = false;
                    Recepcion.Visible = false;
                    Limpiar1();
                    foreach (var lis in Lista1)
                    {
                        LbNombre.Text = lis.Nombre.ToString();
                        LbApellidos.Text = lis.Apellidos.ToString();
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
}
