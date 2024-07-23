using System;

namespace Week04Code
{
    public class Program
    {
        public static void Main()
        {
            LinkedList list = new LinkedList();
            list.InsertTail(1);
            list.InsertTail(2);
            list.InsertTail(3);
            list.PrintList(); // Expected output: 1 -> 2 -> 3 -> null

            list.RemoveTail();
            list.PrintList(); // Expected output: 1 -> 2 -> null

            list.Remove(2);
            list.PrintList(); // Expected output: 1 -> null

            list.InsertHead(2);
            list.InsertHead(2);
            list.Replace(2, 4);
            list.PrintList(); // Expected output: 4 -> 4 -> 1 -> null

            foreach (var item in list.Reverse())
            {
                Console.WriteLine(item); // Expected output: 1 4 4
            }
        }
    }
}
