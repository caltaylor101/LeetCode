using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class InterviewPrepPart2
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums);
            var endIndex = nums.Length;

            for (int i = 0; i < endIndex; i++)
            {
                // Makes sure it is a unique value.
                // i = 0 is always unique, so we continue till we get a new i value. 
                if (i > 0 && nums[i - 1] == nums[i]) continue;

                //Everything to the left of i has already been added. 
                //Therefore, we need to make sure we are only solving for the next i.
                var left = i + 1;
                var right = endIndex - 1;

                while (left < right)
                {
                    //Check to see if our left and right pointer add up to the sum with our i. 
                    //For every instance they do, we add it to the list and traverse to unique values. 
                    var sum = nums[i] + nums[left] + nums[right];
                    if (sum == 0)
                    {
                        result.Add(new List<int>() { nums[i], nums[left], nums[right] });
                        //Move to the spot right before the next unique value.
                        //If left = left + 1 we increase left till we find a unique value.
                        //For example, if we had [1, 1, 1, 1, 2] this while loop would stop at left = 1, left + 1 = 2.
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        //We do the same thing on the right side.
                        while (left < right && nums[right] == nums[right - 1]) right--;
                        //This extra ++ or -- puts us on the unique value. 
                        left++;
                        right--;
                    }
                    //If sum is less than 0, that means our values on both pointers are too small.
                    //For example, [-4, -1, 0, 1, 2, 2]
                    //i = -4, left starts at i+1 = -1, and right is at the end, 2.
                    //-4 + -1 + 2 = -3. Since the value is too small, we need to move up on the left index to find the next match.
                    //In the provided example, this would be 2.
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return result;
        }
        public IList<IList<int>> ThreeSum5(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();

            Dictionary<int, int> numbers = new Dictionary<int, int>();
            HashSet<string> uniqueTriplets = new HashSet<string>();

            HashSet<int> numbersChecked = new HashSet<int>();

            StringBuilder triplet = new StringBuilder();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!numbers.TryAdd(nums[i], 1))
                {
                    numbers[nums[i]] += 1;
                }
            }
            foreach (var set in numbers)
            {
                if (numbersChecked.Add(set.Key))
                {
                    if (set.Key < 0)
                    {
                        for (int k = 0; k <= -set.Key; k++)
                        {
                            var otherVariable = -1 * (set.Key + k);
                            if (numbers.ContainsKey(otherVariable) && numbers.ContainsKey(k))
                            {
                                int[] values = new int[] { otherVariable, k, set.Key };

                                if (otherVariable == k && numbers[k] < 2) continue;

                                Array.Sort(values);

                                foreach (int value in values)
                                {
                                    triplet.Append(value);
                                }
                                if (uniqueTriplets.Add(triplet.ToString()))
                                {
                                    result.Add(new List<int>() { values[0], values[1], values[2] });
                                }
                                triplet.Clear();
                            }
                        }

                    }

                    if (set.Key > 0)
                    {
                        for (int k = 0; k >= -set.Key; k--)
                        {
                            var otherVariable = -1 * (set.Key + k);
                            if (numbers.ContainsKey(otherVariable) && numbers.ContainsKey(k))
                            {
                                int[] values = new int[] { otherVariable, k, set.Key };
                                if (otherVariable == k && numbers[k] < 2) continue;

                                Array.Sort(values);
                                foreach (int value in values)
                                {
                                    triplet.Append(value);
                                }
                                if (uniqueTriplets.Add(triplet.ToString()))
                                {
                                    result.Add(new List<int>() { values[0], values[1], values[2] });
                                }
                                triplet.Clear();
                            }
                        }
                    }

                    if (set.Key == 0 && numbers[set.Key] > 2)
                    {
                        if (uniqueTriplets.Add(new string("000")))
                        {
                            result.Add(new List<int>() { 0, 0, 0 });
                        }
                    }

                }

            }

            return result;
        }
        public IList<IList<int>> ThreeSum4(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Dictionary<int, int> values = new Dictionary<int, int>();
            HashSet<string> distinctTriplets = new HashSet<string>();
            StringBuilder triplet = new StringBuilder();

            var low = int.MinValue;
            var high = int.MaxValue;

            int x = int.MinValue;
            int y = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                if (!values.TryAdd(nums[i], 1))
                {
                    values[nums[i]] += 1;
                }
            }

            foreach (var set in values)
            {
                if (set.Key == 0 && set.Value > 2)
                {
                    if (distinctTriplets.Add("000"))
                    {
                        result.Add(new List<int>() { 0, 0, 0 });
                    }
                }
                if ((set.Key == 1 || set.Key == -1) && values.ContainsKey(0) && values.ContainsKey(-set.Key))
                {
                    if (distinctTriplets.Add("-101"))
                    {
                        result.Add(new List<int>() { -1, 0, 1 });
                    }
                }
                if (set.Key != 0 && set.Key != 1 && set.Key != -1)
                {
                    if (values.ContainsKey(-set.Key) && values.ContainsKey(0) && values[-set.Key] > 1)
                    {
                        low = Math.Min(-set.Key, set.Key);
                        high = Math.Max(-set.Key, set.Key);
                        triplet.Append(low);
                        triplet.Append(0);
                        triplet.Append(high);
                        if (distinctTriplets.Add(triplet.ToString()))
                        {
                            result.Add(new List<int>() { low, 0, high });
                        }
                        triplet.Clear();
                    }

                    if (set.Key % 2 == 0)
                    {
                        x = -set.Key / 2;
                        y = x;
                        if (set.Key + y + x == 0 && values.ContainsKey(x) && values[x] > 1)
                        {
                            triplet.Append(x);
                            triplet.Append(x);
                            triplet.Append(set.Key);
                            if (distinctTriplets.Add(triplet.ToString()))
                            {
                                result.Add(new List<int>() { x, x, set.Key });
                            }
                            triplet.Clear();
                        }
                    }
                    if (set.Key % 2 != 0)
                    {
                        x = (int)Math.Floor((double)-set.Key / 2);
                        y = (int)Math.Ceiling((double)-set.Key / 2);

                        if (set.Key + x + y == 0 && values.ContainsKey(x) && values.ContainsKey(y))
                        {
                            low = Math.Min(y, x);
                            high = Math.Max(y, x);
                            triplet.Append(low);
                            triplet.Append(high);
                            triplet.Append(set.Key);
                            if (distinctTriplets.Add(triplet.ToString()))
                            {
                                result.Add(new List<int>() { low, high, set.Key });
                            }
                            triplet.Clear();
                        }
                    }

                    if (values.ContainsKey(-set.Key) && values.ContainsKey(0))
                    {
                        low = Math.Min(-set.Key, set.Key);
                        high = Math.Max(-set.Key, set.Key);
                        triplet.Append(low);
                        triplet.Append(0);
                        triplet.Append(high);
                        if (distinctTriplets.Add(triplet.ToString()))
                        {
                            result.Add(new List<int>() { low, 0, high });
                        }
                        triplet.Clear();
                    }

                }

            }

            return result;
        }
        public IList<IList<int>> ThreeSum3(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Dictionary<int, int> values = new Dictionary<int, int>();
            HashSet<string> distinctTriplets = new HashSet<string>();
            StringBuilder triplet = new StringBuilder();
            int x = int.MinValue;
            int y = int.MinValue;
            int a = int.MinValue;
            int b = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                if (!values.TryAdd(nums[i], 1))
                {
                    values[nums[i]] += 1;
                }
            }

            foreach (var set in values)
            {
                x = int.MinValue;
                y = int.MinValue;
                if (set.Key == 0) { }
                if (set.Key == 0 && set.Value > 2)
                {
                    triplet.Append(0);
                    triplet.Append(0);
                    triplet.Append(0);
                    if (distinctTriplets.Add(triplet.ToString()))
                    {
                        result.Add(new List<int>() { 0, 0, 0 });
                    }
                    triplet.Clear();
                }
                if (set.Key == 1 || set.Key == -1)
                {
                    if (values.ContainsKey(-set.Key) && values.ContainsKey(0))
                    {
                        if (values[0] > 0 && values[-set.Key] > 0)
                        {
                            triplet.Append(-1);
                            triplet.Append(0);
                            triplet.Append(1);
                            if (distinctTriplets.Add(triplet.ToString()))
                            {
                                result.Add(new List<int>() { -1, 0, 1 });
                            }
                            triplet.Clear();
                        }
                    }
                }
                if (set.Key % 2 == 0 && set.Key != 0)
                {
                    x = -(set.Key) / 2;
                    y = x;
                }
                if (set.Key != 1 && set.Key != -1 && set.Key != 0)
                {
                    a = (int)(Math.Floor(-(decimal)set.Key / 2));
                    b = (int)(Math.Ceiling(-(decimal)set.Key / 2));
                }

                if (values.ContainsKey(x) && values.ContainsKey(y))
                {

                    if (x == y && values[x] > 1 && x + y + set.Key == 0)
                    {
                        triplet.Append(x);
                        triplet.Append(y);
                        triplet.Append(set.Key);
                        if (distinctTriplets.Add(triplet.ToString()))
                        {
                            result.Add(new List<int>() { x, y, set.Key });
                        }
                        triplet.Clear();
                    }
                }
                if (values.ContainsKey(a) && values.ContainsKey(b))
                {
                    Console.WriteLine("a {0} and b {1} on key {2}", a, b, set.Key);
                    if (a != b && values[a] > 0 && values[b] > 0 && values[a] + values[b] + set.Key == 0)
                    {
                        triplet.Append(x);
                        triplet.Append(y);
                        triplet.Append(set.Key);
                        if (distinctTriplets.Add(triplet.ToString()))
                        {
                            result.Add(new List<int>() { x, y, set.Key });
                        }
                        triplet.Clear();
                    }
                }


                if (values.ContainsKey(0) && values.ContainsKey(set.Key) && values.ContainsKey(-set.Key))
                {
                    if (set.Key == 0 && values[0] >= 3)
                    {
                        triplet.Append(0);
                        triplet.Append(0);
                        triplet.Append(0);
                        if (distinctTriplets.Add(triplet.ToString()))
                        {
                            result.Add(new List<int>() { 0, 0, 0 });
                        }
                        triplet.Clear();
                    }
                    if (values[0] > 0 && set.Value > 0 && values[-set.Key] > 0 && set.Key != 0)
                    {

                        var low = Math.Min(set.Key, -set.Key);
                        var high = Math.Max(set.Key, -set.Key);
                        triplet.Append(low);
                        triplet.Append(0);
                        triplet.Append(high);
                        if (distinctTriplets.Add(triplet.ToString()))
                        {
                            result.Add(new List<int>() { low, 0, high });
                        }
                        triplet.Clear();
                    }
                }
            }

            return result;
        }

        public IList<IList<int>> ThreeSum2(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Dictionary<int, int> values = new Dictionary<int, int>();
            HashSet<string> distinctTriplets = new HashSet<string>();
            StringBuilder triplet = new StringBuilder();
            int x = 0;
            int y = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (!values.TryAdd(nums[i], 1))
                {
                    values[nums[i]] += 1;
                }

                if (nums[i] == 0)
                {

                }
                else if (nums[i] == 1 || nums[i] == -1)
                {
                    if (values.ContainsKey(-nums[i]) && values.ContainsKey(0))
                    {
                        if (values[0] > 0 && values[-nums[i]] > 0)
                        {
                            triplet.Append(-1);
                            triplet.Append(0);
                            triplet.Append(1);
                            if (distinctTriplets.Add(triplet.ToString()))
                            {
                                result.Add(new List<int>() { -1, 0, 1 });
                            }
                            triplet.Clear();
                        }
                    }
                }
                else if (nums[i] % 2 == 0)
                {
                    x = -(nums[i]) / 2;
                    y = x;
                }
                else
                {
                    x = (int)(Math.Floor(-(decimal)nums[i] / 2));
                    y = (int)(Math.Ceiling(-(decimal)nums[i] / 2));
                }

                if (values.ContainsKey(x) && values.ContainsKey(y))
                {

                    if (x == y && values[x] > 1 && x + y + nums[i] == 0)
                    {
                        triplet.Append(x);
                        triplet.Append(y);
                        triplet.Append(nums[i]);
                        if (distinctTriplets.Add(triplet.ToString()))
                        {
                            result.Add(new List<int>() { x, y, nums[i] });
                        }
                        triplet.Clear();
                    }
                    else if (x != y && values[x] > 0 && values[y] > 0)
                    {
                        triplet.Append(x);
                        triplet.Append(y);
                        triplet.Append(nums[i]);
                        if (distinctTriplets.Add(triplet.ToString()))
                        {
                            result.Add(new List<int>() { x, y, nums[i] });
                        }
                        triplet.Clear();
                    }
                }
                else if (values.ContainsKey(0) && values.ContainsKey(nums[i]) && values.ContainsKey(-nums[i]))
                {
                    if (nums[i] == 0 && values[0] >= 3)
                    {
                        triplet.Append(0);
                        triplet.Append(0);
                        triplet.Append(0);
                        if (distinctTriplets.Add(triplet.ToString()))
                        {
                            result.Add(new List<int>() { 0, 0, 0 });
                        }
                        triplet.Clear();
                    }
                    if (values[0] > 0 && values[nums[i]] > 0 && values[-nums[i]] > 0 && nums[i] != 0)
                    {

                        var low = Math.Min(nums[i], -nums[i]);
                        var high = Math.Max(nums[i], -nums[i]);
                        triplet.Append(low);
                        triplet.Append(0);
                        triplet.Append(high);
                        if (distinctTriplets.Add(triplet.ToString()))
                        {
                            result.Add(new List<int>() { low, 0, high });
                        }
                        triplet.Clear();
                    }
                }



            }
            return result;
        }

    }
}
