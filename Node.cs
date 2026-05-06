namespace SinglyLinkedList;

public class Node
{
    public double Value { get; set; }
    public Node? Next { get; set; }

    public Node(double value)
    {
        Value = value;
        Next = null;
    }
}