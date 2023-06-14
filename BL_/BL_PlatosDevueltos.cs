using DA_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_
{
    public class BL_PlatosDevueltos
    {
        DA_PlatosDevueltos dA_PlatosDevueltos;

        public BL_PlatosDevueltos()
        {
            dA_PlatosDevueltos = new DA_PlatosDevueltos();
        }

        public bool RegistrarPlatosDevueltos(string a)
        {
            return dA_PlatosDevueltos.RegistrarPlatosDevueltos(a);
        }
        public bool CerrarOrdenPedidoDelivery(string a)
        {
            return dA_PlatosDevueltos.CerrarOrdenPedidoDelivery(a);
        }

    }
}
