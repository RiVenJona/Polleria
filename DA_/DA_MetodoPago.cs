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
    public class DA_MetodoPago
    {
        public List<BE_MetodoPago> ListaMetodoPago()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MpagoId, descMpago from MetodoPago;", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                BE_MetodoPago metodoPago;
                List<BE_MetodoPago> ListaMetodoPago = new List<BE_MetodoPago>();
                while (rd.Read())
                {
                    metodoPago = new BE_MetodoPago();
                    metodoPago.Valor = int.Parse(rd["MpagoId"].ToString());
                    metodoPago.Descripcion = rd["descMpago"].ToString();
                    ListaMetodoPago.Add(metodoPago);
                }
                return ListaMetodoPago;
            }
        }
    }
}
