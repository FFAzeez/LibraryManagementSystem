using LibraryManagementInfrastructure.Context;
using LibraryManagementInfrastructure.Model;
using LibraryManagementInfrastructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementInfrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LMDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Customer> GetCustomerBooks(string Id)
        {
            var result = await _dbContext.Customers.Include(x => x.Books).FirstOrDefaultAsync(x => x.Id == Id);
            return result;
        }
    }
}
