using CodeFirstBasic.Data;
using CodeFirstBasic.Models;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new PatikaFirstDbContext ())
        {
            context.Database.EnsureCreated();

            // veri ekleme
            if (!context.Movies.Any())
            {
                context.Movies.Add(new Movie { Title = "Inception", Genre = "Sci-Fi", ReleaseYear = 2010 });
                context.Movies.Add(new Movie { Title = "The Godfather", Genre = "Drama", ReleaseYear = 1972 });
                context.Movies.Add(new Movie { Title = "Kader", Genre = "Drama", ReleaseYear = 2006 });
                context.Movies.Add(new Movie { Title = "Issız Adam", Genre = "Drama", ReleaseYear = 2008 });
            }

            if (!context.Games.Any())
            {
                context.Games.Add(new Game { Name = "CS:GO", Platform = "PC", Rating = 9.0m });
                context.Games.Add(new Game { Name = "FIFA 25", Platform = "PlayStation", Rating = 8.7m });
            }

            context.SaveChanges(); // Değişiklikleri kaydet

            Console.WriteLine("----- Movies -----");
            foreach (var movie in context.Movies.ToList())
            {
                Console.WriteLine($"Id: {movie.Id}, Title: {movie.Title}, Genre: {movie.Genre}, Year: {movie.ReleaseYear}");
            }

            Console.WriteLine("\n----- Games -----");
            foreach (var game in context.Games.ToList())
            {
                Console.WriteLine($"Id: {game.Id}, Name: {game.Name}, Platform: {game.Platform}, Rating: {game.Rating}");
            }
        }
    }
}
