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
        public static int ActionAngle { get; private set; }
        public static int[] PointDepart { get; private set; }
        public static int[] PointArrivee { get; private set; }
        public static List<GenericNode> Solution { get; private set; }

        private NavNode.Heuristic currentHeuristic { get; set; }

        public double TotalCost { get; private set; }

        public static int xSize { get; private set; }
        public static int ySize { get; private set; }

        private Stopwatch stopwatch { get; }

        public Color BackgroundColor { get; }
        public Color CurrentTraceColor { get; private set; }
        public Dictionary<Colors, Color> TraceColors { get; }

        public enum Colors
        {
            Blue, Red, Green, Yellow, Magenta
        }

        public Form1()
        {
            xSize = 300;
            ySize = 300;

            ActionAngle = 180;

            BackgroundColor = Color.FromArgb(255, 119, 181, 254);
            TraceColors = new Dictionary<Colors, Color>()
            {
                {Colors.Blue, Color.Blue},
                {Colors.Red, Color.Red},
                {Colors.Green, Color.Green},
                {Colors.Yellow, Color.Yellow},
                //{Colors.Black, Color.Black},
                {Colors.Magenta, Color.Magenta},
            };

            InitializeComponent();
            InitializePictureBox();

            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            
            colorComboBox.DataSource = Enum.GetValues(typeof(Colors));
            hComboBox.DataSource = Enum.GetValues(typeof(NavNode.Heuristic));

            stopwatch = new Stopwatch();
        }

        
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SearchTree g = new SearchTree();
            NavNode N0 = new NavNode(PointDepart[0], PointDepart[1]);

            NavNode.HeuristicMethod = currentHeuristic;

            Solution = g.RechercheSolutionAEtoile(N0);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stopwatch.Stop();
            DisplayStartEndPoint(); // possiblement effacés par utilisateur

            GetSolutionTimeCost(Solution);
            DisplayBoatPath(Solution);
            
            TimeSpan ETA = TimeSpan.FromHours(TotalCost);
            string ETAString = GetFormattedETA(ETA);

            listBox1.Items.Add("Recherche terminée");
            listBox1.Items.Add($"Temps d'exécution : {stopwatch.Elapsed.Seconds}s");
            listBox1.Items.Add($"ETA: {ETAString}");
        }



        private void DisplayBoatPath(List<GenericNode> solution)
        {
            Color currentColor = CurrentTraceColor;

            Graphics g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(currentColor);

            NavNode pnode = (NavNode) Solution[0];

            foreach (var genericNode in solution)
            {
                NavNode node = (NavNode)genericNode;

                g.DrawLine(pen,
                    new Point(pnode.X, pictureBox1.Height - pnode.Y),
                    new Point(node.X, pictureBox1.Height - node.Y));
                
                pnode = node;
            }
        }

        private void GetSolutionTimeCost(List<GenericNode> solution)
        {
            NavNode precedent = new NavNode(0, 0);
            double totalCost = 0;

            foreach (var genericNode in solution)
            {
                NavNode node = (NavNode)genericNode;

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
            TotalCost = totalCost;
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
            if (stopwatch.IsRunning)
            {
                MessageBox.Show("Veuillez attendre la fin de la recherche avant d'en lancer une autre !",
                    "Exécution en cours", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            listBox1.Items.Add(new string('=', 20));
            listBox1.Items.Add($"Cas {CasNavigation} chargé !");
            listBox1.Items.Add($"Lancement de l'A*");
            listBox1.Items.Add($"Veuillez patienter...");

            stopwatch.Reset();
            stopwatch.Start();

            DisplayStartEndPoint();

            backgroundWorker1.RunWorkerAsync();
        }

        

        private void DisplayStartEndPoint()
        {
            DrawCircle(300-PointDepart[1], PointDepart[0], 5, Color.White);
            DrawCircle(300-PointArrivee[1], PointArrivee[0], 5, Color.Black);

            pictureBox1.Refresh();
        }
        
        private string GetFormattedETA(TimeSpan eta)
        {
            int days = eta.Days;
            int hours = eta.Hours;
            int minutes = eta.Minutes;

            return string.Format(
                "{0}{1}h et {2}min",
                days == 0 ? "" : $"{days} jour" + (days > 1 ? "s, " : ", "),
                hours, minutes);
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
            
            pictureBox1.Refresh();
        }

        private void colorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {  
            Colors c = (Colors) ((ComboBox) sender).SelectedValue;
            CurrentTraceColor = TraceColors[c];
        }

        private void clearButton_Click(object sender, EventArgs e) => ResetPictureBox();

        private void DrawCircle(int x, int y, int r, Color color)
        {
            double rSquared = Math.Pow(r, 2);

            for (int i = x - (int)r; i <= x + r; i++)
            for (int j = y - (int)r; j <= y + r; j++)
                if (Math.Abs(Math.Pow(i - x, 2) + Math.Pow(j - y, 2) - rSquared) <= r)
                    NavMap.SetPixel(i, j, color);
        }

        private void hComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentHeuristic = (NavNode.Heuristic) ((ComboBox) sender).SelectedValue;
        }

        private void angleNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ActionAngle = (int) ((NumericUpDown) sender).Value;
        }
    }
}
