namespace BaiTestC_
{
     public class Program
    {
        static void Main(string[] args)
        {
            var contactRepo = ContactRepository.Instance;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Them danh ba moi");
                Console.WriteLine("2. Xoa danh ba");
                Console.WriteLine("3. Chinh sua danh ba");
                Console.WriteLine("4. Hien thi danh ba");
                Console.WriteLine("5. Tim kiem thong tin ho ten");
                Console.WriteLine("6. Sap xep danh ba theo Ten");
                Console.WriteLine("7. Thoat");
                Console.Write("Chon mot tuy chon: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewContact(contactRepo);
                        break;
                    case "2":
                        DeleteContact(contactRepo);
                        break;
                    case "3":
                        UpdateContact(contactRepo);
                        break;
                    case "4":
                        DisplayContacts(contactRepo);
                        break;
                    case "5":
                        SearchContactByName(contactRepo);
                        break;
                    case "6":
                        contactRepo.SortContactsByName();
                        Console.WriteLine("Danh ba da duoc sap xep theo ten.");
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddNewContact(IContactRepository contactRepo)
        {
            var contact = new Contact();
            Console.Write("Nhap Id: ");
            contact.ContactId = int.Parse(Console.ReadLine());
            Console.Write("Nhap First Name: ");
            contact.FirstName = Console.ReadLine();
            Console.Write("Nhap Middle Name: ");
            contact.MiddleName = Console.ReadLine();
            Console.Write("Nhap Last Name: ");
            contact.LastName = Console.ReadLine();
            Console.Write("Nhap Address: ");
            contact.Address = Console.ReadLine();
            Console.Write("Nhap Phone Number: ");
            contact.PhoneNumber = Console.ReadLine();
            Console.Write("Nhap Status (true/false): ");
            contact.Status = bool.Parse(Console.ReadLine());

            contactRepo.AddContact(contact);
        }

        static void DeleteContact(IContactRepository contactRepo)
        {
            Console.Write("Nhap Id danh ba can xoa ");
            int id = int.Parse(Console.ReadLine());
            contactRepo.DeleteContact(id);
        }

        static void UpdateContact(IContactRepository contactRepo)
        {
            var contact = new Contact();
            Console.Write("Nhap id danh ba can chinh sua ");
            contact.ContactId = int.Parse(Console.ReadLine());
            Console.Write("Nhap First Name moi: ");
            contact.FirstName = Console.ReadLine();
            Console.Write("Nhap Middle Name moi: ");
            contact.MiddleName = Console.ReadLine();
            Console.Write("Nhap Last Name moi: ");
            contact.LastName = Console.ReadLine();
            Console.Write("Nhap Address moi: ");
            contact.Address = Console.ReadLine();
            Console.Write("Nhap Phone Number moi: ");
            contact.PhoneNumber = Console.ReadLine();
            Console.Write("Nhap Status moi (true/false): ");
            contact.Status = bool.Parse(Console.ReadLine());

            contactRepo.UpdateContact(contact);
        }

        static void DisplayContacts(IContactRepository contactRepo)
        {
            Console.WriteLine("1. Theo trang thai hoat dong");
            Console.WriteLine("2. Theo dia chi");
            var option = Console.ReadLine();

            if (option == "1")
            {
                var contacts = contactRepo.GetContactsByStatus(true);
                if (contacts.Count > 0)
                {
                    foreach (var contact in contacts)
                    {
                        Console.WriteLine($"ID: {contact.ContactId}, Name: {contact.FirstName} {contact.MiddleName} {contact.LastName}, Address: {contact.Address}, Phone: {contact.PhoneNumber}, Status: {contact.Status}");
                    }
                }
                else
                {
                    Console.WriteLine("khong co danh ba nao dang hoat dong.");
                }
            }
            else if (option == "2")
            {
                Console.Write("Nhap dia chi: ");
                var address = Console.ReadLine();
                var contacts = contactRepo.GetContactsByAddress(address);
                if (contacts.Count > 0)
                {
                    foreach (var contact in contacts)
                    {
                        Console.WriteLine($"ID: {contact.ContactId}, Name: {contact.FirstName} {contact.MiddleName} {contact.LastName}, Address: {contact.Address}, Phone: {contact.PhoneNumber}, Status: {contact.Status}");
                    }
                }
                else
                {
                    Console.WriteLine($"khong tim thay danh ba voi dia chi: {address}");
                }
            }
            else
            {
                Console.WriteLine("Lua chon khong hop le.");
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
                    Console.WriteLine($"ID: {contact.ContactId}, Name: {contact.FirstName} {contact.MiddleName} {contact.LastName}, Address: {contact.Address}, Phone: {contact.PhoneNumber}, Status: {contact.Status}");
                }
            }
            else
            {
                Console.WriteLine($"khong tim thay danh ba voi ten: {name}");
            }
        }
    }
}
