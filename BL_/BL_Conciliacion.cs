using BE_;
using DA_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_
{
    public class BL_Conciliacion
    {
        DA_Conciliacion dA_Conciliacion;
        public BL_Conciliacion()
        {
            dA_Conciliacion = new DA_Conciliacion();
        }

        public List<BE_Conciliacion> OrdenesXRepartidores()
        {
            return dA_Conciliacion.OrdenesXRepartidores();
        }

        public List<BE_Conciliacion> DetallesXOrdendes(string id)
        {
            return dA_Conciliacion.DetalleXTicket(id);
        }
        public bool LiquidarOrden(string a)
        {
            return dA_Conciliacion.LiquidarOrden(a);
        }
    }
}
