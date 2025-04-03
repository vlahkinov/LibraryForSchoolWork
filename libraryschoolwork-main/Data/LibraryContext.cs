using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasIndex(u => u.FullName).IsUnique();
            modelBuilder.Entity<Account>().
                HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Role>()
                .HasIndex(u => u.Name).IsUnique();

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasMany(c => c.Carts)
                    .WithOne(e => e.Employee)
                    .HasForeignKey(c => c.EmployeeId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            
        }
    }
}
