using AnimeManager.Models;
using Microsoft.EntityFrameworkCore;


//this file is the Bridge between Code & Database
namespace AnimeManager.Data
{
	public class AppdbContext: DbContext
	{
        // This class would typically inherit from DbContext and include DbSet properties for your entities.
       
        public DbSet<AnimeCharacter> AnimeCharacters { get; set; }
        //DbSet<T>: like a virtual table in the database, where T is the model class.
        //"Hey EF, please create a table for this model (AnimeCharacter) in the database."
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=anime.db"); //This method tells EF Core what kind of database you're using — in our case, SQLite.(UseSqlite)
            // The string "Data Source=anime.db" is the connection string.
            /*A connection string is just a specially formatted line that tells EF Core:
           -> “Here’s where the database is and how to connect to it.”
           -> Data Source → tells SQLite what file to use as the database.
           -> anime.db → is the name of the file that will be created in your project folder.
           ->The file will be created in the project directory if it doesn't exist.
             */
        }


        // This method is called by Entity Framework Core to configure the database connection.
        // We're overriding it to tell EF Core to use a local SQLite database file named "anime.db".
        // The 'protected' keyword means this method is only accessible inside this class or its subclasses.
        // EF Core calls this method automatically — we don't need to call it ourselves.






    }

}
/*This class tells Entity Framework:
What database you're using (SQLite)
Which tables (models) exist
Where the DB file is located*/