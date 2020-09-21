using BO.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BO.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UniqueListIngredients : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = true;

            // pour chaque pizza
            foreach (var item in FakeDb.Instance.Pizzas)
            {
                // tester si le contenu de liste des ingrédients est strictement égale
                if ((value as List<int>).SequenceEqual(item.Ingredients.Select(x => x.Id)))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Une pizza comporte déjà ces ingrédients, veuillez les modifier";
        }
    }
}