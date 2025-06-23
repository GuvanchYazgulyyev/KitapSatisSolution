using KitapSatisAPI.Data;
using KitapSatisAPI.Models;
using KitapSatisAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapSatisAPI.Tests.Operations
{
    public class BookRepositoryTests
    {
        private DbContextOptions<KitapDbContext> GetDbContextOptions()
        {
            return new DbContextOptionsBuilder<KitapDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task AddAsync_ShouldAddBookToDatabase()
        {
            // Arrange


            var context = ConnectionOperation.GetDbContext(); //  Merkezi yöntem
            var repository = new BookRepository(context);

            var book = new Book
            {
                Title = "Test Kitap",
                Author = "Yazar 1",
                Description = "Test açıklama",
                Price = 50,
                CategoryId = 1
            };

            // Act
            await repository.AddAsync(book);

            // Assert
            var booksInDb = await context.Books.ToListAsync();
            Assert.Single(booksInDb);
            Assert.Equal("Test Kitap", booksInDb[0].Title);
        }
    }
}
