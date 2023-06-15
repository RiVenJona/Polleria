using BE_;
using BL_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace WebPolleria
{
    public partial class GeneOrdenCompra : System.Web.UI.Page
    {
        List<BE_CatalogoProductos> listaFilas = new List<BE_CatalogoProductos>();
        protected void Page_Load(object sender, EventArgs e)
        {
            BL_OrdenInsumo OI = new BL_OrdenInsumo();
            Mensage.Visible = false;
            if (OI.ValidacionInsumo() != 0)
            {
                Mensage.Visible = true;
                Planificacion.Visible = false;
            }
            else
            {

            }

            if (!Page.IsPostBack)
            {
                BL_Trabajador TR = new BL_Trabajador();
                TxtEAlmacen.Text = TR.BuscarNombreTrabajador(Session["usuario"].ToString());
                if (ViewState["listaFilas"] == null)
                {
                    ViewState["listaFilas"] = new List<BE_CatalogoProductos>();
                }
                Grv1.DataSource = (List<BE_CatalogoProductos>)ViewState["listaFilas"];
                Grv1.DataBind();

                if (ViewState["listaFilas1"] == null)
                {
                    ViewState["listaFilas1"] = new List<BE_CatalogoProductos>();
                }
                Grv2.DataSource = (List<BE_CatalogoProductos>)ViewState["listaFilas1"];
                Grv2.DataBind();

                if (ViewState["listaFilas2"] == null)
                {
                    ViewState["listaFilas2"] = new List<BE_CatalogoProductos>();
                }
                Grv3.DataSource = (List<BE_CatalogoProductos>)ViewState["listaFilas2"];
                Grv3.DataBind();

                if (ViewState["listaFilas3"] == null)
                {
                    ViewState["listaFilas3"] = new List<BE_CatalogoProductos>();
                }
                Grv4.DataSource = (List<BE_CatalogoProductos>)ViewState["listaFilas3"];
                Grv4.DataBind();

                if (ViewState["listaFilas4"] == null)
                {
                    ViewState["listaFilas4"] = new List<BE_CatalogoProductos>();
                }
                Grv5.DataSource = (List<BE_CatalogoProductos>)ViewState["listaFilas4"];
                Grv5.DataBind();

                if (ViewState["listaFilas5"] == null)
                {
                    ViewState["listaFilas5"] = new List<BE_CatalogoProductos>();
                }
                Grv6.DataSource = (List<BE_CatalogoProductos>)ViewState["listaFilas5"];
                Grv6.DataBind();

                if (ViewState["listaFilas6"] == null)
                {
                    ViewState["listaFilas6"] = new List<BE_CatalogoProductos>();
                }
                Grv7.DataSource = (List<BE_CatalogoProductos>)ViewState["listaFilas6"];
                Grv7.DataBind();
            }

        }
        protected void Limpiar()
        {
            txtCantidad1.Text = string.Empty;
            TxtCantidad2.Text = string.Empty;
            TxtCantidad3.Text = string.Empty;
            TxtCantidad4.Text = string.Empty;
            TxtCantidad5.Text = string.Empty;
            TxtCantidad6.Text = string.Empty;
            TxtCantidad7.Text = string.Empty;
        }
        protected string ObtenerUsuario()
        {
            string LogedUser = Session["usuario"].ToString();
            return LogedUser;
        }
        protected void BtnTab_Click(object sender, EventArgs e)
        {
            // Obtener el botón de pestaña que se hizo clic
            LinkButton clickedButton = (LinkButton)sender;

            // Desactivar todos los botones de pestaña
            BtnTab1.CssClass = "tab-button";
            BtnTab2.CssClass = "tab-button";
            BtnTab3.CssClass = "tab-button";
            BtnTab4.CssClass = "tab-button";
            BtnTab5.CssClass = "tab-button";
            BtnTab6.CssClass = "tab-button";
            BtnTab7.CssClass = "tab-button";

            // Activar el botón de pestaña clicado
            clickedButton.CssClass = "tab-button active";

            // Obtener el índice de la vista asociada al botón de pestaña clicado
            int viewIndex = int.Parse(clickedButton.CommandArgument);

            // Mostrar la vista correspondiente en el MultiView
            MultiViewTabs.ActiveViewIndex = viewIndex;
        }

        protected void BtnAgregar1_Click(object sender, EventArgs e)
        {
            List<BE_CatalogoProductos> listaFilas = (List<BE_CatalogoProductos>)ViewState["listaFilas"];
            BE_CatalogoProductos NI = new BE_CatalogoProductos();
            NI.idProducto = int.Parse(Dp1.SelectedValue);
            NI.desProducto = Dp1.SelectedItem.Text;
            NI.cantidadProducto = int.Parse(txtCantidad1.Text);
            bool filaRepetida = false;
            foreach (BE_CatalogoProductos fila in listaFilas)
            {
                if (fila.idProducto == NI.idProducto)
                {
                    filaRepetida = true;
                    break;
                }
            }
            if (!filaRepetida)
            {
                listaFilas.Add(NI);
                ViewState["listaFilas"] = listaFilas;

                Grv1.DataSource = listaFilas;
                Grv1.DataBind();
            }
            Limpiar();
        }
        protected void BtnAgregar2_Click(object sender, EventArgs e)
        {
            List<BE_CatalogoProductos> listaFilas1 = (List<BE_CatalogoProductos>)ViewState["listaFilas1"];
            BE_CatalogoProductos NI = new BE_CatalogoProductos();
            NI.idProducto = int.Parse(Dp2.SelectedValue);
            NI.desProducto = Dp2.SelectedItem.Text;
            NI.cantidadProducto = int.Parse(TxtCantidad2.Text);
            bool filaRepetida1 = false;
            foreach (BE_CatalogoProductos fila1 in listaFilas1)
            {
                if (fila1.idProducto == NI.idProducto)
                {
                    filaRepetida1 = true;
                    break;
                }
            }
            if (!filaRepetida1)
            {
                listaFilas1.Add(NI);
                ViewState["listaFilas1"] = listaFilas1;

                Grv2.DataSource = listaFilas1;
                Grv2.DataBind();
            }
            Limpiar();
        }
        protected void BtnAgregar3_Click(object sender, EventArgs e)
        {
            List<BE_CatalogoProductos> listaFilas2 = (List<BE_CatalogoProductos>)ViewState["listaFilas2"];
            BE_CatalogoProductos NI = new BE_CatalogoProductos();
            NI.idProducto = int.Parse(Dp3.SelectedValue);
            NI.desProducto = Dp3.SelectedItem.Text;
            NI.cantidadProducto = int.Parse(TxtCantidad3.Text);
            bool filaRepetida2 = false;
            foreach (BE_CatalogoProductos fila2 in listaFilas2)
            {
                if (fila2.idProducto == NI.idProducto)
                {
                    filaRepetida2 = true;
                    break;
                }
            }
            if (!filaRepetida2)
            {
                listaFilas2.Add(NI);
                ViewState["listaFilas2"] = listaFilas2;

                Grv3.DataSource = listaFilas2;
                Grv3.DataBind();
            }
            Limpiar();
        }
        protected void BtnAgregar4_Click(object sender, EventArgs e)
        {
            List<BE_CatalogoProductos> listaFilas3 = (List<BE_CatalogoProductos>)ViewState["listaFilas3"];
            BE_CatalogoProductos NI = new BE_CatalogoProductos();
            NI.idProducto = int.Parse(Dp4.SelectedValue);
            NI.desProducto = Dp4.SelectedItem.Text;
            NI.cantidadProducto = int.Parse(TxtCantidad4.Text);
            bool filaRepetida3 = false;
            foreach (BE_CatalogoProductos fila3 in listaFilas3)
            {
                if (fila3.idProducto == NI.idProducto)
                {
                    filaRepetida3 = true;
                    break;
                }
            }
            if (!filaRepetida3)
            {
                listaFilas3.Add(NI);
                ViewState["listaFilas3"] = listaFilas3;

                Grv4.DataSource = listaFilas3;
                Grv4.DataBind();
            }
            Limpiar();
        }
        protected void BtnAgregar5_Click(object sender, EventArgs e)
        {
            List<BE_CatalogoProductos> listaFilas4 = (List<BE_CatalogoProductos>)ViewState["listaFilas4"];
            BE_CatalogoProductos NI = new BE_CatalogoProductos();
            NI.idProducto = int.Parse(Dp5.SelectedValue);
            NI.desProducto = Dp5.SelectedItem.Text;
            NI.cantidadProducto = int.Parse(TxtCantidad5.Text);
            bool filaRepetida4 = false;
            foreach (BE_CatalogoProductos fila4 in listaFilas4)
            {
                if (fila4.idProducto == NI.idProducto)
                {
                    filaRepetida4 = true;
                    break;
                }
            }
            if (!filaRepetida4)
            {
                listaFilas4.Add(NI);
                ViewState["listaFilas4"] = listaFilas4;

                Grv5.DataSource = listaFilas4;
                Grv5.DataBind();
            }
            Limpiar();
        }
        protected void BtnAgregar6_Click(object sender, EventArgs e)
        {
            List<BE_CatalogoProductos> listaFilas5 = (List<BE_CatalogoProductos>)ViewState["listaFilas5"];
            BE_CatalogoProductos NI = new BE_CatalogoProductos();
            NI.idProducto = int.Parse(Dp6.SelectedValue);
            NI.desProducto = Dp6.SelectedItem.Text;
            NI.cantidadProducto = int.Parse(TxtCantidad6.Text);
            bool filaRepetida5 = false;
            foreach (BE_CatalogoProductos fila5 in listaFilas5)
            {
                if (fila5.idProducto == NI.idProducto)
                {
                    filaRepetida5 = true;
                    break;
                }
            }
            if (!filaRepetida5)
            {
                listaFilas5.Add(NI);
                ViewState["listaFilas5"] = listaFilas5;

                Grv6.DataSource = listaFilas5;
                Grv6.DataBind();
            }
            Limpiar();
        }
        protected void BtnAgregar7_Click(object sender, EventArgs e)
        {
            List<BE_CatalogoProductos> listaFilas6 = (List<BE_CatalogoProductos>)ViewState["listaFilas6"];
            BE_CatalogoProductos NI = new BE_CatalogoProductos();
            NI.idProducto = int.Parse(Dp7.SelectedValue);
            NI.desProducto = Dp7.SelectedItem.Text;
            NI.cantidadProducto = int.Parse(TxtCantidad7.Text);
            bool filaRepetida6 = false;
            foreach (BE_CatalogoProductos fila6 in listaFilas6)
            {
                if (fila6.idProducto == NI.idProducto)
                {
                    filaRepetida6 = true;
                    break;
                }
            }
            if (!filaRepetida6)
            {
                listaFilas6.Add(NI);
                ViewState["listaFilas6"] = listaFilas6;

                Grv7.DataSource = listaFilas6;
                Grv7.DataBind();
            }
            Limpiar();
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
        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx", true);
        }

        protected void BtnGenerar_Click(object sender, EventArgs e)
        {
            BL_Trabajador TR = new BL_Trabajador();
            BL_OrdenInsumo OI = new BL_OrdenInsumo();
            int Trabajador = TR.BuscarIdTrabajador(ObtenerUsuario()); ;
            DateTime FechaProgramada = DateTime.Parse(TxtFecha.Text);
            if (OI.GenerarSolicitudInsumo(FechaProgramada, Trabajador))
            {

            }
            for (int i = 1; i <= 7; i++)
            {
                if (OI.GenerarSolicitudInsumoDia(i))
                {

                }
            }
            for (int i = 0; i < Grv1.Rows.Count; i++)
            {
                GridViewRow row = Grv1.Rows[i];
                int idProducto = int.Parse(row.Cells[0].Text);
                int Cantidad = int.Parse(row.Cells[2].Text);

                if (OI.GenerarSolicitudInsumoDiaDet(2, idProducto, Cantidad))
                {
                }
            }

            for (int i = 0; i < Grv2.Rows.Count; i++)
            {
                GridViewRow row1 = Grv2.Rows[i];
                int idProducto1 = int.Parse(row1.Cells[0].Text);
                int Cantidad1 = int.Parse(row1.Cells[2].Text);

                if (OI.GenerarSolicitudInsumoDiaDet(3, idProducto1, Cantidad1))
                {
                }
            }

            for (int i = 0; i < Grv3.Rows.Count; i++)
            {
                GridViewRow row2 = Grv3.Rows[i];
                int idProducto2 = int.Parse(row2.Cells[0].Text);
                int Cantidad2 = int.Parse(row2.Cells[2].Text);

                if (OI.GenerarSolicitudInsumoDiaDet(4, idProducto2, Cantidad2))
                {
                }
            }

            for (int i = 0; i < Grv4.Rows.Count; i++)
            {
                GridViewRow row3 = Grv4.Rows[i];
                int idProducto3 = int.Parse(row3.Cells[0].Text);
                int Cantidad3 = int.Parse(row3.Cells[2].Text);

                if (OI.GenerarSolicitudInsumoDiaDet(5, idProducto3, Cantidad3))
                {
                }
            }

            for (int i = 0; i < Grv5.Rows.Count; i++)
            {
                GridViewRow row4 = Grv5.Rows[i];
                int idProducto4 = int.Parse(row4.Cells[0].Text);
                int Cantidad4 = int.Parse(row4.Cells[2].Text);

                if (OI.GenerarSolicitudInsumoDiaDet(6, idProducto4, Cantidad4))
                {
                }
            }

            for (int i = 0; i < Grv6.Rows.Count; i++)
            {
                GridViewRow row5 = Grv6.Rows[i];
                int idProducto5 = int.Parse(row5.Cells[0].Text);
                int Cantidad5 = int.Parse(row5.Cells[2].Text);

                if (OI.GenerarSolicitudInsumoDiaDet(7, idProducto5, Cantidad5))
                {
                }
            }

            for (int i = 0; i < Grv7.Rows.Count; i++)
            {
                GridViewRow row6 = Grv7.Rows[i];
                int idProducto6 = int.Parse(row6.Cells[0].Text);
                int Cantidad6 = int.Parse(row6.Cells[2].Text);

                if (OI.GenerarSolicitudInsumoDiaDet(1, idProducto6, Cantidad6))
                {
                }
            }
            Message("Se genero la solicitud de insumos correctamente");
        }

        protected void BtnSalir1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MainMenu.aspx", true);
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            BL_OrdenInsumo OI = new BL_OrdenInsumo();
            if (OI.CancelarSoliInsumo())
            {

            }
            Message("Se cancelo la solicitud correctamente");
            Mensage.Visible = false;
            Planificacion.Visible = true;
        }
    }
}