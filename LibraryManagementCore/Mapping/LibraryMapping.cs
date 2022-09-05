using AutoMapper;
using LibraryManagementCore.DTOs.Request;
using LibraryManagementCore.DTOs.Requests;
using LibraryManagementCore.DTOs.Responses;
using LibraryManagementInfrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementCore.Mapping
{
    public class LibraryMapping:Profile
    {
        public LibraryMapping()
        {
            CreateMap<Book,BookDTO>()
                .ForMember(x=>x.IsAvailable, opt=>opt.MapFrom(x=>x.Issue.IsAvailable)).ReverseMap();
            CreateMap<Book,BookResponseDTO>()
                .ForMember(x => x.IsAvailable, opt => opt.MapFrom(x => x.Issue.IsAvailable)).ReverseMap();
            CreateMap<ClientDto, Client>().ReverseMap();
            CreateMap<ClientResponseDto, Client>().ReverseMap();
            CreateMap<CustomerResponseDto, Customer>().ReverseMap();
            CreateMap<Customer,CustomerBookDto>()
                .ForMember(x => x.Books, opt=>opt.MapFrom(x=>x.Books)).ReverseMap();
            CreateMap<RegisterDto, Customer>().ReverseMap();
        }
    }
}
