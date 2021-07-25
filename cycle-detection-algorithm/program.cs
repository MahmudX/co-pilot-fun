using System;
using System.Collections.Generic;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        // Create a method implements Floyd's Tortoise and Hare algorithm
        // to find the shortest path between two nodes in a graph.
        static void FindShortestPath(int[] adj, int start, int end)
        {
            int n = adj.Length;
            int[] dist = new int[n];
            int[] path = new int[n];
            bool[] visited = new bool[n];
            int[] queue = new int[n];
            int head = 0, tail = 0;
            int i, u, v;
            int min = int.MaxValue;
            for (i = 0; i < n; i++)
            {
                dist[i] = int.MaxValue;
                path[i] = -1;
            }
            dist[start] = 0;
            queue[tail++] = start;
            visited[start] = true;
            while (head != tail)
            {
                u = queue[head++];
                if (u == end)
                {
                    break;
                }
                for (i = 0; i < n; i++)
                {
                    if (adj[u][i] != 0 && !visited[i])
                    {
                        v = i;
                        if (dist[u] + 1 < dist[v])
                        {
                            dist[v] = dist[u] + 1;
                            path[v] = u;
                            if (dist[v] < min)
                            {
                                min = dist[v];
                            }
                            queue[tail++] = v;
                            visited[v] = true;
                        }
                    }
                }
            }
            if (min == int.MaxValue)
            {
                Console.WriteLine("No path found.");
            }
            else
            {
                Console.WriteLine("Shortest path: ");
                for (i = end; i != start; i = path[i])
                {
                    Console.Write("{0} -> ", i);
                }
                Console.WriteLine(start);
            }
        }
    }
}
