using Microsoft.VisualStudio.TestTools.UnitTesting;
using W5Homework1;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace OrderServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        public OrderService orderService;
        public  XmlSerializer xmlSerializer;

        [TestInitialize]
        public void Test()
        {
            orderService = new OrderService();
            xmlSerializer = new XmlSerializer(typeof(HashSet<Order>));
        }

        [TestMethod]
        public void AddOrderTest()
        {
            //orderService = new OrderService();
            Order order1 = new Order("iii");
            int i = orderService.orders.Count + 1;
            orderService.AddOrder(order1);
            int j = orderService.orders.Count;
            Assert.IsTrue(i == j);
        }

        [TestMethod]
        public void DeteleOrderTest()
        {
            Order order1 = new Order("iii");
            orderService.AddOrder(order1);
            orderService.DeleteOrder(order1.ID);
            int i = orderService.orders.Count;
            Assert.IsTrue(i == 0);

        }

        [TestMethod]
        public void ModifyOrderTest()
        {
            Order order2 = new Order("jjj");
            OrderItem orderItem1 = new OrderItem("pen", "008", 2, 30);
            order2.AddOrderItem(orderItem1);
            orderService.AddOrder(order2);
            orderService.MotifyOrder(order2.ID,"0","iii");
            Assert.IsTrue(orderService.SearchByClient("iii")!=null);
        }

        [TestMethod]
        public void SearchByIDTest()
        {
            Order order2 = new Order("jjj");
            orderService.AddOrder(order2);
            Assert.AreEqual(order2, orderService.SearchByID(order2.ID));
        }

        [TestMethod]
        public void SearchByClientTest()
        {
            Order order1 = new Order("jjj");
            Order order2 = new Order("jjj");
            HashSet<Order> orders1 = new HashSet<Order>();
            orders1.Add(order1);
            orders1.Add(order2);
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            Assert.IsTrue(orderService.SearchByClient("jjj").Contains(order1)&& orderService.SearchByClient("jjj").Contains(order2));
        }

        [TestMethod]
        public void SearchByProductTest()
        {
            Order order1 = new Order("jjj");
            Order order2 = new Order("jjj");
            OrderItem orderItem1 = new OrderItem("pen", "008", 2, 30);
            order1.AddOrderItem(orderItem1);
            order2.AddOrderItem(orderItem1);
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            Assert.IsTrue(orderService.SearchByProduct("pen").Contains(order1) && orderService.SearchByProduct("pen").Contains(order2));
        }

        [TestMethod]
        public void ExportTest()
        {
            Order order1 = new Order("jjj");
            OrderItem orderItem1 = new OrderItem("pen", "008", 2, 30);
            order1.AddOrderItem(orderItem1);
            orderService.AddOrder(order1);
            orderService.Export();
            using (FileStream fs = new FileStream("s.xml", FileMode.Open))
            {
                HashSet<Order> orders1 = (HashSet<Order>)xmlSerializer.Deserialize(fs);
                Assert.IsTrue(orders1.Contains(order1));
            }
        }
        [TestMethod]
        public void ImportTest()
        {
            int i = orderService.orders.Count;
            orderService.Import();
            Assert.IsTrue(orderService.orders.Count == i + 1);
            
        }
    }
}
