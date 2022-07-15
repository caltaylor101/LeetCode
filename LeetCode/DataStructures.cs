using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class DataStructures
    {

        public void Merge4(int[] nums1, int m, int[] nums2, int n)
        {
            int[] nums3 = new int[m + n];

            for(int i = 0; i < nums1.Length; i++)
            {
                if (i < nums2.Length - 1)
                {
                    if (nums1[i] < nums2[i])
                    {
                        nums3[i] = nums1[i];
                    }
                }
                else break;
            }
        }
        public void Merge3(int[] nums1, int m, int[] nums2, int n)
        {
            int counter = 0;
            if (m == 0)
            {
                for (int i = 0; i < nums1.Length; i++)
                {
                    nums1[i] = nums2[i];
                }
            }
            if (n != 0)
            {
                for (int i = m - 1; i >= 0; i--)
                {
                    if (i == m - 1 && nums1[i] <= nums2[counter])
                    {
                        for (int j = m; j < nums1.Length; j++)
                        {
                            nums1[j] = nums2[counter++];
                        }
                        break;
                    }
                    else if (nums1[i] <= nums2[counter])
                    {
                        for (int j = nums1.Length - 1; j > i + 1; j--)
                        {
                            nums1[j] = nums1[j - 1];
                        }
                        if (i + 1 < nums1.Length - 1)
                        {
                            nums1[i + 1] = nums2[counter++];
                        }
                        else
                        {
                            nums1[i] = nums2[counter++];
                        }
                        i = m + 1;
                        m++;
                    }
                    else if (i == 0)
                    {
                        for (int j = nums1.Length - 1; j > i; j--)
                        {
                            nums1[j] = nums1[j - 1];
                        }
                            nums1[i] = nums2[counter++];
                        
                        i = m + 1;
                        m++;
                    }
                    if (counter == n) break;
                }
            }
        }

        public void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            int counter = 0;
            for (int i = m; i < nums1.Length; i++)
            {
                nums1[i] = nums2[counter];
                counter++;
            }
            Array.Sort(nums1);

            foreach (var i in nums1)
            {
                Console.WriteLine(i);
            }
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int kAccessed = 0;
            int startNumber = n;
            if (m == 0)
            {
                for (int i = 0; i < nums1.Length; i++)
                {
                    nums1[i] = nums2[i];
                }
            }
            else
            {

                for (int i = 0; i < nums1.Length; i++)
                {
                    for (int k = kAccessed; k < nums2.Length; k++)
                    {
                        if (nums2[k] <= nums1[i])
                        {
                            for (int h = nums1.Length - 1; h >= i; h--)
                            {
                                if (h - 1 >= 0)
                                {
                                    nums1[h] = nums1[h - 1];
                                }
                            }
                            nums1[i] = nums2[k];
                            kAccessed++;
                            startNumber--;
                            break;
                        }
                        else if (i == nums1.Length - 1)
                        {
                            nums1[i] = nums2[k];
                            break;
                        }
                        else if (nums1[i + 1] >= nums2[k] || nums1.Length - 1 - i == startNumber)
                        {
                            for (int h = (nums1.Length - 1); h > i + 1; h--)
                            {
                                if (h - 1 >= 0)
                                {
                                    nums1[h] = nums1[h - 1];
                                }
                            }
                            nums1[i + 1] = nums2[k];
                            startNumber--;
                            kAccessed++;
                            break;
                        }
                        break;
                    }
                }

                foreach (var i in nums1)
                { Console.WriteLine(i); }
            }

        }
    }
}
