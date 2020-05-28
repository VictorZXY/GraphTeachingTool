using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphTeachingTool
{
    public partial class FormTopicOverview : Form
    {
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        #region Variables
        /// <summary>
        /// The name of the selected algorithm.
        /// </summary>
        readonly string algorithm;

        /// <summary>
        /// A readonly dictionary of algorithm names.
        /// </summary>
        readonly Dictionary<string, string> algorithmNames = new Dictionary<string, string>();

        /// <summary>
        /// A readonly list of objectives for Prim's Minimum Spanning Tree Algorithm.
        /// </summary>
        readonly List<string> objectives_Prim = new List<string>();

        /// <summary>
        /// A readonly list of objectives for Kruskal's Minimum Spanning Tree Algorithm.
        /// </summary>
        readonly List<string> objectives_Kruskal = new List<string>();

        /// <summary>
        /// A readonly list of objectives for Dijkstra's Shortest Path Algorithm.
        /// </summary>
        readonly List<string> objectives_Dijkstra = new List<string>();

        /// <summary>
        /// A readonly dictionary of objectives for each algorithm.
        /// </summary>
        readonly Dictionary<string, List<string>> objectives = new Dictionary<string, List<string>>();

        /// <summary>
        /// A readobly list of prerequisites for algorithms.
        /// </summary>
        readonly List<string> prerequisites = new List<string>();

        /// <summary>
        /// A list of buttons for the example graphs.
        /// </summary>
        readonly List<Button> examples = new List<Button>();

        // External Step-by-Step Demonstration windows to be opened when requested.
        FormPrimOnGraph formPrimOnGraph;
        FormPrimOnMatrix formPrimOnMatrix;
        FormKruskal formKruskal;
        FormDijkstra formDijkstra;
        #endregion

        #region Constructor
        public FormTopicOverview(int accountID, string username, string accountName, string accountType, string algorithm)
        {
            InitializeComponent();

            // Initialise readonly lists and dictionaries
            algorithmNames.Add("Prim", "Prim's Minimum Spanning Tree Algorithm");
            algorithmNames.Add("Kruskal", "Kruskal's Minimum Spanning Tree Algorithm");
            algorithmNames.Add("Dijkstra", "Dijkstra's Shortest Path Algorithm");

            objectives_Prim.Add("Understand the concept of a Minimum Spanning Tree.");
            objectives_Prim.Add("Understand the types of problems that can be solved by finding a Minimum Spanning Tree.");
            objectives_Prim.Add("Solve network optimisation problems using Prim's Algorithm.");
            objectives.Add("Prim", objectives_Prim);
            objectives_Kruskal.Add("Understand the concept of a Minimum Spanning Tree.");
            objectives_Kruskal.Add("Understand the types of problems that can be solved by finding a Minimum Spanning Tree.");
            objectives_Kruskal.Add("Solve network optimisation problems using Kruskal's Algorithm.");
            objectives.Add("Kruskal", objectives_Kruskal);
            objectives_Dijkstra.Add("Understand the Shortest Path problem.");
            objectives_Dijkstra.Add("Solve shortest path problems using Dijkstra's Algorithm.");
            objectives.Add("Dijkstra", objectives_Dijkstra);

            prerequisites.Add("Understand and use the language of graphs and networks.");
            prerequisites.Add("Understand and use the types of graphs, including simple graphs, simple-connected graphs, directed graphs, undirected graphs and trees.");

            // Initialise example graphs
            this.buttonExample1.Click += new EventHandler(ButtonExample_Click);
            this.buttonExample2.Click += new EventHandler(ButtonExample_Click);
            examples.Add(this.buttonExample1);
            examples.Add(this.buttonExample2);

            // Show account name on the account menu.
            this.accountMenu.accountID = accountID;
            this.accountMenu.username = username;
            this.accountMenu.labelAccountName.Text = accountName;
            this.accountMenu.accountType = accountType;
            this.algorithm = algorithm;

            // Show algorithm name, objectives and prerequisites.
            this.labelTopicOverview.Text += algorithmNames[this.algorithm] + "\n\n";
            this.labelTopicOverview.Text += "Objectives:\n\n";
            for (int i = 0; i < objectives[this.algorithm].Count; i++)
                this.labelTopicOverview.Text += "  - " + objectives[this.algorithm][i] + "\n";
            this.labelTopicOverview.Text += "\nPrerequisites:\n\n";
            foreach (string prerequisite in prerequisites)
                this.labelTopicOverview.Text += "  - " + prerequisite + "\n";
            this.labelTopicOverview.Location = new Point(24, (this.Height - this.labelTopicOverview.Height) / 2 - 26);

            // Show buttons for example graphs.
            if (this.algorithm == "Prim")
            {
                buttonAdditionalExample1.Visible = true;
                buttonAdditionalExample2.Visible = true;
                buttonExample1.Text = "Example 1 - Tabular version";
                buttonExample2.Text = "Example 2 - Graphical version";
            }
            else if (this.algorithm == "Dijkstra")
            {
                buttonExample1.Text = "Example 1 - Undirected graph";
                buttonExample2.Text = "Example 2 - Directed graph";
            }
        }
        #endregion

        #region Events
        private void ButtonExample_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            this.Hide();
            int exampleIndex = Convert.ToInt32((sender as Button).Text[8].ToString());
            if (this.algorithm == "Prim")
            {
                if ((sender as Button).Text.Contains("Graphical")) // Prim's algorithm on graph
                {
                    formPrimOnGraph = new FormPrimOnGraph(this.accountMenu.accountID, this.accountMenu.username, this.accountMenu.labelAccountName.Text, this.accountMenu.accountType, exampleIndex);
                    formPrimOnGraph.FormClosed += new FormClosedEventHandler(TeachingForms_FormClosed);
                    formPrimOnGraph.Show();
                }
                else // Prim's algorithm on table
                {
                    formPrimOnMatrix = new FormPrimOnMatrix(this.accountMenu.accountID, this.accountMenu.username, this.accountMenu.labelAccountName.Text, this.accountMenu.accountType, exampleIndex);
                    formPrimOnMatrix.FormClosed += new FormClosedEventHandler(TeachingForms_FormClosed);
                    formPrimOnMatrix.Show();
                }
            }
            else if (this.algorithm == "Kruskal") // Kruskal's algorithm
            {
                formKruskal = new FormKruskal(this.accountMenu.accountID, this.accountMenu.username, this.accountMenu.labelAccountName.Text, this.accountMenu.accountType, exampleIndex);
                formKruskal.FormClosed += new FormClosedEventHandler(TeachingForms_FormClosed);
                formKruskal.Show();
            }
            else // if (this.algorithm == "Dijkstra") // Dijkstra's algorithm
            {
                formDijkstra = new FormDijkstra(this.accountMenu.accountID, this.accountMenu.username, this.accountMenu.labelAccountName.Text, this.accountMenu.accountType, exampleIndex);
                formDijkstra.FormClosed += new FormClosedEventHandler(TeachingForms_FormClosed);
                formDijkstra.Show();
            }
        }

        private void TeachingForms_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            this.Show();
        }
        #endregion
    }
}
