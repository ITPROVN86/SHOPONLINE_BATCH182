using QuanLyDanhBaDienThoai.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhBaDienThoai.repositories
{
    public interface IContactRepository
    {
        void AddContact(Contact contact);
        Contact GetContact(int ID);
        void UpdateContact(Contact contact);
        void DeleteContact(int ID);
        List<Contact> GetAllContacts();
        void AddSampleContacts();
    }
}
