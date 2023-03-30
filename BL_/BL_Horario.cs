using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_;
using DA_;

namespace BL_
{
    public class BL_Horario
    {
        DA_Horario dA_Horario;
        public BL_Horario()
        {
            dA_Horario = new DA_Horario();
        }
        public List<BE_Horario> BL_ListaHorarios()
        {
            return dA_Horario.ListaHorario();
        }
    }
}
