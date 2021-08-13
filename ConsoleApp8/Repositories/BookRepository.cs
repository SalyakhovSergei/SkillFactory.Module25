using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp8
{
    public class BookRepository
    {
        public void AddBook(string bookName, int year)
        {
            using (var db = new AppContext())
            {
                db.Books.Add(new Book() { BookName = bookName, PublishedYear = year });

                db.SaveChanges();
            }
        }
        
        public List<Book> SelectAllBooks()
        {
            using (var db = new AppContext())
            {
                List<Book> allBooks = db.Books.ToList();
                return allBooks;
            }
        }
        
        public Book SelectBookById(int id)
        {
            using (var db = new AppContext())
            {
                Book bookById = db.Books.Where(o => o.Id == id).FirstOrDefault();
                return bookById;
            }
        }
        
        public void UpdateBookYeaR(int id, int updateYear)
        {
            using (var db = new AppContext())
            {
                Book bookToUpdate = db.Books.FirstOrDefault(o => o.Id == id);
                
                if (bookToUpdate != null)
                {
                    bookToUpdate.PublishedYear = updateYear;
                }

                db.SaveChanges();
            }
        }
        //1. Получать список книг определенного жанра и вышедших между определенными годами.
        public void SelectBookByGenreAndYears(string genreName, int yearFrom, int yearTo)
        {
            using (var db = new AppContext())
            {
                List<Book> bookByYearAndGenre = db.Books.Where(o => o.Genre.Title == genreName 
                                                                    && o.PublishedYear >= yearFrom 
                                                                    && o.PublishedYear <= yearTo).ToList();
            }
        }

        // 2. Получать количество книг определенного автора в библиотеке.
        public int CountBooksByAuthor(string authorName)
        {
            using (var db = new AppContext())
            {
                int booksByAuthor = db.Books.Count(o => o.Author.Name == authorName);
                return booksByAuthor;
            }
        }
        
        // 3. Получать количество книг определенного жанра в библиотеке.
        public int CountBooksByGenre(string genre)
        {
            using (var db = new AppContext())
            {
                int booksByGenre = db.Books.Count(o => o.Genre.Title == genre);
                return booksByGenre;
            }
        }
        
        // 4. Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        public bool CheckBookByAuthorAndName(string authorName, string bookName)
        {
            using (var db = new AppContext())
            {
                List<Book> bookByAuthorAndName = db.Books.Where(o => o.Author.Name == authorName 
                                                                    && o.BookName == bookName).ToList();

                if (bookByAuthorAndName.Count > 0) return true;

                return false;
            }
        }
        
        // 5. Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        // Не уверен что этот метод корректный
        public bool CheckBookByUser(string bookName, string userName)
        {
            using (var db = new AppContext())
            {
                List<Book> bookByBookName = db.Books.Where(o => o.BookName == bookName).ToList();
                foreach (var book in bookByBookName)
                {
                    if (book.UserId != null) return true;
                }
                return false;
            }
        }
        
        // 6. Получать количество книг на руках у пользователя.
        public int UserActiveBooks(string userName)
        {
            using (var db = new AppContext())
            {
                var userToCheck = db.Users.FirstOrDefault(o => o.Name == userName);

                return userToCheck.Books.Count();
            }
        }

        // 7. Получение последней вышедшей книги.
        public Book GetNewestBook()
        {
            using (var db = new AppContext())
            {
                var book = db.Books.OrderByDescending(o => o.PublishedYear).First();
                return book;
            }
        }

        // 8. Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        public List<Book> GetBooksByName()
        {
            using (var db = new AppContext())
            {
                var books = db.Books.OrderBy(o => o.BookName).ToList();
                return books;
            }
        }
        
        // 9. Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        public List<Book> GetBooksByYear()
        {
            using (var db = new AppContext())
            {
                var books = db.Books.OrderBy(o => o.PublishedYear).ToList();
                return books;
            }
        }
        
        
    }
}