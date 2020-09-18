using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BO.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MinListNumber : ValidationAttribute
    {
        private int Min { get; set; }
        public MinListNumber(int min)
        {
            Min = min;
        }
        public override bool IsValid(object value)
        {
            bool result = false;
            if ((value as List<int>).Count >= Min)
            {
                result = true;
            }

            return result;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Vous devez sélectionner au moins " + Min + " éléments";
        }


    }
}