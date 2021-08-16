using System;
using System.Data.Entity;
using SkillFactory.Module25.Models;
using SkillFactory.Module25.Repositories;

namespace SkillFactory.Module25
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                var user1 = new User { Name = "Дмитрий", Email = "dimas@mail.ru" };
                var user2 = new User { Name = "Владислав", Email = "vladik@mail.ru" };
                var user3 = new User { Name = "Тамара", Email = "tomati@mail.ru" };
                
                db.Users.AddRange(user1, user2, user3);

                var book1 = new Book { BookName = "Мертвые души", PublishedYear = 1835 };
                var book2 = new Book { BookName = "Собачье сердце", PublishedYear = 1925 };
                var book3 = new Book { BookName = "Доктор Живаго", PublishedYear = 1955 };
                
                db.Books.AddRange(book1, book2, book3);

                var author1 = new Authors { Name = "Михаил Булгаков" };
                var author2 = new Authors { Name = "Николай Гоголь" };
                var author3 = new Authors { Name = "Борис Пастернак" };
                
                db.Authors.AddRange(author1, author2, author3);

                var genre1 = new Genre { Title = "Поэма" };
                var genre2 = new Genre { Title = "Повесть" };
                var genre3 = new Genre { Title = "Роман" };
                
                db.Genres.AddRange(genre1, genre2, genre3);

                book1.Author = author2;
                book2.Author = author1;
                book3.Author = author3;
                
                user1.Books.Add(book1);
                user1.Books.Add(book2);

                db.SaveChanges();

            }
        }
    }
}