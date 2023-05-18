using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BE_
{
    [Serializable]
    public class BE_CatalogoProductos
    {
        public int idProducto { get; set; }
        public string desProducto { get; set; }
        public double PrecioProducto { get; set; }
        public int cantidadProducto { get; set; }

        public double total { get; set; }
        public int mesas { get; set; }
    }
}
