using BO.Utils;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BO.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PizzaNomUnique : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = false;
            int nbSameName = FakeDb.Instance.Pizzas.Where(p => p.Nom == value.ToString()).Count();
            if (nbSameName == 0)
            {
                result = true;
            }

            return result;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Une pizza porte déjà ce nom, veuillez le modifier";
        }
    }
}