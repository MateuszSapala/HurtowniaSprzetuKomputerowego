using System;
using System.Collections.Generic;
using System.Text;

namespace HurtowniaSprzętuKomputerowego.model
{
    class PozycjaSprzedazy
    {
        public int Id { get; set; }
        public int SprzedazId { get; set; }
        public int ProduktId { get; set; }
        public int ZamowionaIlosc { get; set; }
        public decimal Wartosc { get; set; }

        public PozycjaSprzedazy(int id, int sprzedazId, int produktId, int zamowionaIlosc, decimal wartosc)
        {
            Id = id;
            SprzedazId = sprzedazId;
            ProduktId = produktId;
            ZamowionaIlosc = zamowionaIlosc;
            Wartosc = wartosc;
        }
    }
}
