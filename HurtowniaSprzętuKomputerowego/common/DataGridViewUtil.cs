using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HurtowniaSprzętuKomputerowego.common
{
    class DataGridViewUtil
    {
        public static object pobierzWybranaWartoscKloumny(DataGridView data, string nazwaKolumny)
        {
            if (data.SelectedRows.Count == 0)
            {
                throw new Exception("Nie wybrano wiersza");
            }
            return data.SelectedRows[0].Cells[nazwaKolumny].Value;
        }

        public static int pobierzWybranyId(DataGridView data)
        {
            if (data.SelectedRows.Count == 0)
            {
                throw new Exception("Nie wybrano wiersza");
            }
            return Convert.ToInt32(data.SelectedRows[0].Cells["id"].Value);
        }

        public static string pobierzWybranaKloumneString(DataGridView data, string nazwaKolumny)
        {
            if (data.SelectedRows.Count == 0)
            {
                throw new Exception("Nie wybrano wiersza");
            }
            return Convert.ToString(data.SelectedRows[0].Cells[nazwaKolumny].Value);
        }

        public static int pobierzWybranaKloumneInt(DataGridView data, string nazwaKolumny)
        {
            if (data.SelectedRows.Count == 0)
            {
                throw new Exception("Nie wybrano wiersza");
            }
            return Convert.ToInt32(data.SelectedRows[0].Cells[nazwaKolumny].Value);
        }
      

    }
}
