using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementInfrastructure.Repositories.Interface
{
    public interface IUnitOfWork
    {
        IBookRepository Book{ get; }
        IClientRepository Client { get; }
        ICustomerRepository Customer { get; }
    }
}
