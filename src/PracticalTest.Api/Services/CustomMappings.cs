using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PracticalTestApi.Models;
using PracticalTestApi.Services.Dtos;

namespace PracticalTestApi.Services
{
    /// <summary>
    /// AutoMapper extensions.
    /// </summary>
    public static class CustomMappingExtensions
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CustomMapping());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton<IMapper>(mapper);
        }
    }

    /// <summary>
    /// Register custom mappings.
    /// </summary>
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}
