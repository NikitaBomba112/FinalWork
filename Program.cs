using BookStore.Data;
using BookStore.Interfaces;
using BookStore.Repository;

namespace BookStore
{
    class Program
    {
        private static IBook _books;

        public static ApplicationContext DbContext() => new ApplicationContextFactory().CreateDbContext();

        public static async Task Main(string[] args) 
        {
            Initialize();
            var allBook = await _books.GetAllBooksWithAuthorsAsync();
        }

        public static void Initialize()
        {
            new DbInit().Init(DbContext());
            _books = new BookRepository();
        }
    }
}