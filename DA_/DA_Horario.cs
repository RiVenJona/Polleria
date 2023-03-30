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
    public class DA_Horario
    {
        public List<BE_Horario> ListaHorario()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IdHorario, DescHorario FROM Horario;", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                BE_Horario horarios;
                List<BE_Horario> ListaHorarios= new List<BE_Horario>();
                while (rd.Read())
                {
                    horarios = new BE_Horario();
                    horarios.IdHorario = int.Parse(rd["IdHorario"].ToString());
                    horarios.DescHorario = rd["DescHorario"].ToString();
                    ListaHorarios.Add(horarios);
                }
                return ListaHorarios;

            }
        }
    }
}
