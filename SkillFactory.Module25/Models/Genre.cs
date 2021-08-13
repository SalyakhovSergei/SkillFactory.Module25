using System.Collections.Generic;
using SkillFactory.Module25;

namespace SkillFactory.Module25.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}