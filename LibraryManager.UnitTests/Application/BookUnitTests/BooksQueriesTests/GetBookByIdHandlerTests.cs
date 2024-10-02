using LibraryManager.Application.Queries.BookQueries.GetById;
using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Persistance.Repositories;

namespace LibraryManager.UnitTests.Application.BookUnitTests.BooksQueriesTests
{
    public class GetBookByIdHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnBook_WhenBookExists()
        {
            //Arrange
            var dbContextFactory = new InMemoryDbContextFactory();
            var context = dbContextFactory.CreateDbContext();
            var repository = new BookRepository(context);
            var handler = new GetBookByIdHandler(repository);

            var book = new Book("Livro Teste", "Autor Teste", "456789", DateTime.Now);

            var bookId = await repository.Add(book);

            var query = new GetBookByIdQuery(bookId);

            //Act

            var result = await handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.Equal(book.Id, result.Data.Id);
            Assert.Equal("Livro Teste", result.Data.Title);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenBookDoesNotExist()
        {
            //Arrange
            var dbContextFactory = new InMemoryDbContextFactory();
            var context = dbContextFactory.CreateDbContext();
            var repository = new BookRepository(context);
            var handler = new GetBookByIdHandler(repository);

            var query = new GetBookByIdQuery(999);

            //Act
            var result = await handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
            Assert.Equal("Livro nao existe", result.Message);
        }
    }
}
