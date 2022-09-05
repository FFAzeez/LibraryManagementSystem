using LibraryManagementCore.DTOs.Requests;
using LibraryManagementCore.DTOs.Responses;
using System.Threading.Tasks;

namespace LibraryManagementCore.Services.Interface
{
    public interface IClientServices
    {
        Task<Response<ClientResponseDto>> LoginClient(LoginRequestDto login);
        Task<Response<string>> RegisterClient(ClientDto clientDto);
    }
}