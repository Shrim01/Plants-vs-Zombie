using UnityEngine;

namespace BinaryTree
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public int Damage { get; set; }
        public int Reload { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;

        }
    }
}