using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    class Node
    {
        public StockUtilitty value { get; set; }
        public Node Next { get; set; }
        public Node(StockUtilitty stock)
        {
            this.value = stock;
            Next = null;
        }
    }
    public class StockLinkedList
    {
        private Node head;
        //public StockLinkedList(IEnumerable<T> collection);
        public StockLinkedList()
        {

        }
        public stockLinkedList(params StockUtilitty[] value)
        {
            foreach (StockUtilitty temp in value)
            {
                AddLast(temp);

            }
        }
        public void AddLast(StockUtilitty stock)
        {
            Node newNode = new Node(stock);
            if (head == null)
            {
                head = newNode;
            }

            else
            {
                Node temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = newNode;
            }

        }
        public int Count()
        {
            int count = 0;
            if (head != null)
            {
                Node temp = head;
                while (temp != null)
                {
                    count++;
                    temp = temp.Next;
                }
            }
            return count;
        }

        public StockUtilitty[] display()
        {
            int count = Count();
            StockUtilitty[] result = new StockUtilitty[count];
            int index = 0;
            Node temp = head;
            while (temp.Next != null)
            {
                result[index++] = temp.value;
                temp = temp.Next;
            }
            result[index] = temp.value;
            return result;
        }

        public void RemoveData(StockUtilitty stock)
        {
            Node temp = head;
            Node prev = null;
            if (temp != null && temp.value == stock)
            {
                head = temp.Next;

            }

            while (temp != null && temp.value != stock)
            {
                prev = temp;
                temp = temp.Next;
            }

            if (temp.value == stock)
            {
                prev.Next = temp.Next;
            }


        }

    }
}

