1.Informacje formalne

Zestawienie wyników finansowy przedsiębiorst przemysłowych ze sprzedaży produktów, towarów i materiałów oraz średniego stężenia związków chemicznych zanieczyszczających powietrze.

OS: Windows 10/11

Server(ASP.NET Core):
.NET version: .NET 6.0

SoapServer(Java):
JDK version: 16.0.2 (https://jdk.java.net/archive/)
PHP version: 8.1.10

Client(Windows Forms App):
.NET version: .NET 4.7.2

NuGet Packages(Server):
Microsoft.AspNetCore.Authentication.JwtBearer 6.0.16
Newtonsoft.Json 13.0.3
System.IdentityModel.Tokens.Jwt 6.30.0
System.ServiceModel.Duplex 6.0.0
System.ServiceModel.Federation 6.0.0
System.ServiceModel.Http 6.0.0
System.ServiceModel.NetTcp 6.0.0
System.ServiceModel.Security 6.0.0

NuGet Packages(Client):
Newtonsoft.Json 13.0.3

dependencies(SOAP Server):
javax.jws->javax.jws-api 1.1
javax.xml.ws->jaxws-api 2.3.1
com.sun.xml.ws->rt 2.3.6
mysql->mysql-connector-java 8.0.32
org.hibernate->hibernate-core 5.6.3.Final
de.mkammerer->argon2-jvm 2.7



2.Opis projektu

Aplikacja pozwala na porównanie danych związanych z rozwojem przemysłu z danymi średniego stężenia związków chemicznych w powietrzu. Dzięki porówaniu obu danych jesteśmy w stanie zauważyć pewne zależności między zmianami w ich wartościach. 
Dodatkowo każdy przemysł posiada listę związków chemicznych, których zwiększona średnia wartość może wynikać z obecności danego przemysłu. W celu wyświetlenia danych wymagane jest zalogowanie na konto. 
Użytkownik ma również możliwość zapisywania do pliku w formacie json danych na temat wyświetlanego na grafie przemysłu oraz związków chemicznych.

Pzykładowe pytania na które można znaleźć odpowiedzi:
- Czy rozwój wybranego przemysłu może wiązać się ze zwiększeniem stężenia danego związku chemicznego zanieczyszającego powietrze w twoim województwie.
- Jak wyglądała zmiana w ilości wyemitowanych związków chemicznych zanieczyszczających powietrze w twoim województwie.
- Czy dany przemysł w ostatnich latach przynosił straty, czy zyski w twoim województwie.
- Czy dany przemysł funkcjonował lub dalej funkcjonuje w twoim województwie.



3.Informacje na temat specjalnych opcji konfiguracji

W importowanej bazie każde z województw posiada konto, którego login i hasło to nazwa województwa pisana małymi literami.
Zalogowanie się na konto powoduje wyświetlenie danych na temat województwa przypisanego do konta. 

Specjalne opcje konfiguracji Klienta: 
Jeśli korzystamy z kodu źródłowego może być konieczne ręczne dodanie "System.Windows.Forms.DataVisualization" oraz pliku dll z folderu Binaries za pomocą Reference Manager. 
Robimy to klikając prawym przyciskiem w drzewie projektu "References", następnie "Add Reference". Wyszukujemy "DataVisualization", a plik dll klikając na dole tego samego 
okna "Browse" i wybierając plik z folderu Binaries.
W razie problemów ze znalezieniem przez środowisko "CustomRangeSelectorControl" rozwijamy "References" i usuwamy "TestControl" jeśli istnieje. Jeśli nie istnieje lub został usunięty
dodajemy go ponownie za pomocą wyżej opisanego pliku dll.


Specjalne opcje konfiguracji Serwera Soap:
Należy upewenić się, że zawarte w pliku persistence.xml dane użytkownika bazy i adres url pasują do systemowych wartości.
Jeśli systemowe login i hasło użytkownika bazy różnią się od tych w pliku persistence.xml, podczas używania pliku wykonywalnego jar należy podać użytkownika i hasło w postaci "java -jar SoapServer.jar nazwa_użytkownika hasło"


Uruchamianie:
1. Włączyć MySQL.
2.Zaimportować bazę z pliku users.sql do bazy o nazwie users.
3.Upewnić się, że w folderze Assets serwera znajduje się plik o nazwie Statystyki.xml wygenerowany przez konwerter na podstawie danych z podanego źródła na temat zanieczyszczeń powietrza.
4.Upewnić się że każdy z serwisów posiada wymienione wyżej zależności.
5.Włączyć wszystkie serwisy (SoapServer, Server, Client).

Serwer działa na porcie 8080, a serwer Soap na porcie 7779. Baza MySQL powinna działać na porcie 3306. W przypadku innego portu należy zmienić konfigurację w pliku persistence.xml.



4.Informacje na temat źródeł wykorzystanych danych

Zanieczyszczenia powietrza:
-źródło: https://powietrze.gios.gov.pl/pjp/archives (aktualne na dzień 08.06.2023)
-konwerter excel->xml: https://products.aspose.app/cells/conversion/excel-to-xml (typ: Xml Data)

Przemysł:
-źródło: https://bdl.stat.gov.pl/bdl/start (API)


