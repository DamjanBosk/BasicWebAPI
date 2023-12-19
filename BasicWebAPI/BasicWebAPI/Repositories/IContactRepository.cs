using BasicWebAPI.Dtos;
using BasicWebAPI.Entities;

namespace BasicWebAPI.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllContacts();
        Task<Contact?> CreateContact(CreateUpdateContactRequest request);
        Task<Contact?> UpdateContact(int id, CreateUpdateContactRequest request);
        Task<bool> DeleteContact(int id);
        Task<List<Contact>> FilterContacts(int companyId, int countryId);
    }
}
