namespace HotelManagement.Forms.Room
{
    partial class RoomForm
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
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxMinCap = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxMaxCap = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxMinPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxMaxPrice = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxSearchTerm = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRoomType = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvRoom = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgvRoom, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(982, 653);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label4);
            this.flowLayoutPanel4.Controls.Add(this.txtBoxMinCap);
            this.flowLayoutPanel4.Controls.Add(this.label6);
            this.flowLayoutPanel4.Controls.Add(this.txtBoxMaxCap);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(395, 68);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(386, 59);
            this.flowLayoutPanel4.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "Số người";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBoxMinCap
            // 
            this.txtBoxMinCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMinCap.Location = new System.Drawing.Point(83, 3);
            this.txtBoxMinCap.Name = "txtBoxMinCap";
            this.txtBoxMinCap.Size = new System.Drawing.Size(92, 26);
            this.txtBoxMinCap.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(181, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "-";
            // 
            // txtBoxMaxCap
            // 
            this.txtBoxMaxCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMaxCap.Location = new System.Drawing.Point(202, 3);
            this.txtBoxMaxCap.Name = "txtBoxMaxCap";
            this.txtBoxMaxCap.Size = new System.Drawing.Size(105, 26);
            this.txtBoxMaxCap.TabIndex = 4;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label3);
            this.flowLayoutPanel3.Controls.Add(this.txtBoxMinPrice);
            this.flowLayoutPanel3.Controls.Add(this.label5);
            this.flowLayoutPanel3.Controls.Add(this.txtBoxMaxPrice);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 68);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(386, 59);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "Khoảng giá";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBoxMinPrice
            // 
            this.txtBoxMinPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMinPrice.Location = new System.Drawing.Point(101, 3);
            this.txtBoxMinPrice.Name = "txtBoxMinPrice";
            this.txtBoxMinPrice.Size = new System.Drawing.Size(82, 26);
            this.txtBoxMinPrice.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(189, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "-";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtBoxMaxPrice
            // 
            this.txtBoxMaxPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxMaxPrice.Location = new System.Drawing.Point(210, 3);
            this.txtBoxMaxPrice.Name = "txtBoxMaxPrice";
            this.txtBoxMaxPrice.Size = new System.Drawing.Size(98, 26);
            this.txtBoxMaxPrice.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Location = new System.Drawing.Point(787, 3);
            this.btnSearch.Name = "btnSearch";
            this.tableLayoutPanel1.SetRowSpan(this.btnSearch, 2);
            this.btnSearch.Size = new System.Drawing.Size(192, 124);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtBoxSearchTerm);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(386, 59);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ khóa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBoxSearchTerm
            // 
            this.txtBoxSearchTerm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSearchTerm.Location = new System.Drawing.Point(77, 3);
            this.txtBoxSearchTerm.Name = "txtBoxSearchTerm";
            this.txtBoxSearchTerm.Size = new System.Drawing.Size(231, 26);
            this.txtBoxSearchTerm.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.cbRoomType);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(395, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(386, 59);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 34);
            this.label2.TabIndex = 0;
            this.label2.Text = "Phân loại";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbRoomType
            // 
            this.cbRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRoomType.FormattingEnabled = true;
            this.cbRoomType.Location = new System.Drawing.Point(87, 3);
            this.cbRoomType.Name = "cbRoomType";
            this.cbRoomType.Size = new System.Drawing.Size(224, 28);
            this.cbRoomType.TabIndex = 1;
            this.cbRoomType.SelectedIndexChanged += new System.EventHandler(this.cbRoomType_SelectedIndexChange);
            // 
            // flowLayoutPanel5
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel5, 2);
            this.flowLayoutPanel5.Controls.Add(this.btnDetail);
            this.flowLayoutPanel5.Controls.Add(this.btnAdd);
            this.flowLayoutPanel5.Controls.Add(this.btnUpdate);
            this.flowLayoutPanel5.Controls.Add(this.btnDelete);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 590);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(778, 60);
            this.flowLayoutPanel5.TabIndex = 5;
            // 
            // btnDetail
            // 
            this.btnDetail.Location = new System.Drawing.Point(3, 3);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(123, 36);
            this.btnDetail.TabIndex = 3;
            this.btnDetail.Text = "Chi tiết";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(132, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(123, 36);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(261, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(123, 36);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(390, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(123, 36);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvRoom
            // 
            this.dgvRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvRoom, 3);
            this.dgvRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRoom.Location = new System.Drawing.Point(3, 133);
            this.dgvRoom.Name = "dgvRoom";
            this.dgvRoom.RowHeadersWidth = 51;
            this.dgvRoom.RowTemplate.Height = 24;
            this.dgvRoom.Size = new System.Drawing.Size(976, 451);
            this.dgvRoom.TabIndex = 6;
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 653);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RoomForm";
            this.Text = "RoomForm";
            this.Load += new System.EventHandler(this.RoomForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxMinPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxSearchTerm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbRoomType;
        private System.Windows.Forms.TextBox txtBoxMinCap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxMaxCap;
        private System.Windows.Forms.TextBox txtBoxMaxPrice;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.DataGridView dgvRoom;
    }
}