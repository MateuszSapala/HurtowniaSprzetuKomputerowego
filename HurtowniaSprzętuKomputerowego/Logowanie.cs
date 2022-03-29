using HurtowniaSprzętuKomputerowego.common;
using HurtowniaSprzętuKomputerowego.model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HurtowniaSprzętuKomputerowego
{
    public partial class Logowanie : Form
    {

        public Logowanie()
        {
            InitializeComponent();
        }

        private void buttonZaloguj_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string haslo = textBoxHaslo.Text;

            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM Hurtownia.dbo.pracownik WHERE login='" + login + "' AND haslo='" + haslo + "';"))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    Pracownik pracownik = new Pracownik(row.Field<int>("id"), row.Field<string>("imie"), row.Field<string>("nazwisko"), row.Field<string>("adres"), row.Field<string>("login"), row.Field<string>("haslo"));
                    FormPracownik formPracownik = new FormPracownik(pracownik);
                    formPracownik.FormClosed += (s, args) => Close();
                    formPracownik.Show();
                    Hide();
                    return;
                }
            }

            using (SqlDataAdapter dataAdapter = DbConnection.getDataAdapter("SELECT * FROM Hurtownia.dbo.klient WHERE login='" + login + "' AND haslo='" + haslo + "';"))
            {
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    Klient klient = new Klient(row.Field<int>("id"), row.Field<string>("imie"), row.Field<string>("nazwisko"), row.Field<string>("adres"), row.Field<string>("login"), row.Field<string>("haslo"));
                    FormKlient formKlient = new FormKlient(klient);
                    formKlient.FormClosed += (s, args) => Close();
                    formKlient.Show();
                    Hide();
                    return;
                }
            }
        }
    }
}
