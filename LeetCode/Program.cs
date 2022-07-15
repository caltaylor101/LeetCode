// See https://aka.ms/new-console-template for more information
using LeetCode;


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
int[] nums1 = new int[] { 4,5,6,0,0,0 };
int[] nums2 = new int[] { 1,2,3 };

data.Merge3(nums1, m, nums2, n);


