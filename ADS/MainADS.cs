using DeeULib;
using ADS.Homework;
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
                //ADS_MaxValue.GetMaxValue(40, 1, 9).Print();

                var f = new int[] { 12, 5, 6, 1,3 };
                f = f.Append(123).ToArray();
                f.Print();

                //var s = new CustomDictionary<string>();
                //s.Add("d", 3);
                //s.Add("d", 3);
                //s.Add("f", 3);
                //s.ChangeValue("f", 1231321);
                //s.ClearValue("d");
                //s.Print();
            }
            #endregion
        }
    }
    
}