using LibraryManagementCore.DTOs.Request;
using LibraryManagementCore.DTOs.Requests;
using LibraryManagementCore.DTOs.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagementCore.Services.Interface
{
    public interface IBookServices
    {
        Task<Response<string>> CreateBook(BookDTO bookDto);
        Task<Response<string>> DeleteBook(string Id);
        Task<Response<BookResponseDTO>> GetBookById(string Id);
        Task<Response<IEnumerable<BookResponseDTO>>> GetBooks();
        Task<Response<string>> UpdateBook(BookUpdateDto update);
    }
}