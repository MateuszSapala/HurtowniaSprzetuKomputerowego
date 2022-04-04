using HurtowniaSprzętuKomputerowego.common;
using HurtowniaSprzętuKomputerowego.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HurtowniaSprzętuKomputerowego.db
{
    static class SprzedazRepository
    {
        private const string tabela = "Hurtownia.dbo.sprzedaz";

        public static DataTable PobierzSprzedaze()
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM " + tabela))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public static int PobierzMaxIdSprzedazy()
        {
            int maxId = 0;
            try
            {
                using (SqlConnection cnz = DbConnection.getConnection())
                {
                    SqlCommand cmdzs = new SqlCommand("SELECT MAX(id) FROM sprzedaz ", cnz);
                    cmdzs.CommandType = CommandType.Text;
                    cmdzs.Connection.Open();
                    maxId= Convert.ToInt32(cmdzs.ExecuteScalar());
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
            
            return maxId;
        }

        public static void DodajSprzedaz(int id, int klientId, int statusSprzedazy,decimal suma, DateTime dataSprzedazy)
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM " + tabela + " WHERE 0=1;"))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                DataRow sprzedaz = dataTable.NewRow();
                sprzedaz["id"] = id;
                sprzedaz["klient_id"] = klientId;
                sprzedaz["status"] = statusSprzedazy;
                sprzedaz["suma"] = suma;
                sprzedaz["data_sprzedazy"] = dataSprzedazy; 
                dataTable.Rows.Add(sprzedaz);

                new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataTable);
            }
        }

        public static DataTable PobierzSprzedaze(int klientId)
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM " + tabela + " AS s WHERE s.klient_id=@klientId;",
                new List<SqlParameter> { new SqlParameter("@klientId", klientId) }))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public static void EdytujSprzedaz(int id, int status)
        {
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM " + tabela + " WHERE id=@id;", new List<SqlParameter> { new SqlParameter("@id", id) }))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                DataRow dostawca = dataTable.Rows[0];
                dostawca["status"] = status;

                new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataTable);
            }
        }
    }
}
