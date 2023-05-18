using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_
{
    public class TicketDetalle
    {
        public int idTicket { get; set; }
        public int idProductoTicket { get; set;}
        public string desProductoTicket { get; set;}
        public int cantidadProductoTicket { get; set;}
        public double precio { get; set;}
        public double totalTicket { get; set;}
        public double totalProductoTicket { get;set;}
        public int cantidadXTicket { get; set;}
    }
}
