using BartenderExercise.Models;
using BartenderExercise.Models.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BartenderExercise.Controllers
{
	public class BarController : Controller
	{
		IDrinkRepository _drinkRepository;
		IOrderRepository _orderRepository;
		public BarController(IDrinkRepository drinkRepository, IOrderRepository orderRepository)
		{
			_drinkRepository = drinkRepository;
			_orderRepository = orderRepository;
		}

		// Drink menu, needs a model containing the list of drinks passed through
		public IActionResult ViewDrinks()
		{
			return View(_drinkRepository.Menu);
		}

		// Order list, needs a model containing the list of orders passed through
		public IActionResult ViewOrders()
		{
			return View(_orderRepository);
		}

		// Order editing, needs a model containing the details for the order to be edited passed through
		public IActionResult EditOrder(int OrderID)
		{
			return View(_orderRepository.GetOrderByID(OrderID));
		}

		// Receive the submitted changes to the order
		public IActionResult SubmitEditedOrder(Order o)
		{
			_orderRepository.UpdateOrder(o);
			_orderRepository.SaveChanges();

			return View("ViewOrders", _orderRepository);
		}

		// Cancels an order and sends the user back to the order list
		public IActionResult CancelOrder(int OrderID)
		{
			_orderRepository.CancelOrder(OrderID);
			_orderRepository.SaveChanges();

			return View("ViewOrders", _orderRepository);
		}

		// Fufills an order and sends the user back to the order list
		public IActionResult FufillOrder(int OrderID)
		{
			_orderRepository.FufillOrder(OrderID);
			_orderRepository.SaveChanges();

			return View("ViewOrders", _orderRepository);
		}

		// Adds a new order to the order list, then sends the user back to the order list
		public IActionResult AddOrder(int DrinkID)
		{
			Order o = new Order();
			o.DrinkId = DrinkID;
			o.OrderTime = DateTime.Now;
			o.Status = "Pending";

			_orderRepository.CreateOrder(o);
			_orderRepository.SaveChanges();

			// Redirect to the InputInformation view to get customer details, passing the new order as the model
			return View("InputInformation", o);
		}

		// Receives the submitted customer information for the new order
		public IActionResult SubmitCustomerInfo(Order o)
		{
			_orderRepository.UpdateOrder(o);
			_orderRepository.SaveChanges();

			return View("ViewOrders", _orderRepository);
		}

		// Deletes an order and sends the user back to the order list
		public IActionResult DeleteOrder(int OrderID)
		{
			_orderRepository.DeleteOrder(OrderID);
			_orderRepository.SaveChanges();

			return View("ViewOrders", _orderRepository);
		}
	}
}
