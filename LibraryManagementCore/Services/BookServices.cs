using AutoMapper;
using LibraryManagementCore.DTOs.Request;
using LibraryManagementCore.DTOs.Requests;
using LibraryManagementCore.DTOs.Responses;
using LibraryManagementCore.Services.Interface;
using LibraryManagementInfrastructure.Model;
using LibraryManagementInfrastructure.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementCore.Services
{
    public class BookServices : IBookServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookServices(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<string>> CreateBook(BookDTO bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            book.Id = Guid.NewGuid().ToString();
            book.CreateAt = DateTime.Now;
            book.Issue.Id = Guid.NewGuid().ToString();
            book.Issue.BookId = book.Id;
            var result = await _unitOfWork.Book.Add(book);
            if (result)
            {
                return new Response<string>
                {
                    IsSuccessful = true,
                    Message = "Book is Successfully Created.",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            return new Response<string>
            {
                IsSuccessful = false,
                Message = "Book Not Created",
                ResponseCode = HttpStatusCode.BadRequest
            };
        }

        public async Task<Response<BookResponseDTO>> GetBookById(string Id)
        {
            var book = await _unitOfWork.Book.GetBookDetails(Id);
            if (book != null)
            {
                var result = _mapper.Map<BookResponseDTO>(book);
                return new Response<BookResponseDTO>
                {
                    Data = result,
                    IsSuccessful = true,
                    Message = "Book Found",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            return new Response<BookResponseDTO>
            {
                Data = null,
                IsSuccessful = false,
                Message = "Book Not Found",
                ResponseCode = HttpStatusCode.BadRequest
            };
        }

        public async Task<Response<IEnumerable<BookResponseDTO>>> GetBooks()
        {
            var books = await _unitOfWork.Book.GetAllBook();
            if (books != null)
            {
                var result = _mapper.Map<IEnumerable<BookResponseDTO>>(books);
                return new Response<IEnumerable<BookResponseDTO>>
                {
                    Data = result,
                    IsSuccessful = true,
                    Message = "Books Found",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            return new Response<IEnumerable<BookResponseDTO>>
            {
                Data = null,
                IsSuccessful = false,
                Message = "Books Not Found",
                ResponseCode = HttpStatusCode.BadRequest
            };
        }

        public async Task<Response<string>> UpdateBook(BookUpdateDto update)
        {
            var book = await _unitOfWork.Book.GetARecord(update.Id);
            if (book != null)
            {
                book.Description = update.Description;
                book.Edition = update.Edition;
                book.UpdateAt = DateTime.Now;
                await _unitOfWork.Book.Update(book);
                return new Response<string>
                {
                    IsSuccessful = true,
                    Message = "Book Updated Successfully",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            return new Response<string>
            {
                IsSuccessful = false,
                Message = "Book Not Found",
                ResponseCode = HttpStatusCode.BadRequest
            };
        }

        public async Task<Response<string>> DeleteBook(string Id)
        {
            var book = await _unitOfWork.Book.GetARecord(Id);
            if (book != null)
            {
                var result = await _unitOfWork.Book.Delete(book);
                if (result)
                {
                    return new Response<string>
                    {
                        IsSuccessful = true,
                        Message = "Book Deleted Successfully",
                        ResponseCode = HttpStatusCode.OK
                    };
                }
                return new Response<string>
                {
                    IsSuccessful = false,
                    Message = "Book Not Deleted.",
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
    }
}
