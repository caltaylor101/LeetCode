// See https://aka.ms/new-console-template for more information
using LeetCode;


Day6 day = new Day6();

TreeNode node1 = new TreeNode(25);
TreeNode node2 = new TreeNode(56);
TreeNode node3 = new TreeNode(19, null, node1);

TreeNode node4 = new TreeNode(47, null, node2);
TreeNode node5 = new TreeNode(26, node3);
TreeNode node6 = new TreeNode(32, node5, node4);

//day.LevelOrder(node5);


Console.WriteLine(day.IsValidBST(node6));
