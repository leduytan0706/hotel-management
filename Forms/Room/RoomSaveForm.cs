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
        public Models.Room SelectedRoom;
        private List<Models.RoomType> roomTypes;
        private int selectedRoomTypeId;
        private RoomStatus selectedStatus;
        public RoomSaveForm()
        {
            InitializeComponent();
            _roomTypeService = new RoomTypeService();
            _roomService = new RoomService();
            roomTypes = _roomTypeService.GetAllRoomTypes().ToList();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void RoomSaveForm_Load(object sender, EventArgs e)
        {
            this.cbRoomType.DataSource = roomTypes;
            this.cbRoomType.DisplayMember = "Name";
            this.cbRoomType.ValueMember = "RoomTypeId";

            this.cbStatus.DataSource = EnumHelper.ToList<RoomStatus>();
            this.cbStatus.DisplayMember = "Display";
            this.cbStatus.ValueMember = "Value";
            if (IsUpdate && SelectedRoom != null)
            {
                this.Text = "Cập nhật phòng";
                this.txtBoxRoomNumber.Text = SelectedRoom.RoomNumber;
                this.txtBoxDesc.Text = SelectedRoom.Description;
                this.cbRoomType.SelectedValue = SelectedRoom.RoomTypeId;
                this.cbStatus.SelectedValue = SelectedRoom.Status;
                this.txtBoxPrice.Text = SelectedRoom.DefaultPrice.ToString();
                this.txtBoxMaxCap.Text = SelectedRoom.MaximumCapacity.ToString();
                this.btnSave.Text = "Cập nhật";
            }
            else
            {
                this.cbStatus.SelectedValue = RoomStatus.Free;
                //this.cbStatus.Enabled = false;
                this.Text = "Thêm phòng mới";
                this.btnSave.Text = "Thêm mới";
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RoomTypeService roomTypeService = new RoomTypeService();
            try
            {
                if (IsUpdate)
                {
                    SelectedRoom.RoomNumber = this.txtBoxRoomNumber.Text;
                    SelectedRoom.Description = this.txtBoxDesc.Text;
                    SelectedRoom.DefaultPrice = decimal.Parse(this.txtBoxPrice.Text);
                    SelectedRoom.MaximumCapacity = int.Parse(this.txtBoxMaxCap.Text);
                    SelectedRoom.RoomTypeId = selectedRoomTypeId;
                    SelectedRoom.Status = selectedStatus;
                    bool result = _roomService.UpdateRoom(SelectedRoom);
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
                    SelectedRoom = new Models.Room
                    {
                        RoomNumber = this.txtBoxRoomNumber.Text,
                        Description = this.txtBoxDesc.Text,
                        RoomTypeId = selectedRoomTypeId,
                        DefaultPrice = decimal.Parse(this.txtBoxPrice.Text),
                        MaximumCapacity = int.Parse(this.txtBoxMaxCap.Text)
                    };
                    bool result = _roomService.CreateRoom(SelectedRoom);
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

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.SelectedValue is RoomStatus status)
            {
                selectedStatus = status;
            }
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRoomType.SelectedValue is int id)
            {
                selectedRoomTypeId = id;
            }
            else if (cbRoomType.SelectedValue is Models.RoomType roomType)
            {
                selectedRoomTypeId = roomType.RoomTypeId;
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
    }
}
