using BO.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BO
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        [PizzaNomUnique]
        public string Nom { get; set; }
        
        public Pate Pate { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
