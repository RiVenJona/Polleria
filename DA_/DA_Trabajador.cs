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
    public class DA_Trabajador
    {
        public int BuscarIdTrabajador(String n)
        {
            int valor = 0;
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_BuscarIdTrabajador]", cn);
                cmd.Parameters.AddWithValue("@Usuario", n);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    valor = int.Parse(rd["TraId"].ToString());
                }
                rd.Close();
            }

            return valor;
        }

        public string BuscarNombreTrabajador(String n)
        {
            string valor = "";
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_BuscarNombreTrabajador]", cn);
                cmd.Parameters.AddWithValue("@Usuario", n);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    valor = rd["Nombre"].ToString();
                }
                rd.Close();
            }

            return valor;
        }
    }
}
