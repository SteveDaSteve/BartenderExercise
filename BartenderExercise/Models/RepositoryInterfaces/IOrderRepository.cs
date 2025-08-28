namespace BartenderExercise.Models.RepositoryInterfaces
{
	public interface IOrderRepository
	{
		IEnumerable<Order> Orders { get; }
		Order GetOrderByID(int OrderID);
		void CreateOrder(Order o);
		void UpdateOrder(Order o);
		// It is preferable to cancel an order to keep record, but deletion is provided regardless
		void DeleteOrder(int OrderID);
		// Sets the Status attribute to "Fufilled
		void FufillOrder(int OrderID);
		// Sets the Status attribute to "Cancelled"
		void CancelOrder(int OrderID);
		void SaveChanges();
	}
}
