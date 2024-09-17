using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace LibraryManager.Infrastructure.Persistance
{
    public class LibraryManagerDbContext : DbContext
    {
        public LibraryManagerDbContext(DbContextOptions<LibraryManagerDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                 .Entity<Book>(b =>
                 {
                     b.HasKey(b => b.Id);
                    
                 });
            builder
                .Entity<Loan>(l =>
                {
                    l.HasKey(l => l.Id);

                    l.HasOne(l => l.User)
                    .WithMany(l => l.Loans)
                    .HasForeignKey(l => l.IdUser).OnDelete(DeleteBehavior.Restrict);

                    l.HasOne(l => l.Book)
                    .WithMany(l => l.Loans)
                    .HasForeignKey(l => l.IdBook).OnDelete(DeleteBehavior.Restrict);

                });
            builder
                .Entity<User>(u =>
                {
                    u.HasKey(u => u.Id);

                    u.HasMany(u => u.Loans).WithOne(u => u.User).HasForeignKey(u => u.IdUser).OnDelete(DeleteBehavior.Restrict);
                    
                });

            base.OnModelCreating(builder);
        }
    }
}
