using Databases.AdoNet;
using Databases.EntityFrameworkCore;

Console.WriteLine("----- ADO.NET -----");
BooksAdoNetRepository booksAdoNetRepository = new BooksAdoNetRepository();
booksAdoNetRepository.Go();

Console.WriteLine("----- EF Core -----");
BooksEFCoreRepository booksEFCoreRepository = new BooksEFCoreRepository();
booksEFCoreRepository.Go();