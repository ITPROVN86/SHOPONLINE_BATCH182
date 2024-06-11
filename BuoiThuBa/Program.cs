namespace BuoiThuBa
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            /*Console.WriteLine($"Time: {DateTime.Now}");
            await Task.Delay(3000);
            Console.WriteLine($"Time: {DateTime.Now}");*/
            Console.WriteLine($"Result: {await AsFact(6)}");
            Console.Read();
        }

        public static Task<int> AsFact(int num)
        {
            return Task.Run(() => Compute(num));
            int Compute(int p)
            {
                if (p == 1) return 1;
                else return p*Compute(p-1);
            }
        }

    }
}
