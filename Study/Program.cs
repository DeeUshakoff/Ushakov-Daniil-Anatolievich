using DeeULib;
namespace Study
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var hw = new HW_12();

            Match[] a = Match.ReadMatches(@"D:\GitHub\Ushakov-Daniil-Anatolievich\Study\Homework\hw_12\FootB_Data.txt");
            Match.LeaderInPeriod(a, DateTime.Now, DateTime.MaxValue);
            Console.ReadKey();
        }
    }
}
