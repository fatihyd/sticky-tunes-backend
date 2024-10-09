using AutoMapper;
using sticky_tunes_backend.DTOs;
using sticky_tunes_backend.Models;

namespace sticky_tunes_backend.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Post, GetPostDto>();
    }
}