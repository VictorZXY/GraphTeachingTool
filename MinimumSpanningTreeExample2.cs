using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTeachingTool
{
    class MinimumSpanningTreeExample2 : MinimumSpanningTreeExample
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        public MinimumSpanningTreeExample2(System.Windows.Forms.Panel panel) : base(panel)
        {
            CreateVertex("A", 201, 52);
            CreateVertex("B", 443, 128);
            CreateVertex("C", 654, 306);
            CreateVertex("D", 443, 243);
            CreateVertex("E", 201, 243);
            CreateVertex("F", 443, 369);
            CreateVertex("G", 201, 369);
            CreateVertex("H", 52, 306);

            CreateEdge(0, 1, 10);
            CreateEdge(0, 3, 9);
            CreateEdge(0, 4, 10);
            CreateEdge(1, 2, 8);
            CreateEdge(1, 3, 5);
            CreateEdge(2, 3, 9);
            CreateEdge(2, 5, 10);
            CreateEdge(3, 4, 6);
            CreateEdge(3, 5, 7);
            CreateEdge(3, 6, 8);
            CreateEdge(4, 6, 9);
            CreateEdge(4, 7, 7);
            CreateEdge(5, 6, 5);
            CreateEdge(6, 7, 8);

            DrawLabelWeights();
        }
    }
}
