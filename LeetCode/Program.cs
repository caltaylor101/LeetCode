// See https://aka.ms/new-console-template for more information
using LeetCode;
using System.Text;

Day9 day = new Day9();
/*
TreeNode node1 = new TreeNode(25);
TreeNode node2 = new TreeNode(56);
TreeNode node3 = new TreeNode(19, null, node1);

TreeNode node4 = new TreeNode(47, null, node2);
TreeNode node5 = new TreeNode(26, node3);
TreeNode node6 = new TreeNode(32, node5, node4);*/

//day.LevelOrder(node5);


/*int[][] image = new int[][] {
    new int[] { 1, 1, 1 },
    new int[] { 1, 1, 0 },
    new int[] { 1, 0, 1 }
};*/
/*int[][] image = new int[][] {
    new int[] { 0,0,0 },
    new int[] { 0,1,0 }
};
*/
/*int[][] image = new int[][]
{
    new int[] {0,0,0},
    new int[] {0,0,0}
};*/

/*char[][] islandLands = new char[][]
{
    new char[] {'1','1','1', '0','0'},
    new char[] {'0','0','0', '1','1'},
    new char[] {'0','0','0', '0','0'},
    new char[] {'0','1','0', '0','0'}
};

Console.WriteLine(day.NumIslands(islandLands));*/

DataStructures data = new DataStructures();
const int m = 3;
const int n = 3;
/*int[] nums1 = new int[m + n] { 4, 5, 6, 0, 0, 0 };
int[] nums2 = new int[] { 1, 2, 3 };*/
int[] nums1 = new int[] { 1,2,2,1};
int[] nums2 = new int[] { 2,2 };

InterviewPrepQuestions inter = new InterviewPrepQuestions();
/*
ListNode node1 = new ListNode(3);
ListNode node2 = new ListNode(4, node1);
ListNode head = new ListNode(2, node2);

ListNode node5 = new ListNode(9);
ListNode node3 = new ListNode(4);
ListNode node4 = new ListNode(6, node3);
ListNode head2 = new ListNode(5, node4);*/


/*ListNode node1 = new ListNode(1);
ListNode node2 = new ListNode(0, node1);
ListNode node3 = new ListNode(0, node2);
ListNode node4 = new ListNode(0, node3);
ListNode node5 = new ListNode(0, node4);
ListNode node6 = new ListNode(0, node5);
ListNode node7 = new ListNode(0, node6);
ListNode node8 = new ListNode(0, node7);
ListNode node9 = new ListNode(0, node8);
ListNode node10 = new ListNode(0, node9);
ListNode node11 = new ListNode(0, node10);
ListNode node12 = new ListNode(0, node11);
ListNode node13 = new ListNode(0, node12);
ListNode node14 = new ListNode(0, node13);
ListNode node15 = new ListNode(0, node14);
ListNode node16 = new ListNode(0, node15);
ListNode node17 = new ListNode(0, node16);
ListNode node18= new ListNode(0, node17);
ListNode node19= new ListNode(0, node18);
ListNode node20= new ListNode(0, node19);
ListNode node21= new ListNode(0, node20);
ListNode node22= new ListNode(0, node21);
ListNode node23= new ListNode(0, node22);
ListNode node24= new ListNode(0, node23);
ListNode node25= new ListNode(0, node24);
ListNode node26= new ListNode(0, node25);
ListNode node27= new ListNode(0, node26);
ListNode node28= new ListNode(9, node27);
ListNode node29= new ListNode(9, node28);
ListNode node30= new ListNode(0, node29);

ListNode head = new ListNode(1, node30);

ListNode node31 = new ListNode(9);
ListNode node32 = new ListNode(6, node31);
ListNode head2 = new ListNode(5, node32);*/
/*

ListNode node1 = new ListNode(9);
ListNode node2 = new ListNode(9, node1);
ListNode node3 = new ListNode(9, node2);
ListNode node4 = new ListNode(9, node3);
ListNode node5 = new ListNode(9, node4);
ListNode node6 = new ListNode(9, node5);
ListNode head = new ListNode(9, node6);

ListNode node7 = new ListNode(9);
ListNode node8 = new ListNode(9, node7);
ListNode node9 = new ListNode(9, node8);
ListNode head2 = new ListNode(9, node9);*/


/*ListNode head = new ListNode(5);
ListNode head2 = new ListNode(5);*/
/*
char[][] grid = new char[][]
{
  new char[] {'1', '1', '1', '1', '0' },
  new char[] {'1', '1', '0', '1', '0' },
  new char[] {'1', '1', '0', '0', '0' },
  new char[] {'0', '0', '1', '0', '1' }
};*/
/*
char[][] grid = new char[][]
{
  new char[] {'1', '1', '1' },
  new char[] {'0', '1', '0'},
  new char[] {'1', '1', '1'}
};
string temp = "ac";
*/

Node node1 = new Node(1, null);
Node node2 = new Node(10, node1);
Node node3 = new Node(11, node2);
Node node4 = new Node(13, node3);
Node node5 = new Node(7, node4);

node1.random = node5;
node2.random = node3;
node3.random = node1;
node4.random = node5;
node5.random = null;
node5.next = node4;


Node copyListHead = inter.CopyRandomList(node5);


Console.WriteLine("copylisthead current val " + copyListHead.next.next.val);
Console.WriteLine("copylisthead next " + copyListHead.next.next.next.val);
if (copyListHead.next.next.random == null)
{
    Console.WriteLine("random is null ");
}
else
{
    Console.WriteLine("copylisthead random val " + copyListHead.next.next.random.val);
}

Console.WriteLine();
Console.WriteLine("node5 current val " + node5.next.next.val);
Console.WriteLine("node5 next val" + node5.next.next.next.val);
if (node5.next.next.random == null)
{
    Console.WriteLine("random node 5 is null");
}
else
{
    Console.WriteLine("node5 random val " + node5.next.next.random.val);
}



