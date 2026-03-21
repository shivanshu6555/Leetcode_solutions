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

        public int Fib(int n)
        {
            if (n == 0 || n == 1) { return n; }
            return Fib(n - 1) + Fib(n - 2);
        }


    }
}
