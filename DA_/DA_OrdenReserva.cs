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
    public class DA_OrdenReserva
    {
        public List<BE_OrdenReserva> ListaOrdenReserva(string NumOrdenRe)
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlDataAdapter dt = new SqlDataAdapter();
                SqlCommand sc;
                sc = new SqlCommand("[dbo].[BuscaReserva]", cn);
                sc.Parameters.AddWithValue("@OrdenReserva", NumOrdenRe);
                sc.CommandTimeout = 0;
                sc.CommandType = CommandType.StoredProcedure;
                rd = sc.ExecuteReader();
                BE_OrdenReserva ListaReserva;
                List<BE_OrdenReserva> Reserva = new List<BE_OrdenReserva>();
                while (rd.Read())
                {
                    ListaReserva = new BE_OrdenReserva();
                    ListaReserva.NumOrdenRe = rd["NumOrdenRe"].ToString();
                    ListaReserva.FechaProgra = rd["FechaProgra"].ToString();
                    ListaReserva.DNI = int.Parse(rd["DNI"].ToString());
                    ListaReserva.Nombre = rd["Nombre"].ToString();
                    ListaReserva.Apellidos = rd["Apellidos"].ToString();
                    ListaReserva.DescHorario = rd["DescHorario"].ToString();
                    ListaReserva.Telefono = int.Parse(rd["Telefono"].ToString());
                    ListaReserva.Correo = rd["correo"].ToString();
                    ListaReserva.IdMesa = int.Parse(rd["IdMesa"].ToString());
                    ListaReserva.Espacio = int.Parse(rd["Espacios"].ToString());
                    ListaReserva.EstadoOrden = rd["DescEstado"].ToString();
                    Reserva.Add(ListaReserva);
                }
                return Reserva;
            }
        }

        public List<BE_OrdenReserva> ReservasActivas(int DNI)
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlDataAdapter dt = new SqlDataAdapter();
                SqlCommand sc;
                sc = new SqlCommand("[dbo].[BuscaReservaRec]", cn);
                sc.Parameters.AddWithValue("@DNI", DNI);
                sc.CommandTimeout = 0;
                sc.CommandType = CommandType.StoredProcedure;
                rd = sc.ExecuteReader();
                BE_OrdenReserva ListaReserva;
                List<BE_OrdenReserva> Reserva = new List<BE_OrdenReserva>();
                while (rd.Read())
                {
                    ListaReserva = new BE_OrdenReserva();
                    ListaReserva.NumOrdenRe = rd["NumOrdenRe"].ToString();
                    ListaReserva.FechaProgra = rd["FechaProgra"].ToString();
                    ListaReserva.DNI = int.Parse(rd["DNI"].ToString());
                    ListaReserva.Nombre = rd["Nombre"].ToString();
                    ListaReserva.Apellidos = rd["Apellidos"].ToString();
                    ListaReserva.DescHorario = rd["DescHorario"].ToString();
                    ListaReserva.Telefono = int.Parse(rd["Telefono"].ToString());
                    ListaReserva.Correo = rd["correo"].ToString();
                    ListaReserva.IdMesa = int.Parse(rd["IdMesa"].ToString());
                    ListaReserva.Espacio = int.Parse(rd["Espacios"].ToString());
                    ListaReserva.EstadoOrden = rd["DescEstado"].ToString();
                    Reserva.Add(ListaReserva);
                }
                return Reserva;
            }
        }

        public List<BE_OrdenReserva> ReservasActivas1(string Nombre, string Apellidos)
        {
            SqlDataReader rd1 = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlDataAdapter dt = new SqlDataAdapter();
                SqlCommand sc1;
                sc1 = new SqlCommand("[dbo].[BuscaReservaRec1]", cn);
                sc1.Parameters.AddWithValue("@Nombre", Nombre);
                sc1.Parameters.AddWithValue("@Apellidos", Apellidos);
                sc1.CommandTimeout = 0;
                sc1.CommandType = CommandType.StoredProcedure;
                rd1 = sc1.ExecuteReader();
                BE_OrdenReserva ListaReserva1;
                List<BE_OrdenReserva> Reserva1 = new List<BE_OrdenReserva>();
                while (rd1.Read())
                {
                    ListaReserva1 = new BE_OrdenReserva();
                    ListaReserva1.NumOrdenRe = rd1["NumOrdenRe"].ToString();
                    ListaReserva1.FechaProgra = rd1["FechaProgra"].ToString();
                    ListaReserva1.DNI = int.Parse(rd1["DNI"].ToString());
                    ListaReserva1.Nombre = rd1["Nombre"].ToString();
                    ListaReserva1.Apellidos = rd1["Apellidos"].ToString();
                    ListaReserva1.DescHorario = rd1["DescHorario"].ToString();
                    ListaReserva1.Telefono = int.Parse(rd1["Telefono"].ToString());
                    ListaReserva1.Correo = rd1["correo"].ToString();
                    ListaReserva1.IdMesa = int.Parse(rd1["IdMesa"].ToString());
                    ListaReserva1.Espacio = int.Parse(rd1["Espacios"].ToString());
                    ListaReserva1.EstadoOrden = rd1["DescEstado"].ToString();
                    Reserva1.Add(ListaReserva1);
                }
                return Reserva1;
            }
        }
        public bool RegistrarReserva(int IdMesa, DateTime FechaProgra, int IdHorario, int IdTrabajador, int DNI)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[AgregarReserva]", cn);
                    sc.Parameters.AddWithValue("@Mesa", IdMesa);
                    sc.Parameters.AddWithValue("@FechaProgra", FechaProgra);
                    sc.Parameters.AddWithValue("@IdHorario", IdHorario);
                    sc.Parameters.AddWithValue("@IdTrabajador", IdTrabajador);
                    sc.Parameters.AddWithValue("@DNI", DNI);
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
        public List<string> Disponibilidad(DateTime FechaProgra, int IdHorario)
        {
            try
            {
                SqlDataReader rd = null;
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[Disponibilidad]", cn);
                    sc.Parameters.AddWithValue("@FechaProgra", FechaProgra);
                    sc.Parameters.AddWithValue("@Horario", IdHorario);
                    sc.CommandTimeout = 0;
                    sc.CommandType = CommandType.StoredProcedure;
                    rd = sc.ExecuteReader();
                    List<string> Dispo = new List<string>();
                    Dispo.Add("Seleccionar");
                    while (rd.Read())
                    {
                        Dispo.Add(rd["IdMesa"].ToString());
                    }
                    return Dispo;
                }
            }
            catch (Exception)
            {
                return null;
            }

        }
        public bool AnularReserva(string NumOrdenRe)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[AnularReserva]", cn);
                    sc.Parameters.AddWithValue("@OrdenReserva", NumOrdenRe);
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
