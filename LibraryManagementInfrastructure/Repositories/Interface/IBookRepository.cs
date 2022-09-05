using LibraryManagementInfrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementInfrastructure.Repositories.Interface
{
    public interface IBookRepository:IGenericRepository<Book>
    {
        Task<Book> GetBookDetails(string Id);
        Task<IEnumerable<Book>> GetAllBook();
    }
}
