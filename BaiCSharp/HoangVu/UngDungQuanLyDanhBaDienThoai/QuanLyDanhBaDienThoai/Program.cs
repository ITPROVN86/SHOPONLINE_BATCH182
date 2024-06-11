using QuanLyDanhBaDienThoai.models;
using QuanLyDanhBaDienThoai.repositories;
using System;
using System.ComponentModel;
using System.IO;

namespace QuanLyDanhBaDienThoai
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
           

           
            IContactRepository contactRepository = new ContactRepository();
            contactRepository.AddSampleContacts();
          
            while (true)
            {
                
                ShowMainMenu();

             
                int choice;
                Console.Write("Lựa chọn của bạn: ");
                while (!int.TryParse(Console.ReadLine(), out choice) || !IsValidChoice(choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập số tương ứng trên menu.");
                }

             
                switch (choice)
                {
                    case 1:
                       
                        ShowAllContact(contactRepository);
                        break;
                    case 2:
                         
                        AddContact(contactRepository);
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.");
                        break;
                }
            }
        }

        
        static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Để thao tác mời nhập số tương ứng từ bàn phím ");
           
            Console.WriteLine("Phím 1 : xem danh sach danh ba co san");
            Console.WriteLine("Phím 2 : them vao danh ba");
            Console.WriteLine("Phím 3 : tim va cap nhat thong tin danh ba");
            Console.WriteLine("Phím 4 : tim va xoa thong tin nguoi lien lac ");
            Console.WriteLine("Phím 0 : Thoát");
            Console.Write("Lựa chọn của bạn: ");
        }

        
        static bool IsValidChoice(int choice)
        {
            return choice == 0 || choice == 1 || choice == 2 || choice == 3 || choice == 4 || choice == 5; 
        }

        static void ShowAllContact(IContactRepository contactRepository) 
        {
            Console.Clear();
            var contacts = contactRepository.GetAllContacts();
            Console.WriteLine("Danh sách danh ba:");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"FirstName: {contact.FirstName},  MiddleName : {contact.MiddleName}, LastName: {contact.LastName}, Address: {contact.Address},FoneNumber:{contact.FoneNumber},Status :{contact.Status}");
            }
            Console.WriteLine("-----------------------------------------------");

           
            ReturnToMainMenuPrompt();
        }

        
        static void ReturnToMainMenuPrompt()
        {
            Console.WriteLine("Bạn có muốn quay lại màn hình chính không? Y để quay lại (Y/N): ");
            string choice = Console.ReadLine();
            if (!choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                Environment.Exit(0);
            }
        }

       
        static void AddContact(IContactRepository contactRepository)
        {
            Console.Clear();
            Console.WriteLine("Thêm nguoi lien lac mới:");
            Console.WriteLine("------------------");

           

            Console.Write("FirstName: ");
            string name = Console.ReadLine();
           
        }
  
           
    }
}

