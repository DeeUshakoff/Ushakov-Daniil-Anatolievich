using DeeULib;
using System.Text;
namespace ADS
{
    public static class ADS_Sort
    {
        public static int[]? Sort(params int[][] array)
        {
            int[] result = Array.Empty<int>();
            foreach (var item in array)
                result = SortCore(result, item);
            return result;
        }
        public static int[]? Sort(string path) => Sort(ADS_Filework_10_02_2022.ReadFromFile(path));
        static int[]? SortCore(int[] a, int[] b)
        {
            if (a == null && b == null || a.Length == 0 && b.Length == 0)
                return null;
            else if (a == null || b == null)
                return a ?? b;

            ADS_Filework_10_02_2022.CheckSorting(a, b);

            int[] result = new int[a.Length + b.Length];

            int index_a = 0;
            int index_b = 0;

            int index_result = 0;
            while (index_a < a.Length && index_b < b.Length)
            {
                if (a[index_a] < b[index_b])
                {
                    result[index_result] = a[index_a];
                    index_a++;
                }
                else
                {
                    result[index_result] = b[index_b];
                    index_b++;
                }
                index_result++;
            }

            if (index_a < a.Length)
                for (int i = index_a; i < a.Length; i++)
                {
                    result[index_result] = a[i];
                    index_result++;
                }

            if (index_b < b.Length)
                for (int i = index_b; i < b.Length; i++)
                {
                    result[index_result] = b[i];
                    index_result++;
                }

            return result;
        }
    }

    public static class ADS_Same
    {
        public static int[]? GetSame(params int[][] array)
        {
            if (array.Length == 1 || array == null) throw new Exception("Needs >= 2 arrays");

            int[] result = array[0];
            foreach (var item in array)
                result = GetSameCore(result, item);

            return result;
        }
        public static int[]? GetSame(string path) => GetSame(ADS_Filework_10_02_2022.ReadFromFile(path));

        static int[]? GetSameCore(int[] a, int[] b)
        {
            if (a == null || b == null)
                return a ?? null;

            ADS_Filework_10_02_2022.CheckSorting(a, b);

            var result =
            from int_a in a
            join int_b in b on int_a equals int_b
            select new { num = int_a }.num;

            return result.ToArray();
        }
    }
    public static class ADS_MaxValue
    {
        public static double GetMaxValue(params int[] value) =>
            (from variation in GetPermutations(value.ToList(), new List<int>())
             select variation.ToDouble()).Max();

        static IEnumerable<List<int>> GetPermutations(List<int> source, List<int> without)
        {
            if (source.Where(x => x < 0).Any() || source.Count == 0) throw new Exception("Negative inside / Null reference");

            if (source.Count == 1) return new List<List<int>> { new List<int>() { source[0] } };
            else
            {
                var result = new List<List<int>>();

                foreach (var first in source)
                {
                    var next = new List<int>(source.Except(new int[] { first }));
                    without.Add(first);
                    var others = new List<int>(next.Except(without));

                    var permutations = GetPermutations(others, without);
                    without.Remove(first);

                    foreach (var el in permutations)
                    {
                        el.Insert(0, first);
                        result.Add(el);
                    }
                }
                return result;
            }
        }

    }

    public static class ADS_Unique
    {
        /// <summary>
        /// Unique element in first array
        /// </summary>
        /// <param name="path">path to the file</param>
        /// <returns>int[]</returns>
        public static int[]? GetUnique(string path) => GetUnique(ADS_Filework_10_02_2022.ReadFromFile(path));

        /// <summaUnique element in first arrayry>
        /// 
        /// </summary>
        /// <param name="array">Arrays</param>
        /// <returns>int[]</returns>
        public static int[] GetUnique(params int[][] array)
        {
            if (array.Length == 1 || array == null) throw new Exception("Needs >= 2 arrays");
            var result = array[0];

            for (int i = 1; i < array.Length; i++)
                result = result.Except(array[i]).ToArray();
            return result;
        }
    }
    static class ADS_Filework_10_02_2022
    {
        public static void CheckSorting(params int[][] a)
        {
            foreach (var el in a)
                CheckingCore(el);

            static void CheckingCore(int[] a)
            {
                int prev = a[0];
                for (int i = 0; i < a.Length; i++)
                    if (a[i] < prev)
                        throw new ArrayNotSortedException($"Source array is not sorted");
            }
        }
        public static int[][]? ReadFromFile(string path)
        {
            
            if (!Directory.Exists(Path.GetDirectoryName(path)) || !File.Exists(path))
            {
                "Directory or file are not found".Print(ConsoleColor.Red);
                return null;
            }

            var sr = new StreamReader(path);

            var text_lines = sr.ReadToEnd().Split('\n');

            sr.Dispose();

            if (text_lines[0].Split(' ').Length != 1)
                throw new Exception("File doesnt supported");

            text_lines = text_lines[1..text_lines.Length];

            int[][] arrays = Array.Empty<int[]>();

            foreach (var line in text_lines)
            {
                arrays = arrays.Append(line.Split(' ').
                Where(x => x.IsNum()).
                Select(x => x.ToInt()).ToArray()).ToArray();
            }
            return arrays;
        }
    }
    public class ArrayNotSortedException : Exception
    {
        public ArrayNotSortedException(string input = "")
        { input.Print(ConsoleColor.Red); }
    }
}