using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderManager;

namespace W8Homework1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public OrderService orderService1;
        public String SearchType { get; set; }
        public String SearchBy { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            Order order1 = new Order("Ruby");
            OrderItem orderItem1 = new OrderItem("bag", "001", 5, 90);
            OrderItem orderItem2 = new OrderItem("shoes", "002", 2, 190);
            order1.AddOrderItem(orderItem1);
            order1.AddOrderItem(orderItem2);
            OrderItem orderItem3 = new OrderItem("pen", "008", 2, 30);
            OrderItem orderItem4 = new OrderItem("book", "004", 2, 20);
            orderService1 = new OrderService();
            Order order3 = new Order("Mike");
            order3.AddOrderItem(orderItem1);
            order3.AddOrderItem(orderItem2);
            order3.AddOrderItem(orderItem3);
            order3.AddOrderItem(orderItem4);
            orderService1.AddOrder(order1);
            orderService1.AddOrder(order3);
            orderBindingSource.DataSource = orderService1.orders;

            cbxSearchType.DataBindings.Add("SelectedItem", this, "searchType");
            txtSearch.DataBindings.Add("Text", this, "searchBy");
        }

        private void lblTypeForSearch_Click(object sender, EventArgs e)
        {

        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch(SearchType)
            {
                case "订单号":
                    orderBindingSource.DataSource = orderService1.SearchByID(SearchBy);
                    break;
                case "客户名":
                    orderBindingSource.DataSource = orderService1.SearchByClient(SearchBy);
                    break;
                case "商品名":
                    orderBindingSource.DataSource = orderService1.SearchByProduct(SearchBy);
                    break;
                default:
                    break;
            }
            orderBindingSource.ResetBindings(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormEditOrder subfrom = new FormEditOrder(new Order());
            if(subfrom.ShowDialog()==DialogResult.OK)
            {
                this.orderService1.AddOrder(subfrom.currentOrder);
            }
            QueryAll();
            
        }


        private void BtnDetele_Click(object sender, EventArgs e)
        {
            Order currentOrder = orderBindingSource.Current as Order;
            if (currentOrder == null) {
                MessageBox.Show("请选择一个订单项删除");
                return;
            }
       
            orderService1.orders.Remove(currentOrder);
            QueryAll();
              
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            Order currentOrder = orderBindingSource.Current as Order;
            if (currentOrder == null)
            {
                MessageBox.Show("请选择一个订单进行修改");
                return;
            }
            FormEditOrder subfrom = new FormEditOrder(currentOrder);
            if (subfrom.ShowDialog() == DialogResult.OK)
            {
                this.orderService1.UpdateOrder(subfrom.currentOrder);
            }
            QueryAll();
        }

        private void QueryAll()
        {
            orderBindingSource.DataSource = orderService1.orders;
            orderBindingSource.ResetBindings(false);
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void dataGridViewOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
