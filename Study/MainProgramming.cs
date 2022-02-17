using DeeULib;
using Programming.Classwork;
namespace Study
{
    public class MainProgramming
    {
        //            Console.OutputEncoding = System.Text.Encoding.UTF8;

        public static void Main()
        {
            //var s = new Classwork_2_1(@"D:\123.txt");
            ////s.ReadFromFile(@"D:\123.txt").Print();
            //s.Task_8(182, 1);
            ////s.Task_6(18);
            //s.Task_1();

            //s.Task_2();

            var node = new CustomNode<int>(2);
            var node1 = new CustomNode<int>(-5);
            var node2 = new CustomNode<int>(232);

            var list = new CustomLinkedList<int>(node);

            list.AddLast(node1, node2);
            
            
            //list.head.GetNext().GetNext().ToString().Print();
            list.ToString().Print();
            list.Sum().Print();
            list.HasNagative().Print();
            //node.ToString().Print();
        }
        
        
    }

}

