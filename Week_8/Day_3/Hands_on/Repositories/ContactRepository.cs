using WebApplication9.Models;

namespace WebApplication9.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo { ContactId = 1, FirstName = "Saikumar", LastName = "Kagithala", EmailId = "sai123@gmail.com", MobileNo = 9876543210, Designation = "Developer", CompanyId = 1, DepartmentId = 10 },
            new ContactInfo { ContactId = 2, FirstName = "Jaswanth", LastName = "Kagithala", EmailId = "Jashu@gmail.com", MobileNo = 9876543120, Designation = "web-Developer", CompanyId = 2, DepartmentId = 20 },
            new ContactInfo { ContactId = 3, FirstName = "Vamsi", LastName = "Royal", EmailId = "vamsi234@gmail.com", MobileNo = 9876544320, Designation = "AndroidDeveloper", CompanyId = 3, DepartmentId = 30 }
        };

        public List<ContactInfo> GetAll() => contacts;

        public ContactInfo GetById(int id) => contacts.Find(x => x.ContactId == id);

        public void Add(ContactInfo contact)
        {
            contact.ContactId = contacts.Count > 0 ? contacts.Max(c => c.ContactId) + 1 : 1;
            contacts.Add(contact);
        }

        public void Update(int id, ContactInfo contact)
        {
            var existing = contacts.Find(x => x.ContactId == id);
            if (existing != null)
            {
                existing.FirstName = contact.FirstName;
                existing.LastName = contact.LastName;
                existing.EmailId = contact.EmailId;
                existing.MobileNo = contact.MobileNo;
                existing.Designation = contact.Designation;
                existing.CompanyId = contact.CompanyId;
                existing.DepartmentId = contact.DepartmentId;
            }
        }

        public void Delete(int id)
        {
            var contact = contacts.Find(x => x.ContactId == id);
            if (contact != null) contacts.Remove(contact);
        }
    }
}
