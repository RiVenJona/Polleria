using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util_
{
    public static class Conexion
    {
        public static String Obtener()
        {
            return ConfigurationManager.ConnectionStrings["cn"].ToString();
        }
    }
}
