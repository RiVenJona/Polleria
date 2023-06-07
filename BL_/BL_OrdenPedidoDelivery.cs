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
        public bool CambiarEstadoDelivery(int e, string id)
        {
            return dA_OrdenPedidoDelivery.CambiarEstadoDelivery(e, id);
        }
        public bool GenerarCDPyTSD(int a, int b)
        {
            return dA_OrdenPedidoDelivery.GenerarCDPyTSD(a, b);
        }

        public List<BE_OrdenPedidoDelivery> ListaOrdenesPedidoXDeliveryID(int a)
        {
            return dA_OrdenPedidoDelivery.ListaOrdenesPedidoXDeliveryID(a);
        } 
        public List<BE_OrdenPedidoDelivery> ListaOrdenesPedido2XDeliveryID(int a)
        {
            return dA_OrdenPedidoDelivery.ListaOrdenesPedido2XDeliveryID(a);
        } 
    }
}
