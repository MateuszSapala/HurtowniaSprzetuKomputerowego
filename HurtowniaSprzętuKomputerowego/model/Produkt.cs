using System;
using System.Collections.Generic;
using System.Text;

namespace HurtowniaSprzętuKomputerowego.model
{
    class Produkt
    {
        public int Id { get; set; }
        public int DostawcaId { get; set; }
        public string NazwaSprzetu { get; set; }
        public int IloscNaMagazynie { get; set; }
        public decimal Nazwa { get; set; }

        public Produkt(int id, int dostawcaId, string nazwaSprzetu, int iloscNaMagazynie, decimal nazwa)
        {
            Id = id;
            DostawcaId = dostawcaId;
            NazwaSprzetu = nazwaSprzetu;
            IloscNaMagazynie = iloscNaMagazynie;
            Nazwa = nazwa;
        }
    }
}
