using System;
using System.Collections.Generic;
using System.Text;

namespace HurtowniaSprzętuKomputerowego.model
{
    public abstract class Osoba
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }

        public Osoba(int id, string imie, string nazwisko, string adres, string login, string haslo)
        {
            Id = id;
            Imie = imie;
            Nazwisko = nazwisko;
            Adres = adres;
            Login = login;
            Haslo = haslo;
        }
    }
}
