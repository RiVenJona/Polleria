using DA_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_
{
    public class BL_SolicitudCompra
    {
        DA_SolicitudCompra dA_SolicitudCompra;
        public BL_SolicitudCompra()
        {
            dA_SolicitudCompra = new DA_SolicitudCompra();

        }
        public bool RegistrarSolicitudCompra()
        {
            return dA_SolicitudCompra.RegistrarSolicitudCompra();
        }
        public bool RegistrarSolicitudCompraDet(int a, int b)
        {
            return dA_SolicitudCompra.RegistrarSolicitudCompraDet(a, b);
        }
    }
}
