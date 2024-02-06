using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Ninja;
using api.Models;
using AutoMapper;

namespace api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NinjaPostDto, NinjaModel>();
            CreateMap<NinjaModel, NinjaGetDto>();
        }
    }
}