using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_
{
    [Serializable]
    public class BE_Insumo
    {
        public int IdInsumo { get; set; }
        public string NumInsumo { get; set; }
        public string DesIns { get; set;}
        public string Categoria { get; set; }
        public string Unidad { get; set; }
        public int Cantidad { get; set; }

    }
}
