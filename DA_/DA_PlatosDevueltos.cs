using BE_;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util_;

namespace DA_
{
    public class DA_PlatosDevueltos
    {
        public bool RegistrarPlatosDevueltos(string a)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("SP_RegistrarPedidoLiberado", cn);
                    sc.Parameters.AddWithValue("@NumDelivery", a);
                    sc.CommandTimeout = 0;
                    sc.CommandType = CommandType.StoredProcedure;
                    var anul = sc.ExecuteScalar();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CerrarOrdenPedidoDelivery(string id)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlCommand sc;
                sc = new SqlCommand("SP_CerrarOrdenPedidoDelivery", cn);
                sc.Parameters.AddWithValue("@NumDelivery", id);
                sc.CommandTimeout = 0;
                sc.CommandType = CommandType.StoredProcedure;
                var pagar = sc.ExecuteScalar();
                return true;
            }
        }

    }
}
