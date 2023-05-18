using BE_;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util_;
using System.Net.Sockets;

namespace DA_
{
    public class DA_OrdenPedido
    {
        public List<TicketDetalle> ListaTicketsXOP(int idOP)
        {
            SqlDataReader reader = null;

            using (SqlConnection cnx = new SqlConnection(Conexion.Obtener()))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd;
                cmd = new SqlCommand("SP_TicketXOP", cnx);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idOP", SqlDbType.VarChar).Value = idOP;
                reader = cmd.ExecuteReader();

                TicketDetalle beOP;
                List<TicketDetalle> ListTicketsXOP = new List<TicketDetalle>();

                while (reader.Read())
                {
                    beOP = new TicketDetalle();
                    beOP.idTicket = int.Parse(reader["ticket"].ToString());
                    beOP.totalTicket = double.Parse(reader["totalxTicket"].ToString());
                    beOP.cantidadXTicket = int.Parse(reader["cantidad"].ToString());

                    ListTicketsXOP.Add(beOP);
                }
                return ListTicketsXOP;
            }
        }
        public List<TicketDetalle> DetalleXTicket(int Ticket)
        {
            SqlDataReader reader = null;

            using (SqlConnection cnx = new SqlConnection(Conexion.Obtener()))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd;
                cmd = new SqlCommand("SP_DetalleTicket", cnx);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idTicket", SqlDbType.VarChar).Value = Ticket;
                reader = cmd.ExecuteReader();

                TicketDetalle beOP;
                List<TicketDetalle> ListTicketsXOP = new List<TicketDetalle>();

                while (reader.Read())
                {
                    beOP = new TicketDetalle();
                    beOP.desProductoTicket = reader["desProducto"].ToString();
                    beOP.cantidadProductoTicket = int.Parse(reader["cantidadProducto"].ToString());
                    beOP.precio = double.Parse(reader["precio"].ToString());
                    beOP.totalProductoTicket = double.Parse(reader["Total_Producto"].ToString());
                    ListTicketsXOP.Add(beOP);
                }
                return ListTicketsXOP;
            }
        }
        public double TotalOP(int id)
        {
                double valor = 0;
                SqlDataReader rd = null;
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[SP_TotalOrdenPedido]", cn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idOrdenPedido", SqlDbType.VarChar).Value = id;
                rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        valor = double.Parse(rd["totalOP"].ToString());
                    }
                    rd.Close();
                }

            return valor;
        }
        public string NombreCliente(int id)
        {
                string valor = "";
                SqlDataReader rd = null;
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("ClienteXMesa", cn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idmesa", SqlDbType.VarChar).Value = id;
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
