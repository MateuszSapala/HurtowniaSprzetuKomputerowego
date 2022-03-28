using System;
using System.Collections.Generic;
using System.Text;

namespace HurtowniaSprzętuKomputerowego.model
{
    class Sprzedaz
    {
        public enum StatusSprzedazy { PRZYJETE_DO_REALIZACJI ,W_TRAKCIE, DO_WYSYLKI, WYSLANE }

        public int Id { get; set; }
        public int KlientId { get; set; }
        public StatusSprzedazy Status { get; set; }
        public decimal Suma { get; set; }
        public DateTime MyProperty { get; set; }

        public Sprzedaz(int id, int klientId, int statusSprzedazy, decimal suma, DateTime myProperty)
        {
            Id = id;
            KlientId = klientId;
            Status = (StatusSprzedazy)statusSprzedazy;
            Suma = suma;
            MyProperty = myProperty;
        }
    }
}
