using HurtowniaSprzętuKomputerowego.common;
using HurtowniaSprzętuKomputerowego.db;
using HurtowniaSprzętuKomputerowego.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static HurtowniaSprzętuKomputerowego.model.Sprzedaz;

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
            comboBoxSprzedazeStatus.DataSource = Enum.GetValues(typeof(StatusSprzedazy));
            comboBoxSprzedazeStatus.FormattingEnabled = true;
            comboBoxSprzedazeStatus.Format += delegate (object sender, ListControlConvertEventArgs e)
            {
                string description = "";
                switch ((StatusSprzedazy)e.Value)
                {
                    case StatusSprzedazy.PRZYJETE_DO_REALIZACJI:
                        description = "Pryjęte do realizacji";
                        break;
                    case StatusSprzedazy.W_TRAKCIE:
                        description = "W trakcie";
                        break;
                    case StatusSprzedazy.DO_WYSYLKI:
                        description = "Do wysyłki";
                        break;
                    case StatusSprzedazy.WYSLANE:
                        description = "Wysłane";
                        break;
                }
                e.Value = description;
            };
            zaladujDanePracownika();
            zaladujDostawcow();
            zaladujProdukty();
            zaladujKlientow();
            zaladujSprzedaz();

            #region Dostawcy
            dataGridViewDostawcyListaDostawcow.Columns[0].Name = "id";
            dataGridViewDostawcyListaDostawcow.Columns[0].DataPropertyName = "id";
            dataGridViewDostawcyListaDostawcow.Columns[0].HeaderText = "Id";
            dataGridViewDostawcyListaDostawcow.Columns[0].Visible = false;

            dataGridViewDostawcyListaDostawcow.Columns[1].Name = "nazwa";
            dataGridViewDostawcyListaDostawcow.Columns[1].DataPropertyName = "nazwa";
            dataGridViewDostawcyListaDostawcow.Columns[1].HeaderText = "Nazwa";
            dataGridViewDostawcyListaDostawcow.Columns[1].Visible = true;

            dataGridViewDostawcyListaDostawcow.Columns[2].Name = "informacje_dodatkowe";
            dataGridViewDostawcyListaDostawcow.Columns[2].DataPropertyName = "informacje_dodatkowe";
            dataGridViewDostawcyListaDostawcow.Columns[2].HeaderText = "Informacje";
            dataGridViewDostawcyListaDostawcow.Columns[2].Visible = true;
            #endregion

            #region Produkty
            dataGridViewProduktyListaProduktow.Columns[0].Name = "id";
            dataGridViewProduktyListaProduktow.Columns[0].DataPropertyName = "id";
            dataGridViewProduktyListaProduktow.Columns[0].HeaderText = "Id";
            dataGridViewProduktyListaProduktow.Columns[0].Visible = false;

            dataGridViewProduktyListaProduktow.Columns[1].Name = "nazwa";
            dataGridViewProduktyListaProduktow.Columns[1].DataPropertyName = "nazwa";
            dataGridViewProduktyListaProduktow.Columns[1].HeaderText = "Dostawca";
            dataGridViewProduktyListaProduktow.Columns[1].Visible = true;

            dataGridViewProduktyListaProduktow.Columns[2].Name = "nazwa_sprzetu";
            dataGridViewProduktyListaProduktow.Columns[2].DataPropertyName = "nazwa_sprzetu";
            dataGridViewProduktyListaProduktow.Columns[2].HeaderText = "Nazwa";
            dataGridViewProduktyListaProduktow.Columns[2].Visible = true;

            dataGridViewProduktyListaProduktow.Columns[3].Name = "informacje_dodatkowe";
            dataGridViewProduktyListaProduktow.Columns[3].DataPropertyName = "informacje_dodatkowe";
            dataGridViewProduktyListaProduktow.Columns[3].HeaderText = "Informacje";
            dataGridViewProduktyListaProduktow.Columns[3].Visible = false;

            dataGridViewProduktyListaProduktow.Columns[4].Name = "cena_jednostkowa";
            dataGridViewProduktyListaProduktow.Columns[4].DataPropertyName = "cena_jednostkowa";
            dataGridViewProduktyListaProduktow.Columns[4].HeaderText = "Cena";
            dataGridViewProduktyListaProduktow.Columns[4].Visible = true;

            dataGridViewProduktyListaProduktow.Columns[5].Name = "dostawca_id";
            dataGridViewProduktyListaProduktow.Columns[5].DataPropertyName = "dostawca_id";
            dataGridViewProduktyListaProduktow.Columns[5].HeaderText = "Dostawca Id";
            dataGridViewProduktyListaProduktow.Columns[5].Visible = false;
            #endregion

            #region Klienci
            dataGridViewKlienciListaKlientow.Columns[0].Name = "id";
            dataGridViewKlienciListaKlientow.Columns[0].DataPropertyName = "id";
            dataGridViewKlienciListaKlientow.Columns[0].HeaderText = "Id";
            dataGridViewKlienciListaKlientow.Columns[0].Visible = false;

            dataGridViewKlienciListaKlientow.Columns[1].Name = "imie";
            dataGridViewKlienciListaKlientow.Columns[1].DataPropertyName = "imie";
            dataGridViewKlienciListaKlientow.Columns[1].HeaderText = "Imie";
            dataGridViewKlienciListaKlientow.Columns[1].Visible = true;

            dataGridViewKlienciListaKlientow.Columns[2].Name = "nazwisko";
            dataGridViewKlienciListaKlientow.Columns[2].DataPropertyName = "nazwisko";
            dataGridViewKlienciListaKlientow.Columns[2].HeaderText = "Nazwisko";
            dataGridViewKlienciListaKlientow.Columns[2].Visible = true;

            dataGridViewKlienciListaKlientow.Columns[3].Name = "adres";
            dataGridViewKlienciListaKlientow.Columns[3].DataPropertyName = "adres";
            dataGridViewKlienciListaKlientow.Columns[3].HeaderText = "Adres";
            dataGridViewKlienciListaKlientow.Columns[3].Visible = true;

            dataGridViewKlienciListaKlientow.Columns[4].Name = "login";
            dataGridViewKlienciListaKlientow.Columns[4].DataPropertyName = "login";
            dataGridViewKlienciListaKlientow.Columns[4].HeaderText = "Login";
            dataGridViewKlienciListaKlientow.Columns[4].Visible = true;
            #endregion

            #region Sprzedaż

            DataTable data = SprzedazRepository.PobierzSprzedaze(zalogowanyPracownik.Id);
            EnumsTranformers.TransformSprzedazDataTable(data);
            dataGridViewSprzedazeSprzedaze.DataSource = data;

            dataGridViewSprzedazeKupioneProdukty.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewSprzedazeSprzedaze.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dataGridViewSprzedazeSprzedaze.Columns[0].Name = "id";
            dataGridViewSprzedazeSprzedaze.Columns[0].DataPropertyName = "id";
            dataGridViewSprzedazeSprzedaze.Columns[0].HeaderText = "Id";
            dataGridViewSprzedazeSprzedaze.Columns[0].Visible = false;

            dataGridViewSprzedazeSprzedaze.Columns[1].Name = "klient_id";
            dataGridViewSprzedazeSprzedaze.Columns[1].DataPropertyName = "klient_id";
            dataGridViewSprzedazeSprzedaze.Columns[1].HeaderText = "Klient Id";
            dataGridViewSprzedazeSprzedaze.Columns[1].Visible = false;

            dataGridViewSprzedazeSprzedaze.Columns[2].Name = "status";
            dataGridViewSprzedazeSprzedaze.Columns[2].DataPropertyName = "status";
            dataGridViewSprzedazeSprzedaze.Columns[2].HeaderText = "Status";
            dataGridViewSprzedazeSprzedaze.Columns[2].Visible = false;

            dataGridViewSprzedazeSprzedaze.Columns[3].Name = "suma";
            dataGridViewSprzedazeSprzedaze.Columns[3].DataPropertyName = "suma";
            dataGridViewSprzedazeSprzedaze.Columns[3].HeaderText = "Suma";
            dataGridViewSprzedazeSprzedaze.Columns[3].Visible = true;

            dataGridViewSprzedazeSprzedaze.Columns[4].Name = "data_sprzedazy";
            dataGridViewSprzedazeSprzedaze.Columns[4].DataPropertyName = "data_sprzedazy";
            dataGridViewSprzedazeSprzedaze.Columns[4].HeaderText = "Data sprzedaży";
            dataGridViewSprzedazeSprzedaze.Columns[4].Visible = true;
            #endregion
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
                DataTable data = SprzedazRepository.PobierzSprzedaze(zalogowanyPracownik.Id);
                EnumsTranformers.TransformSprzedazDataTable(data);
                dataGridViewSprzedazeSprzedaze.DataSource = data;
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

            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[0].Name = "id";
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[0].DataPropertyName = "id";
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[0].HeaderText = "Id";
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[0].Visible = false;

            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[1].Name = "nazwa";
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[1].DataPropertyName = "nazwa";
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[1].HeaderText = "Dostawca";
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[1].Visible = false;

            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[2].Name = "nazwa_sprzetu";
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[2].DataPropertyName = "nazwa_sprzetu";
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[2].HeaderText = "Nazwa";
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[2].Visible = true;

            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[3].Name = "informacje_dodatkowe";
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[3].DataPropertyName = "informacje_dodatkowe";
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[3].HeaderText = "Informacje";
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[3].Visible = true;

            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[4].Name = "cena_jednostkowa";
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[4].DataPropertyName = "cena_jednostkowa";
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[4].HeaderText = "Cena";
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[4].Visible = true;

            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[5].Name = "dostawca_id";
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[5].DataPropertyName = "dostawca_id";
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[5].HeaderText = "Dostawca id";
            dataGridViewDostawcyProduktyOferowanePrzezDostawce.Columns[5].Visible = false;

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

                dataGridViewKlienciKupnaKlienta.Columns[0].Name = "id";
                dataGridViewKlienciKupnaKlienta.Columns[0].DataPropertyName = "id";
                dataGridViewKlienciKupnaKlienta.Columns[0].HeaderText = "Id";
                dataGridViewKlienciKupnaKlienta.Columns[0].Visible = false;

                dataGridViewKlienciKupnaKlienta.Columns[1].Name = "klient_id";
                dataGridViewKlienciKupnaKlienta.Columns[1].DataPropertyName = "klient_id";
                dataGridViewKlienciKupnaKlienta.Columns[1].HeaderText = "Klient Id";
                dataGridViewKlienciKupnaKlienta.Columns[1].Visible = false;

                dataGridViewKlienciKupnaKlienta.Columns[2].Name = "status";
                dataGridViewKlienciKupnaKlienta.Columns[2].DataPropertyName = "status";
                dataGridViewKlienciKupnaKlienta.Columns[2].HeaderText = "Status";
                dataGridViewKlienciKupnaKlienta.Columns[2].Visible = true;

                dataGridViewKlienciKupnaKlienta.Columns[3].Name = "suma";
                dataGridViewKlienciKupnaKlienta.Columns[3].DataPropertyName = "suma";
                dataGridViewKlienciKupnaKlienta.Columns[3].HeaderText = "Suma";
                dataGridViewKlienciKupnaKlienta.Columns[3].Visible = true;

                dataGridViewKlienciKupnaKlienta.Columns[4].Name = "data_sprzedazy";
                dataGridViewKlienciKupnaKlienta.Columns[4].DataPropertyName = "data_sprzedazy";
                dataGridViewKlienciKupnaKlienta.Columns[4].HeaderText = "Data sprzedaży";
                dataGridViewKlienciKupnaKlienta.Columns[4].Visible = true;
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

                dataGridViewSprzedazeKupioneProdukty.Columns[0].Name = "id";
                dataGridViewSprzedazeKupioneProdukty.Columns[0].DataPropertyName = "id";
                dataGridViewSprzedazeKupioneProdukty.Columns[0].HeaderText = "Id";
                dataGridViewSprzedazeKupioneProdukty.Columns[0].Visible = false;

                dataGridViewSprzedazeKupioneProdukty.Columns[1].Name = "sprzedaz_id";
                dataGridViewSprzedazeKupioneProdukty.Columns[1].DataPropertyName = "sprzedaz_id";
                dataGridViewSprzedazeKupioneProdukty.Columns[1].HeaderText = "Sprzedaż Id";
                dataGridViewSprzedazeKupioneProdukty.Columns[1].Visible = false;

                dataGridViewSprzedazeKupioneProdukty.Columns[2].Name = "produkt_id";
                dataGridViewSprzedazeKupioneProdukty.Columns[2].DataPropertyName = "produkt_id";
                dataGridViewSprzedazeKupioneProdukty.Columns[2].HeaderText = "Produkt Id";
                dataGridViewSprzedazeKupioneProdukty.Columns[2].Visible = false;

                dataGridViewSprzedazeKupioneProdukty.Columns[3].Name = "zamowiona_ilosc";
                dataGridViewSprzedazeKupioneProdukty.Columns[3].DataPropertyName = "zamowiona_ilosc";
                dataGridViewSprzedazeKupioneProdukty.Columns[3].HeaderText = "Zamowiona ilość";
                dataGridViewSprzedazeKupioneProdukty.Columns[3].Visible = true;

                dataGridViewSprzedazeKupioneProdukty.Columns[4].Name = "wartosc";
                dataGridViewSprzedazeKupioneProdukty.Columns[4].DataPropertyName = "wartosc";
                dataGridViewSprzedazeKupioneProdukty.Columns[4].HeaderText = "Wartość";
                dataGridViewSprzedazeKupioneProdukty.Columns[4].Visible = true;

                dataGridViewSprzedazeKupioneProdukty.Columns[5].Name = "id1";
                dataGridViewSprzedazeKupioneProdukty.Columns[5].DataPropertyName = "id1";
                dataGridViewSprzedazeKupioneProdukty.Columns[5].HeaderText = "id1";
                dataGridViewSprzedazeKupioneProdukty.Columns[5].Visible = false;

                dataGridViewSprzedazeKupioneProdukty.Columns[6].Name = "dostawca_id";
                dataGridViewSprzedazeKupioneProdukty.Columns[6].DataPropertyName = "dostawca_id";
                dataGridViewSprzedazeKupioneProdukty.Columns[6].HeaderText = "Dostawca Id";
                dataGridViewSprzedazeKupioneProdukty.Columns[6].Visible = false;

                dataGridViewSprzedazeKupioneProdukty.Columns[7].Name = "nazwa_sprzetu";
                dataGridViewSprzedazeKupioneProdukty.Columns[7].DataPropertyName = "nazwa_sprzetu";
                dataGridViewSprzedazeKupioneProdukty.Columns[7].HeaderText = "Nazwa";
                dataGridViewSprzedazeKupioneProdukty.Columns[7].Visible = true;

                dataGridViewSprzedazeKupioneProdukty.Columns[8].Name = "informacje_dodatkowe";
                dataGridViewSprzedazeKupioneProdukty.Columns[8].DataPropertyName = "informacje_dodatkowe";
                dataGridViewSprzedazeKupioneProdukty.Columns[8].HeaderText = "Informacje";
                dataGridViewSprzedazeKupioneProdukty.Columns[8].Visible = false;

                dataGridViewSprzedazeKupioneProdukty.Columns[9].Name = "cena_jednostkowa";
                dataGridViewSprzedazeKupioneProdukty.Columns[9].DataPropertyName = "cena_jednostkowa";
                dataGridViewSprzedazeKupioneProdukty.Columns[9].HeaderText = "Cena";
                dataGridViewSprzedazeKupioneProdukty.Columns[9].Visible = false;
            }
            catch (Exception ex) {}
        }

        private void buttonSprzedazeZmien_Click(object sender, EventArgs e)
        {
            try
            {
                int id = DataGridViewUtil.pobierzWybranyId(dataGridViewSprzedazeSprzedaze);
                int status = (int)(StatusSprzedazy)comboBoxSprzedazeStatus.SelectedItem;
                SprzedazRepository.EdytujSprzedaz(id, status);
                zaladujSprzedaz();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                textBoxInformacjeHaslo.Text = "";
                buttonyInformacjeEnable(true, false, false);
                textBoxesInformacjeEnable(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void FormPracownik_Load(object sender, EventArgs e)
        {
            
        }

     
    }
}
