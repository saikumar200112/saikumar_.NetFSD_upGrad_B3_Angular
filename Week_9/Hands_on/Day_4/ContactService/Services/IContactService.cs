using Contact_Service.Models;

namespace Contact_Service.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<Contact> GetContactById(int id);
        Task CreateContact(Contact contact);
        Task UpdateContact(Contact contact);
        Task RemoveContact(int id);
    }
}
