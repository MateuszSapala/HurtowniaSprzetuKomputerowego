using HurtowniaSprzętuKomputerowego.common;
using HurtowniaSprzętuKomputerowego.model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HurtowniaSprzętuKomputerowego.db
{
    static class PracownikRepository
    {
        public static void DodajDostawce(string nazwa, string informacjeDodatkowe)
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM Hurtownia.dbo.dostawca WHERE 0=1;"))
            {
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);

                var x = dataSet.Tables;
                var nowyDostawca = dataSet.Tables[0].NewRow();
                nowyDostawca["nazwa"] = nazwa;
                nowyDostawca["informacje_dodatkowe"] = informacjeDodatkowe;
                dataSet.Tables[0].Rows.Add(nowyDostawca);

                new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataSet);
            }
        }
    }
}
