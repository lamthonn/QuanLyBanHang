using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Login
{
    internal class connect
    {
        string constr = @"Data Source=DINHHAI13092003;Initial Catalog=QuanLyBanHang;Integrated Security=True";
        SqlConnection conn;

        public connect() { 
            conn = new SqlConnection(constr);
        }

        public DataTable LayDuLieu(string query)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query,conn);
                DataTable tb = new DataTable();
                da.Fill(tb);
                return tb;
            }
            catch
            {
                return null;
            }
        }

        public bool ThucThi(string query) {
            int r = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                r = cmd.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                conn.Close();
            }
            return r > 0;
        }
    }
}
