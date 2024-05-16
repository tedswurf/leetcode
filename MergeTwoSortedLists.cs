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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        var curr1 = list1;
        var curr2 = list2;
        //PrintAll(curr1);
        //PrintAll(curr2);

        // Create a fixed point head for the start of the chain. This head never changes.
        ListNode head = new ListNode(0, null);

        // Create a chain from the head. This chain moves.
        ListNode chain = head;

        // We only need to do comparison logic if we have nodes from both lists.
        while (curr1 != null && curr2 != null)
        {
            //PrintAll(head);

            var nxt1 = curr1.next;
            var nxt2 = curr2.next;

            if (curr1.val <= curr2.val)
            {
                // list1 contains the appropriate node. Add it next to the chain.
                chain.next = curr1;

                // Shift the chain pointer to the new node, then shift list1 forward.
                chain = curr1;
                curr1 = nxt1;
            }
            else
            {
                // list2 contains the appropriate node. Add it next to the chain.
                chain.next = curr2;

                // Shift the chain pointer to the new node, then shift list2 forward.
                chain = curr2;
                curr2 = nxt2;
            }
        }

        // If anyone of the lists end, we can simply tack on the remaining list, if available.
        if (curr1 != null && curr2 == null)
        {
            chain.next = curr1;
        }
        if (curr1 == null && curr2 != null)
        {
            chain.next = curr2;
        }

        // head.next points to the first actual node from both lists.
        return head.next;
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