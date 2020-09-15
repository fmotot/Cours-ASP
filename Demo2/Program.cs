using Demo2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Personne p1 = new Personne();
            p1.Age = 10;
            p1.Nom = "svdv";
            p1.Prenom = "sdffdg";

            Personne p2 = new Personne
            {
                Nom = "sdjdgjgoipdf",
                Prenom = "sdpgnwisudg",
                Age = 651
            };

            Personne p3 = new Personne(
                "dskgnfdg", "sdfoppo", 39);

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);

            Console.ReadLine();
        }
    }
}
