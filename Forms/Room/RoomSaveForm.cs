using HotelManagement.Business.Interfaces;
using HotelManagement.Business.Services;
using HotelManagement.Models;
using HotelManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.Forms.Room
{
    public partial class RoomSaveForm : Form
    {
        private RoomTypeService _roomTypeService;
        private RoomService _roomService;
        public bool IsUpdate = false;
        public Models.Room room;
        private List<Models.RoomType> roomTypes;
        private List<ItemCombo> roomStatuses;
        private int selectedRoomTypeId;
        private RoomStatus selectedStatus;
        public RoomSaveForm()
        {
            InitializeComponent();
            _roomTypeService = new RoomTypeService();
            _roomService = new RoomService();
            roomTypes = _roomTypeService.GetAllRoomTypes().ToList();
            Dictionary<int, string> roomTypeData = new Dictionary<int, string>
            {
                { 0, "Đã đặt" },
                { 1, "Trống" },
                { 2, "Sửa chữa" },
                { 3, "Không dùng" }
            };
            roomStatuses = new List<ItemCombo>();
            foreach (var pair in roomTypeData)
            {
                roomStatuses.Add(new ItemCombo(pair.Key, pair.Value));
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void RoomSaveForm_Load(object sender, EventArgs e)
        {
            this.cbRoomType.DataSource = roomTypes;
            this.cbRoomType.DisplayMember = "Name";
            this.cbRoomType.ValueMember = "RoomTypeId";

            this.cbStatus.DataSource = Enum.GetValues(typeof(RoomStatus));
            this.cbStatus.SelectedItem = RoomStatus.Free;
            if (IsUpdate && room != null)
            {
                this.Text = "Cập nhật phòng";
                this.txtBoxRoomNumber.Text = room.RoomNumber;
                this.txtBoxDesc.Text = room.Description;
                this.cbRoomType.SelectedValue = room.RoomTypeId;
                this.cbStatus.SelectedItem = room.Status;
                this.txtBoxPrice.Text = room.DefaultPrice.ToString();
                this.txtBoxMaxCap.Text = room.MaximumCapacity.ToString();
                this.btnSave.Text = "Cập nhật";
            }
            else
            {
                this.cbStatus.SelectedValue = 1;
                this.cbStatus.Enabled = false;
                this.Text = "Thêm phòng mới";
                this.btnSave.Text = "Thêm mới";
            }
            
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
            Models.RoomType selectedRoomType = roomTypes.FirstOrDefault(t => t.RoomTypeId == selectedRoomTypeId);
            if (selectedRoomType != null)
            {
                this.txtBoxPrice.Text = selectedRoomType.BasePricePerNight.ToString();
                this.txtBoxMaxCap.Text = selectedRoomType.MaximumCapacity.ToString();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RoomTypeService roomTypeService = new RoomTypeService();
            try
            {
                if (IsUpdate)
                {
                    room.RoomNumber = this.txtBoxRoomNumber.Text;
                    room.Description = this.txtBoxDesc.Text;
                    room.DefaultPrice = decimal.Parse(this.txtBoxPrice.Text);
                    room.MaximumCapacity = int.Parse(this.txtBoxMaxCap.Text);
                    room.RoomTypeId = selectedRoomTypeId;
                    room.Status = selectedStatus;
                    bool result = _roomService.UpdateRoom(room);
                    if (!result)
                    {
                        this.DialogResult = DialogResult.Cancel;
                        MessageBox.Show("Cập nhật phòng không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Cập nhật phòng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                }
                else
                {
                    room = new Models.Room
                    {
                        RoomNumber = this.txtBoxRoomNumber.Text,
                        Description = this.txtBoxDesc.Text,
                        RoomTypeId = selectedRoomTypeId,
                        DefaultPrice = decimal.Parse(this.txtBoxPrice.Text),
                        MaximumCapacity = int.Parse(this.txtBoxMaxCap.Text)
                    };
                    bool result = _roomService.CreateRoom(room);
                    if (!result)
                    {
                        this.DialogResult = DialogResult.Cancel;
                        MessageBox.Show("Thêm phòng không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Thêm phòng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbStatus_SelectedIndexChange(object sender, EventArgs e)
        {
            selectedStatus = (RoomStatus)this.cbStatus.SelectedItem;
        }
    }
}
