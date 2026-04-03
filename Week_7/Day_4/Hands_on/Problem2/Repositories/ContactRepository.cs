using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Repositories
{
    public class ContactRepository :IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(ContactInfo contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
        }

        public List<ContactInfo> GetAll()
        {
            return _context.Contacts.Include(c => c.Company).Include(c => c.Department).ToList();
        }

        public ContactInfo GetById(int id)
        {
           return _context.Contacts.Include(c => c.Company).Include(c => c.Department).FirstOrDefault(c => c.ContactId == id);
        }

        public List<Company> Getcomp()
        {
              return _context.Companies.ToList();
        }

        public List<Department> GetDept()
        {
            return _context.Departments.ToList();

        }

        public void Update(ContactInfo contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();
        }
    }
}
