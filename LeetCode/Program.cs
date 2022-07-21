// See https://aka.ms/new-console-template for more information
using LeetCode;
using System.Text;

Day9 day = new Day9();


InterviewPrepQuestions inter = new InterviewPrepQuestions();

ListNode node1 = new ListNode(5);
ListNode node2 = new ListNode(4, node1);
ListNode node3 = new ListNode(3, node2);
ListNode node4 = new ListNode(2, node3);
ListNode node5 = new ListNode(1, node4);

ListNode test = inter.OddEvenList(node5);

while (test != null)
{
    Console.WriteLine(test.val);
    test = test.next;
}
