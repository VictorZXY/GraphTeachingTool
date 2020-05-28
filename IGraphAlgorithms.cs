using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTeachingTool
{
    // Interface (Group A) is implemented here.
    interface IGraphAlgorithms
    {
        /// <summary>
        /// Returns the total weight of the Minimum Spanning Tree of the graph, using Prim's algorithm.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        double Prim(int vStart);

        /// <summary>
        /// Returns the the Minimum Spanning Tree of the graph, in the form of adjacency matrix, using Prim's algorithm.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        AdjacencyMatrix Prim_GetTree_Matrix(int vStart);

        /// <summary>
        /// Returns the the Minimum Spanning Tree of the graph, in the form of adjacency list, using Prim's algorithm.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        AdjacencyList Prim_GetTree_List(int vStart);

        /// <summary>
        /// Returns the total weight of the Minimum Spanning Tree of the graph, using Kruskal's algorithm.
        /// </summary>
        double Kruskal();

        /// <summary>
        /// Returns the the Minimum Spanning Tree of the graph, in the form of adjacency matrix, using Kruskal's algorithm.
        /// </summary>
        AdjacencyMatrix Kruskal_GetTree_Matrix();

        /// <summary>
        /// Returns the the Minimum Spanning Tree of the graph, in the form of adjacency list, using Kruskal's algorithm.
        /// </summary>
        AdjacencyList Kruskal_GetTree_List();

        /// <summary>
        /// Returns the shortest distance between two vertices of the graph, using Dijkstra's algorithm.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        double Dijkstra(int vStart, int vFinish);

        /// <summary>
        /// Returns the shortest path between two vertices of the graph, using Dijkstra's algorithm.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <returns>A list of all the vertices within the shortest path, including the starting and finishing vertices.</returns>
        List<int> Dijkstra_GetShortestPath(int vStart, int vFinish);
    }
}
