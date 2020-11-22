using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NicolasPlaisant.CalculaJuros.Domain.Core.Services;
using NicolasPlaisant.CalculaJuros.Domain.Core.Services.Interfaces;

namespace NicolasPlaisant.CalculaJuros.Crosscutting
{
    public class IoC
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            #region Configuration 
            services.AddSingleton(configuration);
            #endregion
        }

        public static void ApplyServices(IServiceCollection services)
        {
            #region Services
            services.AddTransient<IComumService, ComumService>();
            services.AddTransient<ICalculadoraService, CalculadoraService>();
            #endregion
        }
    }
}
