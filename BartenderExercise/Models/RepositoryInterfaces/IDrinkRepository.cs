namespace BartenderExercise.Models.RepositoryInterfaces
{
	public interface IDrinkRepository
	{
		IEnumerable<Drink> Menu { get; }
		// Drinks will be added to the menu manually, as an add menu was not specified in the requirements
		Drink GetDrinkByID(int DrinkID);
		Drink AddDrink(Drink drink);
	}
}
