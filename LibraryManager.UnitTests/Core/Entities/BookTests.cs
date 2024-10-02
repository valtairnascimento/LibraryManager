using LibraryManager.Core.Entities;

namespace LibraryManager.UnitTests.Core.Entities
{
    public class BookTests
    {
        [Fact]
        public void Create_ShouldCreateBookWithCorrectProperties()
        {
            //Arrange
            var title = "Titulo teste";
            var author = "Autor teste";
            var isbn = "123456789";
            var publicationYear = new DateTime(2024, 1, 1);

            //Act
            var book = new Book(title, author, isbn, publicationYear);  

            //Assert
            Assert.Equal(title, book.Title);
            Assert.Equal(author, book.Author);
            Assert.Equal(isbn, book.ISBN);
            Assert.Equal(publicationYear, book.PublicationYear);
        }

        [Fact]
        public void Update_ShouldUpdateBookProperties()
        {
            //Arrange
            var book = new Book("Titulo antigo", "Autor Antigo", "123456789", new DateTime(2020,1,1));
            var newTitle = "Novo Titulo";
            var newAuthor = "Novo Autor";
            var newISBN = "987654321";
            var newPublicationYear = new DateTime(2024, 1, 1);

            //Act
            book.Update(newTitle, newAuthor, newISBN, newPublicationYear);

            //Assert
            Assert.Equal(newTitle, book.Title);
            Assert.Equal(newAuthor, book.Author);
            Assert.Equal(newISBN, book.ISBN);
            Assert.Equal(newPublicationYear, book.PublicationYear);
        }

       
    }
}
