using HurtowniaSprzętuKomputerowego.common;
using HurtowniaSprzętuKomputerowego.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HurtowniaSprzętuKomputerowego.db
{
    static class SprzedazRepository
    {
        private const string tabela = "Hurtownia.dbo.sprzedaz";

        public static DataTable PobierzSprzedaze()
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM "+tabela))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public static DataTable PobierzSprzedaze(int klientId)
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM " + tabela + " AS s WHERE s.klient_id=@klientId;",
                new List<SqlParameter> { new SqlParameter("@klientId", klientId) }))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}
