﻿using HurtowniaSprzętuKomputerowego.common;
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
    public partial class FormKlient : Form
    {
        public static string output = "{0,-50}\t{1,-50}\t{2,-50}";
        Klient zalogowanyKlient;

        public FormKlient(Klient klient)
        {
            zalogowanyKlient = klient;
            InitializeComponent();
        }

        private void FormKlient_Load(object sender, EventArgs e)
        {
            ZaladujProdukty();
            DodajKolumneDoListy();
        }

        private void ZaladujProdukty()
        {
            try
            {
                UzupełnijDGVProdukty();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UzupełnijDGVProdukty()
        {
            dataGridViewProdukty.DataSource = ProduktRepository.PobierzProduktyTabelaKlient();
            dataGridViewProdukty.Columns["id"].Visible = false;
            dataGridViewProdukty.Columns["informacje_dodatkowe"].Visible = false;
            dataGridViewProdukty.Columns[1].HeaderText = "Nazwa produktu";
            dataGridViewProdukty.Columns[2].HeaderText = "Cena za 1 szt";
            dataGridViewProdukty.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void buttonWyswietlInformacjeDodatkowe_Click(object sender, EventArgs e)
        {
            try
            {
                string informacje = (string)DataGridViewUtil.pobierzWybranaWartoscKloumny(dataGridViewProdukty, "informacje_dodatkowe");
                labelInfoOProdukcie.Visible = true;
                textBoxInfoOProdukcie.Text = informacje;
                textBoxInfoOProdukcie.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonDodajDoKoszyka_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewProdukty.SelectedRows.Count != 1)
                {
                    throw new Exception("Nalezy wybrać tylko jeden wiersz");
                }
                DataGridViewRow row = dataGridViewProdukty.SelectedRows[0];
                Produkt produkt = new Produkt((int)row.Cells[0].Value, (string)row.Cells[1].Value, (string)row.Cells[3].Value, (decimal)row.Cells[2].Value);
                listBoxKoszyk.Items.Add(produkt);
                dataGridViewProdukty.Rows.Remove(row);
                PoliczCeneIIloscProduktowWKoszyku();
                MessageBox.Show("Produkt został dodany do koszyka");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridViewProdukty_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                e.Value = Math.Round((decimal)e.Value, 2); ;
            }

        }

        private void DodajKolumneDoListy()
        {
            listBoxKoszyk.Items.Add(String.Format(output, "Nazwa", "Ilość", "Cena"));

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            int index = listBoxKoszyk.SelectedIndex;
            if (listBoxKoszyk.SelectedItem.GetType().Equals(typeof(Produkt)))
            {
                Produkt produkt = ((Produkt)listBoxKoszyk.Items[index]);
                int poprzedniaIlosc = produkt.Ilosc;
                produkt.Ilosc = (int)numericUpDownZmienIlosc.Value;
                if (poprzedniaIlosc == produkt.Ilosc)
                {
                    return;
                }
                odswiezListBoxIndex(index, produkt);
                PoliczCeneIIloscProduktowWKoszyku();
                listBoxKoszyk.SelectedIndex = index;
            }

        }

        private void odswiezListBoxIndex(int index, Produkt produkt)
        {
            listBoxKoszyk.Items.RemoveAt(index);
            listBoxKoszyk.Items.Insert(index, produkt);
        }

        private void PoliczCeneIIloscProduktowWKoszyku()
        {
            decimal cenaZamowienia = 0;
            int ilosc = 0;
            if (listBoxKoszyk.Items.Count > 0)
            {
                foreach (var item in listBoxKoszyk.Items)
                {
                    if (item.GetType().Equals(typeof(Produkt)))
                    {

                        Produkt produkt = ((Produkt)item);
                        ilosc += produkt.Ilosc;
                        cenaZamowienia += Math.Round(produkt.Ilosc * produkt.CenaJednostkowa, 2);
                    }
                }

                labelCenaZamowienia.Text = cenaZamowienia.ToString();
                labelCenaZamowienia.Visible = true;
                labelCenaText.Visible = true;

                labelIloscProduktow.Text = ilosc.ToString();
                labelIloscProduktow.Visible = true;
                labelIloscText.Visible = true;
            }
        }



        private void listBoxKoszyk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxKoszyk.SelectedItem is object)
            {
                if (listBoxKoszyk.SelectedItem.GetType().Equals(typeof(Produkt))) {
                    numericUpDownZmienIlosc.Visible = true;
                    labelZmienIlosc.Visible = true;
                    numericUpDownZmienIlosc.Value = ((Produkt)listBoxKoszyk.SelectedItem).Ilosc;
                }
                else {
                    numericUpDownZmienIlosc.Visible = false;
                    labelZmienIlosc.Visible = false;
                }
            }
        }
        
        private void buttonUsunZKoszyka_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxKoszyk.SelectedIndex < 0)
                {
                    throw new ApplicationException("Wybierz produkt z koszyka");
                }

                var produkt = (Produkt)listBoxKoszyk.SelectedItem;
                DataTable table = (DataTable)dataGridViewProdukty.DataSource;
                table.Rows.Add(produkt.Id, produkt.NazwaSprzetu, produkt.CenaJednostkowa, produkt.InformacjeDodatkowe);
                listBoxKoszyk.Items.Remove(listBoxKoszyk.SelectedItem);
                produkt = null;
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonWyslijZamówienie_Click(object sender, EventArgs e)
        {
            try
            {
               

                int idSprzedazy = SprzedazRepository.PobierzMaxIdSprzedazy() + 1;
                List<PozycjaSprzedazy> pozycjeSprzedazy = StworzPozycje(idSprzedazy); 
                if (pozycjeSprzedazy.Count==0)
                {
                    MessageBox.Show("Brak produktów w koszyku");
                    return;
                }
                Sprzedaz sprzedaz = new Sprzedaz(idSprzedazy, zalogowanyKlient.Id, Sprzedaz.StatusSprzedazy.PRZYJETE_DO_REALIZACJI, policzWartośćProduktów(pozycjeSprzedazy), DateTime.Now);
                SprzedazRepository.DodajSprzedaz(sprzedaz.Id, sprzedaz.KlientId, (int)sprzedaz.Status, sprzedaz.Suma, sprzedaz.DataSprzedazy);
                PozycjaSprzedazyRepository.DodajPozycje(pozycjeSprzedazy);
                MessageBox.Show("Pomyslnie wysłano twoje zamówienie");
                listBoxKoszyk.Items.Clear();
                UzupełnijDGVProdukty();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
       
          
        }


        private List<PozycjaSprzedazy> StworzPozycje(int maxIdSprzedazy)
        {
            List<PozycjaSprzedazy> pozycjeSprzedazy = new List<PozycjaSprzedazy>();
            foreach (var item in listBoxKoszyk.Items)
            {
                if (item.GetType().Equals(typeof(Produkt)))
                    {
                    var produkt = (Produkt)item;
                    pozycjeSprzedazy.Add(new PozycjaSprzedazy(maxIdSprzedazy, produkt.Id, produkt.Ilosc, produkt.Ilosc * produkt.CenaJednostkowa));
                }


            }

            return pozycjeSprzedazy;


           
        }

        private decimal policzWartośćProduktów(List<PozycjaSprzedazy> pozycjeSprzedazy)
        {
            decimal wartoscZamowienia = 0;
            foreach (PozycjaSprzedazy pozycja in pozycjeSprzedazy)
            {
                wartoscZamowienia += pozycja.Wartosc;
            }
            return wartoscZamowienia;
        }
    }
}
