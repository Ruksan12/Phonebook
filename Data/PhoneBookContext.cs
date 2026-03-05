using Microsoft.EntityFrameworkCore;
using PhoneBook.Ruksan12.Models;

namespace PhoneBook.Ruksan12.Data
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext() { }
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options){}
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PhoneBookDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact { Id = 1, Name = "Alice Johnson", PhoneNumber = "9875550101", Email = "alice@example.com" },
                new Contact { Id = 2, Name = "Bob Smith", PhoneNumber = "986555-0102", Email = "bob@example.com" },
                new Contact { Id = 3, Name = "Carol Davis", PhoneNumber = "978555-0103", Email = "carol@example.com" }
            );
        }
    }
        
}
