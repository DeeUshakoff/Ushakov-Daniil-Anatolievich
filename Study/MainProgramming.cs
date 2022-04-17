using DeeULib;
using Programming.Classwork;
namespace Programming;

    public class MainProgramming
    {
        //            Console.OutputEncoding = System.Text.Encoding.UTF8;

        public static void Main()
        {
            // var queue = new ControlWork_21_03_2022.CustomQueue<int>();
            // var node = new ControlWork_21_03_2022.Node<int>(1);
            // var node1 = new ControlWork_21_03_2022.Node<int>(2);
            // var node2 = new ControlWork_21_03_2022.Node<int>(3);
            // var node3 = new ControlWork_21_03_2022.Node<int>(4);
            // var node4 = new ControlWork_21_03_2022.Node<int>(46);
            // var node5 = new ControlWork_21_03_2022.Node<int>(46);
            //
            // var nodes = new[] { node1, node2, node3, node4, node5 };
            //
            // queue.Enqueue(node);
            // queue.Enqueue(node1);
            // queue.Enqueue(node2);
            // queue.Enqueue(node3);
            //
            // queue.Remove(0);
            // queue.ToString().Print();

            // var tree = new BinarySearchTree<int>();
            //
            //
            // var node1 = new TreeNode<int>(1);
            // var node2 = new TreeNode<int>(0);
            // var node3 = new TreeNode<int>(3);
            // var node4 = new TreeNode<int>(2);
            // var node5 = new TreeNode<int>(5);
            //
            //
            // tree.Add(node1);
            // tree.Add(node2);
            // tree.Add(node3);
            // tree.Add(node4);
            // tree.Add(node5);
            //
            // tree.SmallLeftTurn(ref tree.Root);
            // tree.Root.Print();
            
             //queue.Size().Print();
             //var t = queue.Dequeue();
             // new DeeU.DRandom(0, 10000);


             //t.ToString().Print();
             //String.Join(" ", queue.GetOddEven()).Print();
             //list.Contains(new CustomNode<int>( 1)).Print();

             var company = new ClassworkEvents.Company();
             var w1 = new ClassworkEvents.Worker(ClassworkEvents.WorkerStatus.Worker);
             var w2 = new ClassworkEvents.Worker(ClassworkEvents.WorkerStatus.Worker);
             var w3 = new ClassworkEvents.Worker(ClassworkEvents.WorkerStatus.Worker);
             var w4 = new ClassworkEvents.Worker(ClassworkEvents.WorkerStatus.Worker);
             company.AddNewWorker(w1);
             company.AddNewWorker(w2);
             company.AddNewWorker(w3);
             company.RemoveWorker(1);
             company.AddNewWorker(w4);
             company.Print();
             

        }
        
    }



