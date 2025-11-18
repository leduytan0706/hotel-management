namespace HotelManagement.Forms.RoomType
{
    partial class RoomTypeForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvRoomType = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.txtBoxMaxCapacity = new System.Windows.Forms.TextBox();
            this.txtBoxDesc = new System.Windows.Forms.TextBox();
            this.txtBoxBasePrice = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomType)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.Controls.Add(this.dgvRoomType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvRoomType
            // 
            this.dgvRoomType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoomType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRoomType.Location = new System.Drawing.Point(363, 3);
            this.dgvRoomType.Name = "dgvRoomType";
            this.dgvRoomType.RowHeadersWidth = 51;
            this.tableLayoutPanel1.SetRowSpan(this.dgvRoomType, 2);
            this.dgvRoomType.RowTemplate.Height = 24;
            this.dgvRoomType.Size = new System.Drawing.Size(434, 444);
            this.dgvRoomType.TabIndex = 0;
            this.dgvRoomType.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoomType_CellClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtBoxName, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtBoxMaxCapacity, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtBoxDesc, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtBoxBasePrice, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(354, 309);
            this.tableLayoutPanel2.TabIndex = 1;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại phòng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số người";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 61);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mô tả";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giá cơ bản";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBoxName
            // 
            this.txtBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxName.Location = new System.Drawing.Point(109, 95);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(242, 22);
            this.txtBoxName.TabIndex = 4;
            // 
            // txtBoxMaxCapacity
            // 
            this.txtBoxMaxCapacity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxMaxCapacity.Location = new System.Drawing.Point(109, 125);
            this.txtBoxMaxCapacity.Name = "txtBoxMaxCapacity";
            this.txtBoxMaxCapacity.Size = new System.Drawing.Size(242, 22);
            this.txtBoxMaxCapacity.TabIndex = 5;
            // 
            // txtBoxDesc
            // 
            this.txtBoxDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxDesc.Location = new System.Drawing.Point(109, 155);
            this.txtBoxDesc.Multiline = true;
            this.txtBoxDesc.Name = "txtBoxDesc";
            this.txtBoxDesc.Size = new System.Drawing.Size(242, 55);
            this.txtBoxDesc.TabIndex = 6;
            // 
            // txtBoxBasePrice
            // 
            this.txtBoxBasePrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxBasePrice.Location = new System.Drawing.Point(109, 216);
            this.txtBoxBasePrice.Name = "txtBoxBasePrice";
            this.txtBoxBasePrice.Size = new System.Drawing.Size(242, 22);
            this.txtBoxBasePrice.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel2, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 318);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(354, 129);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnDetail);
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(73, 28);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(206, 32);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnDetail
            // 
            this.btnDetail.AutoSize = true;
            this.btnDetail.Location = new System.Drawing.Point(3, 3);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(93, 26);
            this.btnDetail.TabIndex = 0;
            this.btnDetail.Text = "Chi tiết";
            this.btnDetail.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Location = new System.Drawing.Point(102, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(99, 26);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnEdit);
            this.flowLayoutPanel2.Controls.Add(this.btnDelete);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(73, 66);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(206, 32);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.btnEdit.Location = new System.Drawing.Point(3, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(93, 26);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Chỉnh sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Location = new System.Drawing.Point(102, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 26);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // RoomTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RoomTypeForm";
            this.Text = "RoomTypeForm";
            this.Load += new System.EventHandler(this.RoomTypeForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomType)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvRoomType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.TextBox txtBoxMaxCapacity;
        private System.Windows.Forms.TextBox txtBoxDesc;
        private System.Windows.Forms.TextBox txtBoxBasePrice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}