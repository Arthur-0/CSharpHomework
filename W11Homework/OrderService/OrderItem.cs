using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{


    public class OrderItem
    {

        [Key]
        public string Id { get; set; }

        public int Index { get; set; } //序号

        [ForeignKey("GoodsItemId")]
        public Goods GoodsItem { get; set; }

        public String GoodsName { get; set; }

        public double UnitPrice { get; set; }

        public string GoodsItemId { get; set; }

        public string OrderId { get; set; }


        public int Quantity { get; set; }

        public OrderItem() {
            Id = Guid.NewGuid().ToString();

        }

        public OrderItem(int index, Goods goods, int quantity) : this()
        {
            this.Index = index;
            this.GoodsItem = goods;
            this.Quantity = quantity;
        }

        public double TotalPrice
        {
            get => UnitPrice * Quantity;
        }

        public override string ToString()
        {
            return $"[No.:{Index},goods:{GoodsName},quantity:{Quantity},totalPrice:{TotalPrice}]";
        }

        public override bool Equals(object obj)
        {
            var item = obj as OrderItem;
            return item != null &&
                   GoodsName == item.GoodsName;
        }

        public override int GetHashCode()
        {
            var hashCode = -2127770830;
            hashCode = hashCode * -1521134295 + Index.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GoodsName);
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }
    }
}
