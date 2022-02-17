using DeeULib;

namespace ADS
{
    public static class MainADS
    {
        public static void Main()
        {
            Classwork_1(true);

            #region "Classwork 1"
            void Classwork_1(bool run = false)
            {
                if (!run) return;
                //String.Join(' ', ADS_Sort.Sort(@"D:\123.txt")).Print();

                //String.Join(' ', ADS_Same.GetSame(@"D:\123.txt")).Print();


                //String.Join(' ', ADS_Unique.GetUnique(@"D:\123.txt")).Print();
                ADS_MaxValue.GetMaxValue(40, 1, 9).Print();

            }
            #endregion
        }
    }
    
}