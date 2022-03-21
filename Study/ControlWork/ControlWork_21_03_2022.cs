using System.Collections;
namespace Programming
{
    public class ControlWork_21_03_2022
    {
        public class CustomQueue<T> : IEnumerable<Node<T>>
        {
            public LinkedList<T> list = new();

            IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();
            IEnumerator<Node<T>> IEnumerable<Node<T>>.GetEnumerator()
            {
                foreach (var el in list.ToArray()) yield return el;
            }

            public IEnumerable<Node<T>> GetOddEven()
            {
                var list = this.ToArray();

                var concated = list.Where((val, ind) => ind % 2 == 0).Concat(list.Where((val, ind) => ind % 2 != 0));
                foreach (var el in concated)
                    yield return el;
            }

            public void RemoveThird()
            {
                if (Size() < 3)
                    throw new Exception("Size less than 3");
                Remove(2);
            }
            public Node<T> Dequeue()
            {
           
                if (IsEmpty())
                    throw new Exception("Queue is empty");

                var result = list.First();
                list.RemoveFirst();
                return result;
            }

            public void Remove(uint index) => list.Remove((int)index);


            public void Enqueue(Node<T> node) => list.Add(node);
            public int Size() => list.Count();
            public bool IsEmpty() => !list.Any();

            public override string ToString() => String.Join(" ", this);
        }


        public class Node<T>
        {
            public T Value;
            public Node<T> next;
            public Node(T value) => Value = value;

            public override string ToString() => Value.ToString();
        }
        public class LinkedList<T> : IEnumerable<Node<T>>
        {
            IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();

            IEnumerator<Node<T>> IEnumerable<Node<T>>.GetEnumerator()
            {
                Node<T> current = head;
                while (current != null)
                {
                    yield return current;
                    current = current.next;
                }
            }

            Node<T> head;


            public void Add(Node<T> node)
            {

                if (head == null)
                    head = node;
                else
                {
                    Node<T> runner = head;

                    while (runner.next != null)
                        runner = runner.next;
                    runner.next = node;
                }
            }


            public void RemoveLast()
            {
                Node<T> runner = head;

                while (runner.next != null)
                {
                    if (runner.next.next == null)
                    {
                        runner.next = null;
                        break;
                    }
                    runner = runner.next;
                }
            }

            public void RemoveFirst()
            {
                if (this.Count() == 1)
                {
                    head = null;
                    return;
                }
                head = head.next;
            }

            public void Remove(int index)
            {
                var count = this.Count();
                if (index == 0) { RemoveFirst(); return; }
                if (index == count - 1) { RemoveLast(); return; }
                var headCopy = head;
                for (int i = 0; i < count - 1; i++)
                {
                    if (i == index - 1)
                    { headCopy.next = headCopy.next.next; return; }

                    headCopy = headCopy.next;
                }
            }
        }
    }
}

