namespace DemoBuoiMot
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            //Caculator();
            //GetAllStudent();
            GetArray();
            Console.Read();
        }

        public static void GetArray()
        {
            int[] a = new int[5];
            a[0] = 5;
            a[1] = 10;
            a[2] = 12;
            string[] names = new string[] { "Allan", "Wilson","James","Android" };
            Console.WriteLine(names[2]);
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }

        public static void GetAllStudent()
        {
            List<Student> list = new List<Student>()
            {
                new Student(){Id=1,Name="Nguyen Van An"},
                new Student(){Id=2,Name="Tran Van Beo"},
                new Student(){Id=3,Name="Hoang Thi Cam An"},
            };
            foreach(var student in list) {
                Console.WriteLine($"Name: {student.Name}");
            }
        }

        public static void Caculator()
        {
            int a = GetInt("Nhap so a: ");
            int b = GetInt("Nhap so b: ");
            while (true)
            {
                int choice = MenuChoice();
                switch (choice)
                {
                    case 1: Console.WriteLine($"{a}+{b}={a + b}"); break;
                    case 2: Console.WriteLine($"{a}-{b}={a - b}"); break;
                    case 3: Console.WriteLine($"{a}*{b}={a * b}"); break;
                    case 4: Console.WriteLine($"{a}/{b}={a / b}"); break;
                    default: break;
                }
            }
        }

        public static int MenuChoice()
        {
            Console.WriteLine("1. Tinh tong");
            Console.WriteLine("2. Tinh hieu");
            Console.WriteLine("3. Tinh tich");
            Console.WriteLine("4. Tinh thuong");
            int choice = GetInt("Chon so: ");
            return choice;
        }

        public static int GetInt(string mes)
        {
            Console.WriteLine(mes);
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}