using DeeULib;

namespace Programming.SimpleOperations
{
    public static class SimpleOperations
    {
        public static int Square(int input)
        {
            return input * input;
        }


        public static double Div(double x, double y)
        {
            if(y == 0) throw new DivideByZeroException();
            return x / y;
        }
    }
}
