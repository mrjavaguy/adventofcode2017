using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils.BinaryTree
{
    public class Tree<T>
    {

        public Tree(T value, Tree<T> left = default(Tree<T>), Tree<T> right = default(Tree<T>))
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }

        public Tree<T> Left { get; }
        public Tree<T> Right { get; }

        public T Value { get; }

        public static Tree<T> Empty => default(Tree<T>);

        public Tree<T> AddLeftTree(Tree<T> tree)
        {
            return new Tree<T>(this.Value, tree, this.Right);
        }

        public Tree<T> AddRightTree(Tree<T> tree)
        {
            return new Tree<T>(this.Value, this.Left, tree);
        }

        public IEnumerable<T> Preorder()
        {
            var stack = new Stack<Tree<T>>();
            stack.Push(this);

            while (stack.Any())
            {
                var tree = stack.Pop();
                yield return tree.Value;
                if (tree.Right != Empty)
                {
                    stack.Push(tree.Right);
                }
                if (tree.Left != Empty)
                {
                    stack.Push(tree.Left);
                }
            }
        }

        public IEnumerable<T> Inorder()
        {
            var stack = new Stack<Tree<T>>();
            var node = this;

            while (node != Empty)
            {
                stack.Push(node);
                node = node.Left;
            }

            while (stack.Any())
            {

                // visit the top node
                node = stack.Pop();
                yield return node.Value;
                if (node.Right != Empty)
                {
                    node = node.Right;

                    // the next node to be visited is the leftmost
                    while (node != Empty)
                    {
                        stack.Push(node);
                        node = node.Left;
                    }
                }
            }
        }

        public IEnumerable<T> Postorder()
        {
            var stack1 = new Stack<Tree<T>>();
            var stack2 = new Stack<Tree<T>>();

            stack1.Push(this);

            while (stack1.Any())
            {
                var tree = stack1.Pop();
                stack2.Push(tree);

                if (tree.Left != Empty)
                {
                    stack1.Push(tree.Left);
                }
                if (tree.Right != Empty)
                {
                    stack1.Push(tree.Right);
                }
            }

            while (stack2.Any())
            {
                var tree = stack2.Pop();
                yield return tree.Value;
            }
        }

        public IEnumerable<T> LevelOrder()
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Any())
            {
                var tree = queue.Dequeue();
                yield return tree.Value;
                if (tree.Left != Empty)
                {
                    queue.Enqueue(tree.Left);
                }
                if (tree.Right != Empty)
                {
                    queue.Enqueue(tree.Right);
                }
            }
        }
    }
}
