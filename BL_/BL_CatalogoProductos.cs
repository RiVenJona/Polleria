﻿using BE_;
using DA_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_
{
    public class BL_CatalogoProductos
    {
        DA_CatalogoProductos dA_Catalogo;
        public BL_CatalogoProductos()
        {
            dA_Catalogo = new DA_CatalogoProductos();
        }
        public List<BE_CatalogoProductos> ListaProductos(string a)
        {
            return dA_Catalogo.ListaProductos(a);
        }
        public List<BE_CatalogoProductos> ListaDevoluciones(string a)
        {
            return dA_Catalogo.ListaDevoluciones(a);
        }
        public List<BE_CatalogoProductos> Productos(int a)
        {
            return dA_Catalogo.Productos(a);
        }
        public List<int> listaMesas(int user)
        {
            return dA_Catalogo.ListaMesasOcupadas(user);
        }
        public List<BE_CatalogoProductos> DetalleOrdenPedido(string a)
        {
            return dA_Catalogo.DetalleOrdenPedido(a);
        }
        public List<BE_CatalogoProductos> DetalleOrdenPedidoDeli(string a)
        {
            return dA_Catalogo.DetalleOrdenPedidoDeli(a);
        }


    }
}
