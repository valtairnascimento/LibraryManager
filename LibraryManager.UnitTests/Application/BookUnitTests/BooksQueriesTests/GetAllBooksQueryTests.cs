using LibraryManager.Application.Queries.BookQueries.GetAll;
using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Persistance.Repositories;

namespace LibraryManager.UnitTests.Application.BookUnitTests.BooksQueriesTests
{
    public class GetAllBooksQueryTests
    {
        [Fact]
        public async Task Handle_ShouldReturnAllBooks()
        {
            //Arrange
            var dbContextFactory = new InMemoryDbContextFactory();
            var context = dbContextFactory.CreateDbContext();
            var repository = new BookRepository(context);
            var handler = new GetAllBooksHandler(repository);

            await repository.Add(new Book("Livro teste1", "autor teste 1", "54321", DateTime.Now));
            await repository.Add(new Book("Livro teste2", "autor teste 2", "1234", DateTime.Now));
            await repository.Add(new Book("Livro teste3", "autor teste 3", "54321", DateTime.Now));

            var query = new GetAllBooksQuery();

            //Act

            var result = await handler.Handle(query, CancellationToken.None);

            //Assert

            Assert.NotNull(result);
            Assert.Equal(3, result.Data.Count);


        }
    }
}
