using Microsoft.Extensions.DependencyInjection;

namespace QuoteAuto.Application.Services;

public static class DependecyServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddQuoteService();
        return services;
    }
}