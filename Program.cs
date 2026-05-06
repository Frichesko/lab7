namespace SinglyLinkedList;
class Program
{
    static void Main()
    {
var list = new SinglyLinkedList();
        list.AddFirst(5.5d);
        list.AddFirst(3.2d);
        list.AddFirst(8.1d);
        list.AddFirst(2.1d);
        list.AddFirst(7.4d);
        list.AddFirst(4.3d);
        list.AddFirst(6.8d);

        Console.WriteLine("Створений список");
        Console.Write("Елементи: ");
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        Console.WriteLine($"Кількість: {list.Count}");
        Console.WriteLine();

        Console.WriteLine($"Середнє значення: {list.GetAverage()}");

        var greater = list.GetFirstGreaterThanAverage();
        Console.WriteLine($"Перший елемент більший за середнє значення: {(greater.HasValue ? greater.Value.ToString() : "null")}");
        Console.WriteLine();

        var targetValue = 5.0;
        Console.WriteLine($"Задане значення: {targetValue}");

        var sum = list.GetSumGreaterThan(targetValue);
        Console.WriteLine($"Сума елементів більше за задане значення: {sum}");
        Console.WriteLine();

        var lessThanAvg = list.GetLessThanAverage();
        Console.WriteLine($"Середнє значення: {list.GetAverage()}");
        Console.Write("Новий список з елементів менших за середнє значення: ");
        foreach (var item in lessThanAvg)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        Console.WriteLine();

        Console.Write("Видалення елементів що розташовані на парних позиціях ");
        Console.WriteLine();
        Console.Write("До видалення: ");
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (i % 2 == 0)
            {
                list.RemoveAt(i);
            }
        }

        Console.Write("Після видалення: ");
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

Console.WriteLine();
        Console.WriteLine("Демонстрація індексації");
        Console.WriteLine();

        var list2 = new SinglyLinkedList();
        list2.AddFirst(5.5);
        list2.AddFirst(3.2);
        list2.AddFirst(8.1);
        list2.AddFirst(2.1);
        list2.AddFirst(7.4);
        list2.AddFirst(4.3);
        list2.AddFirst(6.8);

        Console.Write("Список: ");
        foreach (var item in list2)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Зчитування елементів за індексами:");
        for (int i = 0; i < list2.Count; i++)
        {
            Console.WriteLine($"  list[{i}] = {list2[i]}");
        }

        Console.WriteLine();
        Console.WriteLine("Додавання елемента 9.9 за індексом 3:");
        list2.AddAt(3, 9.9);
        Console.Write("Список після додавання: ");
        foreach (var item in list2)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("Видалення елемента за індексом 5:");
        list2.RemoveAt(5);
        Console.Write("Список після видалення: ");
        foreach (var item in list2)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("Зчитування елементів після змін:");
        for (int i = 0; i < list2.Count; i++)
        {
            Console.WriteLine($"  list[{i}] = {list2[i]}");
        }
    }
}