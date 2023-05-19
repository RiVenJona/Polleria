using BE_;
using DA_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BL_
{
    public class BL_Mesa
    {
        DA_Mesa dA_Mesa;
        public BL_Mesa()
        {
            dA_Mesa = new DA_Mesa();
        }
        public List<BE_Mesa> BL_ListaMesas()
        {
            return dA_Mesa.ListaMesa();
        }

        public List<BE_Mesa> MesasDisponiblesPre()
        {
            return dA_Mesa.MesasDisponiblesPre();
        }
        public bool BL_AsignarMesa(int mesa, int mozo, string nombre, string apellidos, int dni)
        {
            return dA_Mesa.AsignarMesa(mesa, mozo, nombre, apellidos, dni);
        }
        public bool BL_AsignarMesa1(int mesa, string nombre, string apellidos)
        {
            return dA_Mesa.AsignarMesa1(mesa, nombre, apellidos);
        }

        public DataTable BL_Mozo()
        {
            return dA_Mesa.Mozo();
        }

        public DataTable BL_MesaDispoPre()
        {
            return dA_Mesa.MesaDispoPre();
        }
    }
}
