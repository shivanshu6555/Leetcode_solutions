using Leetcode_solutions;
using System.Globalization;
using System.Text;


string[] strs = [""];
int[] nums1 = new int[] {1,3};
int[] nums2 = new int[] {2};



//s.GroupAnagrams(strs);
//s.TopKFrequent([1,1,1,1,1,1,1,1,1,1,2,2,3,3]);
//foreach(int i in s.RemoveDuplicates(nums))
//{
//    Console.WriteLine(i);
//}
//Console.WriteLine(s.RemoveElement(nums,3));
//string paran = "([}}])";
//Console.WriteLine(s.IsValid(paran));

//int[] nums1 = new int[] { 3, 1, 3, 4, 2 };
//Console.WriteLine(s.FindDuplicate(nums1));
//ListNode l1 = new ListNode();
//l1.val = 5;
//ListNode l2 = new ListNode();
//l1.val = 2;
//ListNode l3 = new ListNode();
//l1.val = 13;
//ListNode l4 = new ListNode();
//l1.val = 3;
//ListNode l5 = new ListNode();
//l1.val = 8;
//l1.next = l2;
//l2.next = l3;
//l3.next = l4;
//l4.next = l5;
//ListNode head = new();
//head.next = l1;
//ListNode ans = s.RemoveNodes(head);
//Console.WriteLine(ans.next);

//s.TopKFrequent(nums, 3);
//foreach(int i in s.TopKFrequent(nums, 3))
//{
//    Console.WriteLine(i);
//}

//Console.WriteLine(s.ReverseString("shivanshu"));
//Recursion rec = new();
//Console.WriteLine(rec.Sumofnumbers(10));

//foreach (int i in s.Fibonacci(6))
//{
//    Console.WriteLine(i) ;
//}

//Console.WriteLine(s.Fibonacci(6));

Solution s = new();
////Console.WriteLine(s.IsSorted(nums, nums.Length));

//Console.WriteLine(s.Search(nums1,2));

//foreach(int i in s.ProductExceptSelf(nums1))
//{
//    Console.WriteLine(i) ;
//}

Recursion rec = new();
//rec.PrintName(5);
//rec.PrintLinearly(1, 5);
//rec.PrintDec(1, 5);
//Console.WriteLine(rec.Sum(3));
//Console.WriteLine(s.FindMedianSortedArraysOptimized(nums1,nums2));
int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };
Console.WriteLine(s.ThreeSum(nums));
//foreach(int i in (rec.Reverse(nums, 0, nums.Length - 1))){
//    Console.WriteLine(i);
//}

//rec.reverse(nums, nums.Length);


//Console.WriteLine(rec.IsPalindrome("0P"));

//rec.FindSubsequence([3, 1, 2]);
//Console.WriteLine(rec.SumofSubsequence([1,2,1], 2));

//foreach(List<int> i in (rec.SumofSubsequence([1, 2, 1], 2))){
//    foreach(int j in i)
//    {
//        Console.WriteLine(j);
//    }
//}
Console.WriteLine(s.MaxFrequency(nums,5));
public class Solution
{

    //3 sum
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        List<IList<int>> result = new();
        Array.Sort(nums);
        
