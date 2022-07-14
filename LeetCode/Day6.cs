using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    internal class Day6
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            IList<IList<int>> outputList = new List<IList<int>>();
            List<int> upperList = new List<int>();
            List<TreeNode> lowerList = new List<TreeNode>();
            TreeNode tmp;
            q.Enqueue(root);

            while (q.TryDequeue(out tmp) && root != null)
            {
                upperList.Add(tmp.val);
                if (tmp.left != null)
                {
                    lowerList.Add(tmp.left);
                }
                if (tmp.right != null)
                {
                    lowerList.Add(tmp.right);
                }
                if (q.Count == 0)
                {
                    int[] tmpList = new int[upperList.Count];
                    upperList.CopyTo(tmpList);
                    outputList.Add(tmpList);
                    upperList.Clear();


                    foreach (TreeNode node in lowerList)
                    {
                        q.Enqueue(node);
                    }
                    lowerList.Clear();
                }
            }

            foreach (var i in outputList)
            {
                foreach (var j in i)
                {
                    Console.WriteLine(j);
                }
            }

            int hello = (int)Math.Floor((double)3 / 2);
            return outputList;
        }


        public int Search(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Count() - 1;

            if (nums == null || nums.Count() == 0) return -1;

            while (low < high)
            {
                int guess = (int)Math.Floor((double)(low + high) / 2);
                if (nums[guess] == target) return guess;
                if (nums[guess] > target) high = guess - 1;
                if (nums[guess] < target) low = guess + 1;
            }

            return -1;
        }
        int targetNumber = 4;
        public bool IsBadVersion(int n)
        {
            if (n >= targetNumber) return true;
            else return false;
        }
        public int FirstBadVersion(int n)
        {
            int low = 1;
            int high = n - 1;
            if (IsBadVersion(low)) return low;
            if (!IsBadVersion(high)) return high;

            while (low <= high)
            {
                int search = (low + high) / 2;
                if (IsBadVersion(search)) high = search - 1;
                else low = search + 1;
            }
            return low;

        }

        public bool IsValidBST2(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            TreeNode tmp = new TreeNode();
            q.Enqueue(root);
            int rootVal = root.val;

            while (q.TryDequeue(out tmp) && tmp != null)
            {
                if (tmp.left != null && tmp.left.val < tmp.val) q.Enqueue(tmp.left);
                else if (tmp.left != null && tmp.left.val >= tmp.val) return false;
                if (tmp.right != null && tmp.right.val > tmp.val) q.Enqueue(tmp.right);
                else if (tmp.left != null && tmp.right.val <= tmp.val) return false;
            }

            return true;
        }
        public bool IsValidBST(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            TreeNode lastNode = root;
            TreeNode lastlastNode = root;
            TreeNode lastlastlastNode = root;
            TreeNode currentNode = root;
            q.Enqueue(root);
            int counter = 0;

            while (q.TryDequeue(out currentNode) && currentNode != null)
            {
                if (currentNode == root)
                {
                    if (currentNode.left != null && currentNode.left.val < currentNode.val) q.Enqueue(currentNode.left);
                    else if (currentNode.left != null && currentNode.left.val >= currentNode.val) return false;
                    if (currentNode.right != null && currentNode.right.val > currentNode.val) q.Enqueue(currentNode.right);
                    else if (currentNode.right != null && currentNode.right.val <= currentNode.val) return false;
                }
                else
                {
                    if (currentNode.left != null)
                    {
                        if (currentNode.left.val >= currentNode.val) return false;
                        if (currentNode == lastlastNode.right && currentNode.left.val <= lastlastNode.val) return false;
                        if (currentNode == lastlastlastNode.right && currentNode.left.val <= lastlastlastNode.val) return false;
                        if (currentNode == lastNode.right && currentNode.left.val <= lastNode.val) return false;
                        if (currentNode.left.val < currentNode.val) q.Enqueue(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        if (currentNode.right.val <= currentNode.val) return false;
                        if (currentNode == lastlastNode.left && currentNode.right.val >= lastlastNode.val) return false;
                        if (currentNode == lastlastlastNode.left && currentNode.right.val >= lastlastlastNode.val) return false;
                        if (currentNode == lastNode.left && currentNode.right.val >= lastNode.val) return false;
                        if (currentNode.right.val > currentNode.val) q.Enqueue(currentNode.right);
                    }
                }

                lastlastlastNode = lastlastNode;
                lastlastNode = lastNode;
                lastNode = currentNode;
                counter++;
                
            }
            return true;
        }

    }
}
