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
        public List<BE_Insumo> ListaInsumoDisponible(string a)
        {
            return dA_OrdenInsumo.ListaInsumoDisponible(a);
        }
        public List<BE_Insumo> ListaInsumoOC(string a)
        {
            return dA_OrdenInsumo.ListaInsumoOC(a);
        }
        public bool RegistrarOrdenSalida(int a)
        {
            return dA_OrdenInsumo.RegistrarOrdenSalida(a);
        }
        public bool RegistrarOrdenSalidaDet(int a, int b)
        {
            return dA_OrdenInsumo.RegistrarOrdenSalidaDet(a,b);
        }
    }
}
