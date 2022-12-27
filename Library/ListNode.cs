using System;
using System.Collections;
using System.Collections.Generic;

namespace WebAPI.Library
{
    public class ListNode<T> : IEnumerable, IEnumerator
    {
        private int position = -1;
        public Node<T> head;
        public Node<T> current = null;
        public ListNode()
        {
            head = null;
        }
        private bool Compare<T>(T x, T y)  //Compare Node data whether they are equal or not
        {
            return EqualityComparer<T>.Default.Equals(x, y);
        }

        //Enumerator Operation
        public IEnumerator GetEnumerator()
        {
            return this;
        }
        public bool MoveNext()
        {
            if (position + 1 < SizeOfList(head))
            {
                position++;
                return true;
            }
            return false;
        }
        public void Reset()
        {
            position = -1;
        }
        public object Current
        {
            get
            {
                int cnt = 0;
                object val = -1;
                current = head;
                while (current != null)
                {
                    if (cnt == position)
                    {
                        val = current._Data;
                        break;
                    }
                    current = current._Next;
                    cnt++;
                }
                return val;
            }
        }

        public object this[int index]   //Indexer for finding ith node using index
        {
            get
            {
                int cnt = 0;
                object val = -1;
                current = head;
                while (current != null)
                {
                    if (cnt == index)
                    {
                        val = current._Data;
                        break;
                    }
                    current = current._Next;
                    cnt++;
                }
                return val;
            }
        }

        public void AddAtStart(ListNode<T> list, T new_data)
        {
            Node<T> new_node = new Node<T>(new_data);
            if (list.head == null)
            {
                list.head = new_node;
                return;
            }
            new_node._Next = list.head;
            list.head = new_node;
            return;
        }

        public void AddAfter(Node<T> prev_node, T new_data)
        {
            if (prev_node == null)
            {
                Console.WriteLine("Previous node can't be null");
                return;
            }

            Node<T> new_node = new Node<T>(new_data);
            new_node._Next = prev_node._Next;
            prev_node._Next = new_node;
        }

        public void AddAfterNodeNumber(ListNode<T> list, int position, T new_data)
        {
            Node<T> new_node = new Node<T>(new_data);
            if (list.head == null)
            {
                list.head = new_node;
                return;
            }
            Node<T> temp = list.head;
            int cnt = 0;
            Node<T> prev_node = null;
            while (temp != null)
            {
                cnt++;
                if (cnt == position)
                {
                    prev_node = temp;
                    break;
                }
                temp = temp._Next;
            }
            if (prev_node._Next == null)
            {
                prev_node._Next = new_node;
                return;
            }
            new_node._Next = prev_node._Next;
            prev_node._Next = new_node;
        }

        public void Append(ListNode<T> list, T new_data)
        {
            Node<T> new_node = new Node<T>(new_data);
            if (list.head == null)
            {
                list.head = new_node;
                return;
            }
            Node<T> temp = list.head;
            while (temp._Next != null)
            {
                temp = temp._Next;
            }
            temp._Next = new_node;
        }

        public void RemoveStart(ListNode<T> list)
        {
            Node<T> temp = list.head;
            list.head = list.head._Next;
            return;
        }

        public void RemoveEnd(ListNode<T> list)
        {
            Node<T> temp = list.head;
            while (temp._Next._Next != null)
            {
                temp = temp._Next;
            }
            temp._Next = null;
            return;
        }

        public void RemoveFromPosition(ListNode<T> list, int position)
        {
            if (list.head == null) return;
            int total = SizeOfList(list.head);
            if (position == total)
            {
                RemoveEnd(list);
                return;
            }
            if (position == 1)
            {
                RemoveStart(list);
                return;
            }
            int cnt = 0;
            Node<T> temp = list.head;
            Node<T> prev_node = null;
            while (temp != null)
            {
                cnt++;
                if (cnt + 1 == position)
                {
                    prev_node = temp;
                    break;
                }
                temp = temp._Next;
            }
            prev_node._Next = temp._Next._Next;
            return;
        }

        public void UpdateFromPosition(ListNode<T> list, int position, T new_data)
        {
            list.AddAfterNodeNumber(list, position, new_data);
            list.RemoveFromPosition(list, position);
            return;
        }

        public bool SearchElement(ListNode<T> list, T val)
        {
            Node<T> node = list.head;
            while (node != null)
            {
                //if (node._Data == val) return true;
                if (Compare(node._Data, val) == true) return true;
                node = node._Next;
            }
            return false;
        }

        public void PrintList(ListNode<T> list)
        {
            Node<T> node = list.head;
            Console.Write("List Data : ");
            while (node != null)
            {
                Console.Write(node._Data + " ");
                node = node._Next;
            }
            Console.WriteLine();
        }

        public int SizeOfList(Node<T> node)
        {
            int cnt = 0;
            while (node != null)
            {
                cnt++;
                node = node._Next;
            }
            return cnt;
        }

        public void AddArrayAtLast(ListNode<T> list, T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Append(list, arr[i]);
            }
            return;
        }
        public void AddArrayAtStart(ListNode<T> list, T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                AddAtStart(list, arr[i]);
            }
            return;
        }

        public void ConvertListToArray(ListNode<T> list, T[] arr)
        {
            Node<T> temp = list.head;
            int id = 0;
            while (temp != null)
            {
                arr[id++] = temp._Data;
                temp = temp._Next;
            }
        }
    }
}
