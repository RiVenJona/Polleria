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
                    op.repartidor = rd["NombreRepartidor"].ToString();
                    ListaRepartidores.Add(op);
                }
                return ListaRepartidores;

            }
        }

    }
}
