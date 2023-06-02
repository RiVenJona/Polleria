using BE_;
using DA_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_
{
    public class BL_OrdenInsumo
    {
        DA_OrdenInsumo dA_OrdenInsumo;
        public BL_OrdenInsumo()
        {
            dA_OrdenInsumo = new DA_OrdenInsumo();
        }
        public List<BE_OrdenInsumo> ListaOrdenesInsumo()
        {
            return dA_OrdenInsumo.ListaOrdenesInsumo();
        }
    }
}
