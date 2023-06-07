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
        public List<BE_Insumo> ListaInsumoDisponible(string id)
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_InsumosDisponibles", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NumOrdenIns", SqlDbType.VarChar).Value = id;
                rd = cmd.ExecuteReader();
                BE_Insumo op;
                List<BE_Insumo> ListaInsumosDispo = new List<BE_Insumo>();
                while (rd.Read())
                {
                    op = new BE_Insumo();
                    op.NumInsumo = rd["numInsumo"].ToString();
                    op.DesIns = rd["DesIns"].ToString();
                    op.Unidad = rd["unidad"].ToString();
                    op.Cantidad = int.Parse(rd["cantoi"].ToString());
                    ListaInsumosDispo.Add(op);
                }
                return ListaInsumosDispo;
            }
        }

        public List<BE_Insumo> ListaInsumoOC(string id)
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_InsumosOC", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NumOrdenSalida", SqlDbType.VarChar).Value = id;
                rd = cmd.ExecuteReader();
                BE_Insumo op;
                List<BE_Insumo> ListaInsumosSalida = new List<BE_Insumo>();
                while (rd.Read())
                {
                    op = new BE_Insumo();
                    op.NumInsumo = rd["NumInsumo"].ToString();
                    op.DesIns = rd["DesIns"].ToString();
                    op.Unidad = rd["Unidad"].ToString();
                    op.Cantidad = int.Parse(rd["cantidad"].ToString());
                    ListaInsumosSalida.Add(op);
                }
                return ListaInsumosSalida;
            }
        }
        public bool RegistrarOrdenSalida(int IdTra)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[SP_AgregarOrdenSalida]", cn);
                    sc.Parameters.AddWithValue("@IdTrabajador", IdTra);
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
        }public bool RegistrarOrdenSalidaDet(int id, int cant)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("SP_AgregarOrdenSalidaDet", cn);
                    sc.Parameters.AddWithValue("@IdInsumo", id);
                    sc.Parameters.AddWithValue("@Cantidad", cant);
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
