
namespace lessons
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;




            //var hotel = new Hotel("sinsdgle", "full", 2, 23333, 1, 2, false);
            //hotel.Populate();
            //hotel.Print();

            //var rental = new Rental(1500, 1, 12, true, false, false, true, false);
            //rental.Print();

            //var tri = new Triangle();


            //tri.Create(3,4,5);
            //tri.Print();

            //var rTri = new TriangleRight(3, 4, 5);


            var IsoTri = new TriangleIsoscale();
            IsoTri.Create(2,3);
            DeeU.Print(IsoTri.GetSqaure());
            IsoTri.PrintTriangle();
            //rTri.Print();

            //var PM = new PasswordManager();
            //PM.Start();



            //var game = new Chess();
            //game.Play();








            DeeU.Wait();



        }

    }

}
