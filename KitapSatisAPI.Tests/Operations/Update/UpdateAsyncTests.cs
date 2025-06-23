using KitapSatisAPI.Data;
using KitapSatisAPI.Models;
using KitapSatisAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace KitapSatisAPI.Tests.Operations.Update
{
    public class UpdateAsyncTests
    {
        [Fact]
        public async Task UpdateAsync_ShouldUpdateExistingBook()
        {
            // Arrange  
            var context = ConnectionOperation.GetDbContext(); //  Merkezi yöntem
            var repo = new BookRepository(context);
            var book = await repo.AddAsync(new Book
            {
                Title = "Eski Başlık",
                Author = "Yazar",
                Description = "Açıklama",
                CategoryId = 1
            });

            // Act  
            book.Title = "Yeni Başlık";
            await repo.UpdateAsync(book);

            var updated = await repo.GetByIdAsync(book.Id);

            // Assert  
            Assert.Equal("Yeni Başlık", updated?.Title);
        }
    }
}
