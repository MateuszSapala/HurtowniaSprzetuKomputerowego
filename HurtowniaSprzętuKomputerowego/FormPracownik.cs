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
        }

        private void buttonDostawcyDodajDostawce_Click(object sender, EventArgs e)
        {
            string nazwaDostawcy = textBoxDostawcyNazwaDostawcy.Text;
            string informacjeDodatkowe = textBoxDostawcyInformacjeDodatkowe.Text;
            PracownikRepository.DodajDostawce(nazwaDostawcy, informacjeDodatkowe);
        }
    }
}
