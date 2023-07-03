using BlazorWasm.Client.Birthdays.Services.Contracts;
using BlazorWasm.Shared.Models;
using Microsoft.Extensions.Logging;

namespace BlazorWasm.Client.Birthdays.Services;

public class BirthdayService : IBirthdayService
{
    private HttpClient _httpClient;
    private ILogger<BirthdayService> _logger;

    public BirthdayService(HttpClient httpClient, ILogger<BirthdayService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public Task<IList<BirthdayDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BirthdayDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<BirthdayDto> CreateAsync(BirthdayDto input)
    {
        throw new NotImplementedException();
    }

    public Task<BirthdayDto> UpdateAsync(int id, BirthdayDto input)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}