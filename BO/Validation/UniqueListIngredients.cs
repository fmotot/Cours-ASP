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
            //foreach (var item in FakeDb.Instance.Pizzas)
            //{
            //    // tester si le contenu de liste des ingrédients est strictement égale
            //    if ((value as List<int>).SequenceEqual(item.Ingredients.Select(x => x.Id)))
            //    {
            //        result = false;
            //        break;
            //    }
            //}
            if (value is List<int>)
            {
                List<int> myList = value as List<int>;

                if (FakeDb.Instance.Pizzas.Any(x => x.Ingredients.Select(y => y.Id).OrderBy(z => z).SequenceEqual(myList.OrderBy(p => p))))
                {
                    result = false;
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