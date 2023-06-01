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
    public class DA_Insumo
    {
        public string NumActualOrdenInsumo()
        {
            string valor = "";
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_IdOrdenInsumo]", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    valor = rd["NumActual"].ToString();
                }
                rd.Close();
            }

            return valor;
        }

        public int IdActualOrdenInsumo()
        {
            int valor = 1;
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_IdOrden]", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    valor = int.Parse(rd["NumActual"].ToString());
                }
                rd.Close();
            }

            return valor;
        }
        public List<BE_Insumo> ListaInsumos()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT T0.NumInsumo, T0.DesIns, T1.DesCateg, T0.Unidad, T0.Cantidad FROM INSUMO T0 INNER JOIN Categoria T1 ON T0.IdCategoria = T1.IdCateg;", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                BE_Insumo insumos;
                List<BE_Insumo> ListaInsumos = new List<BE_Insumo>();
                while (rd.Read())
                {
                    insumos = new BE_Insumo();
                    insumos.NumInsumo = rd["NumInsumo"].ToString();
                    insumos.DesIns = rd["DesIns"].ToString();
                    insumos.Categoria = rd["DesCateg"].ToString();
                    insumos.Unidad = rd["Unidad"].ToString();
                    insumos.Cantidad = int.Parse(rd["Cantidad"].ToString());
                    ListaInsumos.Add(insumos);
                }
                return ListaInsumos;

            }
        }
        public List<BE_Insumo> InsumosCatMin()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[BuscInsumosMin]", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                rd = cmd.ExecuteReader();
                BE_Insumo insumos;
                List<BE_Insumo> ListaInsumosMin = new List<BE_Insumo>();
                while (rd.Read())
                {
                    insumos = new BE_Insumo();
                    insumos.NumInsumo = rd["NumInsumo"].ToString();
                    insumos.DesIns = rd["DesCateg"].ToString();
                    insumos.Categoria = rd["DesIns"].ToString();
                    insumos.Unidad = rd["Unidad"].ToString();
                    ListaInsumosMin.Add(insumos);
                }
                return ListaInsumosMin;

            }
        }
        public List<BE_Insumo> ListaInsumosxNombre(String n)
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_BuscarInsumo]", cn);
                cmd.Parameters.AddWithValue("@NombreInsumo", n);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                rd = cmd.ExecuteReader();
                BE_Insumo insumos;
                List<BE_Insumo> ListaInsumosxNombre = new List<BE_Insumo>();
                while (rd.Read())
                {
                    insumos = new BE_Insumo();
                    insumos.NumInsumo = rd["NumInsumo"].ToString();
                    insumos.DesIns = rd["DesIns"].ToString();
                    insumos.Categoria = rd["DesCateg"].ToString();
                    insumos.Unidad = rd["Unidad"].ToString();
                    insumos.Cantidad = int.Parse(rd["Cantidad"].ToString());
                    ListaInsumosxNombre.Add(insumos);
                }
                return ListaInsumosxNombre;

            }
        }

        public int BuscarIdInsumoxNumInsumo(String n)
        {
            int valor = 0;
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_BuscarIdInsumo]", cn);
                cmd.Parameters.AddWithValue("@NumInsumo", n);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    valor = int.Parse(rd["IdInsumo"].ToString());
                }
                rd.Close();
            }

            return valor;
        }

        public bool RegistrarOrdenInsumo(int IdTra)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[SP_AgregarOrIns]", cn);
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
        }
        public bool RegistrarOrdenInsumoDetalle(string IdIns, int IdOrden, int Cantidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[SP_AgregarOrInsDet]", cn);
                    sc.Parameters.AddWithValue("@IdOrden", IdIns);
                    sc.Parameters.AddWithValue("@IdInsumo", IdOrden);
                    sc.Parameters.AddWithValue("@Cantidad", Cantidad);
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



