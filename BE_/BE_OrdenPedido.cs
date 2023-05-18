using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_
{
    public class BE_OrdenPedido
    {
        public int idOrdenPedido { get; set; }
        public int idTicket { get; set; }
        public List<TicketDetalle> listOfTickets { get; set; }
        public DateTime fechaOrdenPedido { get; set; }
        public double totalOP { get; set; }
        public int idcliente { get; set; }
        public string mozo { get; set; }
    }
}
