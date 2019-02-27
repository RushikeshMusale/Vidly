using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<Customer, CustomerDto>();

            //Otherwise update() does not work. it will try to update id as well. we don't want that
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(cust => cust.Id, opt => opt.Ignore());

            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<Movie, MovieDto>();

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.DateAdded, opt=>opt.Ignore());
        }
    }
}