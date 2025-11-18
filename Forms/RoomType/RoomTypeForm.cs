
using HotelManagement.Business.Services;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.Forms.RoomType
{
    public partial class RoomTypeForm : Form
    {
        private readonly RoomTypeService _roomTypeService;
        public Models.RoomType selectedRoomType;
        public RoomTypeForm()
        {
            InitializeComponent();
            _roomTypeService = new RoomTypeService();
        }

        private void RoomTypeForm_Load(object sender, EventArgs e)
        {
            this.Name = "Quản lý loại phòng";
            this.btnDetail.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDelete.Enabled = false;
            LoadRoomTypes();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadRoomTypes()
        {
            List<Models.RoomType> rooms = _roomTypeService.GetAllRoomTypes().ToList();

            // Bind to DataGridView
            dgvRoomType.AutoGenerateColumns = true;
            dgvRoomType.DataSource = rooms;
            dgvRoomType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoomType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void displayRoomTypeInfo()
        {
            if (selectedRoomType != null)
            {
                this.txtBoxName.Text = selectedRoomType.Name;
                this.txtBoxMaxCapacity.Text = selectedRoomType.MaximumCapacity.ToString();
                this.txtBoxDesc.Text = selectedRoomType.Description;
                this.txtBoxBasePrice.Text = selectedRoomType.BasePricePerNight.ToString();
            }
        }

        private void dgvRoomType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    selectedRoomType = new Models.RoomType();
                    DataGridViewRow dr = this.dgvRoomType.Rows[e.RowIndex];
                    Console.WriteLine(dr);
                    Console.WriteLine(dr.Cells[1].Value.ToString());
                    selectedRoomType.RoomTypeId = int.Parse(dr.Cells[0].Value.ToString());
                    selectedRoomType.Name = dr.Cells[1].Value.ToString();
                    selectedRoomType.Description = dr.Cells[2].Value.ToString();
                    selectedRoomType.BasePricePerNight = decimal.Parse(dr.Cells[3].Value.ToString());
                    selectedRoomType.MaximumCapacity = int.Parse(dr.Cells[4].Value.ToString());

                    displayRoomTypeInfo();

                    this.btnDetail.Enabled = true;
                    this.btnEdit.Enabled = true;
                    this.btnDelete.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            RoomTypeSaveForm roomTypeSaveForm = new RoomTypeSaveForm();
            roomTypeSaveForm.IsUpdate = true;
            roomTypeSaveForm.roomType = selectedRoomType;
            if (roomTypeSaveForm.ShowDialog() == DialogResult.OK)
            {
                LoadRoomTypes();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RoomTypeSaveForm roomTypeSaveForm = new RoomTypeSaveForm();
            roomTypeSaveForm.IsUpdate = false;
            if (roomTypeSaveForm.ShowDialog() == DialogResult.OK)
            {
                LoadRoomTypes();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa loại phòng này không?\nXóa bỏ sẽ ảnh hưởng tới các phòng thuộc loại này.", "Xác nhận", MessageBoxButtons.YesNo);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    {
                        bool result = _roomTypeService.DeleteRoomType(selectedRoomType.RoomTypeId);
                        if (result)
                        {
                            MessageBox.Show("Xóa loại phòng thành công!", "Thông báo");
                            LoadRoomTypes();

                        }
                        else
                        {
                            MessageBox.Show("Xóa loại phòng không thành công!", "Thông báo");
                        }
                        break;
                    }
                case DialogResult.No:
                    break;
                default:
                    break;
            }
        }
    }
}
