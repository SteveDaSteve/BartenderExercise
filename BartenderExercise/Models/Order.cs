using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BartenderExercise.Models
{
	// A model representing an order at the bar
	public class Order
	{
		[Key]
		public int OrderID { get; set; }
		public string? CustomerName { get; set; }
		[ForeignKey("Drink")]
		public int DrinkId { get; set; }
		public DateTime OrderTime { get; set; }
		// 3 States: Pending, Fufilled, Cancelled. Pending by default
		public string? Status { get; set; }

		// Other properties, such as payment info, to-go status, and quantity of drinks
		// can also be added, but are unnessary for this exercise
	}
}
