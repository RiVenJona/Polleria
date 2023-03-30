using BE_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util_;

namespace DA_
{
    public class DA_Usuario
    {
        public List<BE_Usuario> ListaUsuario(string user,string pass)
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlDataAdapter dt = new SqlDataAdapter();
                SqlCommand sc;
                sc = new SqlCommand("[dbo].[ValidacionLogin]",cn);
                sc.Parameters.AddWithValue("@user", user);
                sc.Parameters.AddWithValue("@pass", pass);
                sc.CommandTimeout = 0;
                sc.CommandType = CommandType.StoredProcedure;
                rd = sc.ExecuteReader();
                BE_Usuario usuarios;
                List<BE_Usuario> ListaUsers = new List<BE_Usuario>();             
                while (rd.Read())
                {
                    usuarios = new BE_Usuario();
                    usuarios.IdUsuario = int.Parse(rd["IdCuenta"].ToString());
                    ListaUsers.Add(usuarios);
                }
                return ListaUsers;
            }
        }
        public string GetCredencial(string user)
        {
            try {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand cmd;
                    cmd = new SqlCommand("[dbo].[SPValidacionUser]", cn);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    var val = cmd.ExecuteScalar();
                    if (val == null) return "";
                    else return val.ToString();

                }
            }
            catch (Exception ) {
                return String.Empty;
            }
        }
        public string getRolByCre(string user, string pass)
        {
            try { 
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_GetRolTrabajador]", cn);
                cmd.Parameters.AddWithValue("@user",user);
                cmd.Parameters.AddWithValue("@pass",pass);
                cmd.CommandTimeout= 0;
                cmd.CommandType= CommandType.StoredProcedure;
                var val = cmd.ExecuteScalar();
                return val.ToString();
            }
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }
        public bool ExisteUsuario(string user)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[obtenerUsuario]", cn);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    var val = cmd.ExecuteScalar();
                    if (int.Parse(val.ToString()) == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string ValidaPreguntas(string p1, string p2, string p3, string p4, string p5)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[ValidarPreguntas]",cn);
                    cmd.Parameters.AddWithValue("@p1", p1);
                    cmd.Parameters.AddWithValue("@p2", p2);
                    cmd.Parameters.AddWithValue("@p3", p3);
                    cmd.Parameters.AddWithValue("@p4", p4);
                    cmd.Parameters.AddWithValue("@p5", p5);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    var val = cmd.ExecuteScalar();
                    if (val.ToString() != "")
                    { return val.ToString(); }
                    else { return string.Empty; }
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public int ValUsuarioSiTienePreguntas(string user, string pass)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[ValPreguntas]",cn);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    var val = cmd.ExecuteScalar();
                    if (int.Parse(val.ToString()) != 0)
                    { return int.Parse(val.ToString()); }
                    else { return 0; }
                }
            }
            catch(Exception)
            {
                return -1;
            }
        }
        public bool RegistrarPreguntas(string user,string p1, string p2, string p3, string p4, string p5)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[RegistrarPreguntas]",cn);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@p1", p1);
                    cmd.Parameters.AddWithValue("@p2", p2);
                    cmd.Parameters.AddWithValue("@p3", p3);
                    cmd.Parameters.AddWithValue("@p4", p4);
                    cmd.Parameters.AddWithValue("@p5", p5);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    var val = cmd.ExecuteScalar();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CambiarPass(string user, string nuevaPass)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[cambiarPass]", cn);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@nuevapass", nuevaPass);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    var val = cmd.ExecuteScalar();
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
