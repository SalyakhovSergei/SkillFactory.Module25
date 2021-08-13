using System.Collections.Generic;

namespace SkillFactory.Module25.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}