using System;
using AnimeManager.Data;
using AnimeManager.Models;
using AnimeManager.Services;
using SQLitePCL;
class Program
{
    static void Main(string[] args)
    {
    
 
            Batteries.Init(); // Needed for SQLite bundled providers

            Console.WriteLine(" Anime Manager App Starting...\n");

            var service = new AnimeCharacterService();

            // Seed characters only if they don’t exist already
            service.SeedCharacters();

            var characters = service.GetAllCharacters();

            Console.WriteLine("Anime Characters in Database:\n");
            foreach (var c in characters)
            {
                Console.WriteLine($" Name: {c.Name}, Anime: {c.AnimeTitle}, Power Level: {c.PowerLevel} ,Famous quote: {c.FamousQuote}");
            }

            Console.WriteLine("\nDone!");
        
    

    }
}
