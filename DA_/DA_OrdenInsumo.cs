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
    public class DA_OrdenInsumo
    {
        public List<BE_OrdenInsumo> ListaOrdenesInsumo()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("select NumOrdenIns, CONVERT(varchar,fecOi,101) as fecha from OrdenInsumo", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                BE_OrdenInsumo op;
                List<BE_OrdenInsumo> ListaOrdenesInsumo = new List<BE_OrdenInsumo>();
                while (rd.Read())
                {
                    op = new BE_OrdenInsumo();
                    op.numOrdenInsumo = rd["NumOrdenIns"].ToString();
                    op.fecha = rd["fecha"].ToString();
                    ListaOrdenesInsumo.Add(op);
                }
                return ListaOrdenesInsumo;

            }
        }
    }
}
