using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tournament.DTOs;
using Tournament.Models;

namespace Tournament.Profiles
{
    public class TeamsProfile : Profile
    {
        public TeamsProfile()
        {
            CreateMap<Team, TeamReadDto>();
            CreateMap<TeamCreateUpdateDto, Team>();
            CreateMap<Team, TeamCreateUpdateDto>();
        }
    }
}
