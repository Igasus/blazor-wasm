using BlazorWasm.Shared.Models;

namespace BlazorWasm.Client.Birthdays.Services.Contracts;

public interface IBirthdayService
{
    Task<IList<BirthdayDto>> GetAllAsync();
    Task<BirthdayDto> GetByIdAsync(int id);
    Task<BirthdayDto> CreateAsync(BirthdayDto input);
    Task<BirthdayDto> UpdateAsync(int id, BirthdayDto input);
    Task DeleteByIdAsync(int id);
}