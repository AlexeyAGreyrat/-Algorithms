using System;

namespace Lab2
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void Show();
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }
    public class LinkedList : ILinkedList
    {
        private int count = 0;
        private Node Next;
        private Node Prev;
        public void AddNode(int value)
        {
            var node = new Node { Value = value };
            if (Next == null)
                Next = node;
            else
            {
                Prev.NextNode = node;
                node.PrevNode = Prev;
            }
            Prev = node;
            count++;
        }

        public void AddNodeAfter(Node node, int value)
        {
            var newNext = node.NextNode;
            if (node.NextNode == null)
            {
                AddNode(value);
                return;
            }
            var newPrev = node.NextNode.PrevNode; 
            var newNode = new Node { Value = value };
            newNode.NextNode = newNext;
            newNode.PrevNode = newPrev;
            node.NextNode.PrevNode = newNode;
            node.NextNode = newNode;
            count++;
        }

        public Node FindNode(int searchValue)
        {
            var currentNode = Next;

            while (currentNode != null)
            {
                if (currentNode.Value == searchValue)
                    return currentNode;

                currentNode = currentNode.NextNode;
            }

            return null;
        }

        public int GetCount()
        {
            return count;
        }

        public void RemoveNode(int index)
        {
            if(Next == null)
            {                
                return;
            }
            var currentNode = Next;
            var i = 1;
            while (i < index)
            {
                currentNode = currentNode.NextNode;
                i++;
            }
            RemoveNode(currentNode);
        }

        public void RemoveNode(Node node)
        {
            if (Next == null)            
                return;            
            var newNext = node.NextNode;
            var newPrev = node.PrevNode;
            //ex
            if (node.PrevNode == null && node.NextNode == null)
            {
                Next = null;
                count--;
                return;
            }
            //head
            if (node.PrevNode == null)
            {
                Next = newNext;
                Next.PrevNode = null;
                count--;
                return;
            }
            //tail
            if (node.NextNode == null)
            {
                Prev = newPrev;
                Prev.NextNode = null;
                count--;
                return;
            }
            else
            {
                node.NextNode.PrevNode = newPrev;
                node.PrevNode.NextNode = newNext;
                count--;
                return;
            }
        }
        public void Show()
        {
            if(Next==null)
            {
                Console.WriteLine("Список пуст");
                return;
            }    
            var node = Next;
            var i = 1;
            while (node.NextNode != null)
                {
                    Console.WriteLine($"№{i} -  Элемент {node.Value} ");
                    node = node.NextNode;
                    i++;
                }
            Console.WriteLine($"№{i} -  Элемент {node.Value} ");
            
        }
    }
}
