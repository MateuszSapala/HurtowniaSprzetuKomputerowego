using System;
using System.Collections.Generic;
using System.Text;

namespace HurtowniaSprzętuKomputerowego.model
{
    class PozycjaSprzedazy
    {
        public int SprzedazId { get; set; }
        public int ProduktId { get; set; }
        public int ZamowionaIlosc { get; set; }
        public decimal Wartosc { get; set; }


        public PozycjaSprzedazy(int sprzedazId, int produktId, int zamowionaIlosc, decimal wartosc)
        {
            SprzedazId = sprzedazId;
            ProduktId = produktId;
            ZamowionaIlosc = zamowionaIlosc;
            Wartosc = wartosc;
        }
    }
}
