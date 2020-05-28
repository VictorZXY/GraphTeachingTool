using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTeachingTool
{
    // Inheritance (Group A) is implemented here.
    public class AdjacencyMatrix : Graph
    {
        // Graphs (Group A) are implemented here.
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Variables
        /// <summary>
        /// The adjacency matrix.
        /// </summary>
        private double[,] map;
        #endregion

        #region Constructor
        /// <summary>
        /// Represents an adjacency matrix, with the size constrained by the maximum limit number of vertices.
        /// </summary>
        public AdjacencyMatrix() : base()
        {
            this.map = new double[GetSize(), GetSize()];
        }
        #endregion

        #region "Get" Functions
        /// <summary>
        /// Gets the weight of the directed edge between two selected vertices in the adjacency matrix.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <returns>
        /// The weight of the directed edge from vStart to vFinish. 
        /// If there is no edge between them (or at least one of them is not being used), returns 0.
        /// </returns>
        public override double GetEdge(int vStart, int vFinish)
        {
            return this.map[vStart, vFinish];
        }

        /// <summary>
        /// Compares this instance with a specified adjacency matrix.
        /// </summary>
        /// <param name="matrix">The specified adjacency matrix that this instantce is to be compared with.</param>
        /// <returns>
        /// Returns NULL if the two adjaceny matrices are identical.
        /// If the two adjacency matrices are different, return a List<int> containing the indexes of different vertices.
        /// </returns>
        public List<int> CompareTo(AdjacencyMatrix matrix)
        {
            bool isEqual = true;

            List<int> differentVertices = new List<int>();

            if (matrix == null)
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
                if (this.IsVertexExisting(v) != matrix.IsVertexExisting(v))
                {
                    isEqual = false;
                    if (!differentVertices.Contains(v))
                        differentVertices.Add(v);
                }
            }
            for (int row = 0; row < GetSize(); row++)
            {
                for (int col = 0; col < GetSize(); col++)
                {
                    if (!this.GetEdge(row, col).Equals(matrix.GetEdge(row, col)))
                    {
                        isEqual = false;
                        if (!differentVertices.Contains(row))
                            differentVertices.Add(row);
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
        /// Sets value to the weight of an edge between two vertices in the adjacency matrix.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <param name="weight">The weight of the edge.</param>
        /// <param name="isDirected">Boolean status indicating whether the edge should be directed of undirected.</param>
        public override void SetEdge(int vStart, int vFinish, double weight, bool isDirected)
        {
            if (weight != 0)
            {
                this.EnableVertex(vStart);
                this.EnableVertex(vFinish);
                if (isDirected)
                    this.map[vStart, vFinish] = weight;
                else
                {
                    this.map[vStart, vFinish] = weight;
                    this.map[vFinish, vStart] = weight;
                }
            }
        }

        /// <summary>
        /// Removes an edge between two vertices in the adjacency matrix.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <param name="isDirected">bool status indicating whether the egde in both directions should be removed.</param>
        public override void RemoveEdge(int vStart, int vFinish, bool isDirected)
        {
            if (isDirected)
                this.map[vStart, vFinish] = 0;
            else
            {
                this.map[vStart, vFinish] = 0;
                this.map[vFinish, vStart] = 0;
            }
        }
        #endregion
    }
}
