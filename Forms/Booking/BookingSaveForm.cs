using HotelManagement.Business.DTOs;
using HotelManagement.Models;
using HotelManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.Forms.Booking
{
    public partial class BookingSaveForm : Form
    {
        private readonly Business.Services.BookingService _bookingService;
        private readonly Business.Services.CustomerService _customerService;
        private readonly Business.Services.BookingServiceService _bookingServiceService;
        private readonly Business.Services.RoomService _roomService;
        public bool IsUpdate { get; set; } = false;
        public Models.Booking Booking { get; set; }
        public List<Models.BookingService> BookingServices { get; set; }
        public RoomDto SelectedRoom { get; set; }
        public Customer SelectedCustomer;
        public int selectedRoomId;
        private BookingStatus selectedStatus;
        private bool isCustomerExist = false;
        public BookingSaveForm()
        {
            InitializeComponent();
            _bookingService = new Business.Services.BookingService();
            _customerService = new Business.Services.CustomerService();
            _bookingServiceService = new Business.Services.BookingServiceService();
            _roomService = new Business.Services.RoomService();

            this.cbBookingStatus.DataSource = EnumHelper.ToList<BookingStatus>();
            this.cbBookingStatus.DisplayMember = "Display";
            this.cbBookingStatus.ValueMember = "Value";
        }

        private void BookingSaveForm_Load(object sender, EventArgs e)
        {
            
            if (IsUpdate)
            {
                this.Name = "Cập nhật đặt phòng";

                this.txtBoxFullName.Text = Booking.FullName;
                this.txtBoxPhone.Text = Booking.Phone;
                this.txtBoxIdNum.Text = Booking.IdNumber;
                SelectedCustomer = _customerService.GetCustomerByPhone(Booking.Phone);
                if (SelectedCustomer != null)
                {
                    isCustomerExist = true;
                    this.txtBoxEmail.Text = SelectedCustomer.Email;
                    this.txtBoxAddr.Text = SelectedCustomer.Address;
                }
                else
                {
                    isCustomerExist = false;
                }

                SelectedRoom = _roomService.GetRoomById(Booking.RoomId);
                this.txtBoxRoomType.Text = SelectedRoom.RoomTypeName;
                this.txtBoxRoomPrice.Text = Booking.BookedPrice.ToString();
                this.dtpBookingDate.Value = Booking.BookingDate;
                this.dtpBookingDate.Enabled = false;
                this.dtpCheckInDate.Value = Booking.CheckInDate ?? DateTime.Now;
                this.dtpCheckOutDate.Value = Booking.CheckOutDate ?? DateTime.Now;
                this.cbBookingStatus.SelectedValue = Booking.Status;
                this.cbBookingStatus.Enabled = false;
                if (Booking.Status == BookingStatus.Confirmed)
                {
                    this.btnConfirm.Enabled = false;
                }
                else if (Booking.Status == BookingStatus.CheckedIn)
                {
                    this.btnCancel.Enabled = false;
                    this.btnCheckin.Enabled = false;

                    this.dtpCheckInDate.Enabled = false;
                }
                else if (Booking.Status == BookingStatus.CheckedOut)
                {
                    this.btnCheckout.Enabled = false;
                    this.btnCancel.Enabled = false;

                    this.dtpCheckInDate.Enabled = false;
                    this.dtpCheckOutDate.Enabled = false;
                }
                else if (Booking.Status == BookingStatus.Cancelled)
                {
                    this.btnCheckin.Enabled = false;
                    this.btnCheckout.Enabled = false;
                    this.btnConfirm.Enabled = false;
                    this.btnSave.Enabled = false;
                    this.btnCancel.Enabled = false;

                    this.dtpCheckInDate.Enabled = false;
                    this.dtpCheckOutDate.Enabled = false;
                }
            }
            else
            {
                this.Name = "Thêm mới đặt phòng";
                Booking.BookingNumber = _bookingService.GetNewBookingNumber();
                Booking.RoomId = selectedRoomId;
                var selectedRoom = _roomService.GetRoomById(selectedRoomId);
                this.txtBoxRoomType.Text = selectedRoom.RoomTypeName;
                this.txtBoxRoomPrice.Text = selectedRoom.DefaultPrice.ToString();
                this.dtpBookingDate.Value = DateTime.Now;
                this.dtpCheckInDate.Value = DateTime.Now;
                this.cbBookingStatus.SelectedValue = BookingStatus.Pending;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            string phone = this.txtBoxPhone.Text.Trim();
            var customer = _customerService.GetCustomerByPhone(phone);
            if (customer != null)
            {
                isCustomerExist = true;
                this.txtBoxFullName.Text = customer.FullName;
                this.txtBoxEmail.Text = customer.Email;
                this.txtBoxIdNum.Text = customer.IdNumber;
                this.txtBoxAddr.Text = customer.Address;
            }
            else
            {
                isCustomerExist = false;
                MessageBox.Show("Khách hàng không tồn tại trong hệ thống!", "Thông báo");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn muốn lưu thông tin khách hàng không?", 
                "Xác nhận",                               
                MessageBoxButtons.YesNo,                     
                MessageBoxIcon.Warning                        
            );

            if (result == DialogResult.Yes)
            {
                Booking.FullName = txtBoxFullName.Text.Trim();
                Booking.Phone = txtBoxPhone.Text.Trim();
                Booking.IdNumber = txtBoxIdNum.Text.Trim();
                Booking.BookedPrice = decimal.Parse(txtBoxRoomPrice.Text.Trim());
                Booking.BookingDate = dtpBookingDate.Value;
                Booking.CheckInDate = dtpCheckInDate.Value;
                Booking.CheckOutDate = dtpCheckOutDate.Value;
                Booking.Status = (BookingStatus)cbBookingStatus.SelectedValue;

                if (isCustomerExist)
                {
                    SelectedCustomer.FullName = this.txtBoxFullName.Text.Trim();
                    SelectedCustomer.Email = this.txtBoxEmail.Text.Trim();
                    SelectedCustomer.IdNumber = this.txtBoxIdNum.Text.Trim();
                    SelectedCustomer.Address = this.txtBoxAddr.Text.Trim();
                    SelectedCustomer.Phone = this.txtBoxPhone.Text.Trim();
                    // Logic cập nhật thông tin khách hàng
                    MessageBox.Show("Thông tin khách hàng đã được cập nhật.", "Thông báo");

                    if (IsUpdate)
                    {
                        bool result1 = _bookingService.UpdateBooking(Booking, BookingServices);

                        bool result2 = _customerService.UpdateCustomer(SelectedCustomer);

                        if (result1 && result2)
                        {
                            MessageBox.Show("Lưu thông tin đặt phòng thành công!", "Thông báo");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Lưu thông tin đặt phòng không thành công!", "Thông báo");
                        }
                    }
                    else
                    {
                        bool result1 = _bookingService.CreateBooking(Booking, BookingServices);

                        bool result2 = _customerService.UpdateCustomer(SelectedCustomer);

                        if (result1 && result2)
                        {
                            MessageBox.Show("Lưu thông tin đặt phòng thành công!", "Thông báo");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Lưu thông tin đặt phòng không thành công!", "Thông báo");
                        }
                    }

                }
                else
                {
                    SelectedCustomer = new Customer
                    {
                        FullName = this.txtBoxFullName.Text.Trim(),
                        Phone = this.txtBoxPhone.Text.Trim(),
                        Email = this.txtBoxEmail.Text.Trim(),
                        IdNumber = this.txtBoxIdNum.Text.Trim(),
                        Address = this.txtBoxAddr.Text.Trim()
                    };

                    
                    if (IsUpdate)
                    {
                        bool result1 = _bookingService.UpdateBooking(Booking, BookingServices);

                        bool result2 = _customerService.CreateCustomer(SelectedCustomer);

                        if (result1 && result2)
                        {
                            MessageBox.Show("Lưu thông tin đặt phòng thành công!", "Thông báo");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Lưu thông tin đặt phòng không thành công!", "Thông báo");
                        }
                    }
                    else
                    {
                        bool result1 = _bookingService.CreateBookingAndCustomer(Booking, SelectedCustomer, BookingServices);

                        if (result1)
                        {
                            MessageBox.Show("Lưu thông tin đặt phòng thành công!", "Thông báo");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Lưu thông tin đặt phòng không thành công!", "Thông báo");
                        }
                    }
                }
            }
            else if (result == DialogResult.No)
            {
                
                Booking.FullName = txtBoxFullName.Text.Trim();
                Booking.Phone = txtBoxPhone.Text.Trim();
                Booking.IdNumber = txtBoxIdNum.Text.Trim();
                Booking.BookedPrice = decimal.Parse(txtBoxRoomPrice.Text.Trim());
                Booking.BookingDate = dtpBookingDate.Value;
                Booking.CheckInDate = dtpCheckInDate.Value;
                Booking.CheckOutDate = dtpCheckOutDate.Value;
                Booking.Status = (BookingStatus)cbBookingStatus.SelectedValue;

                bool result1 = _bookingService.CreateBooking(Booking, BookingServices);

                if (result1)
                {
                    MessageBox.Show("Lưu thông tin đặt phòng thành công!", "Thông báo");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lưu thông tin đặt phòng không thành công!", "Thông báo");
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

        }

        private void cbBookingStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBookingStatus.SelectedValue is BookingStatus status)
            {
                selectedStatus = status;
            }
        }
    }
}
