using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsertIntoDestinations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // -------------------- Spania --------------------
            // Barcelona
            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson)
                SELECT
                    'htop Amaika & SPA 4Sup - Adults Only ****',
                    CityId,
                    'Amplasat la doar câteva minute de mers de plaja cu nisip auriu, acest hotel de vacanţă însorit este situat într-o zonă rezidenţială liniştită din Calella. Zona de coastă din jurul oraşului Calella prezintă peste 3 km de plaje decorate cu steag albastru şi golfuri retrase. De asemenea, puteţi petrece o zi plăcută în magnificul oraş Barcelona, la 45 de minute către sud.

Camerele sunt dotate cu baie cu cada si articole de uz personal, uscator de par, aer conditionat si incalzire centrala, balcon, birou, seif, telefon direct, TV satelit, radio, minibar (contra cost). Camerele pot fi si adaptate persoanelor cu nevoi speciale.

Hotelul dispune de receptie 24h, aer conditionat, schimb valutar, acces pentru persoane cu nevoi speciale, spalatorie, piscina exterioara, jacuzzi, sauna, restaurant, snack-bar, sala de fitness, sali de conferinte, zona Wi-Fi (internet), camera pentru bagaje, mini-club, programe de animatie, room service disponibil 24h. Este posibilă parcarea privată la proprietate (nu este posibilă rezervarea) si este cu plata. Internet wireless este disponibil în întregul hotel şi se aplică taxe. Turistii pot folosi facilitatile tuturor hotelurilor HTOP (cu rezervare), folosing autobuzul gratuit intre aceste hoteluri.',
                    421.0
                FROM Cities
                WHERE Name = 'Barcelona';
            ");

            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson)
                SELECT
                    'Hotel Samba ***',
                    CityId,
                    'Situat la 500 de metri de plaja Fenals, Samba oferă o piscină sezonieră în aer liber și vedere la Lloret. Fiecare cameră funcțională are un balcon privat.

Samba este situat într-o zonă liniștită, la doar 10 minute de mers pe jos de centrul plin de viață al orașului Lloret de Mar. Autogara Lloret este la 600 de metri și oferă servicii directe către Aeroportul Girona și Barcelona.

Camerele luminoase de la Samba oferă TV prin satelit și vedere la piscină, stradă sau dealuri. Fiecare cameră include mobilier din lemn și se poate închiria un seif. Avem Wi-Fi gratuit în camere.

Bucătăria locală și internațională este servită în restaurantul tip bufet de la Samba. În timpul sezonului de vârf sunt oferite cine tematice. Există, de asemenea, un pub în stil englezesc, deschis vara.',
                    317.0
                FROM Cities
                WHERE Name = 'Barcelona';
            ");

            // Alicante
            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson)
                SELECT
                    'Hotel Maya ***',
                    CityId,
                    'Hotelul Maya este situat la poalele Castelului Santa Barbara, la 5 minute de mers pe jos de plaja din Alicante şi la 10 minute de mers pe jos de centru. Oferă o piscină sezonieră în aer liber, acces gratuit la conexiunea WiFi şi o sală de fitness cu vedere panoramică.

Toate camerele de la Maya au aer condiţionat, TV prin satelit şi minibar. Baia privată este dotată cu uscător de păr.

De la Maya se poate ajunge ușor la plaja Postiguet, situată la 5 minute de mers pe jos de hotel. În lunile iulie şi august, hotelul oferă un program de divertisment pentru adulţi şi copii.

Restaurantul serveşte preparate locale şi internaţionale, precum şi specialităţi din orez. Există şi o cafenea. Oaspeţii au la dispoziţie room service şi prânz la pachet, precum şi distribuitoare automate de băuturi şi gustări.

Centrul comercial Plaza Mar 2 este la 100 de metri. Trenul către parcul tematic Terra Mítica şi stațiunea Benidorm are staţie vizavi de Maya. La doar 50 de metri de hotel se află staţia autobuzului C6 care circulă spre aeroport.',
                    330.0
                FROM Cities
                WHERE Name = 'Alicante';
            ");


            // -------------------- Grecia --------------------
            // Rodos
            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson)
                SELECT
                    'Rhodos Horizon City-Adults Only ****',
                    CityId,
                    'Rhodos Horizon City-Adults Only se află în Rodos (oraș), la aproximativ 4 minute de mers pe jos de Plaja Elli și la 700 m de Plaja Akti Kanari, și pune la dispoziție un bar și WiFi gratuit în întreaga proprietate. Această proprietate include o recepție deschisă nonstop, precum și un restaurant și o terasă. Proprietatea include o piscină în aer liber sezonieră, un centru de fitness, o saună și un lounge comun.

