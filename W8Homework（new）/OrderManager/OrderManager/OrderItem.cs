using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager
{
    [Serializable]
    public class OrderItem
    {
        //定义属性
        public string Name
        {
            get; set;
        }
        public string ID
        {
            get; set;
        }
        public int Num
        {
            get; set;
        }
        public double UnitPrice
        {
            get; set;
        }

        //构造函数
        public OrderItem(string name, string ID, int num, double uniPrice)
        {
            this.ID = ID;
            this.Name = name;
            this.Num = num;
            this.UnitPrice = uniPrice;
        }

        public OrderItem(){}
        
        

        
        override public string ToString()
        {
            return String.Format("{0, -13}", this.ID) + String.Format("{0, -7}", this.Name) + String.Format("{0, -6}", this.Num) + String.Format("{0, -12}", this.UnitPrice) + this.UnitPrice*this.Num + "\n";
        }

        public override bool Equals(object obj)
        {
            var item = obj as OrderItem;
            return item != null &&
                   Name == item.Name &&
                   ID == item.ID;
        }

        public override int GetHashCode()
        {
            var hashCode = 1997165910;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ID);
            return hashCode;
        }
    }
}
