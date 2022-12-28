using APIMantenimiento.Models.Config;
using AutoMapper;

namespace APIMantenimiento.App_Start
{
    internal static  class AutoMapperConfig
    {
        /// <summary>
        /// Add Auto Mapper Configuration
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        internal static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            IMapper mapper = mapperConfig.CreateMapper();
            return services.AddSingleton(mapper);
        }
    }
}
