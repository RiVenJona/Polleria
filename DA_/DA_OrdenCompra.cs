﻿using System;
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
    public class DA_OrdenCompra
    {
        public bool OrdenCompra(int IdTrabajador)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[InsertOrdenCompra]", cn);
                    sc.Parameters.AddWithValue("@IdTrabajador", IdTrabajador);
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
        public bool DetalleOrdenCompra(int idProducto, int cantidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[InsertOrdenCompraDet]", cn);
                    sc.Parameters.AddWithValue("@IdProducto", idProducto);
                    sc.Parameters.AddWithValue("@Cantidad", cantidad);

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

        public List<BE_Insumo> ListaInsumos()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("Select DesIns FROM Insumo;", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                BE_Insumo Insumos;
                List<BE_Insumo> ListaInsumos = new List<BE_Insumo>();
                while (rd.Read())
                {
                    Insumos = new BE_Insumo();
                    Insumos.DesIns = rd["DesIns"].ToString();
                    ListaInsumos.Add(Insumos);
                }
                return ListaInsumos;
            }
        }
        public List<BE_Insumo> ListaInsumosNoMin()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[InsumosNoMin]", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                rd = cmd.ExecuteReader();
                BE_Insumo Insumos;
                List<BE_Insumo> ListaInsumos = new List<BE_Insumo>();
                while (rd.Read())
                {
                    Insumos = new BE_Insumo();
                    Insumos.DesIns = rd["DesIns"].ToString();
                    ListaInsumos.Add(Insumos);
                }
                return ListaInsumos;
            }
        }
        public List<BE_Insumo> AñadirInsumo(int ProdCata)
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {
                cn.Open();
                SqlDataAdapter dt = new SqlDataAdapter();
                SqlCommand sc;
                sc = new SqlCommand("[dbo].[AñadirInsumo]", cn);
                sc.Parameters.AddWithValue("@ProdCata", ProdCata);
                sc.CommandTimeout = 0;
                sc.CommandType = CommandType.StoredProcedure;
                rd = sc.ExecuteReader();
                BE_Insumo ListaReserva;
                List<BE_Insumo> Reserva = new List<BE_Insumo>();
                while (rd.Read())
                {
                    ListaReserva = new BE_Insumo();
                    ListaReserva.NumInsumo = rd["NumInsumo"].ToString();
                    ListaReserva.Categoria = rd["DesCateg"].ToString();
                    ListaReserva.DesIns = rd["DesIns"].ToString();
                    ListaReserva.Cantidad = int.Parse(rd["Cantidad"].ToString());
                    ListaReserva.StockMax = int.Parse(rd["StockMax"].ToString());
                    ListaReserva.Unidad = rd["Unidad"].ToString();
                    Reserva.Add(ListaReserva);
                }
                return Reserva;
            }
        }


    }
}