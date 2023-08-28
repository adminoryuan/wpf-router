using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfRouter.compents;

namespace wpf_router.core
{
    public class Trie
    {
        private TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        public void Insert(string url,AbstComponent compent)
        {
            TrieNode node = root;
            foreach (char c in url)
            {
                if (!node.Children.ContainsKey(c))
                {
                    node.Children[c] = new TrieNode();
                }
                node = node.Children[c];
            }
            node.compent = compent;
        }

        public AbstComponent Search(string url)
        {
            TrieNode node = SearchPrefix(url);
            return  node.compent;
        }

        public bool StartsWith(string prefix)
        {
            TrieNode node = SearchPrefix(prefix);
            return node != null;
        }

        private TrieNode SearchPrefix(string prefix)
        {
            TrieNode node = root;
            foreach (char c in prefix)
            {
                if (node.Children.ContainsKey(c))
                {
                    node = node.Children[c];
                }
                else
                {
                    return null;
                }
            }
            return node;
        }
    }

}
