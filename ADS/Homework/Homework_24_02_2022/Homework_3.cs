using DeeULib;
using Programming.Classwork;
namespace ADS.Homework.Homework_24_02_2022;

public static class Homework_3
{
    public static void SwapElements(this DoublyLinkedList<int> linkedList)
    {
        var even = linkedList.Where((node, index) => (index + 1) % 2 == 0).Select(x => x).ToList();
        var odd = linkedList.Where((node, index) => (index + 1) % 2 != 0).Select(x => x).ToList();

        var result = new DoublyLinkedList<int>();
        
        foreach (var el in odd)
        {
            el.ChangeNext(null);
            el.ChangePrevious(null);
        }
        foreach (var el in even)
        {
            el.ChangeNext(null);
            el.ChangePrevious(null);
        }

        for (var i = 0; i < linkedList.Count; i++)
        {
            if(even.Count != 0)
            {
                result.Add(even.First());
                even.RemoveAt(0);
            }
            if(odd.Count != 0)
            {
                result.Add(odd.First());
                odd.RemoveAt(0);
            }
        }

        linkedList.head = result.head;
    }
}