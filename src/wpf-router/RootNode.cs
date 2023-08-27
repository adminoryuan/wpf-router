using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace wpfRouter
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; }
        public bool IsEndOfWord { get; set; }

        public Page page { get; set; }

        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            IsEndOfWord = false;
        }
    }
}
