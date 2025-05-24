using LibraryManager.Api.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Api.Persistence
{
    public class LibraryManagerDb : DbContext

    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
       

        public LibraryManagerDb(DbContextOptions<LibraryManagerDb> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                 .Entity<User>(e =>
                 {
                     e.HasKey(p => p.Id);

                     e.HasMany(l => l.Loans)
                        .WithOne(u => u.User)
                        .HasForeignKey(f => f.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);
                 });

            builder
                .Entity<Book>(e =>
                {
                    e.HasKey(k => k.Id);

                    e.HasMany(m => m.Loans)
                        .WithOne(o => o.Book)
                        .HasForeignKey(f => f.IdBook)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder.Entity<Loan>(e =>
            {
                e.HasKey(k => k.Id);
            });

            base.OnModelCreating(builder);
        }
    }
}
