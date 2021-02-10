using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{        
    class Graph
    {

        List<Vertex> Vertices = new List<Vertex>();
        List<Edges> Edges = new List<Edges>();
        public bool[] _explored;
        public int VertexCount => Vertices.Count;
        public int EdgesCount => Edges.Count;
        public int[,] _graph;
        public void AddVertex(Vertex ver)
        {
            Vertices.Add(ver);
        }
        public void SetMatrix(int[,] matr)
        {
            _graph = new int[Vertices.Count, Vertices.Count];
            _graph = matr;
            _explored = new bool[Vertices.Count];
        }
        public void AddEdge(Vertex from, Vertex FromTo)
        {
            var edge = new Edges(from, FromTo);
            Edges.Add(edge);
        }
        public Graph()
        {
        }
        public int[,] GetMatrix()
        {
            var matrix = new int[Vertices.Count, Vertices.Count];

            foreach (var edge in Edges)
            {
                var row = edge.From.Number;
                var colum = edge.FromTo.Number;
                matrix[row, colum] = edge.Wight;
                matrix[colum, row] = edge.Wight;
            }
            return matrix;
        }
        public void ArrayFalse()
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                _explored[i] = false;
            }
        }
        public void DFS(int start)
        {
            start++;
            _explored[start] = true;         
            for (int i = 0; i < Vertices.Count; i++)
            {
                if ((_graph[start, i] != 0) && (!_explored[i]))                    
                {
                    Console.Write($" {start + 1} -> {i+1};");
                    DFS(i-1); 
                }
            }
        }        
        public void BFS(int start)
        {            
            ArrayFalse();
            Console.WriteLine();
            var chek = 0;
            start++;
            Console.WriteLine($"Поиск в ширину:");
            Console.WriteLine($"Начало из вершины {start + 1}");
            _explored[start] = true;
            chek++;
            var queue = new Queue<int>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                var j = queue.Dequeue();
                _explored[j] = true;
                Console.WriteLine($" В вершине {j+1}");
                for (int i = 0; i < Vertices.Count; i++)
                {
                    if ((_graph[j, i] != 0) && (!_explored[i]))
                    {
                        Console.WriteLine($"Переходы в вершину {i+1}");
                        _explored[i] = true;
                        chek++;
                        queue.Enqueue(i);
                    }
                }
                if(chek == Vertices.Count)
                {
                    Console.WriteLine($"Обход завершен");
                    return;
                }
            }
        }
    }
        



}
