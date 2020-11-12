using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2A2022_Projet_IA.Resources;

namespace _2A2022_Projet_IA
{
    public partial class Form1 : Form
    {
        public static int CasNavigation;
        public static int[] PointDepart;
        public static int[] PointArrivee;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CasNavigation = 1;
            PointDepart = new[] {100, 200};
            PointArrivee = new[] {200, 100};

            StartNavigation();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CasNavigation = 2;
            PointDepart = new[] { 100, 200 };
            PointArrivee = new[] { 200, 100 };

            StartNavigation();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CasNavigation = 3;
            PointDepart = new[] { 200, 100 };
            PointArrivee = new[] { 100, 200 };
            
            StartNavigation();
        }

        private void StartNavigation()
        {
            SearchTree g = new SearchTree();
            NavNode N0 = new NavNode(PointDepart[0], PointDepart[1]);

            List<GenericNode> solution = g.RechercheSolutionAEtoile(N0);

            //Node2 N1 = N0;
            //for (int i = 1; i < solution.Count; i++)
            //{
            //    Node2 N2 = (Node2)solution[i];
            //    listBox1.Items.Add(Convert.ToString(N1.numero)
            //                       + "--->" + Convert.ToString(N2.numero)
            //                       + "   : " + Convert.ToString(matrice[N1.numero, N2.numero]));
            //    N1 = N2;
            //}

            //g.GetSearchTree(treeView1);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
