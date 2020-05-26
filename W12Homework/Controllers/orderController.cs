using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using W12Homework.Models;

namespace W12Homework.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class orderController : ControllerBase
    {
        private readonly OrderContext orderDb;

        public orderController(OrderContext context)
        {
            this.orderDb = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(string id)
        {
            var order = orderDb.Orders.FirstOrDefault(t => t.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(string id)
        {
            try
            {
                var order = orderDb.Orders.FirstOrDefault(t => t.Id == id);
                if (order != null)
                {
                    orderDb.Remove(order);
                    orderDb.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

        
        [HttpPost("{id}")]
        public ActionResult<OrderItem> PostOrder(OrderItem orderItem,string id)
        {
            try
            {
                var order = orderDb.Orders.FirstOrDefault(t => t.Id == id);
                order.Items.Add(orderItem);
                orderDb.OrderItems.Add(orderItem);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return orderItem;
        }

        [HttpPost]
        public ActionResult<Order> PostOrderItem(Order order)
        {
            try
            {
                orderDb.Orders.Add(order);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return order;
        }

        [HttpPut("{id}")]
        public ActionResult<Order> PutTodoItem(string id, OrderItem order)
        {
            if (id != order.Id)
            {
                return BadRequest("Id cannot be modified!");
            }
            try
            {
                orderDb.Entry(order).State = EntityState.Modified;
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null) error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        [HttpGet("Query")]
        public ActionResult<List<Order>> queryTodoItem(string Id, string customer)
        {
            var query = buildQuery(Id, customer);
            return query.ToList();
        }

        private IQueryable<Order> buildQuery(string Id, string customer)
        {
            IQueryable<Order> query = orderDb.Orders;
            if (Id != null)
            {
                query = query.Where(t => t.Id.Contains(Id));
            }
            if (customer != null)
            {
                query = query.Where(t => t.Customer == customer);
            }
            return query;
        }


      

    }

}
