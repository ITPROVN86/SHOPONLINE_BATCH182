namespace Ngay1805
{
    public class Program
    {
        public static void Alarm_OnAlarmRing()
        {
            Console.WriteLine("Alarm is ring...");
        }
        static void Main(string[] args)
        {
            Caculator caculator = new Caculator();
            Caculator.Operation op;
            op = caculator.Add;
            Console.WriteLine($"Sum: {op(15, 5)}");
            op = caculator.Subtract;
            Console.WriteLine($"Sub: {op(15, 5)}");
            op = caculator.Multiply;
            Console.WriteLine($"Mul: {op(15, 5)}");
            op = caculator.Divide;
            Console.WriteLine($"Div: {op(15, 5)}");

            /* Alarm alarm = new Alarm();
             alarm.OnAlarmRing += Alarm_OnAlarmRing;
             alarm.SetAlarm(3);*/
            /*Student student = new Student()
            {
                StudentId = 1,
                Name = "Hoang Van Thai",
                Age = 19,
                GPA = 3.8
            };

            var studentInfo = student.GetStudentInfo();
            Console.WriteLine($"ID: {studentInfo.Item1}, Name: {studentInfo.Item2}, Age: {studentInfo.Item3}, GPA: {studentInfo.Item4}");*/

            /*Electronic laptop = new Electronic()
            {
                ProductId = 1,
                ProductName = "Laptop",
                Price = 25000000
            };
            Grocery apple = new Grocery() {
                ProductId = 2,
                ProductName = "Apple",
                Price = 45000000
            };

            Console.WriteLine(laptop.DisplayInfo() + ", Tax: " + laptop.CalculateTax());
            Console.WriteLine(apple.DisplayInfo() + ", Tax: " + apple.CalculateTax());

            Order order = new Order()
            {
                OrderId = 1,
                CustomerName = "Tran Van An",
                OrderDate = DateTime.Now
            };
            order.Products.Add(laptop);
            order.Products.Add(apple);
            Console.WriteLine(order.DisplayInfo());*/

            /*Employee employee = new Employee()
            {
                EmployeeId = 1,
                Name = "Nguyen Van A",
                Position = "Employee",
                Salary = 1500,
            };
            Console.WriteLine(employee.DisplayInfo());
            Manager manager = new Manager()
            {
                EmployeeId = 1,
                Name = "Nguyen Van A",
                Position = "Manager",
                Salary = 1500,
                Department = "Sales"
            };
            Console.WriteLine(manager.DisplayInfo());*/
        }
    }
}
