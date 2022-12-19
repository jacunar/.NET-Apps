<<<<<<< HEAD
=======
using BlazingPizza.Data;
>>>>>>> c8ea36748f8cf79e41fa8f67dfcb4d926a962981
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza;

[Route("orders")]
[ApiController]
<<<<<<< HEAD
public class OrdersController : Controller
{
    private readonly PizzaStoreContext _db;

    public OrdersController(PizzaStoreContext db)
    {
=======
public class OrdersController : Controller {
    private readonly PizzaStoreContext _db;

    public OrdersController(PizzaStoreContext db) {
>>>>>>> c8ea36748f8cf79e41fa8f67dfcb4d926a962981
        _db = db;
    }

    [HttpGet]
<<<<<<< HEAD
    public async Task<ActionResult<List<OrderWithStatus>>> GetOrders()
    {
=======
    public async Task<ActionResult<List<OrderWithStatus>>> GetOrders() {
>>>>>>> c8ea36748f8cf79e41fa8f67dfcb4d926a962981
        var orders = await _db.Orders
 	    .Include(o => o.Pizzas).ThenInclude(p => p.Special)
 	    .Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping)
 	    .OrderByDescending(o => o.CreatedTime)
 	    .ToListAsync();

        return orders.Select(o => OrderWithStatus.FromOrder(o)).ToList();
    }

    [HttpPost]
<<<<<<< HEAD
    public async Task<ActionResult<int>> PlaceOrder(Order order)
    {
=======
    public async Task<ActionResult<int>> PlaceOrder(Order order) {
>>>>>>> c8ea36748f8cf79e41fa8f67dfcb4d926a962981
        order.CreatedTime = DateTime.Now;

        // Enforce existence of Pizza.SpecialId and Topping.ToppingId
        // in the database - prevent the submitter from making up
        // new specials and toppings
<<<<<<< HEAD
        foreach (var pizza in order.Pizzas)
        {
=======
        foreach (var pizza in order.Pizzas) {
>>>>>>> c8ea36748f8cf79e41fa8f67dfcb4d926a962981
            pizza.SpecialId = pizza.Special.Id;
            pizza.Special = null;
        }

        _db.Orders.Attach(order);
        await _db.SaveChangesAsync();

        return order.OrderId;
    }
}