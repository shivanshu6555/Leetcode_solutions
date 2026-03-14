using Leetcode_solutions;
using System.Text;


string[] strs = [""];
int[] nums = new int[] {2};
Solution s = new();
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
ListNode l1 = new ListNode();
l1.val = 5;
ListNode l2 = new ListNode();
l1.val = 2;
ListNode l3 = new ListNode();
l1.val = 13;
ListNode l4 = new ListNode();
l1.val = 3;
ListNode l5 = new ListNode();
l1.val = 8;
l1.next = l2;
l2.next = l3;
l3.next = l4;
l4.next = l5;
ListNode head = new();
head.next = l1;
ListNode ans = s.RemoveNodes(head);
Console.WriteLine(ans.next);

public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        //edge cases
        if (strs.Length == 0 || strs.Length == 1) { return new List<IList<string>>(); }

        Dictionary<string, IList<string>> anagrams = new();
        foreach(var word in strs)
        {

            int[] charcount = new int[26];
            foreach (char c in word)
            {
                charcount[c - 'a']++;
            }

            StringBuilder sb = new();
            for(int i = 0; i < 26; i++){
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

        foreach(var i in count)
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
        return nums[0..(i+1)];
    }

    public int RemoveElement(int[] nums, int val)
    {
        int i = 0;
        
        for (int k = 0; k < nums.Length; k++)
        {
            if (nums[k] == val) { i = k; break; }
        }
        int j = i+1;
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
}