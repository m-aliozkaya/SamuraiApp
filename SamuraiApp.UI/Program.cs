using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiApp.UI;

class Program
{
    private static SamuraiContext _context = new SamuraiContext();
    static void Main(string[] args)
    {
        _context.Database.EnsureCreated();
        GetSamurais("Before Add");
        //AddSamurai();
        //GetSamurais("After Add");
        //AddQuoteToExistingSamurai();
        Console.Write("Press any key...");
        Console.ReadKey();
    }

    private static void AddSamurai()
    {
        var samurai = new Samurai { Name = "Sampson" };
        _context.Samurais.Add(samurai);
        _context.SaveChanges();
    }

    private static void GetSamurais(string text)
    {
        var samurais = _context.Samurais.ToList();
        Console.WriteLine($"{text}: Samurai count is {samurais.Count}");

        foreach (var samurai in samurais)
        {
            Console.WriteLine(samurai.Name);
        }
    }

    private static void InsertNewSamuraiWithAQuote()
    {
        var samurai = new Samurai
        {
            Name = "Zoro",
            Quotes = new List<Quote> {
                new Quote{ Text = "I've come to save you Nami"}
            }
        };

        _context.Samurais.Add(samurai);
        _context.SaveChanges();
    }

    private static void AddQuoteToExistingSamurai()
    {
        var samurai = _context.Samurais.FirstOrDefault();
        samurai.Quotes.Add(new Quote
        {
            Text = "Hey Nami, I miss you very much!"
        });

        _context.SaveChanges();
    }
}
