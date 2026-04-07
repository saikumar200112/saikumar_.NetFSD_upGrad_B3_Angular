using WebApplication7.Models;

namespace WebApplication7.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<ContactInfo> GetAllContacts();
        IEnumerable<Company> GetCompanies();
        IEnumerable<Department> GetDepartments();
        ContactInfo GetContactById(int id);
        void AddContact(ContactInfo contact);
        void UpdateContact(ContactInfo contact);
        void DeleteContact(int id);
    }
}
