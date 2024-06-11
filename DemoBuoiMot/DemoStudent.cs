using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBuoiMot
{
    public class UniversityStudent
    {
        protected int id;
        protected string name;
        public int age;
        public UniversityStudent()
        {

        }
        public UniversityStudent(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public override string ToString()
        {
            return $"Id: {id}, Name: {name}";
        }
    }

    class Employee: UniversityStudent
    {
        public Employee(int id, string name): base(id, name)
        {
            
        }
    }
    public class DemoStudent
    {
        List<UniversityStudent> students;
        public DemoStudent()
        {
            //Seeding data
            students = new List<UniversityStudent>() {
                new UniversityStudent(1, "Nguyen Van Bom"),
            new UniversityStudent(2, "Hoang Van Thai"),
            new UniversityStudent(3, "La Thi Yen")
            };
        }
        private void printName(string fn, string ln)//Parameters
        {
            Console.WriteLine($"{fn} {ln}");
        }

        void Swap(ref int a, ref int  b, out int sum)
        {
            int tg = a;
            a = b;
            b = tg;
            sum = a + b;
        }
        //Static Function
        public static void Main(string[] args)
        {
           
            Print();
            var student = new DemoStudent();//Student is Object



            int b = 10, c = 15, sum;
            //ref dành cho giá trị khởi tạo, out ko cần khởi tạo
            student.Swap(ref b, ref c, out sum);
            Console.WriteLine($"a: {b}, b: {c}, sum: {sum}");
            
            
            
            student.printName("Nguyen", "Van An");//Arguments
            student.printName(ln: "Thi Buoi", fn: "Tran");
            //var s = new UniversityStudent(1, "Nguyen Van A");
            //Output list of Students
            List<UniversityStudent> list = student.GetAllStudent();
            foreach(var s in list)
            {
                Console.WriteLine(s);
            }
            //Local Function
            bool IsEven(int number)
            {
                CheckMaxNumber(number);
                if(number % 2 == 0)
                {
                    return true;
                }
                return false;
                //static Local function
                static void CheckMaxNumber(int number)
                {
                    if (number > 10) { 
                    Console.WriteLine($"{number} is greater than 10");
                    }
                    else
                    {
                        Console.WriteLine($"{number} is lesser than 10");
                    }
                }
            }
            int a = 10;
            if (IsEven(a))
            {
                Console.WriteLine("This is even number");
            }
            Console.ReadLine();
        }

        static void Print()
        {
            Console.WriteLine("This is static method!");
        }

        List<UniversityStudent> GetAllStudent()
        {
            return students;
        }
    }
}
