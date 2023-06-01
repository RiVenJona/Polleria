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
        public bool OPDPreparado(int idodp)
        {

            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlDataAdapter dt = new SqlDataAdapter();
                SqlCommand sc;
                sc = new SqlCommand("[dbo].[SP_PedidoDeliveryPreparado]", cn);
                sc.Parameters.AddWithValue("@idDelivery", idodp);
                sc.CommandTimeout = 0;
                sc.CommandType = CommandType.StoredProcedure;
                var pagar = sc.ExecuteScalar();
                return true;
            }
        }
        public bool OPPreparado(int idticket)
        {

            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlDataAdapter dt = new SqlDataAdapter();
                SqlCommand sc;
                sc = new SqlCommand("[dbo].[SP_PedidoPreparado]", cn);
                sc.Parameters.AddWithValue("@idTicketOrdenPedido", idticket);
                sc.CommandTimeout = 0;
                sc.CommandType = CommandType.StoredProcedure;
                var pagar = sc.ExecuteScalar();
                return true;
            }
        }
        public List<TicketDetalle> DetalleXTicketPreparar(int Ticket)
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
                List<TicketDetalle> ListTicketsXOPPreparar = new List<TicketDetalle>();

                while (reader.Read())
                {
                    beOP = new TicketDetalle();
                    beOP.desProductoTicket = reader["desProducto"].ToString();
                    beOP.cantidadProductoTicket = int.Parse(reader["cantidadProducto"].ToString());
                    ListTicketsXOPPreparar.Add(beOP);
                }
                return ListTicketsXOPPreparar;
            }
        }
        public List<TicketDetalle> DetalleXODPPreparar(int idopd)
        {
            SqlDataReader reader = null;

            using (SqlConnection cnx = new SqlConnection(Conexion.Obtener()))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd;
                cmd = new SqlCommand("SP_DetallePedidoDeliveryPreparar", cnx);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idDelivery", SqlDbType.VarChar).Value = idopd;
                reader = cmd.ExecuteReader();
                
                TicketDetalle beOP;
                List<TicketDetalle> ListTicketsXOPPreparar = new List<TicketDetalle>();

                while (reader.Read())
                {
                    beOP = new TicketDetalle();
                    beOP.desProductoTicket = reader["desProducto"].ToString();
                    beOP.cantidadProductoTicket = int.Parse(reader["Cantidad"].ToString());
                    ListTicketsXOPPreparar.Add(beOP);
                }
                return ListTicketsXOPPreparar;
            }
        }

        
        public List<BE_OrdenPedido> ListaPedidosDeliveryPreparar()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                
                cn.Open();
                SqlCommand cmd = new SqlCommand("select IdDelivery, NumDelivery from OrdenPedidoDelivery", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                BE_OrdenPedido op;
                List<BE_OrdenPedido> ListaPedidosDeliveryPreparar = new List<BE_OrdenPedido>();
                while (rd.Read())
                {
                    op = new BE_OrdenPedido();
                    op.idTicket = int.Parse(rd["IdDelivery"].ToString());
                    op.numOrdenPedido = rd["NumDelivery"].ToString();
                    ListaPedidosDeliveryPreparar.Add(op);
                }
                return ListaPedidosDeliveryPreparar;

            }
        }
        public List<BE_OrdenPedido> ListaTickets()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("select idTicketOrdenPedido, NumOrdenPedido from TicketOrdenPedido torp inner join OrdenPedido op on torp.idOrdenPedido=op.idOrdenPedido", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                BE_OrdenPedido op;
                List<BE_OrdenPedido> ListaTickets = new List<BE_OrdenPedido>();
                while (rd.Read())
                {
                    op = new BE_OrdenPedido();
                    op.idTicket = int.Parse(rd["idTicketOrdenPedido"].ToString());
                    op.numOrdenPedido = rd["NumOrdenPedido"].ToString();
                    ListaTickets.Add(op);
                }
                return ListaTickets;

            }
        }

        public bool OPPagado(string NumOrdenPedido)
        {
            
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[SP_OPEstadoPagado]", cn);
                    sc.Parameters.AddWithValue("@NumOrdenPedido", NumOrdenPedido);
                    sc.CommandTimeout = 0;
                    sc.CommandType = CommandType.StoredProcedure;
                    var pagar = sc.ExecuteScalar();
                    return true;
                }
        }
        public List<BE_OrdenPedido> ListaOrdenesPedido()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_OrdenesPedido", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                rd = cmd.ExecuteReader();
                BE_OrdenPedido op;
                List<BE_OrdenPedido> ListaOrdenesPedido = new List<BE_OrdenPedido>();
                while (rd.Read())
                {
                    op = new BE_OrdenPedido();
                    op.numOrdenPedido = rd["NumOrdenPedido"].ToString();
                    op.cliente = rd["nombres"].ToString();
                    op.clienteDNI = rd["dni_ruc"].ToString();
                    op.totalOP = double.Parse(rd["total"].ToString());
                    op.dia = rd["Fecha"].ToString();
                    op.hora = rd["Hora"].ToString();
                    op.estado = rd["DescEstado"].ToString();
                    ListaOrdenesPedido.Add(op);
                }
                return ListaOrdenesPedido;

            }
        }
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
        public double TotalOPD(int id)
        {
            double valor = 0;
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[SP_TotalOrdenPedidoDeli]", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idDelivery", SqlDbType.VarChar).Value = id;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    valor = double.Parse(rd["total"].ToString());
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
        public int GetOrdenPedidoID(int mozo,int mesa)
        {
                int valor = 0;
                SqlDataReader rd = null;
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("GetOrdenPedidoID", cn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idMesa", SqlDbType.VarChar).Value = mesa;
                cmd.Parameters.Add("@mozo", SqlDbType.VarChar).Value = mozo;
                rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        valor = int.Parse(rd["idOrdenPedido"].ToString());
                    }
                    rd.Close();
                }

            return valor;
        }
        public bool InsertOP(int mozo, int mesa)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[AddOrdenPedidoOrTicket]", cn);
                    sc.Parameters.AddWithValue("@mesa", mesa);
                    sc.Parameters.AddWithValue("@mozo", mozo);
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
        public bool InsertDetallePedido(int idProducto,int cantidad,int mesa, int mozo)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[AddDetalleTicket]", cn);
                    sc.Parameters.AddWithValue("@idProducto", idProducto);
                    sc.Parameters.AddWithValue("@cantidad", cantidad);
                    sc.Parameters.AddWithValue("@mesa", mesa);
                    sc.Parameters.AddWithValue("@mozo", mozo);
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
        public bool PedidoDelivery(int idCliente, double totalOP)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[PedidoDelivery]", cn);
                    sc.Parameters.AddWithValue("@Cliente", idCliente);
                    sc.Parameters.AddWithValue("@Total", totalOP);
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
        public bool DetallePedidoDelivery(int idProducto, int cantidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[PedidoDeliveryDet]", cn);
                    sc.Parameters.AddWithValue("@idProducto", idProducto);
                    sc.Parameters.AddWithValue("@cantidad", cantidad);

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
