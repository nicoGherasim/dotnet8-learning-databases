namespace Databases.EntityFrameworkCore
{
    public class BooksEFCoreRepository
    {
        public void Go()
        {
            using (var context = new DbPracticeContext())
            {
                ReadNumberOfBooks(context);

                Console.WriteLine();
                Console.WriteLine("Display all books from the database:");
                ReadAllBooks(context);

                UpdateBook(context);

                Console.WriteLine();
                Console.WriteLine("Display all books from the database after update:");
                ReadAllBooks(context);

                ReadBookByTitle(context, "test123");

                AddNewBook(context);

                Console.WriteLine();
                Console.WriteLine("Display all books from the database after insert:");
                ReadAllBooks(context);

                var bookByTitle = context.Books.Where(b => b.Title == "newlyAddedBook").First();
                Console.WriteLine();
                Console.WriteLine($"Newly added book with WHERE condition: {bookByTitle.Id}, {bookByTitle.Title}");

                RemoveLastBook(context);

                Console.WriteLine();
                Console.WriteLine("Display all books from the database after delete:");
                ReadAllBooks(context);
            }
        }

        private void ReadNumberOfBooks(DbPracticeContext context)
        {
            int numberOfBooks = context.Books.Count();
            Console.WriteLine("Number of books:" + numberOfBooks);
        }

        private void UpdateBook(DbPracticeContext context)
        {
            var firstBook = context.Books.First();
            Console.WriteLine("The id of the first book:" + firstBook.Id);
            firstBook.Title = "test123";
            context.Books.Update(firstBook);
            context.SaveChanges();
        }

        private void ReadAllBooks(DbPracticeContext context)
        {
            var books = context.Books.ToList();
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Id}, {book.Title}, {book.YearOfPublishing}, {book.NumberOfPages}, {book.IsHardCover}");
            }
        }

        private void ReadBookByTitle(DbPracticeContext context, string title)
        {
            var bookByTitle = context.Books.Where(b => b.Title == title).First();
            Console.WriteLine();
            Console.WriteLine($"Book with WHERE condition on title:");
            Console.WriteLine($"{bookByTitle.Id}, {bookByTitle.Title}, {bookByTitle.NumberOfPages}");
        }

        private void AddNewBook(DbPracticeContext context)
        {
            var bookToAdd = new Book
            {
                Title = "newlyAddedBook",
                NumberOfPages = 20,
                YearOfPublishing = 2023,
                IsHardCover = true
            };
            context.Books.Add(bookToAdd);
            context.SaveChanges();
        }

        private void RemoveLastBook(DbPracticeContext context)
        {
            var lastBook = context.Books.OrderBy(b => b.Id).Last();
            context.Books.Remove(lastBook);
            context.SaveChanges();
        }
    }
}
