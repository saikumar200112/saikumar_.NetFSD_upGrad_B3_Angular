using Contact_Service.Models;
using Contact_Service.Repositories;

namespace Contact_Service.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        public ContactService(IContactRepository repository) => _repository = repository;

        public Task<IEnumerable<Contact>> GetAllContacts() => _repository.GetAllAsync();
        public Task<Contact> GetContactById(int id) => _repository.GetByIdAsync(id);
        public Task CreateContact(Contact contact) => _repository.AddAsync(contact);
        public Task UpdateContact(Contact contact) => _repository.UpdateAsync(contact);
        public Task RemoveContact(int id) => _repository.DeleteAsync(id);
    }
}
