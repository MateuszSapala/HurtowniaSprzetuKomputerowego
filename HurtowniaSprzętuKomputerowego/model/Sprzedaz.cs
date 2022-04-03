using System;
using System.Collections.Generic;
using System.Text;

namespace HurtowniaSprzętuKomputerowego.model
{
    class Sprzedaz
    {
        public enum StatusSprzedazy { PRZYJETE_DO_REALIZACJI=0 ,W_TRAKCIE=1, DO_WYSYLKI=2, WYSLANE=3 }

        public int Id { get; set; }
        public int KlientId { get; set; }
        public StatusSprzedazy Status { get; set; }
        public decimal Suma { get; set; }
        public DateTime DataSprzedazy { get; set; }

        public Sprzedaz(int id, int klientId, StatusSprzedazy statusSprzedazy, decimal suma, DateTime dataSprzedazy)
        {
            Id = id;
            KlientId = klientId;
            Status = statusSprzedazy;
            Suma = suma;
            DataSprzedazy = dataSprzedazy;
        }
    }
}
