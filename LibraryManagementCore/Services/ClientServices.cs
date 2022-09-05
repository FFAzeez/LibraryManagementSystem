using AutoMapper;
using LibraryManagementCore.DTOs.Requests;
using LibraryManagementCore.DTOs.Responses;
using LibraryManagementCore.Services.Interface;
using LibraryManagementInfrastructure.Model;
using LibraryManagementInfrastructure.Repositories.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementCore.Services
{
    public class ClientServices : IClientServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public ClientServices(IMapper mapper, IConfiguration config, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _config = config;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<string>> RegisterClient(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            client.Id = Guid.NewGuid().ToString();
            client.ApiKey = _config["ApiKeyString:ApiKey"];
            var result = await _unitOfWork.Client.Add(client);
            if (result)
            {
                return new Response<string>
                {
                    IsSuccessful = true,
                    Message = "Client Successfully Created.",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            return new Response<string>
            {
                IsSuccessful = false,
                Message = "Client Not Successfully Created.",
                ResponseCode = HttpStatusCode.BadRequest
            };
        }

        public async Task<Response<ClientResponseDto>> LoginClient(LoginRequestDto login)
        {
            var client = await _unitOfWork.Client.Login(login.Email, login.Password);
            if (client != null)
            {
                var result = _mapper.Map<ClientResponseDto>(client);
                return new Response<ClientResponseDto>
                {
                    Data = result,
                    IsSuccessful = true,
                    Message = "Login Successfully",
                    ResponseCode = HttpStatusCode.OK
                };
            }
            return new Response<ClientResponseDto>
            {
                IsSuccessful = false,
                Message = "Invalid Email or Password",
                ResponseCode = HttpStatusCode.OK
            };
        }
    }
}
