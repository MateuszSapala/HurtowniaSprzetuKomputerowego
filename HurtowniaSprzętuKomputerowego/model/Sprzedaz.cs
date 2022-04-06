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
        public DateTime DataSprzedazy { get; set; }

        public Sprzedaz(int id, int klientId, StatusSprzedazy statusSprzedazy, decimal suma, DateTime dataSprzedazy)
        {
            Id = id;
            KlientId = klientId;
            Status = statusSprzedazy;
            Suma = suma;
            DataSprzedazy = dataSprzedazy;
        }

        public static string EnumToString(Sprzedaz.StatusSprzedazy status)
        {
            switch (status)
            {
                case Sprzedaz.StatusSprzedazy.PRZYJETE_DO_REALIZACJI:
                    return "Przyjęte do realizacji";
                case Sprzedaz.StatusSprzedazy.W_TRAKCIE:
                    return "W trakcie";
                case Sprzedaz.StatusSprzedazy.DO_WYSYLKI:
                    return "Do Wysyłki";
                case Sprzedaz.StatusSprzedazy.WYSLANE:
                    return "Wysłane";
                default:
                    return "Brak";
            }
        }
     }
}
