using BlazorWasm.Shared.Models;

namespace BlazorWasm.Client.Posts.Services.Contracts;

public interface IPostService
{
    Task<IList<PostDto>> GetAllAsync();
    Task<PostDto> GetByIdAsync(int id);
    Task<PostDto> CreateAsync(PostDto input);
    Task<PostDto> UpdateAsync(int id, PostDto input);
    Task DeleteByIdAsync(int id);
}