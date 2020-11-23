using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2A2022_Projet_IA.Resources;

namespace _2A2022_Projet_IA
{
    public partial class Form1 : Form
    {
        private Bitmap NavMap { get; set; }

        public static int CasNavigation { get; private set; }
        public static int[] PointDepart { get; private set; }
        public static int[] PointArrivee { get; private set; }

        public static int xSize { get; private set; }
        public static int ySize { get; private set; }

        private Stopwatch stopwatch { get; }

        public Color BackgroundColor { get; }
        public Color CurrentTraceColor { get; private set; }
        public Dictionary<Colors, Color> TraceColors { get; }

        public enum Colors
        {
            Blue, Red, Green, Yellow, Black, Magenta
        }

        public Form1()
        {
            xSize = 300;
            ySize = 300;

            BackgroundColor = Color.FromArgb(255, 119, 181, 254);
            TraceColors = new Dictionary<Colors, Color>()
            {
                {Colors.Blue, Color.Blue},
                {Colors.Red, Color.Red},
                {Colors.Green, Color.Green},
                {Colors.Yellow, Color.Yellow},
                {Colors.Black, Color.Black},
                {Colors.Magenta, Color.Magenta},
            };
            
            InitializeComponent();
            InitializePictureBox();

            colorComboBox.DataSource = Enum.GetValues(typeof(Colors));

            stopwatch = new Stopwatch();
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

        private async void StartNavigation()
        {
            if (stopwatch.IsRunning)
            {
                MessageBox.Show("Veuillez attendre la fin de la recherche avant d'en lancer une autre !",
                    "Exécution en cours", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SearchTree g = new SearchTree();
            NavNode N0 = new NavNode(PointDepart[0], PointDepart[1]);

            listBox1.Items.Add(new string('=', 15));
            listBox1.Items.Add($"Cas {CasNavigation} chargé !");
            listBox1.Items.Add($"Lancement de l'A*");

            stopwatch.Reset();
            stopwatch.Start();

            await Task.Run(() =>
            {
                Color currentColor = CurrentTraceColor;

                List<GenericNode> solution = g.RechercheSolutionAEtoile(N0);
                //var elapsed = stopwatch.Elapsed.Seconds;
                double totalCost = 0;

                NavNode precedent = new NavNode(0, 0);

                foreach (var genericNode in solution)
                {
                    NavNode node = (NavNode) genericNode;
                    NavMap.SetPixel(node.Y, 300-node.X, currentColor);
                    if (genericNode != solution[0])
                    {
                        totalCost += precedent.GetArcCost(node);
                        precedent = node;
                    }
                    else
                    {
                        precedent = node;
                    }
                }

                MessageBox.Show($"Le temps total en heure est estimé à {totalCost.ToString()}h.");
            });

            pictureBox1.Refresh();

            stopwatch.Stop();
            listBox1.Items.Add($"Recherche terminée!");
            //listBox1.Items.Add($"Recherche terminée! - {elapsed}s");
            //listBox1.Items.Add($"Traçage du chemin...");
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

            NavMap = new Bitmap(ySize, xSize);

            for (int x = 0; x < NavMap.Width; x++)
            {
                for (int y = 0; y < NavMap.Height; y++)
                {
                    Color pixelColor = NavMap.GetPixel(x, y);
                    NavMap.SetPixel(x, y, BackgroundColor);
                }
            }

            pictureBox1.ClientSize = new Size(xSize, ySize);
            pictureBox1.Image = NavMap;
        }

        private void ResetPictureBox()
        {
            for (int x = 0; x < NavMap.Width; x++)
            {
                for (int y = 0; y < NavMap.Height; y++)
                {
                    Color pixelColor = NavMap.GetPixel(x, y);
                    NavMap.SetPixel(x, y, BackgroundColor);
                }
            }
        }

        private void colorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {  
            Colors c = (Colors) ((ComboBox) sender).SelectedValue;
            CurrentTraceColor = TraceColors[c];
        }
    }
}
