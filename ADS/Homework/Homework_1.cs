using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeeULib;

namespace ADS.Homework
{
    public class Homework_1
    {
        public static void Task_3(double[] input)
        {
            var dic = new CustomDictionary<double>();

            foreach (var el in input) dic.Add(el, 1);

            var mostOftenValue = dic.GetMostOftenPair();

            if(mostOftenValue.Value > input.Length / 2)
                $"Most often value: {mostOftenValue.Key}, {mostOftenValue.Value}/{input.Length} elements are {mostOftenValue.Key}".Print();
            else
                "No such nums there".Print(ConsoleColor.Red);
        }
        public static void Task_2(int[] input) =>
            input.OrderBy(x => x).
            Aggregate((IEnumerable<IEnumerable<int>>)new List<IEnumerable<int>>()
            { Enumerable.Empty<int>() }, (x, y) => x.Concat(x.Select(z => z.Concat(new List<int>() { y })))).
            Select(x => x.ToList()).ToList().
            ForEach(x => String.Join(" ", x).
            Print());

        public static void Task_6(int a, int b, int c)
        {
            var a_permuts = GetAllPermutations(AsList(a));
            var b_permuts = GetAllPermutations(AsList(b));

            foreach (var el_a in a_permuts)
                foreach (var el_b in b_permuts)
                    if (el_a.ToInt() + el_b.ToInt() == c)
                    { $"YES, {el_a.ToInt()} + {el_b.ToInt()} = {c}".Print(ConsoleColor.Green); return; }
            "NOPE".Print(ConsoleColor.Red); return;

            List<int> AsList(int input) => input.ToString().ToCharArray().Select(x => x.ToString().ToInt()).ToList();

            string[] GetAllPermutations(List<int> input)
            {
                var result = Array.Empty<string>();
                GetAllPermutationsCore(input, ref result);
                return result;
            }

            void GetAllPermutationsCore(List<int> input, ref string[] result, string current = "")
            {
                if (input.Count == 0) { result = result.Append(current).ToArray(); return; }

                for(int i = 0; i < input.Count; i++)
                {  
                    var newInput = new List<int>(input);
                    newInput.RemoveAt(i);
                    GetAllPermutationsCore(newInput, ref result, current + input[i]);
                }
            }
        }
    }
    public class CustomPair<T>
    {
       
        public T Key { get; set; }
        public double Value { get; set; }
        public CustomPair(T key, double value)
        {
            Key = key;
            Value = value;
        }

        public bool IsKeyEquals(CustomPair<T> source) => Key.ToString().Equals(source.Key.ToString());
        public bool IsKeyEquals(T key) => Key.ToString().Equals(key.ToString());
        public override string ToString() => $"{Key}: {Value}";
    }

    public class CustomDictionary<T> 
    {
        private CustomPair<T>[] elements = Array.Empty<CustomPair<T>>();

        public bool Contains(T key) => elements.Where(x => x.IsKeyEquals(key)).Any();
        public void Add(T key, double value)
        {
            if (elements.Length == 0) { AddNewKey(new CustomPair<T>(key, value)); return; }

            for (int i = 0; i < elements.Length; i++)
                if (elements[i].IsKeyEquals(key)) { elements[i].Value += value; return; }
            AddNewKey(new CustomPair<T>(key, value));
        }

        private void AddNewKey(CustomPair<T> pair) => elements = elements.Append(pair).ToArray();
        public double GetKeyValue(T key) => elements.Where(x => x.IsKeyEquals(key)).Select(x => x.Value).First();

        public void Print()
        {
            foreach (var el in elements)
                el.ToString().Print();
        }

        public void ChangeValue(T key, double value)
        {
            if (elements.Length == 0) return;
                for (int i = 0; i < elements.Length; i++)
                if (elements[i].IsKeyEquals(key)) { elements[i].Value = value; return; }
        }
        public void ClearValue(T key) => Add(key, -GetKeyValue(key));

        public void ClearAllValues() { }
        public CustomPair<T> GetMostOftenPair() => elements.OrderBy(x => x.Value).Reverse().First();
        public IEnumerator<CustomPair<T>> GetEnumerator() => new CustomDictionaryEnumerator<T>(elements);

    }

    public class CustomDictionaryEnumerator<T> : IEnumerator<CustomPair<T>>
    {
        private bool disposedValue;

        public CustomPair<T>[] Pairs;

        int position = -1;

        object IEnumerator.Current => throw new NotImplementedException();

        public CustomPair<T> Current { get => Pairs[position];  }

        public CustomDictionaryEnumerator(CustomPair<T>[] pairs) => Pairs = pairs;
        public bool MoveNext()
        {
            position++;
            return (position < Pairs.Length);
        }

        public void Reset() => position = -1;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
