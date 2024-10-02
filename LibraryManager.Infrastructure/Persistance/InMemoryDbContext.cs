using LibraryManager.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

public class InMemoryDbContextFactory
{
    public LibraryManagerDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<LibraryManagerDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())  
            .Options;

        var dbContext = new LibraryManagerDbContext(options);

        
        dbContext.Database.EnsureCreated();  
        return dbContext;
    }
}