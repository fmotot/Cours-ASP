using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP2_Module05.Models
{
    public class PizzaVM
    {
        public Pizza Pizza { get; set; }

        public List<Pate> Pates { get; set; }
        public int IdPate { get; set; }

        public List<Ingredient> Ingredients { get; set; }
        public List<int> IdIngredients { get; set; }
    }
}