        for (int i = 0; i < nums.Length - 2; i++)
        {
            int left = i+1; int right = nums.Length - 1;
            if (i>0 && nums[i] == nums[i - 1]) { continue; }
            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];
                if (sum == 0)
                {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] }); // Use List<int> for collection initializer
                    while (left < right && nums[left] == nums[left + 1]) { left++; }
                    while (left < right && nums[right] == nums[right - 1]) { right--; }
                    left++;
                    right--;
                }
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

    //1838. Frequency of the Most Frequent Element
    public int MaxFrequency(int[] nums,int k)
    {
        Array.Sort(nums);
        int MaxFreq = 0;
        long Currsum = 0;
        int left = 0;
        for(int right = 0; right < nums.Length; right++)
        {
            Currsum += nums[right];
            while(((right - left + 1) * (long)nums[right]) - Currsum > k)
            {
                Currsum -= nums[left];
                left++;
            }
            MaxFreq = Math.Max(MaxFreq, right - left + 1);
        }

        return MaxFreq;
    }

    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        //edge cases
        if (strs.Length == 0 || strs.Length == 1) { return new List<IList<string>>(); }

        Dictionary<string, IList<string>> anagrams = new();
        foreach (var word in strs)
        {

            int[] charcount = new int[26];
            foreach (char c in word)
            {
                charcount[c - 'a']++;
            }

            StringBuilder sb = new();
            for (int i = 0; i < 26; i++) {
                sb.Append(charcount[i]);
            }

            string key = sb.ToString();
            if (!anagrams.ContainsKey(key))
            {
                anagrams[key] = new List<string>();
            }
            anagrams[key].Add(word);
        }


        return new List<IList<string>>(anagrams.Values);
    }

    public void TopKFrequent(int[] nums)
    {
        Dictionary<int, int> count = new();
        foreach (int i in nums)
        {
            if (!count.ContainsKey(i)) { count[i] = 1; }
            else { count[i]++; }
        }

        foreach (var i in count)
        {
            Console.WriteLine($"key{i.Key} , {i.Value}");
        }
    }

    public bool ContainsDuplicate(int[] nums)
    {
        Dictionary<int, int> track = new();
        for (int i = 0; i < nums.Length; i++)
        {
            if (track.ContainsKey(nums[i]))
            {
                return false;
            }
            else
            {
                track.Add(nums[i], i);
            }
        }
        return true;
    }

    public int[] RemoveDuplicates(int[] nums)
    {
        int i = 0;
        int j = 0;
        while (j < nums.Length)
        {
            if (nums[i] == nums[j])
            {
                j++;
            }
            else
            {
                i++;
                (nums[i], nums[j]) = (nums[j], nums[i]);
                j++;
            }
        }
        return nums[0..(i + 1)];
    }

    public int RemoveElement(int[] nums, int val)
    {
        int i = 0;

        for (int k = 0; k < nums.Length; k++)
        {
            if (nums[k] == val) { i = k; break; }
        }
        int j = i + 1;
        while (j < nums.Length)
        {
            if (nums[j] != val)
            {
                (nums[i], nums[j]) = (nums[j], nums[i]);
                i++;
                j++;
            }
            else
            {
                j++;
            }
        }
        return nums[0..i].Length;
    }

    public bool IsValid(string s)
    {
        if (s.Length % 2 != 0) { return false; }
        Stack<char> checkparan = new();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '{' || s[i] == '[' || s[i] == '(')
            {
                checkparan.Push(s[i]);
            }
            else if (checkparan.Count == 0) { return false; }
            else if (s[i] == '}' || s[i] == ']' || s[i] == ')')
            {
                if (s[i] == '}' && checkparan.Peek() == '{')
                {
                    checkparan.Pop();
                }
                else if (s[i] == ']' && checkparan.Peek() == '[')
                {
                    checkparan.Pop();
                }
                else if (s[i] == ')' && checkparan.Peek() == '(')
                {
                    checkparan.Pop();
                }
            }
        }
        if (checkparan.Count == 0)
        {
            return true;
        }
        else { return false; }
    }

    public int FindDuplicate(int[] nums)
    {
        int slow = nums[0]; int fast = nums[0];
        do
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        slow = nums[0];

        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }

        return slow;
    }

    public ListNode RemoveNodes(ListNode head)
    {
        ListNode curr = head;
        ListNode prev = null;
        while (curr != null)
        {
            if ((curr.next).val > curr.val)
            {
                ListNode temp = curr.next;
                prev.next = curr.next;
                curr.next = null;
                curr = temp;
            }
            else
            {
                prev = curr;
                curr = curr.next;
            }
        }
        return prev;
    }

    public string ReverseString(string s)
    {
        StringBuilder s1 = new(s);
        int i = 0; int j = s1.Length - 1;
        while (i != j)
        {
            (s1[i], s1[j]) = (s1[j], s1[i]);
            i++; j--;
        }
        return s1.ToString();
    }

    public int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> FreqCount = new();
        foreach (int i in nums)
        {
            if (FreqCount.ContainsKey(i)) { FreqCount[i]++; }
            else { FreqCount[i] = 1; }
        }
        PriorityQueue<int, int> minheap = new();
        foreach (var freq in FreqCount)
        {
            minheap.Enqueue(freq.Key, freq.Value);
            if (minheap.Count > k)
            { minheap.Dequeue(); }
        }
        int[] results = new int[k];
        for (int i = 0; i < k; i++)
        {
            results[i] = minheap.Dequeue();
        }

        return results;

    }

    public int Fibonacci(int n)
    {
        int sum = 0;
        int[] arr = new int[n + 1];
        arr[0] = 0; arr[1] = 1;
        for (int i = 2; i <= n; i++)
        {
            arr[i] = arr[i - 1] + arr[i - 2];
        }

        return arr[n];
    }

    //IsSorted array using recursion
    public bool IsSorted(int[] arr, int n)
    {
        if (n == 0 || n == 1 ) { return true; }

        return (arr[n - 1] > arr[n - 2] && IsSorted(arr, n - 1));
    }

    public int Search(int[] nums, int target)
    {
        int start = 0; int end = nums.Length - 1;
        while (start < end)
        {
            int mid = start + ((end - start) / 2);
            if (nums[mid] == target) { return mid; }
            else if (nums[mid] > target)
            {
                end = mid;
            }
            else
            {
                start = mid;
            }
        }
        return -1;
    }

    public int[] ProductExceptSelf(int[] nums)
    {
        int[] ans = new int[nums.Length];
        int[] prefix = new int[nums.Length];
        Array.Fill(prefix, 1);
        int[] suffix = new int[nums.Length];
        Array.Fill(suffix, 1);
        for (int i = 1; i < nums.Length; i++)
        {
            suffix[i] = suffix[i - 1] * nums[i - 1];
        }

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            prefix[i] = prefix[i + 1] * nums[i + 1];
        }

        for (int i = 0; i < nums.Length; i++)
        {
            ans[i] = prefix[i] * suffix[i];
        }

        return ans;
    }

    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int i = 0; int j = 0;
        int m = nums1.Length;
        int n = nums2.Length;
        List<int> ans = new();
        while (i < m && j < n)
        {
            if (nums1[i] < nums2[j])
            {
                ans.Add(nums1[i]);
                i++;
            }
            else
            {
                ans.Add(nums2[j]);
                j++;
            }
        }
        while (i < m)
        {
            ans.Add(nums1[i]);
            i++;
        }
        while (j < n)
        {
            ans.Add(nums2[j]);
            j++;
        }
        int total = m + n;
        if (ans.Count % 2 == 0)
        {
            return (ans[total / 2] + ans[(total / 2) - 1]) / 2.0;
        }
        else
        {
            return ans[total / 2];
        }
    }

    public double FindMedianSortedArraysBetter(int[] nums1, int[] nums2)
    {
        int i = 0; int j = 0;
        int m = nums1.Length;
        int n = nums2.Length;
        int count = 0;
        int indx1 = (m + n) / 2 - 1;
        int indx2 = (m+n) / 2;
        int indx1elem = int.MinValue;
        int indx2elem = int.MinValue;
        while(i < m && j < n)
        {
            if (nums1[i] < nums2[j])
            {
                if (count == indx1) indx1elem = nums1[i]; 
                if (count == indx2) indx2elem = nums1[i];
                count++;
                i++;
            }
            else
            {
                if (count == indx1) indx1elem = nums2[j];
                if (count == indx2) indx2elem = nums2[j];
                count++;
                j++;
            }
        }

        while(i < m)
        {
            if (count == indx1) indx1elem = nums1[i];
            if (count == indx2) indx2elem = nums1[i];
            count++;
            i++;
        }

        while (j < n)
        {
            if (count == indx1) indx1elem = nums2[j];
            if (count == indx2) indx2elem = nums2[j];
            count++;
            j++;
        }

        int total = m + n;
        if (total % 2 == 0)
        {
            return (indx1elem + indx2elem) / 2.0; 
        }
        else
        {
            return indx2elem;
        }
    }

    public double FindMedianSortedArraysOptimized(int[] nums1, int[] nums2)
    {
        int n1 = nums1.Length;
        int n2 = nums2.Length;
        if (n1 > n2) { return FindMedianSortedArraysOptimized(nums2, nums1); }
        int left = (n1 + n2 + 1) / 2;
        int low = 0; int high = n1;

        while (low <= high)
        {
            int mid1 = (low + high) / 2;
            int mid2 = left - mid1;
            int r1 = int.MaxValue; int r2 = int.MaxValue;
            int l1 = int.MinValue; int l2 = int.MinValue;
            if (mid1 < n1) { r1 = nums1[mid1]; }
            if (mid2 < n2) { r2 = nums2[mid2]; }
            if (mid1 - 1 >= 0) { l1 = nums1[mid1 - 1]; }
            if (mid2 - 1 >= 0) { l2 = nums2[mid2 - 1]; }
            if (l1 <= r2 && l2 <= r1)
            {
                if ((n1 + n2) % 2 == 1) { return Math.Max(l1, l2); }
                else { return (Math.Max(l1, l2) + Math.Min(r1, r2)) / 2.0; }
            }
            if (l1 > r2) { high = mid1 - 1; }
            else { low = mid1 + 1; }
        }
        return 0.0;
    }
}