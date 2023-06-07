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
    public class DA_GenerarOrdenPedidoDelivery
    {
        public List<BE_GenerarOrdenPedidoDelivery> ListPedidoPreparados()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_ListaPedidosDelivery", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                rd = cmd.ExecuteReader();
                BE_GenerarOrdenPedidoDelivery op;
                List<BE_GenerarOrdenPedidoDelivery> ListaOrdenesPedido = new List<BE_GenerarOrdenPedidoDelivery>();
                while (rd.Read())
                {
                    op = new BE_GenerarOrdenPedidoDelivery();
                    op.idOPD = rd["NumDelivery"].ToString();
                    op.nombreCliente = rd["Nombre"].ToString();
                    op.Creacion = rd["FechaDel"].ToString();
                    op.estadoPedido = rd["DescEstado"].ToString();
                    ListaOrdenesPedido.Add(op);
                }
                return ListaOrdenesPedido;

            }
        }
        public List<BE_GenerarOrdenPedidoDelivery> ListaRepartidores()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("ListaRepartidores", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                rd = cmd.ExecuteReader();
                BE_GenerarOrdenPedidoDelivery op;
                List<BE_GenerarOrdenPedidoDelivery> ListaRepartidores = new List<BE_GenerarOrdenPedidoDelivery>();
                while (rd.Read())
                {
                    op=new BE_GenerarOrdenPedidoDelivery();
                    op.idRepartidor = int.Parse(rd["UserId"].ToString());
                    op.repartidor = rd["NombreRepartidor"].ToString();
                    ListaRepartidores.Add(op);
                }
                return ListaRepartidores;

            }
        }

        public bool RegistrarGOPD(int idRepartidor)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[SP_AddGOPD]", cn);
                    sc.Parameters.AddWithValue("@repartidor", idRepartidor);
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
        public bool RegistrarDetalleGOPD(string idDelivery)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[SP_AddDetalleGOPD]", cn);
                    sc.Parameters.AddWithValue("@idDelivery", idDelivery);
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
        public List<TicketDetalle> ListaTickets(string idDelivery)
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("TicketGODP", cn);
                cmd.Parameters.AddWithValue("@numDelivery", idDelivery);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                rd = cmd.ExecuteReader();
                TicketDetalle op;
                List<TicketDetalle> ListaDetalles = new List<TicketDetalle>();
                while (rd.Read())
                {
                    op = new TicketDetalle();
                    op.desProductoTicket = rd["desProducto"].ToString();
                    op.cantidadProductoTicket = int.Parse(rd["Cantidad"].ToString());
                    op.precio = double.Parse(rd["precio"].ToString());
                    op.totalProductoTicket = double.Parse(rd["total"].ToString());
                    ListaDetalles.Add(op);
                }
                return ListaDetalles;

            }
        }

        public int UltimoDelivery()
        {
            int valor = 0;
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_UltimoDelivery", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    valor = int.Parse(rd["idGOPD"].ToString());
                }
                rd.Close();
            }

            return valor;
        }

    }
}
