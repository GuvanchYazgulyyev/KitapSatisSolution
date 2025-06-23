using KitapSatisAPI.Data;
using KitapSatisAPI.Models;
using KitapSatisAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapSatisAPI.Tests.Operations.Delete
{
    public class DeleteAsync
    {
        [Fact]
        public async Task DeleteAsync_ShouldRemoveBookFromDatabase()
        {
            // Arrange
            // Arrange  
            var options = new DbContextOptionsBuilder<KitapDbContext>()
                 .UseInMemoryDatabase(databaseName: "KitapSatisTestDb")
                 .Options;
            var context = new KitapDbContext(options);
            var repo = new BookRepository(context);
            var book = await repo.AddAsync(new Book
            {
                Title = "Silinecek Kitap",
                Author = "Yazar",
                Description = "Açıklama",
                CategoryId = 1
            });

            // Act
            await repo.DeleteAsync(book);
            var result = await repo.GetByIdAsync(book.Id);

            // Assert
            Assert.Null(result);
        }
    }
}
