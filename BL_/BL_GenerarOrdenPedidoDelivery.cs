using BE_;
using DA_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_
{
    public class BL_GenerarOrdenPedidoDelivery
    {
        DA_GenerarOrdenPedidoDelivery daGOPD;

        public BL_GenerarOrdenPedidoDelivery()
        {
            daGOPD = new DA_GenerarOrdenPedidoDelivery();
        }

        public List<BE_GenerarOrdenPedidoDelivery> ListaPedidosGOPD()
        {
            return daGOPD.ListPedidoPreparados();
        }
        public List<BE_GenerarOrdenPedidoDelivery> ListaRepartidores()
        {
            return daGOPD.ListaRepartidores();
        }
        public bool RegistrarGOPD(int idRepartidor)
        {
            return daGOPD.RegistrarGOPD(idRepartidor);
        }
        public bool RegistrarDetalleGOPD(string iddelivery)
        {
            return daGOPD.RegistrarDetalleGOPD(iddelivery);
        }
        public int UltimoDelivery()
        {
            return daGOPD.UltimoDelivery();
        }
        public List<TicketDetalle> ListaTickets(string iddelivery)
        {
            return daGOPD.ListaTickets(iddelivery);
        }
    }
}
