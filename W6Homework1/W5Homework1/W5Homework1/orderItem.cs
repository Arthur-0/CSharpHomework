using System;
using System.Collections.Generic;
using System.Text;

namespace W5Homework1
{
    [Serializable]
    public class OrderItem
    {
        //定义属性
        public string Name;
        public string ID;
        public int Num;
        public double UnitPrice;

        //构造函数
        public OrderItem(string name, string ID, int num, double uniPrice)
        {
            this.ID = ID;
            this.Name = name;
            this.Num = num;
            this.UnitPrice = uniPrice;
        }

        public OrderItem(){}
        
        public override bool Equals(object obj)
        {
            var item = obj as OrderItem;
            return item != null &&
                   Name == item.Name &&
                   ID == item.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, ID);
        }

        
        override public string ToString()
        {
            return String.Format("{0, -13}", this.ID) + String.Format("{0, -7}", this.Name) + String.Format("{0, -6}", this.Num) + String.Format("{0, -12}", this.UnitPrice) + this.UnitPrice*this.Num + "\n";
        }
    }
}
