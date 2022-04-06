Utwrzyć bazę dancyh w SQL Server Management Studio z pliku 1.Init.sql znajdującego się w folderze HurtowniaSprzetuKomputerowego
By połączyć się z bazą danych należy w folderze common w klasie DbConnection.cs podmienić connectionStringa. Aby to zrobic należy w Visualu kliknąć w zakładkę "Narzędzia", następnie "Łączenie z bazą danych", odpalić Microsoft SQL Server Management Studio i skopiować nazwę servera (Server Name). W Visualu w otawrtym oknie ("Dodaj połączenie") wybrać Źródło Dancyh jako Microsoft SQL Server(SqlClient), w pole Nazwa serwera wkleić wcześniej skopiowaną wartość, jako uwierzytelnianie wybrac Uwierzytelnianie systemu Windows. Bazę danych jako Hurtownia, kliknać zaawansowane i na samym dole okna skopiować connection Stringa zaczynającego się od "Data Source".
Nastepnie wkleić go w zmienną conString w wyżej wspomnianej klasie.

Dane logowania do klienta
login:user
hasło:pass

Dane logowania do pracownika
login:admin
hasło:pass