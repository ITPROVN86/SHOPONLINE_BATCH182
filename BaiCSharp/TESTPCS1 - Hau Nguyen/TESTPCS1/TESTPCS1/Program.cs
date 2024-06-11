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
        var isTimThay = false;
        var results = contacts.Where(c => c.FullName.Equals(fullName, StringComparison.OrdinalIgnoreCase));
        foreach (var contact in results)
        {
            Console.WriteLine(contact);
            isTimThay = true;
        }

        if (isTimThay == false)
        {
            Console.WriteLine("Khong tim thay " + fullName);
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
            Console.WriteLine("-----Menu-----");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Delete Contact");
            Console.WriteLine("3. Edit Contact");
            Console.WriteLine("4. Show Contact");
            Console.WriteLine("5. Search");
            Console.WriteLine("6. Sort Contact");
            Console.WriteLine("0. Exit");
            Console.Write("Chon mot tuy chon: ");
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
                    Console.WriteLine("Contact da duoc sap xep.");
                    contactManager.DisplayContacts(status: true);
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
        Console.WriteLine("Da them Contact moi.");
        Console.WriteLine("--------------------");
    }

    static void DeleteContact(ContactManager contactManager)
    {
        Console.Write("Nhap Id Contact muon xoa: ");
        int id = int.Parse(Console.ReadLine());
        contactManager.DeleteContact(id);
        Console.WriteLine("Da xoa Contact.");
        Console.WriteLine("---------------");
    }

    static void EditContact(ContactManager contactManager)
    {
        Console.Write("Nhap Id Contact muon chinh sua: ");
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
        Console.WriteLine("Da chinh sua Contact.");
        Console.WriteLine("---------------------");
    }

    static void DisplayContacts(ContactManager contactManager)
    {
        Console.WriteLine("Hien thi Contact theo cac tieu chi:");
        Console.WriteLine("1. Theo con hoat dong khong (Status = true)");
        Console.WriteLine("2. Theo Address");
        Console.Write("Chon mot tuy chon: ");
        var choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                contactManager.DisplayContacts(status: true);
                break;
            case 2:
                Console.Write("Nhap dia chi: ");
                string address = Console.ReadLine();
                contactManager.DisplayContacts(address: address);
                break;
            default:
                Console.WriteLine("Tuy chon khong hop le.");
                break;
        }
    }

    static void SearchContact(ContactManager contactManager)
    {
        Console.Write("Nhap ho ten day du de tim kiem: ");
        string fullName = Console.ReadLine();
        contactManager.SearchContact(fullName);
    }
}
