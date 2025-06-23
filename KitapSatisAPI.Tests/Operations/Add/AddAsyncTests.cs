using KitapSatisAPI.Data;
using KitapSatisAPI.Models;
using KitapSatisAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace KitapSatisAPI.Tests.Operations.Add
{
    public class AddAsyncTests
    {
        [Fact]
        public async Task AddAsync_ShouldAddBookToDatabase()
        {
            // Arrange
            var context = ConnectionOperation.GetDbContext(); //  Merkezi yöntem
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
