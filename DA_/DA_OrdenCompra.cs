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
    public class DA_OrdenCompra
    {
        public bool OrdenCompra(int IdTrabajador)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[InsertOrdenCompra]", cn);
                    sc.Parameters.AddWithValue("@IdTrabajador", IdTrabajador);
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
        public bool DetalleOrdenCompra(int idProducto, int cantidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[InsertOrdenCompraDet]", cn);
                    sc.Parameters.AddWithValue("@IdProducto", idProducto);
                    sc.Parameters.AddWithValue("@Cantidad", cantidad);

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

        public List<BE_Insumo> ListaInsumos()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("Select DesIns FROM Insumo;", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                BE_Insumo Insumos;
                List<BE_Insumo> ListaInsumos = new List<BE_Insumo>();
                while (rd.Read())
                {
                    Insumos = new BE_Insumo();
                    Insumos.DesIns = rd["DesIns"].ToString();
                    ListaInsumos.Add(Insumos);
                }
                return ListaInsumos;
            }
        }
        public List<BE_Insumo> ListaInsumosNoMin()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[InsumosNoMin]", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                rd = cmd.ExecuteReader();
                BE_Insumo Insumos;
                List<BE_Insumo> ListaInsumos = new List<BE_Insumo>();
                while (rd.Read())
                {
                    Insumos = new BE_Insumo();
                    Insumos.DesIns = rd["DesIns"].ToString();
                    ListaInsumos.Add(Insumos);
                }
                return ListaInsumos;
            }
        }
        public DataTable AñadirInsumo(string DesIns)
{
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[AñadirInsumo]", cn);
                    sc.Parameters.AddWithValue("@DesIns", DesIns);
                    sc.CommandTimeout = 0;
                    sc.CommandType = CommandType.StoredProcedure;
            
                    DataTable result = new DataTable();
                    dt.SelectCommand = sc;
                    dt.Fill(result);

                    return result;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
