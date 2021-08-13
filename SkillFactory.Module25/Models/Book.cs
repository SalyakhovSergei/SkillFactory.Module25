using SkillFactory.Module25.Models;

namespace SkillFactory.Module25
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int PublishedYear { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        
        public Authors Author { get; set; }
        public Genre Genre { get; set; }
    }
}