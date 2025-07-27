using AnimeManager.Data;
using AnimeManager.Models;

namespace AnimeManager.Services
{
    public class AnimeCharacterService
    {
        private readonly AppdbContext _context;

        public AnimeCharacterService()
        {
            _context = new AppdbContext();
            _context.Database.EnsureCreated(); // Ensure DB and table are created
        }

        public void AddCharacter(AnimeCharacter character)
        {
            try
            {
                if (!_context.AnimeCharacters.Any(c =>
                    c.Name == character.Name && c.AnimeTitle == character.AnimeTitle))
                {
                    _context.AnimeCharacters.Add(character);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error occurred while saving to database:");
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine("🔍 Inner Exception: " + ex.InnerException.Message);
            }
        }
        public List<AnimeCharacter> GetAllCharacters()
        {
            return _context.AnimeCharacters.ToList();
        }

        public void SeedCharacters()
        {
            var charactersToAdd = new List<AnimeCharacter>
            {
                new AnimeCharacter { Name = "Satorou Gojo", PowerLevel = 243500000, AnimeTitle = "JJK" ,FamousQuote="Yo wai mo!",CreatedAt = new DateTime(2020, 11, 1) },
                new AnimeCharacter { Name = "Levi Ackerman", PowerLevel = 10000, AnimeTitle = "Attack on Titan" ,FamousQuote="Tatake!",CreatedAt = new DateTime(2013, 4, 7)},
                new AnimeCharacter { Name = "Monkey D. Luffy", PowerLevel = 9000, AnimeTitle = "One Piece" ,FamousQuote="Puru puru",CreatedAt = new DateTime(2003, 12, 1)},
                new AnimeCharacter { Name = "Eren Yeager", PowerLevel = 105000, AnimeTitle = "Attack on Titan" ,FamousQuote="Keeennnyyyyy!",CreatedAt = new DateTime(2014, 12, 1)},
                new AnimeCharacter { Name = "Sebastian", PowerLevel = 76000, AnimeTitle = "Black Butler",FamousQuote="Yare Yare!",CreatedAt = new DateTime(2008, 2, 23) },
                new AnimeCharacter { Name = "Inouske", PowerLevel = 7632000, AnimeTitle = "Demonsalyer",FamousQuote="Kamamoto Gonpochiro",CreatedAt = new DateTime(2018, 3, 23) }

            };

            foreach (var character in charactersToAdd)
            {
                AddCharacter(character); // uses duplicate check inside
            }
        }
    }
}
