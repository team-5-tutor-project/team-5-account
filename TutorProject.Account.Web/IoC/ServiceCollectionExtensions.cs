using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TutorProject.Account.BLL.Clients.Services;
using TutorProject.Account.BLL.Tutors.Services;
using TutorProject.Account.Common;

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

        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ITutorService, TutorService>();

            return services;
        }
    }
}