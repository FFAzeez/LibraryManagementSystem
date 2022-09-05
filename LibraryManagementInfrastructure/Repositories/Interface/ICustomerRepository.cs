using LibraryManagementInfrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementInfrastructure.Repositories.Interface
{
    public interface ICustomerRepository:IGenericRepository<Customer>
    {
        Task<Customer> GetCustomerBooks(string Id);
    }
}
