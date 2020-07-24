using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularDotNetProject.API.DTOs;
using AngularDotNetProject.Domain.Domain;
using AutoMapper;

namespace AngularDotNetProject.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.Headlines,
                    opt => {
                        opt.MapFrom(src => src.HeadlineEvents.Select(x => x.Headline).ToList());
                })
                .ReverseMap();

            CreateMap<Headline, HeadlineDto>()
                .ForMember(dest => dest.Events, opt => {
                    opt.MapFrom(src => src.HeadlineEvents.Select(x => x.Event).ToList());
                })
                .ReverseMap();

            CreateMap<Release, ReleaseDto>().ReverseMap();
            CreateMap<SocialNetwork, SocialNetworkDto>().ReverseMap();

        }
    }
}
