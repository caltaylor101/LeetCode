using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    internal class InterviewPrepQuestions
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
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
