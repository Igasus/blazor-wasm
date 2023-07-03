using System.Net.Http.Json;
using System.Text.Json;
using BlazorWasm.Client.Posts.Services.Contracts;
using BlazorWasm.Shared.Models;
using Microsoft.Extensions.Logging;

namespace BlazorWasm.Client.Posts.Services;

public class PostService : IPostService
{
    private const string BaseRequestRoute = "api/posts";
    
    private readonly HttpClient _httpClient;
    private readonly ILogger<PostService> _logger;

    public PostService(HttpClient httpClient, ILogger<PostService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<IList<PostDto>> GetAllAsync()
    {
        var requestMethod = HttpMethod.Get;
        var requestRoute = BaseRequestRoute;
        
        var request = new HttpRequestMessage(requestMethod, requestRoute);
        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
            throw new Exception();

        var contentStream = await response.Content.ReadAsStreamAsync();
        var posts = await JsonSerializer.DeserializeAsync<List<PostDto>>(
            contentStream,
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        LogResponseBody(requestMethod, requestRoute, posts);

        return posts;
    }

    public async Task<PostDto> GetByIdAsync(int id)
    {
        var requestMethod = HttpMethod.Get;
        var requestRoute = $"{BaseRequestRoute}/{id}";
        
        var request = new HttpRequestMessage(requestMethod, requestRoute);
        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
            throw new Exception();

        var contentStream = await response.Content.ReadAsStreamAsync();
        var post = await JsonSerializer.DeserializeAsync<PostDto>(
            contentStream,
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        LogResponseBody(requestMethod, requestRoute, post);
        
        return post;
    }

    public async Task<PostDto> CreateAsync(PostDto input)
    {
        var requestMethod = HttpMethod.Post;
        var requestRoute = BaseRequestRoute;
        
        var request = new HttpRequestMessage(requestMethod, requestRoute);
        request.Content = JsonContent.Create(input);
        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
            throw new Exception();

        var contentStream = await response.Content.ReadAsStreamAsync();
        var post = await JsonSerializer.DeserializeAsync<PostDto>(
            contentStream,
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        LogResponseBody(requestMethod, requestRoute, post);

        return post;
    }

    public async Task<PostDto> UpdateAsync(int id, PostDto input)
    {
        var requestMethod = HttpMethod.Put;
        var requestRoute = $"{BaseRequestRoute}/{id}";
        
        var request = new HttpRequestMessage(requestMethod, requestRoute);
        request.Content = JsonContent.Create(input);
        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
            throw new Exception();

        var contentStream = await response.Content.ReadAsStreamAsync();
        var post = await JsonSerializer.DeserializeAsync<PostDto>(
            contentStream,
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        
        LogResponseBody(requestMethod, requestRoute, post);

        return post;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var requestMethod = HttpMethod.Delete;
        var requestRoute = $"{BaseRequestRoute}/{id}";

        var request = new HttpRequestMessage(requestMethod, requestRoute);
        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
            throw new Exception();
        
        LogResponseBody(requestMethod, requestRoute, null);
    }

    private void LogResponseBody(HttpMethod httpMethod, string route, object responseBody)
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        
        var httpMethodString = httpMethod.ToString();
        var responseBodyString = JsonSerializer.Serialize(responseBody, jsonSerializerOptions);

        _logger.LogInformation(
            "{HttpMethod} - \"{Route}\" response body: {ResponseBody}",
            httpMethodString,
            route,
            responseBodyString);
    }
}