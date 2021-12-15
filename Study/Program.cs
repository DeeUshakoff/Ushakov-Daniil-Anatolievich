using DeeULib;
namespace Study
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var m_1 = new ConstructionMachine("KFU", "Bot", 15, 1, 3, true);
            var m_2 = new ConstructionMachine("KFU", "Bot", 15, 1, 3, true);
            var m_3 = new ConstructionMachine("Mercedes", "TravelCar", 1500, 1000, 80, true);
            var m_4 = new ConstructionMachine("KFU", "Bot_Beta", 15, 1, 5, true);
            var m_5 = new ConstructionMachine("KFU", "Bot_Alpha", 15, 1, 17, true);

            var stack = new Stack();

            stack.Add(m_1, m_2, m_3, m_4, m_5);
            
            stack.Read();
            stack.Read();

            stack.Print();

            m_1.Repair(@"C:\Users\DeeUsh\Desktop\Tor Browser\m.txt");
            m_2.Repair(@"C:\Users\DeeUsh\Desktop\Tor Browser\m.txt");
            m_3.Repair(@"C:\Users\DeeUsh\Desktop\Tor Browser\m.txt");


        }

        

        
    }
    
}
