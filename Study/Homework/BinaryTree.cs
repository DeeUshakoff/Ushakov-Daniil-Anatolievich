using DeeULib;
namespace Programming;

public class BinarySearchTree<T>
    where T : IComparable, IComparable<T>
{
    public TreeNode<T> Root;
    public int Count => nodes.Count;
    private List<TreeNode<T>> nodes = new();

    public static int GetDirection(TreeNode<T> child, TreeNode<T> parent) =>
        child.Data.CompareTo(parent.Data) > 0 ? 0 : 1;

    public bool IsExternal(int position)
    {
        if (!(from node in nodes select node.Position).Contains(position))
            throw new Exception($"Tree hasn't node with position {position}");
        return nodes.Find(x => x.Position == position).IsExternal();
    }
    
    public void Remove(int position)
    {
        nodes.RemoveAt(nodes.FindIndex(x => x.Position == position));
        var newNodes = nodes.OrderBy(x => x.Position).ToList();
        
        Root = null;
        nodes = new List<TreeNode<T>>();
        
        newNodes.ForEach(x => Add( new TreeNode<T>(x.Data)));
    }
    private bool SetChild(TreeNode<T> parent, TreeNode<T> child)
    {
        if (parent == null)
        {child.Position = 1; parent = child;  return true;}
        if (GetDirection(parent, child) == 0 && !parent.HasLeftChild())
        {
            parent.Left = child;
            child.Parent = parent;
            child.GeneratePosition(parent);
         
            return true;
        }
        if(GetDirection(parent, child) == 1 && !parent.HasRightChild())
        {
            parent.Right = child;
            child.Parent = parent;
            child.GeneratePosition(parent);
         
            return true;
        }
        return false;
    }
    public void Add(TreeNode<T> node)
    {
        var current = Root;
        if(node != null)
            nodes.Add(node);
        
        if (Root == null) {node.Position = 1; Root = node;  return;}
        
        foreach (var i in Enumerable.Range(1, Count))
        {
            if(SetChild(current, node)) break;
            current = GetDirection(current, node) == 0? current.Left : current.Right;
        }
    }

    public void Add(T data) => Add(new TreeNode<T>(data));

    public void SmallLeftTurn(ref TreeNode<T> node) => node = SmallLeftTurnCore(node);
    public void SmallLeftTurn(TreeNode<T> node, out TreeNode<T> left) => left = SmallLeftTurnCore(node);
    private TreeNode<T> SmallLeftTurnCore(TreeNode<T> node)
    {
        var temp = node.Right;
        node.Right = temp.Left;
        temp.Left = node;
        return temp;
    }
    public void SmallRightRotate(ref TreeNode<T> node) => node = SmallRightTurnCore(node);
    public void SmallRightRotate(TreeNode<T> node, out TreeNode<T> right) => right = SmallRightTurnCore(node);
    private TreeNode<T> SmallRightTurnCore(TreeNode<T> node)
    {
        var temp = node.Left;
        node.Left = temp.Right;
        temp.Right = node;
        return temp;
    }
    public void BigLeftRotate(ref TreeNode<T> node)
    {
        SmallRightRotate(node.Right, out var right);
        node.Right = right;
        SmallLeftTurn(ref node);
    }
    
    public void BigRightRotate(ref TreeNode<T> node)
    {
        SmallLeftTurn(node.Left, out var left);
        node.Left = left; 
        SmallRightRotate(ref node);
    }
}
public class TreeNode<T> : IComparable<T>, IComparable
    where T : IComparable, IComparable<T>
{
    public T Data;
    private int position;
    public int Position
    {
        get => position;
        set => position = value >= 1 ? value : throw new Exception("Pos invalid");
    }
    
    public TreeNode<T> Left;
    public TreeNode<T> Right;
    public TreeNode<T> Parent;
    
    public void GeneratePosition(TreeNode<T> parent)
    {
        if (parent.Left == this)
        {
            Position = 2 * parent.Position;
            return;
        }
        Position = 2 * parent.Position + 1;
    }
    
    public static bool IsExternal(TreeNode<T> node) => node.Left == null && node.Right == null;
    public bool IsExternal() => Left == null && Right == null;
    public bool HasLeftChild() => Left != null;
    public bool HasRightChild() => Right != null;
    public TreeNode(T data) => Data = data;

    public TreeNode(T data, TreeNode<T> left, TreeNode<T> right)
    {
        Data = data;
        Left = left;
        Right = right;
        
    }

    public int CompareTo(object obj)
    {
        if (obj is TreeNode<T> item) return Data.CompareTo(item);

        throw new ArgumentException("Types not equals");
    }
    
    public int CompareTo(T data) => Data.CompareTo(data);

    public override string ToString() => 
        $"|value: {Data}, pos: {Position}, left: {(Left == null ? "null" : Left.Data.ToString())}, right: {(Right == null ? "null" : Right.Data.ToString())}|";
}