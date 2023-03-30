using BE_;
using DA_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
