using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util_;
using BE_;

namespace DA_
{
    public class DA_Mesa
    {        
        public List<BE_Mesa> ListaMesa()
        {
                SqlDataReader rd = null;
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT IdMesa FROM Mesas;", cn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.Text;
                    rd = cmd.ExecuteReader();
                    BE_Mesa mesas;
                    List<BE_Mesa> ListaMesas = new List<BE_Mesa>();
                    while (rd.Read())
                    {
                        mesas = new BE_Mesa();
                        mesas.IdMesa = rd["IdMesa"].ToString();
                        ListaMesas.Add(mesas);
                    }
                return ListaMesas;

                }
        }
    }
}
