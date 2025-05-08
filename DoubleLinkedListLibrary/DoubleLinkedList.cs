using System;
using System.Collections;
using System.Collections.Generic;


namespace DoubleLinkedListLibrary
{
    /// <summary>
    /// Представляє вузол у двозв'язному списку.
    /// </summary>
    public class Node
    {
        public double Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(double value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
    
    /// <summary>
    /// Представляє двозв'язний список з елементами типу double.
    /// </summary>
    public class DoubleLinkedList : IEnumerable<double>
    {
        private Node head;

        /// <summary>
        /// Ініціалізує порожній список.
        /// </summary>
        public DoubleLinkedList()
        {
            head = null;
        }

        /// <summary>
        /// Додає елемент на початок списку.
        /// </summary>
        /// <param name="value"></param>
        public void AddToHead(double value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
        }

        /// <summary>
        /// Видаляє елемент за його індексом.
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void Delete(int index)
        {
            if (index<0)
            {
                throw new IndexOutOfRangeException("Index can`t be negative");
            }
            if( head == null)
            {
                throw new IndexOutOfRangeException("This list is empty");
            }
            if (index == 0)
            {
                head=head.Next;
                if(head!=null)
                {
                    head.Previous = null;
                }
                return;
            }
            Node current= head;
            int currentIndex = 0;
            while (current != null)
            {
                if(currentIndex==index)
                {
                    if(current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    if(current.Next!=null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    return;
                }
                current=current.Next;
                currentIndex++;
            }
            throw new IndexOutOfRangeException("Index is out of range");
        }

        /// <summary>
        /// Індексатор (отримує елемент за індексом).
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public double this[int index]
        {
            get
            {
                if (index<0)
                {
                    throw new IndexOutOfRangeException("Index can`t be negative");
                }
                Node current = head;
                int currentIndex = 0;
                while (current != null)
                {
                    if(currentIndex==index)
                    {
                        return current.Value;
                    }
                    current = current.Next;
                    currentIndex++;
                }
                throw new IndexOutOfRangeException("Index is out of range"); 
            }
        }

        /// <summary>
        /// Дозволяє перебирати елементи у списку.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<double> GetEnumerator()
        {
            Node current = head;
            while (current!=null)
            {
                yield return current.Value;
                current= current.Next;
            }
        }

        /// <summary>
        /// Знаходить перше входження елементу, менше за середнє значення.
        /// </summary>
        /// <returns></returns>
        public double? LessThanAverage()
        {
            if (head==null)
            {
                return null;
            }
            int count = 0;
            double sum = 0.0;
            Node current = head;
            while (current != null)
            {
                sum += current.Value;
                count++;
                current = current.Next;
            }
            double average = sum / count;
            current = head;
            while (current != null)
            {
                if(current.Value <average)
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return null;
        }
        
        /// <summary>
        /// Обчислює суму елементів, які розташовані після максимального.
        /// </summary>
        /// <returns></returns>
        public double SumAfterMax()
        {
            if(head==null)
            {
                return 0;
            }
            double max = double.MinValue;
            Node maxNode = null;
            Node current = head;
            while (current != null)
            {
                if (current.Value > max)
                {
                    max= current.Value;
                    maxNode = current;
                }
                current = current.Next;
            }
            if (maxNode == null)
            {
                return 0;
            }
            double sum = 0.0;
            current = maxNode.Next;
            while (current != null)
            {
                sum+= current.Value;
                current = current.Next;
            }
            return sum;
        }

        /// <summary>
        /// Повертає новий список з елементів, які більші за задане значення.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DoubleLinkedList GetGreaterThan(double value)
        {
            DoubleLinkedList newList = new DoubleLinkedList();
            Node current = head;
            while (current != null)
            {
                if(current.Value > value)
                {
                    newList.AddToHead(current.Value);
                }
                current= current.Next;
            }
            return newList;
        }

        /// <summary>
        /// Видаляє всі елементи, розташовані після максимального.
        /// </summary>
        public void DeleteBeforeMax()
        {
            if(head == null)
            {
                return;
            }
            double max=double.MinValue;
            Node maxNode = null;
            Node current = head;
            while(current != null)
            {
                if(current.Value > max)
                {
                    max=current.Value; 
                    maxNode= current;
                }
                current= current.Next;
            }
            if(maxNode!=null && maxNode!=head)
            {
                head = maxNode;
                head.Previous = null;
            }
        }

        /// <summary>
        /// Дозволяє перебирати елементи списку (foreach).
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
