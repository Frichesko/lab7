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
        if (Count == 0)
            return 0.0;

        double sum = 0;
        foreach (var value in this)
        {
            sum += value;
        }

        return sum / Count;
    }

    public double? GetFirstGreaterThanAverage()
    {
        if (Count == 0)
            return null;

        double average = GetAverage();
        foreach (var value in this)
        {
            if (value > average)
                return value;
        }

        return null;
    }

    public double GetSumGreaterThan(double targetValue)
    {
        double sum = 0;
        foreach (var value in this)
        {
            if (value > targetValue)
                sum += value;
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
        if (Count == 0)
            return result;

        double average = GetAverage();
        foreach (var value in this)
        {
            if (value < average)
                result.AddFirst(value);
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