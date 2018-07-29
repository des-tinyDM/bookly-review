using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BooklyReview.Models;
using BooklyReview.Dtos;

namespace BooklyReview.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain Objects to DTO
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            //DTO to Domain Objects
            Mapper.CreateMap<CustomerDto, Customer>()
            .ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<BookDto, Book>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}