using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    public class Customer
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }

        public Customer()
        {
            ID = Guid.NewGuid().ToString();
        }

        public Customer(string iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public static void Add(Customer customer)
        {
            try
            {
                using (var context = new OrderContext())
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                //TODO 需要更加错误类型返回不同错误信息
                throw new ApplicationException($"添加错误!");
            }
        }

        public static List<Customer> GetAll()
        {
            using (var context = new OrderContext())
            {
                try
                {
                    context.Customers.ToList();

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return context.Customers.ToList();
            }
        }

        public override bool Equals(object obj)
        {
            var customer = obj as Customer;
            return customer != null &&
                   ID == customer.ID &&
                   Name == customer.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = 1479869798;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
