using WebApplication3.Models;
namespace WebApplication3.Services
{
    public class ContactService : IContactService
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>();

        public void AddContact(ContactInfo contact)
        {
            contacts.Add(contact);
        }
        public List<ContactInfo> GetAllContacts()
        {
            return contacts;
        }
        public ContactInfo GetContactById(int id)
        {
            return contacts.FirstOrDefault(c => c.ContactId == id);
        }
    }
}
