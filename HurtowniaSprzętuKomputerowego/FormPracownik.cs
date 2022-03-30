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
            zaladujProdukty();
        }

        private object pobierzWybranaWartoscKloumny(DataGridView data, string nazwaKolumny)
        {
            return data.SelectedRows[0].Cells[nazwaKolumny].Value;
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

        private int pobierzWybranaKloumneInt(DataGridView data, string nazwaKolumny)
        {
            return Convert.ToInt32(data.SelectedRows[0].Cells[nazwaKolumny].Value);
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

        private void zaladujProdukty()
        {
            try
            {
                dataGridViewProduktyListaProduktow.DataSource = ProduktRepository.PobierzProdukty();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #region Dostawca
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
            int id = pobierzWybranyId(dataGridViewDostawcyListaDostawcow);
            textBoxDostawcyNazwaDostawcy.Text = pobierzWybranaKloumneString(dataGridViewDostawcyListaDostawcow, "nazwa");
            textBoxDostawcyInformacjeDodatkowe.Text = pobierzWybranaKloumneString(dataGridViewDostawcyListaDostawcow, "informacje_dodatkowe");
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.DataSource = ProduktRepository.PobierzProdukty(id);
        }

        #endregion

        #region Produkt
        private void buttonProduktyDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                int dostawcaId = ((Dostawca)comboBoxProduktyDostawca.SelectedItem).Id;
                string nazwaSprzetu = textBoxProduktyNazwaProduktu.Text;
                string informacjeDodatkowe = textBoxProduktyInformacjeDodatkowe.Text;
                decimal cenaJednostkowa = numericUpDownProduktyCenaJednostkowa.Value;
                ProduktRepository.DodajProdukt(dostawcaId, nazwaSprzetu, informacjeDodatkowe, cenaJednostkowa);
                zaladujProdukty();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonProduktyEdytuj_Click(object sender, EventArgs e)
        {
            try
            {
                int id = pobierzWybranyId(dataGridViewProduktyListaProduktow);
                int dostawcaId = ((Dostawca)comboBoxProduktyDostawca.SelectedItem).Id;
                string nazwaSprzetu = textBoxProduktyNazwaProduktu.Text;
                string informacjeDodatkowe = textBoxProduktyInformacjeDodatkowe.Text;
                decimal cenaJednostkowa = numericUpDownProduktyCenaJednostkowa.Value;
                ProduktRepository.EdytujProdukt(id, dostawcaId, nazwaSprzetu, informacjeDodatkowe, cenaJednostkowa);
                zaladujProdukty();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonProduktyUsun_Click(object sender, EventArgs e)
        {
            try
            {
                int id = pobierzWybranyId(dataGridViewProduktyListaProduktow);
                ProduktRepository.UsunProdukt(id);
                zaladujProdukty();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewProduktyListaProduktow_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProduktyListaProduktow.SelectedRows.Count == 0) return;
            int dostawcaId = pobierzWybranaKloumneInt(dataGridViewProduktyListaProduktow, "dostawca_id");
            foreach (Dostawca dostawca in comboBoxProduktyDostawca.Items)
            {
                if(dostawca.Id == dostawcaId)
                {
                    comboBoxProduktyDostawca.SelectedItem = dostawca;
                }
            }
            textBoxProduktyNazwaProduktu.Text = pobierzWybranaKloumneString(dataGridViewProduktyListaProduktow, "nazwa_sprzetu");
            textBoxDostawcyInformacjeDodatkowe.Text = pobierzWybranaKloumneString(dataGridViewProduktyListaProduktow, "informacje_dodatkowe");
            numericUpDownProduktyCenaJednostkowa.Value = Convert.ToDecimal(pobierzWybranaWartoscKloumny(dataGridViewProduktyListaProduktow, "cena_jednostkowa"));
        }
        #endregion

    }
}
