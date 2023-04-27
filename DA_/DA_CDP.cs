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
    public class DA_CDP
    {
        public List<BE_CDP> ListaCDP()
        {
            SqlDataReader rd = null;
            using (SqlConnection cn = new SqlConnection(Conexion.Obtener()))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT CdpId, descCDP from CDP;", cn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                BE_CDP cdp;
                List<BE_CDP> ListaCDP = new List<BE_CDP>();
                while (rd.Read())
                {
                    cdp = new BE_CDP();
                    cdp.Valor = int.Parse(rd["CdpId"].ToString());
                    cdp.Descripcion = rd["descCDP"].ToString();
                    ListaCDP.Add(cdp);
                }
                return ListaCDP;
            }
        }
    }
}
