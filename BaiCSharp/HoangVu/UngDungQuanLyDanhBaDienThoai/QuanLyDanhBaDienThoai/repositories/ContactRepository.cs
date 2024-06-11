using QuanLyDanhBaDienThoai.models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBaDienThoai.repositories
{
    public class ContactRepository : IContactRepository
    {
        private static ContactRepository _instance;
        private static int _currentId = 1;
        private List<Contact> _contacts = new List<Contact>();
        public ContactRepository() { }

        public void AddContact(Contact contact)
        {
            contact.ID = _currentId++;
            _contacts.Add(contact);
        }

        public void DeleteContact(int ID)
        {
            var contact = GetContact(ID);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }



        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public Contact GetContact(int ID)
        {
            return _contacts.FirstOrDefault(s => s.ID == ID);
        }

        public void UpdateContact(Contact contact)
        {
            var existringContact = GetContact(contact.ID);
            if (existringContact != null)
            {
                existringContact.FirstName = contact.FirstName;
                existringContact.MiddleName = contact.MiddleName;
                existringContact.LastName = contact.LastName;
                existringContact.Address = contact.Address;
                existringContact.FoneNumber = contact.FoneNumber;
                existringContact.Status = contact.Status;
            }
        }

        public void AddSampleContacts()
        {
            List<Contact> sampleContacts = new List<Contact>
            {
                new Contact { FirstName = "Nguyen ", MiddleName = "van", LastName = "a", Address = "DN", FoneNumber = 123456, Status = "Doc than" },
                new Contact { FirstName = "Nguyen ", MiddleName = "van", LastName = "a", Address = "DN", FoneNumber = 123456, Status = "Doc than" },
                new Contact { FirstName = "Nguyen ", MiddleName = "van", LastName = "a", Address = "DN", FoneNumber = 123456, Status = "Doc than" },
                new Contact { FirstName = "Nguyen ", MiddleName = "van", LastName = "a", Address = "DN", FoneNumber = 123456, Status = "Doc than" },
                new Contact { FirstName = "Nguyen ", MiddleName = "van", LastName = "a", Address = "DN", FoneNumber = 123456, Status = "Doc than" },
                new Contact { FirstName = "Nguyen ", MiddleName = "van", LastName = "a", Address = "DN", FoneNumber = 123456, Status = "Doc than" },
                new Contact { FirstName = "Nguyen ", MiddleName = "van", LastName = "a", Address = "DN", FoneNumber = 123456, Status = "Doc than" },
                new Contact { FirstName = "Nguyen ", MiddleName = "van", LastName = "a", Address = "DN", FoneNumber = 123456, Status = "Doc than" },
                new Contact { FirstName = "Nguyen ", MiddleName = "van", LastName = "a", Address = "DN", FoneNumber = 123456, Status = "Doc than" },
                new Contact { FirstName = "Nguyen ", MiddleName = "van", LastName = "a", Address = "DN", FoneNumber = 123456, Status = "Doc than" },
            };

            foreach (var contact in sampleContacts)
            {
                AddContact(contact);
            }

        }
    }
}
        
    


