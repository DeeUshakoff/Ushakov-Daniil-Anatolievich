namespace Programming.Homework;

public class AVLTree<T> : BinarySearchTree<T> where T : IComparable, IComparable<T>
{
    public new void Add(TreeNode<T> node)
    {
        base.Add(node);
        
    }
    
}