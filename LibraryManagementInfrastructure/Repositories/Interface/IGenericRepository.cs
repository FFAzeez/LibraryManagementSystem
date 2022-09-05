using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementInfrastructure.Repositories.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<bool> Delete(T entity);
        Task<IEnumerable<T>> GetAllRecord();
        Task<T> GetARecord(string Id);
        Task<bool> Update(T entity);
    }
}
