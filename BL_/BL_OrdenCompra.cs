using DA_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_;
using System.Net.Sockets;
using System.Data;

namespace BL_
{
    public class BL_OrdenCompra
    {
        DA_OrdenCompra dA_OrdenCompra;

        public BL_OrdenCompra()
        {
            dA_OrdenCompra = new DA_OrdenCompra();
        }
        public bool OrdenCompra(int IdTrabajador)
        {
            return dA_OrdenCompra.OrdenCompra(IdTrabajador);
        }
        public bool DetalleOrdenCompra(int idProducto, int cantidad)
        {
            return dA_OrdenCompra.DetalleOrdenCompra(idProducto, cantidad);
        }
        public List<BE_Insumo> ListaInsumos()
        {
            return dA_OrdenCompra.ListaInsumos();
        }
        public List<BE_Insumo> ListaInsumosNoMin()
        {
            return dA_OrdenCompra.ListaInsumosNoMin();
        }
        public List<BE_Insumo> AñadirInsumo(int DesIns)
        {
            return dA_OrdenCompra.AñadirInsumo(DesIns);
        }
    }
}
