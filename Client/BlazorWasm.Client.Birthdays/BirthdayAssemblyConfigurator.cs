using BlazorWasm.Client.Birthdays.Services;
using BlazorWasm.Client.Birthdays.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlazorWasm.Client.Birthdays;

public static class BirthdayAssemblyConfigurator
{
    public static IServiceCollection ConfigureBirthdayServices(this IServiceCollection services)
    {
        services.AddScoped<IBirthdayService, BirthdayService>(serviceProvider =>
        {
            var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5001") };
            var logger = serviceProvider.GetRequiredService<ILogger<BirthdayService>>();
            var postService = new BirthdayService(httpClient, logger);

            return postService;
        });
        
        return services;
    }
}