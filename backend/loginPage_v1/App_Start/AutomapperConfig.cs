using AutoMapper;
using loginPage_v1.Dto.UserDto;
using loginPage_v1.Dto.UsersBookDto;
using loginPage_v1.Models;
using System;

namespace loginPage_v1.App_Start
{
    public class AutomapperConfig
    {
        private static MapperConfiguration _mapperConfig;
        private IMapper _mapper;

        public AutomapperConfig()
        {
            _mapper = CreateMapper();
        }

        public IMapper GetMapper()
        {
            return _mapper;
        }

        public static void Configure()
        {
            _mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<User, UserFullnameDto>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));

                config.CreateMap<UsersBook, FullUsersBookDto>()
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                    .ForMember(dest => dest.BookLanguage, opt => opt.MapFrom(src => src.BookLanguage))
                    .ForMember(dest => dest.PublicationYear, opt => opt.MapFrom(src => src.PublicationYear))
                    .ForMember(dest => dest.Pages, opt => opt.MapFrom(src => src.Pages))
                    .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                    .ForMember(dest => dest.FinishingDate, opt => opt.MapFrom(src => src.FinishingDate.ToString().Split(' ')[0]))
                    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                    .ForMember(dest => dest.PersonalRating, opt => opt.MapFrom(src => src.PersonalRating))
                    .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes));
            });

            _mapperConfig.AssertConfigurationIsValid();
        }
        public static IMapper CreateMapper()
            {
                if (_mapperConfig == null)
                {
                    Configure();
                    Console.WriteLine("Warning - Wrong app startup sequence, che Global.asax");
                }
                return _mapperConfig.CreateMapper();
            }
        }
    }