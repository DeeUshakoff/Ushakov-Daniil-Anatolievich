using ADS.Algorithms;
using DeeULib;
using ADS.Homework;
using ADS.Homework.Homework_24_02_2022;
using Programming.Classwork;

namespace ADS
{
    public static class MainADS
    {
        public static void Main()
        {
            var list = new DoublyLinkedList<int>
            {
                new CustomNode<int>(1),
                new CustomNode<int>(2),
                new CustomNode<int>(3),
                new CustomNode<int>(4)
            };

            list.SwapElements();
            list.Print();
            
            var list2 = new DoublyLinkedList<int>
            {
               
            };
            list2.SwapElements();
            list2.Print();
        }
        
    }
    
}