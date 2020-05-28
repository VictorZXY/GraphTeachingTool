using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTeachingTool
{
    public abstract class Graph : IGraphOperations, IGraphAlgorithms
    {
        // Graphs (Group A) are implemented here.

        #region Variables
        /// <summary>
        /// The maximum limit number of vertices.
        /// </summary>
        private const int SIZE = 26;

        /// <summary>
        /// Array of Boolean status indicating whether each of the vertices is being used in the graph.
        /// </summary>
        private bool[] vertexExisting;
        #endregion

        #region Constructor
        /// <summary>
        /// Represents a graph in general, with the size constrained by the maximum limit number of vertices.
        /// </summary>
        public Graph()
        {
            this.vertexExisting = new bool[SIZE];
        }
        #endregion

        #region "Get" Functions
        /// <summary>
        /// Gets the size of the graph.
        /// </summary>
        public int GetSize()
        {
            return SIZE;
        }

        /// <summary>
        /// Determines whether a vertex is being used in the graph.
        /// </summary>
        /// <param name="vertex">The vertex to be checked.</param>
        /// <returns>Returns TRUE if vertex is being used in the graph.</returns>
        public bool IsVertexExisting(int vertex)
        {
            return this.vertexExisting[vertex];
        }

        /// <summary>
        /// Gets the name of the vertex from its index in the graph.
        /// </summary>
        /// <param name="vertexIndex">The index of the vertex.</param>
        public string GetVertexName(int vertexIndex)
        {
            return "vertex" + Convert.ToChar(vertexIndex + 'A').ToString();
        }

        /// <summary>
        /// Gets the index of the vertex from its name in the graph.
        /// </summary>
        /// <param name="vertexName">The name of the vertex.</param>
        public int GetVertexIndex(string vertexName)
        {
            return Convert.ToChar(vertexName.Trim("vertex".ToCharArray())) - 'A';
        }

        /// <summary>
        /// Gets the number of vertices that are used in the graph.
        /// </summary>
        public int Count()
        {
            int count = 0;
            foreach (bool existing in this.vertexExisting)
                count += existing ? 1 : 0;
            return count;
        }

        /// <summary>
        /// Gets the weight of the directed edge between two selected vertices in the graph.
        /// This method is to be overridden by the subclasses.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <returns>
        /// Returns he weight of the directed edge from vStart to vFinish. 
        /// If there is no edge between them (or at least one of them is not being used), returns 0.
        /// </returns>
        public abstract double GetEdge(int vStart, int vFinish);

        /// <summary>
        /// Determines whether there is an directed edge between two selected vertices in the graph.
        /// This method is to be overridden by the subclasses.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <returns>Returns TRUE if there is an directed edge from vStart to vFinish.</returns>
        public bool ContainsEdge(int vStart, int vFinish)
        {
            return GetEdge(vStart, vFinish) != 0;
        }

        /// <summary>
        /// Determines if the graph is undirected.
        /// </summary>
        /// <returns>Returns TRUE if the graph is undirected.</returns>
        public bool CheckUndirectedGraph()
        {
            for (int v1 = 0; v1 < GetSize() - 1; v1++)
                for (int v2 = v1 + 1; v2 < GetSize(); v2++)
                    if (GetEdge(v1, v2) != GetEdge(v2, v1))
                        return false;
            return true;
        }
        #endregion

        #region "Set" Functions
        // Polymorphism (Group A) is implemented here.
        /// <summary>
        /// Sets value to the weight of an edge between two vertices in the graph.
        /// This method is to be overridden by the subclasses.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <param name="weight">The weight of the edge.</param>
        /// <param name="isDirected">Boolean status indicating whether the edge should be directed of undirected.</param>
        public abstract void SetEdge(int vStart, int vFinish, double weight, bool isDirected);

        // Polymorphism (Group A) is implemented here.
        /// <summary>
        /// Sets a default value (1) to the weight of an edge between two vertices in the graph.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <param name="isDirected">Boolean status indicating whether the edge should be directed of undirected.</param>
        public void SetEdge(int vStart, int vFinish, bool isDirected)
        {
            SetEdge(vStart, vFinish, 1, isDirected);
        }

        // Polymorphism (Group A) is implemented here.
        /// <summary>
        /// Sets value to the weight of a directed edge between two vertices in the graph.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <param name="weight">The weight of the edge.</param>
        public void SetDirectedEdge(int vStart, int vFinish, double weight)
        {
            SetEdge(vStart, vFinish, weight, true);
        }

        // Polymorphism (Group A) is implemented here.
        /// <summary>
        /// Sets a default value (1) to the weight of a directed edge between two vertices in the graph.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        public void SetDirectedEdge(int vStart, int vFinish)
        {
            SetEdge(vStart, vFinish, 1, true);
        }

        // Polymorphism (Group A) is implemented here.
        /// <summary>
        /// Sets value to the weight of an undirected edge between two vertices in the graph.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <param name="weight">The weight of the edge.</param>
        public void SetUndirectedEdge(int vStart, int vFinish, double weight)
        {
            SetEdge(vStart, vFinish, weight, false);
        }

        // Polymorphism (Group A) is implemented here.
        /// <summary>
        /// Sets a default value (1) to the weight of an undirected edge between two vertices in the graph.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        public void SetUndirectedEdge(int vStart, int vFinish)
        {
            SetEdge(vStart, vFinish, 1, false);
        }

        /// <summary>
        /// Removes an edge between two vertices in the graph.
        /// This method is to be overridden by the subclasses.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <param name="isDirected">bool status indicating whether the egde in both directions should be removed.</param>
        public abstract void RemoveEdge(int vStart, int vFinish, bool isDirected);

        /// <summary>
        /// Removes an edge in one direction specified by the starting and the finishing vertices in the graph.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        public void RemoveDirectedEdge(int vStart, int vFinish)
        {
            RemoveEdge(vStart, vFinish, true);
        }

        /// <summary>
        /// Removes an edge in both directions between two vertices in the graph.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        public void RemoveUndirectedEdge(int vStart, int vFinish)
        {
            RemoveEdge(vStart, vFinish, false);
        }

        /// <summary>
        /// Sets the status of whether a vertex is being used in the graph. 
        /// </summary>
        /// <param name="vertex">The selected vertex.</param>
        /// <param name="existState">The status to be set on the vertex.</param>
        public void SetVertexExistance(int vertex, bool existState)
        {
            this.vertexExisting[vertex] = existState;
        }

        /// <summary>
        /// Indicates that a vertex is being used in the graph.
        /// </summary>
        /// <param name="vertex">The selected vertex.</param>
        public void EnableVertex(int vertex)
        {
            SetVertexExistance(vertex, true);
        }

        /// <summary>
        /// Indicates that a vertex is not being used in the graph.
        /// </summary>
        /// <param name="vertex">The selected vertex.</param>
        public void DisableVertex(int vertex)
        {
            SetVertexExistance(vertex, false);
        }

        /// <summary>
        /// Removes a vertex from the graph, along with all the edges connected to it.
        /// </summary>
        /// <param name="vertex">The vertex to be removed.</param>
        public void RemoveVertex(int vertex)
        {
            for (int v = 0; v < GetSize(); v++)
                this.RemoveUndirectedEdge(v, vertex);
            DisableVertex(vertex);
        }

        /// <summary>
        /// Clears the graph.
        /// </summary>
        public void Clear()
        {
            for (int v = 0; v < this.GetSize(); v++)
                RemoveVertex(v);
        }
        #endregion

        #region Algorithms
        // Graph/Tree Traversal (Group A) is implemented here.
        // Complex user-defined algorithm (Group A) is implemented here.
        /// <summary>
        /// Returns the total weight of the Minimum Spanning Tree of the graph, using Prim's algorithm.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        public double Prim(int vStart)
        {
            if (!CheckUndirectedGraph())
            {
                MessageBox.Show("Error in finding the Minimum Spanning Tree: \nThe graph is not undirected!");
                return -1;
            }
            else
            {
                // Lists (Group A) are implemented here.
                List<int> visitedVertices = new List<int>();
                List<int> remainingVertices = new List<int>();
                double weightMST = 0;
                for (int i = 0; i < GetSize(); i++)
                    if (IsVertexExisting(i))
                        remainingVertices.Add(i);
                visitedVertices.Add(vStart);
                remainingVertices.Remove(vStart);
                while (remainingVertices.Any())
                {
                    double min = Double.MaxValue;
                    int newVertex = -1;
                    foreach (int i in visitedVertices)
                        foreach (int j in remainingVertices)
                            if (ContainsEdge(i, j) && GetEdge(i, j) < min)
                            {
                                min = GetEdge(i, j);
                                newVertex = j;
                            }
                    visitedVertices.Add(newVertex);
                    remainingVertices.Remove(newVertex);
                    weightMST += min;
                }
                return weightMST;
            }
        }

        // Trees (Group A) are implemented here.
        // Graph/Tree Traversal (Group A) is implemented here.
        // Complex user-defined algorithm (Group A) is implemented here.
        /// <summary>
        /// Returns the the Minimum Spanning Tree of the graph, in the form of adjacency matrix, using Prim's algorithm.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        public AdjacencyMatrix Prim_GetTree_Matrix(int vStart)
        {
            if (!CheckUndirectedGraph())
            {
                MessageBox.Show("Error in finding the Minimum Spanning Tree: \nThe graph is not undirected!");
                return null;
            }
            else
            {
                List<int> visitedVertices = new List<int>();
                List<int> remainingVertices = new List<int>();
                AdjacencyMatrix outputMST = new AdjacencyMatrix();
                for (int i = 0; i < this.GetSize(); i++)
                    if (this.IsVertexExisting(i))
                        remainingVertices.Add(i);
                visitedVertices.Add(vStart);
                remainingVertices.Remove(vStart);
                while (remainingVertices.Any())
                {
                    double min = Double.MaxValue;
                    int newVStart = -1, newVFinish = -1;
                    foreach (int i in visitedVertices)
                        foreach (int j in remainingVertices)
                            if (ContainsEdge(i, j) && GetEdge(i, j) < min)
                            {
                                min = GetEdge(i, j);
                                newVStart = i;
                                newVFinish = j;
                            }
                    visitedVertices.Add(newVFinish);
                    remainingVertices.Remove(newVFinish);
                    outputMST.SetUndirectedEdge(newVStart, newVFinish, min);
                }
                return outputMST;
            }
        }

        // Trees (Group A) are implemented here.
        // Graph/Tree Traversal (Group A) is implemented here.
        // Complex user-defined algorithm (Group A) is implemented here.
        /// <summary>
        /// Returns the the Minimum Spanning Tree of the graph, in the form of adjacency list, using Prim's algorithm.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        public AdjacencyList Prim_GetTree_List(int vStart)
        {
            if (!CheckUndirectedGraph())
            {
                MessageBox.Show("Error in finding the Minimum Spanning Tree: \nThe graph is not undirected!");
                return null;
            }
            else
            {
                List<int> visitedVertices = new List<int>();
                List<int> remainingVertices = new List<int>();
                AdjacencyList outputMST = new AdjacencyList();
                for (int i = 0; i < this.GetSize(); i++)
                    if (this.IsVertexExisting(i))
                        remainingVertices.Add(i);
                visitedVertices.Add(vStart);
                remainingVertices.Remove(vStart);
                while (remainingVertices.Any())
                {
                    double min = Double.MaxValue;
                    int newVStart = -1, newVFinish = -1;
                    foreach (int i in visitedVertices)
                        foreach (int j in remainingVertices)
                            if (ContainsEdge(i, j) && GetEdge(i, j) < min)
                            {
                                min = GetEdge(i, j);
                                newVStart = i;
                                newVFinish = j;
                            }
                    visitedVertices.Add(newVFinish);
                    remainingVertices.Remove(newVFinish);
                    outputMST.SetUndirectedEdge(newVStart, newVFinish, min);
                }
                return outputMST;
            }
        }

        /// <summary>
        /// Represents a directed edge.
        /// </summary>
        private struct Edge
        {
            /// <summary>
            /// The starting vertex.
            /// </summary>
            public int vStart;
            /// <summary>
            /// The finishing vertex.
            /// </summary>
            public int vFinish;
            /// <summary>
            /// The weight of the edge.
            /// </summary>
            public double weight;
        }

        /// <summary>
        /// A list of all edges in the graph.
        /// </summary>
        private List<Edge> edges = new List<Edge>();

        /// <summary>
        /// Copies all the edges in the graph into the list.
        /// </summary>
        private void InitialiseEdges()
        {
            Edge temp;
            for (int i = 0; i < GetSize() - 1; i++)
                for (int j = i + 1; j < GetSize(); j++)
                    if (ContainsEdge(i, j))
                    {
                        temp.vStart = i;
                        temp.vFinish = j;
                        temp.weight = GetEdge(i, j);
                        edges.Add(temp);
                    }
        }

        // Recursive algorithm (Group A) is implemented here
        // O(nlogn) sort (Group A) is implemented here.
        /// <summary>
        /// Sorts the edges in ascending order of weights.
        /// </summary>
        private void QuickSort(List<Edge> A, int left, int right)
        {
            int i, j;
            double x;
            Edge temp;
            i = left; j = right; x = A[(left + right) / 2].weight;
            do
            {
                while (i <= right && A[i].weight < x) i++;
                while (j >= left && A[j].weight > x) j--;
                if (i <= j)
                {
                    temp = A[i]; A[i] = A[j]; A[j] = temp;
                    i++; j--;
                }
            } while (i <= j);
            if (left < j) QuickSort(A, left, j);
            if (i < right) QuickSort(A, i, right);
        }

        // Lists (Group A) are implemented here.
        /// <summary>
        /// A Union-Find set of all the vertices.
        /// </summary>
        private List<UnionFind> unionFindVertices = new List<UnionFind>();

        // Linked list maintenance (Group A) is implemented here
        /// <summary>
        /// Copies and initialises all the vertices into the Union-Find structural list.
        /// </summary>
        private void InitialiseUnionFind()
        {
            for (int vertex = 0; vertex < GetSize(); vertex++)
                if (IsVertexExisting(vertex))
                {
                    unionFindVertices.Add(new UnionFind());
                    unionFindVertices[unionFindVertices.Count() - 1].SetVertex(vertex);
                    unionFindVertices[unionFindVertices.Count() - 1].SetLeader(vertex);
                    unionFindVertices[unionFindVertices.Count() - 1].SetPrev(-1);
                    unionFindVertices[unionFindVertices.Count() - 1].SetHead(vertex);
                    unionFindVertices[unionFindVertices.Count() - 1].SetTail(vertex);
                    unionFindVertices[unionFindVertices.Count() - 1].SetCount(1);
                }
        }

        /// <summary>
        /// Finds a vertex in the Union-Find set.
        /// </summary>
        /// <param name="vertex">The desired vertex.</param>
        /// <returns>
        /// Returns the desired vertex, if found in the Union-Find set.
        /// If such vertex is not found, returns a default Union-Find structural vertex.
        /// </returns>
        private UnionFind Find(int vertex)
        {
            foreach (UnionFind v in unionFindVertices)
                if (v.GetVertex() == vertex)
                    return v;
            return new UnionFind();
        }

        // Linked list maintenance (Group A) is implemented here
        /// <summary>
        /// Absorbs the elements of set X into set Y in the Union-Find structure.
        /// </summary>
        private void Update(int setX, int setY)
        {
            int index = unionFindVertices[setX].GetTail();
            do
            {
                unionFindVertices[index].SetLeader(setY);
                index = unionFindVertices[index].GetPrev();
            } while (index != -1);
            unionFindVertices[unionFindVertices[setY].GetHead()].SetPrev(unionFindVertices[setX].GetTail());
            unionFindVertices[setY].SetHead(unionFindVertices[setX].GetHead());
            unionFindVertices[setY].SetCount(unionFindVertices[setY].GetCount() + unionFindVertices[setX].GetCount());
        }

        // Linked list maintenance (Group A) is implemented here
        /// <summary>
        /// Unites two sets in the union-find structure.
        /// </summary>
        private void Union(int setX, int setY)
        {
            if (unionFindVertices[setX].GetCount() < unionFindVertices[setY].GetCount())
                Update(setX, setY);
            else Update(setY, setX);
        }

        // Graph/Tree Traversal (Group A) is implemented here.
        // Complex user-defined algorithm (Group A) is implemented here.
        /// <summary>
        /// Returns the total weight of the Minimum Spanning Tree of the graph, using Kruskal's algorithm.
        /// </summary>
        public double Kruskal()
        {
            if (!CheckUndirectedGraph())
            {
                MessageBox.Show("Error in finding the Minimum Spanning Tree: \nThe graph is not undirected!");
                return -1;
            }
            else
            {
                double weightMST = 0;
                int count = 0;
                InitialiseEdges();
                InitialiseUnionFind();
                QuickSort(edges, 0, edges.Count - 1);
                while (count < Count() - 1)
                {
                    if (Find(edges[0].vStart).GetLeader() != Find(edges[0].vFinish).GetLeader())
                    {
                        count++;
                        weightMST += edges[0].weight;
                        Union(Find(edges[0].vStart).GetLeader(), Find(edges[0].vFinish).GetLeader());
                    }
                    edges.RemoveAt(0);
                }
                return weightMST;
            }
        }

        // Trees (Group A) are implemented here.
        // Graph/Tree Traversal (Group A) is implemented here.
        // Complex user-defined algorithm (Group A) is implemented here.
        /// <summary>
        /// Returns the the Minimum Spanning Tree of the graph, in the form of adjacency matrix, using Kruskal's algorithm.
        /// </summary>
        public AdjacencyMatrix Kruskal_GetTree_Matrix()
        {
            if (!CheckUndirectedGraph())
            {
                MessageBox.Show("Error in finding the Minimum Spanning Tree: \nThe graph is not undirected!");
                return null;
            }
            else
            {
                AdjacencyMatrix outputMST = new AdjacencyMatrix();
                int count = 0;
                InitialiseEdges();
                InitialiseUnionFind();
                QuickSort(edges, 0, edges.Count - 1);
                while (count < Count() - 1)
                {
                    if (Find(edges[0].vStart).GetLeader() != Find(edges[0].vFinish).GetLeader())
                    {
                        count++;
                        outputMST.SetUndirectedEdge(edges[0].vStart, edges[0].vFinish, edges[0].weight);
                        Union(Find(edges[0].vStart).GetLeader(), Find(edges[0].vFinish).GetLeader());
                    }
                    edges.RemoveAt(0);
                }
                return outputMST;
            }
        }

        // Trees (Group A) are implemented here.
        // Graph/Tree Traversal (Group A) is implemented here.
        // Complex user-defined algorithm (Group A) is implemented here.
        /// <summary>
        /// Returns the the Minimum Spanning Tree of the graph, in the form of adjacency list, using Kruskal's algorithm.
        /// </summary>
        public AdjacencyList Kruskal_GetTree_List()
        {
            if (!CheckUndirectedGraph())
            {
                MessageBox.Show("Error in finding the Minimum Spanning Tree: \nThe graph is not undirected!");
                return null;
            }
            else
            {
                AdjacencyList outputMST = new AdjacencyList();
                int count = 0;
                InitialiseEdges();
                InitialiseUnionFind();
                QuickSort(edges, 0, edges.Count - 1);
                while (count < Count() - 1)
                {
                    if (Find(edges[0].vStart).GetLeader() != Find(edges[0].vFinish).GetLeader())
                    {
                        count++;
                        outputMST.SetUndirectedEdge(edges[0].vStart, edges[0].vFinish, edges[0].weight);
                        Union(Find(edges[0].vStart).GetLeader(), Find(edges[0].vFinish).GetLeader());
                    }
                    edges.RemoveAt(0);
                }
                return outputMST;
            }
        }

        /// <summary>
        /// Represents a vertex maintaining necessary properties for Dijkstra's algorithm.
        /// </summary>
        private struct DijkstraVertex
        {
            public double distance;
            public int prev;
        }

        /// <summary>
        /// A list of all the vertices maintaining necessary properties for Dijkstra's algorithm.
        /// </summary>
        private DijkstraVertex[] dijkstraMap = new DijkstraVertex[26];

        /// <summary>
        /// Initialises the shortest-path estimates and predecessors.
        /// </summary>
        /// <param name="vStart">The source vertex.</param>
        private void InitialiseSingleSource(int vStart)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                dijkstraMap[i].distance = Double.MaxValue;
                dijkstraMap[i].prev = -1;
            }
            dijkstraMap[vStart].distance = 0;
        }

        /// <summary>
        /// Improves the shortest path between two vertices, if possible.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        private void RelaxEdge(int vStart, int vFinish)
        {
            if (ContainsEdge(vStart, vFinish) &&
                dijkstraMap[vFinish].distance > dijkstraMap[vStart].distance + GetEdge(vStart, vFinish))
            {
                dijkstraMap[vFinish].distance = dijkstraMap[vStart].distance + GetEdge(vStart, vFinish);
                dijkstraMap[vFinish].prev = vStart;
            }
        }

        // Graph/Tree Traversal (Group A) is implemented here.
        // Complex user-defined algorithm (Group A) is implemented here.
        /// <summary>
        /// Returns the shortest distance between two vertices of the graph, using Dijkstra's algorithm.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        public double Dijkstra(int vStart, int vFinish)
        {
            InitialiseSingleSource(vStart);
            // Lists (Group A) are implemented here.
            List<int> permanetVertices = new List<int>();
            List<int> tempraryVertices = new List<int>();
            for (int i = 0; i < GetSize(); i++)
                tempraryVertices.Add(i);
            while (tempraryVertices.Count != 0)
            {
                int minTemporaryVertex = -1;
                double min = Double.MaxValue;
                foreach (int i in tempraryVertices)
                    if (dijkstraMap[i].distance <= min)
                    {
                        minTemporaryVertex = i;
                        min = dijkstraMap[i].distance;
                    }
                tempraryVertices.Remove(minTemporaryVertex);
                permanetVertices.Add(minTemporaryVertex);
                for (int i = 0; i < GetSize(); i++)
                    RelaxEdge(minTemporaryVertex, i);
            }
            if (dijkstraMap[vFinish].distance == Double.MaxValue)
                return -1;
            else return dijkstraMap[vFinish].distance;
        }

        // Graph/Tree Traversal (Group A) is implemented here.
        // Complex user-defined algorithm (Group A) is implemented here.
        /// <summary>
        /// Returns the shortest path between two vertices of the graph, using Dijkstra's algorithm.
        /// </summary>
        /// <param name="vStart">The starting vertex.</param>
        /// <param name="vFinish">The finishing vertex.</param>
        /// <returns>A list of all the vertices within the shortest path, including the starting and finishing vertices.</returns>
        public List<int> Dijkstra_GetShortestPath(int vStart, int vFinish)
        {
            InitialiseSingleSource(vStart);
            // Lists (Group A) are implemented here.
            List<int> permanetVertices = new List<int>();
            List<int> tempraryVertices = new List<int>();
            List<int> shortestPath = new List<int>();
            for (int i = 0; i < GetSize(); i++)
                tempraryVertices.Add(i);
            while (tempraryVertices.Count != 0)
            {
                int minTemporaryVertex = 0;
                double min = Double.MaxValue;
                foreach (int i in tempraryVertices)
                    if (dijkstraMap[i].distance <= min)
                    {
                        minTemporaryVertex = i;
                        min = dijkstraMap[i].distance;
                    }
                tempraryVertices.Remove(minTemporaryVertex);
                permanetVertices.Add(minTemporaryVertex);
                for (int i = 0; i < GetSize(); i++)
                    RelaxEdge(minTemporaryVertex, i);
            }
            if (dijkstraMap[vFinish].distance == Double.MaxValue)
                return null;
            else
            {
                int i = vFinish;
                shortestPath.Add(i);
                while (dijkstraMap[i].prev != -1)
                {
                    shortestPath.Add(dijkstraMap[i].prev);
                    i = dijkstraMap[i].prev;
                }
                shortestPath.Reverse();
                return shortestPath;
            }
        }
        #endregion
    }
}
