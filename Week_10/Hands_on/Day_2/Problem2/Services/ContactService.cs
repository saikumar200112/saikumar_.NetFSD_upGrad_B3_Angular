using WebApplication12.Models;

namespace WebApplication12.Services
{
    public class ContactService: IContactService
    {
        private readonly List<Contact> _contacts = new();
        private readonly ILogger<ContactService> _logger;

        public ContactService(ILogger<ContactService> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Contact> GetAll() => _contacts;

        public Contact? GetById(int id)
        {
            _logger.LogInformation("Searching for contact ID: {Id}", id);
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Contact contact)
        {
            if (_contacts.Any(c => c.Id == contact.Id))
            {
                _logger.LogWarning("Conflict: Contact with ID {Id} already exists.", contact.Id);
                throw new InvalidOperationException("Duplicate ID");
            }
            _contacts.Add(contact);
        }

        public bool Update(int id, Contact contact)
        {
            var index = _contacts.FindIndex(c => c.Id == id);
            if (index == -1) return false;
            _contacts[index] = contact with { Id = id };
            return true;
        }

        public bool Delete(int id) => _contacts.RemoveAll(c => c.Id == id) > 0;
    }
}
