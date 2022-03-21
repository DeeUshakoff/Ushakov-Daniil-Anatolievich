using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeeULib;

namespace Programming.Classwork
{
    public class CustomLinkedList<T>
    {
        public CustomNode<T> head;
        public CustomNode<T> Last;
        public CustomLinkedList(T value) => AddFirst(new CustomNode<T>(value));
        public CustomLinkedList(CustomNode<T> node) => AddFirst(node);

        private int count = 0;
        public void AddFirst(CustomNode<T> node)
        {
            if (head == null) { head = node; count++; return; }
            
            node.ChangeNext(head);
            head = node;

            count++;
        }
        public void AddLast(params CustomNode<T>[] node)
        {
            foreach(var el in node)
                AddLastCore(el);
        }

        public double Sum()
        {
            if (!DeeULib.DeeU.IsNum(head.GetValue().ToString()))
                throw new Exception("Unnable to sum");
            double res = 0;
            
            foreach (var el in this) res += el.ToDouble();
            return res;
        }
        public CustomNode<T> Max()
        {
            var max = head;
            foreach (var el in this)
                if(el.ToDouble() > max.ToDouble())
                    max = el;
            return max;
        }
        public CustomNode<T> Min()
        {
            var min = head;
            
            foreach (var el in this)
                if (el.ToDouble() < min.ToDouble())
                    min = el;
            return min;
        }
        public bool HasNagative()
        {
            foreach (var el in this)
                if (Double.IsNegative(el.ToDouble())) return true;
            return false;
        }
        private void AddLastCore(CustomNode<T> node)
        {
            if (head == null)
            {
                head = node;
                return;
            }
            
            var headCopy = head;
            while (headCopy.GetNext() != null)
                headCopy = headCopy.GetNext();

            headCopy.ChangeNext(node);
            Last = node;
            count++;
        }
        
        public void SwapAll()
        {
            var headCopy = head;

            for (int i = 1; i <= count-2; i++)
            {
                AddBefore(headCopy, i);
                //Remove(i);
                if (headCopy == null)
                    throw new ArgumentOutOfRangeException();
                headCopy = headCopy.GetNext();
            }

            count++;
        }
        public void AddAfter(CustomNode<T> node, int index)
        {
            node = new CustomNode<T>(node.GetValue());
            if (index == 0) { AddFirst(node); return; }
            if (index == count) { AddLast(node); return; }

            var headCopy = head;
            for (int i = 0; i <= index - 2; i++)
            {
                if (headCopy == null)
                    throw new ArgumentOutOfRangeException();
                headCopy = headCopy.GetNext();
            }

            if (headCopy.GetNext() != null)
                node.ChangeNext(headCopy.GetNext());
            headCopy.ChangeNext(node);

            count++;
        }

        public void AddAround(CustomNode<T> node, int index)
        {
            //if(index == 0) { AddFirst(node); return; }
            //if(index == count) { AddLast(node); return; }

            AddBefore(node, index);
            AddAfter(node, index+1);
           
        }
        public void AddBefore(CustomNode<T> node, int index) => AddAfter(node, index - 1);

        public void RemoveLast()
        {
            if (head.GetNext() == null && head != null) { head = null; return; }

            var headCopy = head;
            for(int i = 1; i < count-1; i++)
                headCopy = headCopy.GetNext();

            headCopy.ChangeNext(null);
            count--;
        }
        public void RemovePenult()
        {
            var last = Last;
            RemoveLast();
            RemoveLast();
            AddLast(last);
        }
        public void RemoveFirst()
        {
            if(head.GetNext() == null || head == null) { head = null; return; }
            head = head.GetNext();
            count--;
        }

