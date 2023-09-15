using Pro.Business.Interfaces;
using Pro.Business.Notificacoes;
using Pro.Business.Services;
using Pro.Data.Context;
using Pro.Data.Repository;

namespace Pro.WebAPI.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependecies (this IServiceCollection services)
    {
        services.AddScoped<ApiContext>();

        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        services.AddScoped<IServicoRepository, ServicoRepository>();

        services.AddScoped<INotificador, Notificador>();
        services.AddScoped<IClienteService, ClienteService>();

        return services;
    }
}
