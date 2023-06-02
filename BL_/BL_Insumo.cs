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
        public List<BE_Insumo> ListaCategorias()
        {
            return dA_Insumo.ListaCategorias();
        }
        public List<BE_Insumo> ListaUnidades()
        {
            return dA_Insumo.ListaUnidades();
        }
        public List<BE_Insumo> InsumosCatMin()
        {
            return dA_Insumo.InsumosCatMin();
        }
        public List<BE_CatalogoProductos> ListaProdCata()
        {
            return dA_Insumo.ListaProdCata();
        }
        public List<BE_Insumo> ListaInsumosxNombre(String n)
        {
            return dA_Insumo.ListaInsumosxNombre(n);
        }
        public string NumActualOrdenInsumo()
        {
            return dA_Insumo.NumActualOrdenInsumo();
        }
        public int BuscarNomCateg(string a)
        {
            return dA_Insumo.BuscarNomCateg(a);
        }
        public int IdActualOrdenInsumo()
        {
            return dA_Insumo.IdActualOrdenInsumo();
        }
        public int BuscarIdInsumoxNumInsumo(String n)
        {
            return dA_Insumo.BuscarIdInsumoxNumInsumo(n);
        }
        public List<BE_Insumo> BuscarInsumo(string a)
        {
            return dA_Insumo.BuscarInsumo(a);
        }
        public bool RegistrarInsumo(string DesIns, int Categoria, string unidad, int cantidad, int StockMin, int StockMax)
        {
            return dA_Insumo.RegistrarInsumo(DesIns, Categoria, unidad, cantidad, StockMin, StockMax);
        }
        public bool ModificarInsumo(string NumInsumo, int Categoria, string unidad, int cantidad, int StockMin, int StockMax)
        {
            return dA_Insumo.ModificarInsumo(NumInsumo, Categoria, unidad, cantidad, StockMin, StockMax);
        }

        public bool RegistrarOrdenInsumo(int t)
        {
            return dA_Insumo.RegistrarOrdenInsumo(t);
        }
        public bool RegistrarOrdenInsumoDetalle(string i, int o, int c)
        {
            return dA_Insumo.RegistrarOrdenInsumoDetalle(i, o, c);
        }
    }
}
