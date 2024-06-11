using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiTest
{
    public class ContactRepository : IContactRepository
    {
        private List<Contact> contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void DeleteContact(int id)
        {
            var contact = GetContact(id);
            if (contact != null)
            {
                contacts.Remove(contact);
            }
        }

        public void UpdateContact(Contact contact)
        {
            var existingContact = GetContact(contact.Id);
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

        public Contact GetContact(int id)
        {
            return contacts.FirstOrDefault(c => c.Id == id);
        }

        public List<Contact> GetAllContacts()
        {
            return contacts;
        }

        public List<Contact> GetActiveContacts()
        {
            return contacts.Where(c => c.Status).ToList();
        }

        public List<Contact> GetContactsByAddress(string address)
        {
            return contacts.Where(c => c.Address.Equals(address, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Contact> SearchContactsByName(string name)
        {
            return contacts.Where(c =>
                $"{c.FirstName} {c.MiddleName} {c.LastName}".Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Contact> SortContactsByName()
        {
            return contacts.OrderBy(c => c.FirstName).ThenBy(c => c.MiddleName).ThenBy(c => c.LastName).ToList();
        }
    }
}
