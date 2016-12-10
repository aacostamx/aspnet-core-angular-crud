using Lauderdale.App.Domain.Interfaces.Repository;
using Lauderdale.Application.Interfaces.Services;
using Lauderdale.Application.Service;
using Lauderdale.Domain.Interfaces.Repository;
using Lauderdale.Infra.Repository;
using Lauderdale.Infra.Repository.Repository;
using Lauderdale.Repository.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Lauderdale.UI.Web.Providers
{
    public static class InjectorExtensions
    {
        public static void ApplyDependencyInjector(this IServiceCollection service)
        {
            service.AddScoped<EntitiesContext, EntitiesContext>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<ICityRepository, CityRepository>();
            service.AddScoped<ICityService, CityService>();
        }
    }
}
