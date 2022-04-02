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
        private const string tabela = "Hurtownia.dbo.pracownik";

        public static Pracownik EdytujPracownika(int id, string imie, string nazwisko, string adres, string login, string haslo)
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM "+tabela+" WHERE id=@id;", new List<SqlParameter> { new SqlParameter("@id", id) }))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                DataRow pracownik = dataTable.Rows[0];
                pracownik["imie"] = imie;
                pracownik["nazwisko"] = nazwisko;
                pracownik["adres"] = adres;
                pracownik["login"] = login;
                pracownik["haslo"] = Common.encryptPassword(haslo);

                new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataTable);

                return new Pracownik(id, imie, nazwisko, adres, login, haslo);
            }
        }
    }
}
