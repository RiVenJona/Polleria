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
        public List<TicketDetalle> DetallexTicket(int ticket)
        {
            return dA_OrdenPedido.DetalleXTicket(ticket);
        }
        public double TotalOP(int id)
        {
            return dA_OrdenPedido.TotalOP(id);
        }
        public string NombreCliente(int mesa)
        {
            return dA_OrdenPedido.NombreCliente(mesa);
        }

        public List<BE_OrdenPedido> ListaOrdenesPedido()
        {
            return dA_OrdenPedido.ListaOrdenesPedido();
        }
        public int GetOrdenPedidoId(int mozo, int mesa)
        {
            return dA_OrdenPedido.GetOrdenPedidoID(mozo, mesa);
        }
        public bool InsertOP(int mozo, int mesa)
        {
            return dA_OrdenPedido.InsertOP(mozo, mesa);
        }
        public bool InsertDetallePedido(int idProducto, int cantidad)
        {
            return dA_OrdenPedido.InsertDetallePedido(idProducto, cantidad);
        }
        public bool OPPagado(string a)
        {
            return dA_OrdenPedido.OPPagado (a);
        }
    }
}
