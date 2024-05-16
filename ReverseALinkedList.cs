/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseList(ListNode head) {
        var queue = new Queue<ListNode>();

        while (head != null)
        {
            queue.Enqueue(head);
            head = head.next;
            //Console.WriteLine($"{string.Join(",",queue.Select(x => x.val))}");
        }

        ListNode next = null;
        while (queue.Count > 0)
        {
            var top = queue.Dequeue();
            head = new ListNode(top.val, next);
            next = head;
            //PrintAll(head);
        }

        return head;
    }

    private void PrintAll(ListNode head)
    {
        if (head == null)
        {
            return;
        }
        var str = head.val.ToString();
        head = head.next;

        while (head != null)
        {
            str = str + $",{head?.val}";
            head = head.next;
        }

        Console.WriteLine(str);
    }
}



/*
The more optimal solution is to reverse the pointers as we visit each node.
*/
public class Solution {
    public ListNode ReverseList(ListNode head) {
        ListNode prev = null;
        ListNode curr = head;

        // PrintAll(head);

        while (curr != null)
        {
            var nxt = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nxt;
        }

        // PrintAll(prev);

        return prev;
    }

    private void PrintAll(ListNode head)
    {
        if (head == null)
        {
            return;
        }
        var str = head.val.ToString();
        head = head.next;

        while (head != null)
        {
            str = str + $">{head?.val}";
            head = head.next;
        }

        Console.WriteLine(str);
    }
}