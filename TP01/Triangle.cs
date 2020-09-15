using System;

namespace TP01
{
    public class Triangle : Forme
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public override double Aire()
        {
            double s = this.Perimetre() / 2;

            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }

        public override double Perimetre()
        {
            return A + B + C;
        }

        public override string ShowType()
        {
            return "Triangle de côté A = " + A + ", B = " + B + ", C = " + C;
        }
    }
}