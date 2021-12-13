using System.Collections.Generic;
using System.Linq;

namespace AOC._2021
{
    class Day12 : TestClass, ITestClass
    {
        private const string Start = "start";
        private const string EndChar = "end";
        private const byte SmallCharsLimit = 96;

        private readonly Dictionary<string, HashSet<string>> _nodes;

        public Day12()
        {
            _input = @"CI-hb
IK-lr
vr-tf
lr-end
XP-tf
start-vr
lr-io
hb-qi
end-CI
tf-YK
end-YK
XP-lr
XP-vr
lr-EU
tf-CI
EU-vr
start-tf
YK-hb
YK-vr
start-EU
lr-CI
hb-XP
XP-io
tf-EU";

            var lines = GetVerticalSplitLines();
            _nodes = new Dictionary<string, HashSet<string>>();

            foreach(string line in lines)
            {
                string[] parts = line.Split('-');
                string src = parts[0];
                string dest = parts[1];

                AddPath(src, dest);
                AddPath(dest, src);
            }
        }


        public object Task1()
        {
            int pathCount = 0;
            var smallNodes = new HashSet<string>();
            foreach (string dest in _nodes[Start])
            {
                pathCount += FindPath1(smallNodes, dest);
            }

            return pathCount;
        }

        public object Task2()
        {
            int pathCount = 0;
            var path = new List<string> { Start };
            foreach (string dest in _nodes[Start])
            {
                pathCount += FindPath2(path, dest, usedSmallDouble: false);
            }

            return pathCount;
        }

        private void AddPath(string src, string dest)
        {
            if (!_nodes.TryGetValue(src, out HashSet<string> destinations))
            {
                destinations = new HashSet<string>();
                _nodes.Add(src, destinations);
            }
            destinations.Add(dest);
        }

        private int FindPath1(HashSet<string> smallNodes, string node)
        {
            if (node == EndChar)
            {
                return 1;
            }
            
            if(node == Start)
            {
                return 0;
            }

            bool isSmall = node[0] > SmallCharsLimit;
            if (isSmall) 
            {
                if (smallNodes.Contains(node))
                {
                    return 0;
                }

                smallNodes.Add(node);
            }

            int count = 0;
            foreach (string dest in _nodes[node])
            {
                count += FindPath1(smallNodes, dest);
            }

            if (isSmall)
            {
                smallNodes.Remove(node);
            }

            return count;
        }

        private int FindPath2(List<string> smallNodes, string node, bool usedSmallDouble)
        {
            if (node == EndChar)
            {
                return 1;
            }

            if(node == Start && smallNodes.Count > 0)
            {
                return 0; //We can't go back to the Start node
            }

            bool isSmall = node[0] > SmallCharsLimit;
            if (isSmall)
            {
                if (smallNodes.Contains(node))
                {
                    //Allow doubles of a single small character
                    if (usedSmallDouble)
                    {
                        return 0;
                    }

                    usedSmallDouble = true;
                }

                smallNodes.Add(node);
            }

            int count = 0;
            foreach (string dest in _nodes[node])
            {
                count += FindPath2(smallNodes, dest, usedSmallDouble);
            }

            if (isSmall)
            {
                smallNodes.RemoveAt(smallNodes.Count - 1);
            }

            return count;
        }
    }
}
