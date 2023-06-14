using DA_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_
{
    public class BL_Trabajador
    {
        DA_Trabajador dA_Trabajador;
        public BL_Trabajador()
        {
            dA_Trabajador = new DA_Trabajador();
        }
        public int BuscarIdTrabajador(String n)
        {
            return dA_Trabajador.BuscarIdTrabajador(n);
        }
        public int BuscarIdUsuario(String n)
        {
            return dA_Trabajador.BuscarIdUsuario(n);
        }
        public int BuscarIdCliente(String n)
        {
            return dA_Trabajador.BuscarIdCliente(n);
        }
        public string BuscarNombreTrabajador(String n)
        {
            return dA_Trabajador.BuscarNombreTrabajador(n);
        }
    }
}
