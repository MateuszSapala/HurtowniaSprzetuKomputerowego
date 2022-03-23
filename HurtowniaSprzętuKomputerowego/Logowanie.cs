using HurtowniaSprzętuKomputerowego.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HurtowniaSprzętuKomputerowego
{
    public partial class Logowanie : Form
    {

        public Logowanie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*using (SqlConnection connection = DbConnection.getConnection())
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Hurtownia.dbo.pracownik;", connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MessageBox.Show(reader.GetInt32(0) + " " + reader.GetString(1));
                }
            }*/
            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter(DbConnection.Table.pracownik))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach(DataRow row in dataTable.Rows)
                {
                    MessageBox.Show(row.Field<int>("id") + " " + row.Field<string>("imie") + " " + row.Field<string>("nazwisko") + " " + row.Field<string>("adres"));
                }
            }
        }
    }
}
