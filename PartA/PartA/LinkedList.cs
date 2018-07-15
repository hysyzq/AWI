using System;
using System.Collections.Generic;

namespace PartA
{
    public class LinkedList
    {
        static void Main(string[] args)
        {
            Node head = BuildList("2,3,4,5,6,7,8,9,10,11");
            //Node head = BuildList("2,3,4");
            //Node head = BuildList("2,3,4,5,3,6,-1,a,v,3,5,6");

            int getNumber = 5;

            Node target = FindFromTail(head, getNumber);
            if (target != null)
            {
                Console.WriteLine(target.Value);
            }
            else
            {
                Console.WriteLine($"There are not enough elements in the list to get No.{getNumber} item from tail");
            }
            
            Console.ReadKey();
        }

        public static Node BuildList (string str)
        {
            Node head = null;
            Node temp = null;
            string[] items = str.Split(",");
            int value = 0;
            for(int i=0;i<items.Length;i++)
            {
                if(int.TryParse(items[i],out value))
                {
                    Node newNode = new Node() { Value = value };
                    if (head == null)
                    {
                        // first node
                        head = newNode;
                        temp = newNode;
                    }
                    else
                    {
                        // other nodes
                        temp.Next = newNode;
                        temp = newNode;
                    }
                }
            }
            return head;
        }

        public static Node FindFromTail (Node head,int num)
        {
            Node target = null;
            Node current = head;
            int gap = 0;
            // loop to the end of the list
            while (current.Next != null)
            {
                current = current.Next;
                gap++;
                // target the next node
                if (gap >= num-1)
                {
                    target = target==null?head: target.Next;
                    gap--;
                }
            }
            return target;
        }
        
    }


    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }
}
