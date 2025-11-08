using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data
{
    public class InvoiceRepository: BaseRepository<Invoice>
    {
        public InvoiceRepository(HotelDbContext context) : base(context) { }

        public Invoice GetInvoiceByBooking(int bookingId)
        {
            return _dbSet.FirstOrDefault(d => d.BookingId == bookingId);
        }
    }
}
