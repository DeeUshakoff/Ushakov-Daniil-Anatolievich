using DeeULib;
using Programming.Classwork;
using Programming;
namespace Study
{
    public class MainProgramming
    {
        //            Console.OutputEncoding = System.Text.Encoding.UTF8;

        public static void Main()
        {
            var tree = new BinarySearchTree<int>();

            tree.Add( new TreeNode<int>(50));
            tree.Add( new TreeNode<int>(17));
            tree.Add( new TreeNode<int>(70));
            tree.Add( new TreeNode<int>(12));
            tree.Add( new TreeNode<int>(23));
            tree.Add( new TreeNode<int>(19));
            tree.Add( new TreeNode<int>(24));

            tree.SmallLeftTurn(ref tree.Root);

            tree.Root.PrintL();
        }
        
        
    }

}

