using DeeULib;
using Programming.Classwork;
using Programming;
using Programming.Homework.hw_25._04._2022;

namespace Study
{
    public class MainProgramming
    {
        //            Console.OutputEncoding = System.Text.Encoding.UTF8;

        public static void Main()
        {
            // var tree = new BinarySearchTree<int>();
            //
            // tree.Add( new TreeNode<int>(50));
            // tree.Add( new TreeNode<int>(17));
            // tree.Add( new TreeNode<int>(70));
            // tree.Add( new TreeNode<int>(12));
            // tree.Add( new TreeNode<int>(23));
            // tree.Add( new TreeNode<int>(19));
            // tree.Add( new TreeNode<int>(24));
            //
            // tree.SmallLeftTurn(ref tree.Root);
            //
            // tree.Root.PrintL();

            var ps = new PowerStation(10, 5);
            var fd = new FireDepartment("Team 1");
            var fd2 = new FireDepartment("Team 3");
            var mes = new MES("Mes");
            ps.OnEmergencyEvent += fd.HandleEmergency;
            ps.OnEmergencyEvent += fd2.HandleEmergency;
            ps.OnEmergencyEvent += mes.HandleEmergency;
            ps.Start();
            
        }
        
        
    }

}

