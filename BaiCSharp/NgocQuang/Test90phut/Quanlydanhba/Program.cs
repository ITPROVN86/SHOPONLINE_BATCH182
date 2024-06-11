namespace Quanlydanhba
{
    public class Program
    {
        static List<Contact> contacts = new List<Contact>();
        static int currentId = 1;

        static void Main(string[] args)
        {
            Program p = new Program();
            bool running = false;

            while (!running)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Them Danh Ba");
                Console.WriteLine("2. Xoa Danh Sach");
                Console.WriteLine("3. Chinh Sua Danh Ba");
                Console.WriteLine("4. Hien thi danh ba theo status");
                Console.WriteLine("5. Hien thi danh ba theo address");
                Console.WriteLine("6. Hien thi tat ca danh ba ");
                Console.WriteLine("7. Tim kiem thong tin theo ho ten");
                Console.WriteLine("8. Sap xep danh ba theo ten");
                Console.WriteLine("9. Thoat");
                Console.Write("Hay chon : ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Vui Long nhap 1 so hop le.");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        p.AddContact();
                        break;
                    case 2:
                        p.DeleteContact();
                        break;
                    case 3:
                        p.EditContact();
                        break;
                    case 4:
                        p.DisplayContactsByStatus();
                        break;
                    case 5:
                        p.DisplayContactsByAddress();
                        break;
                    case 6:
                        p.DisplayAllContacts();
                        break;
                    case 7:
                        p.SearchContactsByName();
                        break;
                    case 8:
                        p.SortContactsByName();
                        break;
                    case 9:
                        running = true;
                        break;
                    default:
                        Console.WriteLine("Vui long chon lai.");
                        break;
                }
            }
        }

         void AddContact()
        {
            
            
            while (true)
            {
                Contact ct = new Contact();
                Console.Write("First Name: ");
                string firstName = Console.ReadLine().Trim();
                Console.Write("Middle Name: ");
                string middleName = Console.ReadLine().Trim();
                Console.Write("Last Name: ");
                string lastName = Console.ReadLine().Trim();
                Console.Write("Address: ");
                string address = Console.ReadLine();
                Console.Write("Phone Number: ");
                string phoneNumber = Console.ReadLine();
                Console.Write("Status (true/false): ");
                bool status = bool.Parse(Console.ReadLine());
                contacts.Add(new Contact
                {
                    Id = currentId++,
                    FirstName = firstName,
                    MiddleName = middleName,
                    LastName = lastName,
                    Address = address,
                    PhoneNumber = phoneNumber,
                    Status = status
                });
                Console.WriteLine("Them thanh cong.");
                Console.WriteLine("Ban co muon them 1 lien he moi khong: (A/S):");
                string choice = Console.ReadLine().ToUpper().Trim();
                if (choice == "S")
                {
                    break;
                }
                else if (choice != "A")
                {
                    Console.WriteLine("Vui long chon A hoac S:");
                    string kric = Console.ReadLine().ToUpper().Trim();
                    if (kric == "S")
                    {
                        break;
                    }else if (kric != "A")
                    {
                        Console.WriteLine("Ban da nhap sai 2 lan vui long chon muc khac");
                        break;
                    }
                }
            }

        }

         void DeleteContact()
        {
            Console.Write("Nhap Id cua danh ba can xoa: ");
            int id = int.Parse(Console.ReadLine());
            var contact = contacts.FirstOrDefault(c => c.Id == id);

            if (contact != null)
            {
                contacts.Remove(contact);
                Console.WriteLine("Da xoa thanh cong.");
            }
            else
            {
                Console.WriteLine("Danh ba khong ton tai.");
            }
        }

         void EditContact()
        {
            Console.Write("Nhap Id danh ba can chinh sua: ");
            int id = int.Parse(Console.ReadLine());
            var contact = contacts.FirstOrDefault(c => c.Id == id);

            if (contact != null)
            {
                Console.Write("First Name: ");
                contact.FirstName = Console.ReadLine();
                Console.Write("Middle Name: ");
                contact.MiddleName = Console.ReadLine();
                Console.Write("Last Name: ");
                contact.LastName = Console.ReadLine();
                Console.Write("Address: ");
                contact.Address = Console.ReadLine();
                Console.Write("Phone Number: ");
                contact.PhoneNumber = Console.ReadLine();
                Console.Write("Status (true/false): ");
                contact.Status = bool.Parse(Console.ReadLine());

                Console.WriteLine("Danh ba cap nhat thanh cong.");
            }
            else
            {
                Console.WriteLine("Danh ba khong ton tai.");
            }
        }

         void DisplayContactsByStatus()
        {
            Console.Write("Nhap status (true/false): ");
            bool status = bool.Parse(Console.ReadLine());
            var Diachi = contacts.Where(c => c.Status == status);

            foreach (var contact in Diachi)
            {
                Console.WriteLine(contact);
            }
        }

         void DisplayContactsByAddress()
        {
            Console.Write("Nhap dia chi: ");
            string address = Console.ReadLine();
            var Diachi = contacts.Where(c => c.Address.Contains(address, StringComparison.OrdinalIgnoreCase));

            foreach (var contact in Diachi)
            {
                Console.WriteLine(contact);
            }
        }

         void DisplayAllContacts()
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }

        void SearchContactsByName()
        {
            Console.Write("Nhap ho ten de tim kiem: ");
            string name = Console.ReadLine().Trim(); // Loại bỏ khoảng trắng thừa ở đầu và cuối

            // Kiểm tra xem người dùng có nhập đầy đủ họ tên không
            if (string.IsNullOrWhiteSpace(name) || name.Split(' ').Length < 2)
            {
                Console.WriteLine("Ban phai nhap day du ho ten (bao gom ho va ten).");
                return; // Trở về menu
            }

            var fullName = contacts.Where(c =>
                $"{c.FirstName} {c.MiddleName} {c.LastName}".Trim().Equals(name, StringComparison.OrdinalIgnoreCase));

            if (fullName.Any())
            {
                foreach (var contact in fullName)
                {
                    Console.WriteLine(contact);
                }
            }
            else
            {
                Console.WriteLine("Khong tim thay danh ba nao voi ten nay.");
            }
        }



        void SortContactsByName()
        {
            var sortedContacts = contacts.OrderBy(c => c.FirstName).ThenBy(c => c.MiddleName).ThenBy(c => c.LastName);

            foreach (var contact in sortedContacts)
            {
                Console.WriteLine(contact);
            }
        }
    }
}