namespace TP01
{
    public class Cercle : Forme
    {
        public int Rayon { get; set; }

        public override double Aire()
        {
            return System.Math.PI * System.Math.Pow(Rayon, 2);
        }

        public override double Perimetre()
        {
            return 2 * System.Math.PI * Rayon;
        }

        public override string ShowType()
        {
            return "Cercle de rayon " + Rayon;
        }
    }
}