using LibraryCoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryCoreApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        #region DbSet
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Novel", IsActive = true },
                new Category { CategoryId = 2, CategoryName = "History", IsActive = true },
                new Category { CategoryId = 3, CategoryName = "Jokes", IsActive = true }
            );

            builder.Entity<Author>().HasData(
                new Author { AuthorId = 1, AuthorName = "Lema", DoB = DateTime.Parse("01/01/1997"), ContactNo = "01947193694", Email = "lema@mail.com", IsActive = true },
                new Author { AuthorId = 2, AuthorName = "Taposhe", DoB = DateTime.Parse("01/01/1997"), ContactNo = "01747193694", Email = "taposhe@mail.com", IsActive = true },
                new Author { AuthorId = 3, AuthorName = "Lee", DoB = DateTime.Parse("01/01/1996"), ContactNo = "01547193694", Email = "lee@mail.com", IsActive = true }
            );

            builder.Entity<Author>().Property(a => a.IsActive).HasDefaultValue(true);
            builder.Entity<Author>().Property(a => a.DoB).IsRequired();
            builder.Entity<Category>().Property(c => c.IsActive).HasDefaultValue(true);
            builder.Entity<Book>().Property(b => b.IsActive).HasDefaultValue(true);
            builder.Entity<Publisher>().Property(p => p.IsActive).HasDefaultValue(true);

        }
    }
}
