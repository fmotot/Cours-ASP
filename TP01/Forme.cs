using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01
{
    public abstract class Forme
    {
        public abstract string ShowType();
        public abstract double Aire();
        public abstract double Perimetre();

        public override string ToString()
        {
            return String.Format("{0}\nAire = {1}\nPérimètre = {2}\n", this.ShowType(), this.Aire(), this.Perimetre());
        }
    }
}
