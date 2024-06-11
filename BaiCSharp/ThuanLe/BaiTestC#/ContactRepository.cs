using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTestC_
{
    public class ContactRepository : IContactRepository
    {
        private static ContactRepository _instance;
        private List<Contact> _contacts;

        private ContactRepository()
        {
            _contacts = new List<Contact>();
        }

        public static ContactRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ContactRepository();
                }
                return _instance;
            }
        }

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public void DeleteContact(int contactID)
        {
            var contact = _contacts.Find(c => c.ContactId == contactID);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }

        public void UpdateContact(Contact contact)
        {
            var existingContact = _contacts.Find(c => c.ContactId == contact.ContactId);
            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.MiddleName = contact.MiddleName;
                existingContact.LastName = contact.LastName;
                existingContact.Address = contact.Address;
                existingContact.PhoneNumber = contact.PhoneNumber;
                existingContact.Status = contact.Status;
            }
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public List<Contact> GetContactsByStatus(bool status)
        {
            return _contacts.Where(c => c.Status == status).ToList();
        }

        public List<Contact> GetContactsByAddress(string address)
        {
            return _contacts.Where(c => c.Address == address).ToList();
        }

        public List<Contact> SearchContactsByName(string name)
        {
            return _contacts.Where(c => c.FullName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void SortContactsByName()
        {
            _contacts = _contacts.OrderBy(c => c.FirstName).ThenBy(c => c.MiddleName).ThenBy(c => c.LastName).ToList();
        }
    }
}
