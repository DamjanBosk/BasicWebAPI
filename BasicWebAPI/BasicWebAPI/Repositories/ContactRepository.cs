using BasicWebAPI.Data;
using BasicWebAPI.Dtos;
using BasicWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace BasicWebAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _dataContext;

        public ContactRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Contact>> GetAllContacts()
        {
            return await _dataContext.Contacts.ToListAsync();
        }

        public async Task<Contact?> CreateContact(CreateUpdateContactRequest request)
        {
            if (request == null || request.Name.IsNullOrEmpty())
            {
                return null;
            }

            Contact contact = new Contact();
            contact.Name = request.Name;
            contact.CompanyId = request.CompanyId;
            contact.CountryId = request.CountryId;

            _dataContext.Contacts.Add(contact);
            await _dataContext.SaveChangesAsync();

            return contact;
        }

        public async Task<Contact?> UpdateContact(int id, CreateUpdateContactRequest request)
        {
            var contact = await _dataContext.Contacts.FindAsync(id);
            if (contact == null || request == null || request.Name.IsNullOrEmpty())
            {
                return null;
            }

            contact.Name = request.Name;
            contact.CompanyId = request.CompanyId;
            contact.CountryId = request.CountryId;
            await _dataContext.SaveChangesAsync();

            return contact;
        }

        public async Task<bool> DeleteContact(int id)
        {
            var contact = await _dataContext.Contacts.FindAsync(id);
            if (contact == null)
            {
                return false;
            }

            _dataContext.Contacts.Remove(contact);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Contact>> FilterContacts(int companyId, int countryId)
        {
            var filteredContacts = await _dataContext.Contacts
                .Where(c => c.CompanyId == companyId || c.CountryId == countryId)
                .ToListAsync();
            return filteredContacts;
        }
    }
}
