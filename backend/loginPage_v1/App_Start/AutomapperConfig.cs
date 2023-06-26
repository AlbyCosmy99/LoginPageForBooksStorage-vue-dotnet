using AutoMapper;
using loginPage_v1.Dto.UserDto;
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