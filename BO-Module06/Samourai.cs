using System.Collections.Generic;

namespace BO
{
    public class Samourai : Entity
    {
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }

        public int Potentiel { get
            {
                //(Force + dégâts de l’arme) *nombre d’arts martiaux + 1)
                return (Force + (Arme == null ? 0 : Arme.Degats)) * (ArtMartials.Count + 1);
            }
        }
        public List<ArtMartial> ArtMartials { get; set; } = new List<ArtMartial>();
    }
}
