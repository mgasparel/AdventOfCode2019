using System.Collections.Generic;

namespace AdventOfCode2019.Day06
{
    public class OrbitalTransfer
    {
        OrbitMap orbitMap;

        public OrbitalTransfer(OrbitMap orbitMap)
        {
            this.orbitMap = orbitMap;
        }

        public int CalculateTransferDistance(string source, string destination)
        {
            Node sourceNode = orbitMap.Nodes[source];
            Node destinationNode = orbitMap.Nodes[destination];

            List<Node> sourcePath = GetPathToCom(sourceNode);
            List<Node> destinationPath = GetPathToCom(destinationNode);

            Node intersection = GetFirstIntersection(sourcePath, destinationPath);

            int distance = CountDistance(sourceNode, intersection);
            distance += CountDistance(destinationNode, intersection);

            return distance;
        }


        Node GetFirstIntersection(List<Node> sourcePath, List<Node> destinationPath)
        {
            for (int s = 0; s < sourcePath.Count; s++)
            {
                for (int d = 0; d < destinationPath.Count; d++)
                {
                    if(sourcePath[s] == destinationPath[d])
                    {
                        return sourcePath[s];
                    }
                }
            }

            throw new System.Exception("Paths do not intersect!");
        }

        int CountDistance(Node nodeA, Node nodeB)
        {
            int nodes = 0;
            Node cursor = nodeA;

            while(cursor.ParentNode != null && cursor.ParentNode != nodeB)
            {
                nodes++;

                cursor = cursor.ParentNode;
            }

            return nodes;
        }


        List<Node> GetPathToCom(Node source)
        {
            var nodes = new List<Node>();
            Node cursor = source;

            while(cursor.ParentNode != null)
            {
                nodes.Add(cursor.ParentNode);
                cursor = cursor.ParentNode;
            }

            return nodes;
        }
    }
}
