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
    public class DA_CatalogoProductos
    {
        public List<BE_CatalogoProductos> ListaProductos(string user)
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlDataAdapter dt = new SqlDataAdapter();
                SqlCommand sc;
                sc = new SqlCommand("[dbo].[CdProductos]", cn);
                sc.Parameters.AddWithValue("@descripcion", user);
                sc.CommandTimeout = 0;
                sc.CommandType = CommandType.StoredProcedure;
                rd = sc.ExecuteReader();
                BE_CatalogoProductos usuarios;
                List<BE_CatalogoProductos> ListaUsers = new List<BE_CatalogoProductos>();
                while (rd.Read())
                {
                    usuarios = new BE_CatalogoProductos();
                    usuarios.idProducto = int.Parse(rd["idProducto"].ToString());
                    usuarios.desProducto = rd["desProducto"].ToString();
                    usuarios.PrecioProducto = int.Parse(rd["precio"].ToString());
                    ListaUsers.Add(usuarios);
                }
                return ListaUsers;
            }
        }
        public List<int> ListaMesasOcupadas(int user)
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("dbo.MesasOcupadas", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idmozo", user);
                rd = cmd.ExecuteReader();
                BE_CatalogoProductos insumos;
                List<int> ListaInsumos = new List<int>();
                while (rd.Read())
                {
                    insumos = new BE_CatalogoProductos();
                    int a = int.Parse(rd["IdMesa"].ToString());
                    ListaInsumos.Add(a);
                }
                return ListaInsumos;

            }
        }
        }
    }
