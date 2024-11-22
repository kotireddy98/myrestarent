using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodRestaurant.Controllers
{
    public class OrderController : Controller
    {
        private static List<OrderBO> Orders = new List<OrderBO>
    {
        new OrderBO { OrderID = 1, OrderName = "Order1", Price = 100, Quantity = 2, Addresses = "Home Address" },
        new OrderBO { OrderID = 2, OrderName = "Order2", Price = 200, Quantity = 1, Addresses = "Office Address" }
    };
        public class OrderBO
        {
            public int OrderID { get; set; }         
            public string OrderName { get; set; }   
            public decimal Price { get; set; }     
            public int? Quantity { get; set; }       
            public string Addresses { get; set; }   
        }


        // GET: Order
        public ActionResult Order()
        {
            return View(Orders);
        }

        public ActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrder(OrderBO orderBO)
        {
            // Generate a new OrderID
            orderBO.OrderID = Orders.Max(o => o.OrderID) + 1;
            Orders.Add(orderBO);
            return RedirectToAction("Order");
        }

        public ActionResult Edit(int id)
        {
            var order = Orders.FirstOrDefault(o => o.OrderID == id);
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(OrderBO orderBO)
        {
            var existingOrder = Orders.FirstOrDefault(o => o.OrderID == orderBO.OrderID);
            if (existingOrder != null)
            {
                existingOrder.OrderName = orderBO.OrderName;
                existingOrder.Price = orderBO.Price;
                existingOrder.Quantity = orderBO.Quantity;
                existingOrder.Addresses = orderBO.Addresses;
            }
            return RedirectToAction("Order");
        }

        public ActionResult DeleteOrder(int id)
        {
            var order = Orders.FirstOrDefault(o => o.OrderID == id);
            if (order != null)
            {
                Orders.Remove(order);
            }
            return RedirectToAction("Order");
        }
    }
}