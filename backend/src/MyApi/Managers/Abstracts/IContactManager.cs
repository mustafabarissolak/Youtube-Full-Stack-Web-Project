using MyApi.Models.DTOs.ContactDtos;

namespace MyApi.Managers.Abstracts;

public interface IContactManager
{
    Task<List<ListContactDto>> GetAllAsync();
    Task<DetailContactDto> GetByIdAsync(string id);
    Task CreateAsync(CreateContactDto dto);
    Task ChangeStatus(string id);
    Task RemoveByIdAsync(string id);
}
