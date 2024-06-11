using System;
using System.Collections.Generic;
using System.Linq;

public class Contact
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public bool Status { get; set; }

    public string FullName => $"{FirstName} {MiddleName} {LastName}";

    public override string ToString()
    {
        return $"{Id}, {FullName}, {Address}, {PhoneNumber}, {(Status ? "Active" : "Inactive")}";
    }
}

public class ContactManager
{
    private List<Contact> contacts = new List<Contact>();

    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
    }

    public void DeleteContact(int contactId)
    {
        contacts.RemoveAll(contact => contact.Id == contactId);
    }

    public void EditContact(int contactId, Action<Contact> editAction)
    {
        var contact = contacts.FirstOrDefault(c => c.Id == contactId);
        if (contact != null)
        {
            editAction(contact);
        }
    }

    public void DisplayContacts(bool? status = null, string address = null)
    {
        var filteredContacts = contacts.AsEnumerable();
        if (status.HasValue)
        {
            filteredContacts = filteredContacts.Where(c => c.Status == status.Value);
        }
        if (!string.IsNullOrEmpty(address))
        {
            filteredContacts = filteredContacts.Where(c => c.Address.Equals(address, StringComparison.OrdinalIgnoreCase));
        }
        foreach (var contact in filteredContacts)
        {
            Console.WriteLine(contact);
        }
    }

    public void SearchContact(string fullName)
    {
        var results = contacts.Where(c => c.FullName.Equals(fullName, StringComparison.OrdinalIgnoreCase));
        foreach (var contact in results)
        {
            Console.WriteLine(contact);
        }
    }

    public void SortContactsByName()
    {
        contacts = contacts.OrderBy(c => c.FirstName)
                           .ThenBy(c => c.MiddleName)
                           .ThenBy(c => c.LastName)
                           .ToList();
    }
}

public class Program
{
    public static void Main()
    {
        ContactManager contactManager = new ContactManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Thêm danh bạ");
            Console.WriteLine("2. Xoá danh bạ");
            Console.WriteLine("3. Chỉnh sửa danh bạ");
            Console.WriteLine("4. Hiển thị danh bạ");
            Console.WriteLine("5. Tìm kiếm thông tin theo họ tên");
            Console.WriteLine("6. Sắp xếp danh bạ theo Tên");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn một tùy chọn: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddContact(contactManager);
                    break;
                case 2:
                    DeleteContact(contactManager);
                    break;
                case 3:
                    EditContact(contactManager);
                    break;
                case 4:
                    DisplayContacts(contactManager);
                    break;
                case 5:
                    SearchContact(contactManager);
                    break;
                case 6:
                    contactManager.SortContactsByName();
                    Console.WriteLine("Danh bạ đã được sắp xếp.");
                    break;
                case 0:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng thử lại.");
                    break;
            }
        }
    }

static void AddContact(ContactManager contactManager)
    {
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("FirstName: ");
        string firstName = Console.ReadLine();
        Console.Write("MiddleName: ");
        string middleName = Console.ReadLine();
        Console.Write("LastName: ");
        string lastName = Console.ReadLine();
        Console.Write("Address: ");
        string address = Console.ReadLine();
        Console.Write("PhoneNumber: ");
        string phoneNumber = Console.ReadLine();
        Console.Write("Status (true for active, false for inactive): ");
        bool status = bool.Parse(Console.ReadLine());

        Contact newContact = new Contact
        {
            Id = id,
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName,
            Address = address,
            PhoneNumber = phoneNumber,
            Status = status
        };

        contactManager.AddContact(newContact);
        Console.WriteLine("Đã thêm danh bạ mới.");
    }

    static void DeleteContact(ContactManager contactManager)
    {
        Console.Write("Nhập Id danh bạ muốn xoá: ");
        int id = int.Parse(Console.ReadLine());
        contactManager.DeleteContact(id);
        Console.WriteLine("Đã xoá danh bạ.");
    }

    static void EditContact(ContactManager contactManager)
    {
        Console.Write("Nhập Id danh bạ muốn chỉnh sửa: ");
        int id = int.Parse(Console.ReadLine());
        contactManager.EditContact(id, contact =>
        {
            Console.Write("FirstName: ");
            contact.FirstName = Console.ReadLine();
            Console.Write("MiddleName: ");
            contact.MiddleName = Console.ReadLine();
            Console.Write("LastName: ");
            contact.LastName = Console.ReadLine();
            Console.Write("Address: ");
            contact.Address = Console.ReadLine();
            Console.Write("PhoneNumber: ");
            contact.PhoneNumber = Console.ReadLine();
            Console.Write("Status (true for active, false for inactive): ");
            contact.Status = bool.Parse(Console.ReadLine());
        });
        Console.WriteLine("Đã chỉnh sửa danh bạ.");
    }

    static void DisplayContacts(ContactManager contactManager)
    {
        Console.WriteLine("Hiển thị danh bạ theo các tiêu chí:");
        Console.WriteLine("1. Theo còn hoạt động không (Status = true)");
        Console.WriteLine("2. Theo Address");
        Console.Write("Chọn một tùy chọn: ");
        eint choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                contactManager.DisplayContacts(status: true);
                break;
            case 2:
                Console.Write("Nhập địa chỉ: ");
                string address = Console.ReadLine();
                contactManager.DisplayContacts(address: address);
                break;
            default:
                Console.WriteLine("Tùy chọn không hợp lệ.");
                break;
        }
    }

    static void SearchContact(ContactManager contactManager)
    {
        Console.Write("Nhập họ tên đầy đủ để tìm kiếm: ");
        string fullName = Console.ReadLine();
        contactManager.SearchContact(fullName);
    }
}