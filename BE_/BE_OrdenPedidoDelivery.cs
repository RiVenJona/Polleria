using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_
{
    public class BE_OrdenPedidoDelivery
    {
        public int idOrdenPedidoDeli { get; set; }
        public string numOrdenPedidoDeli { get; set; }
        public double total { get; set; }
        public double vuelto { get; set; }
        public double recaudacion { get; set; }
        public string estado { get; set; }
        public string cliente { get; set; }
        public string direccion { get; set; }



    }
}
