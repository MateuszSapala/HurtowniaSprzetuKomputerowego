using System;
using System.Collections.Generic;
using System.Text;

namespace HurtowniaSprzętuKomputerowego.model
{
    class Dostawca
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string InformacjeDodatkowe { get; set; }

        public Dostawca(int id, string nazwa, string informacjeDodatkowe)
        {
            Id = id;
            Nazwa = nazwa;
            InformacjeDodatkowe = informacjeDodatkowe;
        }
    }
}
