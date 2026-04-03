using WebApplication6.Models;
using WebApplication6.Repositories;

namespace WebApplication6.Services
{
    public class ContactService :IContactService
    {
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public void AddContact(ContactInfo contact)
        {
            _repository.Add(contact);
        }

        

        public void DeleteContact(int id)
        {
            _repository.Delete(id);
        }

        public List<ContactInfo> GetAllContacts()
        {
            return _repository.GetAll();
        }

        public List<Company> GetCompanies()
        {
           return  _repository.Getcomp();
        }

        public ContactInfo GetContactById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Department> GetDepartments()
        {
            return _repository.GetDept();
        }

        public void UpdateContact(ContactInfo contact)
        {
            _repository.Update(contact);
        }
    }
}
