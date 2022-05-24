using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace TutorProject.Account.Web.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services, Action<IMapperConfigurationExpression> configure)
        {
            var mapperConfig = new MapperConfiguration(configure);
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}