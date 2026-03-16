using System;
using System.Collections.Generic;
using System.Linq;
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


    }
}
