using System.Collections;

namespace CircularLinkedList
{
    public class CircularLinkedList<T> : IEnumerable<T>
    {
        Node<T>? head;
        Node<T>? tail;
        int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count ==0; } }

        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (head == null)
            {
                head = node;
                tail = node;
                tail.Next = head;
                
            }
            else
            {
                node.Next = head;
                tail.Next = node;
                tail = node;
            }
            count++;
        }

        public void Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            if (IsEmpty)
                throw new InvalidOperationException();
            do
            {
                if (current.Data.Equals(data))
                {
                    if(previous != null)
                    {
                        previous.Next = current.Next;
                        if (current == tail)
                            tail = previous;
                    }
                    else
                    { 
                        if (count == 1)
                        {
                            head = tail = null;
                        }
                        else
                        {
                            head = current.Next;
                            tail.Next = current.Next;
                        }
                    }
                    count--;
                    return;
                }
                previous = current;
                current = current.Next;

            } while (current != head);
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public bool Contains(T data)
        {
            Node<T> current = head;
            if (current == null) return false;
            do
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            while (current != head);
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
