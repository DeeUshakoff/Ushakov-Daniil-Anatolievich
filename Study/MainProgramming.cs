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
            list.AddAfter(new CustomNode<int>(10), 2);
            list.AddLast(new CustomNode<int>(10), new CustomNode<int>(13));
            list.ToString().Print();


            list.Remove(new CustomNode<int>(10), true);
            //list.RemovePenult();
            //list.Remove(0);
            //list.head.GetNext().GetNext().ToString().Print();
            list.ToString().Print();
            list.Count().Print();
            //node.ToString().Print();
        }
        
        
    }

}

