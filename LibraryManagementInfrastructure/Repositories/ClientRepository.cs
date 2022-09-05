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
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(LMDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Client> Login(string email, string password)
        {
            return await _dbContext.Clients.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
    }
}
