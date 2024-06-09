using AutoMapper;
using FlorAmor.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorAmor.Application.DTO
{
    public class LadenMappingProfile : Profile
    {
        public LadenMappingProfile()
        {
            CreateMap<Laden, LadenDTO>();
            CreateMap<LadenDTO, Laden>();

        }
    }
}
