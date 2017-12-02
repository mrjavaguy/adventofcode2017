
namespace utilstests.BinaryTreeTests
{
    using System.Collections.Generic;
    using Utils.BinaryTree;
    using Xunit;

    public class TreeTests
    {
        //           1
        //          / \
        //         /   \
        //        /     \
        //       2       3
        //      / \     /
        //     4   5   6
        //   /       / \
        //  7       8   9

        Tree<int> tree = new Tree<int>(1, new Tree<int>(2, new Tree<int>(4, new Tree<int>(7)), new Tree<int>(5)), new Tree<int>(3, new Tree<int>(6, new Tree<int>(8), new Tree<int>(9))));

        [Fact]
        public void PreorderTest()
        {
            var expected = new List<int> { 1, 2, 4, 7, 5, 3, 6, 8, 9 };
            var actual = tree.Preorder();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InorderTest()
        {
            var expected = new List<int> { 7, 4, 2, 5, 1, 8, 6, 9, 3 };
            var actual = tree.Inorder();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PostorderTest()
        {
            var expected = new List<int> { 7, 4, 5, 2, 8, 9, 6, 3, 1 };
            var actual = tree.Postorder();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelorderTest()
        {
            var expected = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var actual = tree.LevelOrder();
            Assert.Equal(expected, actual);
        }
    }
}
