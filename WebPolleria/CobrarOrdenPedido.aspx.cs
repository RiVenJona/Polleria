using BE_;
using BL_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                GvDetalle.DataBind();
                LlenarListaCDP();
                LlenarListaMetodoPago();
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
        }
        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }
    }
}