using DeeULib;

namespace Programming.ControlWork;

public class CWTreeNode<T> : IComparable<T>, IComparable where T: IComparable, IComparable<T>
{
    public T Data;
    public CWTreeNode<T> Left;
    public CWTreeNode<T> Right;
    public CWTreeNode<T> Parent;
    public int height;

    public CWTreeNode(T data) => Data = data;

    public int CompareTo(object obj) 
    {
        if (obj is TreeNode<T> item)
            return Data.CompareTo(item);
        throw new Exception("Different types");
    }

    public int CompareTo(T data) => Data.CompareTo(data); 

}

public class CWBinarySearchTree<T> where T : IComparable, IComparable<T>
{
    private CWTreeNode<T> Root;
    private List<CWTreeNode<T>> nodeList = new();
    
    public void Add(T data)
    {
        var node = new CWTreeNode<T>(data);

        if (Root == null)
        {
            node.height = 1;
            Root = node;
            nodeList.Add(Root);
        }
        else
        {
            var runner = Root;
            while (true)
            {
                if (node.Data.CompareTo(runner.Data) < 0)
                {
                    if (runner.Left == null)
                    {
                        node.Parent = runner;
                        node.height += node.Parent.height + 1;
                        runner.Left = node;
                        nodeList.Add(node);
                        return;
                    }
                    runner = runner.Left;
                }
                else
                {
                    if (runner.Right == null)
                    {
                        node.Parent = runner;
                        node.height += node.Parent.height + 1;
                        runner.Right = node;
                        nodeList.Add(node);
                        return;
                    }
                    runner = runner.Right;
                }
            }
        }
    }

    public void NodeHeight(int height)
    {
        foreach (var node in nodeList.Where(node => node.height == height))
            (node.Data + " ").PrintL();

        DeeU.Print();
    }

    public int NumOfLeaves() => nodeList.Count(node => node.Left == null && node.Right == null);

    public void RainbowPrint()
    {
        var colors = (ConsoleColor[]) ConsoleColor.GetValues(typeof(ConsoleColor));
        var random = new Random();
        
        if (Root == null)
            return;

        var queue = new Queue<CWTreeNode<T>>();
        queue.Enqueue(Root);
        var lastHeight = 1;
        var currentColor = colors[0];
        
        while (queue.Count != 0)
        {
            var runner = queue.Peek();
            var currunetHeight = runner.height;
            queue.Dequeue();

            if (currunetHeight == lastHeight)
            {
                Console.ForegroundColor = currentColor;
                runner.Data.Print();
            }
            else
            {
                lastHeight = currunetHeight;
                currentColor = colors[new Random().Next(1, 15)];
                Console.ForegroundColor = currentColor;
                runner.Data.Print();
            }

            if (runner.Left != null)
                queue.Enqueue(runner.Left);

            if (runner.Right != null)
                queue.Enqueue(runner.Right);
        }
    }
}