Acest hotel pune la dispoziție camere cu aer condiționat, dulap pentru haine, ibric electric, un frigider, un minibar, cutie de valori, televizor cu ecran plat și o baie proprie cu duș. Baia proprie oferă articole de toaletă gratuite. La Rhodos Horizon City-Adults Only, fiecare cameră oferă lenjerie de pat și prosoape.

La acest hotel de 4 stele puteți juca tenis de masă.

Printre punctele de atracție populare situate în apropiere de Rhodos Horizon City-Adults Only se numără Portul Mandraki, Statuile de căprioare și Strada Cavalerilor. Aeroportul Internaţional Rodos se află la 12 km.',
                    556.0
                FROM Cities
                WHERE Name = 'Rodos';
            ");

            // Zakynthos
            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson)
                SELECT
                    'Bitzaro Boutique Hotel ****',
                    CityId,
                    'Bitzaro Boutique Hotel se află în localitatea Zakynthos din regiunea Insulele Ionice, la câțiva pași de Plaja municipală Zante și la 14 minute de mers pe jos de Plaja Kryoneri, și include un bar. Acest hotel de 4 stele oferă o terasă, precum și camere cu aer condiționat și WiFi gratuit, care beneficiază toate de o baie proprie. Anumite camere de la proprietate includ un balcon cu o vedere la mare.

La acest hotel, camerele includ dulap pentru haine. Baia proprie oferă un duș, articole de toaletă gratuite și un uscător de păr. La Bitzaro Boutique Hotel, fiecare cameră are un televizor cu ecran plat și o cutie de valori.

Personalul de la recepție vorbește limbile greacă și engleză britanică.

Printre punctele de atracție populare situate în apropiere de Bitzaro Boutique Hotel se numără Muzeul Bizantin, Piaţa Dionisios Solomos și Biserica Agios Dionysios. Aeroportul internațional Zakynthos se află la 4 km.',
                    501.0
                FROM Cities
                WHERE Name = 'Zakynthos';
            ");


            // -------------------- Italia --------------------
            // Milano
            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson)
                SELECT
                    'Hotel Mythos ***',
                    CityId,
                    'Hotelul Mythos este situat la doar 200 de metri de gara centrală din Milano şi la o călătorie de 5 minute cu metroul de Catedrala din Milano. Camerele sunt dotate cu aer condiționat, iar oaspeţii beneficiază de WiFi gratuit, disponibil în întregul hotel.

Facilităţile oferite de Hotelul Mythos includ o recepţie cu program nonstop, un bar tradiţional şi un lounge. Camerele au podea cu mochetă moale şi baie privată cu duş sau cadă. Unele camere beneficiază de balcon cu vedere la oraș.

Hotelul Mythos, situat la 500 metri de faimosul district comercial Corso Buenos Aires din Milano, vă oferă posibilitatea de a vă plimba prin grădinile publice Indro Montanelli din apropiere, care găzduiesc Galeria de Artă Modernă.

Centrele de expoziții Rho Fiera Milano și Expo 2015 sunt ambele la 15 km de Hotelul Mythos.',
                    649.0
                FROM Cities
                WHERE Name = 'Milano';
            ");

            // Roma
            migrationBuilder.Sql(@"
                INSERT INTO Destinations (Name, CityId, Description, PricePerNightPerPerson)
                SELECT
                    'Hotel Principessa Isabella ****',
                    CityId,
                    'Clarion Collection Principessa Isabella este un hotel clasic, situat la 500 de metri de parcul Villa Borghese. Faimoasa stradă din filmul La Dolce Vita, Via Veneto, se află la o plimbare de 5 minute de hotel. Internetul Wi-Fi este gratuit.

Camerele de la Principessa Isabella au amenajări elegante, în culori calde. Fiecare este dotată cu aer condiționat, TV cu ecran plat cu programe prin satelit și minibar. Băile sunt dotate cu uscător de păr și un set de articole de toaletă.

Un mic dejun tip bufet continental este servit în sala de mic dejun. Barul are o zonă de zi mare, cu ziare și TV, și servește băuturi internaționale și cocktail-uri.

Hotelul este înconjurat de cafenele și restaurante pline de viață. Treptele Spaniole și cartierul comercial exclusivist din Roma sunt la o plimbare de 10 minute.

Hotelul este legat de gara Termini din Roma prin intermediul autobuzului 910, care merge și la stația de metrou Repubblica, situată la 1 km. Transferul de la/la aeroporturile Ciampino și Fiumicino poate fi aranjat la cerere.',
                    678.0
                FROM Cities
                WHERE Name = 'Roma';
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM Destinations");
        }
    }
}
