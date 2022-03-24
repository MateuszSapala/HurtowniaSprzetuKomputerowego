using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HurtowniaSprzętuKomputerowego.common
{
    static class DbConnection
    {

        //Do odpalenia lokalnego potrzebne jest podstawienie odpowiedniego Data Source
        private const string conString = "Data Source=LAPTOP-MPO21D8E\\SQLEXPRESS;Initial Catalog=Hurtownia;Integrated Security=True";

        public static SqlConnection getConnection()
        {
            return new SqlConnection(conString);
        }

        public static SqlDataAdapter getDataAdapter(string sql)
        {
            return new SqlDataAdapter(sql, conString);
        }
    }
}
