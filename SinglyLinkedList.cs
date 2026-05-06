namespace SinglyLinkedList;

public class SinglyLinkedList : IEnumerable<double>
{
    private Node? _head;

    public int Count { get; private set; }

    public SinglyLinkedList()
    {
        _head = null;
        Count = 0;
    }

    public void AddFirst(double value)
    {
        var newNode = new Node(value);
        newNode.Next = _head;
        _head = newNode;
        Count++;
    }

    public void AddAt(int index, double value)
    {
        if (index < 0 || index > Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (index == 0)
        {
            AddFirst(value);
            return;
        }

        var current = _head;
        for (int i = 0; i < index - 1; i++)
            current = current?.Next;

        var newNode = new Node(value);
        newNode.Next = current?.Next;
        current!.Next = newNode;
        Count++;
    }

    public double this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            var current = _head;
            for (int i = 0; i < index; i++)
                current = current?.Next;

            return current?.Value ?? 0.0;
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        if (index == 0)
        {
            _head = _head?.Next;
            Count--;
            return;
        }

        var current = _head;
        for (int i = 0; i < index - 1; i++)
            current = current?.Next;

        current!.Next = current.Next?.Next;
        Count--;
    }

    public double GetAverage()
    {
        if (_head == null)
            return 0.0;

        double sum = 0;
        var current = _head;
        while (current != null)
        {
            sum += current.Value;
            current = current.Next;
        }

        return sum / Count;
    }

    public double? GetFirstGreaterThanAverage()
    {
        if (_head == null)
            return null;

        double average = GetAverage();
        var current = _head;
        while (current != null)
        {
            if (current.Value > average)
                return current.Value;
            current = current.Next;
        }

        return null;
    }

    public double GetSumGreaterThan(double targetValue)
    {
        double sum = 0;
        var current = _head;
        while (current != null)
        {
            if (current.Value > targetValue)
                sum += current.Value;
            current = current.Next;
        }

        return sum;
    }

    public void RemoveEvenIndexElements()
    {
        for (int i = Count - 1; i >= 0; i--)
        {
            if (i % 2 == 0)
            {
                RemoveAt(i);
            }
        }
    }
    public SinglyLinkedList GetLessThanAverage()
    {
        var result = new SinglyLinkedList();
        if (_head == null)
            return result;

        double average = GetAverage();
        var current = _head;
        while (current != null)
        {
            if (current.Value < average)
                result.AddFirst(current.Value);
            current = current.Next;
        }

        return result;
    }

    public IEnumerator<double> GetEnumerator()
    {
        var current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}