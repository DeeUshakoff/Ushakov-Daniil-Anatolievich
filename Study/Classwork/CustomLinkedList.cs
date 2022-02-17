using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Classwork
{
    public class CustomLinkedList<T>
    {
        public CustomNode<T> head;
        public CustomLinkedList(T value) => head = new CustomNode<T>(value);
        public CustomLinkedList(CustomNode<T> node) => head = node;
        public void AddFirst(CustomNode<T> node)
        {
            node.ChangeNext(head);
            head = node;
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
        }
        
        public void AddAfter(CustomNode<T> node, int index)
        {
            if(index < 1) throw new ArgumentOutOfRangeException("index");
            if (index == 1) 
            {
                AddFirst(node);
                return; 
            }
            var headCopy = head;

            for(int i = 1; i <= index - 2; i++)
            {

            }


        }
        public void AddBefore(CustomNode<T> node)
        {

        }
        public CustomNode<T> GetFirst() => head;

        public override string ToString()
        {
            var headCopy = head;
            StringBuilder result = new StringBuilder();

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

    public class CustomLinkedListEnumenator<T> : IEnumerator <CustomNode<T>>
    {
        CustomNode<T> next;
        public CustomLinkedListEnumenator(CustomNode<T> head)
        {
            next = new CustomNode<T>(head.GetValue());
            next.ChangeNext(head);
        }
        public CustomNode<T> Current
        {
            get
            {
                return next;
            }
        }

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
    public class CustomNode<T>
    {
        private T value;
        private CustomNode<T> next;
        private CustomNode<T> previous;
        

        public CustomNode(T value) => ChangeValue(value);

        public void ChangeValue(T value) => this.value = value;
        public void ChangeNext(CustomNode<T> node) => next = node;
        public void ChangePrevious(CustomNode<T> node) => previous = node;

        public T GetValue() => value;

        


        public CustomNode<T> GetNext() => next;
        public CustomNode<T> GetPrevious() => previous;

        public override string ToString() => value.ToString();
        public double ToDouble() => Convert.ToDouble(value);
        public override bool Equals(object? obj) =>
            ToString() == (obj as CustomNode<T>).ToString();

        public override int GetHashCode() => value.GetHashCode(); 
    }

   
}
