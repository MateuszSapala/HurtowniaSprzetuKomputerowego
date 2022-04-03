
namespace HurtowniaSprzętuKomputerowego
{
    partial class FormKlient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPageHistoria = new System.Windows.Forms.TabPage();
            this.splitContainerSprzedaze = new System.Windows.Forms.SplitContainer();
            this.groupBoxSprzedazeSprzedaze = new System.Windows.Forms.GroupBox();
            this.dataGridViewHistoria = new System.Windows.Forms.DataGridView();
            this.groupBoxSprzedazeKupioneProdukty = new System.Windows.Forms.GroupBox();
            this.dataGridViewSprzedazeKupioneProdukty = new System.Windows.Forms.DataGridView();
            this.tabPageKoszyk = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelIloscProduktow = new System.Windows.Forms.Label();
            this.labelCenaZamowienia = new System.Windows.Forms.Label();
            this.labelCenaText = new System.Windows.Forms.Label();
            this.labelIloscText = new System.Windows.Forms.Label();
            this.labelZmienIlosc = new System.Windows.Forms.Label();
            this.numericUpDownZmienIlosc = new System.Windows.Forms.NumericUpDown();
            this.buttonWyslijZamówienie = new System.Windows.Forms.Button();
            this.buttonUsunZKoszyka = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxKoszyk = new System.Windows.Forms.ListBox();
            this.tabPageProdukty = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxInfoOProdukcie = new System.Windows.Forms.TextBox();
            this.labelInfoOProdukcie = new System.Windows.Forms.Label();
            this.buttonWyswietlInformacjeDodatkowe = new System.Windows.Forms.Button();
            this.buttonDodajDoKoszyka = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewProdukty = new System.Windows.Forms.DataGridView();
            this.tabControlKlient = new System.Windows.Forms.TabControl();
            this.tabPageInformacje = new System.Windows.Forms.TabPage();
            this.groupBoxInformacjeTwojeDane = new System.Windows.Forms.GroupBox();
            this.labelInformacjeAdres = new System.Windows.Forms.Label();
            this.labelInformacjeHaslo = new System.Windows.Forms.Label();
            this.labelinformacjeLogin = new System.Windows.Forms.Label();
            this.textBoxHaslo = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxAdres = new System.Windows.Forms.TextBox();
            this.textBoxNazwisko = new System.Windows.Forms.TextBox();
            this.buttonZapisz = new System.Windows.Forms.Button();
            this.buttonAnuluj = new System.Windows.Forms.Button();
            this.labelInformacjeNazwisko = new System.Windows.Forms.Label();
            this.buttonEdytuj = new System.Windows.Forms.Button();
            this.textBoxImie = new System.Windows.Forms.TextBox();
            this.labelInformacjeImie = new System.Windows.Forms.Label();
            this.tabPageHistoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSprzedaze)).BeginInit();
            this.splitContainerSprzedaze.Panel1.SuspendLayout();
            this.splitContainerSprzedaze.Panel2.SuspendLayout();
            this.splitContainerSprzedaze.SuspendLayout();
            this.groupBoxSprzedazeSprzedaze.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistoria)).BeginInit();
            this.groupBoxSprzedazeKupioneProdukty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSprzedazeKupioneProdukty)).BeginInit();
            this.tabPageKoszyk.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZmienIlosc)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPageProdukty.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdukty)).BeginInit();
            this.tabControlKlient.SuspendLayout();
            this.tabPageInformacje.SuspendLayout();
            this.groupBoxInformacjeTwojeDane.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageHistoria
            // 
            this.tabPageHistoria.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPageHistoria.Controls.Add(this.splitContainerSprzedaze);
            this.tabPageHistoria.Location = new System.Drawing.Point(4, 30);
            this.tabPageHistoria.Name = "tabPageHistoria";
            this.tabPageHistoria.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHistoria.Size = new System.Drawing.Size(992, 566);
            this.tabPageHistoria.TabIndex = 8;
            this.tabPageHistoria.Text = "Historia";
            // 
            // splitContainerSprzedaze
            // 
            this.splitContainerSprzedaze.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainerSprzedaze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSprzedaze.Location = new System.Drawing.Point(3, 3);
            this.splitContainerSprzedaze.Name = "splitContainerSprzedaze";
            // 
            // splitContainerSprzedaze.Panel1
            // 
            this.splitContainerSprzedaze.Panel1.Controls.Add(this.groupBoxSprzedazeSprzedaze);
            // 
            // splitContainerSprzedaze.Panel2
            // 
            this.splitContainerSprzedaze.Panel2.Controls.Add(this.groupBoxSprzedazeKupioneProdukty);
            this.splitContainerSprzedaze.Size = new System.Drawing.Size(986, 560);
            this.splitContainerSprzedaze.SplitterDistance = 486;
            this.splitContainerSprzedaze.TabIndex = 4;
            // 
            // groupBoxSprzedazeSprzedaze
            // 
            this.groupBoxSprzedazeSprzedaze.Controls.Add(this.dataGridViewHistoria);
            this.groupBoxSprzedazeSprzedaze.Location = new System.Drawing.Point(18, 15);
            this.groupBoxSprzedazeSprzedaze.Name = "groupBoxSprzedazeSprzedaze";
            this.groupBoxSprzedazeSprzedaze.Size = new System.Drawing.Size(450, 520);
            this.groupBoxSprzedazeSprzedaze.TabIndex = 5;
            this.groupBoxSprzedazeSprzedaze.TabStop = false;
            this.groupBoxSprzedazeSprzedaze.Text = "Sprzedaże";
            // 
            // dataGridViewHistoria
            // 
            this.dataGridViewHistoria.AllowUserToAddRows = false;
            this.dataGridViewHistoria.AllowUserToDeleteRows = false;
            this.dataGridViewHistoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewHistoria.Location = new System.Drawing.Point(3, 25);
            this.dataGridViewHistoria.MultiSelect = false;
            this.dataGridViewHistoria.Name = "dataGridViewHistoria";
            this.dataGridViewHistoria.RowTemplate.Height = 25;
            this.dataGridViewHistoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHistoria.Size = new System.Drawing.Size(444, 492);
            this.dataGridViewHistoria.TabIndex = 0;
            // 
            // groupBoxSprzedazeKupioneProdukty
            // 
            this.groupBoxSprzedazeKupioneProdukty.Controls.Add(this.dataGridViewSprzedazeKupioneProdukty);
            this.groupBoxSprzedazeKupioneProdukty.Location = new System.Drawing.Point(25, 15);
            this.groupBoxSprzedazeKupioneProdukty.Name = "groupBoxSprzedazeKupioneProdukty";
            this.groupBoxSprzedazeKupioneProdukty.Size = new System.Drawing.Size(452, 520);
            this.groupBoxSprzedazeKupioneProdukty.TabIndex = 0;
            this.groupBoxSprzedazeKupioneProdukty.TabStop = false;
            this.groupBoxSprzedazeKupioneProdukty.Text = "Kupione produkty";
            // 
            // dataGridViewSprzedazeKupioneProdukty
            // 
            this.dataGridViewSprzedazeKupioneProdukty.AllowUserToAddRows = false;
            this.dataGridViewSprzedazeKupioneProdukty.AllowUserToDeleteRows = false;
            this.dataGridViewSprzedazeKupioneProdukty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSprzedazeKupioneProdukty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSprzedazeKupioneProdukty.Location = new System.Drawing.Point(3, 25);
            this.dataGridViewSprzedazeKupioneProdukty.MultiSelect = false;
            this.dataGridViewSprzedazeKupioneProdukty.Name = "dataGridViewSprzedazeKupioneProdukty";
            this.dataGridViewSprzedazeKupioneProdukty.RowTemplate.Height = 25;
            this.dataGridViewSprzedazeKupioneProdukty.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSprzedazeKupioneProdukty.Size = new System.Drawing.Size(446, 492);
            this.dataGridViewSprzedazeKupioneProdukty.TabIndex = 1;
            // 
            // tabPageKoszyk
            // 
            this.tabPageKoszyk.Controls.Add(this.panel2);
            this.tabPageKoszyk.Controls.Add(this.groupBox2);
            this.tabPageKoszyk.Location = new System.Drawing.Point(4, 30);
            this.tabPageKoszyk.Name = "tabPageKoszyk";
            this.tabPageKoszyk.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageKoszyk.Size = new System.Drawing.Size(992, 566);
            this.tabPageKoszyk.TabIndex = 1;
            this.tabPageKoszyk.Text = "Koszyk";
            this.tabPageKoszyk.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelIloscProduktow);
            this.panel2.Controls.Add(this.labelCenaZamowienia);
            this.panel2.Controls.Add(this.labelCenaText);
            this.panel2.Controls.Add(this.labelIloscText);
            this.panel2.Controls.Add(this.labelZmienIlosc);
            this.panel2.Controls.Add(this.numericUpDownZmienIlosc);
            this.panel2.Controls.Add(this.buttonWyslijZamówienie);
            this.panel2.Controls.Add(this.buttonUsunZKoszyka);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(649, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 560);
            this.panel2.TabIndex = 1;
            // 
            // labelIloscProduktow
            // 
            this.labelIloscProduktow.AutoSize = true;
            this.labelIloscProduktow.Location = new System.Drawing.Point(238, 393);
            this.labelIloscProduktow.Name = "labelIloscProduktow";
            this.labelIloscProduktow.Size = new System.Drawing.Size(52, 21);
            this.labelIloscProduktow.TabIndex = 7;
            this.labelIloscProduktow.Text = "label5";
            this.labelIloscProduktow.Visible = false;
            // 
            // labelCenaZamowienia
            // 
            this.labelCenaZamowienia.AutoSize = true;
            this.labelCenaZamowienia.Location = new System.Drawing.Point(151, 439);
            this.labelCenaZamowienia.Name = "labelCenaZamowienia";
            this.labelCenaZamowienia.Size = new System.Drawing.Size(52, 21);
            this.labelCenaZamowienia.TabIndex = 6;
            this.labelCenaZamowienia.Text = "label4";
            this.labelCenaZamowienia.Visible = false;
            // 
            // labelCenaText
            // 
            this.labelCenaText.AutoSize = true;
            this.labelCenaText.Location = new System.Drawing.Point(4, 439);
            this.labelCenaText.Name = "labelCenaText";
            this.labelCenaText.Size = new System.Drawing.Size(141, 21);
            this.labelCenaText.TabIndex = 5;
            this.labelCenaText.Text = "Cena Zamówienia: ";
            this.labelCenaText.Visible = false;
            // 
            // labelIloscText
            // 
            this.labelIloscText.AutoSize = true;
            this.labelIloscText.Location = new System.Drawing.Point(4, 393);
            this.labelIloscText.Name = "labelIloscText";
            this.labelIloscText.Size = new System.Drawing.Size(228, 21);
            this.labelIloscText.TabIndex = 4;
            this.labelIloscText.Text = "Ilość zamówionych produktów: ";
            this.labelIloscText.Visible = false;
            // 
            // labelZmienIlosc
            // 
            this.labelZmienIlosc.AutoSize = true;
            this.labelZmienIlosc.Location = new System.Drawing.Point(4, 4);
            this.labelZmienIlosc.Name = "labelZmienIlosc";
            this.labelZmienIlosc.Size = new System.Drawing.Size(96, 21);
            this.labelZmienIlosc.TabIndex = 3;
            this.labelZmienIlosc.Text = "Zmień ilość: ";
            this.labelZmienIlosc.Visible = false;
            // 
            // numericUpDownZmienIlosc
            // 
            this.numericUpDownZmienIlosc.Location = new System.Drawing.Point(106, 2);
            this.numericUpDownZmienIlosc.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownZmienIlosc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownZmienIlosc.Name = "numericUpDownZmienIlosc";
            this.numericUpDownZmienIlosc.Size = new System.Drawing.Size(120, 29);
            this.numericUpDownZmienIlosc.TabIndex = 2;
            this.numericUpDownZmienIlosc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownZmienIlosc.Visible = false;
            this.numericUpDownZmienIlosc.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // buttonWyslijZamówienie
            // 
            this.buttonWyslijZamówienie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonWyslijZamówienie.Location = new System.Drawing.Point(0, 502);
            this.buttonWyslijZamówienie.Name = "buttonWyslijZamówienie";
            this.buttonWyslijZamówienie.Size = new System.Drawing.Size(340, 29);
            this.buttonWyslijZamówienie.TabIndex = 1;
            this.buttonWyslijZamówienie.Text = "Wyślij zamówienie";
            this.buttonWyslijZamówienie.UseVisualStyleBackColor = true;
            this.buttonWyslijZamówienie.Click += new System.EventHandler(this.buttonWyslijZamówienie_Click);
            // 
            // buttonUsunZKoszyka
            // 
            this.buttonUsunZKoszyka.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonUsunZKoszyka.Location = new System.Drawing.Point(0, 531);
            this.buttonUsunZKoszyka.Name = "buttonUsunZKoszyka";
            this.buttonUsunZKoszyka.Size = new System.Drawing.Size(340, 29);
            this.buttonUsunZKoszyka.TabIndex = 0;
            this.buttonUsunZKoszyka.Text = "Usuń z koszyka";
            this.buttonUsunZKoszyka.UseVisualStyleBackColor = true;
            this.buttonUsunZKoszyka.Click += new System.EventHandler(this.buttonUsunZKoszyka_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxKoszyk);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(644, 566);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Koszyk";
            // 
            // listBoxKoszyk
            // 
            this.listBoxKoszyk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxKoszyk.FormattingEnabled = true;
            this.listBoxKoszyk.ItemHeight = 21;
            this.listBoxKoszyk.Location = new System.Drawing.Point(3, 25);
            this.listBoxKoszyk.Name = "listBoxKoszyk";
            this.listBoxKoszyk.Size = new System.Drawing.Size(638, 538);
            this.listBoxKoszyk.TabIndex = 0;
            this.listBoxKoszyk.SelectedIndexChanged += new System.EventHandler(this.listBoxKoszyk_SelectedIndexChanged);
            // 
            // tabPageProdukty
            // 
            this.tabPageProdukty.Controls.Add(this.panel1);
            this.tabPageProdukty.Controls.Add(this.groupBox1);
            this.tabPageProdukty.Location = new System.Drawing.Point(4, 30);
            this.tabPageProdukty.Name = "tabPageProdukty";
            this.tabPageProdukty.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProdukty.Size = new System.Drawing.Size(992, 566);
            this.tabPageProdukty.TabIndex = 0;
            this.tabPageProdukty.Text = "Produkty";
            this.tabPageProdukty.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxInfoOProdukcie);
            this.panel1.Controls.Add(this.labelInfoOProdukcie);
            this.panel1.Controls.Add(this.buttonWyswietlInformacjeDodatkowe);
            this.panel1.Controls.Add(this.buttonDodajDoKoszyka);
            this.panel1.Location = new System.Drawing.Point(504, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 563);
            this.panel1.TabIndex = 1;
            // 
            // textBoxInfoOProdukcie
            // 
            this.textBoxInfoOProdukcie.Location = new System.Drawing.Point(4, 28);
            this.textBoxInfoOProdukcie.Multiline = true;
            this.textBoxInfoOProdukcie.Name = "textBoxInfoOProdukcie";
            this.textBoxInfoOProdukcie.ReadOnly = true;
            this.textBoxInfoOProdukcie.Size = new System.Drawing.Size(484, 172);
            this.textBoxInfoOProdukcie.TabIndex = 4;
            this.textBoxInfoOProdukcie.Visible = false;
            // 
            // labelInfoOProdukcie
            // 
            this.labelInfoOProdukcie.AutoSize = true;
            this.labelInfoOProdukcie.Location = new System.Drawing.Point(3, 0);
            this.labelInfoOProdukcie.Name = "labelInfoOProdukcie";
            this.labelInfoOProdukcie.Size = new System.Drawing.Size(173, 21);
            this.labelInfoOProdukcie.TabIndex = 3;
            this.labelInfoOProdukcie.Text = "Informacje o produkcie:";
            this.labelInfoOProdukcie.Visible = false;
            // 
            // buttonWyswietlInformacjeDodatkowe
            // 
            this.buttonWyswietlInformacjeDodatkowe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonWyswietlInformacjeDodatkowe.Location = new System.Drawing.Point(0, 485);
            this.buttonWyswietlInformacjeDodatkowe.Name = "buttonWyswietlInformacjeDodatkowe";
            this.buttonWyswietlInformacjeDodatkowe.Size = new System.Drawing.Size(488, 39);
            this.buttonWyswietlInformacjeDodatkowe.TabIndex = 2;
            this.buttonWyswietlInformacjeDodatkowe.Text = "Wyświetl informacje dodatkowe";
            this.buttonWyswietlInformacjeDodatkowe.UseVisualStyleBackColor = true;
            this.buttonWyswietlInformacjeDodatkowe.Click += new System.EventHandler(this.buttonWyswietlInformacjeDodatkowe_Click);
            // 
            // buttonDodajDoKoszyka
            // 
            this.buttonDodajDoKoszyka.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonDodajDoKoszyka.Location = new System.Drawing.Point(0, 524);
            this.buttonDodajDoKoszyka.Name = "buttonDodajDoKoszyka";
            this.buttonDodajDoKoszyka.Size = new System.Drawing.Size(488, 39);
            this.buttonDodajDoKoszyka.TabIndex = 0;
            this.buttonDodajDoKoszyka.Text = "Dodaj do koszyka";
            this.buttonDodajDoKoszyka.UseVisualStyleBackColor = true;
            this.buttonDodajDoKoszyka.Click += new System.EventHandler(this.buttonDodajDoKoszyka_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewProdukty);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 560);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tabela Produktów";
            // 
            // dataGridViewProdukty
            // 
            this.dataGridViewProdukty.AllowUserToAddRows = false;
            this.dataGridViewProdukty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProdukty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProdukty.Location = new System.Drawing.Point(3, 25);
            this.dataGridViewProdukty.MultiSelect = false;
            this.dataGridViewProdukty.Name = "dataGridViewProdukty";
            this.dataGridViewProdukty.RowTemplate.Height = 25;
            this.dataGridViewProdukty.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProdukty.Size = new System.Drawing.Size(492, 532);
            this.dataGridViewProdukty.TabIndex = 0;
            this.dataGridViewProdukty.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewProdukty_CellFormatting);
            // 
            // tabControlKlient
            // 
            this.tabControlKlient.Controls.Add(this.tabPageProdukty);
            this.tabControlKlient.Controls.Add(this.tabPageKoszyk);
            this.tabControlKlient.Controls.Add(this.tabPageHistoria);
            this.tabControlKlient.Controls.Add(this.tabPageInformacje);
            this.tabControlKlient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlKlient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControlKlient.Location = new System.Drawing.Point(0, 0);
            this.tabControlKlient.Name = "tabControlKlient";
            this.tabControlKlient.SelectedIndex = 0;
            this.tabControlKlient.Size = new System.Drawing.Size(1000, 600);
            this.tabControlKlient.TabIndex = 0;
            // 
            // tabPageInformacje
            // 
            this.tabPageInformacje.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPageInformacje.Controls.Add(this.groupBoxInformacjeTwojeDane);
            this.tabPageInformacje.Location = new System.Drawing.Point(4, 30);
            this.tabPageInformacje.Name = "tabPageInformacje";
            this.tabPageInformacje.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInformacje.Size = new System.Drawing.Size(992, 566);
            this.tabPageInformacje.TabIndex = 10;
            this.tabPageInformacje.Text = "Informacje";
            // 
            // groupBoxInformacjeTwojeDane
            // 
            this.groupBoxInformacjeTwojeDane.Controls.Add(this.labelInformacjeAdres);
            this.groupBoxInformacjeTwojeDane.Controls.Add(this.labelInformacjeHaslo);
            this.groupBoxInformacjeTwojeDane.Controls.Add(this.labelinformacjeLogin);
            this.groupBoxInformacjeTwojeDane.Controls.Add(this.textBoxHaslo);
            this.groupBoxInformacjeTwojeDane.Controls.Add(this.textBoxLogin);
            this.groupBoxInformacjeTwojeDane.Controls.Add(this.textBoxAdres);
            this.groupBoxInformacjeTwojeDane.Controls.Add(this.textBoxNazwisko);
            this.groupBoxInformacjeTwojeDane.Controls.Add(this.buttonZapisz);
            this.groupBoxInformacjeTwojeDane.Controls.Add(this.buttonAnuluj);
            this.groupBoxInformacjeTwojeDane.Controls.Add(this.labelInformacjeNazwisko);
            this.groupBoxInformacjeTwojeDane.Controls.Add(this.buttonEdytuj);
            this.groupBoxInformacjeTwojeDane.Controls.Add(this.textBoxImie);
            this.groupBoxInformacjeTwojeDane.Controls.Add(this.labelInformacjeImie);
            this.groupBoxInformacjeTwojeDane.Location = new System.Drawing.Point(271, 133);
            this.groupBoxInformacjeTwojeDane.Name = "groupBoxInformacjeTwojeDane";
            this.groupBoxInformacjeTwojeDane.Size = new System.Drawing.Size(450, 323);
            this.groupBoxInformacjeTwojeDane.TabIndex = 5;
            this.groupBoxInformacjeTwojeDane.TabStop = false;
            this.groupBoxInformacjeTwojeDane.Text = "Twoje dane";
            // 
            // labelInformacjeAdres
            // 
            this.labelInformacjeAdres.AutoSize = true;
            this.labelInformacjeAdres.Location = new System.Drawing.Point(9, 128);
            this.labelInformacjeAdres.Name = "labelInformacjeAdres";
            this.labelInformacjeAdres.Size = new System.Drawing.Size(50, 21);
            this.labelInformacjeAdres.TabIndex = 15;
            this.labelInformacjeAdres.Text = "Adres";
            // 
            // labelInformacjeHaslo
            // 
            this.labelInformacjeHaslo.AutoSize = true;
            this.labelInformacjeHaslo.Location = new System.Drawing.Point(9, 223);
            this.labelInformacjeHaslo.Name = "labelInformacjeHaslo";
            this.labelInformacjeHaslo.Size = new System.Drawing.Size(49, 21);
            this.labelInformacjeHaslo.TabIndex = 14;
            this.labelInformacjeHaslo.Text = "Hasło";
            // 
            // labelinformacjeLogin
            // 
            this.labelinformacjeLogin.AutoSize = true;
            this.labelinformacjeLogin.Location = new System.Drawing.Point(9, 173);
            this.labelinformacjeLogin.Name = "labelinformacjeLogin";
            this.labelinformacjeLogin.Size = new System.Drawing.Size(52, 21);
            this.labelinformacjeLogin.TabIndex = 13;
            this.labelinformacjeLogin.Text = "Login:";
            // 
            // textBoxHaslo
            // 
            this.textBoxHaslo.Enabled = false;
            this.textBoxHaslo.Location = new System.Drawing.Point(180, 220);
            this.textBoxHaslo.Name = "textBoxHaslo";
            this.textBoxHaslo.PasswordChar = '*';
            this.textBoxHaslo.Size = new System.Drawing.Size(246, 29);
            this.textBoxHaslo.TabIndex = 12;
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Enabled = false;
            this.textBoxLogin.Location = new System.Drawing.Point(180, 170);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(246, 29);
            this.textBoxLogin.TabIndex = 11;
            // 
            // textBoxAdres
            // 
            this.textBoxAdres.Enabled = false;
            this.textBoxAdres.Location = new System.Drawing.Point(180, 125);
            this.textBoxAdres.Name = "textBoxAdres";
            this.textBoxAdres.Size = new System.Drawing.Size(246, 29);
            this.textBoxAdres.TabIndex = 10;
            // 
            // textBoxNazwisko
            // 
            this.textBoxNazwisko.Enabled = false;
            this.textBoxNazwisko.Location = new System.Drawing.Point(180, 81);
            this.textBoxNazwisko.Name = "textBoxNazwisko";
            this.textBoxNazwisko.Size = new System.Drawing.Size(246, 29);
            this.textBoxNazwisko.TabIndex = 9;
            // 
            // buttonZapisz
            // 
            this.buttonZapisz.Enabled = false;
            this.buttonZapisz.Location = new System.Drawing.Point(346, 277);
            this.buttonZapisz.Name = "buttonZapisz";
            this.buttonZapisz.Size = new System.Drawing.Size(80, 40);
            this.buttonZapisz.TabIndex = 8;
            this.buttonZapisz.Text = "Zapisz";
            this.buttonZapisz.UseVisualStyleBackColor = true;
            // 
            // buttonAnuluj
            // 
            this.buttonAnuluj.Enabled = false;
            this.buttonAnuluj.Location = new System.Drawing.Point(180, 277);
            this.buttonAnuluj.Name = "buttonAnuluj";
            this.buttonAnuluj.Size = new System.Drawing.Size(80, 40);
            this.buttonAnuluj.TabIndex = 7;
            this.buttonAnuluj.Text = "Anuluj";
            this.buttonAnuluj.UseVisualStyleBackColor = true;
            // 
            // labelInformacjeNazwisko
            // 
            this.labelInformacjeNazwisko.AutoSize = true;
            this.labelInformacjeNazwisko.Location = new System.Drawing.Point(6, 84);
            this.labelInformacjeNazwisko.Name = "labelInformacjeNazwisko";
            this.labelInformacjeNazwisko.Size = new System.Drawing.Size(84, 21);
            this.labelInformacjeNazwisko.TabIndex = 5;
            this.labelInformacjeNazwisko.Text = "Nazwisko: ";
            // 
            // buttonEdytuj
            // 
            this.buttonEdytuj.Location = new System.Drawing.Point(6, 277);
            this.buttonEdytuj.Name = "buttonEdytuj";
            this.buttonEdytuj.Size = new System.Drawing.Size(80, 40);
            this.buttonEdytuj.TabIndex = 0;
            this.buttonEdytuj.Text = "Edytuj";
            this.buttonEdytuj.UseVisualStyleBackColor = true;
            // 
            // textBoxImie
            // 
            this.textBoxImie.Enabled = false;
            this.textBoxImie.Location = new System.Drawing.Point(180, 37);
            this.textBoxImie.Name = "textBoxImie";
            this.textBoxImie.Size = new System.Drawing.Size(246, 29);
            this.textBoxImie.TabIndex = 2;
            // 
            // labelInformacjeImie
            // 
            this.labelInformacjeImie.AutoSize = true;
            this.labelInformacjeImie.Location = new System.Drawing.Point(6, 40);
            this.labelInformacjeImie.Name = "labelInformacjeImie";
            this.labelInformacjeImie.Size = new System.Drawing.Size(43, 21);
            this.labelInformacjeImie.TabIndex = 1;
            this.labelInformacjeImie.Text = "Imię:";
            // 
            // FormKlient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tabControlKlient);
            this.Name = "FormKlient";
            this.Text = "FormKlient";
            this.Load += new System.EventHandler(this.FormKlient_Load);
            this.tabPageHistoria.ResumeLayout(false);
            this.splitContainerSprzedaze.Panel1.ResumeLayout(false);
            this.splitContainerSprzedaze.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSprzedaze)).EndInit();
            this.splitContainerSprzedaze.ResumeLayout(false);
            this.groupBoxSprzedazeSprzedaze.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistoria)).EndInit();
            this.groupBoxSprzedazeKupioneProdukty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSprzedazeKupioneProdukty)).EndInit();
            this.tabPageKoszyk.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZmienIlosc)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabPageProdukty.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProdukty)).EndInit();
            this.tabControlKlient.ResumeLayout(false);
            this.tabPageInformacje.ResumeLayout(false);
            this.groupBoxInformacjeTwojeDane.ResumeLayout(false);
            this.groupBoxInformacjeTwojeDane.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageHistoria;
        private System.Windows.Forms.SplitContainer splitContainerSprzedaze;
        private System.Windows.Forms.GroupBox groupBoxSprzedazeSprzedaze;
        private System.Windows.Forms.DataGridView dataGridViewHistoria;
        private System.Windows.Forms.GroupBox groupBoxSprzedazeKupioneProdukty;
        private System.Windows.Forms.DataGridView dataGridViewSprzedazeKupioneProdukty;
        private System.Windows.Forms.TabPage tabPageKoszyk;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonWyslijZamówienie;
        private System.Windows.Forms.Button buttonUsunZKoszyka;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBoxKoszyk;
        private System.Windows.Forms.TabPage tabPageProdukty;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonWyswietlInformacjeDodatkowe;
        private System.Windows.Forms.Button buttonDodajDoKoszyka;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewProdukty;
        private System.Windows.Forms.TabControl tabControlKlient;
        private System.Windows.Forms.TabPage tabPageInformacje;
        private System.Windows.Forms.GroupBox groupBoxInformacjeTwojeDane;
        private System.Windows.Forms.Label labelInformacjeAdres;
        private System.Windows.Forms.Label labelInformacjeHaslo;
        private System.Windows.Forms.Label labelinformacjeLogin;
        private System.Windows.Forms.TextBox textBoxHaslo;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxAdres;
        private System.Windows.Forms.TextBox textBoxNazwisko;
        private System.Windows.Forms.Button buttonZapisz;
        private System.Windows.Forms.Button buttonAnuluj;
        private System.Windows.Forms.Label labelInformacjeNazwisko;
        private System.Windows.Forms.Button buttonEdytuj;
        private System.Windows.Forms.TextBox textBoxImie;
        private System.Windows.Forms.Label labelInformacjeImie;
        private System.Windows.Forms.Label labelInfoOProdukcie;
        private System.Windows.Forms.TextBox textBoxInfoOProdukcie;
        private System.Windows.Forms.Label labelZmienIlosc;
        private System.Windows.Forms.NumericUpDown numericUpDownZmienIlosc;
        private System.Windows.Forms.Label labelCenaText;
        private System.Windows.Forms.Label labelIloscText;
        private System.Windows.Forms.Label labelIloscProduktow;
        private System.Windows.Forms.Label labelCenaZamowienia;
    }
}