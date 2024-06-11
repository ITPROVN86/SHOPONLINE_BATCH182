namespace Ngay2105
{
    public class Program
    {
        public delegate bool Filter(int number);
        public bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public bool IsOdd(int number)
        {
            return number % 2 != 0;
        }

        public List<int> FilterNumber(List<int> numbers, Filter filter)
        {
            List<int> result = new List<int>();
            foreach (int number in numbers)
            {
                if (filter(number))
                {
                    result.Add(number);
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> evenNumbers = p.FilterNumber(numbers,p.IsEven);
            List<int> oddNumbers = p.FilterNumber(numbers, p.IsOdd);
            Console.WriteLine($"Even numbers: {string.Join(",", evenNumbers)}");
            Console.WriteLine($"Odd numbers: {string.Join(",", oddNumbers)}");
        }
    }
}
