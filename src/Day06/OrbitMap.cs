using System.Collections.Generic;

namespace AdventOfCode2019.Day06
{
    public class OrbitMap
    {
        public Dictionary<string, Node> Nodes { get; set; } = new Dictionary<string, Node>();

        public OrbitMap(string[] orbits)
        {
            foreach (var orbit in orbits)
            {
                (Node parent, Node child) nodes = ParseOrbit(orbit);

                MapNodes(nodes.parent, nodes.child);
            }
        }

        public int CountAllOrbits()
        {
            int orbitCount = 0;
            foreach (Node node in Nodes.Values)
            {
                orbitCount += CountOrbits(node);
            }

            return orbitCount;
        }

        (Node parent, Node child) ParseOrbit(string input)
        {
            var parent = new Node(input[0..3]);
            var child = new Node(input[4..7]);

            return (parent, child);
        }

        void MapNodes(Node parent, Node child)
        {
            if(!Nodes.ContainsKey(parent.Id))
            {
                Nodes.Add(parent.Id, parent);
            }

            if(!Nodes.ContainsKey(child.Id))
            {
                Nodes.Add(child.Id, child);
            }

            Nodes[child.Id].ParentNode = Nodes[parent.Id];
        }

        int CountOrbits(Node node)
        {
            int nodes = 0;

            while(node.ParentNode != null)
            {
                node = node.ParentNode;
                nodes++;
            }

            return nodes;
        }
    }
}
