using LibraryManagementCore.DTOs.Requests;
using LibraryManagementCore.DTOs.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementCore.Services.Interface
{
    public interface ICustomerServices
    {
        Task<Response<string>> CreateCustomer(RegisterDto register);
        Task<Response<string>> DeleteCustomer(string Id);
        Task<Response<CustomerResponseDto>> Login(LoginRequestDto userRequest);
        Task<Response<CustomerResponseDto>> GetCustomerById(string Id);
        Task<Response<IEnumerable<CustomerResponseDto>>> GetCustomers();
        Task<Response<string>> UpdateCustomer(CustomerUpdateDto update);
        Task<Response<string>> CustomerReturnBook(BorrowRequestDto borrow);
        Task<Response<string>> CustomerBorrowBook(BorrowRequestDto borrow);
        Task<Response<CustomerBookDto>> GetCustomerBook(string Id);

    }
}