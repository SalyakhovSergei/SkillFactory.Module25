using System.Collections.Generic;

namespace SkillFactory.Module25
{
    public class Authors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
        
    }
}