using WebApplication6.Models;

namespace WebApplication6.Repositories
{
    public interface IContactRepository
    {
        List<ContactInfo> GetAll();
        ContactInfo GetById(int id);
        void Add(ContactInfo contact);
        void Update(ContactInfo contact);
        void Delete(int id);
       
        List<Company> Getcomp();
        List<Department> GetDept();
    }
}
