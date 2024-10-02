using LibraryManager.Application.Commands.BookCommands.DeleteBook;
using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Persistance.Repositories;

namespace LibraryManager.UnitTests.Application.BookUnitTests.BooksCommandTests
{
    public class DeleteBookHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldDeleteBook_WhenBookExists()
        {
            //Arrange
            var dbContextFactory = new InMemoryDbContextFactory();
            var context = dbContextFactory.CreateDbContext();
            var repository =  new BookRepository(context);
            var handler = new DeleteBookHandler(repository);

            var book = new Book("Novo livro", "John Doe", "789456", DateTime.Now);
            var bookId = await repository.Add(book);

            var deleteCommand = new DeleteBookCommand(bookId);

            //Act

            var result = await handler.Handle(deleteCommand, CancellationToken.None);

            //Assert

            Assert.NotNull(result);
            Assert.True(result.IsSuccess);  

            var deleteBook = await repository.GetById(bookId);
            Assert.NotNull(deleteBook);
            Assert.True(deleteBook.IsDeleted);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenBookDoesNotExist()
        {
            var dbContextFactory = new InMemoryDbContextFactory();
            var context = dbContextFactory.CreateDbContext();
            var repository = new BookRepository(context);
            var handler = new DeleteBookHandler(repository);

            var deleteCommand = new DeleteBookCommand(99999);

            //Act
            var result = await handler.Handle(deleteCommand, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
            Assert.Equal("Livro nao existe", result.Message);
        }
    }
}
