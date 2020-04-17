namespace W8Homework1
{
    partial class FormEditItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCommit = new System.Windows.Forms.Button();
            this.LblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtUnitprice = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.LblID = new System.Windows.Forms.Label();
            this.LblUnitPrice = new System.Windows.Forms.Label();
            this.LblNum = new System.Windows.Forms.Label();
            this.OrderItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OrderItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCommit
            // 
            this.btnCommit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCommit.Location = new System.Drawing.Point(169, 277);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(138, 48);
            this.btnCommit.TabIndex = 0;
            this.btnCommit.Text = "确定";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblName.Location = new System.Drawing.Point(67, 64);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(73, 21);
            this.LblName.TabIndex = 1;
            this.LblName.Text = "商品名";
            this.LblName.Click += new System.EventHandler(this.LblName_Click);
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OrderItemBindingSource, "Name", true));
            this.txtName.Location = new System.Drawing.Point(182, 61);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(165, 28);
            this.txtName.TabIndex = 2;
            // 
            // txtID
            // 
            this.txtID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OrderItemBindingSource, "ID", true));
            this.txtID.Location = new System.Drawing.Point(182, 108);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(165, 28);
            this.txtID.TabIndex = 3;
            // 
            // txtUnitprice
            // 
            this.txtUnitprice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OrderItemBindingSource, "UnitPrice", true));
            this.txtUnitprice.Location = new System.Drawing.Point(182, 158);
            this.txtUnitprice.Name = "txtUnitprice";
            this.txtUnitprice.Size = new System.Drawing.Size(165, 28);
            this.txtUnitprice.TabIndex = 4;
            // 
            // txtNum
            // 
            this.txtNum.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OrderItemBindingSource, "Num", true));
            this.txtNum.Location = new System.Drawing.Point(182, 206);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(165, 28);
            this.txtNum.TabIndex = 5;
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblID.Location = new System.Drawing.Point(68, 118);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(74, 21);
            this.LblID.TabIndex = 6;
            this.LblID.Text = "商品ID";
            // 
            // LblUnitPrice
            // 
            this.LblUnitPrice.AutoSize = true;
            this.LblUnitPrice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblUnitPrice.Location = new System.Drawing.Point(68, 168);
            this.LblUnitPrice.Name = "LblUnitPrice";
            this.LblUnitPrice.Size = new System.Drawing.Size(94, 21);
            this.LblUnitPrice.TabIndex = 7;
            this.LblUnitPrice.Text = "商品单价";
            // 
            // LblNum
            // 
            this.LblNum.AutoSize = true;
            this.LblNum.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblNum.Location = new System.Drawing.Point(68, 216);
            this.LblNum.Name = "LblNum";
            this.LblNum.Size = new System.Drawing.Size(94, 21);
            this.LblNum.TabIndex = 8;
            this.LblNum.Text = "商品数量";
            // 
            // OrderItemBindingSource
            // 
            this.OrderItemBindingSource.DataSource = typeof(OrderManager.OrderItem);
            // 
            // FormEditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 337);
            this.Controls.Add(this.LblNum);
            this.Controls.Add(this.LblUnitPrice);
            this.Controls.Add(this.LblID);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.txtUnitprice);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.btnCommit);
            this.Name = "FormEditItem";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.OrderItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtUnitprice;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label LblID;
        private System.Windows.Forms.Label LblUnitPrice;
        private System.Windows.Forms.Label LblNum;
        private System.Windows.Forms.BindingSource OrderItemBindingSource;
    }
}