

namespace SkillFactory.Module25.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int PublishedYear { get; set; }
        
        public User User { get; set; }
        public Authors Author { get; set; }
        public Genre Genre { get; set; }
    }
}