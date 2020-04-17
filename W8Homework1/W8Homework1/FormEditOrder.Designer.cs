namespace W8Homework1
{
    partial class FormEditOrder
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LblClient = new System.Windows.Forms.Label();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.BtnAddItem = new System.Windows.Forms.Button();
            this.BtnDeleteItem = new System.Windows.Forms.Button();
            this.dataGridViewForItem = new System.Windows.Forms.DataGridView();
            this.OrderItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BtnSave = new System.Windows.Forms.Button();
            this.OrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnSave);
            this.splitContainer1.Panel1.Controls.Add(this.BtnDeleteItem);
            this.splitContainer1.Panel1.Controls.Add(this.BtnAddItem);
            this.splitContainer1.Panel1.Controls.Add(this.txtClient);
            this.splitContainer1.Panel1.Controls.Add(this.LblClient);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewForItem);
            this.splitContainer1.Size = new System.Drawing.Size(655, 473);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.TabIndex = 0;
            // 
            // LblClient
            // 
            this.LblClient.AutoSize = true;
            this.LblClient.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblClient.Location = new System.Drawing.Point(56, 67);
            this.LblClient.Name = "LblClient";
            this.LblClient.Size = new System.Drawing.Size(73, 21);
            this.LblClient.TabIndex = 0;
            this.LblClient.Text = "客户名";
            // 
            // txtClient
            // 
            this.txtClient.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.OrderBindingSource, "Client", true));
            this.txtClient.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtClient.Location = new System.Drawing.Point(145, 57);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(225, 31);
            this.txtClient.TabIndex = 1;
            // 
            // BtnAddItem
            // 
            this.BtnAddItem.Location = new System.Drawing.Point(60, 135);
            this.BtnAddItem.Name = "BtnAddItem";
            this.BtnAddItem.Size = new System.Drawing.Size(92, 37);
            this.BtnAddItem.TabIndex = 2;
            this.BtnAddItem.Text = "增加明细";
            this.BtnAddItem.UseVisualStyleBackColor = true;
            this.BtnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);
            // 
            // BtnDeleteItem
            // 
            this.BtnDeleteItem.Location = new System.Drawing.Point(191, 135);
            this.BtnDeleteItem.Name = "BtnDeleteItem";
            this.BtnDeleteItem.Size = new System.Drawing.Size(100, 37);
            this.BtnDeleteItem.TabIndex = 3;
            this.BtnDeleteItem.Text = "删除明细";
            this.BtnDeleteItem.UseVisualStyleBackColor = true;
            this.BtnDeleteItem.Click += new System.EventHandler(this.BtnDeleteItem_Click);
            // 
            // dataGridViewForItem
            // 
            this.dataGridViewForItem.AutoGenerateColumns = false;
            this.dataGridViewForItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewForItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn,
            this.numDataGridViewTextBoxColumn,
            this.unitPriceDataGridViewTextBoxColumn});
            this.dataGridViewForItem.DataSource = this.OrderItemBindingSource;
            this.dataGridViewForItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewForItem.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewForItem.Name = "dataGridViewForItem";
            this.dataGridViewForItem.RowTemplate.Height = 30;
            this.dataGridViewForItem.Size = new System.Drawing.Size(655, 270);
            this.dataGridViewForItem.TabIndex = 0;
            // 
            // OrderItemBindingSource
            // 
            this.OrderItemBindingSource.DataMember = "OrderItems";
            this.OrderItemBindingSource.DataSource = this.OrderBindingSource;
            // 
            // BtnSave
            // 
            this.BtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnSave.Location = new System.Drawing.Point(495, 135);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(102, 37);
            this.BtnSave.TabIndex = 5;
            this.BtnSave.Text = "保存订单";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // OrderBindingSource
            // 
            this.OrderBindingSource.DataSource = typeof(OrderManager.Order);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // numDataGridViewTextBoxColumn
            // 
            this.numDataGridViewTextBoxColumn.DataPropertyName = "Num";
            this.numDataGridViewTextBoxColumn.HeaderText = "Num";
            this.numDataGridViewTextBoxColumn.Name = "numDataGridViewTextBoxColumn";
            // 
            // unitPriceDataGridViewTextBoxColumn
            // 
            this.unitPriceDataGridViewTextBoxColumn.DataPropertyName = "UnitPrice";
            this.unitPriceDataGridViewTextBoxColumn.HeaderText = "UnitPrice";
            this.unitPriceDataGridViewTextBoxColumn.Name = "unitPriceDataGridViewTextBoxColumn";
            // 
            // FormEditOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 473);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormEditOrder";
            this.Text = "FormEditOrder";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label LblClient;
        private System.Windows.Forms.Button BtnDeleteItem;
        private System.Windows.Forms.Button BtnAddItem;
        private System.Windows.Forms.DataGridView dataGridViewForItem;
        private System.Windows.Forms.BindingSource OrderBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource OrderItemBindingSource;
        private System.Windows.Forms.Button BtnSave;
    }
}