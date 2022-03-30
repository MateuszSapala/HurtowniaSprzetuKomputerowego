using HurtowniaSprzętuKomputerowego.db;
using HurtowniaSprzętuKomputerowego.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HurtowniaSprzętuKomputerowego
{
    public partial class FormPracownik : Form
    {
        Pracownik zalogowanyPracownik;

        public FormPracownik(Pracownik pracownik)
        {
            zalogowanyPracownik = pracownik;
            InitializeComponent();
            comboBoxProduktyDostawca.DisplayMember = "Nazwa";
            comboBoxProduktyDostawca.ValueMember = "Id";
            zaladujDostawcow();
        }


        private int pobierzWybranyId(DataGridView data)
        {
            if (data.SelectedRows.Count==0)
            {
                throw new Exception("Nie wybrano wiersza");
            }
            return Convert.ToInt32(data.SelectedRows[0].Cells["id"].Value);
        }

        private string pobierzWybranaKloumneString(DataGridView data, string nazwaKolumny)
        {
            return Convert.ToString(data.SelectedRows[0].Cells[nazwaKolumny].Value);
        }

        private void zaladujDostawcow()
        {
            try
            {
                DataTable dostawcy = PracownikRepository.PobierzDostawcow();
                dataGridViewDostawcyListaDostawcow.DataSource = dostawcy;
                comboBoxProduktyDostawca.Items.Clear();
                foreach (DataRow row in dostawcy.Rows)
                {
                    comboBoxProduktyDostawca.Items.Add(new Dostawca(row));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void buttonDostawcyDodajDostawce_Click(object sender, EventArgs e)
        {
            try
            {
                string nazwaDostawcy = textBoxDostawcyNazwaDostawcy.Text;
                string informacjeDodatkowe = textBoxDostawcyInformacjeDodatkowe.Text;
                PracownikRepository.DodajDostawce(nazwaDostawcy, informacjeDodatkowe);
                zaladujDostawcow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDostawcyEdytujDostawce_Click(object sender, EventArgs e)
        {
            try
            {
                int id = pobierzWybranyId(dataGridViewDostawcyListaDostawcow);
                string nazwaDostawcy = textBoxDostawcyNazwaDostawcy.Text;
                string informacjeDodatkowe = textBoxDostawcyInformacjeDodatkowe.Text;
                PracownikRepository.EdytujDostawce(id, nazwaDostawcy, informacjeDodatkowe);
                zaladujDostawcow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDostawcyUsunDostawce_Click(object sender, EventArgs e)
        {
            try
            {
                int id = pobierzWybranyId(dataGridViewDostawcyListaDostawcow);
                PracownikRepository.UsunDostawce(id);
                zaladujDostawcow();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewDostawcyListaDostawcow_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewDostawcyListaDostawcow.SelectedRows.Count == 0) return;
            textBoxDostawcyNazwaDostawcy.Text = pobierzWybranaKloumneString(dataGridViewDostawcyListaDostawcow, "nazwa");
            textBoxDostawcyInformacjeDodatkowe.Text = pobierzWybranaKloumneString(dataGridViewDostawcyListaDostawcow, "informacje_dodatkowe");
        }
    }
}
