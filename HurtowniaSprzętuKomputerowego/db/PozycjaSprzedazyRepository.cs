using HurtowniaSprzętuKomputerowego.common;
using HurtowniaSprzętuKomputerowego.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HurtowniaSprzętuKomputerowego.db
{
    static class PozycjaSprzedazyRepository
    {
        private const string tabela = "Hurtownia.dbo.pozycja_sprzedazy";

        public static DataTable PobierzPozycje()
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM "+tabela))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }


        public static void DodajPozycje(List<PozycjaSprzedazy> pozycje)
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM " + tabela + " WHERE 0=1;"))
            {

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (PozycjaSprzedazy pozycja in pozycje)
                {
                    DataRow sprzedaz = dataTable.NewRow();
                    sprzedaz["sprzedaz_id"] = pozycja.SprzedazId;
                    sprzedaz["produkt_id"] = pozycja.ProduktId;
                    sprzedaz["zamowiona_ilosc"] = pozycja.ZamowionaIlosc;
                    sprzedaz["wartosc"] = pozycja.Wartosc;
                    dataTable.Rows.Add(sprzedaz);
                }

                new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataTable);
            }
        }

        public static DataTable PobierzPozycje(int sprzedazId)
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM " + tabela + " AS s, Hurtownia.dbo.produkt as p  WHERE s.produkt_id=p.id AND s.sprzedaz_id=@sprzedazId;",
                new List<SqlParameter> { new SqlParameter("@sprzedazId", sprzedazId) }))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}
