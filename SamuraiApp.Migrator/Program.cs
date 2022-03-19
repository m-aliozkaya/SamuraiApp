using SamuraiApp.Data;
using SamuraiApp.Domain;

var context = new SamuraiContext();
var isDatabaseCreated = context.Database.EnsureCreated();

if (isDatabaseCreated)
{
    var samuraiList = new List<Samurai>
    {
        new Samurai{ Name = "Hattori Hanzō", Horse = new Horse {Name = "Deeno" } },
        new Samurai{ Name = "Harada Nobutane", Horse = new Horse {Name = "Frisky" } },
        new Samurai{ Name = "Iwanari Tomomichi", Horse = new Horse {Name = "Goldie" } },
        new Samurai{ Name = "Kawakami Gensai", Horse = new Horse {Name = "Ivery " } },
    };

    samuraiList[0].Battles = new List<Battle>
    {
        new Battle{ Name = "Third Battle Of Uji"},
        new Battle{ Name = "Siege of Chihaya"},
    };

    samuraiList[0].Quotes = new List<Quote>
    {
        new Quote{ Text = "Honour may not win power, but it wins respect. And respect earns power."},
        new Quote{ Text = "Engage in combat fully determined to die and you will be alive; " +
                    "wish to survive in the battle and you will surely meet death."},
        new Quote{ Text = "Victory is reserved for those who are willing to pay its price."},
    };

    samuraiList[1].Battles = new List<Battle>
    {
        new Battle{ Name = "Anegawa"},
        new Battle{ Name = "Siege of Chihaya"},
        new Battle{ Name = "Nagashino"},
        new Battle{ Name = "Sendaigawa"},
    };

    samuraiList[1].Quotes = new List<Quote>
    {
        new Quote{ Text = "We don't rise to the level of our expectations, we fall to the level of our training."},
        new Quote{ Text = "See first with your mind, then with your eyes, and finally with your body."},
        new Quote{ Text = "Think lightly of yourself and deeply of the world"},
    };

    await context.Samurais.AddRangeAsync(samuraiList);
    await context.SaveChangesAsync();

    Console.WriteLine("Database initialized.");
}
else
{
    Console.WriteLine("Database is already exist!");
}

Console.WriteLine("Press ENTER to exit...");
Console.ReadLine();