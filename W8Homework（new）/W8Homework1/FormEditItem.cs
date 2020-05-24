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
    public partial class FormEditItem : Form
    {
        public OrderItem OrderItem1 { get; set; }

        public FormEditItem()
        {
            InitializeComponent();
        }

        public FormEditItem(OrderItem orderItem):this()
        {
            OrderItem1 = orderItem;
            this.OrderItemBindingSource.DataSource = OrderItem1;
        }


        private void btnCommit_Click(object sender, EventArgs e)
        {
            this.OrderItemBindingSource.ResetBindings(true);
            this.Close();
        }

        private void LblName_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
