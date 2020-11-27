using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace _2A2022_Projet_IA.Resources
{
    class NavNode : GenericNode
    {
        public int X, Y;
        private const int WrongInput = 1000000;

        public static Heuristic HeuristicMethod;

        public enum Heuristic
        {
            ClassicTime,
            WeightedDistance
        }

        public NavNode(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool IsEqual(GenericNode N2)
        {
            NavNode node2 = (NavNode) N2;
            return this.X == node2.X && this.Y == node2.Y;
        }

        public override double GetArcCost(GenericNode N2)
        {
            NavNode node2 = (NavNode) N2;
            double distance = GetDistanceEucl(node2);

            if (distance > 10) return WrongInput;
            
            // get alpha l'angle entre bateau et vent
            double alpha = Math.Abs(GetBoatDirection(node2) - GetWindDirection(node2));
            // get vitesse vent
            double windSpeed = GetWindSpeed(node2);
            // get vitesse bateau
            double boatSpeed=0;//              = GetBoatSpeed(alpha, windSpeed);
            // On se ramène à un angle sur 180°
            alpha = alpha > 180 ? 360 - alpha : alpha;

            if (alpha <= 45)
            {
                /* (0.6 + 0.3α / 45) v_v */
                boatSpeed = (0.6 + 0.3 * alpha / 45) * windSpeed;
            }
            else if (alpha <= 90)
            {
                /*v_b=(0.9-0.2(α-45)/45) v_v */
                boatSpeed = (0.9 - 0.2 * (alpha - 45) / 45) * windSpeed;
            }
            else if (alpha < 150)
            {
                /* v_b=0.7(1-(α-90)/60) v_v */
                boatSpeed = 0.7 * (1 - (alpha - 90) / 60) * windSpeed;
            }

            // estimation du temps de navigation entre p1 et p2
            return (distance / boatSpeed);
        }

        public override bool EndState()
        {
            return this.IsEqual(new NavNode(Form1.PointArrivee[0], Form1.PointArrivee[1]));
        }

        public override List<GenericNode> GetListSucc()
        {
            NavNode nodeFin = new NavNode(Form1.PointArrivee[0], Form1.PointArrivee[1]);

            List<GenericNode> lsucc = new List<GenericNode>();

            int[][] succCoords = new int[][]
            {
                //new[] {-3,  3}, new[] {-2,  3}, new[] {-1,  3}, new[] {0,  3}, new[] {1,  3}, new[] {2,  3}, new[] {3,  3},
                //new[] {-3,  2}, new[] {-2,  2}, new[] {-1,  2}, new[] {0,  2}, new[] {1,  2}, new[] {2,  2}, new[] {3,  2},
                //new[] {-3,  1}, new[] {-2,  1}, new[] {-1,  1}, new[] {0,  1}, new[] {1,  1}, new[] {2,  1}, new[] {3,  1},
                //new[] {-3,  0}, new[] {-2,  0}, new[] {-1,  0},                new[] {1,  0}, new[] {2,  0}, new[] {3,  0},
                //new[] {-3, -1}, new[] {-2, -1}, new[] {-1, -1}, new[] {0, -1}, new[] {1, -1}, new[] {2, -1}, new[] {3, -1},
                //new[] {-3, -2}, new[] {-2, -2}, new[] {-1, -2}, new[] {0, -2}, new[] {1, -2}, new[] {2, -2}, new[] {3, -2},
                //new[] {-3, -3}, new[] {-2, -3}, new[] {-1, -3}, new[] {0, -3}, new[] {1, -3}, new[] {2, -3}, new[] {3, -3}

                //new[] {-2,  2}, new[] {0,  2}, new[] {2,  2},
                //new[] {-2,  0},                new[] {2,  0},
                //new[] {-2, -2}, new[] {0, -2}, new[] {2, -2}

                //new[] {-1,  1}, new[] {0,  1}, new[] {1,  1},
                //new[] {-1,  0},                new[] {1,  0},
                //new[] {-1, -1}, new[] {0, -1}, new[] {1, -1},
               
                //new[] {-4,  4}, new[] {-3,  4}, new[] {-2,  4}, new[] {-1,  4}, new[] {0,  4}, new[] {1,  4}, new[] {2,  4}, new[] {3,  4}, new[] {4,  4},
                //new[] {-4,  3}, new[] {-3,  3}, new[] {-2,  3}, new[] {-1,  3}, new[] {0,  3}, new[] {1,  3}, new[] {2,  3}, new[] {3,  3}, new[] {4,  3},
                //new[] {-4,  2}, new[] {-3,  2}, new[] {-2,  2}, new[] {-1,  2}, new[] {0,  2}, new[] {1,  2}, new[] {2,  2}, new[] {3,  2}, new[] {4,  2},
                //new[] {-4,  1}, new[] {-3,  1}, new[] {-2,  1}, new[] {-1,  1}, new[] {0,  1}, new[] {1,  1}, new[] {2,  1}, new[] {3,  1}, new[] {4,  1},
                //new[] {-4,  0}, new[] {-3,  0}, new[] {-2,  0}, new[] {-1,  0},                new[] {1,  0}, new[] {2,  0}, new[] {3,  0}, new[] {4,  0},
                //new[] {-4, -1}, new[] {-3, -1}, new[] {-2, -1}, new[] {-1, -1}, new[] {0, -1}, new[] {1, -1}, new[] {2, -1}, new[] {3, -1}, new[] {4, -1},
                //new[] {-4, -2}, new[] {-3, -2}, new[] {-2, -2}, new[] {-1, -2}, new[] {0, -2}, new[] {1, -2}, new[] {2, -2}, new[] {3, -2}, new[] {4, -2},
                //new[] {-4, -3}, new[] {-3, -3}, new[] {-2, -3}, new[] {-1, -3}, new[] {0, -3}, new[] {1, -3}, new[] {2, -3}, new[] {3, -3}, new[] {4, -3},
                //new[] {-4, -4}, new[] {-3, -4}, new[] {-2, -4}, new[] {-1, -4}, new[] {0, -4}, new[] {1, -4}, new[] {2, -4}, new[] {3, -4}, new[] {4, -4}
                        
                new[] {-2,  2}, new[] {-1,  2}, new[] {0,  2}, new[] {1,  2}, new[] {2,  2},
                new[] {-2,  1},                                               new[] {2,  1},
                new[] {-2,  0},                                               new[] {2,  0},
                new[] {-2, -1},                                               new[] {2, -1},
                new[] {-2, -2}, new[] {-1, -2}, new[] {0, -2}, new[] {1, -2}, new[] {2, -2}


                //new[] {-4,  4}, new[] {-3,  4}, new[] {-2,  4}, new[] {-1,  4}, new[] {0,  4}, new[] {1,  4}, new[] {2,  4}, new[] {3,  4}, new[] {4,  4},
                //new[] {-4,  3},                                                                                                             new[] {4,  3},
                //new[] {-4,  2},                                                                                                             new[] {4,  2},
                //new[] {-4,  1},                                                                                                             new[] {4,  1},
                //new[] {-4,  0},                                                                                                             new[] {4,  0},
                //new[] {-4, -1},                                                                                                             new[] {4, -1},
                //new[] {-4, -2},                                                                                                             new[] {4, -2},
                //new[] {-4, -3},                                                                                                             new[] {4, -3},
                //new[] {-4, -4}, new[] {-3, -4}, new[] {-2, -4}, new[] {-1, -4}, new[] {0, -4}, new[] {1, -4}, new[] {2, -4}, new[] {3, -4}, new[] {4, -4}


                 //                new[] {-1,  2},                new[] {1,  2},
                 //new[] {-2,  1}, new[] {-1,  1}, new[] {0,  1}, new[] {1,  1}, new[] {2,  1},
                 //                new[] {-1,  0},                new[] {1,  0},
                 //new[] {-2, -1}, new[] {-1, -1}, new[] {0, -1}, new[] {1, -1}, new[] {2, -1},
                 //                new[] {-1, -2},                new[] {1, -2},

            };

            double alpha = GetBoatDirection(nodeFin);
            double actA = Form1.ActionAngle;

            foreach (var coord in succCoords)
            {
                int newX = this.X + coord[0];
                int newY = this.Y + coord[1];

                double b = GetAngle(newX, newY);

                double angleDiff = (alpha - b + 180 + 360) % 360 - 180;

                if (angleDiff <= actA/2 && angleDiff >= -actA/2)
                {
                    if (newX >= 1 && newX <= Form1.xSize &&
                        newY >= 1 && newY <= Form1.ySize)
                        lsucc.Add(new NavNode(newX, newY));
                }
            }

            return lsucc;
        }

        public override double CalculeHCost()
        {
            NavNode nodeFin = new NavNode(Form1.PointArrivee[0], Form1.PointArrivee[1]);

            double speed = GetBoatSpeed(GetBoatDirection(nodeFin), GetWindSpeed(this));
            double dist = GetDistanceEucl(nodeFin);
            double heuristic = 0;

            switch (HeuristicMethod)
            {
                case Heuristic.ClassicTime:
                    heuristic = dist / speed;
                    break;
                case Heuristic.WeightedDistance:
                    heuristic = dist / speed + Math.Pow(dist, 2);
                    break;
            }

            if (speed == 0) return WrongInput;
            return heuristic;
        }
        
        private int GetDistanceManh(NavNode N2)
        {
            return Math.Abs(N2.X - this.X) + Math.Abs(N2.Y - this.Y);
        }

        private double GetDistanceEucl(NavNode N2)
        {
            return Math.Sqrt(
                Math.Pow(N2.X - this.X, 2) +
                Math.Pow(N2.Y - this.Y, 2)
            );
        }

        private double GetBoatDirection(NavNode node2)
        {
            return GetAngle(node2.X, node2.Y);
        }

        private double GetAngle(int x2, int y2)
        {
            double a = Math.Atan2(y2 - this.Y, x2 - this.X) * 180 / Math.PI;
            return a < 0 ? a + 360 : a;
        }
        
        private double GetBoatSpeed(double alpha, double VitVent)
        {
            if (alpha >= 0 && alpha < 45)
            {
                return (0.6 + 0.3 * alpha / 45) * VitVent;
            }

            if (alpha >= 45 && alpha < 90)
            {
                return (0.9 - 0.2 * (alpha - 45)/45) * VitVent;
            }
            
            if (alpha >= 90 && alpha < 150)
            {
                return 0.7 *(1- (alpha-90) / 60) * VitVent;
            }

            return 0;
        }

        private double GetWindDirection(NavNode N2)
        {
            if (Form1.CasNavigation == 1)
            {
                return (30);
            }
            else if (Form1.CasNavigation == 2)
            {
                if ((N2.Y + this.Y)/2 > 150)
                {
                    return (180);
                }
                else if ((N2.Y + this.Y) / 2 <= 150)
                {
                    return (90);
                }
                else
                {
                    return (0);
                }
            }
            else if (Form1.CasNavigation == 3)
            {
                if ((N2.Y + this.Y) / 2 > 150)
                {
                    return (170);
                }
                else if ((N2.Y + this.Y) / 2 <= 150)
                {
                    return (65);
                }
                else
                {
                    return (0);
                }
            }
            else
            {
                return (0);
            }
        }

        private double GetWindSpeed(NavNode N2)
        {
            if (Form1.CasNavigation == 1)
            {
                return (50);
            }
            else if (Form1.CasNavigation == 2)
            {
                if ((N2.Y + this.Y) / 2 > 150)
                {
                    return (50);
                }
                else if ((N2.Y + this.Y) / 2 <= 150)
                {
                    return (20);
                }
                else
                {
                    return (0);
                }
            }
            else if (Form1.CasNavigation == 3)
            {
                if ((N2.Y + this.Y) / 2 > 150)
                {
                    return (50);
                }
                else if ((N2.Y + this.Y) / 2 <= 150)
                {
                    return (20);
                }
                else
                {
                    return (0);
                }
            }
            else
            {
                return (0);
            }
        }
    }
}
