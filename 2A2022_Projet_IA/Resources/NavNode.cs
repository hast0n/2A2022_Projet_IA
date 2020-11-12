using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _2A2022_Projet_IA.Resources
{
    class NavNode : GenericNode
    {
        public int X, Y;
        private const int WrongInput = 1000000;

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

            if (GetDistanceEucl(node2) <= 10)
            {
                // get alpha l'angle entre bateau et vent
                // get vitesse vent
                // get vitesse bateau
                double boatSpeed = GetBoatSpeed(alpha, VitVent);
                // 
            }
            else
            {
                return WrongInput;
            }
        }

        public override bool EndState()
        {
            throw new NotImplementedException();
        }

        public override List<GenericNode> GetListSucc()
        {
            throw new NotImplementedException();
        }

        public override double CalculeHCost()
        {
            throw new NotImplementedException();
        }

        private double GetDistanceEucl(NavNode N2)
        {
            return Math.Sqrt(
                Math.Pow(N2.X - this.X, 2) +
                Math.Pow(N2.Y - this.Y, 2)
            );
        }

        private double GetBoatWindAngle()
        {
            return Math.Abs(
                Math.Acos(
                    (this.X * )
                )
            );
        }

        private double GetBoatSpeed(double alpha, double VitVent)
        {
            if (alpha>= 0 && alpha<=45)
            {
                return ((0.6 + 0.3 * alpha / 45) * VitVent);
            }
            else
            {
                if (alpha > 45 && alpha <= 90)
                {
                    return ((0.9 - 0.2 * (alpha - 45)/45) * VitVent);
                }
                else
                {
                    if (alpha > 90 && alpha <= 150)
                    {
                        return (0.7 *(1- (alpha-90 / 60) * VitVent));
                    }
                    else
                    {
                        return (0);
                    }
                }
            }
        }

        private int GetWindDirection(NavNode Node2)
        {

        }
    }
}
