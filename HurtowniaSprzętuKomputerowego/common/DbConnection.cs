using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HurtowniaSprzętuKomputerowego.common
{
    static class DbConnection
    {

        //Do odpalenia lokalnego potrzebne jest podstawienie odpowiedniego Data Source
        private const string conString = "Data Source=DESKTOP-ALQ9BUE;Initial Catalog=Hurtownia;Integrated Security=True";

        public static SqlConnection getConnection()
        {
            return new SqlConnection(conString);
        }

        public static SqlCommand getCommand(string sql)
        {
            return new SqlCommand(sql, getConnection());
        }

        public static SqlDataAdapter getDataAdapter(string sql)
        {
            return new SqlDataAdapter(sql, conString);
        }

        public static SqlDataAdapter getDataAdapter(SqlCommand selectSql)
        {
            return new SqlDataAdapter(selectSql);
        }

        public static SqlDataAdapter getDataAdapter(string selectSql, List<SqlParameter> parameters)
        {
            SqlCommand command = getCommand(selectSql);
            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return new SqlDataAdapter(command);
        }
    }
}
