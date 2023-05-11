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

        public List<BE_Mesa> MesasDisponiblesPre()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[DisponibilidadPre]", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
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

        public bool AsignarMesa(int IdMesa, int Mozo)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[AsignarMesa]", cn);
                    sc.Parameters.AddWithValue("@Mesa", IdMesa);
                    sc.Parameters.AddWithValue("@Mozo", Mozo);
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

        public bool AsignarMesa1(int IdMesa)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[AsignarMesa1]", cn);
                    sc.Parameters.AddWithValue("@Mesa", IdMesa);
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

        public DataTable Mozo()
        {


            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[BuscMozo]", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteReader();
                cn.Close();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);


                //if (rd.Read())
                //{
                //    valor = rd["TraId"].ToString();
                //    valor1 = rd["Nombre"].ToString();
                //}
                //rd.Close();
            }

            return dt;

        }
    }
}
