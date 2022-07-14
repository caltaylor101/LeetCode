using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Day8
    {

        public TreeNode LowestCommonAncestorBFS(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode current = root;
            Queue<TreeNode> treeQueue = new Queue<TreeNode>();
            treeQueue.Enqueue(current);
            TreeNode swapLowest;

            if (p.val > q.val)
            {
                swapLowest = p;
                p = q;
                q = swapLowest;
            }

            while(treeQueue.TryDequeue(out current) && current != null)
            {
                if (p.val < current.val && q.val > current.val)
                {
                    return current;
                }
                else if (p.val == current.val || q.val == current.val)
                {
                    return current;
                }
                else if (p.val < current.val)
                {
                    treeQueue.Enqueue(current.left);
                }
                else
                {
                    treeQueue.Enqueue(current.right);
                }
            }
            return current;
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode current = root;
            Queue<TreeNode> treeQueue = new Queue<TreeNode>();
            treeQueue.Enqueue(current);
            TreeNode swapLowest;

            if (p.val > q.val)
            {
                swapLowest = p;
                p = q;
                q = swapLowest;
            }

            return InOrder(current, p, q);
        }

        public TreeNode InOrder(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p.val < root.val && q.val < root.val)
            {
                InOrder(root.left, p, q);
            }

            if (p.val > root.val && q.val > root.val)
            {
                InOrder(root.right, p, q);
            }

            if (p.val == root.val || q.val == root.val)
            {
                return root;
            }

            return root;
        }


    }
}
