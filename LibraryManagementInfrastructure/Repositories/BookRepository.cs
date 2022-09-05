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
    public class BookRepository:GenericRepository<Book>, IBookRepository
    {
        public BookRepository(LMDbContext context):base(context)
        {
        }

        public async Task<Book> GetBookDetails(string Id)
        {
            return await _dbContext.Books.Include(x => x.Issue).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<Book>> GetAllBook()
        {
            return await _dbContext.Books.Include(x => x.Issue).ToListAsync();
        }
    }
}
