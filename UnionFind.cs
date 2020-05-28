using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTeachingTool
{
    class UnionFind
    {
        // Linked list maintenance (Group A) is implemented here
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Variables
        private int vertex, leader, prev, head, tail, count;
        #endregion

        #region Constructor
        /// <summary>
        /// Represents a vertex in Union-Find structure
        /// This is used for Kruskal's algorithm.
        /// </summary>
        public UnionFind() { }
        #endregion

        #region "Get" Functions
        public int GetVertex()
        {
            return this.vertex;
        }

        public int GetLeader()
        {
            return this.leader;
        }

        public int GetPrev()
        {
            return this.prev;
        }

        public int GetHead()
        {
            return this.head;
        }

        public int GetTail()
        {
            return this.tail;
        }

        public int GetCount()
        {
            return this.count;
        }
        #endregion

        #region "Set" Functions
        public void SetVertex(int newVertex)
        {
            this.vertex = newVertex;
        }

        public void SetLeader(int newLeader)
        {
            this.leader = newLeader;
        }

        public void SetPrev(int newPrev)
        {
            this.prev = newPrev;
        }

        public void SetHead(int newHead)
        {
            this.head = newHead;
        }

        public void SetTail(int newTail)
        {
            this.tail = newTail;
        }

        public void SetCount(int newCount)
        {
            this.count = newCount;
        }
        #endregion
    }
}
