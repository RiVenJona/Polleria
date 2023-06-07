using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util_;
using BE_;
using System.Security.Cryptography;

namespace DA_
{
    public class DA_OrdenPedidoDelivery
    {
        public bool GenerarCDPyTSD(int idDelivery,int TraId)
        {

            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlCommand sc;
                sc = new SqlCommand("[dbo].[SP_GenerarCDPyTSD]", cn);
                sc.Parameters.AddWithValue("@idDelivery", idDelivery);
                sc.Parameters.AddWithValue("@TraId", TraId);
                sc.CommandTimeout = 0;
                sc.CommandType = CommandType.StoredProcedure;
                var pagar = sc.ExecuteScalar();
                return true;
            }
        }
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
        public List<BE_OrdenPedidoDelivery> ListaOrdenesPedido2XDeliveryID(int OPD)
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_ListaPedidosxOrdenEst", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idGOPD", OPD);
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
        public List<BE_OrdenPedidoDelivery> ListaOrdenesPedidoXDeliveryID(int OPD)
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_ListaPedidosxOrdenDes", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idGOPD", OPD);
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
