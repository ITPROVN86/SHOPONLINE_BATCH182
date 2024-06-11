using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_contacts
{
    public class Program
    {
        static void Main(string[] args)
        {
            IContactRepository contactRepo = ContactRepository.Instance;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("==================================\nChon mot thao tac:");
                Console.WriteLine("1. Them danh ba moi");
                Console.WriteLine("2. Xoa danh ba");
                Console.WriteLine("3. Chinh sua danh ba");
                Console.WriteLine("4. Hien thi danh ba");
                Console.WriteLine("5. Tim kiem thong tin theo ho ten");
                Console.WriteLine("6. Sap xep danh ba theo Ten");
                Console.WriteLine("7. Thoat");
                Console.Write("Lua chon cua ban: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddContact(contactRepo);
                        break;
                    case 2:
                        DeleteContact(contactRepo);
                        break;
                    case 3:
                        UpdateContact(contactRepo);
                        break;
                    case 4:
                        DisplayContacts(contactRepo);
                        break;
                    case 5:
                        SearchContactByName(contactRepo);
                        break;
                    case 6:
                        SortContacts(contactRepo);
                        break;
                    case 7:
                        exit = true;
                        Console.WriteLine("Thoat chuong trinh.");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                        break;
                }
            }
        }

        static void AddContact(IContactRepository contactRepo)
        {
            Contact newContact = new Contact();
            Console.Write("Nhap ID: ");
            newContact.Id = int.Parse(Console.ReadLine());
            Console.Write("Nhap ho: ");
            newContact.LastName = Console.ReadLine();
            Console.Write("Nhap ten dem: ");
            newContact.MiddleName = Console.ReadLine();
            Console.Write("Nhap ten: ");
            newContact.FirstName = Console.ReadLine();
            Console.Write("Nhap dia chi: ");
            newContact.Address = Console.ReadLine();
            Console.Write("Nhap so dien thoai: ");
            newContact.PhoneNumber = Console.ReadLine();
            Console.Write("Nhap trang thai (true/false): ");
            newContact.Status = bool.Parse(Console.ReadLine());
            contactRepo.AddContact(newContact);
            Console.WriteLine("Them danh ba thanh cong.");
        }

        static void DeleteContact(IContactRepository contactRepo)
        {
            Console.Write("Nhap ID danh ba de xoa: ");
            int id = int.Parse(Console.ReadLine());
            contactRepo.DeleteContact(id);
            Console.WriteLine("Xoa danh ba thanh cong.");
        }

        static void UpdateContact(IContactRepository contactRepo)
        {
            Console.Write("Nhap ID danh ba de cap nhat: ");
            int id = int.Parse(Console.ReadLine());
            Contact contact = contactRepo.GetAllContacts().Find(c => c.Id == id);
            if (contact != null)
            {
                Console.Write($"Nhap ho moi ({contact.LastName}): ");
                string lastName = Console.ReadLine();
                if (!string.IsNullOrEmpty(lastName))
                {
                    contact.LastName = lastName;
                }

                Console.Write($"Nhap ten dem moi ({contact.MiddleName}): ");
                string middleName = Console.ReadLine();
                if (!string.IsNullOrEmpty(middleName))
                {
                    contact.MiddleName = middleName;
                }

                Console.Write($"Nhap ten moi ({contact.FirstName}): ");
                string firstName = Console.ReadLine();
                if (!string.IsNullOrEmpty(firstName))
                {
                    contact.FirstName = firstName;
                }

                Console.Write($"Nhap dia chi moi ({contact.Address}): ");
                string address = Console.ReadLine();
                if (!string.IsNullOrEmpty(address))
                {
                    contact.Address = address;
                }

                Console.Write($"Nhap so dien thoai moi ({contact.PhoneNumber}): ");
                string phoneNumber = Console.ReadLine();
                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    contact.PhoneNumber = phoneNumber;
                }

                Console.Write($"Nhap trang thai moi ({contact.Status}): ");
                string statusInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(statusInput) && bool.TryParse(statusInput, out bool status))
                {
                    contact.Status = status;
                }

                contactRepo.UpdateContact(contact);
                Console.WriteLine("Cap nhat danh ba thanh cong.");
            }
            else
            {
                Console.WriteLine("Khong tim thay danh ba.");
            }
        }

        static void DisplayContacts(IContactRepository contactRepo)
        {
            Console.WriteLine("Chon tieu chi hien thi:");
            Console.WriteLine("1. Theo con hoat dong khong? Status = true");
            Console.WriteLine("2. Theo dia chi: Quang Nam");
            Console.Write("Lua chon cua ban: ");
            int choice = int.Parse(Console.ReadLine());

            List<Contact> contacts = new List<Contact>();
            switch (choice)
            {
                case 1:
                    contacts = contactRepo.GetActiveContacts();
                    break;
                case 2:
                    contacts = contactRepo.GetContactsByAddress("Quang Nam");
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le.");
                    return;
            }

            if (contacts.Count > 0)
            {
                foreach (var c in contacts)
                {
                    Console.WriteLine($"ID: {c.Id}, Ten: {c.LastName} {c.MiddleName} {c.FirstName}, Dia chi: {c.Address}, SDT: {c.PhoneNumber}, Trang thai: {c.Status}");
                }
            }
            else
            {
                Console.WriteLine("Khong co danh ba nao.");
            }
        }

        static void SearchContactByName(IContactRepository contactRepo)
        {
            Console.Write("Nhap ho va ten: ");
            string fullName = Console.ReadLine();
            Contact contact = contactRepo.GetContactByFullName(fullName);
            if (contact != null)
            {
                Console.WriteLine($"ID: {contact.Id}, Ten: {contact.LastName} {contact.MiddleName} {contact.FirstName}, Dia chi: {contact.Address}, SDT: {contact.PhoneNumber}, Trang thai: {contact.Status}");
            }
            else
            {
                Console.WriteLine("Khong tim thay danh ba.");
            }
        }

        static void SortContacts(IContactRepository contactRepo)
        {
            List<Contact> contacts = contactRepo.GetSortedContacts();
            foreach (var c in contacts)
            {
                Console.WriteLine($"ID: {c.Id}, Ten: {c.LastName} {c.MiddleName} {c.FirstName}, Dia chi: {c.Address}, SDT: {c.PhoneNumber}, Trang thai: {c.Status}");
            }
        }
    }
}
