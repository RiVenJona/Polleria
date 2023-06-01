using DA_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_;
using System.Net.Sockets;

namespace BL_
{
    public class BL_OrdenPedido
    {
        DA_OrdenPedido dA_OrdenPedido;
        public BL_OrdenPedido()
        {
            dA_OrdenPedido = new DA_OrdenPedido();
        }

        public List<TicketDetalle> ListaTicketsXOP(int id)
        {
            return dA_OrdenPedido.ListaTicketsXOP(id);
          
        }

        public List<TicketDetalle> DetalleXTicketPreparar(int ticket)
        {
            return dA_OrdenPedido.DetalleXTicketPreparar(ticket);
        }
        public List<TicketDetalle> DetalleXODPPreparar(int a)
        {
            return dA_OrdenPedido.DetalleXODPPreparar(a);
        }
        public List<TicketDetalle> DetallexTicket(int ticket)
        {
            return dA_OrdenPedido.DetalleXTicket(ticket);
        }
        public double TotalOP(int id)
        {
            return dA_OrdenPedido.TotalOP(id);
        }
        public double TotalOPD(int id)
        {
            return dA_OrdenPedido.TotalOPD(id);
        }
        public string NombreCliente(int mesa)
        {
            return dA_OrdenPedido.NombreCliente(mesa);
        }

        public List<BE_OrdenPedido> ListaOrdenesPedido()
        {
            return dA_OrdenPedido.ListaOrdenesPedido();
        }

        public List<BE_OrdenPedido> ListaTickets()
        {
            return dA_OrdenPedido.ListaTickets();
        }
        public List<BE_OrdenPedido> ListaPedidosDeliveryPreparar()
        {
            return dA_OrdenPedido.ListaPedidosDeliveryPreparar();
        }

        public int GetOrdenPedidoId(int mozo, int mesa)
        {
            return dA_OrdenPedido.GetOrdenPedidoID(mozo, mesa);
        }
        public bool InsertOP(int mozo, int mesa)
        {
            return dA_OrdenPedido.InsertOP(mozo, mesa);
        }
        public bool InsertDetallePedido(int idProducto, int cantidad, int mesa, int mozo)
        {
            return dA_OrdenPedido.InsertDetallePedido(idProducto, cantidad,mesa,mozo);
        }
        public bool PedidoDelivery(int idCliente, double totalOP)
        {
            return dA_OrdenPedido.PedidoDelivery(idCliente, totalOP);
        }
        public bool DetallePedidoDelivery(int idProducto, int cantidad)
        {
            return dA_OrdenPedido.DetallePedidoDelivery(idProducto, cantidad);
        }
        public bool OPPagado(string a)
        {
            return dA_OrdenPedido.OPPagado (a);
        }
        public bool OPPreparado(int a)
        {
            return dA_OrdenPedido.OPPreparado(a);
        }
        public bool OPDPreparado(int a)
        {
            return dA_OrdenPedido.OPDPreparado(a);
        }
    }
}
