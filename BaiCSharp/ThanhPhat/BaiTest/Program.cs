using System;

namespace BaiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IContactRepository repository = new ContactRepository();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nMENU:");
                Console.WriteLine("1: Them moi danh ba");
                Console.WriteLine("2: Xoa danh ba");
                Console.WriteLine("3: Chinh sua danh ba");
                Console.WriteLine("4: Hien thi danh ba");
                Console.WriteLine("5: Tim kiem thong tin theo ho ten");
                Console.WriteLine("6: Sap xep danh ba theo ten");
                Console.WriteLine("0: Thoat");
                Console.Write("Chon chuc nang: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Vui long nhap 1 so hop le.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddContact(repository);
                        break;
                    case 2:
                        DeleteContact(repository);
                        break;
                    case 3:
                        UpdateContact(repository);
                        break;
                    case 4:
                        DisplayContacts(repository);
                        break;
                    case 5:
                        SearchContactByName(repository);
                        break;
                    case 6:
                        SortContacts(repository);
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Vui long chon lai.");
                        break;
                }
            }
        }

        static void AddContact(IContactRepository repository)
        {
            Contact contact = new Contact();

            Console.Write("Nhap id: ");
            contact.Id = int.Parse(Console.ReadLine());

            Console.Write("Nhap ten: ");
            contact.FirstName = Console.ReadLine();

            Console.Write("Nhap ten dem: ");
            contact.MiddleName = Console.ReadLine();

            Console.Write("Nhap ho: ");
            contact.LastName = Console.ReadLine();

            Console.Write("Nhap dia chi: ");
            contact.Address = Console.ReadLine();

            Console.Write("Nhap So Dien Thoai: ");
            contact.PhoneNumber = Console.ReadLine();

            Console.Write("Con hoat dong moi? (true/false): ");
            contact.Status = bool.Parse(Console.ReadLine());

            repository.AddContact(contact);
            Console.WriteLine("Da them danh ba thanh cong.");
        }

        static void DeleteContact(IContactRepository repository)
        {
            Console.Write("Nhap Id cua danh ba can xoa: ");
            int id = int.Parse(Console.ReadLine());
            repository.DeleteContact(id);
            Console.WriteLine("Da xoa danh ba thanh cong.");
        }

        static void UpdateContact(IContactRepository repository)
        {
            Console.Write("Nhap Id cua danh ba can chinh sua: ");
            int id = int.Parse(Console.ReadLine());
            var contact = repository.GetContact(id);

            if (contact != null)
            {
                Console.Write("Nhap ten moi: ");
                contact.FirstName = Console.ReadLine();

                Console.Write("Nhap ten dem moi: ");
                contact.MiddleName = Console.ReadLine();

                Console.Write("Nhap ho moi: ");
                contact.LastName = Console.ReadLine();

                Console.Write("Nhap dia chi mới: ");
                contact.Address = Console.ReadLine();

                Console.Write("Nhap So dien thoai moi: ");
                contact.PhoneNumber = Console.ReadLine();

                Console.Write("Con hoat dong moi? (true/false): ");
                contact.Status = bool.Parse(Console.ReadLine());

                repository.UpdateContact(contact);
                Console.WriteLine("Da chinh sua danh ba thanh cong.");
            }
            else
            {
                Console.WriteLine("Khong tim thay danh ba voi ID nay.");
            }
        }

        static void DisplayContacts(IContactRepository repository)
        {
            Console.WriteLine("1: Hien thi danh ba theo hoat dong");
            Console.WriteLine("2: Hien thi danh ba theo dia chi");
            Console.Write("Con tieu chi hien thi: ");
            int criteria = int.Parse(Console.ReadLine());

            IEnumerable<Contact> filteredContacts;

            if (criteria == 1)
            {
                filteredContacts = repository.GetActiveContacts();
            }
            else if (criteria == 2)
            {
                Console.Write("Nhap dia chi: ");
                string address = Console.ReadLine();
                filteredContacts = repository.GetContactsByAddress(address);
            }
            else
            {
                Console.WriteLine("Tieu chi khong hop le.");
                return;
            }

            foreach (var contact in filteredContacts)
            {
                DisplayContact(contact);
            }
        }

        static void SearchContactByName(IContactRepository contactRepo)
        {
            Console.Write("Nhap ten can tim: ");
            var name = Console.ReadLine();
            var contacts = contactRepo.SearchContactsByName(name);

            if (contacts.Count > 0)
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"ID: {contact.Id}, Name: {contact.FirstName} {contact.MiddleName} {contact.LastName}, Address: {contact.Address}, Phone: {contact.PhoneNumber}, Status: {contact.Status}");
                }
            }
            else
            {
                Console.WriteLine($"khong tim thay danh ba voi ten: {name}");
            }
        }

        static void SortContacts(IContactRepository repository)
        {
            var sortedContacts = repository.SortContactsByName();
            foreach (var contact in sortedContacts)
            {
                DisplayContact(contact);
            }
        }

        static void DisplayContact(Contact contact)
        {
            Console.WriteLine($"Id: {contact.Id}, Name: {contact.FirstName} {contact.MiddleName} {contact.LastName}, " +
                      $"Address: {contact.Address}, Phone: {contact.PhoneNumber}, Status: {contact.Status}");
        }
    }
}
