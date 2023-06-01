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

        public List<BE_OrdenPedidoDelivery> ListaOrdenesPedidoXDeliveryID()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("select NumDelivery, total, vuelto, recaudacion, Estado from OrdenPedidoDelivery\r\nwhere Estado=15", cn);
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
                    opd.estado = rd["Estado"].ToString();
                    ListaOrdenesXDelivery.Add(opd);
                }
                return ListaOrdenesXDelivery;

            }
        }
    }
}
