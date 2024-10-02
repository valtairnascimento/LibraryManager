using LibraryManager.Application.Commands.BookCommands.InsertBook;
using LibraryManager.Infrastructure.Persistance.Repositories;

namespace LibraryManager.UnitTests.Application.BookUnitTests.BooksCommandTests
{
    public class InsertBookHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldInsertBookSuccessfully()
        {
            // Arrange
            var dbContextFactory = new InMemoryDbContextFactory();
            var context = dbContextFactory.CreateDbContext();
            var repository = new BookRepository(context);
            var handler = new InsertBookHandler(repository);

            var insertCommand = new InsertBookCommand("Novo livro", "Autor", "12456", DateTime.Today);

            //Act
            var result = await handler.Handle(insertCommand, CancellationToken.None);   

            //Assert

            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
            Assert.True(result.Data > 0);

            //Verificar se realmente o livro foi criado

            var insertedBook = await repository.GetById(result.Data);
            Assert.NotNull(insertedBook);
            Assert.Equal("Novo livro", insertedBook.Title);
            Assert.Equal("Autor", insertedBook.Author);
            Assert.Equal("12456", insertedBook.ISBN);
            Assert.Equal(DateTime.Today, insertedBook.PublicationYear);


        }
    }
}
