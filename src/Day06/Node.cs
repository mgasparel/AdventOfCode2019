using System.Collections.Generic;

namespace AdventOfCode2019.Day06
{
    public class Node
    {
        public string Id { get; set; }
        public Node ParentNode { get; set; }

        public Node(string id)
        {
            Id = id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
