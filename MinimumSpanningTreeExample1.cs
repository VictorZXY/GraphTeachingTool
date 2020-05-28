using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTeachingTool
{
    class MinimumSpanningTreeExample1 : MinimumSpanningTreeExample
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        public MinimumSpanningTreeExample1(System.Windows.Forms.Panel panel) : base(panel)
        {
            CreateVertex("A", 57, 108);
            CreateVertex("B", 153, 32);
            CreateVertex("C", 181, 131);
            CreateVertex("D", 382, 32);
            CreateVertex("E", 566, 32);
            CreateVertex("F", 537, 303);
            CreateVertex("G", 272, 380);

            CreateEdge(0, 1, 8);
            CreateEdge(0, 2, 3);
            CreateEdge(0, 6, 12);
            CreateEdge(1, 2, 8);
            CreateEdge(1, 3, 9);
            CreateEdge(2, 3, 16);
            CreateEdge(2, 6, 15);
            CreateEdge(3, 4, 14);
            CreateEdge(3, 5, 14);
            CreateEdge(3, 6, 18);
            CreateEdge(4, 5, 15);
            CreateEdge(5, 6, 6);

            DrawLabelWeights();
        }
    }
}
