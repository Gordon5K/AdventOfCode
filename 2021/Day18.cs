using System;
using System.Collections.Generic;
using static AOC._2021.Day18;

namespace AOC._2021
{
    public class Day18 : TestClass, ITestClass
    {
        private readonly string[] _readings;
        public Day18()
        {
            _input = @"[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
[[[5,[2,8]],4],[5,[[9,9],0]]]
[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
[[[[5,4],[7,7]],8],[[8,3],8]]
[[9,3],[[9,9],[6,[4,9]]]]
[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]";

            _readings = GetVerticalSplitLines();
        }

        private const char OpenChar = '[';
        private const char CloseChar = ']';
        private const char Comma = ',';

        public object Task1()
        {
            BranchNode tree = BuildTree(_readings[0]);

            for (int i = 1; i < _readings.Length; i++)
            {
                var toAdd = BuildTree(_readings[i]);
                tree = tree.Add(toAdd);

                tree.ReduceExpression();
            }

            return tree.CalculateMagnitude();
        }

        public object Task2()
        {
            int max = 0;
            for (int i = 0; i < _readings.Length; i++)
            {
                for (int j = 0; j < _readings.Length; j++)
                {
                    if (i == j) continue;

                    var tree1 = BuildTree(_readings[i]);
                    var tree2 = BuildTree(_readings[j]);

                    var sum = tree1.Add(tree2);
                    sum.ReduceExpression();

                    int magnitude = sum.CalculateMagnitude();

                    if(magnitude > max)
                    {
                        max = magnitude;
                    }
                }
            }

            return max;
        }

        public interface ITreeNode
        {
            bool IsValue { get; }
        };

        public class BranchNode : ITreeNode
        {
            public ITreeNode Left { get; set; }

            public ITreeNode Right { get; set; }

            public bool IsValue => false;

            public BranchNode() { }

            public BranchNode(int left, int right)
            {
                Left = new LeafNode(left);
                Right = new LeafNode(right);
            }
        }

        public class LeafNode : ITreeNode
        {
            public int Value { get; set; }

            public bool IsValue => true;

            public LeafNode(int value)
            {
                this.Value = value;
            }
        }

        private static BranchNode BuildTree(ReadOnlySpan<char> expr)
        {
            List<char> literals = new();

            bool TryParseLiterals(out int value)
            {
                if(literals.Count > 0)
                {
                    value = int.Parse(new string(literals.ToArray()));
                    literals.Clear();
                    return true;
                }
                value = 0;
                return false;
            }

            BranchNode node = null;
            ITreeNode childNode = null;
            Stack<BranchNode> expressionStack = new();

            int l = 0;
            while (l < expr.Length)
            {
                int literalValue;
                switch (expr[l])
                {
                    case OpenChar:

                        if (node != null)
                        {
                            expressionStack.Push(node);
                        }
                        node = new BranchNode();

                        break;

                    case Comma:

                        if(TryParseLiterals(out literalValue))
                        {
                            node.Left = new LeafNode(literalValue);
                        }
                        else if(childNode != null)
                        {
                            node.Left = childNode;
                            childNode = null;
                        }

                        break;

                    case CloseChar:

                        if(TryParseLiterals(out literalValue))
                        {
                            node.Right = new LeafNode(literalValue);
                        }
                        else if(childNode != null)
                        {
                            node.Right = childNode;
                            childNode = null;
                        }

                        if (expressionStack.Count > 0)
                        {
                            childNode = node;
                            node = expressionStack.Pop();
                        }

                        break;

                    default:

                        literals.Add(expr[l]);

                        break;
                }

                l++;
            }

            return node;
        }
    }

    public static class Day18TreeExtensions
    {
        public static BranchNode Add(this ITreeNode src, ITreeNode add)
        {
            return new BranchNode()
            {
                Left = src,
                Right = add
            };
        }

