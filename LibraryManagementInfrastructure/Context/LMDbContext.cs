using LibraryManagementInfrastructure.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementInfrastructure.Context
{
    public class LMDbContext:IdentityDbContext
    {
        public LMDbContext(DbContextOptions<LMDbContext> options):base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
