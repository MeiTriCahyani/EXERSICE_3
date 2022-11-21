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
        public void addNote() //add a node in the list 
        {
            int rollNo;
            string nm;
            Console.Write("\n Enter the roll number of the student:");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n Enter the roll name of the student");
            nm = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = rollNo;
            newnode.name = nm;

            // if the node to be inserted is the first node
            if (LAST != null || rollNo <= LAST.rollNumber)
            {
                if ((LAST != null) && (rollNo <= LAST.rollNumber))
                {
                    Console.WriteLine();
                    return;

                }
                newnode.next = LAST;
                LAST = newnode;
                return;

            }

            Node previous, current;
            previous = LAST;
            current = LAST;

            while ((current != null) && (rollNo >= current.rollNumber))
            {
                if (rollNo == current.rollNumber)
                {
                    Console.WriteLine();
                    return;
                }
                previous.next = current;
                previous.next = newnode;
            }
            newnode.next = current;
            previous.next = newnode;
        }
      
        public bool delNode(int rollNo)
        {
            Node previouse, current;
            previouse = current = null;
            if (Search(rollNo, ref previouse, ref current) == false)
                return false;
            previouse.next = current.next;
            if (current == LAST)
                LAST = LAST.next;
            return true;
        }

        public bool Search(int rollNo,ref Node previous,ref Node current)
        //searches for the specified node
        {
            for(previous = current= LAST.next; current !=LAST; previous= current,current=current.next)
            {
                if (rollNo==current.rollNumber)
                    return (true);  //returns true if the node is found

            }
            if (rollNo == LAST.rollNumber) //if the node is present at the end
                return true;
            else
                return (false); // returns false if the node is not found

        }
        public bool listEmpty()
        {
            if(LAST == null)
                return true ;
            else
                return false ;
        }

        public void traverse() //travers all the nodes of the list
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\n Records in the list are:\n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber+""+ currentNode.name+"\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + "" + LAST.name + "\n");
            }
        }
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
                Console.WriteLine("\n The forst record in the list is:\n\n" + LAST.next.rollNumber + "" + LAST.next.name);
        }
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a records in the list");
                    Console.WriteLine("2. Delete a records from the list");
                    Console.WriteLine("2. View all the records in the list");
                    Console.WriteLine("3. Search for a record in the list");
                    Console.WriteLine("4. Display the first record in the list");
                    Console.WriteLine("5. Exit");
                    Console.Write("\nEnter your choice (1-4):");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\n List is empty");
                                    break;
                                }
                                Console.WriteLine(" Enter the roll number of" +
                                    " the student whose record is to be delete");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("\n Record not found.");
                                else
                                    Console.WriteLine("Record with roll number" +
                                        +rollNo + "Deleted");
                            }
                            break ;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\n List is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("n Enter the roll number of the student whose record is to be searched:");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\n Record not found");
                                else
                                {
                                    Console.WriteLine("\n Record found");
                                    Console.WriteLine("\n Roll number:" + curr.rollNumber);
                                    Console.WriteLine("\n Name:" + curr.name);
                                }

                            }
                            break;
                        case '5':
                            {
                                obj.firstNode();

                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
    


}
