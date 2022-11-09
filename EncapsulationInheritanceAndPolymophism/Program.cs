using EncapsulationInheritanceAndPolymophism;
using EncapsulationInheritanceAndPolymophism.Animals;

// 3.1 Encapsulation

PersonHandler ph = new PersonHandler();
Person p1 = ph.CreatePerson(42, "Bob", "Smith", 170, 80);
Person p2 = ph.CreatePerson(43, "Tim", "Smith", 177, 90);
Person p3 = ph.CreatePerson(0, "Low", "Age", 177, 90);
Person p4 = ph.CreatePerson(20, "X", "ShortFirstName", 177, 90);
Person p5 = ph.CreatePerson(21, "Looooooooooooooooooong", "FirstName", 177, 90);
Person p6 = ph.CreatePerson(21, "ShrtLaName", "Ho", 177, 90);
Person p7 = ph.CreatePerson(21, "LongLaName", "HoHohohohohohohohohohoho", 177, 90);

// See the changes of using a PersonHandler:
Console.WriteLine();
Console.WriteLine($"NAME: {p1.FName} {p1.LName} ({p1.Age} years old) ; HEIGHT: {p1.Height} WEIGHT: {p1.Weight}");
ph.SetName(p1, "Joe", "Smithy");
ph.SetHeight(p1, 171);
Console.WriteLine($"NAME: {p1.FName} {p1.LName} ({p1.Age} years old) ; HEIGHT: {p1.Height} WEIGHT: {p1.Weight}");

// 3.2 Polymorphism

Console.WriteLine();
List<UserError> ueList = new List<UserError>() { new NumericInputError(), new TextInputError() };
foreach (UserError ue in ueList)
{
    Console.WriteLine(ue.UEMessage());
}

// 3.3 Inheritance

// Fråga: Om vi under utvecklingen kommer fram till att samtliga fåglar behöver ett
//        nytt attribut, i vilken klass bör vi lägga det?
// Svar: I klassen "Bird".
//
// Fråga: Om alla djur behöver det nya attributet, vart skulle man lägga det då?
// Svar: I klassen "Animal".

// 3.4 More polymorphism

List<Animal> animals = new List<Animal>()
{
    new Bird("Owl", "barn owl", 5, 1, 90),
    new Dog("Corgi", "noble dog", 7, 10, "eats sweets"),
    new Dog("German Shepherd", "Intelligent and hard working", 7, 10, "watchdog"),
    new Flamingo("American Flamingo", "Very pink", 2, 1, 100, 50),
    new Hedgehog("Leaf hedgehog", "Likes to burrow in leafs", 2, 1, 400),
    new Horse("Thoroughbred horse", "Racing horse", 7, 580, true),
    new Pelican("Australian Pelican", "Lives in Australia", 14, 8, 240, 11),
    new Swan("Bewick's swan", "More black and less yellow on their bill", 3, 10, 200, "Kola Peninsula" ),
    new Wolf("Grey wolf", "Typical wolf", 9, 80, "Alpha"),
    new Wolfman("Bob Smith", "Biologist living with wolfs", 43, 100, "delta", 12),
    new Worm("Earth worm", "Common in gardens", 1, 1, 10)
};

Console.WriteLine();
foreach (Animal animal in animals)
{
    Console.Write($"{animal.Name}: ");
    if (animal is IPerson person)
    {
        person.Talk("Hello");
    }
    else
    {
        animal.DoSound();
    }
}

List<Dog> dogs = new List<Dog>();
//dogs.Add(new Horse("Thoroughbred horse", "Retired racing horse", 12, 550, true));

// Fråga: Försök att lägga till en häst i listan av hundar. Varför fungerar inte det?
// Svar: Listan kan hantera "Dog" och (bas)klasserna ovan ("Animal").
//       Klassen "Horse" är en annan underklass till "Animal" och då tillhör en annan
//       klass-gren från "Animal". Skiss:  Animal
//                                         /    \
//                                       Dog    Horse

// Fråga: Vilken typ måste listan vara för att alla klasser skall kunna lagras tillsammans?
// Svar: Listan måste vara typen "Animal" (eller "object" om man ska vara petig)

Console.WriteLine("");
foreach (var animal in animals)
{
    Console.WriteLine(animal.Stats());
}

// Fråga: Förklara vad det är som händer
// Svar: Metoden "Stats()" finns i basklassen "Animal", vilket görs en override på i
//       dess underklasser vars metod anropar basklassens "Stats()" samt bygger på med egna.
//       Detta gör att även underklassernas mer specifika egenskaper kommer med, även från
//       "Pelican" klassen som är en "Bird" som är ett "Animal" där utskrifts ordningen
//       på egenskaperna blir "Animal", "Bird", "Pelican".

Console.WriteLine("");
foreach (var animal in animals)
{
    if(animal is Dog dog)
    {
        Console.WriteLine(dog.Stats());
    }
}

//animals[1].Whatever();

// Fråga: Skapa en ny metod med valfritt namn i klassen Dog som endast returnerar en valfri
// sträng. Kommer du åt den metoden från Animals listan? Varför inte?
// Svar: Listan innehåller underklasser av "Animal", metoden "Whatever()" finns inte i 
//       basklassen "Animal". För att komma åt den så måste man först se om objektet på
//       list positionen är klassen "Dog", sen "casta" till underklassen och därefter anropa.
//       "if(animal is Dog dog){ dog.Whatever(); }" likt "foreach" loopen ovan med "Stats()".

Console.WriteLine("");
foreach (var animal in animals)
{
    if(animal is Dog dog)
    {
        Console.WriteLine(dog.Whatever());
    }
}