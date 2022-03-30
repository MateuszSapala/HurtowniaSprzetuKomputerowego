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
	haslo VARCHAR(50) NOT NULL
);

CREATE TABLE Hurtownia.dbo.sprzedaz(
	id INT IDENTITY(1,1) PRIMARY KEY,
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
	haslo VARCHAR(50) NOT NULL
);

--Dodanie przyk³adowych danych
INSERT INTO Hurtownia.dbo.pracownik (imie, nazwisko, adres, login, haslo) VALUES ('Mateusz', 'Sapa³a', 'Adres', 'admin', 'pass');
INSERT INTO Hurtownia.dbo.klient (imie, nazwisko, adres, login, haslo) VALUES ('Jan', 'Nowak', 'Adres', 'user', 'pass');
INSERT INTO Hurtownia.dbo.klient (imie, nazwisko, adres, login, haslo) VALUES ('Adam', 'Nowak', 'Adres2', 'user2', 'pass');
INSERT INTO Hurtownia.dbo.klient (imie, nazwisko, adres, login, haslo) VALUES ('Tomasz', 'Kowalski', 'Adres3', 'user3', 'pass');

INSERT INTO Hurtownia.dbo.sprzedaz (klient_id, status, suma, data_sprzedazy) VALUES (1, 1, 2, GETDATE());
INSERT INTO Hurtownia.dbo.pozycja_sprzedazy (sprzedaz_id, produkt_id, zamowiona_ilosc, wartosc) VALUES (1, 8, 2, 200);

--Pobieranie danych
--SELECT * FROM Hurtownia.dbo.pozycja_sprzedazy;
--SELECT * FROM Hurtownia.dbo.sprzedaz;
--SELECT * FROM Hurtownia.dbo.klient;
--SELECT * FROM Hurtownia.dbo.produkt;
--SELECT * FROM Hurtownia.dbo.dostawca;
--SELECT * FROM Hurtownia.dbo.pracownik;
--SELECT p.id, d.nazwa, p.nazwa_sprzetu, p.informacje_dodatkowe, p.cena_jednostkowa, d.id AS dostawca_id FROM Hurtownia.dbo.produkt AS p, Hurtownia.dbo.dostawca AS d WHERE p.dostawca_id=d.id;
SELECT * FROM Hurtownia.dbo.klient AS k WHERE LOWER('jan') LIKE LOWER(k.imie)+'|'+LOWER(k.nazwisko)+'|'+LOWER(k.adres)+'|'+LOWER(k.login);

SELECT * FROM Hurtownia.dbo.klient AS k WHERE LOWER('jan') LIKE '%'+LOWER(k.imie)+'%|%'+LOWER(k.nazwisko)+'%|%'+LOWER(k.adres)+'%|%'+LOWER(k.login)+'%';
SELECT * FROM Hurtownia.dbo.klient AS k WHERE LOWER('jan') LIKE '%'+LOWER(k.imie)+'%|dsad';

SELECT * FROM Hurtownia.dbo.klient AS k WHERE (LOWER(k.imie)=LOWER('') OR LOWER(k.nazwisko)=LOWER('') OR LOWER(k.adres)=LOWER('') OR LOWER(k.login)=LOWER(''));

SELECT * FROM Hurtownia.dbo.sprzedaz AS s, Hurtownia.dbo.klient AS k WHERE s.klient_id=k.id;