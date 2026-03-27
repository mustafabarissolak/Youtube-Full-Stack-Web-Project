using MyApi.Context;
using MyApi.Models.Entities;
using MyApi.Repositories.Abstracts;

namespace MyApi.Repositories.Concretes;

public class ContactRepository : Repository<Contact>, IContactRepository
{
    public ContactRepository(AppDbContext context) : base(context) { }
}
