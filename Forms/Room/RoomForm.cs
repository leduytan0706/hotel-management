using HotelManagement.Business.Interfaces;
using HotelManagement.Business.Services;
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

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnDetail_Click(object sender, EventArgs e)
        {

        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            this.Name = "Quản lý phòng";
            this.btnDelete.Enabled = true;
            this.btnDetail.Enabled = true;
            this.btnUpdate.Enabled = true;
            LoadRooms();
        }

        private void LoadRooms()
        {
            List<Models.Room> rooms = _roomService.GetAllRooms().ToList();

            // Bind to DataGridView
            BindDataToGrid(rooms);
        }

        private void BindDataToGrid(List<Models.Room> rooms)
        {
            this.dgvRoom.AutoGenerateColumns = true;
            this.dgvRoom.DataSource = rooms;
            this.dgvRoom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoom.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

            List<Models.Room> rooms = _roomService.SearchRooms(
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
    }
}
