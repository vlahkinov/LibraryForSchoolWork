using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public  class Seeder
    {
        public static async Task Seed(LibraryContext context)
        {
            if (!context.Employees.Any())
            {
                var roles = new List<Role>()
        {
            new Role() { Name = "Administrator" },
            new Role() { Name = "Employee" },
            new Role() { Name = "Client" }
        };
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();

                var books = new List<Book>()
        {
            new Book() { Title = "Istoriq", Year = 1892, IsDeleted = false, Author = "Ivan Vazov" },
            new Book() { Title = "Borba", Year = 1852, IsDeleted = false, Author = "Ivan Vazov" }
        };
                context.Books.AddRange(books);
                await context.SaveChangesAsync();

                var accounts = new List<Account>()
        {
            new Account() { Email = "admin@test.com", FullName = "AdminName", Password = "Pas$w0rd", RoleId = roles[0].Id, IsDeleted = false },
            new Account() { Email = "employee@test.com", FullName = "EmployeeName", Password = "Pas$w0rd", RoleId = roles[1].Id, IsDeleted = false },
            new Account() { Email = "client@test.com", FullName = "ClientName", Password = "Pas$w0rd", RoleId = roles[2].Id, IsDeleted = false }
        };
                context.Accounts.AddRange(accounts);
                await context.SaveChangesAsync();

                var clients = new List<Client>()
        {
            new Client() { Age = 24, BookPreferences = "Poems", AccountId = accounts[2].Id }
        };
                context.Clients.AddRange(clients);
                await context.SaveChangesAsync();

                var employees = new List<Employee>()
        {
            new Employee() { Title = "OfficeEmployee", IsActive = false, PhoneNumber = "359033312", AccountId = accounts[0].Id },
            new Employee() { Title = "DeskEmployee", IsActive = true, PhoneNumber = "359033312", AccountId = accounts[1].Id }
        };
                context.Employees.AddRange(employees);
                await context.SaveChangesAsync();

                var cart = new Cart()
                {
                    ClientId = clients[0].Id,
                    EmployeeId = employees[1].Id,
                    Books = books
                };
                context.Carts.Add(cart);
                await context.SaveChangesAsync();
            }
        }
    }
}
