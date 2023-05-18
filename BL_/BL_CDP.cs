using BE_;
using DA_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_
{
    public class BL_CDP
    {
        DA_CDP dA_CDP;
        public BL_CDP()
        {
            dA_CDP= new DA_CDP();
        }
        public List<BE_CDP> BL_ListaCDP()
        {
            return dA_CDP.ListaCDP();
        }
        
        public string SiguienteIdOrdenPedido()
        {
            return dA_CDP.SiguienteIdOrdenPedido();
        }

        public BE_Persona ClienteCDP(string a)
        {
            return dA_CDP.ClienteCDP(a);
        }

    }
}
