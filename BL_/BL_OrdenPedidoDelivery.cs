using DA_;
using BE_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_
{
    public class BL_OrdenPedidoDelivery
    {
        DA_OrdenPedidoDelivery dA_OrdenPedidoDelivery;
        public BL_OrdenPedidoDelivery()
        {
            dA_OrdenPedidoDelivery = new DA_OrdenPedidoDelivery();
        }
        public bool OPDPagado(int idDelivery, double pago, double vuelto)
        {
            return dA_OrdenPedidoDelivery.OPDPagado(idDelivery, pago, vuelto);
        }

        public List<BE_OrdenPedidoDelivery> ListaOrdenesPedidoXDeliveryID()
        {
            return dA_OrdenPedidoDelivery.ListaOrdenesPedidoXDeliveryID();
        } 
    }
}
