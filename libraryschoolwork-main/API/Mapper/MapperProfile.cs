using AutoMapper;
using Data.Entities;
using Domain.Dtos;
using Domain.Dtos.Account;
using Domain.Dtos.Book;

namespace API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AccountDto, Account>().ReverseMap();
            CreateMap<AccountDtoWithId, Account>().ReverseMap();
            CreateMap<AccountLoginDto, Account>().ReverseMap();
            CreateMap<BookDto, Book>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Cart, CartDto>().ReverseMap();

        }
    }
}
