using AutoMapper;
using FlorAmor.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorAmor.Application.DTO
{
    public class BlumeMappingProfile : Profile
    {
        public BlumeMappingProfile()
        {
            CreateMap<Blume, BlumeDTO>();
            CreateMap<BlumeDTO, Blume>();
               
        }
    }
}
