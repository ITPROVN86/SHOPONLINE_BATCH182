using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_contacts
{
    public class ContactRepository : IContactRepository
    {
        private static ContactRepository instance;
        private List<Contact> contacts = new List<Contact>();

        private ContactRepository() { }

        public static ContactRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ContactRepository();
                }
                return instance;
            }
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void DeleteContact(int contactId)
        {
            var contact = contacts.Find(c => c.Id == contactId);
            if (contact != null)
            {
                contacts.Remove(contact);
            }
        }

        public void UpdateContact(Contact contact)
        {
            var existingContact = contacts.Find(c => c.Id == contact.Id);
            if (existingContact != null)
            {
                existingContact.FirstName = !string.IsNullOrEmpty(contact.FirstName) ? contact.FirstName : existingContact.FirstName;
                existingContact.MiddleName = !string.IsNullOrEmpty(contact.MiddleName) ? contact.MiddleName : existingContact.MiddleName;
                existingContact.LastName = !string.IsNullOrEmpty(contact.LastName) ? contact.LastName : existingContact.LastName;
                existingContact.Address = !string.IsNullOrEmpty(contact.Address) ? contact.Address : existingContact.Address;
                existingContact.PhoneNumber = !string.IsNullOrEmpty(contact.PhoneNumber) ? contact.PhoneNumber : existingContact.PhoneNumber;
                existingContact.Status = contact.Status;
            }
        }

        public List<Contact> GetAllContacts()
        {
            return new List<Contact>(contacts);
        }

        public List<Contact> GetActiveContacts()
        {
            return contacts.Where(c => c.Status).ToList();
        }

        public List<Contact> GetContactsByAddress(string address)
        {
            return contacts.Where(c => c.Address.Equals(address, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Contact GetContactByFullName(string fullName)
        {
            var names = fullName.Split(' ');
            if (names.Length < 3) return null;

            var lastName = names[0];
            var middleName = string.Join(" ", names.Skip(1).Take(names.Length - 2));
            var firstName = names[names.Length - 1];

            return contacts.Find(c =>
                c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                c.MiddleName.Equals(middleName, StringComparison.OrdinalIgnoreCase) &&
                c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }

        public List<Contact> GetSortedContacts()
        {
            return contacts.OrderBy(c => c.FirstName).ThenBy(c => c.MiddleName).ThenBy(c => c.LastName).ToList();
        }
    }
}
