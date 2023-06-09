﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebPolleria
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RolUser"].ToString() != string.Empty)
            {
                this.txtRol.Value = Session["RolUser"].ToString();
                if (Session["RolUser"].ToString() == "Recepcionista")
                {
                    aDevolDel.Style.Add("display", "none");
                    aGenOrdenSalida.Style.Add("display", "none");
                    aSolicitudInsumo.Style.Add("display", "none");
                    aPreparar.Style.Add("display", "none");
                    aOrdenPedido.Style.Add("display", "none");
                    aCobrarOrden.Style.Add("display", "none");
                    aDelivery.Style.Add("display", "none");
                    aDatosInsumo.Style.Add("display", "none");
                    dOrdenDelivery.Style.Add("display", "none");
                    aGestOrdenDeli.Style.Add("display", "none");
                    aGenOrdenCompra.Style.Add("display", "none");
                    aConciliacion.Style.Add("display", "none");
                }
                else if (Session["RolUser"].ToString() == "Jefe de Cocina")
                {
                    aGenOrdenSalida.Style.Add("display", "none");
                    aPreparar.Style.Add("display", "none");
                    aRegistrar.Style.Add("display", "none");
                    aAnular.Style.Add("display", "none");
                    aRecepcion.Style.Add("display", "none");
                    aOrdenPedido.Style.Add("display", "none");
                    aDelivery.Style.Add("display", "none");
                    dOrdenDelivery.Style.Add("display", "none");
                    aCobrarOrden.Style.Add("display", "none");
                    aDatosInsumo.Style.Add("display", "none");
                    aGestOrdenDeli.Style.Add("display", "none");
                    aGenOrdenCompra.Style.Add("display", "none");
                    aConciliacion.Style.Add("display", "none");
                }
                else if (Session["RolUser"].ToString() == "Mozo")
                {
                    aDevolDel.Style.Add("display", "none");
                    aGenOrdenSalida.Style.Add("display", "none");
                    aSolicitudInsumo.Style.Add("display", "none");
                    aPreparar.Style.Add("display", "none");
                    aRegistrar.Style.Add("display", "none");
                    aAnular.Style.Add("display", "none");
                    aRecepcion.Style.Add("display", "none");
                    aCobrarOrden.Style.Add("display", "none");
                    aDelivery.Style.Add("display", "none");
                    aDatosInsumo.Style.Add("display", "none");
                    dOrdenDelivery.Style.Add("display", "none");
                    aGestOrdenDeli.Style.Add("display", "none");
                    aGenOrdenCompra.Style.Add("display", "none");
                    aConciliacion.Style.Add("display", "none");
                }
                else if (Session["RolUser"].ToString() == "Cajero")
                {
                    aDevolDel.Style.Add("display", "none");
                    aGestOrdenDeli.Style.Add("display", "none");
                    aGenOrdenSalida.Style.Add("display", "none");
                    aSolicitudInsumo.Style.Add("display", "none");
                    aPreparar.Style.Add("display", "none");
                    aRegistrar.Style.Add("display", "none");
                    aAnular.Style.Add("display", "none");
                    aRecepcion.Style.Add("display", "none");
                    aDelivery.Style.Add("display", "none");
                    aOrdenPedido.Style.Add("display", "none");
                    aDatosInsumo.Style.Add("display", "none");
                    dOrdenDelivery.Style.Add("display", "none");
                    aGenOrdenCompra.Style.Add("display", "none");
                }
                else if (Session["RolUser"].ToString() == "Chef")
                {
                    aDevolDel.Style.Add("display", "none");
                    aConciliacion.Style.Add("display", "none");
                    aGenOrdenSalida.Style.Add("display", "none");
                    aSolicitudInsumo.Style.Add("display", "none");
                    aCobrarOrden.Style.Add("display", "none");
                    aRegistrar.Style.Add("display", "none");
                    aAnular.Style.Add("display", "none");
                    aRecepcion.Style.Add("display", "none");
                    aDelivery.Style.Add("display", "none");
                    aOrdenPedido.Style.Add("display", "none");
                    aDatosInsumo.Style.Add("display", "none");
                    dOrdenDelivery.Style.Add("display", "none");
                    aGestOrdenDeli.Style.Add("display", "none");
                    aGenOrdenCompra.Style.Add("display", "none");
                }
                else if (Session["RolUser"].ToString() == "Cliente")
                {
                    aDevolDel.Style.Add("display", "none");
                    aConciliacion.Style.Add("display", "none");
                    aGenOrdenSalida.Style.Add("display", "none");
                    aSolicitudInsumo.Style.Add("display", "none");
                    aRegistrar.Style.Add("display", "none");
                    aAnular.Style.Add("display", "none");
                    aCobrarOrden.Style.Add("display", "none");
                    aRecepcion.Style.Add("display", "none");
                    aOrdenPedido.Style.Add("display", "none");
                    aPreparar.Style.Add("display", "none");
                    aDatosInsumo.Style.Add("display", "none");
                    dOrdenDelivery.Style.Add("display", "none");
                    aGestOrdenDeli.Style.Add("display", "none");
                    aGenOrdenCompra.Style.Add("display", "none");
                }
                else if (Session["RolUser"].ToString() == "Encargado de Almacen")
                {
                    aDevolDel.Style.Add("display", "none");
                    aConciliacion.Style.Add("display", "none");
                    aDelivery.Style.Add("display", "none");
                    aRegistrar.Style.Add("display", "none");
                    aAnular.Style.Add("display", "none");
                    aCobrarOrden.Style.Add("display", "none");
                    aRecepcion.Style.Add("display", "none");
                    aOrdenPedido.Style.Add("display", "none");
                    aGestOrdenDeli.Style.Add("display", "none");
                    aPreparar.Style.Add("display", "none");
                    dOrdenDelivery.Style.Add("display", "none");
                    aSolicitudInsumo.Style.Add("display", "none");
                    aGestOrdenDeli.Style.Add("display", "none");
                }
                else if (Session["RolUser"].ToString() == "Repartidor")
                {
                    aDevolDel.Style.Add("display", "none");
                    aGenOrdenSalida.Style.Add("display", "none");
                    aConciliacion.Style.Add("display", "none");
                    aDatosInsumo.Style.Add("display", "none");
                    aSolicitudInsumo.Style.Add("display", "none");
                    aPreparar.Style.Add("display", "none");
                    aDelivery.Style.Add("display", "none");
                    aRegistrar.Style.Add("display", "none");
                    aAnular.Style.Add("display", "none");
                    aCobrarOrden.Style.Add("display", "none");
                    aRecepcion.Style.Add("display", "none");
                    aOrdenPedido.Style.Add("display", "none");
                    aGenOrdenCompra.Style.Add("display", "none");
                    dOrdenDelivery.Style.Add("display", "none");
                }
                else if (Session["RolUser"].ToString() == "Encargado Delivery")
                {
                    aDevolDel.Style.Add("display", "none");
                    aGenOrdenSalida.Style.Add("display", "none");
                    aConciliacion.Style.Add("display", "none");
                    aGestOrdenDeli.Style.Add("display", "none");
                    aDatosInsumo.Style.Add("display", "none");
                    aSolicitudInsumo.Style.Add("display", "none");
                    aPreparar.Style.Add("display", "none");
                    aDelivery.Style.Add("display", "none");
                    aRegistrar.Style.Add("display", "none");
                    aAnular.Style.Add("display", "none");
                    aCobrarOrden.Style.Add("display", "none");
                    aRecepcion.Style.Add("display", "none");
                    aOrdenPedido.Style.Add("display", "none");
                    aGestOrdenDeli.Style.Add("display", "none");
                    aGenOrdenCompra.Style.Add("display", "none");
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["RolUser"] = ""; // Borra la variable de sesión "rol"
            Response.Redirect("~/Login.aspx", true);
        }
    }
}