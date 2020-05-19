using System;
using System.Collections.Generic;
using System.Data.Entity;
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
          
            Orders = new List<Order>();
            using (var context=new OrderContext())
            {
                foreach(Order order in context.orders)
                {
                    this.Orders.Add(order);
                }
            }
        }

        public Order GetOrder(string id)
        {
            var query = Orders
                    .Where(order => order.OrderId == id)
                    .OrderBy(o => o.TotalPrice);
            return query as Order;
        }

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
            catch (Exception e)
            {
                //TODO 需要更加错误类型返回不同错误信息
                throw new ApplicationException($"添加错误: {e.Message}");
            }
        }

        //删除订单
        public void DeleteOrder(string ID)
        {
            Order order1 = SearchByID(ID);
            if(order1!=null)
            {
                Orders.Remove(order1);
                using (var context = new OrderContext())
                {
                    context.orders.Remove(order1);
                    context.SaveChanges();
                    Console.WriteLine("成功删除订单");
                }
            }
            
        }

        public Order SearchByID(string ID)
        {
            var query = Orders
                    .Where(order => order.OrderId==ID)
                    .OrderBy(o => o.TotalPrice);
            return query as Order;
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
            Order oldOrder = GetOrder(newOrder.OrderId);
            if (oldOrder == null)
                throw new ApplicationException($"修改错误：订单 {newOrder.OrderId} 不存在!");

            using (var context = new OrderContext())
            {
                context.Entry(newOrder).State = EntityState.Modified;
                context.orderItems.AddRange(newOrder.Items);
                context.SaveChanges();

            }
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
