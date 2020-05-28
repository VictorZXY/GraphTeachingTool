using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTeachingTool
{
    class ShortestPathExample2 : ShortestPathExample
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        public ShortestPathExample2(System.Windows.Forms.Panel panel) : base(panel)
        {
            CreateVertex('A', 20, 189);
            CreateVertex('B', 242, 34);
            CreateVertex('C', 500, 34);
            CreateVertex('D', 242, 344);
            CreateVertex('E', 500, 344);

            CreateDirectedEdge(0, 1, 10);
            CreateDirectedEdge(0, 3, 5);
            CreateDirectedEdge(1, 2, 1);
            CreateDirectedEdge(1, 3, 2);
            CreateDirectedEdge(2, 4, 4);
            CreateDirectedEdge(3, 1, 3);
            CreateDirectedEdge(3, 2, 9);
            CreateDirectedEdge(3, 4, 2);
            CreateDirectedEdge(4, 0, 7);
            CreateDirectedEdge(4, 2, 6);

            DrawLabelWeights();
        }
    }
}
