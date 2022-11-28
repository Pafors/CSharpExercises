using Exercise_5_Garage.Vehicles;
using Exercise_5_Garage;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System;
using System.Security.Cryptography;
using Exercise_5_Garage.UI;
using Exercise_5_Garage.Handlers;
using Exercise_5_Garage.VehicleStorageFacilities;

// I MER PROGRAMMERINGS VÄNLIGA TERMER SKALL VI ALLTSÅ SOM MINIMUM HA:
// ● En kollektion av fordon; klassen Garage.
// ● En fordonsklass, klassen Vehicle
// ● Ett antal subklasser till fordon.
// ● Ett användargränssnitt som låter oss använda funktionaliteten hos garaget.
//   Här sker all interaktion med användaren.
// ● En GarageHandler. För att abstrahera ett lager så att det inte finns någon direkt
//   kontakt mellan användargränssnittet och garage klassen. Detta görs lämpligen
//   genom en klass som hanterar funktionaliteten som gränssnittet behöver ha
//   tillgång till.
// TODO ● Vi programmerar inte direkt mot konkreta typer så vi använder oss av Interfaces
//   för det tex I UI, IHandler, IVehicle. (Tips är att bryta ut till interface när
//   implementationen är klar om man tycker den här delen är svår)

// KRAVSPECIFIKATION
// Fordonen ska implementeras som klassen Vehicle och subklasser till den.
// ● Vehicle innehåller samtliga egenskaper som ska finnas i samtliga fordonstyper.
//   T.ex. registreringsnummer, färg, antal hjul och andra egenskaper ni kan komma på.
// ●  Registreringsnumret är unikt
// ● Det måste minst finnas följande subklasser:
//   ○ Airplane
//   ○ Motorcycle
//   ○ Car
//   ○ Bus
//   ○ Boat
// ● Dessa skall implementera minst en egen egenskap var, t.ex:
//   ○ Number of Engines
//   ○ Cylinder volume
//   ○ Fueltype (Gasoline/Diesel)
//   ○ Number of

// FUNKTIONALITET
// Det ska gå att:
// ● Lista samtliga parkerade fordon
// ● Lista fordonstyper och hur många av varje som står i garaget
// ● Lägga till och ta bort fordon ur garaget
// ● Sätta en kapacitet (antal parkeringsplatser) vid instansieringen av ett nytt garage
// ● Möjlighet att populera garaget med ett antal fordon från start.
// ● Hitta ett specifikt fordon via registreringsnumret. Det ska gå fungera med både
//   ABC123 samt Abc123 eller AbC123.
// ● Söka efter fordon utifrån en egenskap eller flera (alla möjliga kombinationer från
//   basklassen Vehicle ). Exempelvis:
//   ○ Alla svarta fordon med fyra hjul.
//   ○ Alla motorcyklar som är rosa och har 3 hjul.
//   ○ Alla lastbilar
//   ○ Alla röda fordon
// ● Användaren ska få feedback på att saker gått bra eller dåligt. Till exempel när vi
//   parkerat ett fordon vill vi få en bekräftelse på att fordonet är parkerat. Om det inte
//   går vill användaren få veta varför.

// FRÅN GRÄNSSNITTET SKALL DET GÅ ATT:
// ● Navigera till samtlig funktionalitet från garage via gränssnittet
// ● Skapa ett garage med en användar specificerad storlek
// ● Det skall gå att stänga av applikationen från gränssnittet
//
// Applikationen skall fel hantera indata på ett robust sätt, så att den inte kraschar vid
// felaktig inmatning eller användning.

// TODO UNIT TESTING
// Testen ska skapas i ett eget testprojekt. Vi begränsar oss till att testa de publika
// metoderna i klassen Garage . (Att skriva test för hela applikationen ses som en extra
// uppgift om tid finns)
// Experimentera gärna med att skriva testen före ni implementerat funktionaliteten!
// Använd er sedan ctrl . för att generera era objekt och metoder.
// Implementera sen funktionaliteten tills testet går igenom.

// BONUS
// Möjlighet att också kunna söka på de fordonsspecifika egenskaperna.
// TODO Läsa in storleken på garaget via konfiguration.
// TODO Hantera flera garage.


IUI ui = new ConsoleUI();
IGarageHandler<IVehicle> gh = new GarageHandler<IVehicle>();
ArgumentNullException.ThrowIfNull(gh);
//var storageFacilityManager = new Manager(ui, new GarageHandler<IVehicle>(new Garage<IVehicle>(4)));
var storageFacilityManager = new Manager(ui, gh);
storageFacilityManager.StartUpLoop();

