using WebApplication12.Models;

namespace WebApplication12.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAll();
        Contact? GetById(int id);
        void Add(Contact contact);
        bool Update(int id, Contact contact);
        bool Delete(int id);
    }
}
