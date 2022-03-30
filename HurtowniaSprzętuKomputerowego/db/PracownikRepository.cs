using HurtowniaSprzętuKomputerowego.common;
using HurtowniaSprzętuKomputerowego.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HurtowniaSprzętuKomputerowego.db
{
    static class PracownikRepository
    {
        private const string tabela = "Hurtownia.dbo.dostawca";

        public static void DodajDostawce(string nazwa, string informacjeDodatkowe)
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM "+tabela+" WHERE 0=1;"))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                DataRow dostawca = dataTable.NewRow();
                dostawca["nazwa"] = nazwa;
                dostawca["informacje_dodatkowe"] = informacjeDodatkowe;
                dataTable.Rows.Add(dostawca);

                new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataTable);
            }
        }

        public static void EdytujDostawce(int id, string nazwa, string informacjeDodatkowe)
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM "+tabela+" WHERE id=@id;", new List<SqlParameter> { new SqlParameter("@id", id) }))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                DataRow dostawca = dataTable.Rows[0];
                dostawca["nazwa"] = nazwa;
                dostawca["informacje_dodatkowe"] = informacjeDodatkowe;

                new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataTable);
            }
        }

        public static DataTable PobierzDostawcow()
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM "+tabela))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public static void UsunDostawce(int id)
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM "+tabela+" WHERE id=@id;", new List<SqlParameter> { new SqlParameter("@id", id) }))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataTable.Rows[0].Delete();
                new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataTable);
            }
        }
    }
}
