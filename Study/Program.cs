
namespace Study
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;




            var toy_1 = new Toy(10, false, 1, 1);
            var toy_2 = new Toy(1, false, 1, 1);
            var toy_3 = new Toy(2, false, 1, 1);
            var toy_4 = new Toy(5, true, 1, 1);

            var garland_1 = new Garland(3, false, 1, 1);
            //var garland_2 = new Garland(3, false, 1, 1);

            var tree_1 = new ChristmasTree(10, 2, 1);
            var showcase_1 = new Showcase(20, 2);
            

            
            var Manager = new ChristmasManager(tree_1, showcase_1);

            
            Manager.DecorateTree(toy_4);
            Manager.DecorateTree(toy_4);
            Manager.DecorateTree(garland_1);



            //Manager.ChristmasTree = tree;
            //Manager.DecorateTree();
            Manager.Print();
            
            
            DeeU.Wait();



        }

    }

}
