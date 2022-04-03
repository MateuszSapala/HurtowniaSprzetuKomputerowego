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
            using(SqlConnection connection = DbConnection.getConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE "+tabela+ " SET imie=@imie, nazwisko=@nazwisko, adres=@adres, login=@login, haslo=HASHBYTES('SHA2_512', '"+haslo+"') WHERE id=@id", connection);
                command.Parameters.Add(new SqlParameter("@id", id));
                command.Parameters.Add(new SqlParameter("@imie", imie));
                command.Parameters.Add(new SqlParameter("@nazwisko", nazwisko));
                command.Parameters.Add(new SqlParameter("@adres", adres));
                command.Parameters.Add(new SqlParameter("@login", login));
                command.ExecuteNonQuery();
                connection.Close();
                return new Pracownik(id, imie, nazwisko, adres, login, "");
            }
        }
    }
}
