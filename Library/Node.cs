namespace WebAPI.Library
{
    public class Node<T>
    {
        public T _Data;
        public Node<T> _Next;
        public Node() { }
        public Node(T data)
        {
            _Data = data;
            _Next = null;
        }
    }
}
