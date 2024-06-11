using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_contacts
{
    public interface IContactRepository
    {
        void AddContact(Contact contact);
        void DeleteContact(int contactId);
        void UpdateContact(Contact contact);
        List<Contact> GetAllContacts();
        List<Contact> GetActiveContacts();
        List<Contact> GetContactsByAddress(string address);
        Contact GetContactByFullName(string fullName);
        List<Contact> GetSortedContacts();
    }
}
