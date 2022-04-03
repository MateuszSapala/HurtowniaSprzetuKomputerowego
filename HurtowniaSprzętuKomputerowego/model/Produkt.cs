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
        public int Ilosc { get; set; }
        
        public string InformacjeDodatkowe { get; set; }

        public decimal CenaJednostkowa { get; set; }

        public Produkt(int id, string nazwaSprzetu, string informacjeDodatkowe, decimal cenaJednostkowa)
        {
            Id = id;
            NazwaSprzetu = nazwaSprzetu;
            InformacjeDodatkowe = informacjeDodatkowe;
            CenaJednostkowa = cenaJednostkowa;
            Ilosc = 1;
        }

        public override string ToString()
        {
           
            return String.Format(FormKlient.output ,NazwaSprzetu, Ilosc, (Math.Round(Ilosc * CenaJednostkowa, 2))); 
        }

    }
}
