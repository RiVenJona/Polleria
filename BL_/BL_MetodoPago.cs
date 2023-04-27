using BE_;
using DA_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_
{
    public class BL_MetodoPago
    {
        DA_MetodoPago dA_MetodoPago;
        public BL_MetodoPago()
        {
            dA_MetodoPago = new DA_MetodoPago();
        }
        public List<BE_MetodoPago> BL_ListaMetodoPago()
        {
            return dA_MetodoPago.ListaMetodoPago();
        }
    }
}
