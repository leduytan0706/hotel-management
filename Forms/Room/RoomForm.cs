using HotelManagement.Business.DTOs;
using HotelManagement.Business.Interfaces;
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

namespace HotelManagement.Forms.Room
{
    public partial class RoomForm : Form
    {
        private readonly RoomService _roomService;
        private int selectedRoomTypeId = 0;
        private Models.Room _selectedRoom;
        public RoomForm()
        {
            InitializeComponent();
            _roomService = new RoomService();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            RoomSaveForm roomSaveForm = new RoomSaveForm();
            roomSaveForm.IsUpdate = false;
            if (roomSaveForm.ShowDialog() == DialogResult.OK)
            {
                LoadRooms();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RoomSaveForm roomSaveForm = new RoomSaveForm();
            roomSaveForm.IsUpdate = true;
            roomSaveForm.SelectedRoom = _selectedRoom;
            if (roomSaveForm.ShowDialog() == DialogResult.OK)
            {
                LoadRooms();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa loại phòng này không?\nXóa bỏ sẽ ảnh hưởng tới các phòng thuộc loại này.", "Xác nhận", MessageBoxButtons.YesNo);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    {
                        try
                        {
                            bool result = _roomService.DeleteRoom(_selectedRoom.RoomId);
                            if (result)
                            {
                                MessageBox.Show("Xóa phòng thành công!", "Thông báo");
                                LoadRooms();

                            }
                            else
                            {
                                MessageBox.Show("Xóa phòng không thành công!", "Thông báo");
                            }
                            break;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Thông báo");
                            return;
                        }
                    }
                case DialogResult.No:
                    break;
                default:
                    break;
            }
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            this.Name = "Quản lý phòng";
            this.btnUpdate.Enabled = false;
            this.btnDelete.Enabled = false;
            LoadRooms();
        }

        private void LoadRooms()
        {
            List<RoomDto> rooms = _roomService.GetAllRooms().ToList();

            // Bind to DataGridView
            BindDataToGrid(rooms);
        }

        private void BindDataToGrid(List<RoomDto> rooms)
        {
            this.dgvRoom.AutoGenerateColumns = true;
            this.dgvRoom.DataSource = rooms;
            this.dgvRoom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoom.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.dgvRoom.Columns["RoomId"].HeaderText = "ID";
            this.dgvRoom.Columns["RoomNumber"].HeaderText = "Số phòng";
            this.dgvRoom.Columns["RoomTypeId"].HeaderText = "Mã loại phòng";
            this.dgvRoom.Columns["RoomTypeName"].HeaderText = "Tên loại phòng";
            this.dgvRoom.Columns["Status"].HeaderText = "Mã trạng thái";
            this.dgvRoom.Columns["StatusName"].HeaderText = "Trạng thái";
            this.dgvRoom.Columns["Description"].HeaderText = "Mô tả";
            this.dgvRoom.Columns["DefaultPrice"].HeaderText = "Giá mặc định";
            this.dgvRoom.Columns["MaximumCapacity"].HeaderText = "Số người";
            this.dgvRoom.Columns["UpdatedAt"].HeaderText = "Ngày cập nhật";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtBoxSearchTerm.Text.Trim();
            decimal minPrice = txtBoxMinPrice.Text.Trim() == "" ? 0 : decimal.Parse(txtBoxMinPrice.Text.Trim());
            decimal maxPrice = txtBoxMaxPrice.Text.Trim() == "" ? decimal.MaxValue : decimal.Parse(txtBoxMaxPrice.Text.Trim());
            int minCapacity = txtBoxMinCap.Text.Trim() == "" ? 0 : int.Parse(txtBoxMinCap.Text.Trim());
            int maxCapacity = txtBoxMaxCap.Text.Trim() == "" ? 0 : int.Parse(txtBoxMaxCap.Text.Trim());

            if (searchTerm.Length == 0 && selectedRoomTypeId == 0 && minPrice == 0 && minCapacity == 0)
            {
                LoadRooms();
                return;
            }

            List<RoomDto> rooms = _roomService.SearchRooms(
                    searchTerm,
                    selectedRoomTypeId,
                    minPrice,
                    maxPrice,
                    minCapacity,
                    maxCapacity
                ).ToList();
            BindDataToGrid(rooms);
        }

        private void cbRoomType_SelectedIndexChange(object sender, EventArgs e)
        {
            if (cbRoomType.SelectedValue is DataRowView drv)
            {
                selectedRoomTypeId = Convert.ToInt32(drv["RoomTypeId"]);
            }
            else
            {
                selectedRoomTypeId = Convert.ToInt32(cbRoomType.SelectedValue);
            }
        }

        private void dgvRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    _selectedRoom = new Models.Room();
                    DataGridViewRow dr = this.dgvRoom.Rows[e.RowIndex];
                    _selectedRoom.RoomId = int.Parse(dr.Cells[0].Value.ToString());
                    _selectedRoom.RoomNumber = dr.Cells[1].Value.ToString();
                    _selectedRoom.RoomTypeId = int.Parse(dr.Cells[2].Value.ToString());
                    _selectedRoom.Status = (RoomStatus)dr.Cells[4].Value;
                    _selectedRoom.Description = dr.Cells[6].Value.ToString();
                    _selectedRoom.DefaultPrice = int.Parse(dr.Cells[7].Value.ToString());
                    _selectedRoom.MaximumCapacity = int.Parse(dr.Cells[8].Value.ToString());
                    _selectedRoom.UpdatedAt = DateTime.Parse(dr.Cells[9].Value.ToString());

                    this.btnUpdate.Enabled = true;
                    this.btnDelete.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
