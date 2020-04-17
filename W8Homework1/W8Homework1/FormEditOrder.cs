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
    public partial class FormEditOrder : Form
    {
        public Order currentOrder { get; set; }

        public FormEditOrder()
        {
            InitializeComponent();
        }

        public FormEditOrder(Order order):this()
        {
            currentOrder = order;
            this.OrderBindingSource.DataSource = currentOrder;

        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            FormEditItem formEditItem = new FormEditItem(new OrderItem());
            if(formEditItem.ShowDialog()==DialogResult.OK)
            {
                currentOrder.OrderItems.Add(formEditItem.OrderItem1);
            }
            this.OrderItemBindingSource.ResetBindings(false);
            
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnDeleteItem_Click(object sender, EventArgs e)
        {
            OrderItem currentOrderItem = this.OrderItemBindingSource.Current as OrderItem;
            if(currentOrder==null)
            {
                MessageBox.Show("请选择一个明细项删除");
                return;
            }
            currentOrder.OrderItems.Remove(currentOrderItem);
            this.OrderItemBindingSource.ResetBindings(false);
        }
    }
}