        public void Remove(int index)
        {
            if(index == 0) { RemoveFirst(); return; }
            if(index == count-1) { RemoveLast(); return; }  
            var headCopy = head;
            for (int i = 0; i < count - 1; i++)
            {
                if (i == index - 1)
                { headCopy.ChangeNext(headCopy.GetNext().GetNext()); return; }

                headCopy = headCopy.GetNext(); 
            }
        }
        public void Remove(CustomNode<T> node, bool all = false)
        {
            var headCopy = head;

            for (int i = 0; i < count-1; i++)
            {
                //headCopy.GetValue().ToString().Print();
                if (headCopy.GetValue().Equals(node))
                { "sada".Print(); Remove(i); }


                //if (headCopy.GetNext() == null)
                //{
                    
                //    //if (headCopy.Equals(node)) { RemoveLast(); return; }
                //    return;
                //}
                //if (headCopy.GetNext().Equals(node))
                //    if(!all) { headCopy.ChangeNext(headCopy.GetNext().GetNext()); return; }
                //    else headCopy.ChangeNext(headCopy.GetNext().GetNext());
                headCopy = headCopy.GetNext();
            }
        }
        public CustomNode<T> GetFirst() => head;
        public int Count() => count;
        public override string ToString()
        {
            var headCopy = head;
            StringBuilder result = new();

            if (head == null)
            {
                return String.Empty;
            }
            while (headCopy != null)
            {
                result.Append(headCopy.ToString() + " ");
                headCopy = headCopy.GetNext();
            }
            return result.ToString();
        }
        
        public IEnumerator<CustomNode<T>> GetEnumerator() => new CustomLinkedListEnumenator<T>(head);

    }

    public class DoublyLinkedList<T> : IEnumerable<CustomNode<T>>
    {
        public CustomNode<T> head;
        public CustomNode<T> tail;

        private int count;
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        public void Add(CustomNode<T> node)
        {
            if (head == null)
                head = node;
            else
            {
                tail.ChangeNext(node);
                node.ChangePrevious(tail);
            }
            tail = node;
            count++;
        }
        public void AddFirst(CustomNode<T> node)
        {
            CustomNode<T> temp = head;
            node.ChangeNext(temp);
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.ChangePrevious(node);
            count++;
        }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public bool Contains(CustomNode<T> node) => this.Where(x => x.Equals(node)).Any();
        public void Remove(CustomNode<T> node)
        {
            CustomNode<T> current = head;

            while (current != null)
            {
                if (current.Equals(node)) break;
                current = current.GetNext();
            }
            if (current != null)
            {
                if (current.GetNext() != null)
                    current.GetNext().ChangePrevious(current.GetPrevious());
                else
                    tail = current.GetPrevious();

                if (current.GetPrevious() != null)
                    current.GetPrevious().ChangeNext(current.GetNext());
                else
                    head = current.GetNext();
                count--;
            }
        }
        public void RemoveHead()
        {

        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();

        IEnumerator<CustomNode<T>> IEnumerable<CustomNode<T>>.GetEnumerator()
        {
            CustomNode<T> current = head;
            while (current != null)
            {
                yield return current;
                current = current.GetNext();
            }
        }

        public IEnumerable<CustomNode<T>> BackEnumerator()
        {
            
            CustomNode<T> current = tail;
            while (current != null)
            {
                yield return current;
                current = current.GetPrevious();
            }
        }
        public override string ToString() => String.Join(" ", this);
        public string ToStringReversed() => String.Join(" ", BackEnumerator());
    }

    public class CustomLinkedListEnumenator<T> : IEnumerator <CustomNode<T>>
    {
        CustomNode<T> next;
        public CustomLinkedListEnumenator(CustomNode<T> head)
        {
            
            next = new CustomNode<T>(head.GetValue());
            next.ChangeNext(head);
        }
        public CustomNode<T> Current { get => next; }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (next.GetNext() != null)
            {
                next = next.GetNext();
                return true;
            }
            return false;
        }

        public void Reset()
        {
            //throw new NotImplementedException();
        }
    }
    public class CustomNode<T> : IEquatable<CustomNode<T>>
    {
        private T value;
        private CustomNode<T> next;
        private CustomNode<T> previous;

        public CustomNode() { }
        public CustomNode(T? value) => ChangeValue(value);



        public void ChangeValue(T value) => this.value = value;
        public void ChangeNext(CustomNode<T>? node) { next = node; }
        public void ChangePrevious(CustomNode<T> node) { previous = node; }

        public T GetValue() => value;

        public CustomNode<T> GetNext() => next;
        public CustomNode<T> GetPrevious() => previous;

        public override string ToString() => value.ToString();
        public double ToDouble() => Convert.ToDouble(value);
        //public override bool Equals(object? obj) =>
        //    ToString() == (obj as CustomNode<T>).ToString();

        public override int GetHashCode() => value.GetHashCode();

        public bool Equals(Classwork.CustomNode<T>? other)
        {
            if (other == null || other is not CustomNode<T> node || node == null)
                return false;

            return node.value.Equals(value);
        }
    }
}
