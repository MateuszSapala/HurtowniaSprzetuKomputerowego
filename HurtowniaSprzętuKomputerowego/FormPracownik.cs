using HurtowniaSprzętuKomputerowego.common;
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
            zaladujDanePracownika();
            zaladujDostawcow();
            zaladujProdukty();
            zaladujKlientow();
            zaladujSprzedaz();
        }

        #region Pobieranie danych
        private void zaladujDanePracownika()
        {
            textBoxInformacjeImie.Text = zalogowanyPracownik.Imie;
            textBoxInformacjeNazwisko.Text = zalogowanyPracownik.Nazwisko;
            textBoxInformacjeAdres.Text = zalogowanyPracownik.Adres;
            textBoxInformacjeLogin.Text = zalogowanyPracownik.Login;
        }

        private void zaladujDostawcow()
        {
            try
            {
                DataTable dostawcy = DostawcaRepository.PobierzDostawcow();
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

        private void zaladujKlientow()
        {
            try
            {
                if (textBoxKlienciFiltr.Text.Trim() == "")
                {
                    dataGridViewKlienciListaKlientow.DataSource = KlientRepository.PobierzKlientow();
                    return;
                }
                dataGridViewKlienciListaKlientow.DataSource = KlientRepository.PobierzKlientow(textBoxKlienciFiltr.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void zaladujSprzedaz()
        {
            try
            {
                dataGridViewSprzedazeSprzedaze.DataSource = SprzedazRepository.PobierzSprzedaze();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region Dostawca
        private void buttonDostawcyDodajDostawce_Click(object sender, EventArgs e)
        {
            try
            {
                string nazwaDostawcy = textBoxDostawcyNazwaDostawcy.Text;
                string informacjeDodatkowe = textBoxDostawcyInformacjeDodatkowe.Text;
                DostawcaRepository.DodajDostawce(nazwaDostawcy, informacjeDodatkowe);
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
                int id = DataGridViewUtil.pobierzWybranyId(dataGridViewDostawcyListaDostawcow);
                string nazwaDostawcy = textBoxDostawcyNazwaDostawcy.Text;
                string informacjeDodatkowe = textBoxDostawcyInformacjeDodatkowe.Text;
                DostawcaRepository.EdytujDostawce(id, nazwaDostawcy, informacjeDodatkowe);
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
                int id = DataGridViewUtil.pobierzWybranyId(dataGridViewDostawcyListaDostawcow);
                DostawcaRepository.UsunDostawce(id);
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
            int id = DataGridViewUtil.pobierzWybranyId(dataGridViewDostawcyListaDostawcow);
            textBoxDostawcyNazwaDostawcy.Text = DataGridViewUtil.pobierzWybranaKloumneString(dataGridViewDostawcyListaDostawcow, "nazwa");
            textBoxDostawcyInformacjeDodatkowe.Text = DataGridViewUtil.pobierzWybranaKloumneString(dataGridViewDostawcyListaDostawcow, "informacje_dodatkowe");
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
                int id = DataGridViewUtil.pobierzWybranyId(dataGridViewProduktyListaProduktow);
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
                int id = DataGridViewUtil.pobierzWybranyId(dataGridViewProduktyListaProduktow);
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
            int dostawcaId = DataGridViewUtil.pobierzWybranaKloumneInt(dataGridViewProduktyListaProduktow, "dostawca_id");
            foreach (Dostawca dostawca in comboBoxProduktyDostawca.Items)
            {
                if(dostawca.Id == dostawcaId)
                {
                    comboBoxProduktyDostawca.SelectedItem = dostawca;
                }
            }
            textBoxProduktyNazwaProduktu.Text = DataGridViewUtil.pobierzWybranaKloumneString(dataGridViewProduktyListaProduktow, "nazwa_sprzetu");
            textBoxProduktyInformacjeDodatkowe.Text = DataGridViewUtil.pobierzWybranaKloumneString(dataGridViewProduktyListaProduktow, "informacje_dodatkowe");
            numericUpDownProduktyCenaJednostkowa.Value = Convert.ToDecimal(DataGridViewUtil.pobierzWybranaWartoscKloumny(dataGridViewProduktyListaProduktow, "cena_jednostkowa"));
        }
        #endregion

        #region Klienci
        private void buttonKlienciSzukaj_Click(object sender, EventArgs e)
        {
            zaladujKlientow();
        }

        private void dataGridViewKlienciListaKlientow_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridViewKlienciKupnaKlienta.DataSource = SprzedazRepository.PobierzSprzedaze(DataGridViewUtil.pobierzWybranyId(dataGridViewKlienciListaKlientow));
            }
            catch (Exception ex) { }
        }
        #endregion

        #region Sprzedaże
        private void dataGridViewSprzedazeSprzedaze_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridViewSprzedazeKupioneProdukty.DataSource = PozycjaSprzedazyRepository.PobierzPozycje(DataGridViewUtil.pobierzWybranyId(dataGridViewSprzedazeSprzedaze));
            }
            catch (Exception ex) { }
        }
        #endregion

        #region Informacje
        private void buttonyInformacjeEnable(bool edytuj, bool anuluj, bool zapisz)
        {
            buttonInformacjeEdytuj.Enabled = edytuj;
            buttonInformacjeAnuluj.Enabled = anuluj;
            buttonInformacjeZapisz.Enabled = zapisz;
        }

        private void textBoxesInformacjeEnable(bool enable)
        {
            textBoxInformacjeImie.Enabled = enable;
            textBoxInformacjeNazwisko.Enabled = enable;
            textBoxInformacjeAdres.Enabled = enable;
            textBoxInformacjeLogin.Enabled = enable;
            textBoxInformacjeHaslo.Enabled = enable;
        }


        private void buttonInformacjeEdytuj_Click(object sender, EventArgs e)
        {
            buttonyInformacjeEnable(false, true, true);
            textBoxesInformacjeEnable(true);
        }

        private void buttonInformacjeAnuluj_Click(object sender, EventArgs e)
        {
            textBoxesInformacjeEnable(false);
            zaladujDanePracownika();
            buttonyInformacjeEnable(true, false, false);
        }

        private void buttonInformacjeZapisz_Click(object sender, EventArgs e)
        {
            try
            {
                int id = zalogowanyPracownik.Id;
                string imie = textBoxInformacjeImie.Text;
                string nazwisko = textBoxInformacjeNazwisko.Text;
                string adres = textBoxInformacjeAdres.Text;
                string login = textBoxInformacjeLogin.Text;
                string haslo = textBoxInformacjeHaslo.Text;
                zalogowanyPracownik = PracownikRepository.EdytujPracownika(id, imie, nazwisko, adres, login, haslo);
                zaladujDanePracownika();
                buttonyInformacjeEnable(true, false, false);
                textBoxesInformacjeEnable(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
