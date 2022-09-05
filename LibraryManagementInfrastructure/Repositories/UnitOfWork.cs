using LibraryManagementInfrastructure.Context;
using LibraryManagementInfrastructure.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementInfrastructure.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly LMDbContext _context;
        public UnitOfWork(LMDbContext context)
        {
            _context = context;
            Book = new BookRepository(_context);
            Client = new ClientRepository(_context);
            Customer = new CustomerRepository(_context);
        }

        public IBookRepository Book { get; private set; }
        public IClientRepository Client { get; private set; }
        public ICustomerRepository Customer { get; private set; }
    }
}
