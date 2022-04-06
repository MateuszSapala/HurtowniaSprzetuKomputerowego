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
            using (SqlConnection connection = DbConnection.getConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO " + tabela + " (imie, nazwisko, adres, login, haslo) VALUES (@imie, @nazwisko, @adres, @login, HASHBYTES('SHA2_512', '" + haslo + "')", connection);
                command.Parameters.Add(new SqlParameter("@imie", imie));
                command.Parameters.Add(new SqlParameter("@nazwisko", nazwisko));
                command.Parameters.Add(new SqlParameter("@adres", adres));
                command.Parameters.Add(new SqlParameter("@login", login));
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static Klient EdytujKlienta(int id, string imie, string nazwisko, string adres, string login, string haslo)
        {
            using (SqlConnection connection = DbConnection.getConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE " + tabela + " SET imie=@imie, nazwisko=@nazwisko, adres=@adres, login=@login, haslo=HASHBYTES('SHA2_512', '" + haslo + "') WHERE id=@id", connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                command.Parameters.Add(new SqlParameter("@imie", imie));
                command.Parameters.Add(new SqlParameter("@nazwisko", nazwisko));
                command.Parameters.Add(new SqlParameter("@adres", adres));
                command.Parameters.Add(new SqlParameter("@login", login));
                command.ExecuteNonQuery();
                connection.Close();
                return new Klient(id, imie, nazwisko, adres, login, "");
            }
        }

        public static DataTable PobierzKlientow()
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT id, imie, nazwisko, adres, login FROM "+tabela))
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
            string sql = "SELECT id, imie, nazwisko, adres, login FROM " + tabela + " AS k WHERE ";
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
