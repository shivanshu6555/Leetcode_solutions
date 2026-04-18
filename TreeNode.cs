using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_solutions
{
    public class TreeNode
    {
        public int value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int value = 0, TreeNode Left = null, TreeNode Right = null)
        {
            this.value = value;
            this.Left = Left;
            this.Right = Right;
        }
    }
}
