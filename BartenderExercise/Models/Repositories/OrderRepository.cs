using BartenderExercise.Data;
using BartenderExercise.Models.RepositoryInterfaces;

namespace BartenderExercise.Models.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		public ApplicationDbContext _context;
		public IEnumerable<Order> Orders => _context.Orders;
		public OrderRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		// Returns the order with the specified ID, or null if not found
		public Order GetOrderByID(int OrderID)
		{
			Order o = _context.Orders.Find(OrderID);
			if (o != null)
			{
				return o;
			}
			else
			{
				Console.WriteLine("Tried to find order " + OrderID + ", but it wasn't found");
			}
			return null;
		}

		public void CreateOrder(Order o)
		{
			_context.Orders.Add(o);
			_context.SaveChanges();
			Console.WriteLine("Order" + o.OrderID + "was created");
		}

		public void UpdateOrder(Order o)
		{
			_context.Orders.Update(o);
			_context.SaveChanges();
			Console.WriteLine("Order" + o.OrderID + "was updated");
		}

		// It is preferable to cancel an order to keep record, but deletion is provided regardless
		public void DeleteOrder(int OrderID)
		{
			Order o = _context.Orders.Find(OrderID);
			if (o != null)
			{
				_context.Orders.Remove(o);
				_context.SaveChanges();
				Console.WriteLine("Order" + OrderID + "was deleted");
			}
			else
			{
				Console.WriteLine("Tried to delete order " + OrderID + ", but it wasn't found");
			}
		}

		// Sets the Status attribute to "Fufilled
		public void FufillOrder(int OrderID)
		{
			Order o = _context.Orders.Find(OrderID);
			if (o != null)
			{
				o.Status = "Fufilled";
				_context.Orders.Update(o);
				_context.SaveChanges();
				Console.WriteLine("Order" + OrderID + "has been marked fufilled.");
			}
			else
			{
				Console.WriteLine("Tried to update order " + OrderID + ", but it wasn't found");
			}
		}

		// Sets the Status attribute to "Cancelled"
		public void CancelOrder(int OrderID)
		{
			Order o = _context.Orders.Find(OrderID);
			if (o != null)
			{
				o.Status = "Cancelled";
				_context.Orders.Update(o);
				_context.SaveChanges();
				Console.WriteLine("Order" + OrderID + "has been marked cancelled.");
			} 
			else 
			{
				Console.WriteLine("Tried to update order " + OrderID + ", but it wasn't found");
			}
			
		}

		public void SaveChanges()
		{
			_context.SaveChanges();
		}
	}
}
