using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApi.Exceptions;
using MyApi.Managers.Abstracts;
using MyApi.Models.DTOs.ContactDtos;
using MyApi.Repositories.Abstracts;
using MyApi.SmtpMailServices;

namespace MyApi.Managers.Concretes;

public class ContactManager : IContactManager
{
    private readonly IContactRepository _repository;
    private readonly IEmailTemplateService _mailService;

    public ContactManager(IContactRepository repository, IEmailTemplateService mailService)
    {
        _repository = repository;
        _mailService = mailService;

    }

    public async Task CreateAsync(CreateContactDto dto)
    {
        await _repository.AddAsync(new()
        {
            SenderName = dto.SenderName,
            SenderEmail = dto.SenderEmail,
            SenderSubject = dto.SenderSubject,
            SenderContent = dto.SenderContent,

            CreatedDate = DateTime.UtcNow,
            IsRead = false
        });

        await _repository.SaveAsync();
        await _mailService.SendContactMessageAsync(dto, "testbarissolak@gmail.com");
    }

    public async Task<List<ListContactDto>> GetAllAsync()
        => await _repository.GetAll(tracking: false).Select(m => new ListContactDto()
        {
            Id = m.Id,
            CreatedDate = m.CreatedDate,
            IsRead = m.IsRead,
            SenderEmail = m.SenderEmail,
            SenderName = m.SenderName,
            SenderSubject = m.SenderSubject
        }).ToListAsync();

    public async Task<DetailContactDto> GetByIdAsync(string id)
    {
        var messageDetail = await _repository.GetByIdAsync(Guid.Parse(id));

        if (messageDetail == null)
            throw new NotFoundException("Mesaj bulunamadi !!!");

        if (messageDetail.IsRead == false)
        {
            messageDetail.IsRead = true;
            await _repository.SaveAsync();
        }

        return new()
        {
            SenderEmail = messageDetail.SenderEmail,
            SenderName = messageDetail.SenderName,
            SenderSubject = messageDetail.SenderSubject,
            SenderContent = messageDetail.SenderContent,

            Id = messageDetail.Id,
            CreatedDate = messageDetail.CreatedDate,
            UpdatedDate = messageDetail.UpdatedDate,
            IsRead = messageDetail.IsRead,
        };
    }

    public async Task ChangeStatus(string id)
    {
        var message = await _repository.GetByIdAsync(Guid.Parse(id));
        if (message == null)
            throw new NotFoundException("Mesaj bulunamadi !!!");

        message.IsRead = !message.IsRead;
        message.UpdatedDate = DateTime.UtcNow;
        await _repository.SaveAsync();
    }

    public async Task RemoveByIdAsync(string id)
    {
        var message = await _repository.GetByIdAsync(Guid.Parse(id));
        if (message == null)
            throw new NotFoundException("Mesaj bulunamadi !!!");

        _repository.Remove(message);
        await _repository.SaveAsync();
    }

}
