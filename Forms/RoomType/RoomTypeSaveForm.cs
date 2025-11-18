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

namespace HotelManagement.Forms.RoomType
{
    public partial class RoomTypeSaveForm : Form
    {
        public bool IsUpdate = false;
        public Models.RoomType roomType;
        public RoomTypeSaveForm()
        {
            InitializeComponent();
        }

        private void RoomTypeSaveForm_Load(object sender, EventArgs e)
        {
            if (IsUpdate && roomType != null)
            {
                this.Text = "Cập nhật loại phòng";
                this.txtBoxName.Text = roomType.Name;
                this.txtBoxDesc.Text = roomType.Description;
                this.txtBoxBasePrice.Text = roomType.BasePricePerNight.ToString();
                this.txtBoxMaxCapacity.Text = roomType.MaximumCapacity.ToString();
                this.btnSave.Text = "Cập nhật";
            }
            else
            {
                this.Text = "Thêm loại phòng mới";
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
                    roomType.Name = this.txtBoxName.Text;
                    roomType.Description = this.txtBoxDesc.Text;
                    roomType.BasePricePerNight = decimal.Parse(this.txtBoxBasePrice.Text);
                    roomType.MaximumCapacity = int.Parse(this.txtBoxMaxCapacity.Text);
                    bool result = roomTypeService.UpdateRoomType(roomType);
                    if (!result)
                    {
                        this.DialogResult = DialogResult.Cancel;
                        MessageBox.Show("Cập nhật loại phòng không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Cập nhật loại phòng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                }
                else
                {
                    roomType = new Models.RoomType
                    {
                        Name = this.txtBoxName.Text,
                        Description = this.txtBoxDesc.Text,
                        BasePricePerNight = decimal.Parse(this.txtBoxBasePrice.Text),
                        MaximumCapacity = int.Parse(this.txtBoxMaxCapacity.Text)
                    };
                    bool result = roomTypeService.CreateRoomType(roomType);
                    if (!result)
                    {
                        this.DialogResult = DialogResult.Cancel;
                        MessageBox.Show("Thêm loại phòng không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Thêm loại phòng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }  
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
