using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class DataStructures
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            Dictionary<int, int> dict2 = new Dictionary<int, int>();
            List<int> list = new List<int>();
            
            for (int i = 0; i < nums1.Length; i++)
            {
                if (!dict.TryAdd(nums1[i], 1))
                {
                    dict[nums1[i]] += 1;
                }
            }
            for (int i = 0; i < nums2.Length; i++)
            {
                if (!dict2.TryAdd(nums2[i], 1))
                {
                    dict2[nums2[i]] += 1;
                }
            }
            if (dict.Count < dict2.Count)
            {
                foreach (var key in dict.Keys)
                {
                    if (dict2.ContainsKey(key))
                    {
                        dict[key] = Math.Min(dict[key], dict2[key]);
                        while (dict[key] != 0)
                        {
                            list.Add(key);
                            dict[key]--;
                        }
                    }
                }

            }
            else
            {
                foreach (var key in dict2.Keys)
                {
                    if (dict.ContainsKey(key))
                    {
                        dict2[key] = Math.Min(dict[key], dict2[key]);
                        while (dict2[key] != 0)
                        {
                            list.Add(key);
                            dict2[key]--;
                        }
                    }
                }
            }
            return list.ToArray();
        }
        public int[] Intersect2(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            Dictionary<int, int> dict2 = new Dictionary<int, int>();

            List<int> list = new List<int>();
            List<int> list2 = new List<int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                if (!dict.TryAdd(nums1[i], 1))
                {
                    dict[nums1[i]] += 1;
                }
            }
            for (int i = 0; i < nums2.Length; i++)
            {
                if (!dict2.TryAdd(nums2[i], 1))
                {
                    dict2[nums2[i]] += 1;
                }
            }

            if (dict.Count < dict2.Count)
            {
                foreach (var key in dict.Keys)
                {
                    if (dict2.ContainsKey(key))
                    {
                        dict[key] = Math.Min(dict[key], dict2[key]);
                        while (dict[key] != 0)
                        {
                            list.Add(key);
                            dict[key]--;
                        }
                    }
                }

            }
            else
            {
                foreach (var key in dict2.Keys)
                {
                    if (dict.ContainsKey(key))
                    {
                        dict2[key] = Math.Min(dict[key], dict2[key]);
                        while (dict2[key] != 0)
                        {
                            list.Add(key);
                            dict2[key]--;
                        }
                    }
                }
            }
            return list.ToArray();
        }
        public void Merge4(int[] nums1, int m, int[] nums2, int n)
        {
            int[] nums3 = new int[m + n];

            for (int i = 0; i < nums1.Length; i++)
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
