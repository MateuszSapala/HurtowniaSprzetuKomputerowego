using System;
using System.Collections.Generic;
using System.Text;

namespace HurtowniaSprzętuKomputerowego.model
{
    public class Pracownik : Osoba
    {
        public Pracownik(int id, string imie, string nazwisko, string adres, string login, string haslo) : base(id, imie, nazwisko, adres, login, haslo)
        {
        }
    }
}
