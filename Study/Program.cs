using DeeULib;
namespace Study
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string str_1 = "word1 word2 123 4";
            string str_2 = "a b c d e f g h i";

            str_1.StangeJoin(str_2).Print(ConsoleColor.Cyan);


            DeeU.Wait();
        }

    }

}
