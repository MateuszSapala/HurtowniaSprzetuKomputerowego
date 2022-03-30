using HurtowniaSprzętuKomputerowego.common;
using HurtowniaSprzętuKomputerowego.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HurtowniaSprzętuKomputerowego.db
{
    static class KlientRepository
    {
        private const string tabela = "Hurtownia.dbo.klient";


        public static void DodajKlienta(string imie, string nazwisko, string adres, string login, string haslo)
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM " + tabela + " WHERE 0=1;"))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                DataRow klient = dataTable.NewRow();
                klient["imie"] = imie;
                klient["nazwisko"] = nazwisko;
                klient["adres"] = adres;
                klient["login"] = login;
                klient["haslo"] = haslo;

                dataTable.Rows.Add(klient);

                new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataTable);
            }
        }

        public static void EdytujKlienta(int id, string imie, string nazwisko, string adres, string login, string haslo)
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM " + tabela + " WHERE id=@id;", new List<SqlParameter> { new SqlParameter("@id", id) }))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                DataRow klient = dataTable.Rows[0];
                klient["imie"] = imie;
                klient["nazwisko"] = nazwisko;
                klient["adres"] = adres;
                klient["login"] = login;
                klient["haslo"] = haslo;

                new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataTable);
            }
        }

        public static DataTable PobierzKlientow()
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM "+tabela))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public static DataTable PobierzKlientow(string filtr)
        {
            string[] filtry = filtr.Split(' ');
            List<SqlParameter> parametry = new List<SqlParameter>();
            string sql = "SELECT * FROM " + tabela + " AS k WHERE ";
            for (int i = 0; i < filtry.Length; i++)
            {
                string p = "@p" + i;
                parametry.Add(new SqlParameter(p, "%"+ filtry[i]+"%"));
                if (i != 0) sql += " AND ";
                sql += "(LOWER(k.imie) LIKE LOWER(" + p + ") OR LOWER(k.nazwisko) LIKE LOWER(" + p + ") OR LOWER(k.adres) LIKE LOWER(" + p + ") OR LOWER(k.login) LIKE LOWER(" + p + "))";
            }
            sql += ";";


            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter(sql, parametry))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public static void UsunKlienta(int id)
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
