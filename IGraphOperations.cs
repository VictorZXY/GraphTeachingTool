using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTeachingTool
{
    // Interface (Group A) is implemented here.
    public interface IGraphOperations
    {
        /// <summary>
        /// Gets the size of the graph.
        /// </summary>
        int GetSize();

        /// <summary>
        /// Determines whether a vertex is being used in the graph.
        /// </summary>
        /// <param name="vertex">The vertex to be checked.</param>
        /// <returns>Returns TRUE if vertex is being used in the graph.</returns>
        bool IsVertexExisting(int vertex);

        /// <summary>
        /// Gets the name of the vertex from its index in the graph.
        /// </summary>
        /// <param name="index">The index of the vertex.</param>
        string GetVertexName(int index);

        /// <summary>
        /// Gets the index of the vertex from its name in the graph.
        /// </summary>
        /// <param name="vertexName">The name of the vertex.</param>
        int GetVertexIndex(string vertexName);

        /// <summary>
        /// Gets the number of vertices that are used in the graph.
        /// </summary>
        int Count();

        /// <summary>
        /// Gets the weight of the directed edge between two selected vertices in the graph.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <returns>
        /// Returns The weight of the directed edge from vStart to vFinish. 
        /// If there is no edge between them (or at least one of them is not being used), returns 0.
        /// </returns>
        double GetEdge(int vStart, int vFinish);

        /// <summary>
        /// Determines whether there is an directed edge between two selected vertices in the graph.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <returns>Returns TRUE if there is an directed edge from vStart to vFinish.</returns>
        bool ContainsEdge(int vStart, int vFinish);

        /// <summary>
        /// Determines if the graph is undirected.
        /// </summary>
        /// <returns>Returns TRUE if the graph is undirected.</returns>
        bool CheckUndirectedGraph();

        /// <summary>
        /// Sets value to the weight of an edge between two vertices in the graph.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <param name="weight">The weight of the edge.</param>
        /// <param name="isDirected">Boolean status indicating whether the edge should be directed of undirected.</param>
        void SetEdge(int vStart, int vFinish, double weight, bool isDirected);

        /// <summary>
        /// Sets a default value (1) to the weight of an edge between two vertices in the graph.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <param name="isDirected">Boolean status indicating whether the edge should be directed of undirected.</param>
        void SetEdge(int vStart, int vFinish, bool isDirected);

        /// <summary>
        /// Sets value to the weight of a directed edge between two vertices in the graph.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <param name="weight">The weight of the edge.</param>
        void SetDirectedEdge(int vStart, int vFinish, double weight);

        /// <summary>
        /// Sets a default value (1) to the weight of a directed edge between two vertices in the graph.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        void SetDirectedEdge(int vStart, int vFinish);

        /// <summary>
        /// Sets value to the weight of an undirected edge between two vertices in the graph.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <param name="weight">The weight of the edge.</param>
        void SetUndirectedEdge(int vStart, int vFinish, double weight);

        /// <summary>
        /// Sets a default value (1) to the weight of an undirected edge between two vertices in the graph.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        void SetUndirectedEdge(int vStart, int vFinish);

        /// <summary>
        /// Removes an edge between two vertices in the graph.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <param name="isDirected">bool status indicating whether the egde in both directions should be removed.</param>
        void RemoveEdge(int vStart, int vFinish, bool isDirected);

        /// <summary>
        /// Removes an edge in one direction specified by the starting and the finishing vertices in the graph.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        void RemoveDirectedEdge(int vStart, int vFinish);

        /// <summary>
        /// Removes an edge in both directions between two vertices in the graph.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        void RemoveUndirectedEdge(int vStart, int vFinish);

        /// <summary>
        /// Sets the status of whether a vertex is being used in the graph. 
        /// </summary>
        /// <param name="vertex">The selected vertex.</param>
        /// <param name="existState">The status to be set on the vertex.</param>
        void SetVertexExistance(int vertex, bool existState);

        /// <summary>
        /// Indicates that a vertex is being used in the graph.
        /// </summary>
        /// <param name="vertex">The selected vertex.</param>
        void EnableVertex(int vertex);

        /// <summary>
        /// Indicates that a vertex is not being used in the graph.
        /// </summary>
        /// <param name="vertex">The selected vertex.</param>
        void DisableVertex(int vertex);

        /// <summary>
        /// Removes a vertex from the graph, along with all the edges connected to it.
        /// </summary>
        /// <param name="vertex">The vertex to be removed.</param>
        void RemoveVertex(int vertex);

        /// <summary>
        /// Clears the graph.
        /// </summary>
        void Clear();
    }
}
