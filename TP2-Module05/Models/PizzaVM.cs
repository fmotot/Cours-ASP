using BO;
using BO.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TP2_Module05.Models
{
    public class PizzaVM
    {
        public Pizza Pizza { get; set; }

        public List<SelectListItem> Pates { get; set; } = new List<SelectListItem>();

        [Required]
        public int? IdPate { get; set; }

        public List<SelectListItem> Ingredients { get; set; } = new List<SelectListItem>();

        [Required]
        [MinListNumber(2)]
        [MaxListNumber(5)]
        [UniqueListIngredients]
        public List<int> IdIngredients { get; set; } = new List<int>();
    }
}