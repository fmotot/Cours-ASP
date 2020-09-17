using BO;
using System;
using System.Collections.Generic;

namespace TP2_Module05.Utils
{
    public class FakeDb
    {
        private static readonly Lazy<FakeDb> lazy =
            new Lazy<FakeDb>(() => new FakeDb());

        public List<Pizza> Pizzas { get; private set; }
        public List<Ingredient> Ingredients { get; private set; }
        public List<Pate> Pates { get; private set; }

        /// <summary>
        /// FakeDb singleton access.
        /// </summary>
        public static FakeDb Instance { get { return lazy.Value; } }


        private FakeDb()
        {
            this.Ingredients = IngredientsDisponibles;
            this.Pates = PatesDisponibles;
            this.Pizzas = new List<Pizza>();
        }

        private static List<Ingredient> IngredientsDisponibles => new List<Ingredient>
        {
            new Ingredient{Id=1,Nom="Mozzarella"},
            new Ingredient{Id=2,Nom="Jambon"},
            new Ingredient{Id=3,Nom="Tomate"},
            new Ingredient{Id=4,Nom="Oignon"},
            new Ingredient{Id=5,Nom="Cheddar"},
            new Ingredient{Id=6,Nom="Saumon"},
            new Ingredient{Id=7,Nom="Champignon"},
            new Ingredient{Id=8,Nom="Poulet"}
        };

        private static List<Pate> PatesDisponibles => new List<Pate>
        {
            new Pate{ Id=1,Nom="Pate fine, base crême"},
            new Pate{ Id=2,Nom="Pate fine, base tomate"},
            new Pate{ Id=3,Nom="Pate épaisse, base crême"},
            new Pate{ Id=4,Nom="Pate épaisse, base tomate"}
        };
    }
}