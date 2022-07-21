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


ListNode node6 = new ListNode(6, node3);
ListNode node7 = new ListNode(7, node6);
ListNode node8 = new ListNode(8, node7);
ListNode node9 = new ListNode(9, node8);


TreeNode tree5 = new TreeNode(7);
TreeNode tree4 = new TreeNode(15);
TreeNode tree3 = new TreeNode(20, tree4, tree5);
TreeNode tree2 = new TreeNode(9, tree3, null);
TreeNode tree1 = new TreeNode(3, tree2, tree3);

/*TreeNode tree10 = new TreeNode(8);
TreeNode tree9 = new TreeNode(-1, null, tree10);
TreeNode tree8 = new TreeNode(6);
TreeNode tree7 = new TreeNode(1);
TreeNode tree6 = new TreeNode(5);
TreeNode tree5 = new TreeNode(3, null, tree8);
TreeNode tree4 = new TreeNode(1, tree6, tree7);
TreeNode tree3 = new TreeNode(4, tree5, tree9);
TreeNode tree2 = new TreeNode(2, tree4, null);
TreeNode tree1 = new TreeNode(0, tree2, tree3);*/


var test = inter.ZigzagLevelOrder(tree1);

foreach (var i in test)
{
    foreach (var k in i) Console.WriteLine(k);
}
