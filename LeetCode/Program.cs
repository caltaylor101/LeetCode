// See https://aka.ms/new-console-template for more information
using LeetCode;
using System.Text;

Day9 day = new Day9();


InterviewPrepQuestions inter = new InterviewPrepQuestions();


/*
TreeNode tree5 = new TreeNode(7);
TreeNode tree4 = new TreeNode(15);
TreeNode tree3 = new TreeNode(20, tree4, tree5);
TreeNode tree2 = new TreeNode(9, tree3, null);
TreeNode tree1 = new TreeNode(3, tree2, tree3);*/

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

TreeNode node7 = new TreeNode(7);
TreeNode node6 = new TreeNode(6);
TreeNode node5 = new TreeNode(5);
TreeNode node4 = new TreeNode(4);
TreeNode node3 = new TreeNode(3, node6, node7);
TreeNode node2 = new TreeNode(2, node4, node5);
TreeNode node1 = new TreeNode(1, node2, node3);


Console.WriteLine( inter.MaxArea(new int[] { 1, 1 }));


