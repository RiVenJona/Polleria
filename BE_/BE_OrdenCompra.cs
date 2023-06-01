using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_
{
    public class BE_OrdenCompra
    {
        public int IdCompra { get; set; }
        public string NumOrdenCompra { get; set; }
        public DateTime FechaCompra { get; set; }
        public int IdTrabajador { get; set; }
        public int Estado { get; set; }
    }
}
