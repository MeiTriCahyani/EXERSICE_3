using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXERSICE_3
{
    class Node
    {
        //Creates Nodes for the circular nexted list
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;
        public CircularList()
        {
            LAST = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
