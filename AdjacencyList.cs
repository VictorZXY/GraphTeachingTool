using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTeachingTool
{
    // Inheritance (Group A) is implemented here.
    public class AdjacencyList : Graph
    {
        // Graphs (Group A) are implemented here.
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Variables
        /// <summary>
        /// Represents a directed edge starting from the vertex.
        /// </summary>
        private struct AdjacentEdge
        {
            /// <summary>
            /// The vertex that this edge is directed to.
            /// </summary>
            public int vertex;
            /// <summary>
            /// The weight of this edge.
            /// </summary>
            public double weight;
        }

        // Lists (Group A) are implemented here.
        /// <summary>
        /// The adjacency list.
        /// </summary>
        private List<AdjacentEdge>[] list;
        #endregion

        #region Constructor
        /// <summary>
        /// Represents an adjacency list, with the size constrained by the maximum limit number of vertices.
        /// </summary>
        public AdjacencyList() : base()
        {
            this.list = new List<AdjacentEdge>[GetSize()];
            for (int i = 0; i < GetSize(); i++)
                this.list[i] = new List<AdjacentEdge>();
        }
        #endregion

        #region "Get" Functions
        /// <summary>
        /// Gets the weight of the directed edge between two selected vertices in the adjacency list.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <returns>
        /// The weight of the directed edge from vStart to vFinish. 
        /// If there is no edge between them (or at least one of them is not being used), returns 0.
        /// </returns>
        public override double GetEdge(int vStart, int vFinish)
        {
            foreach (AdjacentEdge edge in list[vStart])
                if (edge.vertex == vFinish)
                    return edge.weight;
            return 0;
        }

        /// <summary>
        /// Compares this instance with a specified adjacency list.
        /// </summary>
        /// <param name="matrix">The specified adjacency list that this instantce is to be compared with.</param>
        /// <returns>
        /// Returns NULL if the two adjaceny lists are identical.
        /// If the two adjacency lists are different, return a List<int> containing the indexes of different vertices.
        /// </returns>
        public List<int> CompareTo(AdjacencyList list)
        {
            bool isEqual = true;

            List<int> differentVertices = new List<int>();

            if (list == null)
            {
                isEqual = false;
                for (int v = 0; v < GetSize(); v++)
                    if (this.IsVertexExisting(v))
                        if (!differentVertices.Contains(v))
                            differentVertices.Add(v);
                differentVertices.Sort();
                return differentVertices;
            }

            for (int v = 0; v < GetSize(); v++)
            {
                if (this.IsVertexExisting(v) != list.IsVertexExisting(v))
                {
                    isEqual = false;
                    if (!differentVertices.Contains(v))
                        differentVertices.Add(v);
                }
            }
            for (int v = 0; v < GetSize(); v++)
            {
                if(this.list[v].Count()!=list.list[v].Count())
                {
                    isEqual = false;
                    if (!differentVertices.Contains(v))
                        differentVertices.Add(v);
                }
                foreach (AdjacentEdge edge in this.list[v])
                {
                    if(!list.list[v].Contains(edge))
                    {
                        isEqual = false;
                        if (!differentVertices.Contains(v))
                            differentVertices.Add(v);
                    }
                }
            }
            if (isEqual)
                return null;
            else
            {
                differentVertices.Sort();
                return differentVertices;
            }
        }
        #endregion

        #region "Set" Functions
        /// <summary>
        /// Sets value to the weight of an edge between two vertices in the adjacency list.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <param name="weight">The weight of the edge.</param>
        /// <param name="isDirected">Boolean status indicating whether the edge should be directed of undirected.</param>
        public override void SetEdge(int vStart, int vFinish, double weight, bool isDirected)
        {
            if (weight != 0)
            {
                AdjacentEdge edge1, edge2;
                AdjacentEdge edgeToRemove = new AdjacentEdge();
                edge1.vertex = vFinish;
                edge1.weight = weight;
                edge2.vertex = vStart;
                edge2.weight = weight;
                this.EnableVertex(vStart);
                this.EnableVertex(vFinish);
                foreach (AdjacentEdge edge in this.list[vStart])
                    if (edge.vertex == vFinish)
                        edgeToRemove = edge;
                this.list[vStart].Remove(edgeToRemove);
                this.list[vStart].Add(edge1);
                if (!isDirected)
                {
                    foreach (AdjacentEdge edge in this.list[vFinish])
                        if (edge.vertex == vStart)
                            edgeToRemove = edge;
                    this.list[vFinish].Remove(edgeToRemove);
                    this.list[vFinish].Add(edge2);
                }
            }
        }

        /// <summary>
        /// Removes an edge between two vertices in the adjacency list.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <param name="isDirected">bool status indicating whether the egde in both directions should be removed.</param>
        public override void RemoveEdge(int vStart, int vFinish, bool isDirected)
        {
            AdjacentEdge edgeToRemove = new AdjacentEdge();
            foreach (AdjacentEdge edge in this.list[vStart])
                if (edge.vertex == vFinish)
                    edgeToRemove = edge;
            this.list[vStart].Remove(edgeToRemove);
            if (!isDirected)
            {
                foreach (AdjacentEdge edge in this.list[vFinish])
                    if (edge.vertex == vStart)
                        edgeToRemove = edge;
                this.list[vFinish].Remove(edgeToRemove);
            }
        }
        #endregion
    }
}
