using DeeULib;
using Programming.Classwork;
using Programming.Homework;
using System.Diagnostics;

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



            //var node = new CustomNode<int>(2);
            //var node1 = new CustomNode<int>(5);
            //var node2 = new CustomNode<int>(232);


            //var list = new CustomLinkedList<int>(node);

            //list.AddLast(node1, node2);
            ////list.ToString().Print();
            //list.SwapAll();

            //list.AddAfter(new CustomNode<int>(121), 0);
            //list.AddBefore(new CustomNode<int>(121), 1);
            //list.AddAfter(new CustomNode<int>(121), 1);


            //list.RemovePenult();
            //list.Remove(0);
            //list.head.GetNext().GetNext().ToString().Print();
            //list.ToString().Print();
            //list.Count().Print();
            //node.ToString().Print();

            var coll = new CustomArrayCollecton<int>();
            coll.AddRange(1, 2, 3);
            coll.Insert(2, 45);
            //coll.Reverse();


            //var stopwatch = new Stopwatch();

            //stopwatch.Start();
            //coll.Remove(1);
            //stopwatch.Stop();

            //stopwatch.ElapsedMilliseconds.ToString().Print();

            coll.ToString().Print();
        }
        
        
    }

}

