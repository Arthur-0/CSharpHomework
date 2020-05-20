using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace OrderApp
{

    /**
     * The service class to manage orders
     * */
    public class OrderService
    {

        private List<Order> orders;

        public List<Order> Orders { get => orders; set => orders = value; }
        public OrderService()
        {
            this.orders = GetAllOrders();
        }

        public static List<Order> GetAllOrders()
        {
            using (var context = new OrderContext())
            {
                return AllOrders(context).ToList();
            }
        }

        public  Order GetOrder(string id)
        {
            using (var context = new OrderContext()) { 
            
                return AllOrders(context).FirstOrDefault(o => o.OrderId == id);
            }
        }

        /*

        public Order GetOrder(string id)
        {
            var query = Orders
                    .Where(order => order.OrderId == id)
                    .OrderBy(o => o.TotalPrice);
            return query as Order;
        }*/

        public Order AddOrder(Order order1)
        {
            this.Orders.Add(order1);
            try
            {
                using (var context = new OrderContext())
                {
                    
                    context.orders.Add(order1);
                    context.SaveChanges();
                }
                return order1;
            }
            catch (DbEntityValidationException dbEx)
            {
                //TODO 需要更加错误类型返回不同错误信息
                throw new ApplicationException($"添加错误: {dbEx.Message}");
            }
        }

        //删除订单
        public void DeleteOrder(string ID)
        {
            using (var context = new OrderContext())
            {
                var order = context.orders.Include("Items").Where(o =>o.OrderId == ID).FirstOrDefault();
                this.orders.Remove(order);
                context.orders.Remove(order);
                context.SaveChanges();

            }
            
        }

        public Order SearchByID(string ID)
        {
            var query = Orders
                    .Where(order => order.OrderId==ID)
                    .OrderBy(o => o.TotalPrice);
            return query.ToList().First();
        }

        public List<Order> QueryOrdersByGoodsName(string goodsName)
        {
            var query = Orders
                    .Where(order => order.Items.Exists(item => item.GoodsName == goodsName))
                    .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }

        public List<Order> QueryOrdersByCustomerName(string customerName)
        {
            return Orders
                .Where(order => order.CustomerName == customerName)
                .OrderBy(o => o.TotalPrice)
                .ToList();
        }

        public void UpdateOrder(Order newOrder)
        {
            deleteItems(newOrder.OrderId);

            using (var context = new OrderContext())
            {
                context.Entry(newOrder).State = EntityState.Modified;
                context.orderItems.AddRange(newOrder.Items);
                context.SaveChanges();

            }
        }

        private static void deleteItems(string orderId)
        {
            using (var db = new OrderContext())
            {
                var oldItems = db.orderItems.Where(item => item.OrderId == orderId);
                db.orderItems.RemoveRange(oldItems);
                db.SaveChanges();
            }
        }

        private static IQueryable<Order> AllOrders(OrderContext context)
        {
            return context.orders.Include(o => o.Items.Select(i => i.GoodsItem))
                      .Include("Customer");
        }


        //删除订单明细
        public void DeleteOrderItem(OrderItem orderItem)
        {
            using (var context = new OrderContext())
            {
                context.orderItems.Remove(orderItem);
                context.SaveChanges();
            }

        }

        public void Sort()
        {
            Orders.Sort();
        }

        public void Sort(Func<Order, Order, int> func)
        {
            Orders.Sort((o1, o2) => func(o1, o2));
        }

        public void Export(String fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xs.Serialize(fs, Orders);
            }
        }

        public void Import(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Order> temp = (List<Order>)xs.Deserialize(fs);
                temp.ForEach((Action<Order>)(order =>
                {
                    if (!this.Orders.Contains(order))
                    {
                        this.Orders.Add(order);
                    }
                }));
            }
        }

        public object QueryByTotalAmount(float amout)
        {
            return Orders
               .Where(order => order.TotalPrice >= amout)
               .OrderByDescending(o => o.TotalPrice)
               .ToList();
        }

        public static void AddGood(Goods goods)
        {
            try
            {
                using (var context = new OrderContext())
                {
                    context.GoodItems.Add(goods);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                //TODO 需要更加错误类型返回不同错误信息
                throw new ApplicationException($"添加错误!");
            }
        }

        public static List<Goods> GetAll()
        {
            using (var context = new OrderContext())
            {
                return context.GoodItems.ToList();
            }
        }

        public static void AddCustomer(Customer customer)
        {
            try
            {
                using (var db = new OrderContext())
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                //TODO 需要更加错误类型返回不同错误信息
                throw new ApplicationException($"添加错误!");
            }
        }
    }
}
