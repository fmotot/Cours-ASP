using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BO.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MaxListNumber : ValidationAttribute
    {
        private int Max { get; set; }
        public MaxListNumber(int max)
        {
            Max = max;
        }
        public override bool IsValid(object value)
        {
            bool result = false;
            if ((value as List<int>).Count <= Max)
            {
                result = true;
            }

            return result;
        }
    }
}