
namespace Study
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Console.WriteLine(3 % 3);

            var a = new CNum(1, 1);
            var b = (CNum)a.Clone();
            a.x = 123;
            b.Print();
            DeeU.Wait();
        }

    }

}
