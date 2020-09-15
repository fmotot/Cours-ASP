namespace TP01
{
    public class Carre : Rectangle
    {
        public override int Largeur { get => base.Longueur;  }

        public override string ShowType()
        {
            return "Carré de côté = " + Longueur;
        }
    }
}