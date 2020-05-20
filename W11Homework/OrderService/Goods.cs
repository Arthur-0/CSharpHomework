using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    public class Goods
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Goods()
        {
        }

        public Goods(string iD, string name, double price)
        {
            ID = iD;
            Name = name;
            Price = price;
        }


        public static void Add(Goods goods)
        {
            try
            {
                using (var db = new OrderContext())
                {
                    db.GoodItems.Add(goods);
                    db.SaveChanges();
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
            using (var db = new OrderContext())
            {
                return db.GoodItems.ToList();
            }
        }

        public override bool Equals(object obj)
        {
            var goods = obj as Goods;
            return goods != null &&
                   ID == goods.ID &&
                   Name == goods.Name;
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
