using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    class QueueNode
    {
        public string companyName;
        public string date;
        public string time;
        public QueueNode Next;
        public QueueNode(string name, string date, string time)
        {
            this.companyName = name;
            this.date = date;
            this.time = time;
            Next = null;
        }

    }
    class LinkedQueue
    {
        QueueNode head;

        //method that store data at end of list
        public void EnqueueData(string name, string date, string time)
        {
            QueueNode queue = new QueueNode(name, date, time);
            if (head == null)
            {
                head = queue;
            }
            else
            {
                QueueNode temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = queue;
            }
        }
        //display the queue data 
        public void Dequeue()
        {
            if (head == null)
            {
                Console.WriteLine("No record available since transaction does not initiated");
            }
            else
            {
                Console.WriteLine("===========Transaction detail==========");
                QueueNode temp = head;
                while (temp != null)
                {
                    Console.WriteLine("Company {0} \nDate:{1}\nTime:{2}", temp.companyName, temp.date, temp.time);
                    temp = temp.Next;
                    Console.WriteLine("=================================================");
                }
            }
        }
    }
}
    

