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
    public class DA_Conciliacion
    {
        public List<BE_Conciliacion> OrdenesXRepartidores()
        {
            SqlDataReader reader = null;

            using (SqlConnection cnx = new SqlConnection(Conexion.Obtener()))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd;
                cmd = new SqlCommand("[dbo].[SP_OrdenXRepartidores]", cnx);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();

                BE_Conciliacion beC;
                List<BE_Conciliacion> ListOrdenes = new List<BE_Conciliacion>();

                while (reader.Read())
                {
                    beC = new BE_Conciliacion();
                    beC.NroGOPD = reader["numGOPD"].ToString();
                    beC.idRepartidor = int.Parse(reader["idRepartidor"].ToString());
                    beC.Nombre = reader["Nombre"].ToString();
                    beC.EstadoGOPD = reader["DescEstado"].ToString();
                    ListOrdenes.Add(beC);
                }
                return ListOrdenes;
            }
        }
        public List<BE_Conciliacion> DetalleXTicket(string id)
        {
            SqlDataReader reader = null;

            using (SqlConnection cnx = new SqlConnection(Conexion.Obtener()))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd;
                cmd = new SqlCommand("[dbo].[DetalleConciliacion]", cnx);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@numId", SqlDbType.VarChar).Value = id;
                reader = cmd.ExecuteReader();

                BE_Conciliacion beOP;
                List<BE_Conciliacion> ListDetalles = new List<BE_Conciliacion>();

                while (reader.Read())
                {
                    beOP = new BE_Conciliacion();
                    beOP.idDetallePedido = reader["NumDelivery"].ToString();
                    beOP.total = double.Parse(reader["Total"].ToString());
                    beOP.vuelto = double.Parse(reader["Vuelto"].ToString());
                    beOP.recaudacion = double.Parse(reader["Recaudacion"].ToString());
                    beOP.estadoPedido = reader["DescEstado"].ToString();
                    ListDetalles.Add(beOP);
                }
                return ListDetalles;
            }
        }

        public bool LiquidarOrden(string IdTra)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[LiquidarOPD]", cn);
                    sc.Parameters.AddWithValue("@id", IdTra);
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


    }
}
