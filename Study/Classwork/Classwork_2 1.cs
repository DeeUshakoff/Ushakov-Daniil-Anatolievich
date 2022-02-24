using DeeULib;

namespace Study
{
    public class Classwork_2_1
    {
        public LinkedList<int> linked_list;
        public Classwork_2_1(string? path)
        {
            var reference = ConvertToLinkedList(ReadFromFile(path));

            linked_list = reference ?? new LinkedList<int>();
        }

        public void Task_1() => Print(linked_list);
        public void Task_2()
        {
            bool hasNegative = true && linked_list.Where(x => x < 0).Any();

            PrintMax();
            PrintSum();
            CheckNegativity();

            void PrintMax() => $"Max: {linked_list.Max()}".Print();
            void PrintSum() => $"Sum: {linked_list.Sum()}".Print();
            void CheckNegativity() =>
                DeeU.Print(hasNegative ?
                    "Linked list has negative nums" : "Linked list nums are positive",
                        hasNegative ? ConsoleColor.Yellow : ConsoleColor.Green);
        }
        public void Task_3() => linked_list.RemoveFirst();
        public void Task_4() => linked_list.RemoveLast();
        public void Task_5()
        {
            // Вот они - костыли
            if (linked_list.Count >= 2)
            {
                var last = linked_list.Last();

                linked_list.RemoveLast();
                linked_list.RemoveLast();

                linked_list.AddLast(last);
            }
        }
        public void Task_6(int value) => linked_list.Remove(value);
        public void Task_7(int value)
        {
            while (linked_list.Contains(value))
                linked_list.Remove(value);
        }

        public void Task_8(int value, int newValue)
        {
            if (!linked_list.Contains(value))
            {
                $"Value {value} not found".Print(ConsoleColor.Red);
                return;
            }

            var node = linked_list.Find(value);

            linked_list.AddBefore(node, newValue);
            linked_list.AddAfter(node, newValue);
        }

        private static int[] ReadFromFile(string? path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)) || !File.Exists(path))
            {
                "Directory or file are not found".Print(ConsoleColor.Red);
                return null;
            }
            var sr = new StreamReader(path);

            var array = sr.ReadLine().Split(' ').
                Where(x => x.IsNum()).
                Select(x => x.ToInt()).ToArray();
            return array;
        }
        private static int[] ReadFromConsole(int count = 0)
        {
            if (count <= 1)
            {
                "Enter num: ".PrintL(ConsoleColor.Green);
                return new int[] { DeeU.ReadInt() };
            }

            $"Enter {count} nums".Print(ConsoleColor.Green);

            var entered_nums = new int[count];

            for (int current_num = 0; current_num < count; current_num++)
            {
                $"{current_num + 1}/{count}: ".PrintL();
                entered_nums[current_num] = DeeU.ReadInt();
            }
            return entered_nums;
        }

        private static LinkedList<int> ConvertToLinkedList(int[] source)
        {
            var linked_list = new LinkedList<int>();
            foreach (var el in source)
                linked_list.AddLast(new LinkedListNode<int>(el));
            return linked_list;
        }
        public void Print(LinkedList<int> source)
        {
            foreach (var el in source)
                el.Print();
        }
    }
}
