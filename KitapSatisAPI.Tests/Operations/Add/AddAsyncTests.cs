using KitapSatisAPI.Data;
using KitapSatisAPI.Models;
using KitapSatisAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
namespace KitapSatisAPI.Tests.Operations.Add
{
    public class AddAsyncTests 
    {
        [Fact]
        public async Task AddAsync_ShouldAddBookToDatabase()
        {
            // Arrange  
            var options = new DbContextOptionsBuilder<KitapDbContext>()
                .UseInMemoryDatabase(databaseName: "KitapSatisTestDb")
                .Options;
            var context = new KitapDbContext(options);
            var repo = new BookRepository(context);
            var newBook = new Book
            {
                Title = "Yeni Kitap",
                Author = "Yazar",
                Description = "Açıklama",
                CategoryId = 1
            };

            // Act  
            var result = await repo.AddAsync(newBook);
            var count = await context.Books.CountAsync();

            // Assert  
            Assert.Equal("Yeni Kitap", result.Title);
            Assert.Equal(1, count);
        }
    }
}
