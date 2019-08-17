using System.Linq;
using AutoMapper;
using DatingApp.api.Dtos;
using DatingApp.api.Models;

namespace DatingApp.api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, options =>
                options.MapFrom(src => src.Photos.FirstOrDefault(u => u.IsMain).Url))
                .ForMember(dest => dest.Age, options =>
                options.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, options =>
                options.MapFrom(x => x.Photos.FirstOrDefault(u => u.IsMain).Url))
                .ForMember(dest => dest.Age, options =>
                options.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoForDetailedDto>();
        }
    }
}