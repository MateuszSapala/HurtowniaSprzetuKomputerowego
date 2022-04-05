--Usuniêcie i dodanie bazy danych
DROP DATABASE IF EXISTS Hurtownia;
CREATE DATABASE Hurtownia;

--Usuñ istniej¹ce tabele
DROP TABLE IF EXISTS Hurtownia.dbo.pozycja_sprzedazy;
DROP TABLE IF EXISTS Hurtownia.dbo.sprzedaz;
DROP TABLE IF EXISTS Hurtownia.dbo.klient;
DROP TABLE IF EXISTS Hurtownia.dbo.produkt;
DROP TABLE IF EXISTS Hurtownia.dbo.dostawca;
DROP TABLE IF EXISTS Hurtownia.dbo.pracownik;

--Dodanie tabel
CREATE TABLE Hurtownia.dbo.dostawca(
	id INT IDENTITY(1,1) PRIMARY KEY,
	nazwa VARCHAR(50) NOT NULL,
	informacje_dodatkowe VARCHAR(255) NOT NULL
);

CREATE TABLE Hurtownia.dbo.produkt(
	id INT IDENTITY(1,1) PRIMARY KEY,
	dostawca_id INT FOREIGN KEY REFERENCES Hurtownia.dbo.dostawca(id),
	nazwa_sprzetu VARCHAR(50) NOT NULL,
	informacje_dodatkowe VARCHAR(255) NOT NULL,
	cena_jednostkowa MONEY NOT NULL,
);

CREATE TABLE Hurtownia.dbo.klient(
	id INT IDENTITY(1,1) PRIMARY KEY,
	imie VARCHAR(50) NOT NULL,
	nazwisko VARCHAR(50) NOT NULL,
	adres VARCHAR(50) NOT NULL,
	login VARCHAR(50) NOT NULL,
	haslo VARBINARY(8000) NOT NULL
);

CREATE TABLE Hurtownia.dbo.sprzedaz(
	id INT PRIMARY KEY,
	klient_id INT FOREIGN KEY REFERENCES Hurtownia.dbo.klient(id),
	status INT NOT NULL CHECK (status BETWEEN 0 AND 3),
	suma MONEY NOT NULL,
	data_sprzedazy DATETIME NOT NULL
);

CREATE TABLE Hurtownia.dbo.pozycja_sprzedazy(
	id INT IDENTITY(1,1) PRIMARY KEY,
	sprzedaz_id INT FOREIGN KEY REFERENCES Hurtownia.dbo.sprzedaz(id),
	produkt_id INT FOREIGN KEY REFERENCES Hurtownia.dbo.produkt(id),
	zamowiona_ilosc INT NOT NULL,
	wartosc MONEY NOT NULL,
);

CREATE TABLE Hurtownia.dbo.pracownik(
	id INT IDENTITY(1,1) PRIMARY KEY,
	imie VARCHAR(50) NOT NULL,
	nazwisko VARCHAR(50) NOT NULL,
	adres VARCHAR(50) NOT NULL,
	login VARCHAR(50) NOT NULL,
	haslo VARBINARY(8000) NOT NULL
);

--Dodanie przyk³adowych danych
INSERT INTO Hurtownia.dbo.pracownik (imie, nazwisko, adres, login, haslo) 
VALUES ('Mateusz', 'Sapa³a', '£ódŸ ul. Zmyœlona 1', 'admin', HashBytes('SHA2_512', 'pass')),
('Szymon', 'Szafoni', '£ódŸ ul. Zmyœlona 2', 'admin2', HashBytes('SHA2_512', 'pass'));

INSERT INTO Hurtownia.dbo.klient (imie, nazwisko, adres, login, haslo) 
VALUES ('Jan', 'Nowak', '£ódŸ ul. Zmyœlona 3', 'user', HashBytes('SHA2_512', 'pass')),
('Adam', 'Nowak', '£ódŸ ul. Zmyœlona 4', 'user2', HashBytes('SHA2_512', 'pass')),
('Tomasz', 'Kowalski', '£ódŸ ul. Zmyœlona 5', 'user3', HashBytes('SHA2_512', 'pass'));

INSERT INTO Hurtownia.dbo.dostawca (nazwa, informacje_dodatkowe) VALUES 
('Firma 1', 'Dostawca monitorów'),
('Firma 2', 'Dostawca klawiatur'),
('Firma 3', 'Dostawca laptopów'),
('Firma 4', 'Dostawca komputerów');

INSERT INTO Hurtownia.dbo.produkt(dostawca_id, nazwa_sprzetu, informacje_dodatkowe, cena_jednostkowa) VALUES
(1, 'Monitor 1', '18 cali', 456),
(1, 'Monitor 2', '20 cali', 678),
(1, 'Monitor 3', '24 cali', 789),
(2, 'Klawiatura 1', '', 123),
(2, 'Klawiatura 2', '', 146),
(2, 'Klawiatura 3', 'Klawiatura podœwietlana', 256),
(3, 'Laptop 1', '', 4499),
(3, 'Laptop 2', '', 4999),
(3, 'Laptop 3', '', 5999),
(4, 'Komputer 1', '', 4499),
(4, 'Komputer 2', '', 4999),
(4, 'Komputer 3', '', 5999);

INSERT INTO Hurtownia.dbo.sprzedaz (id, klient_id, status, suma, data_sprzedazy) VALUES
(1, 1, 3, 7057, GETDATE()),
(2, 2, 2, 4499, GETDATE()),
(3, 3, 1, 49999, GETDATE()),
(4, 1, 0, 712, GETDATE());

--Pobieranie danych
--SELECT * FROM Hurtownia.dbo.pozycja_sprzedazy;
--SELECT * FROM Hurtownia.dbo.sprzedaz;
--SELECT * FROM Hurtownia.dbo.klient;
--SELECT * FROM Hurtownia.dbo.produkt;
--SELECT * FROM Hurtownia.dbo.dostawca;
--SELECT * FROM Hurtownia.dbo.pracownik;
--SELECT p.id, d.nazwa, p.nazwa_sprzetu, p.informacje_dodatkowe, p.cena_jednostkowa, d.id AS dostawca_id FROM Hurtownia.dbo.produkt AS p, Hurtownia.dbo.dostawca AS d WHERE p.dostawca_id=d.id;