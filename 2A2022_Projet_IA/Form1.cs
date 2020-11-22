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
        private Bitmap NavMap;
        public static int CasNavigation;
        public static int[] PointDepart;
        public static int[] PointArrivee;
        public static int xSize = 300;
        public static int ySize = 300;

        public Form1()
        {
            InitializeComponent();
            InitializePictureBox();
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void StartNavigation()
        {
            SearchTree g = new SearchTree();
            NavNode N0 = new NavNode(PointDepart[0], PointDepart[1]);

            await Task.Run(() =>
            {
                List<GenericNode> solution = g.RechercheSolutionAEtoile(N0);
                
                foreach (var genericNode in solution)
                {
                    NavNode node = (NavNode) genericNode;

                    Color newColor = Color.FromArgb(200, 0, 0);
                    NavMap.SetPixel(node.X, node.Y, newColor);
                }
            });
        }

        private void InitializePictureBox()
        {
            // Sets up an image object to be displayed.
            if (NavMap != null)
            {
                NavMap.Dispose();
            }
            
            // Stretches the image to fit the pictureBox.
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            NavMap = new Bitmap(xSize, ySize);

            for (int x = 0; x < NavMap.Width; x++)
            {
                for (int y = 0; y < NavMap.Height; y++)
                {
                    Color pixelColor = NavMap.GetPixel(x, y);
                    Color newColor = Color.FromArgb(255, 119, 181, 254);
                    NavMap.SetPixel(x, y, newColor);
                }
            }

            pictureBox1.ClientSize = new Size(xSize, ySize);
            pictureBox1.Image = NavMap;

            listBox1.Items.Add("pass!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
