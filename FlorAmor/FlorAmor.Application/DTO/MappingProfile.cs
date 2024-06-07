using AutoMapper;
using FlorAmor.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorAmor.Application.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Blume, BlumeDTO>();  // Blume --> BlumeDto
            CreateMap<BlumeDTO, Blume>();  // BlumeDto --> Blume
        }
    }
}
