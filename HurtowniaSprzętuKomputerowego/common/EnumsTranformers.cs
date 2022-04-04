using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using HurtowniaSprzętuKomputerowego.model;

namespace HurtowniaSprzętuKomputerowego.common
{
    class EnumsTranformers
    {
        public static void TransformSprzedazDataTable(DataTable table)
        {
            table.Columns.Add("Status Zamówienia", typeof(String));
            foreach (DataRow row in table.Rows)
            {
                int value = (int)row[2];
                row[5] = Sprzedaz.EnumToString(((Sprzedaz.StatusSprzedazy)value));
            }
        }
    }
}
