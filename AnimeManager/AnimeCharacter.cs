using System;
using System.ComponentModel.DataAnnotations;

namespace AnimeManager.Models
{
    public class AnimeCharacter
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? AnimeTitle { get; set; }

        public string? Power { get; set; }

        public int PowerLevel { get; set; }

        public string? FamousQuote { get; set; }

        public DateTime CreatedAt { get; set; } 
    }
}