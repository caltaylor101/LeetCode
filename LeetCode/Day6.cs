using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{

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


        public bool IsValidBSTBFS(TreeNode root)
        {
            Queue<MyNode> q = new Queue<MyNode>();
            MyNode current = new MyNode(root, long.MinValue, long.MaxValue);
            q.Enqueue(current);

            while (q.TryDequeue(out current) && current != null)
            {
                if (current.node.val >= current.max || current.node.val <= current.min) return false;
                if (current.node.left != null)
                {
                    if (current.node.left.val < current.node.val)
                    {
                        q.Enqueue(new MyNode(current.node.left, current.min, current.node.val));
                    }
                    else return false;
                }
                if (current.node.right != null)
                {
                    if (current.node.right.val > current.node.val)
                    {
                        q.Enqueue(new MyNode(current.node.right, current.node.val, current.max));
                    }
                    else return false;
                }
            }
            return true;
        }


        public bool InOrder(TreeNode node, long min, long max)
        {
            if (node.left != null && !InOrder(node.left, min, node.val))
            {
                return false;
            }

            if (node.val >= max || node.val <= min)
            {
                return false;
            }

            if (node.right != null && !InOrder(node.right, node.val, max))
            {
                return false;
            }

            return true;
        }
        public bool IsValidBST(TreeNode root)
        {
            long min = long.MinValue;
            long max = long.MaxValue;


            return PostOrder(root, min, max);
        }

        public bool PreOrder(TreeNode node, long min, long max)
        {
            if (node.val >= max || node.val <= min)
            {
                return false;
            }

            if (node.left != null && !PreOrder(node.left, min, node.val))
            {
                return false;
            }

            if (node.right != null && !PreOrder(node.right, node.val, max))
            {
                return false;
            }

            return true;
        }
        List<int> testList = new List<int>();
        public bool PostOrder(TreeNode node, long min, long max)
        {
            if (node.left != null && !PostOrder(node.left, min, node.val))
            {
                return false;
            }
            if (node.right != null && !PostOrder(node.right, node.val, max))
            {
                return false;
            }

            if (node.val <= min || node.val >= max)
            {
                return false;
            }

            return true;
        }







    }

    public class MyNode
    {
        public TreeNode node;
        public long min;
        public long max;
        public MyNode(TreeNode node, long min = long.MinValue, long max = long.MaxValue)
        {
            this.node = node;
            this.min = min;
            this.max = max;
        }
    }

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
}



