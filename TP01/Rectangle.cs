namespace TP01
{
    public class Rectangle : Forme
    {
        private int largeur;
        private int longueur;

        public Rectangle()
        {

        }

        public Rectangle(int largeur, int longueur)
        {
            this.largeur = largeur;
            this.longueur = longueur;
        }

        public int Longueur
        {
            get { return longueur; }
            set { longueur = value; }
        }


        public virtual int Largeur
        {
            get { return largeur; }
            set { largeur = value; }
        }


        public override double Aire()
        {
            return Largeur * Longueur;
        }

        public override double Perimetre()
        {
            return 2 * Longueur + 2 * Largeur;
        }

        public override string ShowType()
        {
            return "Rectangle de longueur = " + Longueur + " et largeur = " + Largeur;
        }
    }
}