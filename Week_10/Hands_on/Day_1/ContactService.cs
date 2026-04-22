using ConsoleApp2;

public class ContactService : IContactService
{
    private readonly List<Contact> _contacts = new();

    public void AddContact(Contact contact)
    {
        Validate(contact);
        _contacts.Add(contact);
    }

    public void UpdateContact(Contact contact)
    {
        Validate(contact);

        var existing = _contacts.FirstOrDefault(c => c.Id == contact.Id);

        if (existing == null)
            throw new Exception("Contact not found");

        existing.Name = contact.Name;
        existing.Email = contact.Email;
        existing.Phone = contact.Phone;
    }

    public void DeleteContact(int id)
    {
        var contact = _contacts.FirstOrDefault(c => c.Id == id);

        if (contact != null)
            _contacts.Remove(contact);
    }

    public List<Contact> GetAllContacts()
    {
        return _contacts;
    }

   
    private static void Validate(Contact contact)
    {
        if (contact == null)
            throw new ArgumentNullException(nameof(contact));

        if (string.IsNullOrWhiteSpace(contact.Name))
            throw new ArgumentException("Name is required");

        if (string.IsNullOrWhiteSpace(contact.Email))
            throw new ArgumentException("Email is required");
    }
}