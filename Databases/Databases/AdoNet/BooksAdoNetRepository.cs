using System.Data.SqlClient;

namespace Databases.AdoNet
{
    public class BooksAdoNetRepository
    {
        public void Go()
        {
            var connectionString = "Server=localhost;Database=BooksManagement;User Id=sa;Password=<YOUR_PASSWORD>;TrustServerCertificate=True";

            // option1 - do not use
            //SqlConnection connection = new SqlConnection(connectionString);
            //connection.Open();
            //// code block
            //connection.Close();

            // option2 - way better than 1
            //SqlConnection connection = new SqlConnection(connectionString);
            //try
            //{
            //    connection.Open();
            //    //code block
            //}
            //catch(Exception ex)
            //{
            //    // code block
            //}
            //finally
            //{
            //    connection.Close();
            //}

            // option 3 - the best
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                ReadNumberOfBooks(connection);

                UpdateBook(connection);

                ReadAllBooks(connection);
            }
        }

        private void ReadNumberOfBooks(SqlConnection connection)
        {
            SqlCommand readNumberOfBooks = new SqlCommand("SELECT COUNT(*) FROM Books", connection);
            var numberOfBooks = readNumberOfBooks.ExecuteScalar();

            Console.WriteLine("number of books:" + numberOfBooks);
        }

        private void UpdateBook(SqlConnection connection)
        {
            SqlCommand updateBooksTitle = new SqlCommand("UPDATE Books SET title = 'None' WHERE id=1", connection);
            var numberOfUpdatedBooks = updateBooksTitle.ExecuteNonQuery();

            Console.WriteLine("number of updated books:" + numberOfUpdatedBooks);
        }

        private void ReadAllBooks(SqlConnection connection)
        {
            Console.WriteLine("Read all books:");
            SqlCommand readAllBooks = new SqlCommand("SELECT * FROM Books", connection);
            SqlDataReader allBooks = readAllBooks.ExecuteReader();

            List<Book> books = new List<Book>();
            while (allBooks.Read())
            {
                Book book = new Book
                {
                    Id = (int)allBooks["Id"],
                    Title = (string)allBooks["Title"],
                    YearOfPublishing = (int)allBooks["YearOfPublishing"],
                    NumberOfPages = (int)allBooks["NumberOfPages"],
                    IsHardCover = (bool)allBooks["IsHardCover"]
                };
                Console.WriteLine($"{allBooks["Id"]}, {allBooks["Title"]}, {allBooks[2]}");

                books.Add(book);
            }

            Console.WriteLine("Title and year of publishing of books: ");
            foreach (Book b in books)
            {
                Console.WriteLine($"Title: {b.Title}, Year of publishing: {b.YearOfPublishing}.");
            }
        }
    }
}
