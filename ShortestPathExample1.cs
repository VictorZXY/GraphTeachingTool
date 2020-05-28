using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTeachingTool
{
    class ShortestPathExample1 : ShortestPathExample
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        public ShortestPathExample1(System.Windows.Forms.Panel panel) : base(panel)
        {
            CreateVertex('A', 27, 148);
            CreateVertex('B', 93, 22);
            CreateVertex('C', 191, 131);
            CreateVertex('D', 302, 22);
            CreateVertex('E', 506, 22);
            CreateVertex('F', 486, 293);
            CreateVertex('G', 262, 370);

            CreateUndirectedEdge(0, 1, 9);
            CreateUndirectedEdge(0, 2, 3);
            CreateUndirectedEdge(0, 6, 14);
            CreateUndirectedEdge(1, 2, 5);
            CreateUndirectedEdge(1, 3, 12);
            CreateUndirectedEdge(2, 3, 16);
            CreateUndirectedEdge(2, 6, 9);
            CreateUndirectedEdge(3, 4, 12);
            CreateUndirectedEdge(3, 5, 14);
            CreateUndirectedEdge(3, 6, 18);
            CreateUndirectedEdge(4, 5, 17);
            CreateUndirectedEdge(5, 6, 6);

            DrawLabelWeights();
        }
    }
}
