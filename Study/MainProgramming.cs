using DeeULib;
using Programming.Classwork;
namespace Programming
{
    public class MainProgramming
    {
        //            Console.OutputEncoding = System.Text.Encoding.UTF8;

        public static void Main()
        {
            var queue = new ControlWork_21_03_2022.CustomQueue<int>();
            var node = new ControlWork_21_03_2022.Node<int>(1);
            var node1 = new ControlWork_21_03_2022.Node<int>(2);
            var node2 = new ControlWork_21_03_2022.Node<int>(3);
            var node3 = new ControlWork_21_03_2022.Node<int>(4);
            var node4 = new ControlWork_21_03_2022.Node<int>(46);
            var node5 = new ControlWork_21_03_2022.Node<int>(46);

            var nodes = new[] { node1, node2, node3, node4, node5 };

            queue.Enqueue(node);
            queue.Enqueue(node1);
            queue.Enqueue(node2);
            queue.Enqueue(node3);

            queue.Remove(0);
            queue.ToString().Print();
            //queue.Size().Print();
            //var t = queue.Dequeue();

            //t.ToString().Print();
            //String.Join(" ", queue.GetOddEven()).Print();
            //list.Contains(new CustomNode<int>( 1)).Print();

        }
    }

}

