using AutoMapper;
using LibraryManagementCore.DTOs.Requests;
using LibraryManagementCore.DTOs.Responses;
using LibraryManagementCore.Extentions;
using LibraryManagementCore.Services.Interface;
using LibraryManagementInfrastructure.Model;
using LibraryManagementInfrastructure.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementCore.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly UserManager<Customer> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerServices(UserManager<Customer> userManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<string>> CreateCustomer(RegisterDto register)
        {
            var customer = _mapper.Map<Customer>(register);
            customer.CreateAt = DateTime.Now;
            customer.UserName = register.Email;
            var user = await _userManager.CreateAsync(customer, register.Password);
            if (user.Succeeded)
            {
                return new Response<string>
                {
                    IsSuccessful = true,
                    Message = "Customer Created Successfully.",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            return new Response<string>
            {
                IsSuccessful = false,
                Message = "Customer Not Created.",
                ResponseCode = HttpStatusCode.BadRequest
            };
        }
        public async Task<Response<CustomerResponseDto>> Login(LoginRequestDto userRequest)
        {
            Customer user = await _userManager.FindByEmailAsync(userRequest.Email);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, userRequest.Password))
                {
                    var response = _mapper.Map<CustomerResponseDto>(user);
                    return new Response<CustomerResponseDto>
                    {
                        Data= response,
                        IsSuccessful = true,
                        Message = "Customer Login Successfully.",
                        ResponseCode=HttpStatusCode.OK
                    };
                }
                return new Response<CustomerResponseDto>
                {
                    IsSuccessful = false,
                    Message = "Invalid credentials",
                    ResponseCode = HttpStatusCode.BadRequest
                };
            }
            return new Response<CustomerResponseDto>
            {
                IsSuccessful = false,
                Message = "Invalid credentials",
                ResponseCode = HttpStatusCode.BadRequest
            };
        }

        public async Task<Response<CustomerBookDto>> GetCustomerBook(string Id)
        {
            var result = await _unitOfWork.Customer.GetCustomerBooks(Id);
            if(result != null)
            {
                var map =_mapper.Map<CustomerBookDto>(result);
                return new Response<CustomerBookDto>
                {
                    Data = map,
                    IsSuccessful = true,
                    Message = "Customer Found",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            return new Response<CustomerBookDto>
            {
                Data = null,
                IsSuccessful = false,
                Message = "Customer Not Found",
                ResponseCode = HttpStatusCode.BadRequest
            };
        }

        public async Task<Response<string>> CustomerBorrowBook(BorrowRequestDto borrow)
        {
            var customer = await _unitOfWork.Customer.GetARecord(borrow.CustomerId);
            if(customer != null)
            {
                var book = await _unitOfWork.Book.GetBookDetails(borrow.BookId);
                if (book != null)
                {
                    if (book.Issue.IsAvailable)
                    {
                        book.CustomerId = customer.Id;
                        book.Issue.IssueDate = DateTime.Now;
                        book.Issue.ExpireDate = book.Issue.IssueDate.AddWorkingDays(14);
                        book.Issue.IsAvailable = false;
                        book.Issue.CustomerId = borrow.CustomerId;
                        var result = await _unitOfWork.Book.Update(book);
                        if (result)
                        {
                            return new Response<string>
                            {
                                IsSuccessful = true,
                                Message = "Book Borrowed",
                                ResponseCode = HttpStatusCode.OK
                            };
                        }
                        return new Response<string>
                        {
                            IsSuccessful = false,
                            Message = "Book Not Borrowed",
                            ResponseCode = HttpStatusCode.BadRequest
                        };
                    }
                    return new Response<string>
                    {
                        IsSuccessful = false,
                        Message = "Book Not Available",
                        ResponseCode = HttpStatusCode.BadRequest
                    };
                }
                return new Response<string>
                {
                    IsSuccessful = false,
                    Message = "Book Not Found",
                    ResponseCode = HttpStatusCode.BadRequest
                };
            }
            return new Response<string>
            {
                IsSuccessful = false,
                Message = "Customer Not Found",
                ResponseCode = HttpStatusCode.BadRequest
            };
        }

        public async Task<Response<string>> CustomerReturnBook(BorrowRequestDto borrow)
        {
            var customer = await _unitOfWork.Customer.GetARecord(borrow.CustomerId);
            if (customer != null)
            {
                var book = await _unitOfWork.Book.GetBookDetails(borrow.BookId);
                if (book != null)
                {
                    if(book.Issue.ExpireDate <= DateTime.Now)
                    {
                        book.Issue.IsAvailable = true;
                        var result = await _unitOfWork.Book.Update(book);
                        if (result)
                        {
                            return new Response<string>
                            {
                                IsSuccessful = true,
                                Message = "Book Returned",
                                ResponseCode = HttpStatusCode.OK
                            };
                        }
                        return new Response<string>
                        {
                            IsSuccessful = false,
                            Message = "Book Not Returned",
                            ResponseCode = HttpStatusCode.BadRequest
                        };
                    }
                   // book.Issue.ExpireDate 
                    /*book.Issue.IsAvailable = true;
                    var result = await _unitOfWork.Book.Update(book);*/
                    return new Response<string>
                    {
                        IsSuccessful = false,
                        Message = "Return date elaspe, you have to make payment of #5000 ",
                        ResponseCode = HttpStatusCode.Forbidden
                    };
                }
                return new Response<string>
                {
                    IsSuccessful = false,
                    Message = "Book Not Found",
                    ResponseCode = HttpStatusCode.BadRequest
                };
            }
            return new Response<string>
            {
                IsSuccessful = false,
                Message = "Customer Not Found",
                ResponseCode = HttpStatusCode.BadRequest
            };
        }

        public async Task<Response<CustomerResponseDto>> GetCustomerById(string Id)
        {
            var customer = await _unitOfWork.Customer.GetARecord(Id);
            if (customer != null)
            {
                var result = _mapper.Map<CustomerResponseDto>(customer);
                return new Response<CustomerResponseDto>
                {
                    Data = result,
                    IsSuccessful = true,
                    Message = "Customer Found",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            return new Response<CustomerResponseDto>
            {
                Data = null,
                IsSuccessful = false,
                Message = "Customer Not Found",
                ResponseCode = HttpStatusCode.BadRequest
            };
        }

        public async Task<Response<IEnumerable<CustomerResponseDto>>> GetCustomers()
        {
            var customer = await _unitOfWork.Customer.GetAllRecord();
            if (customer != null)
            {
                var result = _mapper.Map<List<CustomerResponseDto>>(customer);
                return new Response<IEnumerable<CustomerResponseDto>>
                {
                    Data = result,
                    IsSuccessful = true,
                    Message = "Customers Found",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            return new Response<IEnumerable<CustomerResponseDto>>
            {
                Data = null,
                IsSuccessful = false,
                Message = "Customers Not Found",
                ResponseCode = HttpStatusCode.BadRequest
            };
        }

        public async Task<Response<string>> UpdateCustomer(CustomerUpdateDto update)
        {
            var customer = await _unitOfWork.Customer.GetARecord(update.Id);
            if (customer != null)
            {
                customer.FirstName = string.IsNullOrWhiteSpace(update.FirstName) ? customer.FirstName : update.FirstName;
                customer.LastName = string.IsNullOrWhiteSpace(update.LastName) ? customer.LastName : update.LastName;
                customer.Address = string.IsNullOrWhiteSpace(update.Address) ? customer.Address : update.Address;
                customer.PhoneNumber = string.IsNullOrWhiteSpace(update.PhoneNumber) ? customer.PhoneNumber : update.PhoneNumber;
                var result = await _unitOfWork.Customer.Update(customer);
                if (result)
                {
                    return new Response<string>
                    {
                        IsSuccessful = true,
                        Message = "Updated Successfully.",
                        ResponseCode = HttpStatusCode.OK
                    };
                }
                return new Response<string>
                {
                    IsSuccessful = false,
                    Message = "Not Updated.",
                    ResponseCode = HttpStatusCode.BadRequest
                };
            }
            return new Response<string>
            {
                IsSuccessful = true,
                Message = "Customer Not Found",
                ResponseCode = HttpStatusCode.BadRequest
            };
        }

        public async Task<Response<string>> DeleteCustomer(string Id)
        {
            var customer = await _unitOfWork.Customer.GetARecord(Id);
            if (customer != null)
            {
                var result = await _unitOfWork.Customer.Delete(customer);
                if (result)
                {
                    return new Response<string>
                    {
                        IsSuccessful = true,
                        Message = "Customer Deleted Successfully",
                        ResponseCode = HttpStatusCode.OK
                    };
                }
                return new Response<string>
                {
                    IsSuccessful = false,
                    Message = "Customer Not Deleted",
                    ResponseCode = HttpStatusCode.BadRequest
                };
            }
            return new Response<string>
            {
                IsSuccessful = false,
                Message = "Customer Not Found",
                ResponseCode = HttpStatusCode.BadRequest
            };
        }
    }
}