        public static void ReduceExpression(this ITreeNode node)
        {

            bool hasReduced = true;
            while (hasReduced)
            {
                hasReduced = false;
                bool keepExploding = true;

                while (keepExploding)
                {
                    BranchNode toExplode = null, parent = null;
                    LeafNode explodeLeft = null, explodeRight = null;

                    FindNodeToExplode(node, depth: 0, ref toExplode, ref parent, ref explodeLeft, ref explodeRight);

                    if (toExplode != null)
                    {
                        if (parent.Left == toExplode)
                        {
                            parent.Left = new LeafNode(0);
                        }
                        else if (parent.Right == toExplode)
                        {
                            parent.Right = new LeafNode(0);
                        }

                        if (explodeLeft != null)
                        {
                            explodeLeft.Value += (toExplode.Left as LeafNode).Value;
                        }
                        if (explodeRight != null)
                        {
                            explodeRight.Value += (toExplode.Right as LeafNode).Value;
                        }

                        hasReduced = true;
                    }
                    else
                    {
                        keepExploding = false;
                    }
                }

                LeafNode toSplit = null;
                BranchNode splitParent = null;

                FindNodeToSplit(node, ref toSplit, ref splitParent);

                if (toSplit != null)
                {
                    var (left, right) = SplitNumber(toSplit.Value);

                    if (splitParent.Left == toSplit)
                    {
                        splitParent.Left = new BranchNode(left, right);
                    }
                    else if (splitParent.Right == toSplit)
                    {
                        splitParent.Right = new BranchNode(left, right);
                    }

                    hasReduced = true;
                }
            }
        }

        private static bool FindNodeToExplode(ITreeNode node, int depth,
            ref BranchNode toExplode,
            ref BranchNode parent, ref LeafNode explodeLeft, ref LeafNode explodeRight)
        {
            if (node is LeafNode leafNode)
            {
                if (toExplode == null)
                {
                    explodeLeft = leafNode;
                }
                else
                {
                    explodeRight = leafNode;
                }
            }
            else if (node is BranchNode branchNode)
            {
                if (toExplode == null && depth == 4)
                {
                    toExplode = branchNode;
                    return true;
                }
                else
                {
                    bool foundLeft = FindNodeToExplode(
                            branchNode.Left, depth + 1, 
                            ref toExplode, ref parent, ref explodeLeft, ref explodeRight);

                    bool foundRight = explodeRight == null &&
                        FindNodeToExplode(branchNode.Right, depth + 1, 
                            ref toExplode, ref parent, ref explodeLeft, ref explodeRight);

                    if (foundLeft || foundRight)
                    {
                        if (parent == null)
                        {
                            parent = branchNode;
                        }
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool FindNodeToSplit(ITreeNode node, ref LeafNode toSplit, ref BranchNode parentNode)
        {
            if (node is LeafNode leafNode)
            {
                if (leafNode.Value >= 10)
                {
                    toSplit = leafNode;
                    return true;
                }
            }
            else if (node is BranchNode branchNode)
            {
                var foundLeft = FindNodeToSplit(branchNode.Left, ref toSplit, ref parentNode);
                var foundRight = !foundLeft && FindNodeToSplit(branchNode.Right, ref toSplit, ref parentNode);

                if(foundLeft || foundRight)
                {
                    if (parentNode == null)
                    {
                        parentNode = branchNode;
                    }
                    return true;
                }
            }
            return false;
        }

        public static (int left, int right) SplitNumber(this int num)
        {
            decimal half = (decimal)num / 2;
            return (left: (int)Math.Floor(half), right: (int)Math.Ceiling(half));
        }

        public static int CalculateMagnitude(this ITreeNode node)
        {
            if (node is BranchNode branchNode)
            {
                int left, right;
                if (branchNode.Left is LeafNode lNode)
                {
                    left = 3 * lNode.Value;
                }
                else
                {
                    left = 3 * CalculateMagnitude(branchNode.Left);
                }

                if (branchNode.Right is LeafNode rNode)
                {
                    right = 2 * rNode.Value;
                }
                else
                {
                    right = 2 * CalculateMagnitude(branchNode.Right);
                }
                return left + right;
            }
            return 0;
        }
    }

}
