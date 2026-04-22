using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{

    public interface IContactService
    {
        void AddContact(Contact contact);

        void UpdateContact(Contact contact);

        void DeleteContact(int id);

        List<Contact> GetAllContacts();
    }
}
