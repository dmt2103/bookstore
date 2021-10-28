using BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1 to Many (Category - Book)
            modelBuilder.Entity<Book>()
                .HasOne(c => c.Category)
                .WithMany(b => b.Books)
                .HasForeignKey(s => s.CategoryId);

            // Many to Many (Book - Tag)
            modelBuilder.Entity<BookTag>().HasKey(bt => new { bt.BookId, bt.TagId });

            modelBuilder.Entity<BookTag>()
                .HasOne(bt => bt.Book)
                .WithMany(t => t.BookTags)
                .HasForeignKey(bt => bt.BookId);

            modelBuilder.Entity<BookTag>()
                .HasOne(bt => bt.Tag)
                .WithMany(b => b.BookTags)
                .HasForeignKey(bt => bt.TagId);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BookTag> BookTags { get; set; }
    }
}