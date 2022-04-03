using HurtowniaSprzętuKomputerowego.common;
using HurtowniaSprzętuKomputerowego.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HurtowniaSprzętuKomputerowego.db
{
    static class ProduktRepository
    {
        private const string tabela = "Hurtownia.dbo.produkt";


        public static void DodajProdukt(int dostawcaId, string nazwaSprzetu, string informacjeDodatkowe, decimal cenaJednostkowa)
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM " + tabela + " WHERE 0=1;"))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                DataRow produkt = dataTable.NewRow();
                produkt["dostawca_id"] = dostawcaId;
                produkt["nazwa_sprzetu"] = nazwaSprzetu;
                produkt["informacje_dodatkowe"] = informacjeDodatkowe;
                produkt["cena_jednostkowa"] = cenaJednostkowa;

                dataTable.Rows.Add(produkt);

                new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataTable);
            }
        }

        public static void EdytujProdukt(int id, int dostawcaId, string nazwaSprzetu, string informacjeDodatkowe, decimal cenaJednostkowa)
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM " + tabela + " WHERE id=@id;", new List<SqlParameter> { new SqlParameter("@id", id) }))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                DataRow produkt = dataTable.Rows[0];
                produkt["dostawca_id"] = dostawcaId;
                produkt["nazwa_sprzetu"] = nazwaSprzetu;
                produkt["informacje_dodatkowe"] = informacjeDodatkowe;
                produkt["cena_jednostkowa"] = cenaJednostkowa;

                new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataTable);
            }
        }

        public static DataTable PobierzProdukty()
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT p.id, d.nazwa, p.nazwa_sprzetu, p.informacje_dodatkowe, p.cena_jednostkowa, d.id AS dostawca_id FROM " + tabela+" AS p, Hurtownia.dbo.dostawca AS d WHERE p.dostawca_id=d.id;"))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public static DataTable PobierzProduktyTabelaKlient()
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT p.id, p.nazwa_sprzetu as nazwa_sprzetu, p.cena_jednostkowa as cena_za_1_szt,  p.informacje_dodatkowe FROM " + tabela + " AS p;"))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public static DataTable PobierzProdukty(int dostawcaId)
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT p.id, d.nazwa, p.nazwa_sprzetu, p.informacje_dodatkowe, p.cena_jednostkowa, d.id AS dostawca_id FROM " + tabela + " AS p, Hurtownia.dbo.dostawca AS d WHERE p.dostawca_id=d.id AND d.id=@dostawcaId;", 
                new List<SqlParameter> { new SqlParameter("@dostawcaId", dostawcaId)}))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public static void UsunProdukt(int id)
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM " + tabela + " WHERE id=@id;", new List<SqlParameter> { new SqlParameter("@id", id) }))
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
