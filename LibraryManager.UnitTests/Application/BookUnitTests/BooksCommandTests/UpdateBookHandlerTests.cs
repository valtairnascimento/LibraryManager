using LibraryManager.Application.Commands.BookCommands.UpdateBook;
using LibraryManager.Core.Entities;
using LibraryManager.Infrastructure.Persistance.Repositories;
using System.Net;

namespace LibraryManager.UnitTests.Application.BookUnitTests.BooksCommandTests
{
    public class UpdateBookHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldUpdateBook_WhenBookExists()
        {
            //Arrange
            var dbContextFactory = new InMemoryDbContextFactory();
            var context = dbContextFactory.CreateDbContext();
            var repository = new BookRepository(context);
            var handler = new UpdateBookHandler(repository);

            var book = new Book("Livro 1", "Autor 1", "12313", DateTime.Now.AddYears(-15));
            var bookId = await repository.Add(book);

            var updateCommand = new UpdateBookCommand(bookId, "Livro Atualizado", "Autor Atualizado", "456123", DateTime.Today);

            //Act
            var result = await handler.Handle(updateCommand, CancellationToken.None);   

            //Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);

            var updatedBook = await repository.GetById(bookId);
            Assert.NotNull(updatedBook);
            Assert.Equal("Livro Atualizado", updatedBook.Title);
            Assert.Equal("Autor Atualizado", updatedBook.Author);
            Assert.Equal("456123", updatedBook.ISBN);
            Assert.Equal(DateTime.Today, updatedBook.PublicationYear);
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenBookDoesNotExist()
        {
            //Arrange
            var dbContextFactory = new InMemoryDbContextFactory();
            var context = dbContextFactory.CreateDbContext();
            var repository = new BookRepository(context);
            var handler = new UpdateBookHandler(repository);

            var updateCommand = new UpdateBookCommand(999999, "Livro Atualizado", "Autor Atualizado", "456123", DateTime.Today);

            //Act
            var result = await handler.Handle(updateCommand, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
            Assert.Equal("Livro nao existe", result.Message);
        }
    }
}
