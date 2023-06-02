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
    public class DA_OrdenPedidoDelivery
    {
        public bool OPDPagado(int idDelivery, double pago, double vuelto)
        {

            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlCommand sc;
                sc = new SqlCommand("[dbo].[SP_CompletarOPD]", cn);
                sc.Parameters.AddWithValue("@idDelivery", idDelivery);
                sc.Parameters.AddWithValue("@Pago", pago);
                sc.Parameters.AddWithValue("@Vuelto", vuelto);
                sc.CommandTimeout = 0;
                sc.CommandType = CommandType.StoredProcedure;
                var pagar = sc.ExecuteScalar();
                return true;
            }
        }
        public bool CambiarEstadoDelivery(int estado, string id)
        {

            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlCommand sc;
                sc = new SqlCommand("[dbo].[SP_CambiarEstadoDelivery]", cn);
                sc.Parameters.AddWithValue("@Estado", estado);
                sc.Parameters.AddWithValue("@NumDelivery", id);
                sc.CommandTimeout = 0;
                sc.CommandType = CommandType.StoredProcedure;
                var pagar = sc.ExecuteScalar();
                return true;
            }
        }
        public List<BE_OrdenPedidoDelivery> ListaOrdenesPedido2XDeliveryID()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("select NumDelivery, p.Nombre+' '+p.apellidos as cliente, p.Direccion as direccion,total, vuelto\r\nfrom OrdenPedidoDelivery opd\r\ninner join cliente c on c.IdCliente = opd.IdCliente\r\ninner join persona p on c.PersonaID = p.PersonaId\r\nwhere opd.Estado=15", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                BE_OrdenPedidoDelivery opd;
                List<BE_OrdenPedidoDelivery> ListaOrdenes2XDelivery = new List<BE_OrdenPedidoDelivery>();
                while (rd.Read())
                {
                    opd = new BE_OrdenPedidoDelivery();
                    opd.numOrdenPedidoDeli = rd["NumDelivery"].ToString();
                    opd.cliente = rd["cliente"].ToString();
                    opd.direccion = rd["direccion"].ToString();
                    opd.total = double.Parse(rd["total"].ToString());
                    opd.vuelto = double.Parse(rd["vuelto"].ToString());
                    ListaOrdenes2XDelivery.Add(opd);
                }
                return ListaOrdenes2XDelivery;

            }
        }
        public List<BE_OrdenPedidoDelivery> ListaOrdenesPedidoXDeliveryID()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("select NumDelivery, total, vuelto, recaudacion, e.DescEstado\r\nfrom OrdenPedidoDelivery opd\r\ninner join estado e on e.EstadoId = opd.Estado\r\nwhere Estado=15\r\n", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                BE_OrdenPedidoDelivery opd;
                List<BE_OrdenPedidoDelivery> ListaOrdenesXDelivery= new List<BE_OrdenPedidoDelivery>();
                while (rd.Read())
                {
                    opd = new BE_OrdenPedidoDelivery();
                    opd.numOrdenPedidoDeli = rd["NumDelivery"].ToString();
                    opd.total = double.Parse(rd["total"].ToString());
                    opd.vuelto = double.Parse(rd["vuelto"].ToString());
                    opd.recaudacion = double.Parse(rd["recaudacion"].ToString());
                    opd.estado = rd["DescEstado"].ToString();
                    ListaOrdenesXDelivery.Add(opd);
                }
                return ListaOrdenesXDelivery;

            }
        }
    }
}
