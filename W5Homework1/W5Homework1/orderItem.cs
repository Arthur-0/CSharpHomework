using System;
using System.Collections.Generic;
using System.Text;

namespace W5Homework1
{
    class OrderItem
    {
        //定义属性
        private string Name;
        public string name
        {
            set { Name = value; }
            get { return Name; }
        }
        private string ID;
        public string id
        {
            set { ID = value; }
            get { return ID; }
        }
        private int Num;
        public int num
        {
            set { Num = value;}
            get { return Num; }
        }
        private double UnitPrice;
        public double unitPrice
        {
            set { UnitPrice = value; }
            get { return UnitPrice; }
        }

        //构造函数
        public OrderItem(string name,string ID,int num,double uniPrice)
        {
            this.ID = ID;
            this.Name = name;
            this.Num = num;
            this.UnitPrice = uniPrice;
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
            return HashCode.Combine(Name, ID);
        }

        
        public string toString()
        {
            return String.Format("{0, -13}", this.ID) + String.Format("{0, -7}", this.Name) + String.Format("{0, -6}", this.Num) + String.Format("{0, -12}", this.unitPrice) + this.unitPrice*this.Num + "\n";
        }
    }
}
