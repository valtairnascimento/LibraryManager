using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Persistance.Repositories;

namespace LibraryManager.UnitTests.Application.BookUnitTests

{
    public class BookRepositoryTests
    {
        [Fact]
        public async Task Add_ShouldAddBookToDatabase()
        {
            // Arrange
            var dbContextFactory = new InMemoryDbContextFactory();
            var context = dbContextFactory.CreateDbContext();
            var repository = new BookRepository(context);

            var book = new Book("Livro teste", "Autor teste", "12345", DateTime.Now);

            // Act
            var result = await repository.Add(book);

            // Assert
            Assert.True(result > 0);
            Assert.True(await repository.Exists(result));
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllBooks()
        {
            // Arrange
            var dbContextFactory = new InMemoryDbContextFactory();
            var context = dbContextFactory.CreateDbContext();
            var repository = new BookRepository(context);

            await repository.Add(new Book("Livro 1", "Autor 1", "12345", DateTime.Now));
            await repository.Add(new Book("Livro 2", "Autor 2", "12345", DateTime.Now));

            // Act
            var books = await repository.GetAll();

            // Assert
            Assert.Equal(2, books.Count);

        }
    }
}
