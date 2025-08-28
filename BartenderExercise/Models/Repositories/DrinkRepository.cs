using BartenderExercise.Data;
using BartenderExercise.Models.RepositoryInterfaces;

namespace BartenderExercise.Models.Repositories
{
	public class DrinkRepository : IDrinkRepository
	{
		public ApplicationDbContext _context;
		public IEnumerable<Drink> Menu => _context.Drinks;

		public DrinkRepository(ApplicationDbContext context)
		{
			_context = context;

			/*
			// I don't know a lot about drinks
			AddDrink(new Drink { 
				Name = "Moonshine", 
				Description = "A beverage of dubious legality.", 
				AlcaholContent = 0.30, 
				Price = 8.99
			});
			AddDrink(new Drink
			{
				Name = "Vokda",
				Description = "A strong, potato-based drink.",
				AlcaholContent = 0.75,
				Price = 11.99
			});
			AddDrink(new Drink
			{
				Name = "Fruit Cocktail",
				Description = "A sweet beverage.",
				AlcaholContent = 0.10,
				Price = 5.99
			});
			*/
		}

		// Returns the drink with the specified ID
		public Drink GetDrinkByID(int DrinkID)
		{
			return _context.Drinks.Find(DrinkID);
		}

		public Drink AddDrink(Drink drink)
		{
			_context.Drinks.Add(drink);
			_context.SaveChanges();
			return drink;
		}
	}
}
