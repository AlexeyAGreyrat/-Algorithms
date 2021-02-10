using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
         
        static void Main(string[] args)
        {            
            var graph = new Graph();            
            var v1 = new Vertex(0);
            var v2 = new Vertex(1);
            var v3 = new Vertex(2);
            var v4 = new Vertex(3);
            var v5 = new Vertex(4);
            var v6 = new Vertex(5);

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);


            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v2, v4);
            graph.AddEdge(v2, v5);
            graph.AddEdge(v3, v4);
            graph.AddEdge(v3, v6);
            graph.AddEdge(v4, v5);
            graph.AddEdge(v5, v6);

            var matrix = graph.GetMatrix();
            for (int i = 0; i < graph.VertexCount; i++)
            {
                for (int j = 0; j < graph.VertexCount; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            graph.SetMatrix(matrix);

            var start = 4;
            Console.WriteLine("Поиск в глубину:");
            Console.WriteLine($"Начало из вершины {start+1}");
            graph.ArrayFalse();
            graph.DFS(start-1);
            Console.WriteLine();            
            graph.BFS(start - 1);
        }        
    }
}
