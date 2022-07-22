using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode
{


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    // Definition for a Node.
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
    /*
        public class MyNode
        {
            public int val;
            public MyNode next;
            public Node random;

            public MyNode(int _val, MyNode next = null, MyNode random = null)
            {
                val = _val;
                next = null;
                random = null;
            }
        }*/

    /*  public class TreeNode {
          public int val;
          public TreeNode left;
          public TreeNode right;
          public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
              this.val = val;
              this.left = left;
              this.right = right;
          }
      }*/
    internal class InterviewPrepQuestions
    {
        public int MaxArea(int[] height)
        {
            int sumVolume = 0;
            int maxVolume = 0;
            int startIndex = 0;
            int endIndex = height.Length - 1;
            int prevMaxStartValue = height[startIndex];
            int prevMaxEndValue = height[endIndex];

            maxVolume = Math.Max(maxVolume, ((endIndex - startIndex) * Math.Min(height[startIndex], height[endIndex])));

            while (startIndex <= endIndex)
            {
                if (prevMaxStartValue < height[startIndex])
                {
                    sumVolume = (endIndex - startIndex) * Math.Min(height[startIndex], height[endIndex]);
                    prevMaxStartValue = height[startIndex];
                }
                if (prevMaxEndValue < height[endIndex])
                {
                    sumVolume = (endIndex - startIndex) * Math.Min(height[startIndex], height[endIndex]);
                    prevMaxEndValue = height[endIndex];
                }
                if (height[startIndex] <= height[endIndex]) startIndex++;
                else endIndex--;
                if (sumVolume > maxVolume) maxVolume = sumVolume;
            }

            return maxVolume;
        }

        public int MaxArea3(int[] height)
        {
            int sumVolume = 0;
            int maxVolume = 0;
            int startIndex = 0;
            int endIndex = height.Length - 1;
            int prevMaxStartValue = height[startIndex];
            int prevMaxEndValue = height[endIndex];

            maxVolume = Math.Max(maxVolume, ((endIndex - startIndex) * Math.Min(height[startIndex], height[endIndex])));

            while (startIndex <= endIndex)
            {
                if (prevMaxStartValue < height[startIndex])
                {
                    if (height[startIndex] <= height[endIndex]) sumVolume = (endIndex - startIndex) * height[startIndex];
                    else sumVolume = (endIndex - startIndex) * height[endIndex];

                    prevMaxStartValue = height[startIndex];
                }
                if (prevMaxEndValue < height[endIndex])
                {
                    if (height[startIndex] <= height[endIndex]) sumVolume = (endIndex - startIndex) * height[startIndex];
                    else sumVolume = (endIndex - startIndex) * height[endIndex];
                }
                if (height[startIndex] <= height[endIndex]) startIndex++;
                else endIndex--;
                if (sumVolume > maxVolume) maxVolume = sumVolume;
            }

            return maxVolume;
        }
        public int MaxArea2(int[] height)
        {
            //Variable to return that records our maxVolume
            int maxVolume = 0;
            int startIndex = 0;
            int endIndex = height.Length - 1;

            //Sandwich the answer in. 
            while (startIndex <= endIndex)
            {
                //We put the calculation we came up with to compare it against the maxVolume.
                //If the next iteration is greater than the maxVolume, we record the new value. 
                //From the start example, ((8 - 1) * Math.Min(8, 7)).
                maxVolume = Math.Max(maxVolume, ((endIndex - startIndex) * Math.Min(height[startIndex], height[endIndex])));
                //Whichever value is smaller, we traverse that index. 
                //If the start value is smaller, we find a bigger one by moving it up.
                //If the endIndex is smaller than the startIndex, then we move it down to find a larger value.
                //This way, we are alwasys finding the furthest maximum values from each other. 
                if (height[startIndex] <= height[endIndex]) startIndex++;
                else endIndex--;
            }
            //Return what we found.
            return maxVolume;
        }


        public Node Connect(Node root)
        {
            //check for initial null cases
            if (root == null) return null;
            if (root.left == null) return root;

            //check if the left node exists so we can traverse down the tree.
            if (root.left != null)
            {
                //every left node should point to the right node.
                root.left.next = root.right;
                //Make sure root.next isn't null.
                //We can access the left node from here to fulfill the space complexity requirement.
                //If root.next is null, then we are at the edge of our tree and the right node will be null.
                if (root.next != null) root.right.next = root.next.left;
                
            }
            //Return null when the tree has been traversed. 
            else return null;

            //Recurse the logic on both branches.
            Connect(root.left);
            Connect(root.right);
            return root;
        }

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            var n = preorder.Length;
            if (n == 0) return null;

            return DFS(preorder, 0, n - 1, inorder, 0, n - 1);
        }

        private TreeNode DFS(int[] preorder, int preLeft, int preRight, int[] inorder, int inLeft, int inRight)
        {
            if (preLeft > preRight) return null;

            var rootValue = preorder[preLeft];
            var rootInIndex = -1;

            for (int i = inLeft; i <= inRight; i++)
            {
                if (inorder[i] == rootValue)
                {
                    rootInIndex = i;
                    break;
                }
            }

            var count = rootInIndex - inLeft;

            var root = new TreeNode(rootValue);

            root.left = DFS(preorder, preLeft + 1, preLeft + count, inorder, inLeft, rootInIndex - 1);
            root.right = DFS(preorder, preLeft + count + 1, preRight, inorder, rootInIndex + 1, inRight);

            return root;
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            //Initialize both lists
            IList<IList<int>> returnList = new List<IList<int>>();
            IList<int> intList = new List<int>();
            // check for null root
            if (root == null) return returnList;
            // use two stacks to traverse the tree
            Stack<TreeNode> stack1 = new Stack<TreeNode>();
            Stack<TreeNode> stack2 = new Stack<TreeNode>();
            //Initialize the stack with the root
            stack1.Push(root);
            //currentNode will take each node from the stack
            TreeNode currentNode;

            //We won't be done till both stacks are empty. 
            while (stack1.Count > 0 || stack2.Count > 0)
            {
                //TryPop returns a boolean. So if nothing is in the stack, it will return false.
                //If there is something in the stack, it assigns it to currentNode.
                while(stack1.TryPop(out currentNode))
                {
                    //Add the currentNode to the list, as it will be deleted when the loop resets.
                    intList.Add(currentNode.val);
                    //Moves left to right through the tree
                    if (currentNode.left != null) stack2.Push(currentNode.left);
                    if (currentNode.right != null) stack2.Push(currentNode.right);
                }

                //If there is something in the intList, add it to our return list.
                //If the left and right node are null, then we will add a blank list here.
                if (intList.Count != 0) returnList.Add(intList);
                //Get a fresh list.
                intList = new List<int>();

                while (stack2.TryPop(out currentNode))
                {
                    intList.Add(currentNode.val);
                    //Move right to left now, as we are going the opposite direction down the tree because we are on the next level.
                    if (currentNode.right != null) stack1.Push(currentNode.right);
                    if (currentNode.left != null) stack1.Push(currentNode.left);
                }
                if (intList.Count != 0) returnList.Add(intList);
                intList = new List<int>();
            }
            return returnList;
        }
        public IList<IList<int>> ZigzagLevelOrder3(TreeNode root)
        {
            IList<IList<int>> returnList = new List<IList<int>>();
            IList<int> intList = new List<int>();
            if (root == null) return returnList;
            bool q1Traverse = true;
            bool q2Traverse = false;
            Stack<TreeNode> q1 = new Stack<TreeNode>();
            Stack<TreeNode> q2 = new Stack<TreeNode>();
            q1.Push(root);
            intList = new List<int>();
            TreeNode currentNode;
            while (q1.Count > 0 || q2.Count > 0)
            {
                if (q1Traverse && q1.TryPop(out currentNode))
                {
                    intList.Add(currentNode.val);
                    if (currentNode.left != null)
                    {
                        q2.Push(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        q2.Push(currentNode.right);
                    }
                }
                if (q2Traverse && q2.TryPop(out currentNode))
                {
                    intList.Add(currentNode.val);
                    if (currentNode.right != null)
                    {
                        q1.Push(currentNode.right);
                    }
                    if (currentNode.left != null)
                    {
                        q1.Push(currentNode.left);
                    }
                }
                if (q1.Count == 0 && q1Traverse)
                {
                    if (intList != null && intList.Count > 0) returnList.Add(intList);

                    intList = new List<int>();
                    q1Traverse = false;
                    q2Traverse = true;
                }
                if (q2.Count == 0 && q2Traverse)
                {
                    if (intList != null && intList.Count > 0) returnList.Add(intList);
                    intList = new List<int>();
                    q1Traverse = true;
                    q2Traverse = false;
                }
            }
            return returnList;
        }
        public IList<IList<int>> ZigzagLevelOrder2(TreeNode root)
        {
            IList<IList<int>> zigList = new List<IList<int>>();
            IList<int> zagIntList = new List<int>();
            if (root == null) return zigList;
            bool q1Traverse =true;
            bool q2Traverse = false;
            Queue<TreeNode> q1 = new Queue<TreeNode>();
            Stack<TreeNode> q2 = new Stack<TreeNode>();
            q1.Enqueue(root);
            zagIntList.Add(root.val);
            zigList.Add(zagIntList);
            zagIntList = new List<int>();
            TreeNode currentNode;



            while (q1.Count > 0 || q2.Count > 0)
            {
                if (q1Traverse && q1.TryDequeue(out currentNode))
                {
                    if (currentNode.right != null)
                    {
                        q2.Push(currentNode.right);
                        zagIntList.Add(currentNode.right.val);
                    }
                    if (currentNode.left != null)
                    {
                        q2.Push(currentNode.left);
                        zagIntList.Add(currentNode.left.val);
                    }
                }
                if (q2Traverse && q2.TryPop(out currentNode))
                {
                    if (currentNode.left != null)
                    {
                        q1.Enqueue(currentNode.left);
                        zagIntList.Add(currentNode.left.val);
                    }
                    if (currentNode.right != null)
                    {
                        q1.Enqueue(currentNode.right);
                        zagIntList.Add(currentNode.right.val);
                    }
                }
                if (q1.Count == 0 && q1Traverse)
                {
                    if(zagIntList != null && zagIntList.Count > 0) zigList.Add(zagIntList);

                    zagIntList = new List<int>();
                    q1Traverse = false;
                    q2Traverse = true;
                }
                if (q2.Count == 0 && q2Traverse)
                {
                    if (zagIntList != null && zagIntList.Count > 0) zigList.Add(zagIntList);
                    zagIntList = new List<int>();
                    q1Traverse = true;
                    q2Traverse = false;
                }
            }
            return zigList;
        }


        private IList<int> list = new List<int>();
        public IList<int> InorderTraversal(TreeNode root)
        {

            if (root.left != null)
            {
                InorderTraversal(root.left); 
            }

            list.Add(root.val);

            if (root.right != null)
            {
                InorderTraversal(root.right);
            }

            return list;
        }
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            // HashSet that will track all unique nodes
            HashSet<ListNode> set = new HashSet<ListNode>();

            while(headA != null || headB != null)
            {
                if (headA != null)
                {
                    // tries to add the node to the set, if it exists then we know this is our intersection.
                    if(!set.Add(headA))
                    {
                        return headA;
                    }
                    //traverse through the first list
                    headA = headA.next;

                }
                if (headB != null)
                {
                    if(!set.Add(headB))
                    {
                        return headB;
                    }
                    //traverse through the second list
                    headB = headB.next;
                }
            }

            //return null if both lists don't have an intersection.
            return null;
        }

        public ListNode OddEvenList(ListNode head)
        {
            if (head == null) return null;
            //Instantiates our first even node.
            ListNode evenCurrent = head.next;
            //A way to reference our even list
            ListNode evenHead = evenCurrent;
            //Instantiates our first odd node
            ListNode oddCurrent = head;
            //At the end of the traversal we can attach the even head to oddTail.next
            ListNode oddTail;

            //I did a while true here, which could also be moved as:
            // while (oddCurrent.next != null || evenCurrent.next !=null)
            // Then remove the if statement, and have oddTail = oddCurrent after the while loop.
            while(true)
            {
                if (oddCurrent.next == null || evenCurrent.next == null)
                {
                    //When either of those are null, the list has stopped traversing.
                    // We assign the oddTail to the last odd node in the list.
                    oddTail = oddCurrent;
                    break;
                }
                oddCurrent.next = evenCurrent.next;
                evenCurrent.next = oddCurrent.next.next;
                oddCurrent = oddCurrent.next;
                evenCurrent = evenCurrent.next;
            }
            //point the oddTail to the evenHead.
            oddTail.next = evenHead;
            //return the original head.
            return head;
        }

        public int MyAtoi(string s)
        {
            if (String.IsNullOrEmpty(s)) return 0;


            bool isPositive = true;
            bool operatorTriggered = false;
            bool digitsTriggered = false;
            StringBuilder digits = new StringBuilder();
            int returnInt;


            foreach(char c in s)
            {
                // if a whitespace happens after the triggers, then break the loop
                if ((digitsTriggered || operatorTriggered) && char.IsWhiteSpace(c)) break;
                // if there is a leading whitespace, reset the loop
                if (char.IsWhiteSpace(c)) continue;

                    switch (c)
                    {
                        case '-':
                            if (digitsTriggered) break;
                            // check if operator has been set, if not, set the operator and reset loop
                            if (!operatorTriggered)
                            {
                                isPositive = false;
                                operatorTriggered = true;
                                continue;
                            }
                            else break;
                        case '+':
                            if (digitsTriggered) break;
                            // check if operator has been set, if not, set the operator and reset loop
                            if (!operatorTriggered)
                            {
                                isPositive = true;
                                operatorTriggered = true;
                                continue;
                            }
                            else break;
                            //Regex expression to find any digit and add it to a string.
                        case var digit when new Regex(@"^[0-9]+$").IsMatch(digit.ToString()):
                            digits.Append(digit);
                            digitsTriggered = true;
                            continue;
                        default:
                            break;
                    }
                    break;
            };

            //Make sure our digits string isn't null or empty.
            if (String.IsNullOrEmpty(digits.ToString())) return 0;

            //Try catch blocks to see if it is outside the integer range.
            //If it fails to convert to an int at this stage, then we know it is outside of the range.
            try
            {
                returnInt = Convert.ToInt32(digits.ToString());
            }
            catch
            {
                if (isPositive)
                {
                    returnInt = int.MaxValue;
                }
                else
                {
                    returnInt = int.MinValue;
                }
            }

            //Ternary operator to make the integer + or - on return
            return (isPositive) ? returnInt: -returnInt;
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] nums3 = new int[nums1.Length + nums2.Length];
            nums1.CopyTo(nums3, 0);
            nums2.CopyTo(nums3, nums1.Length);
            Array.Sort(nums3);
            

            if (nums3.Length % 2 == 0)
            {
                int median1 = nums3.Length;
                int median21 = median1 / 2;
                int median22 = median1/2 -1;

                double median2 = Convert.ToDouble(nums3[median21]);
                double median3 = Convert.ToDouble(nums3[median22]);
                return ((median2 + median3) / 2);
            }
            else
            {
                return nums3[nums3.Length / 2];
            }

            return 0f;
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode head = new ListNode();
            ListNode current = head;
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            while (list1 != null || list2 != null)
            {
                if (list1?.val <= list2?.val || list2 == null)
                {
                    current.next = list1;
                    current = current.next;
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;
                    current = current.next;
                    list2 = list2.next;
                }
            }
            return head.next;
        }
        public int MaxProfit(int[] prices)
        {
            int low = prices[0];
            int sum = 0;
            int max = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < low) low = prices[i];
                max = Math.Max(max, prices[i] - low);
            }

            return max;
        }
        public Node CopyRandomList(Node head)
        {
            // take care of the null case
            if (head == null) return head;
            // The new node we create to traverse our copy list.
            Node copyNode;
            // This gets our main list's head so we can traverse through it multiple times.
            Node currentNode = head;
            // The currentCopyNode is initialized here. 
            // This is going to be the exact copy of currentNode.
            Node currentCopyListNode = new Node(head.val);
            // This keeps our reference to the head of our copy list so we can access our list.
            Node returnHead = currentCopyListNode;
            // This keeps our references to each object.
            Dictionary<Node, Node> nodeDict = new Dictionary<Node, Node>();

            // Loop through the main list to create a copy of val and next to our new list.
            while (currentNode != null)
            {
                // We need to check if the next one is null.
                // Creating this next copy allows us to traverse with our copy list
                if (currentNode.next != null)
                {
                    copyNode = new Node(currentNode.next.val);
                }
                else
                {
                    copyNode = null;
                }

                // We can now assign currentCopyListNode.next to our newly created noce.
                // This is now a complete node, aside from the random property
                currentCopyListNode.next = copyNode;

                // Now we make a reference to these nodes.
                // Dictionary allows us a reference to the objects.
                nodeDict.Add(currentNode, currentCopyListNode);
                
                // Then we traverse to the next node and continue copying
                currentNode = currentNode.next;
                currentCopyListNode = currentCopyListNode.next;
            }
            // At this point we have 2 identical lists aside from the random node. 
            // we reset both to the head so we can traverse both lists again. 
            currentNode = head;
            currentCopyListNode = returnHead;

            // this while loop traverses both lists and adds the randomNode to our copied list.
            /*while (currentNode != null)
            {
                // Check if random is null, otherwise an error will occur trying to access the dictionary.
                if (currentNode.random != null)
                {
                    // We look up the main list's node in the dictionary and assign it to our currentCopyListNode's random property.
                    currentCopyListNode.random = nodeDict[currentNode.random];
                }
                else
                {
                    currentCopyListNode.random = null;
                }
                currentNode = currentNode.next;
                currentCopyListNode = currentCopyListNode.next;
            }*/

            // return the head of our new list.
            return returnHead;
        }


        public string LongestPalindrome(string s)
        {
            int preIndex = 0;
            int currentIndex = 1;
            int postIndex = 2;
            int biggestCount = 0;
            int[] bestValues = new int[] { };
            StringBuilder returnString = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                preIndex = i - 1;
                postIndex = i + 1;
                if (postIndex < s.Length && s[postIndex] == s[i])
                {
                    preIndex = i;
                    postIndex = i + 1;
                    while(preIndex >= 0 && postIndex < s.Length)
                    {
                        if (s[preIndex] == s[postIndex])
                        {
                            preIndex--;
                            postIndex++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    preIndex++;
                    postIndex--;
                    if (postIndex - preIndex > biggestCount)
                    {
                        biggestCount = postIndex - preIndex;
                        bestValues = new int[] { preIndex, postIndex };
                    }
                }
                preIndex = i - 1;
                postIndex = i + 1;
                if (preIndex >= 0 && postIndex < s.Length && (s[preIndex] == s[postIndex]))
                {
                    while (preIndex >= 0 && postIndex < s.Length)
                    {
                        if (s[preIndex] == s[postIndex])
                        {
                            preIndex--;
                            postIndex++;
                        }
                        else break;
                    }
                    preIndex++;
                    postIndex--;
                    if (postIndex - preIndex > biggestCount)
                    {
                        biggestCount = postIndex - preIndex;
                        bestValues = new int[] { preIndex, postIndex };
                    }
                }
            }
            if (biggestCount == 0) return s[0].ToString();
            for (int i = bestValues[0]; i <= bestValues[1]; i++)
            {
                returnString.Append(s[i]);
            }
            return returnString.ToString();
        }

            /*public string LongestPalindrome(string s)
            {
                int preIndex = 0;
                int currentIndex = 1;
                int postIndex = 2;
                StringBuilder check = new StringBuilder();
                string longP = "";
                string returnString = "";
                if (s.Length == 1) return s;
                if (s.Length < 3)
                {
                    if (s[0] == s[1])
                    {
                        return s;
                    }
                    else
                    {
                        return s[0].ToString();
                    }
                }
                if (s.Length < 4)
                {
                    if (s[0] == s[2])
                    {
                        return s;
                    }
                    if (s[0] == s[1])
                    {
                        return s.Substring(0, 2);
                    }
                    if (s[1] == s[2])
                    {
                        return s.Substring(1, 2);
                    }

                    else return s[0].ToString();
                }


                while (currentIndex < s.Length)
                {
                    preIndex = currentIndex - 1;
                    postIndex = currentIndex + 1;
                    if (currentIndex + 1 < s.Length - 1 && s[currentIndex] == s[postIndex])
                    {
                        preIndex = currentIndex;
                        postIndex = currentIndex + 1;
                        while(preIndex >= 0 && postIndex < s.Length)
                        {
                            if (s[preIndex] == s[postIndex])
                            {
                                preIndex--;
                                postIndex++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        preIndex++;
                        for (int i = preIndex; i < postIndex; i++)
                        {
                            check.Append(s[i]);
                        }
                        if (check.Length > returnString.Length) returnString = check.ToString();
                        check.Clear();
                    }
                    preIndex = currentIndex - 1;
                    postIndex = currentIndex + 1; 
                    if (postIndex < s.Length && s[preIndex] == s[postIndex])
                    {
                        while (preIndex >= 0 && postIndex < s.Length)
                        {
                            if (s[preIndex] == s[postIndex])
                            {
                                preIndex--;
                                postIndex++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        preIndex++;
                        for (int i = preIndex; i < postIndex; i++)
                        {
                            check.Append(s[i]);
                        }
                        if (check.Length > returnString.Length) returnString = check.ToString();
                        check.Clear();
                    }
                    currentIndex++;
                }
                if (returnString == "") return s[0].ToString();
                return returnString;
            }*/

            public bool IsValid(string s)
        {
            Stack<char> q = new Stack<char>();
            char tmp;
            
            foreach (char i in s)
            {
                switch (i)
                {
                    case '{':
                        q.Push(i);
                        break;

                    case '(':
                        q.Push(i);
                        break;
                    case '[':
                        q.Push(i);
                        break;
                    case '}':
                        if (q.Count == 0) return false;
                        if (q.Pop() != '{') return false;
                        break;
                    case ')':
                        if (q.Count == 0) return false;
                        if (q.Pop() != '(') return false;
                        break;
                    case ']':
                        if (q.Count == 0) return false;
                        if (q.Pop() != '[') return false;
                        break;
                }
            }
            if (q.Count != 0) return false;
            return true;
        }

        private int islandCount = 0;

        public int NumIslands(char[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        islandCount += DestroyIsland(grid, i, j);
                    }
                }
            }
            return islandCount;
        }

        public int DestroyIsland(char[][] grid, int vertical, int horizontal)
        {

                bool up = vertical - 1 >= 0 && grid[vertical - 1][horizontal] == '1';
                bool down = vertical + 1 < grid.Length && grid[vertical + 1][horizontal] == '1';
                bool left = horizontal - 1 >= 0 && grid[vertical][horizontal - 1] == '1';
                bool right = horizontal + 1 < grid[vertical].Length && grid[vertical][horizontal + 1] == '1';
                // vertical Destruction
                if (up)
                {
                    grid[vertical - 1][horizontal] = '0';
                    DestroyIsland(grid, vertical - 1, horizontal);
                }
                if (down)
                {
                    grid[vertical + 1][horizontal] = '0';
                    DestroyIsland(grid, vertical + 1, horizontal);
                }
                if (left)
                {
                    grid[vertical][horizontal - 1] = '0';
                    DestroyIsland(grid,vertical, horizontal - 1);
                }
                if (right)
                {
                    grid[vertical][horizontal + 1] = '0';
                    DestroyIsland(grid, vertical, horizontal + 1);
                } 

                return 1;
        }

        public int LengthOfLongestSubstring(string s)
        {
            HashSet<char> uniqueChars = new HashSet<char>();
            int maxStringLength = 0;
            int hashIndex = 0;
            int copyIndex = 0;

            if (s == null || s == "") return 0;

            while (hashIndex < s.Length)
            {
                if (!uniqueChars.Contains(s[hashIndex]))
                {
                    uniqueChars.Add(s[hashIndex]);
                    hashIndex++;
                    if (maxStringLength < (hashIndex - copyIndex))
                    {
                        maxStringLength = hashIndex - copyIndex;
                    }
                }
                else
                {
                    uniqueChars.Remove(s[copyIndex]);
                    copyIndex++;
                }
            }

            return maxStringLength;


        }
        public int LengthOfLongestSubstring2(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            List<char> list = new List<char>();
            int largestString = 1;

            if (s=="")
            {
                return 0;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (dict.TryAdd(s[i], i))
                {
                    list.Add(s[i]);
                }
                else
                {
                    if (largestString < list.Count)
                    {
                        largestString = list.Count;
                    }
                    if (list[0] == s[i])
                    {
                        list.Remove(list[0]);
                    }
                    else
                    {
                        while (list[0] != s[i])
                        {
                            list.Remove(list[0]);
                        }
                        list.Remove(list[0]);
                    }
                    dict.Clear();
                    dict = list.ToDictionary(x => x, x => 0);
                    if (dict.TryAdd(s[i], i))
                    {
                        list.Add(s[i]);
                    }
                }
            }
            return (largestString < list.Count) ? list.Count : largestString;
        }

        public ListNode AddTwoNumbers2(ListNode l1, ListNode l2)
        {
            ListNode tmp = new ListNode(0);
            ListNode head = tmp;
            int carryOver = 0;
            while (l1 != null || l2 != null)
            {
                int sum = carryOver;

                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                if (sum >= 10)
                {
                    sum -= 10;
                    carryOver = 1;
                }
                else
                {
                    carryOver = 0;
                }
                tmp.next = new ListNode(sum);
                tmp = tmp.next;
            }
            if (carryOver == 1)
            {
                tmp.next = new ListNode(carryOver);
            }
            return head.next;
        }

            /*public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                StringBuilder list1 = new StringBuilder();
                StringBuilder list2 = new StringBuilder();

                ListNode tmp = l1;
                while (tmp != null)
                {
                    list1.Append(tmp.val);
                    tmp = tmp.next;
                }

                tmp = l2;
                while (tmp != null)
                {
                    list2.Append(tmp.val);
                    tmp = tmp.next;
                }

                char[] list1CharArray = list1.ToString().ToCharArray();
                char[] list2CharArray = list2.ToString().ToCharArray();

                int smallIndex = 0;

                if (list1CharArray.Length <= list2CharArray.Length)
                {
                    smallIndex = list1CharArray.Length;
                }
                else
                {
                    smallIndex = list2CharArray.Length;
                }

                int carryOver = 0;
                List<int> list3 = new List<int>();
                for (int i = 0; i < smallIndex; i++)
                {
                    int list1Int = Convert.ToInt32(list1CharArray[i].ToString());
                    int list2Int = Convert.ToInt32(list2CharArray[i].ToString());
                    int total = list1Int + list2Int + carryOver;

                    if (total >= 10)
                    {
                        list3.Add(total - 10);
                        carryOver = 1;
                    }
                    else
                    {
                        list3.Add(total);
                        carryOver = 0;
                    }
                }
                if (list1CharArray.Length < list2CharArray.Length)
                {
                    for (int i = smallIndex; i < list2CharArray.Length; i++)
                    {
                        int list2Int = Convert.ToInt32(list2CharArray[i].ToString());
                        int total = list2Int + carryOver;
                        if (total >= 10)
                        {
                            list3.Add(total - 10);
                            carryOver = 1;
                        }
                        else
                        {
                            list3.Add(total);
                            carryOver = 0;
                        }
                    }
                }
                else if (list1CharArray.Length > list2CharArray.Length)
                {
                    for (int i = smallIndex; i < list1CharArray.Length; i++)
                    {
                        int list1Int = Convert.ToInt32(list1CharArray[i].ToString());
                        int total = list1Int + carryOver;
                        if (total >= 10)
                        {
                            list3.Add(total - 10);
                            carryOver = 1;
                        }
                        else
                        {
                            list3.Add(total);
                            carryOver = 0;
                        }
                    }
                }
                if (carryOver > 0)
                {
                    list3.Add(carryOver);
                }

                list3.Reverse();
                ListNode nextTmp = null;
                foreach (var number in list3)
                {
                    tmp = new ListNode(number, nextTmp);
                    nextTmp = tmp;
                }
                return tmp;

            }*/
            /*   public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
           {

               StringBuilder list1 = new StringBuilder();
               StringBuilder list2 = new StringBuilder();

               ListNode tmp = l1;
               while (tmp != null)
               {
                   list1.Append(tmp.val);
                   tmp = tmp.next;
               }

               tmp = l2;
               while (tmp != null)
               {
                   list2.Append(tmp.val);
                   tmp = tmp.next;
               }

               char[] list1CharArray = list1.ToString().ToCharArray();
               char[] list2CharArray = list2.ToString().ToCharArray();

               char[] smallCharArray;
               char[] bigCharArray;

               if (list1CharArray.Length <= list2CharArray.Length)
               {
                   smallCharArray = list1CharArray;
                   bigCharArray = list2CharArray;
               }
               else
               {
                   smallCharArray = list2CharArray;
                   bigCharArray=list1CharArray;
               }
               StringBuilder list3 = new StringBuilder();
               int carryOver = 0;
               int equalListCarryOver = 0;
               for (int i = 0; i < smallCharArray.Length; i++)
               {
                   int smallInt = Convert.ToInt32(smallCharArray[i].ToString());
                   int bigInt = Convert.ToInt32(bigCharArray[i].ToString());
                   int total = smallInt + bigInt;
                   if (carryOver > 0 && i != bigCharArray.Length - 1 && (smallCharArray.Length != 1 || bigCharArray.Length != 1))
                   {
                       if (total + carryOver >= 10)
                       {
                           list3.Append(total + carryOver - 10);
                           carryOver = 1;
                       }
                       else
                       {
                           list3.Append(total + carryOver);
                           carryOver = 0;
                       }
                   }
                   else if (smallInt + bigInt >= 10 && (smallCharArray.Length != 1 || bigCharArray.Length != 1))
                   {
                       list3.Append(total - 10);
                       carryOver = 1;
                   }
                   else if (i != smallCharArray.Length - 1 && (smallCharArray.Length != 1 || bigCharArray.Length != 1))
                   {
                       list3.Append(total);

                   }
                   if (i == smallCharArray.Length - 1)
                   {
                       if (smallCharArray.Length < bigCharArray.Length)
                       {
                           int j = i + 1;
                           while (j < bigCharArray.Length)
                           {
                               if (carryOver == 1 && bigCharArray[j] != '9')
                               {
                                   list3.Append(Convert.ToInt32(bigCharArray[j].ToString()) + carryOver);
                                   carryOver = 0;
                                   j++;
                               }
                               else if (bigCharArray[j] == '9' && carryOver == 1)
                               {
                                   list3.Append(0);
                                   carryOver = 1;
                                   j++;
                               }
                               else
                               {
                                   list3.Append(bigCharArray[j]);
                                   j++;
                               }
                           }
                           if (carryOver == 1)
                           {
                               list3.Append(carryOver);
                           }
                       }
                       else if (smallCharArray.Length == 1 && bigCharArray.Length == 1)
                       {
                           if (bigInt + smallInt >= 10)
                           {
                               list3.Append(bigInt + smallInt - 10);
                               list3.Append(1);
                           }
                           else
                           {
                               list3.Append(bigInt + smallInt);
                           }
                       }
                       else
                       {
                           if (carryOver > 0)
                           {
                               if (total + carryOver >= 10)
                               {
                                   list3.Append(total - 10);
                                   list3.Append(1);
                               }
                               else
                               {
                                   list3.Append(total + carryOver);
                               }
                           }
                           else
                           {
                               list3.Append(total);
                           }
                       }
                   }
               }
               char[] list3Reversal = list3.ToString().ToCharArray();
               Array.Reverse(list3Reversal);

               string list3Return = new string(list3Reversal);
               ListNode nextTmp = null;
               foreach (var number in list3Reversal)
               {
                   int tmpInt = Convert.ToInt32(number.ToString());
                   tmp = new ListNode(tmpInt, nextTmp);
                   nextTmp = tmp;
               }
               return tmp; 
           }*/

        }
}
