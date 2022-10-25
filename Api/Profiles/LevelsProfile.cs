using Api.Dtos.Level;
using Api.Models;
using AutoMapper;

namespace Api.Profiles
{
    public class LevelsProfile : Profile
    {
        public LevelsProfile()
        {
            CreateMap<Level, LevelReadDto>();
            CreateMap<LevelCreateDto, Level>();
        }
    }
}