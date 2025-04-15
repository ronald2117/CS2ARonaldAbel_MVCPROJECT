using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2ARonaldAbel_MVCPROJECT.BusLogic.Model
{
    public class RecipeRequest
    {
        public string? Budget { get; set; }
        public string? Ingredients { get; set; }
        public string? Preferences { get; set; }
        public string? DishType { get; set; } = "Filipino";
        public required string MealTime { get; set; }
    }
}