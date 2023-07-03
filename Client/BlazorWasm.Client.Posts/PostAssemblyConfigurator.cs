using BlazorWasm.Client.Posts.Services;
using BlazorWasm.Client.Posts.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlazorWasm.Client.Posts;

public static class PostAssemblyConfigurator
{
    public static IServiceCollection ConfigurePostServices(this IServiceCollection services)
    {
        services.AddScoped<IPostService, PostService>(serviceProvider =>
        {
            var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5001") };
            var logger = serviceProvider.GetRequiredService<ILogger<PostService>>();
            var postService = new PostService(httpClient, logger);

            return postService;
        });
        
        return services;
    }
}