﻿using BE_;
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
    public class DA_OrdenInsumo
    {
        public List<BE_Insumo> ListaInsumoDisponible(string id)
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_InsumosDisponibles", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NumOrdenIns", SqlDbType.VarChar).Value = id;
                rd = cmd.ExecuteReader();
                BE_Insumo op;
                List<BE_Insumo> ListaInsumosDispo = new List<BE_Insumo>();
                while (rd.Read())
                {
                    op = new BE_Insumo();
                    op.NumInsumo = rd["numInsumo"].ToString();
                    op.DesIns = rd["DesIns"].ToString();
                    op.Unidad = rd["unidad"].ToString();
                    op.Cantidad = int.Parse(rd["cantoi"].ToString());
                    ListaInsumosDispo.Add(op);
                }
                return ListaInsumosDispo;
            }
        }public List<BE_Insumo> ListaInsumoNoDisponible(string id)
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("InsumosNoDisponibles", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NumOrdenIns", SqlDbType.VarChar).Value = id;
                rd = cmd.ExecuteReader();
                BE_Insumo op;
                List<BE_Insumo> ListaInsumosDispo = new List<BE_Insumo>();
                while (rd.Read())
                {
                    op = new BE_Insumo();
                    op.NumInsumo = rd["numInsumo"].ToString();
                    op.DesIns = rd["DesIns"].ToString();
                    op.Unidad = rd["unidad"].ToString();
                    op.Cantidad = int.Parse(rd["cantoi"].ToString());
                    ListaInsumosDispo.Add(op);
                }
                return ListaInsumosDispo;
            }
        }
        public int ValidacionInsumo()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[ValidacionSolInsu]", cn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    var val = cmd.ExecuteScalar();
                    if (int.Parse(val.ToString()) != 0)
                    { return int.Parse(val.ToString()); }
                    else { return 0; }
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public string SolicitudActual()
        {
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("select top 1 NumSolInsumo from SolInsumo order by 1 desc", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                string valor = cmd.ExecuteScalar().ToString();
                return valor;
            }
        }
        public List<BE_Insumo> ListaInsumoOC(string id)
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_InsumosOC", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@numSolicitudCompra", SqlDbType.VarChar).Value = id;
                    rd = cmd.ExecuteReader();
                BE_Insumo op;
                List<BE_Insumo> ListaInsumosSalida = new List<BE_Insumo>();
                while (rd.Read())
                {
                    op = new BE_Insumo();
                    op.NumInsumo = rd["NumInsumo"].ToString();
                    op.Categoria= rd["DesCateg"].ToString();
                    op.DesIns = rd["DesIns"].ToString();
                    op.Cantidad = int.Parse(rd["CanTidad Requerida"].ToString());
                    op.Unidad = rd["Unidad"].ToString();
                    ListaInsumosSalida.Add(op);
                }
                return ListaInsumosSalida;
            }
        }
        public bool RegistrarOrdenSalida(int IdTra)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[SP_AgregarOrdenSalida]", cn);
                    sc.Parameters.AddWithValue("@IdTrabajador", IdTra);
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
        public bool RegistrarOrdenSalidaDet(int id, int cant)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("SP_AgregarOrdenSalidaDet", cn);
                    sc.Parameters.AddWithValue("@IdInsumo", id);
                    sc.Parameters.AddWithValue("@Cantidad", cant);
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
        public bool CerrarSolicitudInsumo(string id)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("SP_CerrarOrdenInsumo", cn);
                    sc.Parameters.AddWithValue("@NumOrdenIns", id);
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
        public List<BE_OrdenInsumo> ListaOrdenesInsumo()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("SP_ListaSoliInsumo", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                rd = cmd.ExecuteReader();
                BE_OrdenInsumo op;
                List<BE_OrdenInsumo> ListaOrdenesInsumo = new List<BE_OrdenInsumo>();
                while (rd.Read())
                {
                    op = new BE_OrdenInsumo();
                    op.numOrdenInsumo = rd["NumOrdenIns"].ToString();
                    op.fecha = rd["fecha"].ToString();
                    ListaOrdenesInsumo.Add(op);
                }
                return ListaOrdenesInsumo;

            }
        }
        
        public bool GenerarSolicitudInsumo(DateTime FechaProgramada,int Trabajador)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[InsertSolicitudInsumo1]", cn);
                    sc.Parameters.AddWithValue("@FechaProgramada", FechaProgramada);
                    sc.Parameters.AddWithValue("@Tabajador", Trabajador);
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
        public bool GenerarSolicitudInsumoDia(int Dia)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[InsertSolicitudInsumoDia]", cn);
                    sc.Parameters.AddWithValue("@DIA", Dia);
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
        public bool GenerarSolicitudInsumoDiaDet(int Dia,int Producto,int Cantidad)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[InsertSolicitudInsumoDiaDet]", cn);
                    sc.Parameters.AddWithValue("@Dia", Dia);
                    sc.Parameters.AddWithValue("@Producto", Producto);
                    sc.Parameters.AddWithValue("@Cantidad", Cantidad);
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
        public bool CancelarSoliInsumo()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
                {
                    cn.Open();
                    SqlDataAdapter dt = new SqlDataAdapter();
                    SqlCommand sc;
                    sc = new SqlCommand("[dbo].[CancelarSoli]", cn);
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
