﻿using BE_;
using DA_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_
{
    public class BL_OrdenReserva
    {
        DA_OrdenReserva dA_Orden;
        public BL_OrdenReserva()
        {
            dA_Orden = new DA_OrdenReserva();
        }
        public List<BE_OrdenReserva> BL_Reserva(string a)
        {
            return dA_Orden.ListaOrdenReserva(a);
        }
        public List<BE_OrdenReserva> BL_ReservaActiva(int a)
        {
            return dA_Orden.ReservasActivas(a);
        }
        public List<BE_OrdenReserva> BL_ReservaActiva1(string b, string c)
        {
            return dA_Orden.ReservasActivas1(b, c);
        }
        public bool BL_RegistrarReserva(int mesa, DateTime fecha, int hora, int tra, int dni)
        {
            return dA_Orden.RegistrarReserva(mesa, fecha, hora, tra, dni);
        }
        public List<string> BL_Disponibilidad(DateTime Fechad, int Horad)
        {
            return dA_Orden.Disponibilidad(Fechad, Horad);
        }
        public bool BL_AnulaReserva(String b)
        {
            return dA_Orden.AnularReserva(b);
        }

    }
}
