using System.ComponentModel.DataAnnotations;

namespace BartenderExercise.Models
{
	// A model representing the drinks on the menu
	public class Drink
	{
		[Key]
		public int DrinkID { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public double Price { get; set; }
		public double AlcaholContent { get; set; }

		// Other properties, such as size, nutritional info, ingredients, etc.
		// can also be added, but are unnessary for this exercise
	}
}
