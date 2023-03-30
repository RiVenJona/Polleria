using BE_;
using DA_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_
{
    public class BL_Insumo
    {
        DA_Insumo dA_Insumo;
        public BL_Insumo()
        {
            dA_Insumo = new DA_Insumo();
        }
        public List<BE_Insumo> ListaInsumos()
        {
            return dA_Insumo.ListaInsumos();
        }
        public List<BE_Insumo> ListaInsumosxNombre(String n)
        {
            return dA_Insumo.ListaInsumosxNombre(n);
        }
        public string NumActualOrdenInsumo()
        {
            return dA_Insumo.NumActualOrdenInsumo();
        }
    }
}
