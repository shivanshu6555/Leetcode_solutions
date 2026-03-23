using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_solutions
{
    internal class Recursion
    {
        //sum of n numbers using recursion
        public int Sumofnumbers(int n)
        {
            if(n == 1) { return 1; }
            return n + (Sumofnumbers(n - 1));
        }

        //print name 5 times
        
        public void PrintName(int n)
        {

            if (n == 0) { return; }
            Console.WriteLine("shivanshu");
            PrintName(n-1);


        }

        //print linearly from 1 to n
        public void PrintLinearly(int i ,int n)
        {
            if(i > n) {  return ; }
            Console.WriteLine(i);
            PrintLinearly(i+1,n);

        }

        //print from n to 1 without -ve
        public void PrintDec(int i, int n)
        {
            if(i > n) { return; }
            PrintDec(i + 1, n);
            Console.WriteLine(i);
        }

        //sum of all natural numbers
        public int Sum(int n)
        {
           if(n == 1) { return 1; }
            return n + Sum(n - 1);
            Console.WriteLine(n);
        }

        //reverse an array usingrecursion
        public int[] Reverse(int[] arr,int l, int r)
        {
            if(l >= r) { return arr; }
            (arr[l], arr[r]) = (arr[r], arr[l]);
            return Reverse(arr, l + 1, r - 1);
        }

        //reverse witohout using left and right pointer
        public void reversearray(int[] arr, int n, int i)
        {
            if (i >= n / 2) { return; }
            (arr[i], arr[n - i - 1]) = (arr[n - i - 1], arr[i]);
            reversearray(arr, n, i+1);
        }
        public void reverse(int[] arr, int n)
        {
            int i = 0;
            reversearray(arr, n, i);
            foreach(int j in arr)
            {
                Console.WriteLine(j);
            }
        }

        //fibonacci using recursion
        public int Fib(int n)
        {
            if (n == 0 || n == 1) { return n; }
            return Fib(n - 1) + Fib(n - 2);
        }


        //finding palindrome using reversing from recursion
        public StringBuilder Reverse(StringBuilder s, int i, int n)
        {
            if (i >= n / 2) { return s; }
            (s[i], s[n - i - 1]) = (s[n - i - 1], s[i]);
            return Reverse(s, i + 1, n);
        }
        public bool IsPalindrome(string s)
        {
            int i = 0; 
            string result = new string(s.Where(c => char.IsLetter(c) || char.IsNumber(c)).ToArray()).ToLower();
            StringBuilder s1 = new StringBuilder(result);
            int n = s1.Length;
            string reverse = (Reverse(s1, i, n)).ToString();
            if (result == reverse)
            {
                return true;
            }
            else { return false; }
        }

        //subsequence using recursion 
        public List<List<int>> FindSubsequence(int[] arr)
        {
            int n = arr.Length;
            List<List<int>> allSubsequences = new();
            List<int> result = new();
            Subswquencewithrec(arr, result, allSubsequences, n, 0);
            return allSubsequences;
        }

        public void Subswquencewithrec(int[] arr, List<int> result, List<List<int>> allsubs, int n, int i)
        {
            if(i >= n) { allsubs.Add(new List<int>(result)); return; }
            result.Add(arr[i]);
            Subswquencewithrec(arr, result,allsubs ,n, i + 1);
            result.Remove(arr[i]);
            Subswquencewithrec(arr, result,allsubs ,n, i + 1);
        }

        //subsequence sum = k using recursion
        public List<List<int>> SumofSubsequence(int[] arr, int k)
        {
            List<List<int>> result = new();
            List<int> cal = new();
            findsubsequencewithsum(arr, result, cal, arr.Length, 0, 0, k);
            return result;
        }

        public void findsubsequencewithsum(int[] arr, List<List<int>> result, List<int> cal, int n,int i, int sum, int k)
        {
            if (i == n)
            {
                if (sum == k)
                {
                    result.Add(new List<int>(cal));
                }
                return;
            }
            cal.Add(arr[i]);
            sum += arr[i];
            findsubsequencewithsum(arr, result, cal, n, i + 1,sum, k);
            cal.Remove(arr[i]);
            sum -= arr[i];
            findsubsequencewithsum(arr, result, cal, n, i + 1, sum, k);
        }



    }
}
