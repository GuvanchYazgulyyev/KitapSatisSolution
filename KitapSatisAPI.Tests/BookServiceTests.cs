using KitapSatisAPI.Models;
using KitapSatisAPI.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapSatisAPI.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public async Task GetAllBooks_ShouldReturnBooks()
        {
            // Arrange
            var mockRepo = new Mock<IBookRepository>();
            mockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(new List<Book> {
                    new Book { Id = 1, Title = "Test Kitap", Price = 100, CategoryId = 1 }
                });

            var books = await mockRepo.Object.GetAllAsync();

            // Assert
            Assert.NotNull(books);
            Assert.Single(books);
            var bookList = books.ToList();

            Assert.Equal("Test Kitap", bookList[0].Title);

        }
    }
}
