using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_
{
    public class BE_Conciliacion
    {
        public string NroGOPD { get; set; }
        public int idRepartidor { get; set; }
        public string Nombre { get; set; }
        public string EstadoGOPD { get; set; }
        public string idDetallePedido { get; set; }
        public double vuelto { get; set; }
        public double total { get; set; }
        public double recaudacion { get; set; }
        public string estadoPedido { get; set; }

    }
}
